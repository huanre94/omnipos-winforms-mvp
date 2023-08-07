using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmReturns : DevExpress.XtraEditors.XtraForm
    {
        Customer _currentCustomer = new Customer();
        EmissionPoint emissionPoint;
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        ClsFunctions functions = new ClsFunctions();
        long sequenceNumber;

        public FrmReturns()
        {
            InitializeComponent();
        }

        private bool GetEmissionPointInformation()
        {

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
            }

            if (emissionPoint != null)
            {
                response = true;
                LblEstablishment.Text = emissionPoint.Establishment;
                LblEmissionPoint.Text = emissionPoint.Emission;
                functions.PrinterName = emissionPoint.PrinterName;
                LblCashier.Text = loginInformation.UserName;

                GetNewSequenceNumber(emissionPoint.EmissionPointId, emissionPoint.LocationId);
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
            }

            return response;
        }

        private void GetNewSequenceNumber(int _emissionPointId, int _locationId)
        {
            try
            {
                SequenceTable sequenceTable = new ClsGeneral(Program.customConnectionString).GetSequenceByEmissionPointId(_emissionPointId, _locationId, (int)DLL.Enums.SequenceType.INVOICE);

                if (sequenceTable == null)
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", MessageType.WARNING);
                    Close();
                    return;
                }

                sequenceNumber = sequenceTable.Sequence;
                string stringSequence = sequenceNumber.ToString();
                LblInvoiceNumber.Text = stringSequence.PadLeft(9, '0');

            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al obtener secuencia."
                                        , MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void FrmReturns_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {

            }
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (_currentCustomer != null)
            {
                if (_currentCustomer.CustomerId != 1)
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
                    DialogResult = DialogResult.Cancel;
                }
            }

            return response;
        }

        private void TxtObservation_KeyDown(object sender, KeyEventArgs e)
        {
            //11/07/2022
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnObservationKeyBoard.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}