using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS
{
    public partial class FrmPaymentAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer _currentCustomer;
        public decimal advanceAmount;
        public bool processResponse;
        ClsFunctions functions = new ClsFunctions();
        List<SP_Advance_Consult_Result> advances;

        public FrmPaymentAdvance()
        {
            InitializeComponent();
        }

        private void CheckGridView()
        {
            GrvAdvanceHistory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcAdvanceHistory.DataSource = null;
            BindingList<SP_Advance_Consult_Result> bindingList = new BindingList<SP_Advance_Consult_Result>
            {
                AllowNew = false
            };
            GrcAdvanceHistory.DataSource = bindingList;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {

        }

        private void LoadPreviousAdvances()
        {
            try
            {
                advances = new ClsAccountsReceivable().GetPendingAdvances(_currentCustomer.CustomerId);
                if (advances.Count == 0)
                {
                    advances = new List<SP_Advance_Consult_Result>();

                    functions.ShowMessage(
                                  "No existen anticipos previamente registrados."
                                  , ClsEnums.MessageType.WARNING
                                  , false
                                  );

                }

                GrcAdvanceHistory.DataSource = advances;
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                                  "No se ha podido iniciar sesión."
                                                  , ClsEnums.MessageType.WARNING
                                                  , true
                                                  , ex.InnerException.Message
                                                  );
            }
        }

        private void FrmPaymentAdvance_Load(object sender, EventArgs e)
        {
            CheckGridView();
            LoadPreviousAdvances();
            LblAmount.Text = advanceAmount.ToString();
            LblSelectedAmount.Text = 0.00M.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}