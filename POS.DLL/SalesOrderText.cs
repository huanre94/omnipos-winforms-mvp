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
    
    public partial class SalesOrderText
    {
        public long SalesOrderId { get; set; }
        public int Sequence { get; set; }
        public string SalesOrderText1 { get; set; }
    
        public virtual SalesOrder SalesOrder { get; set; }
    }
}