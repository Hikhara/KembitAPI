using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using WebApplication1.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllers();
//builder.Services.AddDbContext<KasteelContext>(options => options.UseInMemoryDatabase("Kasteel"));
builder.Services.AddDbContext<KasteelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1Context")));
builder.Services.AddDbContext<KoningContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1Context")));

//builder.Services.AddScoped<DbContext, KasteelContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



builder.Services.AddSwaggerGen(c => {
c.SwaggerDoc("v1", new OpenApiInfo { Title = "[anything]", Version = "v1" });
    /*c.AddSecurityDefinition("[auth scheme: same name as defined for asp.net]", new OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "X-API-KEY", //header with api key
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    });*/
    /*var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    c.AddSecurityRequirement(requirement);*/
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
    {
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "Authorization by x-api-key inside request's header",
        Scheme = "ApiKeyScheme"
    });

    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
