using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductModelProductDescriptionCultureEntityTypeConfiguration : IEntityTypeConfiguration<ProductModelProductDescriptionCulture>
    {
        public void Configure(EntityTypeBuilder<ProductModelProductDescriptionCulture> builder)
        {
            builder
                .HasKey(x => new { x.ProductModelID, x.ProductDescriptionID, x.CultureID });

            builder
                .HasOne(x => x.ProductModel)
                .WithMany(x => x.ProductModelProductDescriptionCultures)
                .HasForeignKey(x => x.ProductModelID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductDescription)
                .WithMany(x => x.ProductDescriptions)
                .HasForeignKey(x => x.ProductDescriptionID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Culture)
                .WithMany(x => x.Cultures)
                .HasForeignKey(x => x.CultureID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductModelProductDescriptionCulture", "Production");
        }
    }
}
