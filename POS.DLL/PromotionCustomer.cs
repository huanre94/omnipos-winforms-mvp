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
    
    public partial class PromotionCustomer
    {
        public long PromotionId { get; set; }
        public int Sequence { get; set; }
        public long CustomerId { get; set; }
        public decimal Percent { get; set; }
        public string StatusPromCust { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual PromotionTable PromotionTable { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
