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
using DevExpress.XtraEditors.Repository;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.Xml.Linq;
using DevExpress.XtraGrid.Views.Grid;
using POS.DLL;
using POS.Classes;

namespace POS
{
    public partial class FrmPayment : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        DataTable dataTable = new DataTable();
        public decimal invoiceAmount;
        decimal paidAmount = 0;
        decimal pendingAmount = 0;
        decimal changeAmount = 0;

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            invoiceAmount = 42.69M;
            LblTotal.Text = invoiceAmount.ToString();
            TxtAmount.Text = invoiceAmount.ToString();
            pendingAmount = invoiceAmount;           
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (GrvPayment.RowCount > 1)
            {
                bool response;                
                
                response = functions.ShowMessage("Existen pagos registrados, desea continuar?", ClsEnums.MessageType.WARNING);

                if (response)
                {
                    GrcPayment.DataSource = null;
                    GrvPayment.Columns.Clear();
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }                
            }
        }

        #region Keypad
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "9";
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!TxtAmount.Text.Contains("."))
            {
                TxtAmount.Text += ".";
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtAmount.Text = "";
        }

        #endregion

        private void BtnCash_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                Cash();
            }
            else
            {                
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnCreditCard_Click(object sender, EventArgs e)
        {            
            if (TxtAmount.Text != "")
            {
                CreditCard();
            }
            else
            {                
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                Check();
            }
            else
            {                
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnInternalCredit_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                InternalCredit();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnGiftcard_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                GiftCard();
            }
            else
            {                
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void Cash()
        {
            CheckGridView();
            CalculatePayment(ClsEnums.PaymModeEnum.EFECTIVO);

            DataRow NewRow = dataTable.NewRow();

            NewRow[0] = "Efectivo";
            NewRow[1] = paidAmount;
            dataTable.Rows.Add(NewRow);

            GrcPayment.DataSource = dataTable;
        }

        private void CreditCard()
        {
            CheckGridView();
            FrmPaymentCard paymentCard = new FrmPaymentCard();
            paymentCard.ShowDialog();

            if (paymentCard.processResponse)
            {
                CalculatePayment(ClsEnums.PaymModeEnum.TARJETA_CREDITO);

                DataRow NewRow = dataTable.NewRow();
                NewRow[0] = "Tarjeta";
                NewRow[1] = paidAmount;
                dataTable.Rows.Add(NewRow);

                GrcPayment.DataSource = dataTable;
            }
        }

        private void Check()
        {
            CheckGridView();
            FrmPaymentCheck paymentCheck = new FrmPaymentCheck();
            paymentCheck.ShowDialog();

            if (paymentCheck.processResponse)
            {
                CalculatePayment(ClsEnums.PaymModeEnum.CHEQUE_DIA);

                DataRow NewRow = dataTable.NewRow();
                NewRow[0] = "Cheque";
                NewRow[1] = paidAmount; 
                dataTable.Rows.Add(NewRow);

                GrcPayment.DataSource = dataTable;
            }
        }

        private void InternalCredit()
        {
            CheckGridView();
            FrmPaymentCredit paymentCredit = new FrmPaymentCredit();
            paymentCredit.invoiceAmount = invoiceAmount;
            paymentCredit.ShowDialog();
            
            if (paymentCredit.formActionResult)
            {    
                if (functions.RequestSupervisorAuth())
                {
                    CalculatePayment(ClsEnums.PaymModeEnum.TARJETA_CONSUMO);

                    DataRow NewRow = dataTable.NewRow();
                    NewRow[0] = "Credito";
                    NewRow[1] = paidAmount;
                    dataTable.Rows.Add(NewRow);

                    GrcPayment.DataSource = dataTable;                    
                }
            }            
        }

        private void GiftCard()
        {
            CheckGridView();
            CalculatePayment(ClsEnums.PaymModeEnum.BONO);
        }

        private void CheckGridView()
        {                       
            if (dataTable.Columns.Count == 0)
            {
                GrcPayment.DataSource = null;
                GrvPayment.Columns.Clear();
                GrvPayment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                dataTable.Columns.Add("Descripcion", typeof(string));
                dataTable.Columns.Add("Monto", typeof(decimal));

                GrcPayment.DataSource = dataTable;
            }             
        }

        private void CalculatePayment(ClsEnums.PaymModeEnum _paymModeId)
        {
            paidAmount += decimal.Parse(TxtAmount.Text);

            if (_paymModeId == ClsEnums.PaymModeEnum.EFECTIVO)                
            {
                if (paidAmount > invoiceAmount)
                {
                    changeAmount = paidAmount - invoiceAmount;
                    functions.ShowMessage("El cambio a entregar es de $" + changeAmount.ToString());
                    paidAmount = invoiceAmount;
                }
            }
            else if (_paymModeId == ClsEnums.PaymModeEnum.TARJETA_CONSUMO)
            {

            }

            pendingAmount = invoiceAmount - paidAmount;

            LblPaid.Text = paidAmount.ToString();
            LblPending.Text = pendingAmount.ToString();

            if (paidAmount >= invoiceAmount)
            {                
                //close invoice process
                Close();
            }
            else
            {
                TxtAmount.Text = pendingAmount.ToString();
            }
        }

        
    }
}