using System.Data.Entity;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public HeroContext() 
            : base("HeroContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}