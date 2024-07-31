using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Work shift lookup table.
    /// <summary>
    public partial class Shift
    {
        /// <summary>
        /// Primary key for Shift records.
        /// <summary>
        [Required]
        [Key]
        public byte ShiftId { get; set; }

        /// <summary>
        /// Shift description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Shift start time.
        /// <summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Shift end time.
        /// <summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.
        /// <summary>
        public virtual ICollection<EmployeeDepartmentHistory> Shifts { get; set; } = new HashSet<EmployeeDepartmentHistory>();
    }
}
