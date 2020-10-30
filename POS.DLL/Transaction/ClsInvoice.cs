using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInvoice
    {
        public bool ClosingInvoice(XElement _invoiceXml)
        {
            bool response = false;

            //Call to closing invoice process
            if (_invoiceXml.HasElements)
            {
                response = true;
            }

            return response;
        }
    }
}
