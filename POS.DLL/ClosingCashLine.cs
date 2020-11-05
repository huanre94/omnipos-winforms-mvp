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
    
    public partial class ClosingCashLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClosingCashLine()
        {
            this.ClosingCashMoney = new HashSet<ClosingCashMoney>();
        }
    
        public long ClosingCashId { get; set; }
        public int Sequence { get; set; }
        public int EmissionPointId { get; set; }
        public int PaymModeId { get; set; }
        public decimal CashierAmount { get; set; }
        public decimal SystemAmount { get; set; }
    
        public virtual ClosingCashTable ClosingCashTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClosingCashMoney> ClosingCashMoney { get; set; }
        public virtual EmissionPoint EmissionPoint { get; set; }
        public virtual PaymMode PaymMode { get; set; }
    }
}
