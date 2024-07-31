using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class BusinessEntityContactEntityTypeConfiguration : IEntityTypeConfiguration<BusinessEntityContact>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityContact> builder)
        {
            builder
                .HasKey(x => new { x.PersonID, x.ContactTypeID, x.BusinessEntityID });

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_BusinessEntityContact_rowguid");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.BusinessEntityContacts)
                .HasForeignKey(x => x.PersonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ContactType)
                .WithMany(x => x.ContactTypes)
                .HasForeignKey(x => x.ContactTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.BusinessEntityContacts)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

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
                .ToTable("BusinessEntityContact", "Person");
        }
    }
}
