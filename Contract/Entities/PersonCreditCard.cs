using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping people to their credit card information in the CreditCard table. 
    /// <summary>
    public partial class PersonCreditCard
    {
        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual Person BusinessEntity { get; set; } = null!;

        public int BusinessEntityID { get; set; }

        public int CreditCardID { get; set; }

        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// <summary>
        public virtual CreditCard CreditCard { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
