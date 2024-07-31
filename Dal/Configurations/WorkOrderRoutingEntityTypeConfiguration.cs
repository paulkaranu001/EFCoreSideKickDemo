using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class WorkOrderRoutingEntityTypeConfiguration : IEntityTypeConfiguration<WorkOrderRouting>
    {
        public void Configure(EntityTypeBuilder<WorkOrderRouting> builder)
        {
            builder
                .HasKey(x => new { x.WorkOrderID, x.ProductId, x.OperationSequence });

            builder
                .HasIndex(x => x.ProductId)
                .HasDatabaseName("IX_WorkOrderRouting_ProductID");

            builder
                .HasOne(x => x.WorkOrder)
                .WithMany(x => x.WorkOrders)
                .HasForeignKey(x => x.WorkOrderID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.WorkOrderRoutings)
                .HasForeignKey(x => x.LocationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ProductId)
                .HasColumnName("ProductID")
                .HasPrecision(10, 0)
                .HasComment("Primary key. Foreign key to Product.ProductID.");

            builder
                .Property(x => x.OperationSequence)
                .HasColumnName("OperationSequence")
                .HasPrecision(5, 0)
                .HasComment("Primary key. Indicates the manufacturing process sequence.");

            builder
                .Property(x => x.ScheduledStartDate)
                .HasColumnName("ScheduledStartDate")
                .HasColumnType("datetime")
                .HasComment("Planned manufacturing start date.");

            builder
                .Property(x => x.ScheduledEndDate)
                .HasColumnName("ScheduledEndDate")
                .HasColumnType("datetime")
                .HasComment("Planned manufacturing end date.");

            builder
                .Property(x => x.ActualStartDate)
                .HasColumnName("ActualStartDate")
                .HasColumnType("datetime")
                .HasComment("Actual start date.");

            builder
                .Property(x => x.ActualEndDate)
                .HasColumnName("ActualEndDate")
                .HasColumnType("datetime")
                .HasComment("Actual end date.");

            builder
                .Property(x => x.ActualResourceHrs)
                .HasColumnName("ActualResourceHrs")
                .HasColumnType("decimal")
                .HasPrecision(9, 4)
                .HasComment("Number of manufacturing hours used.");

            builder
                .Property(x => x.PlannedCost)
                .HasColumnName("PlannedCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Estimated manufacturing cost.");

            builder
                .Property(x => x.ActualCost)
                .HasColumnName("ActualCost")
                .HasColumnType("money")
                .HasPrecision(19, 4)
                .HasComment("Actual manufacturing cost.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("WorkOrderRouting", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrderRouting_ScheduledEndDate", "([ScheduledEndDate]>=[ScheduledStartDate])"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrderRouting_ActualEndDate", "([ActualEndDate]>=[ActualStartDate] OR [ActualEndDate] IS NULL OR [ActualStartDate] IS NULL)"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrderRouting_ActualResourceHrs", "([ActualResourceHrs]>=(0.0000))"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrderRouting_PlannedCost", "([PlannedCost]>(0.00))"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrderRouting_ActualCost", "([ActualCost]>(0.00))"));
        }
    }
}
