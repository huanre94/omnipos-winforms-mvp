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
    
    public partial class SequenceTable
    {
        public short LocationId { get; set; }
        public int SequenceId { get; set; }
        public string SeqType { get; set; }
        public Nullable<int> EmissionPointId { get; set; }
        public int Sequence { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    
        public virtual Location Location { get; set; }
    }
}
