using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping products and product photos.
    /// <summary>
    public partial class ProductProductPhoto
    {
        /// <summary>
        /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
        /// <summary>
        public virtual ProductPhoto ProductPhoto { get; set; } = null!;

        public int ProductPhotoID { get; set; }

        public int ProductID { get; set; }

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// 0 = Photo is not the principal image. 1 = Photo is the principal image.
        /// <summary>
        public bool Primary { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
