using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductModelIllustrationEntityTypeConfiguration : IEntityTypeConfiguration<ProductModelIllustration>
    {
        public void Configure(EntityTypeBuilder<ProductModelIllustration> builder)
        {
            builder
                .HasKey(x => new { x.ProductModelID, x.IllustrationID });

            builder
                .HasOne(x => x.ProductModel)
                .WithMany(x => x.ProductModelIllustrations)
                .HasForeignKey(x => x.ProductModelID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Illustration)
                .WithMany(x => x.Illustrations)
                .HasForeignKey(x => x.IllustrationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductModelIllustration", "Production");
        }
    }
}
