using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Current version number of the AdventureWorks 2016 sample database. 
    /// <summary>
    public partial class AwbuildVersion
    {
        /// <summary>
        /// Primary key for AWBuildVersion records.
        /// <summary>
        [Required]
        [Key]
        public byte SystemInformationId { get; set; }

        /// <summary>
        /// Version number of the database in 9.yy.mm.dd.00 format.
        /// <summary>
        [StringLength(25)]
        public string DatabaseVersion { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime VersionDate { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
