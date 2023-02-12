using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class KasteelController : ControllerBase
    {
        //private readonly ILogger<KasteelController> _logger;
        private readonly KasteelContext dbContext;

        //private static readonly string[] Desc = new[]
        //  {"Calzone", "Diavola", "Hawaii", "Scampi"};

        public KasteelController(KasteelContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //public KasteelController(ILogger<KasteelController> logger)
        //{
        //    _logger = logger;
        //
        //}


            
        [HttpGet]
        public IActionResult GetKasteels()
        {
            //return Enumerable.Range(1, 5).Select(index => new Kasteel
            //{
                //Date = DateTime.Now.AddDays(index),
                //Name = Random.Shared.Next(-20, 55),
                //Name = Desc[Random.Shared.Next(Desc.Length)]
                //Name = 
            //})
            //.ToArray();

            return Ok(dbContext.Kasteel.ToList());
        }

        [HttpPost]
        public IActionResult CreateKasteels(CreateKasteel createKasteel)
        {
            var kasteel = new Kasteel()
            {
            Name = createKasteel.Name
            };

            dbContext.Kasteel.Add(kasteel);
            dbContext.SaveChanges();

            return Ok(dbContext.Kasteel.ToList());
        }
        [HttpPut]
        [Route("{Id:int}")]
        public IActionResult UpdateKasteel([FromRoute] int Id, UpdateKasteel updateKasteel)
        {
            var kasteel = dbContext.Kasteel.Find(Id);

            if (kasteel != null)
            {
                kasteel.Name = updateKasteel.Name;

                dbContext.SaveChanges();

                return Ok(dbContext.Kasteel.ToList());
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteKasteel([FromRoute] int Id)
        {
            var kasteel = dbContext.Kasteel.Find(Id);

            if (kasteel != null)
            {
                dbContext.Remove(kasteel);
                dbContext.SaveChanges();

                return Ok(dbContext.Kasteel.ToList());
            }

            return NotFound();
        }
    }
}
