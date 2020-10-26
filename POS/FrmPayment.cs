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

namespace POS
{
    public partial class FrmPayment : DevExpress.XtraEditors.XtraForm
    {
        DataTable dataTable = new DataTable();
        decimal invoiceAmount = 0;

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            LblTotal.Text = invoiceAmount.ToString();

            var db = new POSEntities();
            var customer = from cust in db.Customer
                           select cust;
            MessageBox.Show(customer.First().Lastname);


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (GrvPayment.RowCount > 0)
            {
                FrmMessage message = new FrmMessage();
                message.messagetype = "Confirm";
                message.messageText = "Existen pagos registrados. Desea continuar?";
                message.ShowDialog();

                if (message.messageResponse)
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
                this.Cash();
            }
            else
            {
                FrmMessage frmMessage = new FrmMessage();
                frmMessage.messagetype = "Warning";
                frmMessage.messageText = "Debe ingresar un valor obligatoriamente";
                frmMessage.ShowDialog();
            }
        }

        private void BtnCreditCard_Click(object sender, EventArgs e)
        {
            this.CreditCard();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        private void BtnEmployeeCredit_Click(object sender, EventArgs e)
        {
            this.EmployeeCredit();
        }

        private void BtnGiftcard_Click(object sender, EventArgs e)
        {
            this.GiftCard();
        }

        private void Cash()
        {
            CheckGridView();
            DataRow NewRow = dataTable.NewRow();

            NewRow[0] = "Efectivo";
            NewRow[1] = decimal.Parse(TxtAmount.Text);
            dataTable.Rows.Add(NewRow);

            GrcPayment.DataSource = dataTable;
            TxtAmount.Text = "";
        }

        private void CreditCard()
        {
            CheckGridView();
            FrmPaymentCard paymentCard = new FrmPaymentCard();
            paymentCard.ShowDialog();

            DataRow NewRow = dataTable.NewRow();

            NewRow[0] = "Tarjeta";
            NewRow[1] = decimal.Parse(TxtAmount.Text);
            dataTable.Rows.Add(NewRow);

            GrcPayment.DataSource = dataTable;
            TxtAmount.Text = "";            
        }

        private void Check()
        {
            FrmPaymentCheck paymentCheck = new FrmPaymentCheck();
            paymentCheck.ShowDialog();
        }

        private void EmployeeCredit()
        {
            //do something
        }

        private void GiftCard()
        {
            //do something
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

            //GrvPayment.AddNewRow();
            //GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, Description, "Efectivo");
            //GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, Amount, decimal.Parse(TxtAmount.Text));
        }

        
    }
}