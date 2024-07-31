using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Person_rowguid");

            builder
                .HasIndex(x => new { x.LastName, x.FirstName, x.MiddleName })
                .HasDatabaseName("IX_Person_LastName_FirstName_MiddleName");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.Person)
                .HasForeignKey<Person>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.PersonType)
                .HasColumnName("PersonType")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");

            builder
                .Property(x => x.NameStyle)
                .HasColumnName("NameStyle")
                .HasDefaultValueSql("((0))")
                .HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");

            builder
                .Property(x => x.Title)
                .HasColumnName("Title")
                .IsUnicode(true)
                .HasComment("A courtesy title. For example, Mr. or Ms.");

            builder
                .Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsUnicode(true)
                .HasComment("First name of the person.");

            builder
                .Property(x => x.MiddleName)
                .HasColumnName("MiddleName")
                .IsUnicode(true)
                .HasComment("Middle name or middle initial of the person.");

            builder
                .Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsUnicode(true)
                .HasComment("Last name of the person.");

            builder
                .Property(x => x.Suffix)
                .HasColumnName("Suffix")
                .IsUnicode(true)
                .HasComment("Surname suffix. For example, Sr. or Jr.");

            builder
                .Property(x => x.EmailPromotion)
                .HasColumnName("EmailPromotion")
                .HasPrecision(10, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");

            builder
                .Property(x => x.AdditionalContactInfo)
                .HasColumnName("AdditionalContactInfo")
                .HasColumnType("xml")
                .HasComment("Additional contact information about the person stored in xml format. ");

            builder
                .Property(x => x.Demographics)
                .HasColumnName("Demographics")
                .HasColumnType("xml")
                .HasComment("Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.");

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
                .ToTable("Person", "Person");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Person_EmailPromotion", "([EmailPromotion]>=(0) AND [EmailPromotion]<=(2))"))
                .ToTable(c => c.HasCheckConstraint("CK_Person_PersonType", "([PersonType] IS NULL OR (upper([PersonType])='GC' OR upper([PersonType])='SP' OR upper([PersonType])='EM' OR upper([PersonType])='IN' OR upper([PersonType])='VC' OR upper([PersonType])='SC'))"));
        }
    }
}
