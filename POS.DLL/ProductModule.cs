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
    
    public partial class ProductModule
    {
        public long ProductId { get; set; }
        public int LocationId { get; set; }
        public decimal Cost { get; set; }
        public decimal PriceReference { get; set; }
        public decimal Price { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal IRBPAmount { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
