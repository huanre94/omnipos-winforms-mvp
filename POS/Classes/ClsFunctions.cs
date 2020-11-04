﻿using POS.Classes;
using POS.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class ClsFunctions
    {    
        public bool ShowMessage(string _messageText
                                , ClsEnums.MessageType _messageType = ClsEnums.MessageType.INFO
                                , bool _showMessageDetail = false
                                , string _messageTextDetail = "")
        {
            FrmMessage frmMessage = new FrmMessage
            {
                messagetype = _messageType,
                messageText = _messageText,
                showMessageDetail = _showMessageDetail,
                messageTextDetail = _messageTextDetail
            };
            frmMessage.ShowDialog();
            
            return frmMessage.messageResponse;
        }      
        
        public bool RequestSupervisorAuth()
        {
            FrmSupervisorAuth auth = new FrmSupervisorAuth();
            auth.ShowDialog();

            return auth.formActionResult;
        }        
    }
}
