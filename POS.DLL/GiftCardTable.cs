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
    
    public partial class GiftCardTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiftCardTable()
        {
            this.GiftCardLine = new HashSet<GiftCardLine>();
        }
    
        public long GiftCardId { get; set; }
        public long GiftCardIdLocal { get; set; }
        public short LocationId { get; set; }
        public short LocationIdOrigin { get; set; }
        public int Year { get; set; }
        public long GiftCardBlockId { get; set; }
        public System.DateTime Registration { get; set; }
        public System.DateTime Expiration { get; set; }
        public string Type { get; set; }
        public string UseCode { get; set; }
        public long CustomerId { get; set; }
        public long InvoiceId { get; set; }
        public long GiftCardNumberStart { get; set; }
        public long GiftCardNumberFinal { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual GiftCardBlockTable GiftCardBlockTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardLine> GiftCardLine { get; set; }
        public virtual Location Location { get; set; }
        public virtual Location Location1 { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
