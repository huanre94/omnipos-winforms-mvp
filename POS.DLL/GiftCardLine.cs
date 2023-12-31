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
    
    public partial class GiftCardLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiftCardLine()
        {
            this.GiftCardLineProduct = new HashSet<GiftCardLineProduct>();
            this.GiftCardTrans = new HashSet<GiftCardTrans>();
        }
    
        public long GiftCardId { get; set; }
        public int Sequence { get; set; }
        public int Year { get; set; }
        public string GiftCardNumber { get; set; }
        public long CustomerId { get; set; }
        public string RedeemIdentification { get; set; }
        public string RedeemCustomer { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountConsumed { get; set; }
        public string StatusLine { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual GiftCardTable GiftCardTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardLineProduct> GiftCardLineProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardTrans> GiftCardTrans { get; set; }
    }
}
