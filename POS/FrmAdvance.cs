using DevExpress.XtraEditors;
using POS.Classes;
using POS.DLL;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer _currentCustomer;
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        ClsFunctions functions = new ClsFunctions();

        public FrmAdvance()
        {
            InitializeComponent();
        }

        private void FrmAdvance_Load(object sender, EventArgs e)
        {
            LoadPreviousAdvances();
            CheckGridView();
        }

        private void LoadPreviousAdvances()
        {

        }

        #region Keypad
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }
        #endregion

        private void BtnEnter_Click(object sender, EventArgs e)
        {

        }

        private void CheckGridView()
        {
            GrvAdvance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcAdvance.DataSource = null;
            //BindingList<> bindingList = new BindingList<>(denominations);
            //bindingList.AllowNew = false;
            //GrcAdvance.DataSource = bindingList;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnNewAdvance_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrintLastAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                long lastId = new ClsAccountsReceivableTrans().;

                if (lastId == 0)
                {
                    functions.ShowMessage("No hay documento previo existente.", ClsEnums.MessageType.WARNING);
                }
                else
                {
                    functions.PrintDocument(lastId, ClsEnums.DocumentType.ADVANCE);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al imprimir la última factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }
    }
}