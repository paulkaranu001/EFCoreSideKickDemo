using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Sale discounts lookup table.
    /// <summary>
    public partial class SpecialOffer
    {
        /// <summary>
        /// Primary key for SpecialOffer records.
        /// <summary>
        [Required]
        [Key]
        public int SpecialOfferId { get; set; }

        /// <summary>
        /// Discount description.
        /// <summary>
        [StringLength(255)]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Discount precentage.
        /// <summary>
        public decimal DiscountPct { get; set; }

        /// <summary>
        /// Discount type category.
        /// <summary>
        [StringLength(50)]
        public string Type { get; set; } = String.Empty;

        /// <summary>
        /// Group the discount applies to such as Reseller or Customer.
        /// <summary>
        [StringLength(50)]
        public string Category { get; set; } = String.Empty;

        /// <summary>
        /// Discount start date.
        /// <summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Discount end date.
        /// <summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Minimum discount percent allowed.
        /// <summary>
        public int MinQty { get; set; }

        /// <summary>
        /// Maximum discount percent allowed.
        /// <summary>
        public int? MaxQty { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key for SpecialOfferProduct records.
        /// <summary>
        public virtual ICollection<SpecialOfferProduct> SpecialOffers { get; set; } = new HashSet<SpecialOfferProduct>();
    }
}
