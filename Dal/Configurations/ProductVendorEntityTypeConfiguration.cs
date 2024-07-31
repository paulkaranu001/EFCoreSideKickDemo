using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductVendorEntityTypeConfiguration : IEntityTypeConfiguration<ProductVendor>
    {
        public void Configure(EntityTypeBuilder<ProductVendor> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.ProductID });

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.ProductVendors)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductVendors)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductVendorUnitMeasureUnitMeasureCode)
                .WithMany(x => x.ProductVendors)
                .HasForeignKey(x => x.UnitMeasureCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.AverageLeadTime)
                .HasColumnName("AverageLeadTime")
                .HasPrecision(10, 0)
                .HasComment("The average span of time (in days) between placing an order with the vendor and receiving the purchased product.");

            builder
                .Property(x => x.StandardPrice)
                .HasColumnName("StandardPrice")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("The vendor's usual selling price.");

            builder
                .Property(x => x.LastReceiptCost)
                .HasColumnName("LastReceiptCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("The selling price when last purchased.");

            builder
                .Property(x => x.LastReceiptDate)
                .HasColumnName("LastReceiptDate")
                .HasColumnType("datetime")
                .HasComment("Date the product was last received by the vendor.");

            builder
                .Property(x => x.MinOrderQty)
                .HasColumnName("MinOrderQty")
                .HasPrecision(10, 0)
                .HasComment("The maximum quantity that should be ordered.");

            builder
                .Property(x => x.MaxOrderQty)
                .HasColumnName("MaxOrderQty")
                .HasPrecision(10, 0)
                .HasComment("The minimum quantity that should be ordered.");

            builder
                .Property(x => x.OnOrderQty)
                .HasColumnName("OnOrderQty")
                .HasPrecision(10, 0)
                .HasComment("The quantity currently on order.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductVendor", "Purchasing");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_AverageLeadTime", "([AverageLeadTime]>=(1))"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_StandardPrice", "([StandardPrice]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_LastReceiptCost", "([LastReceiptCost]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_MinOrderQty", "([MinOrderQty]>=(1))"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_MaxOrderQty", "([MaxOrderQty]>=(1))"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductVendor_OnOrderQty", "([OnOrderQty]>=(0))"));
        }
    }
}
