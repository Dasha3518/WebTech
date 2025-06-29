using Fedorova.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fedorova.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("DefaultConnection");
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Category { get; set; }

    

    
    }
}