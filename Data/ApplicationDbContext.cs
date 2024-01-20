using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class ApplicationDbContext:DbContext
    {
        //Connect by constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}

        //Second Method
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;database=inventory;User Id=sa;Password=1234;TrustServerCertificate=true;MultipleActiveResultSets=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
