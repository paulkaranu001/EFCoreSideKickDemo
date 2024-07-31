using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Unit of measure lookup table.
    /// <summary>
    public partial class UnitMeasure
    {
        /// <summary>
        /// Primary key.
        /// <summary>
        [Required]
        [StringLength(3)]
        [Key]
        public string UnitMeasureCode { get; set; } = String.Empty;

        /// <summary>
        /// Unit of measure description.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Standard code identifying the unit of measure for the quantity.
        /// <summary>
        public virtual ICollection<BillOfMaterials> BillOfMaterialss { get; set; } = new HashSet<BillOfMaterials>();

        /// <summary>
        /// Unit of measure for Size column.
        /// <summary>
        public virtual ICollection<Product> ProductUnitMeasureSizeUnitMeasureCodes { get; set; } = new HashSet<Product>();

        /// <summary>
        /// Unit of measure for Weight column.
        /// <summary>
        public virtual ICollection<Product> ProductUnitMeasureWeightUnitMeasureCodes { get; set; } = new HashSet<Product>();

        /// <summary>
        /// The product's unit of measure.
        /// <summary>
        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new HashSet<ProductVendor>();
    }
}
