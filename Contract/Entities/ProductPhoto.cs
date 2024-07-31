using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product images.
    /// <summary>
    public partial class ProductPhoto
    {
        /// <summary>
        /// Primary key for ProductPhoto records.
        /// <summary>
        [Required]
        [Key]
        public int ProductPhotoId { get; set; }

        /// <summary>
        /// Small image of the product.
        /// <summary>
        public byte[]? ThumbNailPhoto { get; set; }

        /// <summary>
        /// Small image file name.
        /// <summary>
        [StringLength(50)]
        public string? ThumbnailPhotoFileName { get; set; }

        /// <summary>
        /// Large image of the product.
        /// <summary>
        public byte[]? LargePhoto { get; set; }

        /// <summary>
        /// Large image file name.
        /// <summary>
        [StringLength(50)]
        public string? LargePhotoFileName { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
        /// <summary>
        public virtual ICollection<ProductProductPhoto> ProductPhotoes { get; set; } = new HashSet<ProductProductPhoto>();
    }
}
