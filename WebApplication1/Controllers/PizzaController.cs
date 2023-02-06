using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private static readonly string[] Desc = new[]
        {"Calzone", "Diavola", "Hawaii", "Scampi"};

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPizza")]
        public IEnumerable<Pizza> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Pizza
            {
                Date = DateTime.Now.AddDays(index),
                Name = Random.Shared.Next(-20, 55),
                Description = Desc[Random.Shared.Next(Desc.Length)]
            })
            .ToArray();
        }
    }
}
