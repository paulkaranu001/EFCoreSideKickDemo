using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasIndex(x => x.LoginId)
                .IsUnique()
                .HasDatabaseName("AK_Employee_LoginID");

            builder
                .HasIndex(x => x.NationalIdnumber)
                .IsUnique()
                .HasDatabaseName("AK_Employee_NationalIDNumber");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Employee_rowguid");

            builder
                .HasIndex(x => new { x.OrganizationLevel, x.OrganizationNode })
                .HasDatabaseName("IX_Employee_OrganizationLevel_OrganizationNode");

            builder
                .HasIndex(x => x.OrganizationNode)
                .HasDatabaseName("IX_Employee_OrganizationNode");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.Employee)
                .HasForeignKey<Employee>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.NationalIdnumber)
                .HasColumnName("NationalIDNumber")
                .IsUnicode(true)
                .HasComment("Unique national identification number such as a social security number.");

            builder
                .Property(x => x.LoginId)
                .HasColumnName("LoginID")
                .IsUnicode(true)
                .HasComment("Network login.");

            builder
                .Property(x => x.OrganizationNode)
                .HasColumnName("OrganizationNode")
                .HasComment("Where the employee is located in corporate hierarchy.");

            builder
                .Property(x => x.OrganizationLevel)
                .HasColumnName("OrganizationLevel")
                .HasComputedColumnSql("([OrganizationNode].[GetLevel]())")
                .HasComment("The depth of the employee in the corporate hierarchy.");

            builder
                .Property(x => x.JobTitle)
                .HasColumnName("JobTitle")
                .IsUnicode(true)
                .HasComment("Work title such as Buyer or Sales Representative.");

            builder
                .Property(x => x.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date")
                .HasComment("Date of birth.");

            builder
                .Property(x => x.MaritalStatus)
                .HasColumnName("MaritalStatus")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("M = Married, S = Single");

            builder
                .Property(x => x.Gender)
                .HasColumnName("Gender")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("M = Male, F = Female");

            builder
                .Property(x => x.HireDate)
                .HasColumnName("HireDate")
                .HasColumnType("date")
                .HasComment("Employee hired on this date.");

            builder
                .Property(x => x.SalariedFlag)
                .HasColumnName("SalariedFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");

            builder
                .Property(x => x.VacationHours)
                .HasColumnName("VacationHours")
                .HasPrecision(5, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Number of available vacation hours.");

            builder
                .Property(x => x.SickLeaveHours)
                .HasColumnName("SickLeaveHours")
                .HasPrecision(5, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Number of available sick leave hours.");

            builder
                .Property(x => x.CurrentFlag)
                .HasColumnName("CurrentFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");

            builder
                .Property(x => x.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Employee", "HumanResources");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Employee_BirthDate", "([BirthDate]>='1930-01-01' AND [BirthDate]<=dateadd(year,(-18),getdate()))"))
                .ToTable(c => c.HasCheckConstraint("CK_Employee_MaritalStatus", "(upper([MaritalStatus])='S' OR upper([MaritalStatus])='M')"))
                .ToTable(c => c.HasCheckConstraint("CK_Employee_HireDate", "([HireDate]>='1996-07-01' AND [HireDate]<=dateadd(day,(1),getdate()))"))
                .ToTable(c => c.HasCheckConstraint("CK_Employee_Gender", "(upper([Gender])='F' OR upper([Gender])='M')"))
                .ToTable(c => c.HasCheckConstraint("CK_Employee_VacationHours", "([VacationHours]>=(-40) AND [VacationHours]<=(240))"))
                .ToTable(c => c.HasCheckConstraint("CK_Employee_SickLeaveHours", "([SickLeaveHours]>=(0) AND [SickLeaveHours]<=(120))"));
        }
    }
}
