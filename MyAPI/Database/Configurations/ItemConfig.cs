using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Models;

namespace MyAPI.Database.Configurations
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasIndex(x => x.ID);
            builder
                .ToTable("Items");
        }
    }
}
