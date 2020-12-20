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
using POS.DLL;
using POS.Classes;
using DevExpress.XtraEditors.Controls;

namespace POS
{
    public partial class FrmChangePaymMode : DevExpress.XtraEditors.XtraForm
    {
        public SP_Login_Consult_Result loginInformation;
        EmissionPoint emissionPoint;
        ClsFunctions functions = new ClsFunctions();
        InvoicePayment invoicePayment;
        SP_InvoicePayment_Consult_Result row;
        Customer customer;
        bool allow;

        public FrmChangePaymMode()
        {
            InitializeComponent();
        }

        private void FrmChangePaymMode_Load(object sender, EventArgs e)
        {
            if (!GetEmissionPointInformation())
            {
                LblEmission.Visible = true;
                TxtEmissionPoint.Visible = true;
                BtnKeypadEmission.Visible = true;
            }

            LoadPaymModes();
        }

        private bool GetEmissionPointInformation()
        {
            DLL.Catalog.ClsGeneral clsGeneral = new DLL.Catalog.ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", ClsEnums.MessageType.WARNING);
            }

            if (emissionPoint != null)
            {
                response = true;
                TxtEmissionPoint.Text = emissionPoint.Emission;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void LoadPaymModes()
        {
            DLL.Catalog.ClsPaymMode clsPaymMode = new DLL.Catalog.ClsPaymMode();
            List<DLL.PaymMode> paymModes;

            try
            {
                paymModes = clsPaymMode.GetPaymModes();

                if (paymModes != null)
                {
                    if (paymModes.Count > 0)
                    {
                        foreach (var paym in paymModes)
                        {
                            CmbPaymMode.Properties.Items.Add(new ImageComboBoxItem { Value = paym.PaymModeId, Description = paym.Name });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                functions.ShowMessage(
                                           "Ocurrio un problema al catálogo de formas de pago."
                                           , ClsEnums.MessageType.ERROR
                                           , true
                                           , ex.Message
                                       );
            }
        }

        private void BtnKeypadEmission_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.EMISSIONPOINT_NUMBER;
            keyPad.ShowDialog();
            TxtEmissionPoint.Text = keyPad.emissionPoint;
        }

        private void BtnKeypadInvoice_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.INVOICE_NUMBER;
            keyPad.ShowDialog();
            TxtInvoiceNumber.Text = keyPad.invoiceNumber;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetPaymentsInformation(
                                    (int)loginInformation.LocationId
                                    ,TxtEmissionPoint.Text
                                    ,TxtInvoiceNumber.Text
                                    );
        }

        private void GetPaymentsInformation(
                                            int _locationId
                                            ,string _emissionPoint
                                            ,string _invoiceNumber
                                            )
        {
            DLL.Transaction.ClsInvoiceTrans invoiceTrans = new DLL.Transaction.ClsInvoiceTrans();
            DLL.Catalog.ClsCustomer clsCustomer = new DLL.Catalog.ClsCustomer();
            List<SP_InvoicePayment_Consult_Result> payments;

            try 
            {
                payments = invoiceTrans.GetInvoicePayments(
                                                            _locationId
                                                            , _emissionPoint
                                                            , _invoiceNumber
                                                            );

                if (payments != null)
                {
                    if (payments.Count > 0)
                    {
                        BindingList<SP_InvoicePayment_Consult_Result> bindingList = new BindingList<SP_InvoicePayment_Consult_Result>(payments);
                        bindingList.AllowNew = true;
                        customer = clsCustomer.GetCustomerById(payments.First().CustomerId);

                        GrcPayments.DataSource = bindingList;
                    }
                }
                else
                {
                    GrcPayments.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de pagos de factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void CmbPaymMode_SelectedValueChanged(object sender, EventArgs e)
        {
            int rowIndex = GrvPayments.FocusedRowHandle;
            SelectPaymentOption(rowIndex);
        }

        private void SelectPaymentOption(int _rowIndex)
        {
            if (_rowIndex < 0)
            {
                functions.ShowMessage("No ha seleccionado ningun registro.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                allow = false;
                row = (SP_InvoicePayment_Consult_Result)GrvPayments.GetRow(_rowIndex);

                if ((int)CmbPaymMode.EditValue == (int)ClsEnums.PaymModeEnum.DEBITO_BANCARIO || (int)CmbPaymMode.EditValue == (int)ClsEnums.PaymModeEnum.TARJETA_CREDITO)
                {
                    FrmPaymentCard paymentCard = new FrmPaymentCard();
                    paymentCard.creditCardAmount = row.Amount;
                    paymentCard.customer = customer;
                    paymentCard.ShowDialog();

                    if (paymentCard.processResponse)
                    {
                        allow = paymentCard.processResponse;
                        invoicePayment = new InvoicePayment();
                        invoicePayment.PaymModeId = (int)CmbPaymMode.EditValue;
                        invoicePayment.BankId = paymentCard.bankId;
                        invoicePayment.CreditCardId = paymentCard.creditCardId;
                        invoicePayment.Authorization = paymentCard.authorization;
                    }
                }
                else if ((int)CmbPaymMode.EditValue == (int)ClsEnums.PaymModeEnum.CHEQUE_DIA || (int)CmbPaymMode.EditValue == (int)ClsEnums.PaymModeEnum.CHEQUE_POST)
                {
                    FrmPaymentCheck paymentCheck = new FrmPaymentCheck();
                    paymentCheck.checkAmount = row.Amount;
                    paymentCheck.customer = customer;
                    paymentCheck.ShowDialog();

                    if (paymentCheck.processResponse)
                    {
                        allow = paymentCheck.processResponse;
                        invoicePayment = new InvoicePayment();
                        invoicePayment.PaymModeId = (int)CmbPaymMode.EditValue;
                        invoicePayment.CheckOwner = paymentCheck.checkOwnerName;
                        invoicePayment.BankId = paymentCheck.checkBankId;
                        invoicePayment.CkeckType = "";
                        invoicePayment.CkeckDate = paymentCheck.checkDate;
                        invoicePayment.AccountNumber = paymentCheck.checkAccountNumber;
                        invoicePayment.CkeckNumber = paymentCheck.checkNumber;
                        invoicePayment.Authorization = paymentCheck.checkAuthorization;
                    }
                }
                else if ((int)CmbPaymMode.EditValue == (int)ClsEnums.PaymModeEnum.BONO)
                {
                    FrmPaymentGiftcard paymentGiftcard = new FrmPaymentGiftcard();
                    paymentGiftcard.paidAmount = row.Amount;
                    paymentGiftcard.ShowDialog();

                    if (paymentGiftcard.formActionResult)
                    {
                        allow = paymentGiftcard.formActionResult;
                        invoicePayment = new InvoicePayment();
                        invoicePayment.PaymModeId = (int)CmbPaymMode.EditValue;
                        invoicePayment.GiftCardNumber = paymentGiftcard.giftcardNumber;
                    }
                }
                else
                {
                    allow = true;
                    invoicePayment = new InvoicePayment();
                    invoicePayment.PaymModeId = (int)CmbPaymMode.EditValue;
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ChangePaymMode();
        }

        private void ChangePaymMode()
        {
            DLL.Transaction.ClsInvoiceTrans invoiceTrans = new DLL.Transaction.ClsInvoiceTrans();

            if (allow)
            {
                functions.emissionPoint = emissionPoint;

                if (emissionPoint != null ? functions.RequestSupervisorAuth(): true)
                {
                    try
                    {
                        bool response = invoiceTrans.UpdateInvoicePayments(
                                                                            row.InvoiceId
                                                                            , row.PaymModeId
                                                                            , row.Sequence
                                                                            , invoicePayment
                                                                            , (int)loginInformation.UserId
                                                                            , loginInformation.Workstation
                                                                            );

                        if (response)
                        {
                            functions.ShowMessage("Actualización realizada exitosamente.");
                        }
                        else
                        {
                            functions.ShowMessage("No se pudo realizar actualización", ClsEnums.MessageType.WARNING);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage(
                                                "Ocurrió un problema al actualizar forma de pago."
                                                , ClsEnums.MessageType.ERROR
                                                , true
                                                , ex.InnerException.Message
                                            );
                    }
                }
            }
            else
            {
                functions.ShowMessage("No se puede realizar actualización por falta de información.", ClsEnums.MessageType.WARNING);
            }
        }
    }
}