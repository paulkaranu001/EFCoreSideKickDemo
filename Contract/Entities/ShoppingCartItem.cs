using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Contains online customer orders until the order is submitted or cancelled.
    /// <summary>
    public partial class ShoppingCartItem
    {
        /// <summary>
        /// Primary key for ShoppingCartItem records.
        /// <summary>
        [Required]
        [Key]
        public int ShoppingCartItemId { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Shopping cart identification number.
        /// <summary>
        [StringLength(50)]
        public string ShoppingCartId { get; set; } = String.Empty;

        /// <summary>
        /// Product quantity ordered.
        /// <summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product ordered. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Date the time the record was created.
        /// <summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
