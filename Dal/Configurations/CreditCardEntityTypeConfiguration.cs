using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class CreditCardEntityTypeConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .HasKey(x => x.CreditCardId);

            builder
                .HasIndex(x => x.CardNumber)
                .IsUnique()
                .HasDatabaseName("AK_CreditCard_CardNumber");

            builder
                .Property(x => x.CreditCardId)
                .HasColumnName("CreditCardID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for CreditCard records.");

            builder
                .Property(x => x.CardType)
                .HasColumnName("CardType")
                .IsUnicode(true)
                .HasComment("Credit card name.");

            builder
                .Property(x => x.CardNumber)
                .HasColumnName("CardNumber")
                .IsUnicode(true)
                .HasComment("Credit card number.");

            builder
                .Property(x => x.ExpMonth)
                .HasColumnName("ExpMonth")
                .HasPrecision(3, 0)
                .HasComment("Credit card expiration month.");

            builder
                .Property(x => x.ExpYear)
                .HasColumnName("ExpYear")
                .HasPrecision(5, 0)
                .HasComment("Credit card expiration year.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("CreditCard", "Sales");
        }
    }
}
