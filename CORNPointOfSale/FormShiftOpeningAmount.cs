using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormShiftOpeningAmount : Form
    {
        DataTable dt;
        Distributor_UserController _duController = new Distributor_UserController();
        ShiftController _SController = new ShiftController();
        RptSaleController rptSaleCtl = new RptSaleController();
        static DataTable dt_new = new DataTable();
        DataTable dtDocumentNo = new DataTable();

        public FormShiftOpeningAmount()
        {
            InitializeComponent();
        }

        private void txtLoginID_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void LoadUser()
        {
            try
            {
                dt = _duController.SelectDistributorUser(47, Constants.IntNullValue, Constants.IntNullValue);
                cboxUser.DataSource = dt;
                cboxUser.DisplayMember = "USER_NAME";
                cboxUser.ValueMember = "USER_ID";
                if (SessionClass.RoleID != 1)
                {
                    cboxUser.Enabled = false;
                    cbDocumentNo.Enabled = false;
                    cboxUser.SelectedValue = SessionClass.UserID;
                }
                else
                {
                    cboxUser.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw;
            }
        }

        private void GetDocumentNo()
        {
            btnSave.Text = "Save";
            txtAmount.Text = string.Empty;
            cbDocumentNo.DataSource = null;
            dt_new.Rows.Clear();
            cbDocumentNo.Items.Clear();
            DateTime MWorkDate = System.DateTime.Now;
            PurchaseController mPurchase = new PurchaseController();
            DataTable dt = _SController.GetOpeningCash(Constants.IntNullValue, Convert.ToInt32(cboxUser.SelectedValue), Constants.IntNullValue, Constants.IntNullValue,SessionClass.CurrentWorkDate);
            dtDocumentNo = dt;
            int _rows = dt.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                var _value = dt.Rows[i].ItemArray[0].ToString();
                dt_new.Rows.Add(dt.Rows[i]["OPENIIN_ID"].ToString(), Convert.ToInt64(_value));
            }
            cbDocumentNo.DataSource = dt_new;
            cbDocumentNo.DisplayMember = "Display";
            cbDocumentNo.ValueMember = "value";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["OPENIIN_ID"].ToString() == cbDocumentNo.SelectedValue.ToString())
                {
                    txtAmount.Text = dr["AMOUNT"].ToString();
                }
                btnSave.Text = "Update";
            }
        }

        public void CreateTableForDocumentNo()
        {
            dt_new.Columns.Add("Display", typeof(string));
            dt_new.Columns.Add("value", typeof(Int64));
        }
        private void FormShiftOpeningAmount_Load(object sender, EventArgs e)
        {
            CreateTableForDocumentNo();
            LoadUser();
            GetDocumentNo();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int shiftID = 0;
            if (txtAmount.TextLength == 0)
            {
                MessageBox.Show(this, "Please Enter Amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtClosedShifts = rptSaleCtl.SelectSales(Constants.IntNullValue, Convert.ToInt32(cboxUser.SelectedValue.ToString()), SessionClass.CurrentWorkDate, Constants.DateNullValue, 7, shiftID);
            if (dtClosedShifts.Rows.Count > 0)
            {
                MessageBox.Show(this, "Shift is Closed of This User.\n You can Enter Shift Opening after day Close", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow[] dr = dt.Select("USER_ID = '"+DataControl.chkNull_Zero(cboxUser.SelectedValue.ToString())+"'");
            if (dr.Length != 0)
            {
                shiftID = Convert.ToInt32(DataControl.chkNull_Zero(dr[0][2].ToString()));
            }
            if (btnSave.Text == "Save")
            {
                bool result = _SController.InsertShiftOpeningAmount(Convert.ToInt32(DataControl.chkNull_Zero(cboxUser.SelectedValue.ToString())), shiftID, Convert.ToInt32(txtAmount.Text), Convert.ToDateTime(SessionClass.CurrentWorkDate));
                if (result)
                {
                    MessageBox.Show(this, "Added Successfully", "Message", MessageBoxButtons.OK);
                    txtAmount.Text = "";
                    GetDocumentNo();
                }
            }
            else
            {
                bool result = _SController.UpdateShiftOpeningAmount(Convert.ToInt32(cbDocumentNo.SelectedValue), Convert.ToInt32(txtAmount.Text));
                if (result)
                {
                    MessageBox.Show(this, "Updated Successfully", "Message", MessageBoxButtons.OK);
                }
            }
        }

        private void cbDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocumentNo.DisplayMember == "Display" && cbDocumentNo.ValueMember == "value")
            {
                
            }
        }

        private void cboxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxUser.DisplayMember == "USER_NAME" && cboxUser.ValueMember == "USER_ID")
            {
                GetDocumentNo();
            }
        }
    }
}