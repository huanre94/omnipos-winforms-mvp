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
    
    public partial class CountCashLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CountCashLine()
        {
            this.CountCashMoney = new HashSet<CountCashMoney>();
        }
    
        public long CountCashId { get; set; }
        public int Sequence { get; set; }
        public int EmissionPointId { get; set; }
        public int PaymModeId { get; set; }
        public decimal CashierAmount { get; set; }
        public decimal SystemAmount { get; set; }
    
        public virtual CountCashTable CountCashTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountCashMoney> CountCashMoney { get; set; }
        public virtual EmissionPoint EmissionPoint { get; set; }
        public virtual PaymMode PaymMode { get; set; }
    }
}
