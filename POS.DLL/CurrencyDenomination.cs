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
    
    public partial class CurrencyDenomination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrencyDenomination()
        {
            this.ClosingCashierMoney = new HashSet<ClosingCashierMoney>();
        }
    
        public int CurrencyDenominationId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int DenominationTypeId { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClosingCashierMoney> ClosingCashierMoney { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
        public virtual DenominationType DenominationType { get; set; }
    }
}
