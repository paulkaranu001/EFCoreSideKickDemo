using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductDescriptionEntityTypeConfiguration : IEntityTypeConfiguration<ProductDescription>
    {
        public void Configure(EntityTypeBuilder<ProductDescription> builder)
        {
            builder
                .HasKey(x => x.ProductDescriptionId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_ProductDescription_rowguid");

            builder
                .Property(x => x.ProductDescriptionId)
                .HasColumnName("ProductDescriptionID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ProductDescription records.");

            builder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .IsUnicode(true)
                .HasComment("Description of the product.");

            builder
                .Property(x => x.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductDescription", "Production");
        }
    }
}
