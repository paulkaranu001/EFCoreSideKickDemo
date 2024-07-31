using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping sales orders to sales reason codes.
    /// <summary>
    public partial class SalesOrderHeaderSalesReason
    {
        /// <summary>
        /// Primary key. Foreign key to SalesReason.SalesReasonID.
        /// <summary>
        public virtual SalesReason SalesReason { get; set; } = null!;

        public int SalesReasonID { get; set; }

        public int SalesOrderID { get; set; }

        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// <summary>
        public virtual SalesOrderHeader SalesOrder { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
