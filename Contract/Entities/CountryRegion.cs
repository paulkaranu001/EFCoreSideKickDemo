using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table containing the ISO standard codes for countries and regions.
    /// <summary>
    public partial class CountryRegion
    {
        /// <summary>
        /// ISO standard code for countries and regions.
        /// <summary>
        [Required]
        [StringLength(3)]
        [Key]
        public string CountryRegionCode { get; set; } = String.Empty;

        /// <summary>
        /// Country or region name.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
        /// <summary>
        public virtual ICollection<StateProvince> StateProvinces { get; set; } = new HashSet<StateProvince>();

        /// <summary>
        /// ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.
        /// <summary>
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; } = new HashSet<CountryRegionCurrency>();

        /// <summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
        /// <summary>
        public virtual ICollection<SalesTerritory> SalesTerritories { get; set; } = new HashSet<SalesTerritory>();
    }
}
