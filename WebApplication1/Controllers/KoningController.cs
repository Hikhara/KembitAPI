using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

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

        [HttpPost]
        public IActionResult CreateKonings(CreateKoning createKoning)
        {
            var koning = new Koning()
            {
                CastleId = createKoning.CastleId,
                Name = createKoning.Name,
                Location = createKoning.Location,
                Year = createKoning.Year
            };

            dbContext.Koning.Add(koning);
            dbContext.SaveChanges();

            return Ok(dbContext.Koning.ToList());
        }
        [HttpPut]
        [Route("{Id:int}")]
        public IActionResult UpdateKoning([FromRoute] int Id, UpdateKoning updateKoning)
        {
            var koning = dbContext.Koning.Find(Id);

            if (koning != null)
            {
                koning.CastleId = updateKoning.CastleId;
                koning.Name = updateKoning.Name;
                koning.Location = updateKoning.Location;
                koning.Year = updateKoning.Year;

                dbContext.SaveChanges();

                return Ok(dbContext.Koning.ToList());
            };

            return NotFound();
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteKoning([FromRoute] int Id)
        {
            var koning = dbContext.Koning.Find(Id);

            if (koning != null)
            {
                dbContext.Remove(koning);
                dbContext.SaveChanges();

                return Ok(dbContext.Koning.ToList());
            }

            return NotFound();
        }
    }
}
