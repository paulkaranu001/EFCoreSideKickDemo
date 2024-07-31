using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Current customer information. Also see the Person and Store tables.
    /// <summary>
    public partial class Customer
    {
        /// <summary>
        /// Primary key.
        /// <summary>
        [Required]
        [Key]
        public int CustomerId { get; set; }

        public int? PersonID { get; set; }

        public int? StoreID { get; set; }

        public int? TerritoryID { get; set; }

        /// <summary>
        /// Foreign key to Person.BusinessEntityID
        /// <summary>
        public virtual Person? Person { get; set; }

        /// <summary>
        /// Foreign key to Store.BusinessEntityID
        /// <summary>
        public virtual Store? Store { get; set; }

        /// <summary>
        /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual SalesTerritory? Territory { get; set; }

        /// <summary>
        /// Unique number identifying the customer assigned by the accounting system.
        /// <summary>
        public string AccountNumber { get; set; } = String.Empty;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Customer identification number. Foreign key to Customer.BusinessEntityID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> Customers { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
