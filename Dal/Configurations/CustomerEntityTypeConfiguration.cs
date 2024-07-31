using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(x => x.CustomerId);

            builder
                .HasIndex(x => x.AccountNumber)
                .IsUnique()
                .HasDatabaseName("AK_Customer_AccountNumber");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Customer_rowguid");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.PersonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Store)
                .WithMany(x => x.Stores)
                .HasForeignKey(x => x.StoreID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Territory)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.TerritoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("CustomerID")
                .HasPrecision(10, 0)
                .HasComment("Primary key.");

            builder
                .Property(x => x.AccountNumber)
                .HasColumnName("AccountNumber")
                .IsUnicode(false)
                .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))")
                .HasComment("Unique number identifying the customer assigned by the accounting system.");

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
                .ToTable("Customer", "Sales");
        }
    }
}
