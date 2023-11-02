using Microsoft.EntityFrameworkCore;
using TechOil.Models;

namespace TechOil.DataAccess
{
    public class TechOilDbContext : DbContext
    {
        public DbSet<Proyect> Proyects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-48IVMU9;Initial Catalog=TechOil;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true;");
        }
    }
}
