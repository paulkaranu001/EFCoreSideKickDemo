using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PurchaseOrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            builder
                .HasKey(x => new { x.PurchaseOrderID, x.PurchaseOrderDetailId });

            builder
                .HasOne(x => x.PurchaseOrder)
                .WithMany(x => x.PurchaseOrders)
                .HasForeignKey(x => x.PurchaseOrderID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.PurchaseOrderDetails)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.PurchaseOrderDetailId)
                .HasColumnName("PurchaseOrderDetailID")
                .HasPrecision(10, 0)
                .HasComment("Primary key. One line number per purchased product.");

            builder
                .Property(x => x.DueDate)
                .HasColumnName("DueDate")
                .HasColumnType("datetime")
                .HasComment("Date the product is expected to be received.");

            builder
                .Property(x => x.OrderQty)
                .HasColumnName("OrderQty")
                .HasPrecision(5, 0)
                .HasComment("Quantity ordered.");

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Vendor's selling price of a single product.");

            builder
                .Property(x => x.LineTotal)
                .HasColumnName("LineTotal")
                .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))")
                .HasComment("Per product subtotal. Computed as OrderQty * UnitPrice.");

            builder
                .Property(x => x.ReceivedQty)
                .HasColumnName("ReceivedQty")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .HasComment("Quantity actually received from the vendor.");

            builder
                .Property(x => x.RejectedQty)
                .HasColumnName("RejectedQty")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .HasComment("Quantity rejected during inspection.");

            builder
                .Property(x => x.StockedQty)
                .HasColumnName("StockedQty")
                .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))")
                .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("PurchaseOrderDetail", "Purchasing");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderDetail_OrderQty", "([OrderQty]>(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderDetail_UnitPrice", "([UnitPrice]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderDetail_ReceivedQty", "([ReceivedQty]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderDetail_RejectedQty", "([RejectedQty]>=(0.00))"));
        }
    }
}
