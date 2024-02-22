using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasOne(a => a.Address)
                            .WithOne(e => e.Supplier)
                            .HasForeignKey<Address>(a => a.SupplierRefId);

            builder.HasMany(x => x.Items)
                    .WithOne(x => x.Supplier)
                    .HasForeignKey("SupplierRefId");
           
        }
    }
}
