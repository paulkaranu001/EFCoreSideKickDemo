using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Résumés submitted to Human Resources by job applicants.
    /// <summary>
    public partial class JobCandidate
    {
        /// <summary>
        /// Primary key for JobCandidate records.
        /// <summary>
        [Required]
        [Key]
        public int JobCandidateId { get; set; }

        public int? BusinessEntityID { get; set; }

        /// <summary>
        /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
        /// <summary>
        public virtual Employee? BusinessEntity { get; set; }

        /// <summary>
        /// Résumé in XML format.
        /// <summary>
        public string? Resume { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
