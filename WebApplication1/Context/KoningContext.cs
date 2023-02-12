using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class KoningContext : DbContext
    {
        public KoningContext(DbContextOptions<KoningContext> options) : base(options)
        {

        }

        //public KasteelContext(DbSet<Kasteel> kasteels)
        //{
        //    Kasteels = kasteels;
        //}

        public DbSet<Koning> Koning { get; set; }

        //public static implicit operator KasteelContext(KasteelController v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
