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
    
    public partial class PromotionPaymMode
    {
        public long PromotionId { get; set; }
        public int Sequence { get; set; }
        public int PaymModeId { get; set; }
        public int BankId { get; set; }
        public int CreditCardId { get; set; }
        public decimal Percent { get; set; }
        public string StatusPromPaym { get; set; }
        public string RewardMultiplierType { get; set; }
        public int RewardMultiplierValue { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual PaymMode PaymMode { get; set; }
        public virtual PromotionTable PromotionTable { get; set; }
    }
}
