using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping product descriptions and the language the description is written in.
    /// <summary>
    public partial class ProductModelProductDescriptionCulture
    {
        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ProductModel ProductModel { get; set; } = null!;

        public int ProductModelID { get; set; }

        public int ProductDescriptionID { get; set; }

        [StringLength(6)]
        public string CultureID { get; set; } = String.Empty;

        /// <summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        /// <summary>
        public virtual ProductDescription ProductDescription { get; set; } = null!;

        /// <summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        /// <summary>
        public virtual Culture Culture { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
