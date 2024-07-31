using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductProductPhotoEntityTypeConfiguration : IEntityTypeConfiguration<ProductProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductProductPhoto> builder)
        {
            builder
                .HasKey(x => new { x.ProductPhotoID, x.ProductID });

            builder
                .HasOne(x => x.ProductPhoto)
                .WithMany(x => x.ProductPhotoes)
                .HasForeignKey(x => x.ProductPhotoID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductProductPhotoes)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Primary)
                .HasColumnName("Primary")
                .HasDefaultValueSql("((0))")
                .HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductProductPhoto", "Production");
        }
    }
}
