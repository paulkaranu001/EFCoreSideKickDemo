using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table of customer purchase reasons.
    /// <summary>
    public partial class SalesReason
    {
        /// <summary>
        /// Primary key for SalesReason records.
        /// <summary>
        [Required]
        [Key]
        public int SalesReasonId { get; set; }

        /// <summary>
        /// Sales reason description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Category the sales reason belongs to.
        /// <summary>
        [StringLength(50)]
        public string ReasonType { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to SalesReason.SalesReasonID.
        /// <summary>
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesReasons { get; set; } = new HashSet<SalesOrderHeaderSalesReason>();
    }
}
