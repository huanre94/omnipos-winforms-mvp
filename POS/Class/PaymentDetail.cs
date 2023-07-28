namespace POS.Class
{
    public class PaymentDetail
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public PaymentDetail() { }

        public PaymentDetail(string description, decimal value)
        {
            Description = description;
            Amount = value;
        }

    }
}
