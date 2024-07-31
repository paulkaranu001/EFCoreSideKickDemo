using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasKey(x => x.LocationId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_Location_Name");

            builder
                .Property(x => x.LocationId)
                .HasColumnName("LocationID")
                .HasPrecision(5, 0)
                .HasComment("Primary key for Location records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Location description.");

            builder
                .Property(x => x.CostRate)
                .HasColumnName("CostRate")
                .HasColumnType("smallmoney")
                .HasPrecision(10, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Standard hourly cost of the manufacturing location.");

            builder
                .Property(x => x.Availability)
                .HasColumnName("Availability")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Work capacity (in hours) of the manufacturing location.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Location", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Location_CostRate", "([CostRate]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_Location_Availability", "([Availability]>=(0.00))"));
        }
    }
}
