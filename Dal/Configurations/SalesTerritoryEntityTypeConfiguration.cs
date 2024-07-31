using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesTerritoryEntityTypeConfiguration : IEntityTypeConfiguration<SalesTerritory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritory> builder)
        {
            builder
                .HasKey(x => x.TerritoryId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_SalesTerritory_Name");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesTerritory_rowguid");

            builder
                .HasOne(x => x.SalesTerritoryCountryRegionCountryRegionCode)
                .WithMany(x => x.SalesTerritories)
                .HasForeignKey(x => x.CountryRegionCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for SalesTerritory records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Sales territory description");

            builder
                .Property(x => x.Group)
                .HasColumnName("Group")
                .IsUnicode(true)
                .HasComment("Geographic area to which the sales territory belong.");

            builder
                .Property(x => x.SalesYtd)
                .HasColumnName("SalesYTD")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales in the territory year to date.");

            builder
                .Property(x => x.SalesLastYear)
                .HasColumnName("SalesLastYear")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales in the territory the previous year.");

            builder
                .Property(x => x.CostYtd)
                .HasColumnName("CostYTD")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Business costs in the territory year to date.");

            builder
                .Property(x => x.CostLastYear)
                .HasColumnName("CostLastYear")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Business costs in the territory the previous year.");

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
                .ToTable("SalesTerritory", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesTerritory_SalesYTD", "([SalesYTD]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesTerritory_SalesLastYear", "([SalesLastYear]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesTerritory_CostYTD", "([CostYTD]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesTerritory_CostLastYear", "([CostLastYear]>=(0.00))"));
        }
    }
}
