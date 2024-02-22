using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasOne(x => x.Category)
                 .WithMany(x => x.Items)
                 .HasForeignKey(x=>x.CateId);

        
        }
    }
}
