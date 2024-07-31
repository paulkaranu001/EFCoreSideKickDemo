using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductModelEntityTypeConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder
                .HasKey(x => x.ProductModelId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_ProductModel_Name");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_ProductModel_rowguid");

            builder
                .Property(x => x.ProductModelId)
                .HasColumnName("ProductModelID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ProductModel records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Product model description.");

            builder
                .Property(x => x.CatalogDescription)
                .HasColumnName("CatalogDescription")
                .HasColumnType("xml")
                .HasComment("Detailed product catalog information in xml format.");

            builder
                .Property(x => x.Instructions)
                .HasColumnName("Instructions")
                .HasColumnType("xml")
                .HasComment("Manufacturing instructions in xml format.");

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
                .ToTable("ProductModel", "Production");
        }
    }
}
