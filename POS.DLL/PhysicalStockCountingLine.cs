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
    
    public partial class PhysicalStockCountingLine
    {
        public int PhysicalStockCountingId { get; set; }
        public int Sequence { get; set; }
        public long ProductId { get; set; }
        public int InventUnitId { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal CountedQuantity { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual InventUnit InventUnit { get; set; }
        public virtual PhysicalStockCountingTable PhysicalStockCountingTable { get; set; }
        public virtual Product Product { get; set; }
    }
}
