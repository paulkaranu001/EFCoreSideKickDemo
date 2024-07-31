using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product descriptions in several languages.
    /// <summary>
    public partial class ProductDescription
    {
        /// <summary>
        /// Primary key for ProductDescription records.
        /// <summary>
        [Required]
        [Key]
        public int ProductDescriptionId { get; set; }

        /// <summary>
        /// Description of the product.
        /// <summary>
        [StringLength(400)]
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        /// <summary>
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductDescriptions { get; set; } = new HashSet<ProductModelProductDescriptionCulture>();
    }
}
