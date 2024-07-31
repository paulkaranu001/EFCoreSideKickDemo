using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesOrderHeaderSalesReasonEntityTypeConfiguration : IEntityTypeConfiguration<SalesOrderHeaderSalesReason>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeaderSalesReason> builder)
        {
            builder
                .HasKey(x => new { x.SalesReasonID, x.SalesOrderID });

            builder
                .HasOne(x => x.SalesReason)
                .WithMany(x => x.SalesReasons)
                .HasForeignKey(x => x.SalesReasonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.SalesOrder)
                .WithMany(x => x.SalesOrderHeaderSalesReasons)
                .HasForeignKey(x => x.SalesOrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("SalesOrderHeaderSalesReason", "Sales");
        }
    }
}
