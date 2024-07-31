using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ShoppingCartItemEntityTypeConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
                .HasKey(x => x.ShoppingCartItemId);

            builder
                .HasIndex(x => new { x.ShoppingCartId, x.ProductID })
                .HasDatabaseName("IX_ShoppingCartItem_ShoppingCartID_ProductID");

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ShoppingCartItems)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ShoppingCartItemId)
                .HasColumnName("ShoppingCartItemID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ShoppingCartItem records.");

            builder
                .Property(x => x.ShoppingCartId)
                .HasColumnName("ShoppingCartID")
                .IsUnicode(true)
                .HasComment("Shopping cart identification number.");

            builder
                .Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .HasPrecision(10, 0)
                .HasDefaultValueSql("((1))")
                .HasComment("Product quantity ordered.");

            builder
                .Property(x => x.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date the time the record was created.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ShoppingCartItem", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ShoppingCartItem_Quantity", "([Quantity]>=(1))"));
        }
    }
}
