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
    
    public partial class SP_GiftCard_Consult_Result
    {
        public Nullable<long> GiftCardId { get; set; }
        public string GiftCardNumber { get; set; }
        public string Status { get; set; }
        public string StatusLine { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> LowInventory { get; set; }
        public Nullable<bool> UseInvoice { get; set; }
        public Nullable<System.DateTime> Registration { get; set; }
        public Nullable<System.DateTime> Expiration { get; set; }
        public Nullable<long> CustomerIdInvoice { get; set; }
        public string CustomerNameInvoice { get; set; }
        public string Type { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
    }
}