using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Customer reviews of products they have purchased.
    /// <summary>
    public partial class ProductReview
    {
        /// <summary>
        /// Primary key for ProductReview records.
        /// <summary>
        [Required]
        [Key]
        public int ProductReviewId { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Name of the reviewer.
        /// <summary>
        [StringLength(50)]
        public string ReviewerName { get; set; } = String.Empty;

        /// <summary>
        /// Date review was submitted.
        /// <summary>
        public DateTime ReviewDate { get; set; }

        /// <summary>
        /// Reviewer's e-mail address.
        /// <summary>
        [StringLength(50)]
        public string EmailAddress { get; set; } = String.Empty;

        /// <summary>
        /// Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.
        /// <summary>
        public int Rating { get; set; }

        /// <summary>
        /// Reviewer's comments
        /// <summary>
        [StringLength(3850)]
        public string? Comments { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
