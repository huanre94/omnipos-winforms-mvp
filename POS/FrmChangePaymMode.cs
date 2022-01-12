using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace POS
{
    public partial class FrmChangePaymMode : DevExpress.XtraEditors.XtraForm
    {
        public SP_Login_Consult_Result loginInformation;
        private EmissionPoint emissionPoint;
        private ClsFunctions functions = new ClsFunctions();
        private InvoicePayment invoicePayment;
        private SP_InvoicePayment_Consult_Result row;
        private Customer customer;
        private bool allowChangePaymode;

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
            ClsGeneral clsGeneral = new ClsGeneral();

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
                    functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión."
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
            ClsPaymMode clsPaymMode = new ClsPaymMode();
            List<PaymMode> paymModes;

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
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al catálogo de formas de pago.",
                    ClsEnums.MessageType.ERROR
                                           , true
                                           , ex.Message
                                       );
            }
        }

        private void BtnKeypadEmission_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.EMISSIONPOINT_NUMBER
            };
            keyPad.ShowDialog();
            TxtEmissionPoint.Text = keyPad.emissionPoint;
        }

        private void BtnKeypadInvoice_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.INVOICE_NUMBER
            };
            keyPad.ShowDialog();
            TxtInvoiceNumber.Text = keyPad.invoiceNumber;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetPaymentsInformation(
                                    (int)loginInformation.LocationId
                                    , TxtEmissionPoint.Text
                                    , TxtInvoiceNumber.Text
                                    );
        }

        private void GetPaymentsInformation(
                                            int _locationId
                                            , string _emissionPoint
                                            , string _invoiceNumber
                                            )
        {
            ClsInvoiceTrans invoiceTrans = new ClsInvoiceTrans();
            ClsCustomer clsCustomer = new ClsCustomer();
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
                        BindingList<SP_InvoicePayment_Consult_Result> bindingList = new BindingList<SP_InvoicePayment_Consult_Result>(payments)
                        {
                            AllowNew = true
                        };
                        customer = clsCustomer.GetCustomerById(payments.First().CustomerId);

                        GrcPayments.DataSource = bindingList;
                    }
                }
                else
                {
                    GrcPayments.DataSource = null;
                    functions.ShowMessage("No se encontraron pagos.", ClsEnums.MessageType.WARNING);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de pagos de factura."
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
                allowChangePaymode = false;
                row = (SP_InvoicePayment_Consult_Result)GrvPayments.GetRow(_rowIndex);

                switch ((int)CmbPaymMode.EditValue)
                {
                    case (int)ClsEnums.PaymModeEnum.DEBITO_BANCARIO:
                    case (int)ClsEnums.PaymModeEnum.TARJETA_CREDITO:
                        FrmPaymentCard paymentCard = new FrmPaymentCard
                        {
                            creditCardAmount = row.Amount,
                            customer = customer
                        };
                        paymentCard.ShowDialog();

                        if (paymentCard.processResponse)
                        {
                            allowChangePaymode = paymentCard.processResponse;
                            invoicePayment = new InvoicePayment
                            {
                                PaymModeId = (int)CmbPaymMode.EditValue,
                                BankId = paymentCard.bankId,
                                CreditCardId = paymentCard.creditCardId,
                                Authorization = paymentCard.authorization
                            };
                        }
                        break;

                    case (int)ClsEnums.PaymModeEnum.CHEQUE_DIA:
                    case (int)ClsEnums.PaymModeEnum.CHEQUE_POST:
                        FrmPaymentCheck paymentCheck = new FrmPaymentCheck
                        {
                            checkAmount = row.Amount,
                            customer = customer
                        };
                        paymentCheck.ShowDialog();

                        if (paymentCheck.processResponse)
                        {
                            allowChangePaymode = paymentCheck.processResponse;
                            invoicePayment = new InvoicePayment
                            {
                                PaymModeId = (int)CmbPaymMode.EditValue,
                                CheckOwner = paymentCheck.checkOwnerName,
                                BankId = paymentCheck.checkBankId,
                                CkeckType = "",
                                CkeckDate = paymentCheck.checkDate,
                                AccountNumber = paymentCheck.checkAccountNumber,
                                CkeckNumber = paymentCheck.checkNumber,
                                Authorization = paymentCheck.checkAuthorization
                            };
                        }
                        break;

                    case (int)ClsEnums.PaymModeEnum.BONO:
                        FrmPaymentGiftcard paymentGiftcard = new FrmPaymentGiftcard
                        {
                            paidAmount = row.Amount
                        };
                        paymentGiftcard.ShowDialog();

                        if (paymentGiftcard.formActionResult)
                        {
                            allowChangePaymode = paymentGiftcard.formActionResult;
                            invoicePayment = new InvoicePayment
                            {
                                PaymModeId = (int)CmbPaymMode.EditValue,
                                GiftCardNumber = paymentGiftcard.giftcardNumber
                            };
                        }
                        break;

                    default:
                        allowChangePaymode = true;
                        invoicePayment = new InvoicePayment
                        {
                            PaymModeId = (int)CmbPaymMode.EditValue
                        };
                        break;
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ChangePaymMode();
        }

        private void ChangePaymMode()
        {
            ClsInvoiceTrans invoiceTrans = new ClsInvoiceTrans();

            if (allowChangePaymode)
            {
                functions.emissionPoint = emissionPoint;
                if (emissionPoint != null ? functions.RequestSupervisorAuth() : true)
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
                        functions.ShowMessage("Ocurrió un problema al actualizar forma de pago."
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