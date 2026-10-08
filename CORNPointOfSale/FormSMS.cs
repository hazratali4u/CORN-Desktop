using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormSMS : Form
    {
        public FormSMS()
        {
            InitializeComponent();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormSMSConfiguration _frmsms = new FormSMSConfiguration();
            _frmsms.ShowDialog();
        }

        private void ChkAllCustomer_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListCustomer.Items.Count;
            if (ChkAllCustomer.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListCustomer.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListCustomer.SetItemChecked(i, false);
                }
            }
        }
        private void LoadCustomer()
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dtCustomer = mController.SelectPrincipalCustomer(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
            ChkListCustomer.DataSource = dtCustomer;
            ChkListCustomer.ValueMember = "CUSTOMER_ID";
            ChkListCustomer.DisplayMember = "CUSTOMER_DETAIL2";
        }

        private void FormSMS_Shown(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void FormSMS_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 430, 200);
            groupPanel2.Location = new Point(points[0], points[1]);
        }
    }
}
