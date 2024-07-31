using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product subcategories. See ProductCategory table.
    /// <summary>
    public partial class ProductSubcategory
    {
        /// <summary>
        /// Primary key for ProductSubcategory records.
        /// <summary>
        [Required]
        [Key]
        public int ProductSubcategoryId { get; set; }

        public int ProductCategoryID { get; set; }

        /// <summary>
        /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
        /// <summary>
        public virtual ProductCategory ProductCategory { get; set; } = null!;

        /// <summary>
        /// Subcategory description.
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
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        /// <summary>
        public virtual ICollection<Product> ProductSubcategories { get; set; } = new HashSet<Product>();
    }
}
