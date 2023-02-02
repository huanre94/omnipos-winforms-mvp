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
    
    public partial class SalesRemissionTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesRemissionTable()
        {
            this.SalesRemissionLine = new HashSet<SalesRemissionLine>();
        }
    
        public long SalesRemissionId { get; set; }
        public long SalesRemissionIdLocal { get; set; }
        public short LocationId { get; set; }
        public short TypeDoc { get; set; }
        public int EmissionPointId { get; set; }
        public string Establishment { get; set; }
        public Nullable<long> RemissionNumber { get; set; }
        public string Emission { get; set; }
        public int TransportDriverId { get; set; }
        public int TransportId { get; set; }
        public int TransportReasonId { get; set; }
        public System.DateTime SalesRemissionDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public string Observation { get; set; }
        public string KeyAccessSri { get; set; }
        public int TransferStatusId { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual EmissionPoint EmissionPoint { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesRemissionLine> SalesRemissionLine { get; set; }
        public virtual Transport Transport { get; set; }
        public virtual TransportDriver TransportDriver { get; set; }
        public virtual TransportReason TransportReason { get; set; }
    }
}
