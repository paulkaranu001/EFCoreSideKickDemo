using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Product inventory and manufacturing locations.
    /// <summary>
    public partial class Location
    {
        /// <summary>
        /// Primary key for Location records.
        /// <summary>
        [Required]
        [Key]
        public short LocationId { get; set; }

        /// <summary>
        /// Location description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Standard hourly cost of the manufacturing location.
        /// <summary>
        public decimal CostRate { get; set; }

        /// <summary>
        /// Work capacity (in hours) of the manufacturing location.
        /// <summary>
        public decimal Availability { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Inventory location identification number. Foreign key to Location.LocationID. 
        /// <summary>
        public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new HashSet<ProductInventory>();

        /// <summary>
        /// Manufacturing location where the part is processed. Foreign key to Location.LocationID.
        /// <summary>
        public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } = new HashSet<WorkOrderRouting>();
    }
}
