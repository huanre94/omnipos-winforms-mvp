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
    
    public partial class GiftCardTrans
    {
        public long GiftCardId { get; set; }
        public int Sequence { get; set; }
        public int TrnsSeq { get; set; }
        public short LocationIdRedeem { get; set; }
        public System.DateTime RedeemDate { get; set; }
        public string TrnsType { get; set; }
        public string TrnsStatus { get; set; }
        public long TrnsId { get; set; }
        public decimal TrnsAmount { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RedeemQuantity { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual GiftCardLine GiftCardLine { get; set; }
        public virtual Location Location { get; set; }
    }
}
