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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.InventProductLocation = new HashSet<InventProductLocation>();
            this.ProductBarcode = new HashSet<ProductBarcode>();
            this.InvoiceLine = new HashSet<InvoiceLine>();
            this.SalesOrderLine = new HashSet<SalesOrderLine>();
            this.ProductModule = new HashSet<ProductModule>();
            this.GiftCardLineProduct = new HashSet<GiftCardLineProduct>();
            this.PhysicalStockCountingLine = new HashSet<PhysicalStockCountingLine>();
        }
    
        public long ProductId { get; set; }
        public string SAPCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InventUnitId { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Type { get; set; }
        public bool IsDeductible { get; set; }
        public bool UseTax { get; set; }
        public bool UseIrbp { get; set; }
        public bool IsECommerce { get; set; }
        public bool UseCatchWeight { get; set; }
        public decimal CatchWeightMax { get; set; }
        public decimal CatchWeightMin { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string ProductOldCode { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventProductLocation> InventProductLocation { get; set; }
        public virtual InventUnit InventUnit { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBarcode> ProductBarcode { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductModule> ProductModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftCardLineProduct> GiftCardLineProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhysicalStockCountingLine> PhysicalStockCountingLine { get; set; }
    }
}
