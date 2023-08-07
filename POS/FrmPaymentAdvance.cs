using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentAdvance : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public Customer _currentCustomer;
        public decimal paymentAmount;
        public PaymModeEnum _paymMode;
        public decimal pendingAmount;
        public BindingList<SP_Advance_Consult_Result> advances;
        bool ProcessResponse { get; set; } = false;

        decimal selectedAmount = 0;

        public FrmPaymentAdvance()
        {
            InitializeComponent();
        }

        public bool GetResponse() => ProcessResponse;

        private void CheckGridView()
        {
            GrvAdvanceHistory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcAdvanceHistory.DataSource = null;

            BindingList<SP_Advance_Consult_Result> advances = new BindingList<SP_Advance_Consult_Result> { AllowNew = false };
            GrcAdvanceHistory.DataSource = advances;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (selectedAmount <= 0 || selectedAmount > paymentAmount)
            {
                functions.ShowMessage("El monto seleccionado debe ser igual o menor al monto digitado.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            pendingAmount = selectedAmount;
            ProcessResponse = true;
        }

        private void LoadPreviousAdvances()
        {
            try
            {
                ICollection<SP_Advance_Consult_Result> advancesList = new AccountsReceivableRepository(Program.customConnectionString).GetPendingAccountReceivable(_currentCustomer.CustomerId, _paymMode);
                advances = new BindingList<SP_Advance_Consult_Result>(advancesList.ToList());
                if (advances?.Count() <= 0)
                {
                    functions.ShowMessage("El cliente no cuenta con valores registrados.", MessageType.WARNING);
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                GrcAdvanceHistory.DataSource = advances;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se ha podido cargar registros.",
                                      MessageType.WARNING,
                                      true,
                                      ex.Message);
            }
        }

        private void FrmPaymentAdvance_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                Text = _paymMode == PaymModeEnum.ANTICIPOS ? "Anticipo" : "Nota de Credito";
                CheckGridView();
                LoadPreviousAdvances();
                LblAmount.Text = $"{paymentAmount}";
                LblSelectedAmount.Text = $"0.00M";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) { }

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
            if (_currentCustomer?.CustomerId == 1)
            {
                functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
                DialogResult = DialogResult.Cancel;
                return false;
            }

            return true;
        }
    }
}
