using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// One way hashed authentication information
    /// <summary>
    public partial class Password
    {
        public virtual Person BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Password for the e-mail account.
        /// <summary>
        [StringLength(128)]
        public string PasswordHash { get; set; } = String.Empty;

        /// <summary>
        /// Random value concatenated with the password string before the password is hashed.
        /// <summary>
        [StringLength(10)]
        public string PasswordSalt { get; set; } = String.Empty;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
