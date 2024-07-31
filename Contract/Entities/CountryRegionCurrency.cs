using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping ISO currency codes to a country or region.
    /// <summary>
    public partial class CountryRegionCurrency
    {
        /// <summary>
        /// ISO standard currency code. Foreign key to Currency.CurrencyCode.
        /// <summary>
        public virtual Currency CountryRegionCurrencyCurrencyCurrencyCode { get; set; } = null!;

        [StringLength(3)]
        public string CurrencyCode { get; set; } = String.Empty;

        [StringLength(3)]
        public string CountryRegionCode { get; set; } = String.Empty;

        /// <summary>
        /// ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.
        /// <summary>
        public virtual CountryRegion CountryRegionCurrencyCountryRegionCountryRegionCode { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
