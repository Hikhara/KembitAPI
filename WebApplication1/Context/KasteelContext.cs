using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class KasteelContext : DbContext
    {
        public KasteelContext(DbContextOptions <KasteelContext>options) : base(options)
        {

        }

        //public KasteelContext(DbSet<Kasteel> kasteels)
        //{
        //    Kasteels = kasteels;
        //}

        public DbSet<Kasteel> Kasteel { get; set; }

        //public static implicit operator KasteelContext(KasteelController v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
