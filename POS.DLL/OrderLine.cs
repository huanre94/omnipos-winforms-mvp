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
    
    public partial class OrderLine
    {
        public long OrderId { get; set; }
        public int Sequence { get; set; }
        public long ProductId { get; set; }
        public string Barcode { get; set; }
        public int InventUnitId { get; set; }
        public decimal Quantity { get; set; }
        public int QuantityCW { get; set; }
        public int Returned { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public bool UseTax { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxSubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxDiscount { get; set; }
        public decimal IRBPAmount { get; set; }
        public decimal Total { get; set; }
    
        public virtual InventUnit InventUnit { get; set; }
        public virtual Product Product { get; set; }
        public virtual OrderTable OrderTable { get; set; }
    }
}
