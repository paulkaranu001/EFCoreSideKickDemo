using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SpecialOfferProductEntityTypeConfiguration : IEntityTypeConfiguration<SpecialOfferProduct>
    {
        public void Configure(EntityTypeBuilder<SpecialOfferProduct> builder)
        {
            builder
                .HasKey(x => new { x.SpecialOfferID, x.ProductID });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SpecialOfferProduct_rowguid");

            builder
                .HasOne(x => x.SpecialOffer)
                .WithMany(x => x.SpecialOffers)
                .HasForeignKey(x => x.SpecialOfferID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.SpecialOfferProducts)
                .HasForeignKey(x => x.ProductID)
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
                .ToTable("SpecialOfferProduct", "Sales");
        }
    }
}
