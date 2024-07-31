using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Manufacturing failure reasons lookup table.
    /// <summary>
    public partial class ScrapReason
    {
        /// <summary>
        /// Primary key for ScrapReason records.
        /// <summary>
        [Required]
        [Key]
        public short ScrapReasonId { get; set; }

        /// <summary>
        /// Failure description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Reason for inspection failure.
        /// <summary>
        public virtual ICollection<WorkOrder> ScrapReasons { get; set; } = new HashSet<WorkOrder>();
    }
}
