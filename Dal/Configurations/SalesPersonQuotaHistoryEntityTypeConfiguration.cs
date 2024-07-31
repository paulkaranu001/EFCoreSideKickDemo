using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesPersonQuotaHistoryEntityTypeConfiguration : IEntityTypeConfiguration<SalesPersonQuotaHistory>
    {
        public void Configure(EntityTypeBuilder<SalesPersonQuotaHistory> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.QuotaDate });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesPersonQuotaHistory_rowguid");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.SalesPersonQuotaHistories)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.QuotaDate)
                .HasColumnName("QuotaDate")
                .HasColumnType("datetime")
                .HasComment("Sales quota date.");

            builder
                .Property(x => x.SalesQuota)
                .HasColumnName("SalesQuota")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Sales quota amount.");

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
                .ToTable("SalesPersonQuotaHistory", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesPersonQuotaHistory_SalesQuota", "([SalesQuota]>(0.00))"));
        }
    }
}
