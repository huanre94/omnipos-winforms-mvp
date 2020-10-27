using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Functions
    {
        public bool ShowMessage(string _messageText, string _messageType = "Info")
        {
            FrmMessage frmMessage = new FrmMessage
            {
                messagetype = _messageType,
                messageText = _messageText
            };
            frmMessage.ShowDialog();
            
            return frmMessage.messageResponse;
        }        
    }
}
