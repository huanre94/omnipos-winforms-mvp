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
    
    public partial class OrderTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderTable()
        {
            this.OrderLine = new HashSet<OrderLine>();
            this.OrderPaymMode = new HashSet<OrderPaymMode>();
            this.OrderPromotion = new HashSet<OrderPromotion>();
            this.OrderText = new HashSet<OrderText>();
        }
    
        public long OrderId { get; set; }
        public long OrderIdLocal { get; set; }
        public System.DateTime Registration { get; set; }
        public string SalesChannel { get; set; }
        public bool IsECommerce { get; set; }
        public long OrderECommerce { get; set; }
        public string Destination { get; set; }
        public string Recipient { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxSubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxDiscount { get; set; }
        public decimal IRBPAmount { get; set; }
        public bool ShippingFree { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal Total { get; set; }
        public long InternalCreditCardId { get; set; }
        public long InvoiceId { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual EmissionPoint EmissionPoint { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPaymMode> OrderPaymMode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPromotion> OrderPromotion { get; set; }
        public virtual Salesman Salesman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderText> OrderText { get; set; }
    }
}
