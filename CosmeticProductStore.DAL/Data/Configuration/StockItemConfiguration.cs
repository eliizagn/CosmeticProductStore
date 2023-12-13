using CosmeticProductStore.DAL.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.DAL.Data.Configuration;

public class StockItemConfiguration
{
    public void Configure(EntityTypeBuilder<StockItem> builder)
    {
        builder.ToTable("stock_items");
        builder.HasKey(k => new { k.StoreCode, k.ProductId });

        builder.Property(p => p.Quantity).HasColumnName("quantity").HasMaxLength(20).IsRequired();
        builder.Property(p => p.Price).HasColumnName("price").HasMaxLength(20).IsRequired();

        builder.HasOne(stockItem => stockItem.Product)
            .WithMany(p => p.StockItems)
            .HasForeignKey(ps => ps.ProductId);

        builder.HasOne(stockItem => stockItem.Store)
            .WithMany(s => s.StockItems)
            .HasForeignKey(ps => ps.StoreCode);
    }
}
