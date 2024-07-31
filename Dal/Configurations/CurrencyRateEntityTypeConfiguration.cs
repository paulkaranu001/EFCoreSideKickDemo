using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class CurrencyRateEntityTypeConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder
                .HasKey(x => x.CurrencyRateId);

            builder
                .HasIndex(x => new { x.CurrencyRateDate, x.FromCurrencyCode, x.ToCurrencyCode })
                .IsUnique()
                .HasDatabaseName("AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode");

            builder
                .HasOne(x => x.CurrencyRateCurrencyFromCurrencyCode)
                .WithMany(x => x.CurrencyRateCurrencyFromCurrencyCodes)
                .HasForeignKey(x => x.FromCurrencyCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CurrencyRateCurrencyToCurrencyCode)
                .WithMany(x => x.CurrencyRateCurrencyToCurrencyCodes)
                .HasForeignKey(x => x.ToCurrencyCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.CurrencyRateId)
                .HasColumnName("CurrencyRateID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for CurrencyRate records.");

            builder
                .Property(x => x.CurrencyRateDate)
                .HasColumnName("CurrencyRateDate")
                .HasColumnType("datetime")
                .HasComment("Date and time the exchange rate was obtained.");

            builder
                .Property(x => x.AverageRate)
                .HasColumnName("AverageRate")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Average exchange rate for the day.");

            builder
                .Property(x => x.EndOfDayRate)
                .HasColumnName("EndOfDayRate")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Final exchange rate for the day.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("CurrencyRate", "Sales");
        }
    }
}
