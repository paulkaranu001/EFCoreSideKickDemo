using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Customers (resellers) of Adventure Works products.
    /// <summary>
    public partial class Store
    {
        /// <summary>
        /// Primary key. Foreign key to Customer.BusinessEntityID.
        /// <summary>
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        public int? SalesPersonID { get; set; }

        /// <summary>
        /// Name of the store.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual SalesPerson? SalesPerson { get; set; }

        /// <summary>
        /// Demographic informationg about the store such as the number of employees, annual sales and store type.
        /// <summary>
        public string? Demographics { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Foreign key to Store.BusinessEntityID
        /// <summary>
        public virtual ICollection<Customer> Stores { get; set; } = new HashSet<Customer>();
    }
}
