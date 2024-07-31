using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Street address information for customers, employees, and vendors.
    /// <summary>
    public partial class Address
    {
        /// <summary>
        /// Primary key for Address records.
        /// <summary>
        [Required]
        [Key]
        public int AddressId { get; set; }

        public int StateProvinceID { get; set; }

        /// <summary>
        /// First street address line.
        /// <summary>
        [StringLength(60)]
        public string AddressLine1 { get; set; } = String.Empty;

        /// <summary>
        /// Second street address line.
        /// <summary>
        [StringLength(60)]
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Name of the city.
        /// <summary>
        [StringLength(30)]
        public string City { get; set; } = String.Empty;

        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// <summary>
        public virtual StateProvince StateProvince { get; set; } = null!;

        /// <summary>
        /// Postal code for the street address.
        /// <summary>
        [StringLength(15)]
        public string PostalCode { get; set; } = String.Empty;

        /// <summary>
        /// Latitude and longitude of this address.
        /// <summary>
        public object? SpatialLocation { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to Address.AddressID.
        /// <summary>
        public virtual ICollection<BusinessEntityAddress> Addresses { get; set; } = new HashSet<BusinessEntityAddress>();

        /// <summary>
        /// Customer billing address. Foreign key to Address.AddressID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> BillToAddresses { get; set; } = new HashSet<SalesOrderHeader>();

        /// <summary>
        /// Customer shipping address. Foreign key to Address.AddressID.
        /// <summary>
        public virtual ICollection<SalesOrderHeader> ShipToAddresses { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
