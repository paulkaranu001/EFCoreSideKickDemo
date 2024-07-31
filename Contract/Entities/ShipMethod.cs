using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Shipping company lookup table.
    /// <summary>
    public partial class ShipMethod
    {
        /// <summary>
        /// Primary key for ShipMethod records.
        /// <summary>
        [Required]
        [Key]
        public int ShipMethodId { get; set; }

        /// <summary>
        /// Shipping company name.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Minimum shipping charge.
        /// <summary>
        public decimal ShipBase { get; set; }

        /// <summary>
        /// Shipping charge per pound.
        /// <summary>
        public decimal ShipRate { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();

        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// <summary>
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new HashSet<PurchaseOrderHeader>();
    }
}
