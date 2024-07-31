using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductListPriceHistoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductListPriceHistory>
    {
        public void Configure(EntityTypeBuilder<ProductListPriceHistory> builder)
        {
            builder
                .HasKey(x => new { x.ProductID, x.StartDate });

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductListPriceHistories)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasComment("List price start date.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("List price end date");

            builder
                .Property(x => x.ListPrice)
                .HasColumnName("ListPrice")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Product list price.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductListPriceHistory", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ProductListPriceHistory_EndDate", "([EndDate]>=[StartDate] OR [EndDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductListPriceHistory_ListPrice", "([ListPrice]>(0.00))"));
        }
    }
}
