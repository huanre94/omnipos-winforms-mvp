﻿using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmInvoiceCancel : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        EmissionPoint emissionPoint;

        public FrmInvoiceCancel(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
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
            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != string.Empty)
            {
                try
                {
                    emissionPoint = new ClsGeneral().GetEmissionPointByIP(addressIP, CadenaC);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
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
                LblEstablishment.Text = emissionPoint.Establishment;
                TxtEmissionPoint.Text = emissionPoint.Emission;
                TxtEmissionPoint.Enabled = false;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                TxtEmissionPoint.Enabled = true;
            }

            return response;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (long.Parse(LblInvoiceId.Text) <= 0)
            {
                functions.ShowMessage("Debe seleccionar una factura valida", ClsEnums.MessageType.WARNING);
            }
            else
            {
                functions.emissionPoint = emissionPoint;
                if (functions.RequestSupervisorAuth(true, (int)ClsEnums.CancelReasonType.ITEM_CANCEL, CadenaC))
                {
                    SalesLog salesLog = new SalesLog
                    {
                        CustomerId = 1,
                        EmissionPointId = emissionPoint.EmissionPointId,
                        LocationId = emissionPoint.LocationId,
                        InvoiceNumber = int.Parse(TxtSequence.Text),
                        XmlLog = string.Empty,
                        ReasonId = functions.motiveId,
                        LogTypeId = (int)ClsEnums.LogType.ANULAR_FACTURA,
                        Authorization = functions.supervisorAuthorization,
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };

                    InvoiceTable invoiceTable = null;
                    try
                    {
                        invoiceTable = new ClsInvoiceTrans().ConsultInvoice(int.Parse(LblInvoiceId.Text), CadenaC);
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un problema al consultar documento.", ClsEnums.MessageType.ERROR, true, ex.Message);
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
                        invoiceCancel = new ClsInvoiceTrans().CancelInvoice(salesLog, invoiceTable, CadenaC);
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un problema al cargar venta anulada."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message);
                    }

                    if (invoiceCancel)
                    {
                        functions.ShowMessage("Factura anulada correctamente.", ClsEnums.MessageType.INFO);
                        ClearInvoice();
                    }
                    else
                    {
                        functions.ShowMessage("Hubo un error al anular la transaccion, por favor vuelva a intentar", ClsEnums.MessageType.ERROR);
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
                functions.ShowMessage("Punto de emision de factura no puede estar vacia", ClsEnums.MessageType.WARNING);
            }
            else if (TxtSequence.Text == string.Empty)
            {
                functions.ShowMessage("Secuencia de factura no puede estar vacia", ClsEnums.MessageType.WARNING);
            }
            else
            {

                try
                {
                    SP_InvoiceCancel_Consult_Result response = new ClsInvoiceTrans().ConsultInvoiceStatus(emissionPoint, int.Parse(TxtSequence.Text), CadenaC);

                    if (response != null)
                    {

                        if (response.TransferStatusId == (int)ClsEnums.TransferStatus.PENDING_MIGRATE)
                        {
                            functions.ShowMessage("La factura aun no ha sido migrada a ERP.", ClsEnums.MessageType.WARNING);
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
                            functions.ShowMessage("La factura ya se encuentra anulada.", ClsEnums.MessageType.WARNING);
                        }
                    }
                    else
                    {
                        functions.ShowMessage("No existe factura con la secuencia digitada.", ClsEnums.MessageType.WARNING);
                        ClearInvoice();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar venta anulada."
                                                , ClsEnums.MessageType.ERROR
                                                , true
                                                , ex.InnerException.Message);
                }
            }
        }

        private void BtnEmissionPointKeyPad_Click(object sender, EventArgs e)
        {
            using (var emissionPointKeypad = new FrmKeyPad(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.EMISSIONPOINT_NUMBER
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
            using (FrmKeyPad sequenceKeyPad = new FrmKeyPad(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.INVOICE_NUMBER
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
            using (FrmKeyBoard observationKeyboard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.OBSERVATION
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
                    this.Close();
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
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}