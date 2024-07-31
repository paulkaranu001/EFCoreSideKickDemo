using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesTaxRateEntityTypeConfiguration : IEntityTypeConfiguration<SalesTaxRate>
    {
        public void Configure(EntityTypeBuilder<SalesTaxRate> builder)
        {
            builder
                .HasKey(x => x.SalesTaxRateId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SalesTaxRate_rowguid");

            builder
                .HasIndex(x => new { x.StateProvinceID, x.TaxType })
                .IsUnique()
                .HasDatabaseName("AK_SalesTaxRate_StateProvinceID_TaxType");

            builder
                .HasOne(x => x.StateProvince)
                .WithMany(x => x.SalesTaxRates)
                .HasForeignKey(x => x.StateProvinceID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.SalesTaxRateId)
                .HasColumnName("SalesTaxRateID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for SalesTaxRate records.");

            builder
                .Property(x => x.TaxType)
                .HasColumnName("TaxType")
                .HasPrecision(3, 0)
                .HasComment("1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.");

            builder
                .Property(x => x.TaxRate)
                .HasColumnName("TaxRate")
                .HasColumnType("smallmoney")
                .HasPrecision(10, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax rate amount.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Tax rate description.");

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
                .ToTable("SalesTaxRate", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SalesTaxRate_TaxType", "([TaxType]>=(1) AND [TaxType]<=(3))"));
        }
    }
}
