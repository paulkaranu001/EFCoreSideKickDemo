using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Bicycle assembly diagrams.
    /// <summary>
    public partial class Illustration
    {
        /// <summary>
        /// Primary key for Illustration records.
        /// <summary>
        [Required]
        [Key]
        public int IllustrationId { get; set; }

        /// <summary>
        /// Illustrations used in manufacturing instructions. Stored as XML.
        /// <summary>
        public string? Diagram { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to Illustration.IllustrationID.
        /// <summary>
        public virtual ICollection<ProductModelIllustration> Illustrations { get; set; } = new HashSet<ProductModelIllustration>();
    }
}
