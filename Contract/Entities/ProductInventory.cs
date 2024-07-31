using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product inventory information.
    /// <summary>
    public partial class ProductInventory
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        public int ProductID { get; set; }

        public short LocationID { get; set; }

        /// <summary>
        /// Inventory location identification number. Foreign key to Location.LocationID. 
        /// <summary>
        public virtual Location Location { get; set; } = null!;

        /// <summary>
        /// Storage compartment within an inventory location.
        /// <summary>
        [StringLength(10)]
        public string Shelf { get; set; } = String.Empty;

        /// <summary>
        /// Storage container on a shelf in an inventory location.
        /// <summary>
        public byte Bin { get; set; }

        /// <summary>
        /// Quantity of products in the inventory location.
        /// <summary>
        public short Quantity { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
