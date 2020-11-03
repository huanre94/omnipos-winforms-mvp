//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.AccountsReceivable = new HashSet<AccountsReceivable>();
            this.GiftCardLine = new HashSet<GiftCardLine>();
            this.GiftCardTable = new HashSet<GiftCardTable>();
            this.InternalCreditCard = new HashSet<InternalCreditCard>();
            this.PromotionCustomer = new HashSet<PromotionCustomer>();
            this.InvoiceTable = new HashSet<InvoiceTable>();
            this.SalesOrder = new HashSet<SalesOrder>();
        }
    
        public long CustomerId { get; set; }
        public long CustomerIdLocal { get; set; }
        public string Lastname { get; set; }
        public string Firtsname { get; set; }
        public string SAPCode { get; set; }
        public short LocationId { get; set; }
        public int IdentTypeId { get; set; }
        public string Identification { get; set; }
        public string Gender { get; set; }
        public string PersonType { get; set; }
        public Nullable<bool> IsSpecialTaxpayer { get; set; }
        public bool IsEmployee { get; set; }
        public int EmployeeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int CustomerTypeId { get; set; }
        public Nullable<bool> UseWithhold { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountsReceivable> AccountsReceivable { get; set; }
        public virtual City City { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual IdentType IdentType { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardLine> GiftCardLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardTable> GiftCardTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InternalCreditCard> InternalCreditCard { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionCustomer> PromotionCustomer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceTable> InvoiceTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
