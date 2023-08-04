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
        IEnumerable<GlobalParameter> GlobalParameters { get; set; }
        SP_Login_Consult_Result LoginInformation { get; set; }
        EmissionPoint emissionPoint;

        public FrmInvoiceCancel()
        {
            InitializeComponent();
        }

        public FrmInvoiceCancel(IEnumerable<GlobalParameter> globalParameters, SP_Login_Consult_Result loginInformation)
        {
            InitializeComponent();
            GlobalParameters = globalParameters;
            LoginInformation = loginInformation;
        }

        private void FrmInvoiceCancel_Load(object sender, EventArgs e)
        {
            ClearInvoice();
            if (GetEmissionPointInformation())
            {

            }
            LblCashierUser.Text = LoginInformation.UserName;
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = LoginInformation.AddressIP;

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
                return;
            }

            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth(true, CancelReasonType.ITEM_CANCEL))
            {
                SalesLog salesLog = new SalesLog
                {
                    CustomerId = 1,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    LocationId = emissionPoint.LocationId,
                    InvoiceNumber = int.Parse(TxtSequence.Text),
                    XmlLog = string.Empty,
                    ReasonId = functions.MotiveId,
                    LogTypeId = (int)DLL.Enums.LogType.ANULAR_FACTURA,
                    Authorization = functions.SupervisorAuthorization,
                    CreatedDatetime = DateTime.Now,
                    CreatedBy = (int)LoginInformation.UserId,
                    Status = "A",
                    Workstation = LoginInformation.Workstation
                };

                InvoiceTable invoiceTable = null;
                try
                {
                    invoiceTable = new InvoiceRepository(Program.customConnectionString).GetInvoiceById(int.Parse(LblInvoiceId.Text));
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al consultar documento.", MessageType.ERROR, true, ex.Message);
                }

                invoiceTable.TransferStatusId = (int)DLL.Enums.TransferStatus.PENDING_UPDATE;
                invoiceTable.Observation = TxtObservation.Text;
                invoiceTable.ClosingCashierId = -99;
                invoiceTable.Status = "I";
                invoiceTable.ModifiedBy = LoginInformation.UserId;
                invoiceTable.ModifiedDatetime = DateTime.Now;

                bool invoiceCancel = false;
                try
                {
                    invoiceCancel = new InvoiceRepository(Program.customConnectionString).CancelInvoice(salesLog, invoiceTable);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar venta anulada."
                                        , MessageType.ERROR
                                        , true
                                        , ex.Message);
                }

                if (!invoiceCancel)
                {
                    functions.ShowMessage("Hubo un error al anular la transaccion, por favor vuelva a intentar", MessageType.ERROR);
                    return;
                }

                functions.ShowMessage("Factura anulada correctamente.", MessageType.INFO);
                ClearInvoice();
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
                return;
            }

            if (TxtSequence.Text == string.Empty)
            {
                functions.ShowMessage("Secuencia de factura no puede estar vacia", MessageType.WARNING);
                return;
            }

            try
            {
                InvoiceTable response = new InvoiceRepository(Program.customConnectionString).GetInvoiceByNumber(emissionPoint, int.Parse(TxtSequence.Text));

                if (response == null)
                {
                    functions.ShowMessage("No existe factura con la secuencia digitada.", MessageType.WARNING);
                    return;
                }

                if (response.TransferStatusId == (int)DLL.Enums.TransferStatus.PENDING_MIGRATE)
                {
                    functions.ShowMessage("La factura aun no ha sido migrada a ERP.", MessageType.WARNING);
                    return;
                }

                if (!response.Status.Equals("A") && !response.Status.Equals("C"))
                {
                    functions.ShowMessage("La factura ya se encuentra anulada.", MessageType.WARNING);
                    return;
                }

                LblInvoiceId.Text = $"{response.InvoiceId}";
                LblInvoiceStatus.Text = response.Status;
                LblCustomerIdentification.Text = response.Customer.Identification;
                LblCustomerName.Text = $"{response.Customer.Firtsname} {response.Customer.Lastname}";
                LblInvoiceAmount.Text = $"$ {response.Total:0.##}";
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar venta anulada.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void BtnEmissionPointKeyPad_Click(object sender, EventArgs e)
        {
            using (FrmKeyPad emissionPointKeypad = new FrmKeyPad(InputFromOption.EMISSIONPOINT_NUMBER))
            {
                emissionPointKeypad.ShowDialog();

                TxtEmissionPoint.Text = emissionPointKeypad.GetValue();
            }
        }

        private void BtnSeqKeyPad_Click(object sender, EventArgs e)
        {
            using (FrmKeyPad sequenceKeyPad = new FrmKeyPad(InputFromOption.INVOICE_NUMBER))
            {
                sequenceKeyPad.ShowDialog();

                TxtSequence.Text = sequenceKeyPad.GetValue();
            }
        }

        private void BtnObservationKeyBoard_Click(object sender, EventArgs e)
        {
            using (FrmKeyBoard observationKeyboard = new FrmKeyBoard(InputFromOption.OBSERVATION))
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