using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PersonCreditCardEntityTypeConfiguration : IEntityTypeConfiguration<PersonCreditCard>
    {
        public void Configure(EntityTypeBuilder<PersonCreditCard> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.CreditCardID });

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.PersonCreditCards)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.PersonCreditCards)
                .HasForeignKey(x => x.CreditCardID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("PersonCreditCard", "Sales");
        }
    }
}
