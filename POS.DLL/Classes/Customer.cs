namespace POS.DLL
{
    public partial class Customer
    {
        public string FullName
        {
            get => $"{Firtsname} {Lastname}";
        }
    }
}
