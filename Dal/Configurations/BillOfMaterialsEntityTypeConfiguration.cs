using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class BillOfMaterialsEntityTypeConfiguration : IEntityTypeConfiguration<BillOfMaterials>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterials> builder)
        {
            builder
                .HasKey(x => x.BillOfMaterialsId);

            builder
                .HasIndex(x => new { x.ProductAssemblyID, x.ComponentID, x.StartDate })
                .IsUnique()
                .HasDatabaseName("AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate");

            builder
                .HasOne(x => x.ProductAssembly)
                .WithMany(x => x.ProductAssemblies)
                .HasForeignKey(x => x.ProductAssemblyID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Component)
                .WithMany(x => x.Components)
                .HasForeignKey(x => x.ComponentID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.BillOfMaterialsUnitMeasureUnitMeasureCode)
                .WithMany(x => x.BillOfMaterialss)
                .HasForeignKey(x => x.UnitMeasureCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.BillOfMaterialsId)
                .HasColumnName("BillOfMaterialsID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for BillOfMaterials records.");

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date the component started being used in the assembly item.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("Date the component stopped being used in the assembly item.");

            builder
                .Property(x => x.Bomlevel)
                .HasColumnName("BOMLevel")
                .HasPrecision(5, 0)
                .HasComment("Indicates the depth the component is from its parent (AssemblyID).");

            builder
                .Property(x => x.PerAssemblyQty)
                .HasColumnName("PerAssemblyQty")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .HasDefaultValueSql("((1.00))")
                .HasComment("Quantity of the component needed to create the assembly.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("BillOfMaterials", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_BillOfMaterials_EndDate", "([EndDate]>[StartDate] OR [EndDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_BillOfMaterials_ProductAssemblyID", "([ProductAssemblyID]<>[ComponentID])"))
                .ToTable(c => c.HasCheckConstraint("CK_BillOfMaterials_BOMLevel", "([ProductAssemblyID] IS NULL AND [BOMLevel]=(0) AND [PerAssemblyQty]=(1.00) OR [ProductAssemblyID] IS NOT NULL AND [BOMLevel]>=(1))"))
                .ToTable(c => c.HasCheckConstraint("CK_BillOfMaterials_PerAssemblyQty", "([PerAssemblyQty]>=(1.00))"));
        }
    }
}
