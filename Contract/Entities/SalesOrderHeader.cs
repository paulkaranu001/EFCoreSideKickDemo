using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// General sales order information.
    /// <summary>
    public partial class SalesOrderHeader
    {
        /// <summary>
        /// Primary key.
        /// <summary>
        [Required]
        [Key]
        public int SalesOrderId { get; set; }

        public int CustomerID { get; set; }

        public int? SalesPersonID { get; set; }

        public int? TerritoryID { get; set; }

        public int BillToAddressID { get; set; }

        public int ShipToAddressID { get; set; }

        public int ShipMethodID { get; set; }

        public int? CreditCardID { get; set; }

        public int? CurrencyRateID { get; set; }

        /// <summary>
        /// Incremental number to track changes to the sales order over time.
        /// <summary>
        public byte RevisionNumber { get; set; }

        /// <summary>
        /// Dates the sales order was created.
        /// <summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Date the order is due to the customer.
        /// <summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Date the order was shipped to the customer.
        /// <summary>
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
        /// <summary>
        public byte Status { get; set; }

        /// <summary>
        /// 0 = Order placed by sales person. 1 = Order placed online by customer.
        /// <summary>
        public bool OnlineOrderFlag { get; set; }

        /// <summary>
        /// Unique sales order identification number.
        /// <summary>
        public string SalesOrderNumber { get; set; } = String.Empty;

        /// <summary>
        /// Customer purchase order number reference. 
        /// <summary>
        [StringLength(25)]
        public string? PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Financial accounting number reference.
        /// <summary>
        [StringLength(15)]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Customer identification number. Foreign key to Customer.BusinessEntityID.
        /// <summary>
        public virtual Customer Customer { get; set; } = null!;

        /// <summary>
        /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
        /// <summary>
        public virtual SalesPerson? SalesPerson { get; set; }

        /// <summary>
        /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
        /// <summary>
        public virtual SalesTerritory? Territory { get; set; }

        /// <summary>
        /// Customer billing address. Foreign key to Address.AddressID.
        /// <summary>
        public virtual Address BillToAddress { get; set; } = null!;

        /// <summary>
        /// Customer shipping address. Foreign key to Address.AddressID.
        /// <summary>
        public virtual Address ShipToAddress { get; set; } = null!;

        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// <summary>
        public virtual ShipMethod ShipMethod { get; set; } = null!;

        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// <summary>
        public virtual CreditCard? CreditCard { get; set; }

        /// <summary>
        /// Approval code provided by the credit card company.
        /// <summary>
        [StringLength(15)]
        public string? CreditCardApprovalCode { get; set; }

        /// <summary>
        /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
        /// <summary>
        public virtual CurrencyRate? CurrencyRate { get; set; }

        /// <summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        /// <summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Tax amount.
        /// <summary>
        public decimal TaxAmt { get; set; }

        /// <summary>
        /// Shipping cost.
        /// <summary>
        public decimal Freight { get; set; }

        /// <summary>
        /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
        /// <summary>
        public decimal TotalDue { get; set; }

        /// <summary>
        /// Sales representative comments.
        /// <summary>
        [StringLength(128)]
        public string? Comment { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// <summary>
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new HashSet<SalesOrderDetail>();

        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// <summary>
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = new HashSet<SalesOrderHeaderSalesReason>();
    }
}
