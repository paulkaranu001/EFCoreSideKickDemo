using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// High-level product categorization.
    /// <summary>
    public partial class ProductCategory
    {
        /// <summary>
        /// Primary key for ProductCategory records.
        /// <summary>
        [Required]
        [Key]
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Category description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
        /// <summary>
        public virtual ICollection<ProductSubcategory> ProductCategories { get; set; } = new HashSet<ProductSubcategory>();
    }
}
