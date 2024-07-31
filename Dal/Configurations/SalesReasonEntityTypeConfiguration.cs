using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SalesReasonEntityTypeConfiguration : IEntityTypeConfiguration<SalesReason>
    {
        public void Configure(EntityTypeBuilder<SalesReason> builder)
        {
            builder
                .HasKey(x => x.SalesReasonId);

            builder
                .Property(x => x.SalesReasonId)
                .HasColumnName("SalesReasonID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for SalesReason records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Sales reason description.");

            builder
                .Property(x => x.ReasonType)
                .HasColumnName("ReasonType")
                .IsUnicode(true)
                .HasComment("Category the sales reason belongs to.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("SalesReason", "Sales");
        }
    }
}
