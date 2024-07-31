using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Products sold or used in the manfacturing of sold products.
    /// <summary>
    public partial class Product
    {
        /// <summary>
        /// Primary key for Product records.
        /// <summary>
        [Required]
        [Key]
        public int ProductId { get; set; }

        [StringLength(3)]
        public string? SizeUnitMeasureCode { get; set; }

        [StringLength(3)]
        public string? WeightUnitMeasureCode { get; set; }

        public int? ProductSubcategoryID { get; set; }

        public int? ProductModelID { get; set; }

        /// <summary>
        /// Name of the product.
        /// <summary>
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Unique product identification number.
        /// <summary>
        [StringLength(25)]
        public string ProductNumber { get; set; } = String.Empty;

        /// <summary>
        /// 0 = Product is purchased, 1 = Product is manufactured in-house.
        /// <summary>
        public bool MakeFlag { get; set; }

        /// <summary>
        /// 0 = Product is not a salable item. 1 = Product is salable.
        /// <summary>
        public bool FinishedGoodsFlag { get; set; }

        /// <summary>
        /// Product color.
        /// <summary>
        [StringLength(15)]
        public string? Color { get; set; }

        /// <summary>
        /// Minimum inventory quantity. 
        /// <summary>
        public short SafetyStockLevel { get; set; }

        /// <summary>
        /// Inventory level that triggers a purchase order or work order. 
        /// <summary>
        public short ReorderPoint { get; set; }

        /// <summary>
        /// Standard cost of the product.
        /// <summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Selling price.
        /// <summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Product size.
        /// <summary>
        [StringLength(5)]
        public string? Size { get; set; }

        /// <summary>
        /// Unit of measure for Size column.
        /// <summary>
        public virtual UnitMeasure? ProductUnitMeasureSizeUnitMeasureCode { get; set; }

        /// <summary>
        /// Unit of measure for Weight column.
        /// <summary>
        public virtual UnitMeasure? ProductUnitMeasureWeightUnitMeasureCode { get; set; }

        /// <summary>
        /// Product weight.
        /// <summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Number of days required to manufacture the product.
        /// <summary>
        public int DaysToManufacture { get; set; }

        /// <summary>
        /// R = Road, M = Mountain, T = Touring, S = Standard
        /// <summary>
        [StringLength(2)]
        public string? ProductLine { get; set; }

        /// <summary>
        /// H = High, M = Medium, L = Low
        /// <summary>
        [StringLength(2)]
        public string? Class { get; set; }

        /// <summary>
        /// W = Womens, M = Mens, U = Universal
        /// <summary>
        [StringLength(2)]
        public string? Style { get; set; }

        /// <summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        /// <summary>
        public virtual ProductSubcategory? ProductSubcategory { get; set; }

        /// <summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        /// <summary>
        public virtual ProductModel? ProductModel { get; set; }

        /// <summary>
        /// Date the product was available for sale.
        /// <summary>
        public DateTime SellStartDate { get; set; }

        /// <summary>
        /// Date the product was no longer available for sale.
        /// <summary>
        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// Date the product was discontinued.
        /// <summary>
        public DateTime? DiscontinuedDate { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Component identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<BillOfMaterials> Components { get; set; } = new HashSet<BillOfMaterials>();

        /// <summary>
        /// Parent product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<BillOfMaterials> ProductAssemblies { get; set; } = new HashSet<BillOfMaterials>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID
        /// <summary>
        public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; } = new HashSet<ProductCostHistory>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ProductDocument> ProductDocuments { get; set; } = new HashSet<ProductDocument>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new HashSet<ProductInventory>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID
        /// <summary>
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; } = new HashSet<ProductListPriceHistory>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ProductProductPhoto> ProductProductPhotoes { get; set; } = new HashSet<ProductProductPhoto>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new HashSet<ProductReview>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new HashSet<TransactionHistory>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new HashSet<WorkOrder>();

        /// <summary>
        /// Product ordered. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } = new HashSet<SpecialOfferProduct>();

        /// <summary>
        /// Primary key. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new HashSet<ProductVendor>();

        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// <summary>
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new HashSet<PurchaseOrderDetail>();
    }
}
