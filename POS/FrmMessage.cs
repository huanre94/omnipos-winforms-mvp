using DevExpress.XtraEditors;
using POS.DLL.Enums;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        string MessageText { get; set; }
        string MessageTextDetail { get; set; }
        bool ShowMessageDetail { get; set; }
        MessageType Messagetype { get; set; }
        bool MessageResponse { get; set; }

        public bool GetMessageResponse() => MessageResponse;

        public FrmMessage()
        {
            InitializeComponent();
        }

        public FrmMessage(string messageText, MessageType messagetype, bool showMessageDetail, string messageTextDetail)
        {
            InitializeComponent();
            MessageText = messageText;
            MessageTextDetail = messageTextDetail;
            ShowMessageDetail = showMessageDetail;
            Messagetype = messagetype;
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            CreateMessage();
        }

        private void CreateMessage()
        {
            DevExpress.Utils.Svg.SvgImage image = new DevExpress.Utils.Svg.SvgImage();

            LnkViewDetail.Visible = ShowMessageDetail;

            switch (Messagetype)
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
            LblMessage.Text = MessageText;

            BtnAccept.Focus();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            MessageResponse = true;
        }

        private void LnkViewDetail_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(MessageTextDetail);
        }

        private void BtnAccept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    LnkViewDetail_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}