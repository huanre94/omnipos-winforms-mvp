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
    
    public partial class SP_Product_Consult_Result
    {
        public long ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> InventUnitId { get; set; }
        public decimal Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<decimal> FinalPrice { get; set; }
        public Nullable<bool> UseTax { get; set; }
        public Nullable<decimal> TaxProductAmount { get; set; }
        public Nullable<decimal> DiscountProductAmount { get; set; }
        public Nullable<bool> UseIrbp { get; set; }
        public Nullable<decimal> IrbpProductAmount { get; set; }
        public decimal Stock { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<bool> WeightControl { get; set; }
        public Nullable<decimal> BaseAmount { get; set; }
        public Nullable<decimal> BaseTaxAmount { get; set; }
        public Nullable<decimal> LinePercent { get; set; }
        public Nullable<decimal> LineDiscount { get; set; }
        public Nullable<decimal> TaxPercent { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> IrbpAmount { get; set; }
        public Nullable<decimal> LineAmount { get; set; }
        public Nullable<long> PromotionId { get; set; }
        public Nullable<bool> UseReward { get; set; }
        public long RewardProductId { get; set; }
        public decimal RewardPercent { get; set; }
    }
}