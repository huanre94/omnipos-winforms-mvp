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
