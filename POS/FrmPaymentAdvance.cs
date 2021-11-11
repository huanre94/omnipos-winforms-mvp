using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using POS.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentAdvance : DevExpress.XtraEditors.XtraForm
    {
        public Customer currentCustomer;
        public decimal advanceAmount;
        //public List selectedAdvances;


        public FrmPaymentAdvance()
        {
            InitializeComponent();
        }

        private void CheckGridView()
        {
            //GrcPayment.DataSource = null;
            //GrvPayment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            //BindingList<> bindingList = new BindingList<>();

            //GrcPayment.DataSource = bindingList;
        }
    }
}