using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.
    /// <summary>
    public partial class BillOfMaterials
    {
        /// <summary>
        /// Primary key for BillOfMaterials records.
        /// <summary>
        [Required]
        [Key]
        public int BillOfMaterialsId { get; set; }

        public int? ProductAssemblyID { get; set; }

        public int ComponentID { get; set; }

        [StringLength(3)]
        public string UnitMeasureCode { get; set; } = String.Empty;

        /// <summary>
        /// Parent product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product? ProductAssembly { get; set; }

        /// <summary>
        /// Component identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual Product Component { get; set; } = null!;

        /// <summary>
        /// Date the component started being used in the assembly item.
        /// <summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date the component stopped being used in the assembly item.
        /// <summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Standard code identifying the unit of measure for the quantity.
        /// <summary>
        public virtual UnitMeasure BillOfMaterialsUnitMeasureUnitMeasureCode { get; set; } = null!;

        /// <summary>
        /// Indicates the depth the component is from its parent (AssemblyID).
        /// <summary>
        public short Bomlevel { get; set; }

        /// <summary>
        /// Quantity of the component needed to create the assembly.
        /// <summary>
        public decimal PerAssemblyQty { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }
    }
}
