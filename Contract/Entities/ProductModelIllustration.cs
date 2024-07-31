using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping product models and illustrations.
    /// <summary>
    public partial class ProductModelIllustration
    {
        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ProductModel ProductModel { get; set; } = null!;

        public int ProductModelID { get; set; }

        public int IllustrationID { get; set; }

        /// <summary>
        /// Primary key. Foreign key to Illustration.IllustrationID.
        /// <summary>
        public virtual Illustration Illustration { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
