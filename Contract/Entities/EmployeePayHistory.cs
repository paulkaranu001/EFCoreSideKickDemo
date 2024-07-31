using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Employee pay history.
    /// <summary>
    public partial class EmployeePayHistory
    {
        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual Employee BusinessEntity { get; set; } = null!;

        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Date the change in pay is effective
        /// <summary>
        [Required]
        public DateTime RateChangeDate { get; set; }

        /// <summary>
        /// Salary hourly rate.
        /// <summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 1 = Salary received monthly, 2 = Salary received biweekly
        /// <summary>
        public byte PayFrequency { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
