using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Class
{
    public class Invoice
    {
        public int MyProperty { get; set; }

        ICollection<InvoiceLine> lines { get; set; } = new List<InvoiceLine>();
        ICollection<InvoicePayment> payments { get; set; } = new List<InvoicePayment>();

        


    }

    public class InvoiceLine
    {

    }

    public class InvoicePayment
    {
        public long InvoiceId { get; set; }

    }
}
