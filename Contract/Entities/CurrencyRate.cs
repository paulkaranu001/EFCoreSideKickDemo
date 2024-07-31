using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Currency exchange rates.
    /// <summary>
    public partial class CurrencyRate
    {
        /// <summary>
        /// Primary key for CurrencyRate records.
        /// <summary>
        [Required]
        [Key]
        public int CurrencyRateId { get; set; }

        [StringLength(3)]
        public string FromCurrencyCode { get; set; } = String.Empty;

        [StringLength(3)]
        public string ToCurrencyCode { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the exchange rate was obtained.
        /// <summary>
        public DateTime CurrencyRateDate { get; set; }

        /// <summary>
        /// Exchange rate was converted from this currency code.
        /// <summary>
        public virtual Currency CurrencyRateCurrencyFromCurrencyCode { get; set; } = null!;

        /// <summary>
        /// Exchange rate was converted to this currency code.
        /// <summary>
        public virtual Currency CurrencyRateCurrencyToCurrencyCode { get; set; } = null!;

        /// <summary>
        /// Average exchange rate for the day.
        /// <summary>
        public decimal AverageRate { get; set; }

        /// <summary>
        /// Final exchange rate for the day.
        /// <summary>
        public decimal EndOfDayRate { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> CurrencyRates { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
