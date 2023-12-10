using CosmeticProductStore.DAL.Data.Configuration;
using CosmeticProductStore.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticProductStore.DAL.Data;

public class StoreDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Store>? Stores { get; set; }
    public DbSet<StockItem>? StockItems { get; set; }

    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new StoreConfiguration().Configure(modelBuilder.Entity<Store>());
        new StockItemConfiguration().Configure(modelBuilder.Entity<StockItem>());

        base.OnModelCreating(modelBuilder);
    }
}
