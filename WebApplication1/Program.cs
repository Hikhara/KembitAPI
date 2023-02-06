using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using WebApplication1.Models;
using WebApplication1.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<KasteelContext>(options => options.UseInMemoryDatabase("Kasteel"));
builder.Services.AddDbContext<KasteelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1Context")));
builder.Services.AddDbContext<KoningContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1Context")));

//builder.Services.AddScoped<DbContext, KasteelContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
