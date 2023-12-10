﻿using CosmeticProductStore.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.DAL.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.Property(p => p.Id).HasColumnName("id").HasMaxLength(20).IsRequired();

    }
}
