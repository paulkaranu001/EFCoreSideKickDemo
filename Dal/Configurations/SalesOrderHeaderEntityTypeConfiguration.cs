using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesOrderHeaderEntityTypeConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder
                .HasKey(x => x.SalesOrderId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesOrderHeader_rowguid");

            builder
                .HasIndex(x => x.SalesOrderNumber)
                .IsUnique()
                .HasDatabaseName("AK_SalesOrderHeader_SalesOrderNumber");

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.SalesPerson)
                .WithMany(x => x.SalesOrderHeaders)
                .HasForeignKey(x => x.SalesPersonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Territory)
                .WithMany(x => x.SalesOrderHeaders)
                .HasForeignKey(x => x.TerritoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BillToAddress)
                .WithMany(x => x.BillToAddresses)
                .HasForeignKey(x => x.BillToAddressID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ShipToAddress)
                .WithMany(x => x.ShipToAddresses)
                .HasForeignKey(x => x.ShipToAddressID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ShipMethod)
                .WithMany(x => x.SalesOrderHeaders)
                .HasForeignKey(x => x.ShipMethodID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.SalesOrderHeaders)
                .HasForeignKey(x => x.CreditCardID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CurrencyRate)
                .WithMany(x => x.CurrencyRates)
                .HasForeignKey(x => x.CurrencyRateID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.SalesOrderId)
                .HasColumnName("SalesOrderID")
                .HasPrecision(10, 0)
                .HasComment("Primary key.");

            builder
                .Property(x => x.RevisionNumber)
                .HasColumnName("RevisionNumber")
                .HasPrecision(3, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Incremental number to track changes to the sales order over time.");

            builder
                .Property(x => x.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Dates the sales order was created.");

            builder
                .Property(x => x.DueDate)
                .HasColumnName("DueDate")
                .HasColumnType("datetime")
                .HasComment("Date the order is due to the customer.");

            builder
                .Property(x => x.ShipDate)
                .HasColumnName("ShipDate")
                .HasColumnType("datetime")
                .HasComment("Date the order was shipped to the customer.");

            builder
                .Property(x => x.Status)
                .HasColumnName("Status")
                .HasPrecision(3, 0)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");

            builder
                .Property(x => x.OnlineOrderFlag)
                .HasColumnName("OnlineOrderFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");

            builder
                .Property(x => x.SalesOrderNumber)
                .HasColumnName("SalesOrderNumber")
                .IsUnicode(true)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))")
                .HasComment("Unique sales order identification number.");

            builder
                .Property(x => x.PurchaseOrderNumber)
                .HasColumnName("PurchaseOrderNumber")
                .IsUnicode(true)
                .HasComment("Customer purchase order number reference. ");

            builder
                .Property(x => x.AccountNumber)
                .HasColumnName("AccountNumber")
                .IsUnicode(true)
                .HasComment("Financial accounting number reference.");

            builder
                .Property(x => x.CreditCardApprovalCode)
                .HasColumnName("CreditCardApprovalCode")
                .HasColumnType("varchar")
                .IsUnicode(false)
                .HasComment("Approval code provided by the credit card company.");

            builder
                .Property(x => x.SubTotal)
                .HasColumnName("SubTotal")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");

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
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))")
                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.");

            builder
                .Property(x => x.Comment)
                .HasColumnName("Comment")
                .IsUnicode(true)
                .HasComment("Sales representative comments.");

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
                .ToTable("SalesOrderHeader", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_Status", "([Status]>=(0) AND [Status]<=(8))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_DueDate", "([DueDate]>=[OrderDate])"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_ShipDate", "([ShipDate]>=[OrderDate] OR [ShipDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_SubTotal", "([SubTotal]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_TaxAmt", "([TaxAmt]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesOrderHeader_Freight", "([Freight]>=(0.00))"));
        }
    }
}
