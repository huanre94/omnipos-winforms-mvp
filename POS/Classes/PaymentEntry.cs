namespace POS.Classes
{
    public class PaymentEntry
    {
        PaymentEntry() { }

        PaymentEntry(string _description, decimal _amount)
        {
            Description = _description; Amount = _amount;
        }

        string Description { get; set; }
        decimal Amount { get; set; }
    }
}
