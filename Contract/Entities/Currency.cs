using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table containing standard ISO currencies.
    /// <summary>
    public partial class Currency
    {
        /// <summary>
        /// The ISO code for the Currency.
        /// <summary>
        [Required]
        [StringLength(3)]
        [Key]
        public string CurrencyCode { get; set; } = String.Empty;

        /// <summary>
        /// Currency name.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// ISO standard currency code. Foreign key to Currency.CurrencyCode.
        /// <summary>
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencyCurrencyCurrencyCodes { get; set; } = new HashSet<CountryRegionCurrency>();

        /// <summary>
        /// Exchange rate was converted from this currency code.
        /// <summary>
        public virtual ICollection<CurrencyRate> CurrencyRateCurrencyFromCurrencyCodes { get; set; } = new HashSet<CurrencyRate>();

        /// <summary>
        /// Exchange rate was converted to this currency code.
        /// <summary>
        public virtual ICollection<CurrencyRate> CurrencyRateCurrencyToCurrencyCodes { get; set; } = new HashSet<CurrencyRate>();
    }
}
