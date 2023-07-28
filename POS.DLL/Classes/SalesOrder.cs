namespace POS.DLL
{
    public partial class SalesOrder
    {

        public SalesOrder Clone()
        {
            return (SalesOrder)MemberwiseClone();
        }
    }
}
