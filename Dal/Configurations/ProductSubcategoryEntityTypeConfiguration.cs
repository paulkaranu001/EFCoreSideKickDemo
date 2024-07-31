using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductSubcategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            builder
                .HasKey(x => x.ProductSubcategoryId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_ProductSubcategory_Name");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_ProductSubcategory_rowguid");

            builder
                .HasOne(x => x.ProductCategory)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductCategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ProductSubcategoryId)
                .HasColumnName("ProductSubcategoryID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ProductSubcategory records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Subcategory description.");

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
                .ToTable("ProductSubcategory", "Production");
        }
    }
}
