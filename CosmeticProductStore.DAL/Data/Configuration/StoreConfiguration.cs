using CosmeticProductStore.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.DAL.Data.Configuration;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores");

        builder.HasKey(k => k.StoreCode);

        builder.Property(p => p.StoreCode).HasColumnName("store_code").IsRequired();

        builder.Property(p => p.Address).HasColumnName("store_address").IsRequired().HasMaxLength(25);
        builder.Property(p => p.Name).HasColumnName("store_name").HasMaxLength(20).IsRequired();
    }
}

