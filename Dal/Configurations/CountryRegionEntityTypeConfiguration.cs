using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class CountryRegionEntityTypeConfiguration : IEntityTypeConfiguration<CountryRegion>
    {
        public void Configure(EntityTypeBuilder<CountryRegion> builder)
        {
            builder
                .HasKey(x => x.CountryRegionCode);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_CountryRegion_Name");

            builder
                .Property(x => x.CountryRegionCode)
                .HasColumnName("CountryRegionCode")
                .IsUnicode(true)
                .HasComment("ISO standard code for countries and regions.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Country or region name.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("CountryRegion", "Person");
        }
    }
}
