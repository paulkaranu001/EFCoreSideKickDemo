using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class WorkOrderEntityTypeConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder
                .HasKey(x => x.WorkOrderId);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.WorkOrders)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.ScrapReason)
                .WithMany(x => x.ScrapReasons)
                .HasForeignKey(x => x.ScrapReasonID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.WorkOrderId)
                .HasColumnName("WorkOrderID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for WorkOrder records.");

            builder
                .Property(x => x.OrderQty)
                .HasColumnName("OrderQty")
                .HasPrecision(10, 0)
                .HasComment("Product quantity to build.");

            builder
                .Property(x => x.StockedQty)
                .HasColumnName("StockedQty")
                .HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))")
                .HasComment("Quantity built and put in inventory.");

            builder
                .Property(x => x.ScrappedQty)
                .HasColumnName("ScrappedQty")
                .HasPrecision(5, 0)
                .HasComment("Quantity that failed inspection.");

            builder
                .Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .HasComment("Work order start date.");

            builder
                .Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .HasComment("Work order end date.");

            builder
                .Property(x => x.DueDate)
                .HasColumnName("DueDate")
                .HasColumnType("datetime")
                .HasComment("Work order due date.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("WorkOrder", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrder_OrderQty", "([OrderQty]>(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrder_ScrappedQty", "([ScrappedQty]>=(0))"))
                .ToTable(c => c.HasCheckConstraint("CK_WorkOrder_EndDate", "([EndDate]>=[StartDate] OR [EndDate] IS NULL)"));
        }
    }
}
