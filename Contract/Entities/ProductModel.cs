using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product model classification.
    /// <summary>
    public partial class ProductModel
    {
        /// <summary>
        /// Primary key for ProductModel records.
        /// <summary>
        [Required]
        [Key]
        public int ProductModelId { get; set; }

        /// <summary>
        /// Product model description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Detailed product catalog information in xml format.
        /// <summary>
        public string? CatalogDescription { get; set; }

        /// <summary>
        /// Manufacturing instructions in xml format.
        /// <summary>
        public string? Instructions { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; } = new HashSet<ProductModelIllustration>();

        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new HashSet<ProductModelProductDescriptionCulture>();
    }
}
