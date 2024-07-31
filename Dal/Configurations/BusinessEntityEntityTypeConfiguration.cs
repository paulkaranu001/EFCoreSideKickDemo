using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class BusinessEntityEntityTypeConfiguration : IEntityTypeConfiguration<BusinessEntity>
    {
        public void Configure(EntityTypeBuilder<BusinessEntity> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_BusinessEntity_rowguid");

            builder
                .Property(x => x.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for all customers, vendors, and employees.");

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
                .ToTable("BusinessEntity", "Person");
        }
    }
}
