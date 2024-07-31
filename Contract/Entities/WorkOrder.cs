using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Manufacturing work orders.
    /// <summary>
    public partial class WorkOrder
    {
        /// <summary>
        /// Primary key for WorkOrder records.
        /// <summary>
        [Required]
        [Key]
        public int WorkOrderId { get; set; }

        public int ProductID { get; set; }

        public short? ScrapReasonID { get; set; }

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Product quantity to build.
        /// <summary>
        public int OrderQty { get; set; }

        /// <summary>
        /// Quantity built and put in inventory.
        /// <summary>
        public int StockedQty { get; set; }

        /// <summary>
        /// Quantity that failed inspection.
        /// <summary>
        public short ScrappedQty { get; set; }

        /// <summary>
        /// Work order start date.
        /// <summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Work order end date.
        /// <summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Work order due date.
        /// <summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Reason for inspection failure.
        /// <summary>
        public virtual ScrapReason? ScrapReason { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to WorkOrder.WorkOrderID.
        /// <summary>
        public virtual ICollection<WorkOrderRouting> WorkOrders { get; set; } = new HashSet<WorkOrderRouting>();
    }
}
