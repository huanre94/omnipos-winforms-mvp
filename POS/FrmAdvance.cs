using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer _currentCustomer;
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;
        ClsFunctions functions = new ClsFunctions();
        List<SP_Advance_Consult_Result> advances;
        decimal TypedAmount = 0.00M;
        decimal TotalAdvances = 0.00M;
        XElement advanceXml = new XElement("Advance");

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
                    DialogResult = DialogResult.Cancel;
                }
            }

            return response;
        }

        private void BtnAdvancePayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblTotal.Text != "" && TypedAmount != 0)
                {
                    FrmPayment payment = new FrmPayment
                    {
                        invoiceAmount = decimal.Parse(LblTotal.Text),
                        customer = _currentCustomer,
                        emissionPoint = emissionPoint,
                        loginInformation = loginInformation,
                        paymentMethod = false,
                        invoiceXml = advanceXml
                    };
                    payment.ShowDialog();

                    if (payment.canCloseInvoice)
                    {
                        if (payment.paymentXml.HasElements)
                        {
                            advanceXml.Add(payment.paymentXml);
                            ClosingInvoice();
                        }
                    }
                }
                else
                {
                    functions.ShowMessage("El valor del anticipo debe ser mayor a cero.", ClsEnums.MessageType.ERROR);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("El valor del anticipo debe ser mayor a cero.", ClsEnums.MessageType.ERROR, true, ex.Message);
            }

        }

        private void BtnKeypadAdvance_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.ADVANCE_AMOUNT
            };
            keyPad.ShowDialog();

            TypedAmount = keyPad.advanceAmount == "" ? 0 : decimal.Parse(keyPad.advanceAmount);
            LblTotal.Text = TypedAmount.ToString("0.00");
        }

        private void ClosingInvoice()
        {
            SP_Advance_Insert_Result result = null;
            XElement invoiceTableXml = new XElement("AccountsReceivable");

            try
            {
                AccountsReceivable accountsReceivable = new AccountsReceivable()
                {
                    LocationId = emissionPoint.LocationId,
                    TypeDoc = 8,
                    CustomerId = _currentCustomer.CustomerId,
                    Amount = decimal.Parse(LblTotal.Text),
                    AmountPaid = 0,
                    Status = "A",
                    StatusAccounts = "",
                    CreatedBy = (int)loginInformation.UserId,
                    Workstation = loginInformation.Workstation
                };

                Type type = accountsReceivable.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(accountsReceivable);

                    if (value == null)
                    {
                        value = "";
                    }

                    invoiceTableXml.Add(new XElement(name, value));
                }

                advanceXml.Add(invoiceTableXml);

                result = new ClsAccountsReceivableTrans().AddAdvance(advanceXml);

                if (result != null)
                {
                    if (!(bool)result.Error)
                    {
                        ClearAdvance();

                        //if (PrintInvoice((Int64)invoiceResult.InvoiceId))
                        if (functions.PrintDocument((long)result.AccountsReceivableId, ClsEnums.DocumentType.ADVANCE, true))
                        {
                            functions.ShowMessage("Venta finalizada exitosamente.");
                        }
                        else
                        {
                            functions.ShowMessage("La venta finalizó correctamente pero no se pudo imprimir factura.", ClsEnums.MessageType.WARNING);
                        }
                    }
                    else
                    {
                        // Begin(IG004)
                        var invoiceRemoveXml = from xm in advanceXml.Descendants("Payment")
                                               select xm;
                        invoiceRemoveXml.Remove();
                        // End(IG004)

                        var invoiceTableRemoveXml = from xm in advanceXml.Descendants("InvoiceTable")
                                                    select xm;
                        invoiceTableRemoveXml.Remove();

                        functions.ShowMessage(
                                               "No se ha podido registrar la factura. Revisar detalle."
                                               , ClsEnums.MessageType.WARNING
                                               , true
                                               , result.TextError
                                            );
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ha ocurrido un problema al registrar la factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
            finally
            {
                invoiceTableXml.RemoveAll();
            }
        }

        private void BtnRefreshAdvance_Click(object sender, EventArgs e)
        {
            LoadPreviousAdvances();
        }

        private void BtnPrintHistoricAdvance_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelAdvance_Click(object sender, EventArgs e)
        {

        }

        private void ClearAdvance()
        {
            LblTotal.Text = "0.00";
        }
    }
}