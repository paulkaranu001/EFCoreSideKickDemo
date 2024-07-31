using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class EmployeeDepartmentHistoryEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeDepartmentHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartmentHistory> builder)
        {
            builder
                .HasKey(x => new { x.ShiftID, x.BusinessEntityID, x.DepartmentID, x.StartDate });

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.Shifts)
                .HasForeignKey(x => x.ShiftID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.EmployeeDepartmentHistories)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("date")
                .HasComment("Date the employee started work in the department.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date")
                .HasComment("Date the employee left the department. NULL = Current department.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("EmployeeDepartmentHistory", "HumanResources");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_EmployeeDepartmentHistory_EndDate", "([EndDate]>=[StartDate] OR [EndDate] IS NULL)"));
        }
    }
}
