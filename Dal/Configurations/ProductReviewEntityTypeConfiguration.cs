using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductReviewEntityTypeConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder
                .HasKey(x => x.ProductReviewId);

            builder
                .HasIndex(x => new { x.Comments, x.ProductID, x.ReviewerName })
                .HasDatabaseName("IX_ProductReview_ProductID_Name");

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductReviews)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ProductReviewId)
                .HasColumnName("ProductReviewID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ProductReview records.");

            builder
                .Property(x => x.ReviewerName)
                .HasColumnName("ReviewerName")
                .IsUnicode(true)
                .HasComment("Name of the reviewer.");

            builder
                .Property(x => x.ReviewDate)
                .HasColumnName("ReviewDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date review was submitted.");

            builder
                .Property(x => x.EmailAddress)
                .HasColumnName("EmailAddress")
                .IsUnicode(true)
                .HasComment("Reviewer's e-mail address.");

            builder
                .Property(x => x.Rating)
                .HasColumnName("Rating")
                .HasPrecision(10, 0)
                .HasComment("Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.");

            builder
                .Property(x => x.Comments)
                .HasColumnName("Comments")
                .IsUnicode(true)
                .HasComment("Reviewer's comments");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductReview", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ProductReview_Rating", "([Rating]>=(1) AND [Rating]<=(5))"));
        }
    }
}
