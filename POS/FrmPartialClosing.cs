using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmPartialClosing : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public IEnumerable<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        EmissionPoint emissionPoint = new EmissionPoint();
        IEnumerable<SP_ClosingCashierDenominations_Consult_Result> denominations;
        IEnumerable<SP_ClosingCashierPartial_Consult_Result> partials;
        decimal cashAmount = 0;

        public FrmPartialClosing()
        {
            InitializeComponent();
        }

        #region Functions
        private void CalculatePayment()
        {
            decimal cash = CalculateDenominations();
            LblTotalCashier.Text = cash.ToString();
        }

        private void LoadGridInformation()
        {
            try
            {
                ClosingCashierRepository closing = new ClosingCashierRepository(Program.customConnectionString);
                denominations = closing.GetDenominations();
                partials = closing.GetPartialClosings(emissionPoint, loginInformation);

                if (partials?.Count() > 0)
                {
                    int count;
                    try
                    {
                        count = (from pa in partials where pa.ClosingCashierId == 0 select pa.CashAmount).Count();
                    }
                    catch
                    {
                        count = 0;
                    }

                    if (count >= 0)
                    {
                        cashAmount = (decimal)(from pa in partials select pa.CashAmount).FirstOrDefault();
                    }
                    else
                    {
                        cashAmount = (decimal)(from pa in partials where pa.ClosingCashierId == 0 select pa.CashAmount).FirstOrDefault();
                    }

                    partials = (from pa in partials where pa.CashierAmount != 0 select pa).ToList();

                    decimal totalPartial = 0;
                    foreach (SP_ClosingCashierPartial_Consult_Result item in partials)
                    {
                        totalPartial += item.CashierAmount;
                    }

                    cashAmount -= totalPartial;
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar informacion.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
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

        private void CheckGridView()
        {
            GrvDenomination.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcDenomination.DataSource = null;
            BindingList<SP_ClosingCashierDenominations_Consult_Result> bindingList = new BindingList<SP_ClosingCashierDenominations_Consult_Result>(denominations.ToList()) { AllowNew = false };
            GrcDenomination.DataSource = bindingList;

            GrvPartialClosing.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPartialClosing.DataSource = null;
            BindingList<SP_ClosingCashierPartial_Consult_Result> bindingList3 = new BindingList<SP_ClosingCashierPartial_Consult_Result>(partials.ToList()) { AllowNew = false };
            GrcPartialClosing.DataSource = bindingList3;
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

                if (emissionPoint == null)
                {
                    functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                    return false;
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);

                return false;
            }

            return true;
        }

        private void LoadPartialClosingReason()
        {
            try
            {
                IEnumerable<CancelReason> cancelReasons = new CancelReasonRepository(Program.customConnectionString).ConsultReasons(CancelReasonType.PARTIAL_CLOSING);

                if (cancelReasons?.Count() > 0)
                {
                    foreach (CancelReason reason in cancelReasons)
                    {
                        CmbMotive.Properties.Items.Add(new ImageComboBoxItem { Value = reason.ReasonId, Description = reason.Name });
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar motivos de cierre.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }
        #endregion

        #region Keypad Buttons
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters,
                Visible = true
            };
            Close();
        }




        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotalCashier.Text) <= 0)
            {
                functions.ShowMessage("El valor a retirar debe ser mayor a 0", MessageType.WARNING);
                return;
            }

            if (decimal.Parse(LblTotalCashier.Text) > cashAmount)
            {
                functions.ShowMessage("No puede retirar un valor mayor a la venta", MessageType.WARNING);
                return;
            }

            if (CmbMotive.SelectedItem == null)
            {
                functions.ShowMessage("Debe seleccionar un motivo de cierre parcial", MessageType.WARNING);
                return;
            }

            if (TxtAccountingCode.Text == string.Empty)
            {
                functions.ShowMessage("El campo Codigo Contable no puede estar vacio", MessageType.WARNING);
                return;
            }

            bool hasDuplicateAccountingCode = new ClosingCashierRepository(Program.customConnectionString).ValidateDuplicateAccountingCode(emissionPoint.LocationId, TxtAccountingCode.Text);
            if (hasDuplicateAccountingCode)
            {
                functions.ShowMessage("El codigo contable ya ha sido registrada previamente.", MessageType.WARNING);
                return;
            }


            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth())
            {
                XElement closingXml = new XElement("ClosingCashier");

                XElement closingCashierTableXml = new XElement("ClosingCashierTable");
                ClosingCashierTable cashierTable = new ClosingCashierTable()
                {
                    LocationId = emissionPoint.LocationId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    UserId = (int)loginInformation.UserId,
                    OpeningAmount = 0,
                    Authorization = functions.SupervisorAuthorization,
                    Status = "A",
                    CreatedBy = (int)loginInformation.UserId,
                    Workstation = emissionPoint.Workstation,
                    ReasonId = int.Parse(CmbMotive.EditValue.ToString()),
                    AccountingCode = TxtAccountingCode.Text
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

                XElement closingCashierLineXml = new XElement("ClosingCashierLine");
                ClosingCashierLine cashierLine = new ClosingCashierLine()
                {

                    PaymModeId = (int)PaymModeEnum.EFECTIVO,
                    CashierAmount = decimal.Parse(LblTotalCashier.Text),
                    SystemAmount = 0
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

                try
                {
                    List<SP_ClosingCashierPartial_Insert_Result> clsClosing = new ClosingCashierRepository(Program.customConnectionString).InsertPartialClosing(closingXml).ToList();

                    if (clsClosing?.Count() > 0)
                    {
                        SP_ClosingCashierPartial_Insert_Result closing = clsClosing[0];
                        if (!(bool)closing.Error)
                        {
                            //if (PrintInvoice((Int64)closing.ClosingCashierId))
                            if (!functions.PrintDocument((long)closing.ClosingCashierId, DocumentType.CLOSINGCASHIER, false))
                            {
                                functions.ShowMessage("El cierre parcial finalizó correctamente, pero no se pudo imprimir factura.", MessageType.WARNING);
                                return;
                            }

                            functions.ShowMessage("Cierre parcial finalizado exitosamente.");

                            FrmMenu frmMenu = new FrmMenu
                            {
                                loginInformation = loginInformation,
                                globalParameters = globalParameters,
                                Visible = true
                            };
                            Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al registrar cierre parcial de caja.",
                                          MessageType.ERROR,
                                          true,
                                          ex.Message);
                }
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

        private void BtnDelete_Click(object sender, EventArgs e) => TxtBarcode.Text = "";

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtBarcode.Text != "")
            {
                SP_ClosingCashierDenominations_Consult_Result row = (SP_ClosingCashierDenominations_Consult_Result)GrvDenomination.GetRow(GrvDenomination.FocusedRowHandle);
                decimal totalAmount = decimal.Parse(TxtBarcode.Text) * row.Value;
                GrvDenomination.UpdateCurrentRow();
                GrvDenomination.SetRowCellValue(GrvDenomination.FocusedRowHandle, GrvDenomination.Columns["TypedAmount"], TxtBarcode.Text);
                GrvDenomination.SetRowCellValue(GrvDenomination.FocusedRowHandle, GrvDenomination.Columns["TotalAmount"], totalAmount);
            }
            CalculatePayment();
            TxtBarcode.Text = "";
        }
        #endregion

        private void FrmPartialClosing_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                LoadGridInformation();
                LoadPartialClosingReason();
                CheckGridView();
                CalculatePayment();

                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                FrmMenu frmMenu = new FrmMenu()
                {
                    loginInformation = loginInformation,
                    globalParameters = globalParameters
                };
                frmMenu.Show();
                Close();

            }
        }

        private void BtnLastClosing_Click(object sender, EventArgs e)
        {
            try
            {
                long lastId = new ClosingCashierRepository(Program.customConnectionString).ConsultLastClosing(emissionPoint, "P");

                if (functions.PrintDocument(lastId, DocumentType.CLOSINGCASHIER))
                {
                    functions.ShowMessage("Cierre parcial impreso.");
                }
                else
                {
                    functions.ShowMessage("Cierre parcial realizado correctamente, pero no se pudo imprimir comprobante.");
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al realizar el cierre parcial.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
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

        private void GrcDenomination_KeyDown(object sender, KeyEventArgs e)
        {
            //11/07/2022
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnAccept_Click(null, null);
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

        private void CmbMotive_KeyDown(object sender, KeyEventArgs e)
        {
            //11/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtBarcode.Focus();
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
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