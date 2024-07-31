using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class VendorEntityTypeConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder
                .HasKey(x => x.BusinessEntityID);

            builder
                .HasIndex(x => x.AccountNumber)
                .IsUnique()
                .HasDatabaseName("AK_Vendor_AccountNumber");

            builder
                .HasOne(x => x.BusinessEntity)
                .WithOne(x => x.Vendor)
                .HasForeignKey<Vendor>(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.AccountNumber)
                .HasColumnName("AccountNumber")
                .IsUnicode(true)
                .HasComment("Vendor account (identification) number.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Company name.");

            builder
                .Property(x => x.CreditRating)
                .HasColumnName("CreditRating")
                .HasPrecision(3, 0)
                .HasComment("1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average");

            builder
                .Property(x => x.PreferredVendorStatus)
                .HasColumnName("PreferredVendorStatus")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");

            builder
                .Property(x => x.ActiveFlag)
                .HasColumnName("ActiveFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");

            builder
                .Property(x => x.PurchasingWebServiceUrl)
                .HasColumnName("PurchasingWebServiceURL")
                .IsUnicode(true)
                .HasComment("Vendor URL.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Vendor", "Purchasing");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Vendor_CreditRating", "([CreditRating]>=(1) AND [CreditRating]<=(5))"));
        }
    }
}
