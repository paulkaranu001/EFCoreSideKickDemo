using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Source of the ID that connects vendors, customers, and employees with address and contact information.
    /// <summary>
    public partial class BusinessEntity
    {
        /// <summary>
        /// Primary key for all customers, vendors, and employees.
        /// <summary>
        [Required]
        [Key]
        public int BusinessEntityId { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new HashSet<BusinessEntityAddress>();

        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new HashSet<BusinessEntityContact>();

        /// <summary>
        /// Primary key for Person records.
        /// <summary>
        public virtual Person Person { get; set; } = null!;

        /// <summary>
        /// Primary key. Foreign key to Customer.BusinessEntityID.
        /// <summary>
        public virtual Store Store { get; set; } = null!;

        /// <summary>
        /// Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID
        /// <summary>
        public virtual Vendor Vendor { get; set; } = null!;
    }
}
