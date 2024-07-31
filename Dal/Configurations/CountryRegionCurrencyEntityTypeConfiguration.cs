using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class CountryRegionCurrencyEntityTypeConfiguration : IEntityTypeConfiguration<CountryRegionCurrency>
    {
        public void Configure(EntityTypeBuilder<CountryRegionCurrency> builder)
        {
            builder
                .HasKey(x => new { x.CurrencyCode, x.CountryRegionCode });

            builder
                .HasOne(x => x.CountryRegionCurrencyCurrencyCurrencyCode)
                .WithMany(x => x.CountryRegionCurrencyCurrencyCurrencyCodes)
                .HasForeignKey(x => x.CurrencyCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CountryRegionCurrencyCountryRegionCountryRegionCode)
                .WithMany(x => x.CountryRegionCurrencies)
                .HasForeignKey(x => x.CountryRegionCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("CountryRegionCurrency", "Sales");
        }
    }
}
