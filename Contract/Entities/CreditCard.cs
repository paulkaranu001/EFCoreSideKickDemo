using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Customer credit card information.
    /// <summary>
    public partial class CreditCard
    {
        /// <summary>
        /// Primary key for CreditCard records.
        /// <summary>
        [Required]
        [Key]
        public int CreditCardId { get; set; }

        /// <summary>
        /// Credit card name.
        /// <summary>
        [StringLength(50)]
        public string CardType { get; set; } = String.Empty;

        /// <summary>
        /// Credit card number.
        /// <summary>
        [StringLength(25)]
        public string CardNumber { get; set; } = String.Empty;

        /// <summary>
        /// Credit card expiration month.
        /// <summary>
        public byte ExpMonth { get; set; }

        /// <summary>
        /// Credit card expiration year.
        /// <summary>
        public short ExpYear { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// <summary>
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new HashSet<PersonCreditCard>();

        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
