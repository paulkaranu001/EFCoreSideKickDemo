using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductInventoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder
                .HasKey(x => new { x.ProductID, x.LocationID });

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductInventories)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.ProductInventories)
                .HasForeignKey(x => x.LocationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Shelf)
                .HasColumnName("Shelf")
                .IsUnicode(true)
                .HasComment("Storage compartment within an inventory location.");

            builder
                .Property(x => x.Bin)
                .HasColumnName("Bin")
                .HasPrecision(3, 0)
                .HasComment("Storage container on a shelf in an inventory location.");

            builder
                .Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .HasPrecision(5, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Quantity of products in the inventory location.");

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
                .ToTable("ProductInventory", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ProductInventory_Shelf", "([Shelf] like '[A-Za-z]' OR [Shelf]='N/A')"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductInventory_Bin", "([Bin]>=(0) AND [Bin]<=(100))"));
        }
    }
}
