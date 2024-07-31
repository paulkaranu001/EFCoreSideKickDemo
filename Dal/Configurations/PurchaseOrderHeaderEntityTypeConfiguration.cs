using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PurchaseOrderHeaderEntityTypeConfiguration : IEntityTypeConfiguration<PurchaseOrderHeader>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderHeader> builder)
        {
            builder
                .HasKey(x => x.PurchaseOrderId);

            builder
                .HasOne(x => x.Employee)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.EmployeeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Vendor)
                .WithMany(x => x.Vendors)
                .HasForeignKey(x => x.VendorID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ShipMethod)
                .WithMany(x => x.PurchaseOrderHeaders)
                .HasForeignKey(x => x.ShipMethodID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasPrecision(10, 0)
                .HasComment("Primary key.");

            builder
                .Property(x => x.RevisionNumber)
                .HasColumnName("RevisionNumber")
                .HasPrecision(3, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Incremental number to track changes to the purchase order over time.");

            builder
                .Property(x => x.Status)
                .HasColumnName("Status")
                .HasPrecision(3, 0)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");

            builder
                .Property(x => x.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Purchase order creation date.");

            builder
                .Property(x => x.ShipDate)
                .HasColumnName("ShipDate")
                .HasColumnType("datetime")
                .HasComment("Estimated shipment date from the vendor.");

            builder
                .Property(x => x.SubTotal)
                .HasColumnName("SubTotal")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.");

            builder
                .Property(x => x.TaxAmt)
                .HasColumnName("TaxAmt")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");

            builder
                .Property(x => x.Freight)
                .HasColumnName("Freight")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");

            builder
                .Property(x => x.TotalDue)
                .HasColumnName("TotalDue")
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", stored: true)
                .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("PurchaseOrderHeader", "Purchasing");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderHeader_Status", "([Status]>=(1) AND [Status]<=(4))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderHeader_ShipDate", "([ShipDate]>=[OrderDate] OR [ShipDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderHeader_SubTotal", "([SubTotal]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderHeader_TaxAmt", "([TaxAmt]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_PurchaseOrderHeader_Freight", "([Freight]>=(0.00))"));
        }
    }
}
