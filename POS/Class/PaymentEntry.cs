namespace POS.Classes
{
    public class PaymentEntry
    {
        public PaymentEntry() { }

        public PaymentEntry(string _description, decimal _amount)
        {
            Description = _description;
            Amount = _amount;
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
