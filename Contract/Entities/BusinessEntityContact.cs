using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping stores, vendors, and employees to people
    /// <summary>
    public partial class BusinessEntityContact
    {
        /// <summary>
        /// Primary key. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual Person Person { get; set; } = null!;

        public int PersonID { get; set; }

        public int ContactTypeID { get; set; }

        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Primary key.  Foreign key to ContactType.ContactTypeID.
        /// <summary>
        public virtual ContactType ContactType { get; set; } = null!;

        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

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
