using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Individual products associated with a specific sales order. See SalesOrderHeader.
    /// <summary>
    public partial class SalesOrderDetail
    {
        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// <summary>
        public virtual SalesOrderHeader SalesOrder { get; set; } = null!;

        public int SalesOrderID { get; set; }

        public int SpecialOfferID { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Primary key. One incremental unique number per product sold.
        /// <summary>
        [Required]
        public int SalesOrderDetailId { get; set; }

        /// <summary>
        /// Shipment tracking number supplied by the shipper.
        /// <summary>
        [StringLength(25)]
        public string? CarrierTrackingNumber { get; set; }

        /// <summary>
        /// Quantity ordered per product.
        /// <summary>
        public short OrderQty { get; set; }

        public virtual SpecialOfferProduct SpecialOfferIdProduct { get; set; } = null!;

        /// <summary>
        /// Selling price of a single product.
        /// <summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount amount.
        /// <summary>
        public decimal UnitPriceDiscount { get; set; }

        /// <summary>
        /// Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.
        /// <summary>
        public decimal LineTotal { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
