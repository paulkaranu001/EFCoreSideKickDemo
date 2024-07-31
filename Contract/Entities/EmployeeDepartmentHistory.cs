using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Employee department transfers.
    /// <summary>
    public partial class EmployeeDepartmentHistory
    {
        /// <summary>
        /// Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.
        /// <summary>
        public virtual Shift Shift { get; set; } = null!;

        public byte ShiftID { get; set; }

        public int BusinessEntityID { get; set; }

        public short DepartmentID { get; set; }

        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual Employee BusinessEntity { get; set; } = null!;

        /// <summary>
        /// Department in which the employee worked including currently. Foreign key to Department.DepartmentID.
        /// <summary>
        public virtual Department Department { get; set; } = null!;

        /// <summary>
        /// Date the employee started work in the department.
        /// <summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date the employee left the department. NULL = Current department.
        /// <summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
