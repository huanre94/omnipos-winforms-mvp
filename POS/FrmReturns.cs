using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
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

        public FrmReturns(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP, CadenaC);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
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
                LblEmissionPoint.Text = emissionPoint.Emission;
                functions.PrinterName = emissionPoint.PrinterName;
                LblCashier.Text = loginInformation.UserName;

                GetNewSequenceNumber(emissionPoint.EmissionPointId, emissionPoint.LocationId);
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void GetNewSequenceNumber(int _emissionPointId, int _locationId)
        {
            ClsGeneral clsGeneral = new ClsGeneral();
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = clsGeneral.GetSequenceByEmissionPointId(_emissionPointId, _locationId, (int)ClsEnums.SequenceType.INVOICE, CadenaC);

                if (sequenceTable != null)
                {
                    sequenceNumber = sequenceTable.Sequence;
                    string stringSequence = sequenceNumber.ToString();
                    LblInvoiceNumber.Text = stringSequence.PadLeft(9, '0');
                }
                else
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", ClsEnums.MessageType.WARNING);
                    Close();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al obtener secuencia."
                                        , ClsEnums.MessageType.ERROR
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
                    functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", ClsEnums.MessageType.ERROR);
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