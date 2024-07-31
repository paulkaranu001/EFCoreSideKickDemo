using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PhoneNumberTypeEntityTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder
                .HasKey(x => x.PhoneNumberTypeId);

            builder
                .Property(x => x.PhoneNumberTypeId)
                .HasColumnName("PhoneNumberTypeID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for telephone number type records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Name of the telephone number type");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("PhoneNumberType", "Person");
        }
    }
}
