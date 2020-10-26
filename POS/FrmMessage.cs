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

namespace POS
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        public string messageText = "";
        public string messagetype;
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
            image = POS.Properties.Resources.info;
           
            if (messagetype == "Warning")
            {
                image = POS.Properties.Resources.warning;
            }
            else if (messagetype == "Error")
            {
                image = POS.Properties.Resources.cancel3;
            }
            else if (messagetype == "Confirm")
            {
                BtnCancel.Visible = true;
                image = POS.Properties.Resources.warning;
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