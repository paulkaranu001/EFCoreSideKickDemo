using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class StateProvinceEntityTypeConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder
                .HasKey(x => x.StateProvinceId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_StateProvince_Name");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_StateProvince_rowguid");

            builder
                .HasIndex(x => new { x.StateProvinceCode, x.CountryRegionCode })
                .IsUnique()
                .HasDatabaseName("AK_StateProvince_StateProvinceCode_CountryRegionCode");

            builder
                .HasOne(x => x.StateProvinceCountryRegionCountryRegionCode)
                .WithMany(x => x.StateProvinces)
                .HasForeignKey(x => x.CountryRegionCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Territory)
                .WithMany(x => x.StateProvinces)
                .HasForeignKey(x => x.TerritoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for StateProvince records.");

            builder
                .Property(x => x.StateProvinceCode)
                .HasColumnName("StateProvinceCode")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("ISO standard state or province code.");

            builder
                .Property(x => x.IsOnlyStateProvinceFlag)
                .HasColumnName("IsOnlyStateProvinceFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("State or province description.");

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
                .ToTable("StateProvince", "Person");
        }
    }
}
