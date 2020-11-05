//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrder()
        {
            this.SalesOrderPayment = new HashSet<SalesOrderPayment>();
            this.SalesOrderText = new HashSet<SalesOrderText>();
            this.SalesOrderLine = new HashSet<SalesOrderLine>();
        }
    
        public long SalesOrderId { get; set; }
        public long SalesOrderIdLocal { get; set; }
        public short LocationId { get; set; }
        public int EmissionPointId { get; set; }
        public string Establishment { get; set; }
        public string Emission { get; set; }
        public long CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int SalesOriginId { get; set; }
        public long OrderECommerce { get; set; }
        public string Destination { get; set; }
        public string Recipient { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal BaseTaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal IrbpAmount { get; set; }
        public decimal Total { get; set; }
        public bool ShippingFree { get; set; }
        public decimal ShippingAmount { get; set; }
        public long InvoiceId { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual Salesman Salesman { get; set; }
        public virtual SalesOrigin SalesOrigin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderPayment> SalesOrderPayment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderText> SalesOrderText { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual EmissionPoint EmissionPoint { get; set; }
    }
}
