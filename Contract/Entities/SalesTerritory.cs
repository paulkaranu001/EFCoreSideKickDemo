using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Sales territory lookup table.
    /// <summary>
    public partial class SalesTerritory
    {
        /// <summary>
        /// Primary key for SalesTerritory records.
        /// <summary>
        [Required]
        [Key]
        public int TerritoryId { get; set; }

        [StringLength(3)]
        public string CountryRegionCode { get; set; } = String.Empty;

        /// <summary>
        /// Sales territory description
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
        /// <summary>
        public virtual CountryRegion SalesTerritoryCountryRegionCountryRegionCode { get; set; } = null!;

        /// <summary>
        /// Geographic area to which the sales territory belong.
        /// <summary>
        [StringLength(50)]
        public string Group { get; set; } = String.Empty;

        /// <summary>
        /// Sales in the territory year to date.
        /// <summary>
        public decimal SalesYtd { get; set; }

        /// <summary>
        /// Sales in the territory the previous year.
        /// <summary>
        public decimal SalesLastYear { get; set; }

        /// <summary>
        /// Business costs in the territory year to date.
        /// <summary>
        public decimal CostYtd { get; set; }

        /// <summary>
        /// Business costs in the territory the previous year.
        /// <summary>
        public decimal CostLastYear { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual ICollection<StateProvince> StateProvinces { get; set; } = new HashSet<StateProvince>();

        /// <summary>
        /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        /// <summary>
        /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();

        /// <summary>
        /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual ICollection<SalesPerson> SalesPersons { get; set; } = new HashSet<SalesPerson>();

        /// <summary>
        /// Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new HashSet<SalesTerritoryHistory>();
    }
}
