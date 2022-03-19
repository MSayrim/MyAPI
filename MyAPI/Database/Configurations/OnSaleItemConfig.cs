using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Models;

namespace MyAPI.Database.Configurations
{
    public class OnSaleItemConfig : IEntityTypeConfiguration<OnSaleItem>
    {
        public void Configure(EntityTypeBuilder<OnSaleItem> builder)
        {
            builder.HasIndex(x=>x.ID);
            

            builder
                .ToTable("OnSale");
        }
    }
}