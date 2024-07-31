using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Employee information such as salary, department, and title.
    /// <summary>
    public partial class Employee
    {
        /// <summary>
        /// Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual Person BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Unique national identification number such as a social security number.
        /// <summary>
        [StringLength(15)]
        public string NationalIdnumber { get; set; } = String.Empty;

        /// <summary>
        /// Network login.
        /// <summary>
        [StringLength(256)]
        public string LoginId { get; set; } = String.Empty;

        /// <summary>
        /// Where the employee is located in corporate hierarchy.
        /// <summary>
        public object? OrganizationNode { get; set; }

        /// <summary>
        /// The depth of the employee in the corporate hierarchy.
        /// <summary>
        public short? OrganizationLevel { get; set; }

        /// <summary>
        /// Work title such as Buyer or Sales Representative.
        /// <summary>
        [StringLength(50)]
        public string JobTitle { get; set; } = String.Empty;

        /// <summary>
        /// Date of birth.
        /// <summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// M = Married, S = Single
        /// <summary>
        [StringLength(1)]
        public string MaritalStatus { get; set; } = String.Empty;

        /// <summary>
        /// M = Male, F = Female
        /// <summary>
        [StringLength(1)]
        public string Gender { get; set; } = String.Empty;

        /// <summary>
        /// Employee hired on this date.
        /// <summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.
        /// <summary>
        public bool SalariedFlag { get; set; }

        /// <summary>
        /// Number of available vacation hours.
        /// <summary>
        public short VacationHours { get; set; }

        /// <summary>
        /// Number of available sick leave hours.
        /// <summary>
        public short SickLeaveHours { get; set; }

        /// <summary>
        /// 0 = Inactive, 1 = Active
        /// <summary>
        public bool CurrentFlag { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Employee who controls the document.  Foreign key to Employee.BusinessEntityID
        /// <summary>
        public virtual ICollection<Document> DocumentEmployeeOwners { get; set; } = new HashSet<Document>();

        /// <summary>
        /// Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID
        /// <summary>
        public virtual SalesPerson SalesPerson { get; set; } = null!;

        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new HashSet<EmployeeDepartmentHistory>();

        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; set; } = new HashSet<EmployeePayHistory>();

        /// <summary>
        /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual ICollection<JobCandidate> JobCandidates { get; set; } = new HashSet<JobCandidate>();

        /// <summary>
        /// Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual ICollection<PurchaseOrderHeader> Employees { get; set; } = new HashSet<PurchaseOrderHeader>();
    }
}
