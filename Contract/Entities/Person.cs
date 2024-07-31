using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreSideKickDemo
{
    /// <summary>
    /// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
    /// <summary>
    public partial class Person
    {
        /// <summary>
        /// Primary key for Person records.
        /// <summary>
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;

        [Key]
        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
        /// <summary>
        [StringLength(2)]
        public string PersonType { get; set; } = String.Empty;

        /// <summary>
        /// 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
        /// <summary>
        public bool NameStyle { get; set; }

        /// <summary>
        /// A courtesy title. For example, Mr. or Ms.
        /// <summary>
        [StringLength(8)]
        public string? Title { get; set; }

        /// <summary>
        /// First name of the person.
        /// <summary>
        [StringLength(50)]
        public string FirstName { get; set; } = String.Empty;

        /// <summary>
        /// Middle name or middle initial of the person.
        /// <summary>
        [StringLength(50)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Last name of the person.
        /// <summary>
        [StringLength(50)]
        public string LastName { get; set; } = String.Empty;

        /// <summary>
        /// Surname suffix. For example, Sr. or Jr.
        /// <summary>
        [StringLength(10)]
        public string? Suffix { get; set; }

        /// <summary>
        /// 0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. 
        /// <summary>
        public int EmailPromotion { get; set; }

        /// <summary>
        /// Additional contact information about the person stored in xml format. 
        /// <summary>
        public string? AdditionalContactInfo { get; set; }

        /// <summary>
        /// Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.
        /// <summary>
        public string? Demographics { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// <summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// <summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Primary key. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new HashSet<BusinessEntityContact>();

        /// <summary>
        /// Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID
        /// <summary>
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; } = new HashSet<EmailAddress>();

        public virtual Password Password { get; set; } = null!;

        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual ICollection<PersonPhone> PersonPhones { get; set; } = new HashSet<PersonPhone>();

        /// <summary>
        /// Foreign key to Person.BusinessEntityID
        /// <summary>
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// <summary>
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new HashSet<PersonCreditCard>();

        /// <summary>
        /// Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.
        /// <summary>
        public virtual Employee Employee { get; set; } = null!;
    }
}
