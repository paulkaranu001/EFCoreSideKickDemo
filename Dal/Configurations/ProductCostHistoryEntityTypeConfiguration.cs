using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductCostHistoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCostHistory>
    {
        public void Configure(EntityTypeBuilder<ProductCostHistory> builder)
        {
            builder
                .HasKey(x => new { x.ProductID, x.StartDate });

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductCostHistories)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasComment("Product cost start date.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("Product cost end date.");

            builder
                .Property(x => x.StandardCost)
                .HasColumnName("StandardCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Standard cost of the product.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ProductCostHistory", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_ProductCostHistory_EndDate", "([EndDate]>=[StartDate] OR [EndDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_ProductCostHistory_StandardCost", "([StandardCost]>=(0.00))"));
        }
    }
}
