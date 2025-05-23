using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Individual products associated with a specific purchase order. See PurchaseOrderHeader.
    /// <summary>
    public partial class PurchaseOrderDetail
    {
        /// <summary>
        /// Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.
        /// <summary>
        public virtual PurchaseOrderHeader PurchaseOrder { get; set; } = null!;

        public int PurchaseOrderID { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Primary key. One line number per purchased product.
        /// <summary>
        [Required]
        public int PurchaseOrderDetailId { get; set; }

        /// <summary>
        /// Date the product is expected to be received.
        /// <summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Quantity ordered.
        /// <summary>
        public short OrderQty { get; set; }

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Vendor's selling price of a single product.
        /// <summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Per product subtotal. Computed as OrderQty * UnitPrice.
        /// <summary>
        public decimal LineTotal { get; set; }

        /// <summary>
        /// Quantity actually received from the vendor.
        /// <summary>
        public decimal ReceivedQty { get; set; }

        /// <summary>
        /// Quantity rejected during inspection.
        /// <summary>
        public decimal RejectedQty { get; set; }

        /// <summary>
        /// Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.
        /// <summary>
        public decimal StockedQty { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
