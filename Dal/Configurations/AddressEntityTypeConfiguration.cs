using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(x => x.AddressId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Address_rowguid");

            builder
                .HasIndex(x => new { x.AddressLine1, x.AddressLine2, x.City, x.StateProvinceID, x.PostalCode })
                .IsUnique()
                .HasDatabaseName("IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode");

            builder
                .HasOne(x => x.StateProvince)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.StateProvinceID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.AddressId)
                .HasColumnName("AddressID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for Address records.");

            builder
                .Property(x => x.AddressLine1)
                .HasColumnName("AddressLine1")
                .IsUnicode(true)
                .HasComment("First street address line.");

            builder
                .Property(x => x.AddressLine2)
                .HasColumnName("AddressLine2")
                .IsUnicode(true)
                .HasComment("Second street address line.");

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .IsUnicode(true)
                .HasComment("Name of the city.");

            builder
                .Property(x => x.PostalCode)
                .HasColumnName("PostalCode")
                .IsUnicode(true)
                .HasComment("Postal code for the street address.");

            builder
                .Property(x => x.SpatialLocation)
                .HasColumnName("SpatialLocation")
                .HasComment("Latitude and longitude of this address.");

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
                .ToTable("Address", "Person");
        }
    }
}
