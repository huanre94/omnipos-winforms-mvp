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
    
    public partial class GiftCardTrans
    {
        public long GiftCardId { get; set; }
        public int Sequence { get; set; }
        public int TrnsSeq { get; set; }
        public short LocationIdWithdrawn { get; set; }
        public System.DateTime Withdrawal { get; set; }
        public string TrnsType { get; set; }
        public string TrnsStatus { get; set; }
        public long TrnsId { get; set; }
        public decimal TrnsAmount { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityWithdrawn { get; set; }
    
        public virtual GiftCardLine GiftCardLine { get; set; }
        public virtual Location Location { get; set; }
    }
}