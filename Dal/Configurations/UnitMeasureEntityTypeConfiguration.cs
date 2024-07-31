using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class UnitMeasureEntityTypeConfiguration : IEntityTypeConfiguration<UnitMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitMeasure> builder)
        {
            builder
                .HasKey(x => x.UnitMeasureCode);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_UnitMeasure_Name");

            builder
                .Property(x => x.UnitMeasureCode)
                .HasColumnName("UnitMeasureCode")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("Primary key.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Unit of measure description.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("UnitMeasure", "Production");
        }
    }
}
