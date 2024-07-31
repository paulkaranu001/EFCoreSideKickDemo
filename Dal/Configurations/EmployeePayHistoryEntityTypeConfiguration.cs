using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class EmployeePayHistoryEntityTypeConfiguration : IEntityTypeConfiguration<EmployeePayHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeePayHistory> builder)
        {
            builder
                .HasKey(x => new { x.BusinessEntityID, x.RateChangeDate });

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.EmployeePayHistories)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.RateChangeDate)
                .HasColumnName("RateChangeDate")
                .HasColumnType("datetime")
                .HasComment("Date the change in pay is effective");

            builder
                .Property(x => x.Rate)
                .HasColumnName("Rate")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Salary hourly rate.");

            builder
                .Property(x => x.PayFrequency)
                .HasColumnName("PayFrequency")
                .HasPrecision(3, 0)
                .HasComment("1 = Salary received monthly, 2 = Salary received biweekly");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("EmployeePayHistory", "HumanResources");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_EmployeePayHistory_PayFrequency", "([PayFrequency]=(2) OR [PayFrequency]=(1))"))
                .ToTable(c => c.HasCheckConstraint("CK_EmployeePayHistory_Rate", "([Rate]>=(6.50) AND [Rate]<=(200.00))"));
        }
    }
}
