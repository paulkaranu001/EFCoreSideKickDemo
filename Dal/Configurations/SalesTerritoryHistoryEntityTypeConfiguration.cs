using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesTerritoryHistoryEntityTypeConfiguration : IEntityTypeConfiguration<SalesTerritoryHistory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritoryHistory> builder)
        {
            builder
                .HasKey(x => new { x.TerritoryID, x.BusinessEntityID, x.StartDate });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesTerritoryHistory_rowguid");

            builder
                .HasOne(x => x.Territory)
                .WithMany(x => x.SalesTerritoryHistories)
                .HasForeignKey(x => x.TerritoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.SalesTerritoryHistories)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasComment("Primary key. Date the sales representive started work in the territory.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("Date the sales representative left work in the territory.");

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
                .ToTable("SalesTerritoryHistory", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesTerritoryHistory_EndDate", "([EndDate]>=[StartDate] OR [EndDate] IS NULL)"));
        }
    }
}
