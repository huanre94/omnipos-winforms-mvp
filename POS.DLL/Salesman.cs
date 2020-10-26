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
    
    public partial class Salesman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Salesman()
        {
            this.InvoiceTable = new HashSet<InvoiceTable>();
            this.OrderTable = new HashSet<OrderTable>();
        }
    
        public int SalesmanId { get; set; }
        public string Name { get; set; }
        public string SAPCode { get; set; }
        public bool IsExternal { get; set; }
        public int ParentId { get; set; }
        public string Type { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal Fulfillment { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceTable> InvoiceTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTable { get; set; }
    }
}
