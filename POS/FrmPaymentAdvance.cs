using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer _currentCustomer;
        public decimal advanceAmount;
        public bool processResponse;
        public int _paymMode;
        public decimal pendingAmount;
        ClsFunctions functions = new ClsFunctions();
        public BindingList<SP_Advance_Consult_Result> advances;
        decimal selectedAmount = 0;

        public FrmPaymentAdvance(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable

        private void CheckGridView()
        {
            GrvAdvanceHistory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcAdvanceHistory.DataSource = null;
            BindingList<SP_Advance_Consult_Result> advances = new BindingList<SP_Advance_Consult_Result>
            {
                AllowNew = false
            };
            GrcAdvanceHistory.DataSource = advances;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (selectedAmount > 0 && selectedAmount <= advanceAmount)
            {
                pendingAmount = selectedAmount;
                processResponse = true;
            }
            else
            {
                functions.ShowMessage("El monto seleccionado debe ser igual o menor al monto digitado.", ClsEnums.MessageType.WARNING);
                DialogResult = DialogResult.None;
            }
        }

        private void LoadPreviousAdvances()
        {
            try
            {
                advances = new BindingList<SP_Advance_Consult_Result>(new ClsAccountsReceivable().GetPendingAccountReceivable(_currentCustomer.CustomerId, _paymMode, CadenaC));
                if (advances.Count == 0)
                {
                    functions.ShowMessage("El cliente no cuenta con valores registrados.", ClsEnums.MessageType.WARNING);
                    DialogResult = DialogResult.Cancel;
                }

                GrcAdvanceHistory.DataSource = advances;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se ha podido cargar registros.", ClsEnums.MessageType.WARNING, true, ex.Message);
            }
        }

        private void FrmPaymentAdvance_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                Text = _paymMode == (int)ClsEnums.PaymModeEnum.ANTICIPOS ? "Anticipo" : "Nota de Credito";
                CheckGridView();
                LoadPreviousAdvances();
                LblAmount.Text = $"{advanceAmount}";
                LblSelectedAmount.Text = $"0.00M";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void GrvAdvanceHistory_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            selectedAmount = 0;
            BindingList<SP_Advance_Consult_Result> array = (BindingList<SP_Advance_Consult_Result>)GrvAdvanceHistory.DataSource;
            foreach (SP_Advance_Consult_Result item in array)
            {
                if ((bool)item.IsSelected)
                {
                    selectedAmount += (decimal)item.AdvanceAmount;
                }
            }
            LblSelectedAmount.Text = selectedAmount.ToString("0.00");
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (_currentCustomer != null)
            {
                if (_currentCustomer.CustomerId != 1)
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", ClsEnums.MessageType.ERROR);
                    DialogResult = DialogResult.Cancel;
                }
            }

            return response;
        }
    }
}