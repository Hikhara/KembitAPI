using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class KoningController : ControllerBase
    {
        //private readonly ILogger<KasteelController> _logger;
        private readonly KoningContext dbContext;

        //private static readonly string[] Desc = new[]
        //  {"Calzone", "Diavola", "Hawaii", "Scampi"};

        public KoningController(KoningContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //public KasteelController(ILogger<KasteelController> logger)
        //{
        //    _logger = logger;
        //
        //}


            
        [HttpGet]
        public IActionResult GetKonings()
        {
            //return Enumerable.Range(1, 5).Select(index => new Kasteel
            //{
                //Date = DateTime.Now.AddDays(index),
                //Name = Random.Shared.Next(-20, 55),
                //Name = Desc[Random.Shared.Next(Desc.Length)]
                //Name = 
            //})
            //.ToArray();

            return Ok(dbContext.Koning.ToList());
        }
    }
}
