﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using POS.DLL;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Extensions;
using POS.Classes;

namespace POS
{
    public partial class FrmPaymentCard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public ClsEnums.PaymModeEnum paymModeEnum;
        public int bankId;
        public int creditCardId;
        public string authorization;
        public bool processResponse;

        public FrmPaymentCard()
        {
            InitializeComponent();
        }

        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CREDITCARD_AUTHORIZATION;
            keyPad.ShowDialog();
            TxtAuthorization.Text = keyPad.creditCardAuthorization;
        }            
        
        private void FrmPaymentCard_Load(object sender, EventArgs e)
        {
            LoadBanks();
        }

        private void LoadBanks()
        {
            try
            {
                var db = new DLL.POSEntities();
                var banks = from ba in db.Bank
                            where ba.Status == "A"
                            select ba;

                foreach (var item in banks.ToList())
                {
                    CmbCardBank.Properties.Items.Add(new ImageComboBoxItem { Value = item.BankId, Description = item.Name });
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Bancos."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }

        }

        private void CmbCardBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCardBrand.Properties.Items.Clear();
            LoadBrands(int.Parse(CmbCardBank.EditValue.ToString()));
        }

        private void LoadBrands(int _BankId)
        {
            var db = new DLL.POSEntities();

            if (CmbCardType.SelectedItem != null)
            {
                try
                {
                    if (CmbCardType.SelectedItem.ToString() == "DEBITO")
                    {
                        paymModeEnum = ClsEnums.PaymModeEnum.DEBITO_BANCARIO;

                        var brands = from cre in db.CreditCard
                                     join ban in db.BankCreditCard
                                     on cre.CreditCardId equals ban.CreditCardId
                                     where cre.Status == "A"
                                     && ban.BankId == _BankId
                                     && cre.IsDebit == true
                                     select cre;

                        foreach (var item in brands.ToList())
                        {
                            CmbCardBrand.Properties.Items.Add(new ImageComboBoxItem { Value = item.CreditCardId, Description = item.Name });
                        }
                    }
                    else
                    {
                        paymModeEnum = ClsEnums.PaymModeEnum.TARJETA_CREDITO;

                        var brands = from cre in db.CreditCard
                                     join ban in db.BankCreditCard
                                     on cre.CreditCardId equals ban.CreditCardId
                                     where cre.Status == "A"
                                     && ban.BankId == _BankId
                                     && cre.IsCredit == true
                                     select cre;

                        foreach (var item in brands.ToList())
                        {
                            CmbCardBrand.Properties.Items.Add(new ImageComboBoxItem { Value = item.CreditCardId, Description = item.Name });
                        }
                    }
                }
                catch(Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar lista de Marcas de Tarjeta."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (CmbCardType.SelectedItem != null && CmbCardBank.EditValue != null 
                && CmbCardBrand.EditValue != null && TxtAuthorization.Text != "")
            {
                bankId = int.Parse(CmbCardBank.EditValue.ToString());
                creditCardId = int.Parse(CmbCardBrand.EditValue.ToString());
                authorization = TxtAuthorization.Text;

                processResponse = true;
            }
            else
            {
                
                functions.ShowMessage("Debe llenar todos los campos", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void CmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCardBank.Properties.Items.Clear();
            CmbCardBrand.Properties.Items.Clear();
            LoadBanks();
        }
    }
}