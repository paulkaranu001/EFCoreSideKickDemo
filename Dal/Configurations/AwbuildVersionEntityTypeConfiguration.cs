using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class AwbuildVersionEntityTypeConfiguration : IEntityTypeConfiguration<AwbuildVersion>
    {
        public void Configure(EntityTypeBuilder<AwbuildVersion> builder)
        {
            builder
                .HasKey(x => x.SystemInformationId);

            builder
                .Property(x => x.SystemInformationId)
                .HasColumnName("SystemInformationID")
                .HasPrecision(3, 0)
                .HasComment("Primary key for AWBuildVersion records.");

            builder
                .Property(x => x.DatabaseVersion)
                .HasColumnName("Database Version")
                .IsUnicode(true)
                .HasComment("Version number of the database in 9.yy.mm.dd.00 format.");

            builder
                .Property(x => x.VersionDate)
                .HasColumnName("VersionDate")
                .HasColumnType("datetime")
                .HasComment("Date and time the record was last updated.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("AWBuildVersion", "dbo");
        }
    }
}
