using System.Collections.Generic;

namespace POS.DLL
{
    public partial class InvoiceTable
    {

        public static Dictionary<char, string> statusValues = new Dictionary<char, string>()
        {
            { 'A', "Activo" },
            { 'C', "Pagada" },
            { 'I', "Inactivo" }
        };
    }
}
