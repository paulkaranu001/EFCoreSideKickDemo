using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// State and province lookup table.
    /// <summary>
    public partial class StateProvince
    {
        /// <summary>
        /// Primary key for StateProvince records.
        /// <summary>
        [Required]
        [Key]
        public int StateProvinceId { get; set; }

        [StringLength(3)]
        public string CountryRegionCode { get; set; } = String.Empty;

        public int TerritoryID { get; set; }

        /// <summary>
        /// ISO standard state or province code.
        /// <summary>
        [StringLength(3)]
        public string StateProvinceCode { get; set; } = String.Empty;

        /// <summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
        /// <summary>
        public virtual CountryRegion StateProvinceCountryRegionCountryRegionCode { get; set; } = null!;

        /// <summary>
        /// 0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.
        /// <summary>
        public bool IsOnlyStateProvinceFlag { get; set; }

        /// <summary>
        /// State or province description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual SalesTerritory Territory { get; set; } = null!;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// <summary>
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        /// <summary>
        /// State, province, or country/region the sales tax applies to.
        /// <summary>
        public virtual ICollection<SalesTaxRate> SalesTaxRates { get; set; } = new HashSet<SalesTaxRate>();
    }
}
