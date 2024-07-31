using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class TransactionHistoryEntityTypeConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            builder
                .HasKey(x => x.TransactionId);

            builder
                .HasIndex(x => new { x.ReferenceOrderId, x.ReferenceOrderLineId })
                .HasDatabaseName("IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID");

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.TransactionHistories)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.TransactionId)
                .HasColumnName("TransactionID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for TransactionHistory records.");

            builder
                .Property(x => x.ReferenceOrderId)
                .HasColumnName("ReferenceOrderID")
                .HasPrecision(10, 0)
                .HasComment("Purchase order, sales order, or work order identification number.");

            builder
                .Property(x => x.ReferenceOrderLineId)
                .HasColumnName("ReferenceOrderLineID")
                .HasPrecision(10, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Line number associated with the purchase order, sales order, or work order.");

            builder
                .Property(x => x.TransactionDate)
                .HasColumnName("TransactionDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time of the transaction.");

            builder
                .Property(x => x.TransactionType)
                .HasColumnName("TransactionType")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder");

            builder
                .Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .HasPrecision(10, 0)
                .HasComment("Product quantity.");

            builder
                .Property(x => x.ActualCost)
                .HasColumnName("ActualCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Product cost.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("TransactionHistory", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_TransactionHistory_TransactionType", "(upper([TransactionType])='P' OR upper([TransactionType])='S' OR upper([TransactionType])='W')"));
        }
    }
}
