using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Companies from whom Adventure Works Cycles purchases parts or other goods.
    /// <summary>
    public partial class Vendor
    {
        /// <summary>
        /// Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID
        /// <summary>
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Vendor account (identification) number.
        /// <summary>
        [StringLength(15)]
        public string AccountNumber { get; set; } = String.Empty;

        /// <summary>
        /// Company name.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// 1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average
        /// <summary>
        public byte CreditRating { get; set; }

        /// <summary>
        /// 0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.
        /// <summary>
        public bool PreferredVendorStatus { get; set; }

        /// <summary>
        /// 0 = Vendor no longer used. 1 = Vendor is actively used.
        /// <summary>
        public bool ActiveFlag { get; set; }

        /// <summary>
        /// Vendor URL.
        /// <summary>
        [StringLength(1024)]
        public string? PurchasingWebServiceUrl { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to Vendor.BusinessEntityID.
        /// <summary>
        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new HashSet<ProductVendor>();

        /// <summary>
        /// Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.
        /// <summary>
        public virtual ICollection<PurchaseOrderHeader> Vendors { get; set; } = new HashSet<PurchaseOrderHeader>();
    }
}
