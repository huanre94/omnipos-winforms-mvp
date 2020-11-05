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
    
    public partial class EmissionPoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmissionPoint()
        {
            this.ClosingCashLine = new HashSet<ClosingCashLine>();
            this.CountCashLine = new HashSet<CountCashLine>();
            this.InvoiceTable = new HashSet<InvoiceTable>();
            this.SalesOrder = new HashSet<SalesOrder>();
            this.SalesRemissionTable = new HashSet<SalesRemissionTable>();
        }
    
        public int EmissionPointId { get; set; }
        public short LocationId { get; set; }
        public int InventLocationId { get; set; }
        public string Establishment { get; set; }
        public string Emission { get; set; }
        public string Name { get; set; }
        public long InvoiceNumber { get; set; }
        public string AddressIP { get; set; }
        public string ScaleName { get; set; }
        public string ScanBarcodeName { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClosingCashLine> ClosingCashLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountCashLine> CountCashLine { get; set; }
        public virtual InventLocation InventLocation { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceTable> InvoiceTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesRemissionTable> SalesRemissionTable { get; set; }
    }
}
