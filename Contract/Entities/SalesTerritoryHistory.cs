using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Sales representative transfers to other sales territories.
    /// <summary>
    public partial class SalesTerritoryHistory
    {
        /// <summary>
        /// Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual SalesTerritory Territory { get; set; } = null!;

        public int TerritoryID { get; set; }

        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual SalesPerson BusinessEntity { get; set; } = null!;

        /// <summary>
        /// Primary key. Date the sales representive started work in the territory.
        /// <summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date the sales representative left work in the territory.
        /// <summary>
        public DateTime? EndDate { get; set; }

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
