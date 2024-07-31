using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class IllustrationEntityTypeConfiguration : IEntityTypeConfiguration<Illustration>
    {
        public void Configure(EntityTypeBuilder<Illustration> builder)
        {
            builder
                .HasKey(x => x.IllustrationId);

            builder
                .Property(x => x.IllustrationId)
                .HasColumnName("IllustrationID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for Illustration records.");

            builder
                .Property(x => x.Diagram)
                .HasColumnName("Diagram")
                .HasColumnType("xml")
                .HasComment("Illustrations used in manufacturing instructions. Stored as XML.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Illustration", "Production");
        }
    }
}
