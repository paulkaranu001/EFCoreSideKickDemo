using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PersonPhoneEntityTypeConfiguration : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder
                .HasKey(x => new { x.PhoneNumberTypeID, x.BusinessEntityID, x.PhoneNumber });

            builder
                .HasIndex(x => x.PhoneNumber)
                .HasDatabaseName("IX_PersonPhone_PhoneNumber");

            builder
                .HasOne(x => x.PhoneNumberType)
                .WithMany(x => x.PhoneNumberTypes)
                .HasForeignKey(x => x.PhoneNumberTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.PersonPhones)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsUnicode(true)
                .HasComment("Telephone number identification number.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("PersonPhone", "Person");
        }
    }
}
