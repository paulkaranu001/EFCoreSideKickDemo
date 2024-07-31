using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Cross-reference table mapping products to related product documents.
    /// <summary>
    public partial class ProductDocument
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Product { get; set; } = null!;

        public int ProductID { get; set; }

        public object DocumentNode { get; set; }

        /// <summary>
        /// Document identification number. Foreign key to Document.DocumentNode.
        /// <summary>
        public virtual Document ProductDocumentDocumentDocumentNode { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
