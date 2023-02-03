using DevExpress.XtraEditors;
using POS.DLL.Enums;
using System;

namespace POS
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        public string messageText = "";
        public string messageTextDetail = "";
        public bool showMessageDetail;
        public MessageType messagetype;
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
                case MessageType.INFO:
                    image = Properties.Resources.info2;
                    break;
                case MessageType.WARNING:
                    image = Properties.Resources.warning;
                    break;
                case MessageType.ERROR:
                    image = Properties.Resources.cancel3;
                    break;
                case MessageType.CONFIRM:
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