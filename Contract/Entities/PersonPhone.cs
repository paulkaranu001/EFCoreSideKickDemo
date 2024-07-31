using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Telephone number and type of a person.
    /// <summary>
    public partial class PersonPhone
    {
        /// <summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        /// <summary>
        public virtual PhoneNumberType PhoneNumberType { get; set; } = null!;

        public int PhoneNumberTypeID { get; set; }

        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual Person BusinessEntity { get; set; } = null!;

        /// <summary>
        /// Telephone number identification number.
        /// <summary>
        [Required]
        [StringLength(25)]
        public string PhoneNumber { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
