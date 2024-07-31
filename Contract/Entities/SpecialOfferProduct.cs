using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping products to special offer discounts.
    /// <summary>
    public partial class SpecialOfferProduct
    {
        /// <summary>
        /// Primary key for SpecialOfferProduct records.
        /// <summary>
        public virtual SpecialOffer SpecialOffer { get; set; } = null!;

        public int SpecialOfferID { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Promotional code. Foreign key to SpecialOffer.SpecialOfferID.
        /// <summary>
        public virtual ICollection<SalesOrderDetail> SpecialOfferIdProducts { get; set; } = new HashSet<SalesOrderDetail>();
    }
}
