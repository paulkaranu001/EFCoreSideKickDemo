using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class DatabaseLogEntityTypeConfiguration : IEntityTypeConfiguration<DatabaseLog>
    {
        public void Configure(EntityTypeBuilder<DatabaseLog> builder)
        {
            builder
                .HasKey(x => x.DatabaseLogId);

            builder
                .Property(x => x.DatabaseLogId)
                .HasColumnName("DatabaseLogID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for DatabaseLog records.");

            builder
                .Property(x => x.PostTime)
                .HasColumnName("PostTime")
                .HasColumnType("datetime")
                .HasComment("The date and time the DDL change occurred.");

            builder
                .Property(x => x.DatabaseUser)
                .HasColumnName("DatabaseUser")
                .IsUnicode(true)
                .HasComment("The user who implemented the DDL change.");

            builder
                .Property(x => x.Event)
                .HasColumnName("Event")
                .IsUnicode(true)
                .HasComment("The type of DDL statement that was executed.");

            builder
                .Property(x => x.Schema)
                .HasColumnName("Schema")
                .IsUnicode(true)
                .HasComment("The schema to which the changed object belongs.");

            builder
                .Property(x => x.Object)
                .HasColumnName("Object")
                .IsUnicode(true)
                .HasComment("The object that was changed by the DDL statment.");

            builder
                .Property(x => x.Tsql)
                .HasColumnName("TSQL")
                .IsUnicode(true)
                .HasComment("The exact Transact-SQL statement that was executed.");

            builder
                .Property(x => x.XmlEvent)
                .HasColumnName("XmlEvent")
                .HasColumnType("xml")
                .HasComment("The raw XML data generated by database trigger.");

            builder
                .ToTable("DatabaseLog", "dbo");
        }
    }
}
