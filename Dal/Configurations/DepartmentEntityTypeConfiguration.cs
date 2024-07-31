using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(x => x.DepartmentId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_Department_Name");

            builder
                .Property(x => x.DepartmentId)
                .HasColumnName("DepartmentID")
                .HasPrecision(5, 0)
                .HasComment("Primary key for Department records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Name of the department.");

            builder
                .Property(x => x.GroupName)
                .HasColumnName("GroupName")
                .IsUnicode(true)
                .HasComment("Name of the group to which the department belongs.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Department", "HumanResources");
        }
    }
}
