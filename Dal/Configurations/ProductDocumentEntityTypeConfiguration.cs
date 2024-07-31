using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductDocumentEntityTypeConfiguration : IEntityTypeConfiguration<ProductDocument>
    {
        public void Configure(EntityTypeBuilder<ProductDocument> builder)
        {
            builder
                .HasKey(x => new { x.ProductID, x.DocumentNode });

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductDocuments)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductDocumentDocumentDocumentNode)
                .WithMany(x => x.ProductDocumentDocumentDocumentNodes)
                .HasForeignKey(x => x.DocumentNode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductDocument", "Production");
        }
    }
}
