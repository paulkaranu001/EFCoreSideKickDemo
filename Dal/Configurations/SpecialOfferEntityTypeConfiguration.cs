using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class SpecialOfferEntityTypeConfiguration : IEntityTypeConfiguration<SpecialOffer>
    {
        public void Configure(EntityTypeBuilder<SpecialOffer> builder)
        {
            builder
                .HasKey(x => x.SpecialOfferId);

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_SpecialOffer_rowguid");

            builder
                .Property(x => x.SpecialOfferId)
                .HasColumnName("SpecialOfferID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for SpecialOffer records.");

            builder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .IsUnicode(true)
                .HasComment("Discount description.");

            builder
                .Property(x => x.DiscountPct)
                .HasColumnName("DiscountPct")
                .HasColumnType("smallmoney")
                .HasPrecision(10, 4)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Discount precentage.");

            builder
                .Property(x => x.Type)
                .HasColumnName("Type")
                .IsUnicode(true)
                .HasComment("Discount type category.");

            builder
                .Property(x => x.Category)
                .HasColumnName("Category")
                .IsUnicode(true)
                .HasComment("Group the discount applies to such as Reseller or Customer.");

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasComment("Discount start date.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("Discount end date.");

            builder
                .Property(x => x.MinQty)
                .HasColumnName("MinQty")
                .HasPrecision(10, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Minimum discount percent allowed.");

            builder
                .Property(x => x.MaxQty)
                .HasColumnName("MaxQty")
                .HasPrecision(10, 0)
                .HasComment("Maximum discount percent allowed.");

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
                .ToTable("SpecialOffer", "Sales");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_SpecialOffer_EndDate", "([EndDate]>=[StartDate])"))
                .ToTable(c => c.HasCheckConstraint("CK_SpecialOffer_DiscountPct", "([DiscountPct]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_SpecialOffer_MinQty", "([MinQty]>=(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_SpecialOffer_MaxQty", "([MaxQty]>=(0))"));
        }
    }
}
