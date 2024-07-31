using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table containing the departments within the Adventure Works Cycles company.
    /// <summary>
    public partial class Department
    {
        /// <summary>
        /// Primary key for Department records.
        /// <summary>
        [Required]
        [Key]
        public short DepartmentId { get; set; }

        /// <summary>
        /// Name of the department.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Name of the group to which the department belongs.
        /// <summary>
        [StringLength(50)]
        public string GroupName { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Department in which the employee worked including currently. Foreign key to Department.DepartmentID.
        /// <summary>
        public virtual ICollection<EmployeeDepartmentHistory> Departments { get; set; } = new HashSet<EmployeeDepartmentHistory>();
    }
}
