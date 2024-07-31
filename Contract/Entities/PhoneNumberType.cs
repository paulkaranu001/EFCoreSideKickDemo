using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Type of phone number of a person.
    /// <summary>
    public partial class PhoneNumberType
    {
        /// <summary>
        /// Primary key for telephone number type records.
        /// <summary>
        [Required]
        [Key]
        public int PhoneNumberTypeId { get; set; }

        /// <summary>
        /// Name of the telephone number type
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        /// <summary>
        public virtual ICollection<PersonPhone> PhoneNumberTypes { get; set; } = new HashSet<PersonPhone>();
    }
}
