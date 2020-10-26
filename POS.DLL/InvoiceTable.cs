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
    
    public partial class InvoiceTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceTable()
        {
            this.InvoiceLine = new HashSet<InvoiceLine>();
            this.InvoicePaymMode = new HashSet<InvoicePaymMode>();
            this.InvoicePromotion = new HashSet<InvoicePromotion>();
        }
    
        public long InvoiceId { get; set; }
        public long InvoiceIdLocal { get; set; }
        public short LocationId { get; set; }
        public short TypeDoc { get; set; }
        public long InvoiceIdOrigin { get; set; }
        public int EmissionPointId { get; set; }
        public long DocNumber { get; set; }
        public string AuthorizationSRI { get; set; }
        public string StatusSRI { get; set; }
        public long CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public bool IsCredit { get; set; }
        public System.DateTime Registration { get; set; }
        public System.DateTime Expiration { get; set; }
        public bool IsECommerce { get; set; }
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
        public decimal Received { get; set; }
        public decimal Change { get; set; }
        public decimal Returned { get; set; }
        public long ConsumerCardId { get; set; }
        public long OrderId { get; set; }
        public int ClosingCashId { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual EmissionPoint EmissionPoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicePaymMode> InvoicePaymMode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicePromotion> InvoicePromotion { get; set; }
        public virtual Location Location { get; set; }
        public virtual Salesman Salesman { get; set; }
    }
}
