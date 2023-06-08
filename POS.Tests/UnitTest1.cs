using NUnit.Framework;
using POS.DLL;
namespace POS.Tests
{
    public class Tests
    {
        Customer currentCustomer = new Customer();

        [SetUp]
        public void Setup()
        {
            currentCustomer.Firtsname = "";
        }

        [Test]
        public void Test1()
        {

        }
    }
}