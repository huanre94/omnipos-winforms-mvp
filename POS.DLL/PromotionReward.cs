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
    
    public partial class PromotionReward
    {
        public long PromotionId { get; set; }
        public int Sequence { get; set; }
        public long ProductId { get; set; }
        public decimal StartRange { get; set; }
        public decimal FinalRange { get; set; }
        public decimal Percent { get; set; }
        public bool LowInventory { get; set; }
        public long ProductIdReward { get; set; }
        public int QuantityReceive { get; set; }
        public int MaxReceive { get; set; }
        public string Caption { get; set; }
        public int TotalReward { get; set; }
        public int StockReward { get; set; }
        public string StatusPromRew { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual PromotionTable PromotionTable { get; set; }
    }
}
