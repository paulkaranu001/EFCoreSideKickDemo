using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product maintenance documents.
    /// <summary>
    public partial class Document
    {
        /// <summary>
        /// Primary key for Document records.
        /// <summary>
        [Required]
        [Key]
        public object DocumentNode { get; set; }

        public int Owner { get; set; }

        /// <summary>
        /// Depth in the document hierarchy.
        /// <summary>
        public short? DocumentLevel { get; set; }

        /// <summary>
        /// Title of the document.
        /// <summary>
        [StringLength(50)]
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Employee who controls the document.  Foreign key to Employee.BusinessEntityID
        /// <summary>
        public virtual Employee DocumentEmployeeOwner { get; set; } = null!;

        /// <summary>
        /// 0 = This is a folder, 1 = This is a document.
        /// <summary>
        public bool FolderFlag { get; set; }

        /// <summary>
        /// File name of the document
        /// <summary>
        [StringLength(400)]
        public string FileName { get; set; } = String.Empty;

        /// <summary>
        /// File extension indicating the document type. For example, .doc or .txt.
        /// <summary>
        [StringLength(8)]
        public string FileExtension { get; set; } = String.Empty;

        /// <summary>
        /// Revision number of the document. 
        /// <summary>
        [StringLength(5)]
        public string Revision { get; set; } = String.Empty;

        /// <summary>
        /// Engineering change approval number.
        /// <summary>
        public int ChangeNumber { get; set; }

        /// <summary>
        /// 1 = Pending approval, 2 = Approved, 3 = Obsolete
        /// <summary>
        public byte Status { get; set; }

        /// <summary>
        /// Document abstract.
        /// <summary>
        public string? DocumentSummary { get; set; }

        /// <summary>
        /// Complete document.
        /// <summary>
        public byte[]? Document1 { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Required for FileStream.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Document identification number. Foreign key to Document.DocumentNode.
        /// <summary>
        public virtual ICollection<ProductDocument> ProductDocumentDocumentDocumentNodes { get; set; } = new HashSet<ProductDocument>();
    }
}
