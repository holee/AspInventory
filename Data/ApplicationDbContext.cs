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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                            .HasKey(s=>s.Id);

            modelBuilder.Entity<Supplier>()
                          .HasOne(a => a.Address)
                            .WithOne(e=>e.Supplier)
                            .HasForeignKey<Address>(a=>a.SupplierRefId);

            //modelBuilder.Entity<Item>()
            //    .HasOne(x => x.Category)
            //    .WithMany(x => x.Item)
            //    .HasForeignKey(x => x.CateId);


            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
         
    }
}
