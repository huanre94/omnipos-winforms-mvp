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
    
    public partial class CountCashMoney
    {
        public long CountCashId { get; set; }
        public int Sequence { get; set; }
        public int SecLineMoney { get; set; }
        public string DenominationType { get; set; }
        public decimal Denomination { get; set; }
        public decimal Quantity { get; set; }
    
        public virtual CountCashLine CountCashLine { get; set; }
    }
}
