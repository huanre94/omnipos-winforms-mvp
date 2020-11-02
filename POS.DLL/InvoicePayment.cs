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
    
    public partial class InvoicePayment
    {
        public long InvoiceId { get; set; }
        public short LocationId { get; set; }
        public int Sequence { get; set; }
        public int PaymModeId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public int BankId { get; set; }
        public int CreditCardId { get; set; }
        public string AccountNumber { get; set; }
        public int CkeckNumber { get; set; }
        public string CkeckType { get; set; }
        public System.DateTime CkeckDate { get; set; }
        public string CheckOwner { get; set; }
        public string Authorization { get; set; }
        public bool IsProtest { get; set; }
        public System.DateTime ProtestDate { get; set; }
        public string GiftCardNumber { get; set; }
        public string WithholdCode { get; set; }
        public string WithholdNumber { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public string Workstation { get; set; }
    
        public virtual PaymMode PaymMode { get; set; }
        public virtual Location Location { get; set; }
        public virtual InvoiceTable InvoiceTable { get; set; }
    }
}
