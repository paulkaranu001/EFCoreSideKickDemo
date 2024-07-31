using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Where to send a person email.
    /// <summary>
    public partial class EmailAddress
    {
        /// <summary>
        /// Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID
        /// <summary>
        public virtual Person BusinessEntity { get; set; } = null!;

        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Primary key. ID of this email address.
        /// <summary>
        [Required]
        public int EmailAddressId { get; set; }

        /// <summary>
        /// E-mail address for the person.
        /// <summary>
        [StringLength(50)]
        public string? EmailAddress1 { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
