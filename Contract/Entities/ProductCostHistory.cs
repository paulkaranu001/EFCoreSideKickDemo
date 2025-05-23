using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Changes in the cost of a product over time.
    /// <summary>
    public partial class ProductCostHistory
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        public int ProductID { get; set; }

        /// <summary>
        /// Product cost start date.
        /// <summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Product cost end date.
        /// <summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Standard cost of the product.
        /// <summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
