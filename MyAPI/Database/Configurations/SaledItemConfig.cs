using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Models;

namespace MyAPI.Database.Configurations
{
    public class SaledItemConfig : IEntityTypeConfiguration<SaledItem>
    {
        public void Configure(EntityTypeBuilder<SaledItem> builder)
        {
            builder.HasIndex(x => x.ID);
            builder
                .ToTable("SaledItems");
        }
    }
}
