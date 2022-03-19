using Microsoft.EntityFrameworkCore;
using MyAPI.Database.Configurations;
using MyAPI.Models;

namespace MyAPI.Database
{
    public class DotaItemAuctionDB : DbContext
    {

        public DotaItemAuctionDB(DbContextOptions<DotaItemAuctionDB> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .ApplyConfiguration(new ItemConfig());
            builder
                .ApplyConfiguration(new OnSaleItemConfig());

            builder
                .ApplyConfiguration(new UserConfig());

            builder
                .ApplyConfiguration(new SaledItemConfig());


        }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OnSaleItem> OnSaleItems { get; set; }
        public DbSet<SaledItem> SaledItems { get; set; }
    }
}
