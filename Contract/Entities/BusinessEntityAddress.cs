using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping customers, vendors, and employees to their addresses.
    /// <summary>
    public partial class BusinessEntityAddress
    {
        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

        public int BusinessEntityID { get; set; }

        public int AddressTypeID { get; set; }

        public int AddressID { get; set; }

        /// <summary>
        /// Primary key. Foreign key to AddressType.AddressTypeID.
        /// <summary>
        public virtual AddressType AddressType { get; set; } = null!;

        /// <summary>
        /// Primary key. Foreign key to Address.AddressID.
        /// <summary>
        public virtual Address Address { get; set; } = null!;

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
