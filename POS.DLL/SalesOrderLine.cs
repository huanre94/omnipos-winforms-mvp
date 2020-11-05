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
    
    public partial class SalesOrderLine
    {
        public long SalesOrderId { get; set; }
        public int Sequence { get; set; }
        public long ProductId { get; set; }
        public string Barcode { get; set; }
        public int InventUnitId { get; set; }
        public bool UseTax { get; set; }
        public decimal TaxProductAmount { get; set; }
        public decimal DiscountProductAmount { get; set; }
        public decimal Quantity { get; set; }
        public int QuantityCW { get; set; }
        public int Returned { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal BaseTaxAmount { get; set; }
        public decimal LinePercent { get; set; }
        public decimal LineDiscount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal IrbpAmount { get; set; }
        public decimal LineAmount { get; set; }
        public long PromotionId { get; set; }
    
        public virtual InventUnit InventUnit { get; set; }
        public virtual Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
