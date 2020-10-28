using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.CompilerServices;
using POS.Classes;

namespace POS
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        public string messageText = "";
        public ClsEnums.MessageType messagetype;
        public bool messageResponse;

        public FrmMessage()
        {
            InitializeComponent();            
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            this.CreateMessage();
        }

        private void CreateMessage()
        {
            DevExpress.Utils.Svg.SvgImage image = new DevExpress.Utils.Svg.SvgImage();            

            switch (messagetype)
            {
                case ClsEnums.MessageType.INFO:
                    image = POS.Properties.Resources.info2;
                    break;
                case ClsEnums.MessageType.WARNING:
                    image = POS.Properties.Resources.warning;
                    break;
                case ClsEnums.MessageType.ERROR:
                    image = POS.Properties.Resources.cancel3;
                    break;
                case ClsEnums.MessageType.CONFIRM:                    
                    image = POS.Properties.Resources.warning;
                    BtnCancel.Visible = true;
                    break;
            }                      

            ImgSvgMessage.SvgImage = image;
            LblMessage.Text = messageText;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            messageResponse = true;
        }
    }
}