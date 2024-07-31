using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.ProductId);

            builder
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("AK_Product_Name");

            builder
                .HasIndex(x => x.ProductNumber)
                .IsUnique()
                .HasDatabaseName("AK_Product_ProductNumber");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Product_rowguid");

            builder
                .HasOne(x => x.ProductUnitMeasureSizeUnitMeasureCode)
                .WithMany(x => x.ProductUnitMeasureSizeUnitMeasureCodes)
                .HasForeignKey(x => x.SizeUnitMeasureCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductUnitMeasureWeightUnitMeasureCode)
                .WithMany(x => x.ProductUnitMeasureWeightUnitMeasureCodes)
                .HasForeignKey(x => x.WeightUnitMeasureCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductSubcategory)
                .WithMany(x => x.ProductSubcategories)
                .HasForeignKey(x => x.ProductSubcategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ProductModel)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductModelID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ProductId)
                .HasColumnName("ProductID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for Product records.");

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(true)
                .HasComment("Name of the product.");

            builder
                .Property(x => x.ProductNumber)
                .HasColumnName("ProductNumber")
                .IsUnicode(true)
                .HasComment("Unique product identification number.");

            builder
                .Property(x => x.MakeFlag)
                .HasColumnName("MakeFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

            builder
                .Property(x => x.FinishedGoodsFlag)
                .HasColumnName("FinishedGoodsFlag")
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

            builder
                .Property(x => x.Color)
                .HasColumnName("Color")
                .IsUnicode(true)
                .HasComment("Product color.");

            builder
                .Property(x => x.SafetyStockLevel)
                .HasColumnName("SafetyStockLevel")
                .HasPrecision(5, 0)
                .HasComment("Minimum inventory quantity. ");

            builder
                .Property(x => x.ReorderPoint)
                .HasColumnName("ReorderPoint")
                .HasPrecision(5, 0)
                .HasComment("Inventory level that triggers a purchase order or work order. ");

            builder
                .Property(x => x.StandardCost)
                .HasColumnName("StandardCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Standard cost of the product.");

            builder
                .Property(x => x.ListPrice)
                .HasColumnName("ListPrice")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Selling price.");

            builder
                .Property(x => x.Size)
                .HasColumnName("Size")
                .IsUnicode(true)
                .HasComment("Product size.");

            builder
                .Property(x => x.Weight)
                .HasColumnName("Weight")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .HasComment("Product weight.");

            builder
                .Property(x => x.DaysToManufacture)
                .HasColumnName("DaysToManufacture")
                .HasPrecision(10, 0)
                .HasComment("Number of days required to manufacture the product.");

            builder
                .Property(x => x.ProductLine)
                .HasColumnName("ProductLine")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

            builder
                .Property(x => x.Class)
                .HasColumnName("Class")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("H = High, M = Medium, L = Low");

            builder
                .Property(x => x.Style)
                .HasColumnName("Style")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("W = Womens, M = Mens, U = Universal");

            builder
                .Property(x => x.SellStartDate)
                .HasColumnName("SellStartDate")
                .HasColumnType("datetime")
                .HasComment("Date the product was available for sale.");

            builder
                .Property(x => x.SellEndDate)
                .HasColumnName("SellEndDate")
                .HasColumnType("datetime")
                .HasComment("Date the product was no longer available for sale.");

            builder
                .Property(x => x.DiscontinuedDate)
                .HasColumnName("DiscontinuedDate")
                .HasColumnType("datetime")
                .HasComment("Date the product was discontinued.");

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
                .ToTable("Product", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Product_SafetyStockLevel", "([SafetyStockLevel]>(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_ReorderPoint", "([ReorderPoint]>(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_StandardCost", "([StandardCost]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_ListPrice", "([ListPrice]>=(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_Weight", "([Weight]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_DaysToManufacture", "([DaysToManufacture]>=(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_ProductLine", "(upper([ProductLine])='R' OR upper([ProductLine])='M' OR upper([ProductLine])='T' OR upper([ProductLine])='S' OR [ProductLine] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_Class", "(upper([Class])='H' OR upper([Class])='M' OR upper([Class])='L' OR [Class] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_Style", "(upper([Style])='U' OR upper([Style])='M' OR upper([Style])='W' OR [Style] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_Product_SellEndDate", "([SellEndDate]>=[SellStartDate] OR [SellEndDate] IS NULL)"));
        }
    }
}
