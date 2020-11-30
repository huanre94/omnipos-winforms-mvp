using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmClosingCashier : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;
        List<SP_ClosingCashierDenominations_Consult_Result> denominations;
        List<SP_ClosingCashierPartial_Consult_Result> partials;
        List<SP_ClosingCashierPayment_Consult_Result> payments;
        XElement closingXml = new XElement("ClosingCashier");
        GridView selectedGrv;
        decimal totalHideCash = 0;

        public FrmClosingCashier()
        {
            InitializeComponent();
        }

        private void FrmClosingCashier_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                LoadGridInformation();
                CheckGridView();
                CalculatePayment();

                //functions.AxOPOSScanner = AxOPOSScanner;
                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                FrmMenu frmMenu = new FrmMenu();
                frmMenu.loginInformation = loginInformation;
                frmMenu.globalParameters = globalParameters;
                frmMenu.Visible = true;
                Close();
            }
        }

        #region Functions
        private decimal CalculatePartials()
        {
            decimal totalPartials = 0;
            for (int i = 0; i < GrvPartialClosing.DataRowCount; i++)
            {
                totalPartials += ((decimal)GrvPartialClosing.GetRowCellValue(i, "CashierAmount"));
            }

            return totalPartials;
        }
        private decimal CalculateDenominations()
        {
            decimal totalDenominations = 0;
            for (int i = 0; i < GrvDenomination.DataRowCount; i++)
            {
                totalDenominations += ((decimal)GrvDenomination.GetRowCellValue(i, "TotalAmount"));
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
            int cashPaymentId = (int)ClsEnums.PaymModeEnum.EFECTIVO;

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
                ClsClosingTrans closing = new ClsClosingTrans();
                denominations = closing.GetDenominations();
                partials = closing.GetPartialClosings(emissionPoint, loginInformation);
                partials = (from pa in partials where pa.CashierAmount != 0 select pa).ToList();
                payments = closing.GetClosingPayments(emissionPoint, loginInformation);


                List<SP_ClosingCashierPayment_Consult_Result> newList = new List<SP_ClosingCashierPayment_Consult_Result>();
                foreach (SP_ClosingCashierPayment_Consult_Result item in payments)
                {
                    if (item.PaymModeId == (int)ClsEnums.PaymModeEnum.EFECTIVO)
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
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
            }

            if (payments.Count == 0)
            {
                functions.ShowMessage("No hay metodos de pago registrados.", ClsEnums.MessageType.WARNING);
            }
        }

        private void CheckGridView()
        {
            GrvDenomination.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcDenomination.DataSource = null;
            BindingList<SP_ClosingCashierDenominations_Consult_Result> bindingList = new BindingList<SP_ClosingCashierDenominations_Consult_Result>(denominations);
            bindingList.AllowNew = false;
            GrcDenomination.DataSource = bindingList;

            GrvPayment.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPayment.DataSource = null;
            BindingList<SP_ClosingCashierPayment_Consult_Result> bindingList2 = new BindingList<SP_ClosingCashierPayment_Consult_Result>(payments);
            bindingList.AllowNew = false;
            GrcPayment.DataSource = bindingList2;

            GrvPartialClosing.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPartialClosing.DataSource = null;
            BindingList<SP_ClosingCashierPartial_Consult_Result> bindingList3 = new BindingList<SP_ClosingCashierPartial_Consult_Result>(partials);
            bindingList.AllowNew = false;
            GrcPartialClosing.DataSource = bindingList3;
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

                    if (emissionPoint != null)
                    {
                        response = true;
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                    }
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

            return response;
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
            GlobalParameter parameter = new ClsGeneral().GetParameterByName("MaxDifferenceClosingCashierValue");

            if (payments.Count == 0)
            {
                functions.ShowMessage("No hay metodos de pago registrados.", ClsEnums.MessageType.WARNING);
            } else
            {
                if (Math.Abs(decimal.Parse(LblDifference.Text)) <= decimal.Parse(parameter.Value))
                {
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

                        foreach (var prop in properties)
                        {
                            var name = prop.Name;
                            var value = prop.GetValue(cashierTable);

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

                            foreach (var prop in properties)
                            {
                                var name = prop.Name;
                                var value = prop.GetValue(cashierMoney);

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

                            foreach (var prop in properties)
                            {
                                var name = prop.Name;
                                var value = prop.GetValue(cashierLine);

                                if (value == null)
                                {
                                    value = "";
                                }

                                closingCashierLineXml.Add(new XElement(name, value));
                            }
                            closingXml.Add(closingCashierLineXml);
                        }

                        List<SP_ClosingCashier_Insert_Result> clsClosing = new ClsClosingTrans().InsertFullClosing(closingXml);

                        if (clsClosing != null)
                        {
                            if (clsClosing.Count > 0)
                            {
                                SP_ClosingCashier_Insert_Result closing = clsClosing[0];
                                if (!(bool)closing.Error)
                                {
                                    //if (PrintInvoice((Int64)closing.ClosingCashierId))
                                    if (functions.PrintDocument((Int64)closing.ClosingCashierId, ClsEnums.DocumentType.CLOSINGCASHIER))
                                    {
                                        functions.ShowMessage("Cierre de caja finalizado exitosamente.");
                                    }
                                    else
                                    {
                                        functions.ShowMessage("El cierre de caja finalizó correctamente, pero no se pudo imprimir factura.", ClsEnums.MessageType.WARNING);
                                    }

                                    FrmMenu frmMenu = new FrmMenu();
                                    frmMenu.loginInformation = loginInformation;
                                    frmMenu.globalParameters = globalParameters;
                                    frmMenu.Visible = true;
                                    Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    functions.ShowMessage("El cierre supera el margen maximo permitido", ClsEnums.MessageType.ERROR);
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

        //private bool PrintInvoice(Int64 _invoiceId)
        //{
        //    ClsClosingTrans clsInvoiceTrans = new ClsClosingTrans();
        //    List<SP_ClosingCashierTicket_Consult_Result> invoiceTicket;
        //    bool response = false;
        //    string bodyText = "";

        //    try
        //    {
        //        invoiceTicket = clsInvoiceTrans.GetClosingTicket(_invoiceId);

        //        if (invoiceTicket != null)
        //        {
        //            if (invoiceTicket.Count > 0)
        //            {

        //                foreach (var line in invoiceTicket)
        //                {
        //                    bodyText += line.BodyText + Environment.NewLine;
        //                }

        //                bool PrinterDocumentOk = functions.ProcessDocumentToPrint(bodyText);

        //                if (PrinterDocumentOk == true)
        //                {
        //                    response = true;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        functions.ShowMessage(
        //                                "Ha ocurrido un problema al imprimir la factura."
        //                                , ClsEnums.MessageType.ERROR
        //                                , true
        //                                , ex.Message
        //                            );
        //    }

        //    return response;
        //}

        private void BtnLastClosing_Click(object sender, EventArgs e)
        {
            Int64 lastId = new ClsClosingTrans().ConsultLastClosing(emissionPoint, "F");
            //if (PrintInvoice(lastId))
            if (functions.PrintDocument(lastId, ClsEnums.DocumentType.CLOSINGCASHIER))
            {
                functions.ShowMessage("Ok.");
            }
        }
    }
}