using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class EmailAddressEntityTypeConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.EmailAddressId });

            builder
                .HasIndex(x => x.EmailAddress1)
                .HasDatabaseName("IX_EmailAddress_EmailAddress");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.EmailAddresses)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.EmailAddressId)
                .HasColumnName("EmailAddressID")
                .HasPrecision(10, 0)
                .HasComment("Primary key. ID of this email address.");

            builder
                .Property(x => x.EmailAddress1)
                .HasColumnName("EmailAddress")
                .IsUnicode(true)
                .HasComment("E-mail address for the person.");

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
                .ToTable("EmailAddress", "Person");
        }
    }
}
