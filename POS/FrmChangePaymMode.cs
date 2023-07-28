using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmChangePaymMode : DevExpress.XtraEditors.XtraForm
    {
        private readonly ClsFunctions functions = new ClsFunctions();
        private SP_Login_Consult_Result LoginInformation { get; set; }
        private EmissionPoint emissionPoint;
        private InvoicePayment invoicePayment;
        private SP_InvoicePayment_Consult_Result row;
        private Customer customer;
        private bool allowChangePaymode { get; set; }

        public FrmChangePaymMode()
        {
            InitializeComponent();
        }

        public FrmChangePaymMode(SP_Login_Consult_Result _loginInformation)
        {
            InitializeComponent();
            LoginInformation = _loginInformation;
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
            string addressIP = LoginInformation.AddressIP;

            if (addressIP == "")
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return true;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

            if (emissionPoint == null)
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                return true;
            }

            TxtEmissionPoint.Text = emissionPoint.Emission;
            return false;
        }

        private void LoadPaymModes()
        {
            try
            {
                IEnumerable<PaymMode> paymModes = new ClsPaymMode(Program.customConnectionString).GetPaymModes();

                if (paymModes?.Count() > 0)
                {
                    foreach (PaymMode paym in paymModes)
                    {
                        CmbPaymMode.Properties.Items.Add(new ImageComboBoxItem { Value = paym.PaymModeId, Description = paym.Name });
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al catálogo de formas de pago.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private void BtnKeypadEmission_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.EMISSIONPOINT_NUMBER);
            keyPad.ShowDialog();

            TxtEmissionPoint.Text = keyPad.GetValue();
        }

        private void BtnKeypadInvoice_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.INVOICE_NUMBER);
            keyPad.ShowDialog();
            TxtInvoiceNumber.Text = keyPad.GetValue();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetPaymentsInformation((int)LoginInformation.LocationId,
                                   TxtEmissionPoint.Text,
                                   TxtInvoiceNumber.Text);
        }

        private void GetPaymentsInformation(int _locationId,
                                            string _emissionPoint,
                                            string _invoiceNumber)
        {
            try
            {
                IEnumerable<SP_InvoicePayment_Consult_Result> payments = new InvoiceRepository(Program.customConnectionString).GetInvoicePayments(_locationId, _emissionPoint, _invoiceNumber);

                if (payments == null)
                {
                    GrcPayments.DataSource = null;
                    functions.ShowMessage("No se encontraron pagos.", MessageType.WARNING);
                    return;
                }

                if (payments?.Count() > 0)
                {
                    BindingList<SP_InvoicePayment_Consult_Result> bindingList = new BindingList<SP_InvoicePayment_Consult_Result>(payments.ToList())
                    {
                        AllowNew = true
                    };
                    customer = new CustomerRepository(Program.customConnectionString).GetCustomerById(payments.First().CustomerId);

                    GrcPayments.DataSource = bindingList;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de pagos de factura.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void CmbPaymMode_SelectedValueChanged(object sender, EventArgs e)
        {
            //08/07/2022  Se comento para que realice este proceso al dar Enter en la linea seleccionada.
            //int rowIndex = GrvPayments.FocusedRowHandle;
            //SelectPaymentOption(rowIndex);
        }

        private void SelectPaymentOption(int _rowIndex)
        {
            if (_rowIndex < 0)
            {
                functions.ShowMessage("No ha seleccionado ningun registro.", MessageType.WARNING);
                return;
            }

            allowChangePaymode = false;
            row = (SP_InvoicePayment_Consult_Result)GrvPayments.GetRow(_rowIndex);

            switch ((int)CmbPaymMode.EditValue)
            {
                case (int)PaymModeEnum.DEBITO_BANCARIO:
                case (int)PaymModeEnum.TARJETA_CREDITO:
                    FrmPaymentCard paymentCard = new FrmPaymentCard()
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

                case (int)PaymModeEnum.CHEQUE_DIA:
                case (int)PaymModeEnum.CHEQUE_POST:
                    FrmPaymentCheck paymentCheck = new FrmPaymentCheck()
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

                case (int)PaymModeEnum.BONO:
                    FrmPaymentGiftcard paymentGiftcard = new FrmPaymentGiftcard()
                    {
                        PaidAmount = row.Amount
                    };
                    paymentGiftcard.ShowDialog();

                    if (paymentGiftcard.FormActionResult)
                    {
                        allowChangePaymode = paymentGiftcard.FormActionResult;
                        invoicePayment = new InvoicePayment
                        {
                            PaymModeId = (int)CmbPaymMode.EditValue,
                            GiftCardNumber = paymentGiftcard.giftcardNumber
                        };
                    }
                    break;

                //case (int)PaymModeEnum.CREDITO:
                //    FrmPaymentCredit credit = new FrmPaymentCredit()
                //    {

                //    }


                default:
                    allowChangePaymode = true;
                    invoicePayment = new InvoicePayment
                    {
                        PaymModeId = (int)CmbPaymMode.EditValue
                    };
                    break;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ChangePaymMode();
        }

        private void ChangePaymMode()
        {
            if (!allowChangePaymode)
            {
                functions.ShowMessage("No se puede realizar actualización por falta de información.", MessageType.WARNING);
                return;
            }

            functions.emissionPoint = emissionPoint;
            if (emissionPoint == null || functions.RequestSupervisorAuth())
            {
                try
                {
                    bool response = new InvoiceRepository(Program.customConnectionString).UpdateInvoicePayments(row.InvoiceId,
                                                                                                              row.PaymModeId,
                                                                                                              row.Sequence,
                                                                                                              invoicePayment,
                                                                                                              (int)LoginInformation.UserId,
                                                                                                              LoginInformation.Workstation);

                    if (!response)
                    {
                        functions.ShowMessage("No se pudo realizar actualización", MessageType.WARNING);
                        return;
                    }

                    functions.ShowMessage("Actualización realizada exitosamente.");
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrió un problema al actualizar forma de pago.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }
            }
        }

        private void TxtEmissionPoint_KeyDown(object sender, KeyEventArgs e)
        {
            //07/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtInvoiceNumber.Focus();
                    break;
                case Keys.F1:
                    BtnKeypadEmission_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //07/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnSearch_Click(null, null);
                    CmbPaymMode.Focus();//07/07/2022
                    break;
                case Keys.F1:
                    BtnKeypadInvoice_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void CmbPaymMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //08/08/2022
                int rowIndex = GrvPayments.FocusedRowHandle;
                SelectPaymentOption(rowIndex);
                BtnAccept.Focus();
            }
        }
    }
}