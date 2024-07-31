using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductPhotoEntityTypeConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder
                .HasKey(x => x.ProductPhotoId);

            builder
                .Property(x => x.ProductPhotoId)
                .HasColumnName("ProductPhotoID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ProductPhoto records.");

            builder
                .Property(x => x.ThumbNailPhoto)
                .HasColumnName("ThumbNailPhoto")
                .HasComment("Small image of the product.");

            builder
                .Property(x => x.ThumbnailPhotoFileName)
                .HasColumnName("ThumbnailPhotoFileName")
                .IsUnicode(true)
                .HasComment("Small image file name.");

            builder
                .Property(x => x.LargePhoto)
                .HasColumnName("LargePhoto")
                .HasComment("Large image of the product.");

            builder
                .Property(x => x.LargePhotoFileName)
                .HasColumnName("LargePhotoFileName")
                .IsUnicode(true)
                .HasComment("Large image file name.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductPhoto", "Production");
        }
    }
}
