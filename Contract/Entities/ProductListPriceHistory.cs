using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Changes in the list price of a product over time.
    /// <summary>
    public partial class ProductListPriceHistory
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        public int ProductID { get; set; }

        /// <summary>
        /// List price start date.
        /// <summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// List price end date
        /// <summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Product list price.
        /// <summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
