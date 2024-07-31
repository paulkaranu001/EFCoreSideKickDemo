using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Types of addresses stored in the Address table. 
    /// <summary>
    public partial class AddressType
    {
        /// <summary>
        /// Primary key for AddressType records.
        /// <summary>
        [Required]
        [Key]
        public int AddressTypeId { get; set; }

        /// <summary>
        /// Address type description. For example, Billing, Home, or Shipping.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to AddressType.AddressTypeID.
        /// <summary>
        public virtual ICollection<BusinessEntityAddress> AddressTypes { get; set; } = new HashSet<BusinessEntityAddress>();
    }
}
