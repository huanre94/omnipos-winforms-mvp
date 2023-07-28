namespace POS.DLL
{
    public class ProductConsultDto
    {
        public short LocationId { get; set; }
        public string Barcode { get; set; }
        public decimal Quantity { get; set; }
        public long CustomerId { get; set; }
        public long InternalCreditCardId { get; set; }
        public string Paymmode { get; set; }
        public string BarcodeBefore { get; set; }

        public ProductConsultDto() { }

        public ProductConsultDto(short locationId, string barcode, decimal quantity, long customerId, long internalCreditCardId, string paymmode, string barcodeBefore = "")
        {
            LocationId = locationId;
            Barcode = barcode;
            Quantity = quantity;
            CustomerId = customerId;
            InternalCreditCardId = internalCreditCardId;
            Paymmode = paymmode;
            BarcodeBefore = barcodeBefore;
        }
    }
}
