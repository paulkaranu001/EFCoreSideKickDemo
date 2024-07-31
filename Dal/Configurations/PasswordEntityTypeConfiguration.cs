using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PasswordEntityTypeConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.Password)
                .HasForeignKey<Password>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("varchar")
                .IsUnicode(false)
                .HasComment("Password for the e-mail account.");

            builder
                .Property(x => x.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasColumnType("varchar")
                .IsUnicode(false)
                .HasComment("Random value concatenated with the password string before the password is hashed.");

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
                .ToTable("Password", "Person");
        }
    }
}
