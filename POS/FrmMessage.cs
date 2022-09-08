using DevExpress.XtraEditors;
using POS.Classes;
using System;

namespace POS
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        public string messageText = "";
        public string messageTextDetail = "";
        public bool showMessageDetail;
        public ClsEnums.MessageType messagetype;
        public bool messageResponse;

        public FrmMessage()
        {
            InitializeComponent();
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            CreateMessage();
        }

        private void CreateMessage()
        {
            DevExpress.Utils.Svg.SvgImage image = new DevExpress.Utils.Svg.SvgImage();

            LnkViewDetail.Visible = showMessageDetail;

            switch (messagetype)
            {
                case ClsEnums.MessageType.INFO:
                    image = Properties.Resources.info2;
                    break;
                case ClsEnums.MessageType.WARNING:
                    image = Properties.Resources.warning;
                    break;
                case ClsEnums.MessageType.ERROR:
                    image = Properties.Resources.cancel3;
                    break;
                case ClsEnums.MessageType.CONFIRM:
                    image = Properties.Resources.warning;
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

        private void LnkViewDetail_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(messageTextDetail);
        }
    }
}