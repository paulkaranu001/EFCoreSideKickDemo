using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ErrorLogEntityTypeConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder
                .HasKey(x => x.ErrorLogId);

            builder
                .Property(x => x.ErrorLogId)
                .HasColumnName("ErrorLogID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for ErrorLog records.");

            builder
                .Property(x => x.ErrorTime)
                .HasColumnName("ErrorTime")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("The date and time at which the error occurred.");

            builder
                .Property(x => x.UserName)
                .HasColumnName("UserName")
                .IsUnicode(true)
                .HasComment("The user who executed the batch in which the error occurred.");

            builder
                .Property(x => x.ErrorNumber)
                .HasColumnName("ErrorNumber")
                .HasPrecision(10, 0)
                .HasComment("The error number of the error that occurred.");

            builder
                .Property(x => x.ErrorSeverity)
                .HasColumnName("ErrorSeverity")
                .HasPrecision(10, 0)
                .HasComment("The severity of the error that occurred.");

            builder
                .Property(x => x.ErrorState)
                .HasColumnName("ErrorState")
                .HasPrecision(10, 0)
                .HasComment("The state number of the error that occurred.");

            builder
                .Property(x => x.ErrorProcedure)
                .HasColumnName("ErrorProcedure")
                .IsUnicode(true)
                .HasComment("The name of the stored procedure or trigger where the error occurred.");

            builder
                .Property(x => x.ErrorLine)
                .HasColumnName("ErrorLine")
                .HasPrecision(10, 0)
                .HasComment("The line number at which the error occurred.");

            builder
                .Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .IsUnicode(true)
                .HasComment("The message text of the error that occurred.");

            builder
                .ToTable("ErrorLog", "dbo");
        }
    }
}
