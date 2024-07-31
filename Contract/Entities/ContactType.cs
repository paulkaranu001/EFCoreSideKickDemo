using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table containing the types of business entity contacts.
    /// <summary>
    public partial class ContactType
    {
        /// <summary>
        /// Primary key for ContactType records.
        /// <summary>
        [Required]
        [Key]
        public int ContactTypeId { get; set; }

        /// <summary>
        /// Contact type description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key.  Foreign key to ContactType.ContactTypeID.
        /// <summary>
        public virtual ICollection<BusinessEntityContact> ContactTypes { get; set; } = new HashSet<BusinessEntityContact>();
    }
}
