using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Sales representative current information.
    /// <summary>
    public partial class SalesPerson
    {
        /// <summary>
        /// Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID
        /// <summary>
        public virtual Employee BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        public int? TerritoryID { get; set; }

        /// <summary>
        /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual SalesTerritory? Territory { get; set; }

        /// <summary>
        /// Projected yearly sales.
        /// <summary>
        public decimal? SalesQuota { get; set; }

        /// <summary>
        /// Bonus due if quota is met.
        /// <summary>
        public decimal Bonus { get; set; }

        /// <summary>
        /// Commision percent received per sale.
        /// <summary>
        public decimal CommissionPct { get; set; }

        /// <summary>
        /// Sales total year to date.
        /// <summary>
        public decimal SalesYtd { get; set; }

        /// <summary>
        /// Sales total of previous year.
        /// <summary>
        public decimal SalesLastYear { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();

        /// <summary>
        /// Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; } = new HashSet<SalesPersonQuotaHistory>();

        /// <summary>
        /// Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new HashSet<SalesTerritoryHistory>();

        /// <summary>
        /// ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual ICollection<Store> Stores { get; set; } = new HashSet<Store>();
    }
}
