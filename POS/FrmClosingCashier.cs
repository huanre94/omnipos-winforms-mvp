using DevExpress.XtraGrid.Views.Grid;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
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
    public partial class FrmClosingCashier : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public IEnumerable<GlobalParameter> globalParameters;
        private IEnumerable<SP_ClosingCashierDenominations_Consult_Result> denominations;
        private IEnumerable<SP_ClosingCashierPartial_Consult_Result> partials;
        private IEnumerable<SP_ClosingCashierPayment_Consult_Result> payments;
        private GridView selectedGrv;
        private decimal totalHideCash = 0;
        string TipoCierre;

        public FrmClosingCashier(string TipoCierre = "")
        {
            //Se incrementa un parámetro para saber si es cierre Total T o si es Arquedo de Caja A'
            InitializeComponent();
            this.TipoCierre = TipoCierre;
        }


        private void FrmClosingCashier_Load(object sender, EventArgs e)
        {
            //Indica el tipo de cierre para mostrar texto informativo y parametro para SP
            lblTipoCierre.Text = TipoCierre == "F" ? "Cierre Total" : "Arqueo de Caja";

            if (!GetEmissionPointInformation())
            {
                FrmMenu frmMenu = new FrmMenu()
                {
                    loginInformation = loginInformation,
                    globalParameters = globalParameters,
                    Visible = true
                };
                Close();
                return;
            }

            LoadGridInformation();
            CheckGridView();
            CalculatePayment();

            functions.PrinterName = emissionPoint.PrinterName;
        }

        #region Functions
        private decimal CalculatePartials()
        {
            decimal totalPartials = 0;
            for (int i = 0; i < GrvPartialClosing.DataRowCount; i++)
            {
                totalPartials += (decimal)GrvPartialClosing.GetRowCellValue(i, "CashierAmount");
            }

            return totalPartials;
        }
        private decimal CalculateDenominations()
        {
            decimal totalDenominations = 0;
            for (int i = 0; i < GrvDenomination.DataRowCount; i++)
            {
                totalDenominations += (decimal)GrvDenomination.GetRowCellValue(i, "TotalAmount");
            }

            return totalDenominations;
        }


        private void CalculatePayment()
        {
            decimal cash = CalculateDenominations();
            decimal partials = CalculatePartials();
            decimal totalCash = cash + partials;
            decimal totalSystem = 0;
            decimal totalCashier = 0;
            int cashPaymentId = (int)PaymModeEnum.EFECTIVO;

            for (int i = 0; i < GrvPayment.DataRowCount; i++)
            {
                SP_ClosingCashierPayment_Consult_Result row = (SP_ClosingCashierPayment_Consult_Result)GrvPayment.GetRow(i);
                if (row.PaymModeId == cashPaymentId)
                {
                    GrvPayment.UpdateCurrentRow();
                    GrvPayment.SetRowCellValue(i, GrvPayment.Columns["CashierAmount"], totalCash);
                }

                totalSystem += (decimal)row.Amount;
                totalCashier += (decimal)row.CashierAmount;
            }

            decimal difference = totalSystem + totalHideCash - totalCashier;
            LblDifference.Text = difference.ToString();
            LblTotalCashier.Text = totalCashier.ToString();
        }

        private void LoadGridInformation()
        {
            try
            {
                ClsClosingTrans closing = new ClsClosingTrans(Program.customConnectionString);
                denominations = closing.GetDenominations();
                partials = closing.GetPartialClosings(emissionPoint, loginInformation);
                partials = partials.Where(pa => pa.CashierAmount != 0).ToList();
                payments = closing.GetClosingPayments(emissionPoint, loginInformation);


                List<SP_ClosingCashierPayment_Consult_Result> newList = new List<SP_ClosingCashierPayment_Consult_Result>();
                foreach (SP_ClosingCashierPayment_Consult_Result item in payments)
                {
                    if (item.PaymModeId == (int)PaymModeEnum.EFECTIVO)
                    {
                        totalHideCash = (decimal)item.Amount;
                        item.Amount = 0;
                    }
                    newList.Add(item);
                }
                payments = newList;
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                            "Ocurrio un problema al cargar informacion."
                                            , MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
            }

            if (payments.Count() == 0)
            {
                functions.ShowMessage("No hay metodos de pago registrados.", MessageType.WARNING);
            }
        }

        private void CheckGridView()
        {
            GrvDenomination.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcDenomination.DataSource = null;
            BindingList<SP_ClosingCashierDenominations_Consult_Result> bindingList = new BindingList<SP_ClosingCashierDenominations_Consult_Result>(denominations.ToList())
            {
                AllowNew = false
            };
            GrcDenomination.DataSource = bindingList;

            GrvPayment.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPayment.DataSource = null;
            BindingList<SP_ClosingCashierPayment_Consult_Result> bindingList2 = new BindingList<SP_ClosingCashierPayment_Consult_Result>(payments.ToList())
            {
                AllowNew = false
            };
            GrcPayment.DataSource = bindingList2;

            GrvPartialClosing.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPartialClosing.DataSource = null;
            BindingList<SP_ClosingCashierPartial_Consult_Result> bindingList3 = new BindingList<SP_ClosingCashierPartial_Consult_Result>(partials.ToList())
            {
                AllowNew = false
            };
            GrcPartialClosing.DataSource = bindingList3;
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP == "")
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return true;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);

                if (emissionPoint == null)
                {
                    functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
                return false;
            }

        }
        #endregion

        #region Keypad Buttons
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.loginInformation = loginInformation;
            frmMenu.globalParameters = globalParameters;
            frmMenu.Visible = true;
            Close();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (payments.Count() == 0)
            {
                functions.ShowMessage("No hay metodos de pago registrados.", MessageType.WARNING);
                return;
            }

            XElement closingXml = new XElement("ClosingCashier");

            decimal maxDifferenceClosingValue = decimal.Parse(new ClsGeneral(Program.customConnectionString).GetParameterByName("MaxDifferenceClosingCashierValue").Value);
            if (Math.Abs(decimal.Parse(LblDifference.Text)) > maxDifferenceClosingValue)
            {
                functions.ShowMessage("El cierre supera el margen maximo permitido", MessageType.ERROR);
                return;
            }

            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth())
            {
                XElement closingCashierTableXml = new XElement("ClosingCashierTable");
                ClosingCashierTable cashierTable = new ClosingCashierTable()
                {
                    LocationId = emissionPoint.LocationId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    UserId = (int)loginInformation.UserId,
                    OpeningAmount = 0,
                    Authorization = functions.supervisorAuthorization,
                    Status = "A",
                    CreatedBy = (int)loginInformation.UserId,
                    Workstation = emissionPoint.Workstation
                };

                Type type = cashierTable.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(cashierTable);

                    if (value == null)
                    {
                        value = "";
                    }

                    closingCashierTableXml.Add(new XElement(name, value));
                }

                closingXml.Add(closingCashierTableXml);


                for (int i = 0; i < GrvDenomination.DataRowCount; i++)
                {
                    SP_ClosingCashierDenominations_Consult_Result row = (SP_ClosingCashierDenominations_Consult_Result)GrvDenomination.GetRow(i);

                    if ((int)row.TypedAmount == 0)
                    {
                        continue;
                    }

                    XElement closingCashierMoneyXml = new XElement("ClosingCashierMoney");
                    ClosingCashierMoney cashierMoney = new ClosingCashierMoney()
                    {
                        Sequence = 0,
                        CurrencyDenominationId = row.CurrencyDenominationId,
                        Quantity = (int)row.TypedAmount
                    };
                    type = cashierMoney.GetType();
                    properties = type.GetProperties();

                    foreach (PropertyInfo prop in properties)
                    {
                        string name = prop.Name;
                        object value = prop.GetValue(cashierMoney);

                        if (value == null)
                        {
                            value = "";
                        }

                        closingCashierMoneyXml.Add(new XElement(name, value));
                    }
                    closingXml.Add(closingCashierMoneyXml);
                }

                for (int i = 0; i < GrvPayment.DataRowCount; i++)
                {
                    SP_ClosingCashierPayment_Consult_Result row = (SP_ClosingCashierPayment_Consult_Result)GrvPayment.GetRow(i);

                    if (row.PaymModeId == 8)
                    {
                        row.Amount = totalHideCash;
                    }

                    XElement closingCashierLineXml = new XElement("ClosingCashierLine");
                    ClosingCashierLine cashierLine = new ClosingCashierLine()
                    {

                        PaymModeId = row.PaymModeId,
                        CashierAmount = (decimal)row.CashierAmount,
                        SystemAmount = (decimal)row.Amount
                    };
                    type = cashierLine.GetType();
                    properties = type.GetProperties();

                    foreach (PropertyInfo prop in properties)
                    {
                        string name = prop.Name;
                        object value = prop.GetValue(cashierLine);

                        if (value == null)
                        {
                            value = "";
                        }

                        closingCashierLineXml.Add(new XElement(name, value));
                    }
                    closingXml.Add(closingCashierLineXml);
                }

                try
                {
                    List<SP_ClosingCashier_Insert_Result> clsClosing = new ClsClosingTrans(Program.customConnectionString).InsertFullClosing(closingXml, TipoCierre).ToList();


                    if (clsClosing?.Count() > 0)
                    {
                        SP_ClosingCashier_Insert_Result closing = clsClosing[0];
                        if ((bool)closing.Error)
                        {
                            functions.ShowMessage("No se ha podido realizar cierre de caja.",
                                                  MessageType.WARNING,
                                                  true,
                                                  closing.TextError);
                            return;
                        }

                        if (!functions.PrintDocument((long)closing.ClosingCashierId, DocumentType.CLOSINGCASHIER))
                        {
                            functions.ShowMessage("El cierre de caja finalizó correctamente, pero no se pudo imprimir documento.", MessageType.WARNING);
                        }
                        else
                        {
                            functions.ShowMessage("Cierre de caja finalizado exitosamente.");
                        }

                        FrmMenu frmMenu = new FrmMenu();
                        frmMenu.loginInformation = loginInformation;
                        frmMenu.globalParameters = globalParameters;
                        frmMenu.Visible = true;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al registrar cierre de caja.",
                                          MessageType.ERROR,
                                          true,
                                          ex.Message);
                }
            }
        }

        private void GrvDenomination_RowClick(object sender, RowClickEventArgs e)
        {
            selectedGrv = GrvDenomination;
            BtnDot.Enabled = false;
        }

        private void GrvPayment_RowClick(object sender, RowClickEventArgs e)
        {
            selectedGrv = GrvPayment;
            BtnDot.Enabled = true;
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!TxtBarcode.Text.Contains("."))
            {
                TxtBarcode.Text += ".";
            }
        }
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = "";
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtBarcode.Text != "")
            {
                //selectedGrv = GrvDenomination;//11/07/2022

                if (selectedGrv != null)
                {
                    int rowSelected = selectedGrv.FocusedRowHandle;
                    if (selectedGrv == GrvPayment)
                    {
                        selectedGrv.UpdateCurrentRow();
                        selectedGrv.SetRowCellValue(selectedGrv.FocusedRowHandle, selectedGrv.Columns["CashierAmount"], TxtBarcode.Text);
                    }
                    if (selectedGrv == GrvDenomination)
                    {
                        SP_ClosingCashierDenominations_Consult_Result row = (SP_ClosingCashierDenominations_Consult_Result)selectedGrv.GetRow(rowSelected);
                        decimal totalAmount = decimal.Parse(TxtBarcode.Text) * row.Value;
                        //selectedGrv.FocusedRowHandle = rowSelected;
                        selectedGrv.UpdateCurrentRow();
                        selectedGrv.SetRowCellValue(selectedGrv.FocusedRowHandle, selectedGrv.Columns["TypedAmount"], TxtBarcode.Text);
                        selectedGrv.SetRowCellValue(selectedGrv.FocusedRowHandle, selectedGrv.Columns["TotalAmount"], totalAmount);
                    }
                }
            }
            CalculatePayment();
            TxtBarcode.Text = "";
        }
        #endregion

        private void BtnLastClosing_Click(object sender, EventArgs e)
        {
            //long lastId = new ClsClosingTrans().ConsultLastClosing(emissionPoint, "F" );   // 04/01/2023
            long lastId = new ClsClosingTrans(Program.customConnectionString).ConsultLastClosing(emissionPoint, TipoCierre);

            if (functions.PrintDocument(lastId, DocumentType.CLOSINGCASHIER, false))
            {
                functions.ShowMessage("Cierre total impreso.");
            }
        }

        private void BtnCancelClosing_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = InputFromOption.CLOSING_CASHIER_ID
            };
            keyPad.ShowDialog();



        }

        private void GrcDenomination_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //11/07/2022
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F5:
                    BtnCancelClosing_Click(null, null);
                    break;
                case Keys.F7:
                    BtnLastClosing_Click(null, null);
                    break;
                case Keys.F12:
                    TxtBarcode.Focus();
                    break;
                default:
                    break;
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            //11/07/2022            
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnEnter_Click(null, null);
                    GrcDenomination.Focus();
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F5:
                    BtnCancelClosing_Click(null, null);
                    break;
                case Keys.F7:
                    BtnLastClosing_Click(null, null);
                    break;
                case Keys.F12:
                    GrcDenomination.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}