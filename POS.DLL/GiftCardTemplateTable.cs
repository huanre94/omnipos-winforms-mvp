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
    
    public partial class GiftCardTemplateTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiftCardTemplateTable()
        {
            this.GiftCardTemplateLine = new HashSet<GiftCardTemplateLine>();
        }
    
        public long GiftCardTemplateId { get; set; }
        public long ProductId { get; set; }
        public string Observation { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardTemplateLine> GiftCardTemplateLine { get; set; }
        public virtual Product Product { get; set; }
    }
}
