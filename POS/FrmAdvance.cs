using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer _currentCustomer;
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        ClsFunctions functions = new ClsFunctions();
        List<SP_Advance_Consult_Result> advances;
        decimal TypedAmount = 0.00M;
        decimal TotalAdvances = 0.00M;

        public FrmAdvance()
        {
            InitializeComponent();
        }

        private void FrmAdvance_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                CheckGridView();
                LoadPreviousAdvances();
            }
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


                foreach (var item in advances)
                {
                    TotalAdvances += (decimal)item.AdvanceAmount;
                }

                GrcAdvanceHistory.DataSource = advances;
                LblTotalAdvance.Text = TotalAdvances.ToString("0.00");
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
                long lastId = 0;// new ClsAccountsReceivableTrans().;

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
                                        "Ocurrio un problema al imprimir la último anticipo."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (_currentCustomer != null)
            {
                if (_currentCustomer.CustomerId != 1)
                {
                    LblCustomerName.Text = _currentCustomer.Firtsname + " " + _currentCustomer.Lastname;
                    response = true;
                }
                else
                {
                    functions.ShowMessage("No se puede realizar anticipos a CONSUMIDOR FINAL.", ClsEnums.MessageType.ERROR);
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            return response;
        }

        private void BtnAdvancePayment_Click(object sender, EventArgs e)
        {

        }

        private void BtnKeypadAdvance_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.ADVANCE_AMOUNT
            };
            keyPad.ShowDialog();

            if (keyPad.advanceAmount != "")
            {
                TypedAmount = decimal.Parse(keyPad.advanceAmount);
                LblTotal.Text = TypedAmount.ToString();
            }
            else
            {
                functions.ShowMessage(
                                                 "No se ."
                                                 , ClsEnums.MessageType.WARNING
                                                 , false
                                                 );
            }
        }
    }
}