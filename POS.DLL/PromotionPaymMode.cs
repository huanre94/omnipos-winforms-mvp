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
    
    public partial class PromotionPaymMode
    {
        public long PromotionId { get; set; }
        public int Sequence { get; set; }
        public int PaymModeId { get; set; }
        public int BankId { get; set; }
        public int CreditCardId { get; set; }
        public decimal Percent { get; set; }
        public string StatusPromPaym { get; set; }
    
        public virtual PromotionTable PromotionTable { get; set; }
        public virtual PaymMode PaymMode { get; set; }
    }
}
