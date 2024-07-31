using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ScrapReasonEntityTypeConfiguration : IEntityTypeConfiguration<ScrapReason>
    {
        public void Configure(EntityTypeBuilder<ScrapReason> builder)
        {
            builder
                .HasKey(x => x.ScrapReasonId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_ScrapReason_Name");

            builder
                .Property(x => x.ScrapReasonId)
                .HasColumnName("ScrapReasonID")
                .HasPrecision(5, 0)
                .HasComment("Primary key for ScrapReason records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Failure description.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("ScrapReason", "Production");
        }
    }
}
