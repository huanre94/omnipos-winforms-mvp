﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class POSEntities : DbContext
    {
        public POSEntities()
            : base("name=POSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountsReceivable> AccountsReceivable { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BankCreditCard> BankCreditCard { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<IdentType> IdentType { get; set; }
        public virtual DbSet<InventLocation> InventLocation { get; set; }
        public virtual DbSet<InventProductLocation> InventProductLocation { get; set; }
        public virtual DbSet<InventUnit> InventUnit { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBarcode> ProductBarcode { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<PromotionCustomer> PromotionCustomer { get; set; }
        public virtual DbSet<PromotionProducts> PromotionProducts { get; set; }
        public virtual DbSet<PromotionReward> PromotionReward { get; set; }
        public virtual DbSet<PromotionTable> PromotionTable { get; set; }
        public virtual DbSet<Salesman> Salesman { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<InternalCreditCardLine> InternalCreditCardLine { get; set; }
        public virtual DbSet<TaxTable> TaxTable { get; set; }
        public virtual DbSet<PromotionType> PromotionType { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<InternalCreditCard> InternalCreditCard { get; set; }
        public virtual DbSet<SalesOrderPayment> SalesOrderPayment { get; set; }
        public virtual DbSet<SalesOrderText> SalesOrderText { get; set; }
        public virtual DbSet<SalesOrigin> SalesOrigin { get; set; }
        public virtual DbSet<GlobalParameter> GlobalParameter { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<InventTransType> InventTransType { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<SalesRemissionLine> SalesRemissionLine { get; set; }
        public virtual DbSet<SalesRemissionTable> SalesRemissionTable { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
        public virtual DbSet<TransportDriver> TransportDriver { get; set; }
        public virtual DbSet<TransportReason> TransportReason { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<SalesOrderLine> SalesOrderLine { get; set; }
        public virtual DbSet<PaymMode> PaymMode { get; set; }
        public virtual DbSet<RetentionTable> RetentionTable { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<LogType> LogType { get; set; }
        public virtual DbSet<SalesLog> SalesLog { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<ClosingCashierLine> ClosingCashierLine { get; set; }
        public virtual DbSet<ClosingCashierMoney> ClosingCashierMoney { get; set; }
        public virtual DbSet<ClosingCashierTable> ClosingCashierTable { get; set; }
        public virtual DbSet<CurrencyDenomination> CurrencyDenomination { get; set; }
        public virtual DbSet<CurrencyType> CurrencyType { get; set; }
        public virtual DbSet<DenominationType> DenominationType { get; set; }
        public virtual DbSet<EmissionPoint> EmissionPoint { get; set; }
        public virtual DbSet<SequenceTable> SequenceTable { get; set; }
        public virtual DbSet<SequenceType> SequenceType { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayment { get; set; }
        public virtual DbSet<ProductModule> ProductModule { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<CancelReason> CancelReason { get; set; }
        public virtual DbSet<GiftCardBlockLine> GiftCardBlockLine { get; set; }
        public virtual DbSet<GiftCardBlockTable> GiftCardBlockTable { get; set; }
        public virtual DbSet<GiftCardLine> GiftCardLine { get; set; }
        public virtual DbSet<GiftCardLineProduct> GiftCardLineProduct { get; set; }
        public virtual DbSet<GiftCardTable> GiftCardTable { get; set; }
        public virtual DbSet<GiftCardTrans> GiftCardTrans { get; set; }
        public virtual DbSet<PromotionPaymMode> PromotionPaymMode { get; set; }
        public virtual DbSet<InvoiceTable> InvoiceTable { get; set; }
        public virtual DbSet<TransferStatus> TransferStatus { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<PhysicalStockCountingLine> PhysicalStockCountingLine { get; set; }
        public virtual DbSet<PhysicalStockCountingTable> PhysicalStockCountingTable { get; set; }
    
        public virtual ObjectResult<SP_InternalCreditCard_Consult_Result> SP_InternalCreditCard_Consult(Nullable<long> internalCreditCardId, string barcode, string type, string cActivacion, string status)
        {
            var internalCreditCardIdParameter = internalCreditCardId.HasValue ?
                new ObjectParameter("InternalCreditCardId", internalCreditCardId) :
                new ObjectParameter("InternalCreditCardId", typeof(long));
    
            var barcodeParameter = barcode != null ?
                new ObjectParameter("Barcode", barcode) :
                new ObjectParameter("Barcode", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            var cActivacionParameter = cActivacion != null ?
                new ObjectParameter("CActivacion", cActivacion) :
                new ObjectParameter("CActivacion", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_InternalCreditCard_Consult_Result>("SP_InternalCreditCard_Consult", internalCreditCardIdParameter, barcodeParameter, typeParameter, cActivacionParameter, statusParameter);
        }
    
        public virtual ObjectResult<SP_GaranCheck_Authorize_Result> SP_GaranCheck_Authorize(Nullable<int> bankId, string accountNumber, Nullable<int> ckeckNumber, Nullable<decimal> ckeckAmount, string identification, string name, string phone, string reference)
        {
            var bankIdParameter = bankId.HasValue ?
                new ObjectParameter("BankId", bankId) :
                new ObjectParameter("BankId", typeof(int));
    
            var accountNumberParameter = accountNumber != null ?
                new ObjectParameter("AccountNumber", accountNumber) :
                new ObjectParameter("AccountNumber", typeof(string));
    
            var ckeckNumberParameter = ckeckNumber.HasValue ?
                new ObjectParameter("CkeckNumber", ckeckNumber) :
                new ObjectParameter("CkeckNumber", typeof(int));
    
            var ckeckAmountParameter = ckeckAmount.HasValue ?
                new ObjectParameter("CkeckAmount", ckeckAmount) :
                new ObjectParameter("CkeckAmount", typeof(decimal));
    
            var identificationParameter = identification != null ?
                new ObjectParameter("Identification", identification) :
                new ObjectParameter("Identification", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var referenceParameter = reference != null ?
                new ObjectParameter("Reference", reference) :
                new ObjectParameter("Reference", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GaranCheck_Authorize_Result>("SP_GaranCheck_Authorize", bankIdParameter, accountNumberParameter, ckeckNumberParameter, ckeckAmountParameter, identificationParameter, nameParameter, phoneParameter, referenceParameter);
        }
    
        public virtual ObjectResult<SP_Customer_Insert_Result> SP_Customer_Insert(string paramXML)
        {
            var paramXMLParameter = paramXML != null ?
                new ObjectParameter("ParamXML", paramXML) :
                new ObjectParameter("ParamXML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Customer_Insert_Result>("SP_Customer_Insert", paramXMLParameter);
        }
    
        public virtual ObjectResult<SP_GiftCard_Consult_Result> SP_GiftCard_Consult(string giftCardNumber)
        {
            var giftCardNumberParameter = giftCardNumber != null ?
                new ObjectParameter("GiftCardNumber", giftCardNumber) :
                new ObjectParameter("GiftCardNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GiftCard_Consult_Result>("SP_GiftCard_Consult", giftCardNumberParameter);
        }
    
        [DbFunction("POSEntities", "FN_Identification_Validate")]
        public virtual IQueryable<FN_Identification_Validate_Result> FN_Identification_Validate(string identification, string isPassport)
        {
            var identificationParameter = identification != null ?
                new ObjectParameter("Identification", identification) :
                new ObjectParameter("Identification", typeof(string));
    
            var isPassportParameter = isPassport != null ?
                new ObjectParameter("IsPassport", isPassport) :
                new ObjectParameter("IsPassport", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FN_Identification_Validate_Result>("[POSEntities].[FN_Identification_Validate](@Identification, @IsPassport)", identificationParameter, isPassportParameter);
        }
    
        public virtual ObjectResult<SP_Login_Consult_Result> SP_Login_Consult(string userName, string password, string workstation, string addressIP)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var workstationParameter = workstation != null ?
                new ObjectParameter("Workstation", workstation) :
                new ObjectParameter("Workstation", typeof(string));
    
            var addressIPParameter = addressIP != null ?
                new ObjectParameter("AddressIP", addressIP) :
                new ObjectParameter("AddressIP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Login_Consult_Result>("SP_Login_Consult", userNameParameter, passwordParameter, workstationParameter, addressIPParameter);
        }
    
        public virtual ObjectResult<SP_Invoice_Insert_Result> SP_Invoice_Insert(string paramXML)
        {
            var paramXMLParameter = paramXML != null ?
                new ObjectParameter("ParamXML", paramXML) :
                new ObjectParameter("ParamXML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Invoice_Insert_Result>("SP_Invoice_Insert", paramXMLParameter);
        }
    
        public virtual ObjectResult<SP_ProductBarcode_Consult_Result> SP_ProductBarcode_Consult(string productName, Nullable<int> locationId)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ProductBarcode_Consult_Result>("SP_ProductBarcode_Consult", productNameParameter, locationIdParameter);
        }
    
        public virtual ObjectResult<SP_SalesLog_Consult_Result> SP_SalesLog_Consult(Nullable<short> locationId, Nullable<int> emissionPointId)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(short));
    
            var emissionPointIdParameter = emissionPointId.HasValue ?
                new ObjectParameter("EmissionPointId", emissionPointId) :
                new ObjectParameter("EmissionPointId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SalesLog_Consult_Result>("SP_SalesLog_Consult", locationIdParameter, emissionPointIdParameter);
        }
    
        public virtual ObjectResult<SP_Product_Consult_Result> SP_Product_Consult(Nullable<short> locationId, string barcode, Nullable<decimal> quantity, Nullable<long> customerId, Nullable<long> internalCreditCardId, string paymMode, string barcodeBefore)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(short));
    
            var barcodeParameter = barcode != null ?
                new ObjectParameter("Barcode", barcode) :
                new ObjectParameter("Barcode", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(decimal));
    
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(long));
    
            var internalCreditCardIdParameter = internalCreditCardId.HasValue ?
                new ObjectParameter("InternalCreditCardId", internalCreditCardId) :
                new ObjectParameter("InternalCreditCardId", typeof(long));
    
            var paymModeParameter = paymMode != null ?
                new ObjectParameter("PaymMode", paymMode) :
                new ObjectParameter("PaymMode", typeof(string));
    
            var barcodeBeforeParameter = barcodeBefore != null ?
                new ObjectParameter("BarcodeBefore", barcodeBefore) :
                new ObjectParameter("BarcodeBefore", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Product_Consult_Result>("SP_Product_Consult", locationIdParameter, barcodeParameter, quantityParameter, customerIdParameter, internalCreditCardIdParameter, paymModeParameter, barcodeBeforeParameter);
        }
    
        public virtual ObjectResult<SP_ClosingCashierDenominations_Consult_Result> SP_ClosingCashierDenominations_Consult()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashierDenominations_Consult_Result>("SP_ClosingCashierDenominations_Consult");
        }
    
        public virtual ObjectResult<SP_ClosingCashierPayment_Consult_Result> SP_ClosingCashierPayment_Consult(Nullable<short> locationId, Nullable<int> userId, Nullable<int> emissionPointId, string closingCashierDate)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(short));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var emissionPointIdParameter = emissionPointId.HasValue ?
                new ObjectParameter("EmissionPointId", emissionPointId) :
                new ObjectParameter("EmissionPointId", typeof(int));
    
            var closingCashierDateParameter = closingCashierDate != null ?
                new ObjectParameter("ClosingCashierDate", closingCashierDate) :
                new ObjectParameter("ClosingCashierDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashierPayment_Consult_Result>("SP_ClosingCashierPayment_Consult", locationIdParameter, userIdParameter, emissionPointIdParameter, closingCashierDateParameter);
        }
    
        public virtual ObjectResult<SP_ClosingCashierPartial_Insert_Result> SP_ClosingCashierPartial_Insert(string paramXML, string type)
        {
            var paramXMLParameter = paramXML != null ?
                new ObjectParameter("ParamXML", paramXML) :
                new ObjectParameter("ParamXML", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashierPartial_Insert_Result>("SP_ClosingCashierPartial_Insert", paramXMLParameter, typeParameter);
        }
    
        public virtual ObjectResult<SP_ClosingCashier_Insert_Result> SP_ClosingCashier_Insert(string paramXML)
        {
            var paramXMLParameter = paramXML != null ?
                new ObjectParameter("ParamXML", paramXML) :
                new ObjectParameter("ParamXML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashier_Insert_Result>("SP_ClosingCashier_Insert", paramXMLParameter);
        }
    
        public virtual ObjectResult<SP_ClosingCashierPartial_Consult_Result> SP_ClosingCashierPartial_Consult(Nullable<short> locationId, Nullable<int> userId, Nullable<int> emissionPointId, string closingCashierDate)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(short));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var emissionPointIdParameter = emissionPointId.HasValue ?
                new ObjectParameter("EmissionPointId", emissionPointId) :
                new ObjectParameter("EmissionPointId", typeof(int));
    
            var closingCashierDateParameter = closingCashierDate != null ?
                new ObjectParameter("ClosingCashierDate", closingCashierDate) :
                new ObjectParameter("ClosingCashierDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashierPartial_Consult_Result>("SP_ClosingCashierPartial_Consult", locationIdParameter, userIdParameter, emissionPointIdParameter, closingCashierDateParameter);
        }
    
        public virtual ObjectResult<SP_ClosingCashierTicket_Consult_Result> SP_ClosingCashierTicket_Consult(Nullable<long> closingCashierId)
        {
            var closingCashierIdParameter = closingCashierId.HasValue ?
                new ObjectParameter("ClosingCashierId", closingCashierId) :
                new ObjectParameter("ClosingCashierId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClosingCashierTicket_Consult_Result>("SP_ClosingCashierTicket_Consult", closingCashierIdParameter);
        }
    
        public virtual ObjectResult<SP_Supervisor_Validate_Result> SP_Supervisor_Validate(string barcode)
        {
            var barcodeParameter = barcode != null ?
                new ObjectParameter("barcode", barcode) :
                new ObjectParameter("barcode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Supervisor_Validate_Result>("SP_Supervisor_Validate", barcodeParameter);
        }
    
        public virtual ObjectResult<SP_InvoiceTicket_Consult_Result> SP_InvoiceTicket_Consult(Nullable<long> invoiceId, Nullable<bool> openCashier)
        {
            var invoiceIdParameter = invoiceId.HasValue ?
                new ObjectParameter("InvoiceId", invoiceId) :
                new ObjectParameter("InvoiceId", typeof(long));
    
            var openCashierParameter = openCashier.HasValue ?
                new ObjectParameter("OpenCashier", openCashier) :
                new ObjectParameter("OpenCashier", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_InvoiceTicket_Consult_Result>("SP_InvoiceTicket_Consult", invoiceIdParameter, openCashierParameter);
        }
    
        public virtual ObjectResult<SP_SalesOrigin_Consult_Result> SP_SalesOrigin_Consult()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SalesOrigin_Consult_Result>("SP_SalesOrigin_Consult");
        }
    
        public virtual ObjectResult<SP_InvoicePayment_Consult_Result> SP_InvoicePayment_Consult(Nullable<int> locationId, string emissionPoint, string invoiceNumber)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(int));
    
            var emissionPointParameter = emissionPoint != null ?
                new ObjectParameter("EmissionPoint", emissionPoint) :
                new ObjectParameter("EmissionPoint", typeof(string));
    
            var invoiceNumberParameter = invoiceNumber != null ?
                new ObjectParameter("InvoiceNumber", invoiceNumber) :
                new ObjectParameter("InvoiceNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_InvoicePayment_Consult_Result>("SP_InvoicePayment_Consult", locationIdParameter, emissionPointParameter, invoiceNumberParameter);
        }
    
        public virtual ObjectResult<SP_GiftCardRedeem_Insert_Result> SP_GiftCardRedeem_Insert(string giftCardNumber, string redeemName, string redeemIdentification, Nullable<int> redeemLocation, string productGrid)
        {
            var giftCardNumberParameter = giftCardNumber != null ?
                new ObjectParameter("GiftCardNumber", giftCardNumber) :
                new ObjectParameter("GiftCardNumber", typeof(string));
    
            var redeemNameParameter = redeemName != null ?
                new ObjectParameter("RedeemName", redeemName) :
                new ObjectParameter("RedeemName", typeof(string));
    
            var redeemIdentificationParameter = redeemIdentification != null ?
                new ObjectParameter("RedeemIdentification", redeemIdentification) :
                new ObjectParameter("RedeemIdentification", typeof(string));
    
            var redeemLocationParameter = redeemLocation.HasValue ?
                new ObjectParameter("RedeemLocation", redeemLocation) :
                new ObjectParameter("RedeemLocation", typeof(int));
    
            var productGridParameter = productGrid != null ?
                new ObjectParameter("ProductGrid", productGrid) :
                new ObjectParameter("ProductGrid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GiftCardRedeem_Insert_Result>("SP_GiftCardRedeem_Insert", giftCardNumberParameter, redeemNameParameter, redeemIdentificationParameter, redeemLocationParameter, productGridParameter);
        }
    
        public virtual ObjectResult<SP_InvoiceCancel_Consult_Result> SP_InvoiceCancel_Consult(Nullable<int> locationId, Nullable<int> emissionPointId, Nullable<int> invoiceNumber)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(int));
    
            var emissionPointIdParameter = emissionPointId.HasValue ?
                new ObjectParameter("EmissionPointId", emissionPointId) :
                new ObjectParameter("EmissionPointId", typeof(int));
    
            var invoiceNumberParameter = invoiceNumber.HasValue ?
                new ObjectParameter("InvoiceNumber", invoiceNumber) :
                new ObjectParameter("InvoiceNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_InvoiceCancel_Consult_Result>("SP_InvoiceCancel_Consult", locationIdParameter, emissionPointIdParameter, invoiceNumberParameter);
        }
    
        public virtual ObjectResult<SP_PhysicalStockCounting_Insert_Result> SP_PhysicalStockCounting_Insert(string physicalStockXml)
        {
            var physicalStockXmlParameter = physicalStockXml != null ?
                new ObjectParameter("PhysicalStockXml", physicalStockXml) :
                new ObjectParameter("PhysicalStockXml", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhysicalStockCounting_Insert_Result>("SP_PhysicalStockCounting_Insert", physicalStockXmlParameter);
        }
    
        public virtual ObjectResult<SP_PhysicalStockLine_Consult_Result> SP_PhysicalStockLine_Consult(Nullable<int> physicalStockCountingId)
        {
            var physicalStockCountingIdParameter = physicalStockCountingId.HasValue ?
                new ObjectParameter("PhysicalStockCountingId", physicalStockCountingId) :
                new ObjectParameter("PhysicalStockCountingId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhysicalStockLine_Consult_Result>("SP_PhysicalStockLine_Consult", physicalStockCountingIdParameter);
        }
    
        public virtual ObjectResult<SP_PhysicalStockLine_Insert_Result> SP_PhysicalStockLine_Insert(Nullable<int> physicalStockCountingId, string physicalStockXml)
        {
            var physicalStockCountingIdParameter = physicalStockCountingId.HasValue ?
                new ObjectParameter("PhysicalStockCountingId", physicalStockCountingId) :
                new ObjectParameter("PhysicalStockCountingId", typeof(int));
    
            var physicalStockXmlParameter = physicalStockXml != null ?
                new ObjectParameter("PhysicalStockXml", physicalStockXml) :
                new ObjectParameter("PhysicalStockXml", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhysicalStockLine_Insert_Result>("SP_PhysicalStockLine_Insert", physicalStockCountingIdParameter, physicalStockXmlParameter);
        }
    
        public virtual ObjectResult<SP_PhysicalStockProduct_Consult_Result> SP_PhysicalStockProduct_Consult(Nullable<int> locationId, Nullable<int> emissionPointId, string productBarcode, string productInternalId)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(int));
    
            var emissionPointIdParameter = emissionPointId.HasValue ?
                new ObjectParameter("EmissionPointId", emissionPointId) :
                new ObjectParameter("EmissionPointId", typeof(int));
    
            var productBarcodeParameter = productBarcode != null ?
                new ObjectParameter("ProductBarcode", productBarcode) :
                new ObjectParameter("ProductBarcode", typeof(string));
    
            var productInternalIdParameter = productInternalId != null ?
                new ObjectParameter("ProductInternalId", productInternalId) :
                new ObjectParameter("ProductInternalId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhysicalStockProduct_Consult_Result>("SP_PhysicalStockProduct_Consult", locationIdParameter, emissionPointIdParameter, productBarcodeParameter, productInternalIdParameter);
        }
    
        public virtual ObjectResult<SP_PhysicalStockTable_Insert_Result> SP_PhysicalStockTable_Insert(string physicalStockXml)
        {
            var physicalStockXmlParameter = physicalStockXml != null ?
                new ObjectParameter("PhysicalStockXml", physicalStockXml) :
                new ObjectParameter("PhysicalStockXml", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhysicalStockTable_Insert_Result>("SP_PhysicalStockTable_Insert", physicalStockXmlParameter);
        }
    }
}
