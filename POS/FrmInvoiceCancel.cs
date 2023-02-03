using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmInvoiceCancel : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public IEnumerable<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        EmissionPoint emissionPoint;

        public FrmInvoiceCancel()
        {
            InitializeComponent();
        }

        private void FrmInvoiceCancel_Load(object sender, EventArgs e)
        {
            ClearInvoice();
            if (GetEmissionPointInformation())
            {

            }
            LblCashierUser.Text = loginInformation.UserName;
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP == string.Empty)
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return false;
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
                    ex.Message);
            }


            if (emissionPoint == null)
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                TxtEmissionPoint.Enabled = true;
                return false;
            }

            LblEstablishment.Text = emissionPoint.Establishment;
            TxtEmissionPoint.Text = emissionPoint.Emission;
            TxtEmissionPoint.Enabled = false;
            return true;

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (long.Parse(LblInvoiceId.Text) <= 0)
            {
                functions.ShowMessage("Debe seleccionar una factura valida", MessageType.WARNING);
            }
            else
            {
                functions.emissionPoint = emissionPoint;
                if (functions.RequestSupervisorAuth(true, (int)CancelReasonType.ITEM_CANCEL))
                {
                    SalesLog salesLog = new SalesLog
                    {
                        CustomerId = 1,
                        EmissionPointId = emissionPoint.EmissionPointId,
                        LocationId = emissionPoint.LocationId,
                        InvoiceNumber = int.Parse(TxtSequence.Text),
                        XmlLog = string.Empty,
                        ReasonId = functions.motiveId,
                        LogTypeId = (int)DLL.Enums.LogType.ANULAR_FACTURA,
                        Authorization = functions.supervisorAuthorization,
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };

                    InvoiceTable invoiceTable = null;
                    try
                    {
                        invoiceTable = new ClsInvoiceTrans(Program.customConnectionString).ConsultInvoice(int.Parse(LblInvoiceId.Text));
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un problema al consultar documento.", MessageType.ERROR, true, ex.Message);
                    }

                    invoiceTable.TransferStatusId = 4;
                    invoiceTable.Observation = TxtObservation.Text;
                    invoiceTable.ClosingCashierId = -99;
                    invoiceTable.Status = "I";
                    invoiceTable.ModifiedBy = loginInformation.UserId;
                    invoiceTable.ModifiedDatetime = DateTime.Now;

                    bool invoiceCancel = false;
                    try
                    {
                        invoiceCancel = new ClsInvoiceTrans(Program.customConnectionString).CancelInvoice(salesLog, invoiceTable);
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un problema al cargar venta anulada."
                                            , MessageType.ERROR
                                            , true
                                            , ex.Message);
                    }

                    if (invoiceCancel)
                    {
                        functions.ShowMessage("Factura anulada correctamente.", MessageType.INFO);
                        ClearInvoice();
                    }
                    else
                    {
                        functions.ShowMessage("Hubo un error al anular la transaccion, por favor vuelva a intentar", MessageType.ERROR);
                    }
                }
            }
        }

        private void ClearInvoice()
        {
            TxtSequence.Text = string.Empty;
            //TxtEmissionPoint.Text = string.Empty;
            LblInvoiceId.Text = $"{0}";
            LblInvoiceStatus.Text = "PENDIENTE";
            LblCustomerIdentification.Text = "9999999999";
            LblCustomerName.Text = "CONSUMIDOR FINAL";
            LblInvoiceAmount.Text = $"$ {0:0.##}";
            TxtObservation.Text = string.Empty;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtEmissionPoint.Text == string.Empty)
            {
                functions.ShowMessage("Punto de emision de factura no puede estar vacia", MessageType.WARNING);
            }
            else if (TxtSequence.Text == string.Empty)
            {
                functions.ShowMessage("Secuencia de factura no puede estar vacia", MessageType.WARNING);
            }
            else
            {

                try
                {
                    SP_InvoiceCancel_Consult_Result response = new ClsInvoiceTrans(Program.customConnectionString).ConsultInvoiceStatus(emissionPoint, int.Parse(TxtSequence.Text));

                    if (response != null)
                    {

                        if (response.TransferStatusId == (int)DLL.Enums.TransferStatus.PENDING_MIGRATE)
                        {
                            functions.ShowMessage("La factura aun no ha sido migrada a ERP.", MessageType.WARNING);
                            return;
                        }

                        if (response.Status.Equals("A") || response.Status.Equals("C"))
                        {
                            LblInvoiceId.Text = $"{response.InvoiceId}";
                            LblInvoiceStatus.Text = response.StatusDesc;
                            LblCustomerIdentification.Text = response.Identification;
                            LblCustomerName.Text = $"{response.Firtsname} {response.Lastname}";
                            LblInvoiceAmount.Text = $"$ {response.Total:0.##}";
                        }
                        else
                        {
                            functions.ShowMessage("La factura ya se encuentra anulada.", MessageType.WARNING);
                        }
                    }
                    else
                    {
                        functions.ShowMessage("No existe factura con la secuencia digitada.", MessageType.WARNING);
                        ClearInvoice();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar venta anulada."
                                                , MessageType.ERROR
                                                , true
                                                , ex.InnerException.Message);
                }
            }
        }

        private void BtnEmissionPointKeyPad_Click(object sender, EventArgs e)
        {
            using (FrmKeyPad emissionPointKeypad = new FrmKeyPad()
            {
                inputFromOption = InputFromOption.EMISSIONPOINT_NUMBER
            })
            {
                emissionPointKeypad.ShowDialog();

                if (emissionPointKeypad.emissionPoint != string.Empty)
                {
                    TxtEmissionPoint.Text = emissionPointKeypad.emissionPoint;
                }
            }
        }

        private void BtnSeqKeyPad_Click(object sender, EventArgs e)
        {
            using (FrmKeyPad sequenceKeyPad = new FrmKeyPad()
            {
                inputFromOption = InputFromOption.INVOICE_NUMBER
            })
            {
                sequenceKeyPad.ShowDialog();

                if (sequenceKeyPad.invoiceNumber != string.Empty)
                {
                    TxtSequence.Text = sequenceKeyPad.invoiceNumber;
                }
            }
        }

        private void BtnObservationKeyBoard_Click(object sender, EventArgs e)
        {
            using (FrmKeyBoard observationKeyboard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.OBSERVATION
            })
            {
                observationKeyboard.ShowDialog();
                TxtObservation.Text = observationKeyboard.observation;  // observationKeyboard.checkOwnerName;  08/07/2022 Se inactivo porque trae un campo vacio
            }
        }

        private void TxtSequence_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnSearch_Click(null, null);
                    break;
                case Keys.F1:
                    BtnSeqKeyPad_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void TxtObservation_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnObservationKeyBoard_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}