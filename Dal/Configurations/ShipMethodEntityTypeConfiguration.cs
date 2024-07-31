using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ShipMethodEntityTypeConfiguration : IEntityTypeConfiguration<ShipMethod>
    {
        public void Configure(EntityTypeBuilder<ShipMethod> builder)
        {
            builder
                .HasKey(x => x.ShipMethodId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_ShipMethod_Name");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_ShipMethod_rowguid");

            builder
                .Property(x => x.ShipMethodId)
                .HasColumnName("ShipMethodID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ShipMethod records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Shipping company name.");

            builder
                .Property(x => x.ShipBase)
                .HasColumnName("ShipBase")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Minimum shipping charge.");

            builder
                .Property(x => x.ShipRate)
                .HasColumnName("ShipRate")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping charge per pound.");

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
                .ToTable("ShipMethod", "Purchasing");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ShipMethod_ShipBase", "([ShipBase]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_ShipMethod_ShipRate", "([ShipRate]>(0.00))"));
        }
    }
}
