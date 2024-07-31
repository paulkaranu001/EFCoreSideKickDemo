using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Store_rowguid");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.Store)
                .HasForeignKey<Store>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.SalesPerson)
                .WithMany(x => x.Stores)
                .HasForeignKey(x => x.SalesPersonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Name of the store.");

            builder
                .Property(x => x.Demographics)
                .HasColumnName("Demographics")
                .HasColumnType("xml")
                .HasComment("Demographic informationg about the store such as the number of employees, annual sales and store type.");

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
                .ToTable("Store", "Sales");
        }
    }
}
