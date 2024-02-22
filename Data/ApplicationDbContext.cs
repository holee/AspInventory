using Inventory.Configurations;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            //modelBuilder.Entity<Supplier>()
            //              .HasOne(a => a.Address)
            //                .WithOne(e=>e.Supplier)
            //                .HasForeignKey<Address>(a=>a.SupplierRefId);

            //modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemConfiguration());


            modelBuilder.Entity<ItemSupplier>()
                    .HasKey(x => new { x.Item_Id, x.Supplier_Id });

            modelBuilder.Entity<Employee>()
                         .HasMany(x => x.Customers)
                         .WithMany(x => x.Employees)
                            .UsingEntity<Order>(
                                    j=>j.HasOne(x=>x.Customer)
                                        .WithMany()
                                        .HasForeignKey(x=>x.CustomerRefId),
                                    j=>j.HasOne(x=>x.Employee)
                                        .WithMany()
                                        .HasForeignKey(x=>x.EmployeeRefId),
                                    j =>
                                    {
                                        j.ToTable("orders");
                                        j.Property(x => x.Discount)
                                          .HasPrecision(18, 2);
                                        j.Property(x=>x.Total)
                                            .HasPrecision(18, 2);
                                    });               






            //modelBuilder.Entity<Item>()
            //              .HasMany(x => x.Suppliers)
            //              .WithMany(x => x.Items)
            //              .UsingEntity<ItemSupplier>(
            //                j=>j.HasOne(x=>x.Supplier)
            //                    .WithMany()
            //                    .HasForeignKey(x=>x.Supplier_Id),
            //                j=>j.HasOne(x=>x.Item)
            //                    .WithMany()
            //                    .HasForeignKey(x=>x.Item_Id));

            //modelBuilder.Entity<Item>()
            //             .HasMany(x => x.Suppliers)
            //             .WithMany(x => x.Items)
            //             .UsingEntity<ItemSupplier>();

            //modelBuilder.Entity<ItemSupplier>()
            //       .HasOne(x => x.Item)
            //       .WithMany(x => x.ItemSuppliers)
            //       .HasForeignKey(x => x.SupId);

            //modelBuilder.Entity<ItemSupplier>()
            //    .HasOne(x => x.Supplier)
            //    .WithMany(x => x.ItemSuppliers).HasForeignKey(x=>x.ItemId);




            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; } 
    }
}


//modelBuilder.Entity<Item>()
//                .HasOne(x=>x.Category)
//                    .WithMany(x => x.Items)
//                      .HasForeignKey("catId");

//modelBuilder.Entity<Category>()
//                    .HasMany(x => x.Items)
//                        .WithOne(x=>x.Category)
//                            .HasForeignKey("cid");


//modelBuilder.Entity<Item>()
//    .HasOne(x => x.Category)
//    .WithMany(x => x.Item)
//    .HasForeignKey(x => x.CateId);