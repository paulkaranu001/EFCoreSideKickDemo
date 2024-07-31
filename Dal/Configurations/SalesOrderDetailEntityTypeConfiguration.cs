using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesOrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            builder
                .HasKey(x => new { x.SalesOrderID, x.SalesOrderDetailId });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesOrderDetail_rowguid");

            builder
                .HasOne(x => x.SalesOrder)
                .WithMany(x => x.SalesOrderDetails)
                .HasForeignKey(x => x.SalesOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.SpecialOfferIdProduct)
                .WithMany(x => x.SpecialOfferIdProducts)
                .HasForeignKey(x => new { x.SpecialOfferID, x.ProductID })
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.SalesOrderDetailId)
                .HasColumnName("SalesOrderDetailID")
                .HasPrecision(10, 0)
                .HasComment("Primary key. One incremental unique number per product sold.");

            builder
                .Property(x => x.CarrierTrackingNumber)
                .HasColumnName("CarrierTrackingNumber")
                .IsUnicode(true)
                .HasComment("Shipment tracking number supplied by the shipper.");

            builder
                .Property(x => x.OrderQty)
                .HasColumnName("OrderQty")
                .HasPrecision(5, 0)
                .HasComment("Quantity ordered per product.");

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Selling price of a single product.");

            builder
                .Property(x => x.UnitPriceDiscount)
                .HasColumnName("UnitPriceDiscount")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.0))")
                .HasComment("Discount amount.");

            builder
                .Property(x => x.LineTotal)
                .HasColumnName("LineTotal")
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))")
                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");

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
                .ToTable("SalesOrderDetail", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderDetail_OrderQty", "([OrderQty]>(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderDetail_UnitPrice", "([UnitPrice]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderDetail_UnitPriceDiscount", "([UnitPriceDiscount]>=(0.00))"));
        }
    }
}
