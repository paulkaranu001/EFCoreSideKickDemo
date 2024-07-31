using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesPersonEntityTypeConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesPerson_rowguid");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.SalesPerson)
                .HasForeignKey<SalesPerson>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Territory)
                .WithMany(x => x.SalesPersons)
                .HasForeignKey(x => x.TerritoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.SalesQuota)
                .HasColumnName("SalesQuota")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Projected yearly sales.");

            builder
                .Property(x => x.Bonus)
                .HasColumnName("Bonus")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Bonus due if quota is met.");

            builder
                .Property(x => x.CommissionPct)
                .HasColumnName("CommissionPct")
                .HasColumnType("smallmoney")
                .HasPrecision(10, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Commision percent received per sale.");

            builder
                .Property(x => x.SalesYtd)
                .HasColumnName("SalesYTD")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total year to date.");

            builder
                .Property(x => x.SalesLastYear)
                .HasColumnName("SalesLastYear")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total of previous year.");

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
                .ToTable("SalesPerson", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesPerson_SalesQuota", "([SalesQuota]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesPerson_Bonus", "([Bonus]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesPerson_CommissionPct", "([CommissionPct]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesPerson_SalesYTD", "([SalesYTD]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SalesPerson_SalesLastYear", "([SalesLastYear]>=(0.00))"));
        }
    }
}
