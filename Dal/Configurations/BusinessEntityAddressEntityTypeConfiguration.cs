using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class BusinessEntityAddressEntityTypeConfiguration : IEntityTypeConfiguration<BusinessEntityAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityAddress> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.AddressTypeID, x.AddressID });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_BusinessEntityAddress_rowguid");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.BusinessEntityAddresses)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.AddressType)
                .WithMany(x => x.AddressTypes)
                .HasForeignKey(x => x.AddressTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.AddressID)
                .OnDelete(DeleteBehavior.NoAction);

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
                .ToTable("BusinessEntityAddress", "Person");
        }
    }
}
