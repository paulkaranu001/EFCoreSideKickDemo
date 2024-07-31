using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Lookup table containing the languages in which some AdventureWorks data is stored.
    /// <summary>
    public partial class Culture
    {
        /// <summary>
        /// Primary key for Culture records.
        /// <summary>
        [Required]
        [StringLength(6)]
        [Key]
        public string CultureId { get; set; } = String.Empty;

        /// <summary>
        /// Culture description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        /// <summary>
        public virtual ICollection<ProductModelProductDescriptionCulture> Cultures { get; set; } = new HashSet<ProductModelProductDescriptionCulture>();
    }
}
