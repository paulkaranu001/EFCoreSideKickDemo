using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ShiftEntityTypeConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder
                .HasKey(x => x.ShiftId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_Shift_Name");

            builder
                .HasIndex(x => new { x.StartTime, x.EndTime })
                .IsUnique()
                .HasDatabaseName("AK_Shift_StartTime_EndTime");

            builder
                .Property(x => x.ShiftId)
                .HasColumnName("ShiftID")
                .HasPrecision(3, 0)
                .HasComment("Primary key for Shift records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Shift description.");

            builder
                .Property(x => x.StartTime)
                .HasColumnName("StartTime")
                .HasComment("Shift start time.");

            builder
                .Property(x => x.EndTime)
                .HasColumnName("EndTime")
                .HasComment("Shift end time.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Shift", "HumanResources");
        }
    }
}
