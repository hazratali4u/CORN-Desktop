using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class frmCustomer : Form
    {
        private frmPOS objfrmPOS;

        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(frmPOS objfrmPOS) : this()
        {
            this.objfrmPOS = objfrmPOS;
        }

        #region Load Functions
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadVolumeType();
            Grid_Customer.BackgroundColor = Color.White;
            btnAddNew_Click(null, null);
            txtCustomerName.Focus();
        }

        private void LoadCustomer()
        {
            try
            {
                //Grid_Customer.DataSource = null;
                //Grid_Customer.Rows.Clear();
                //CustomerDataController _mController = new CustomerDataController();
                //DataTable dt = _mController.SelectAllCustomer(Convert.ToInt32(cboxDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
                //Grid_Customer.DataSource = dt;
                //ArrangeCustomerGrid();
            }
            catch (Exception)
            {
            }
        }
        public void ArrangeCustomerGrid()
        {
            try
            {
                Grid_Customer.Columns.Remove("Edit");
                Grid_Customer.Columns.Remove("Select");
                Grid_Customer.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }
            // hide extra columns
            Grid_Customer.Columns["CUSTOMER_ID"].Visible = false;
            Grid_Customer.Columns["DISTRIBUTOR_ID"].Visible = false;
            Grid_Customer.Columns["CONTACT_PERSON"].Visible = false;
            Grid_Customer.Columns["EMAIL_ADDRESS"].Visible = false;
            Grid_Customer.Columns["IS_GST_REGISTERED"].Visible = false;
            Grid_Customer.Columns["GST_NUMBER"].Visible = false;
            Grid_Customer.Columns["REGDATE"].Visible = false;
            Grid_Customer.Columns["TIME_STAMP"].Visible = false;
            Grid_Customer.Columns["LASTUPDATE_DATE"].Visible = false;
            Grid_Customer.Columns["TOWN_ID"].Visible = false;
            Grid_Customer.Columns["AREA_ID"].Visible = false;
            Grid_Customer.Columns["ROUTE_ID"].Visible = false;
            Grid_Customer.Columns["CUSTOMER_DETAIL"].Visible = false;
            Grid_Customer.Columns["CUSTOMER_ADDRESS"].Visible = false;
            Grid_Customer.Columns["CNIC"].Visible = false;
            Grid_Customer.Columns["IS_ACTIVE"].Visible = false;
            Grid_Customer.Columns["CUSTOMER_CODE"].Visible = false;
            Grid_Customer.Columns["Opening"].Visible = false;
            Grid_Customer.Columns["DEBIT_CREDIT"].Visible = false;
            Grid_Customer.Columns["MAX_DAY_CLOSE"].Visible = false;
            Grid_Customer.Columns["SALE_INVOICE_ID"].Visible = false;
            // rename columns headrs
            Grid_Customer.Columns["CUSTOMER_NAME"].HeaderText = "Name";
            Grid_Customer.Columns["CONTACT_NUMBER"].HeaderText = "Contact Number";
            Grid_Customer.Columns["IS_ACTIVE"].HeaderText = "Status";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            Grid_Customer.Columns.Add(btnEdit);
            // Add Select Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            // checkColumn.HeaderCell = dgvColumnHeader;
            checkColumn.ReadOnly = false;
            Grid_Customer.Columns.Add(checkColumn);
            Grid_Customer.Columns["Select"].DisplayIndex = 0;
            checkColumn.HeaderText = "";

            // Set Columns Width
            Grid_Customer.Columns["Select"].Width = 50;
            Grid_Customer.Columns["CUSTOMER_NAME"].Width = 150;
            Grid_Customer.Columns["CONTACT_NUMBER"].Width = 120;
            Grid_Customer.Columns["Address"].Width = 570;
            Grid_Customer.Columns["Edit"].Width = 50;
            Grid_Customer.Columns["Contact_Number"].Width = 120;

            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "IS_Active";
            Grid_Customer.Columns.Add(activeClm);
            Grid_Customer.Columns["activeClm"].DisplayIndex = Grid_Customer.Columns["Edit"].DisplayIndex - 1;
            Grid_Customer.Columns["activeClm"].Width = 100;
            ActiveInactiveText();
        }
        public void ActiveInactiveText()
        {
            int _rows = Grid_Customer.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(Grid_Customer.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    Grid_Customer.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    Grid_Customer.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
            Grid_Customer.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            DrpDistributor.DataSource = dt;
            DrpDistributor.ValueMember = "DISTRIBUTOR_ID";
            DrpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.SelectedIndexChanged -= new EventHandler(cboxDistributor_SelectedIndexChanged);
            cboxDistributor.DataSource = dt;
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.SelectedIndexChanged += new EventHandler(cboxDistributor_SelectedIndexChanged);
            cboxDistributor_SelectedIndexChanged(null, null);
        }

        private void LoadVolumeType()
        {
            SLASHCodesController mController = new SLASHCodesController();
            DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, bool.Parse("True"));
            DrpVolumeClass.ValueMember = "REF_ID";
            DrpVolumeClass.DisplayMember = "SLASH_DESC";
            DrpVolumeClass.DataSource = dt;
            DrpVolumeClass.SelectedValue = "88";
        }
        #endregion

        #region Save Customers

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int _opType = 1;
            if (rbtnDebit.Checked)
            {
                _opType = 2;
            }
            if (txtOpeningAmount.TextLength == 0)
            {
                txtOpeningAmount.Text = "0";
            }
            if (txtCustomerName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Must enter Customer Name", "CORN : POS");
                return;
            }

            if (txtAddress.Text.Trim().Length < 1)
            {
                MessageBox.Show("Must enter Address", "CORN : POS");
                return;
            }

            if (txtPhoneNo.Text.Trim().Length < 1)
            {
                MessageBox.Show("Must enter Phone No", "CORN : POS");
                return;
            }

            if (txtPhoneNo.Text.Trim().Length < 1)
            {
                MessageBox.Show("Must enter Phone No", "CORN : POS");
                return;
            }
            string result = "0";
            CustomerDataController mController = new CustomerDataController();
            if (btnSave.Text == "Save")
            {
                SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
                DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("CUSTOMER", "CUSTOMER_ID", int.Parse(DrpDistributor.SelectedValue.ToString()));
                if (dtSettingsTable.Rows.Count > 0)
                {
                    long CustomerId = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                    string StrCode = "";

                    if (CustomerId.ToString().Length == 1)
                    {
                        StrCode = "OT0000" + CustomerId.ToString();
                    }
                    else if (CustomerId.ToString().Length == 2)
                    {
                        StrCode = "OT000" + CustomerId.ToString();
                    }
                    else if (CustomerId.ToString().Length == 3)
                    {
                        StrCode = "OT00" + CustomerId.ToString();
                    }
                    else if (CustomerId.ToString().Length == 4)
                    {
                        StrCode = "OT0" + CustomerId.ToString();
                    }
                    else if (CustomerId.ToString().Length == 5)
                    {
                        StrCode = "OT" + CustomerId.ToString();
                    }
                    int opening = Convert.ToInt32(txtOpeningAmount.Text);
                    result = mController.InsertCustomer(CustomerId, false, chkIsActive.Checked, Constants.IntNullValue, int.Parse(DrpVolumeClass.SelectedValue.ToString()),
                        Constants.IntNullValue, 0, Constants.IntNullValue, Convert.ToInt32(txtOpeningAmount.Text),
                        int.Parse(DrpDistributor.SelectedValue.ToString()), "", "", txtPhoneNo.Text, txtEmailAddress.Text, StrCode, txtCustomerName.Text,
                        txtAddress.Text, txtRegdate.Value, 1, 1, txtCNIC.Text, "", _opType, opening, SessionClass.UserID, SessionClass.CurrentWorkDate);
                    SessionClass.CustomerID = CustomerId;
                    penalNewCustomer.Visible = false;
                    if (result == "1")
                    {
                        frmPOS _pos = Application.OpenForms["frmPOS"] as frmPOS;
                        _pos.LoadCustomerData();
                        ClearAll();
                        _pos.drpCustomer.SelectedValue = SessionClass.CustomerID;
                        this.Close();
                        _pos.txtskuCode.Focus();
                    }
                }
            }
            else
            {
                //============If Day has been closed or after customer is added or Not=========
                int _AreaID = 0;
                if (lblOpenType.Visible == true)
                {
                    _AreaID = 1;
                }
                //=============================================================================
                int _saleInvoiceID = 0;
                try
                {
                    _saleInvoiceID = Convert.ToInt32(lblInvoiceID.Text);
                }
                catch (Exception)
                { }
                int opening = Convert.ToInt32(txtOpeningAmount.Text);
                mController.UpdateCustomer(Convert.ToInt32(lblCustomerID.Text), false, chkIsActive.Checked, Constants.IntNullValue, int.Parse(DrpVolumeClass.SelectedValue.ToString()),
                Constants.IntNullValue, _AreaID, Constants.IntNullValue, Convert.ToInt32(txtOpeningAmount.Text), int.Parse(DrpDistributor.SelectedValue.ToString()), "", "",
                txtPhoneNo.Text, txtEmailAddress.Text, null, txtCustomerName.Text, txtAddress.Text, Constants.DateNullValue, 1, 1, txtCNIC.Text, "", _opType, opening, SessionClass.UserID, SessionClass.CurrentWorkDate, _saleInvoiceID);
                //ClearAll();
            }
            penalNewCustomer.Visible = false;
            LoadCustomer();
        }

        #endregion

        #region Common Functions

        private void ClearAll()
        {
            txtCustomerName.Text = "";
            txtAddress.Text = "n/a";
            txtPhoneNo.Text = "n/a";
            txtSeach.Text = "";
            txtEmailAddress.Text = "n/a";
            txtCNIC.Text = "n/a";
            btnSave.Text = "Save";
            txtCustomerName.Focus();
            //Grid_Customer.DataSource = null;
            //pnlHeading.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSeach.Text.Trim().Length > 0)
            {
                if (DrpDistributor.Items.Count > 0)
                {
                    CustomerDataController mController = new CustomerDataController();
                    DataTable dt = mController.UspSelectCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), null, txtSeach.Text);
                    Grid_Customer.AutoGenerateColumns = false;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(Grid_Customer);
                            row.Cells[0].Value = dr["CUSTOMER_ID"];
                            row.Cells[1].Value = dr["DISTRIBUTOR_ID"];
                            row.Cells[2].Value = dr["PROMOTION_CLASS"];
                            row.Cells[3].Value = dr["REGDATE"];
                            row.Cells[4].Value = dr["CNIC"];
                            row.Cells[5].Value = dr["CUSTOMER_CODE"];
                            row.Cells[6].Value = dr["CUSTOMER_NAME"];
                            row.Cells[7].Value = dr["CONTACT_NUMBER"];
                            row.Cells[8].Value = dr["ADDRESS"];
                            row.Cells[9].Value = dr["IS_ACTIVE"];
                            Grid_Customer.Rows.Add(row);
                        }
                        pnlHeading.Visible = true;
                        Grid_Customer.Focus();
                    }
                }
            }
        }

        private void Grid_users_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int RowIndex = Grid_Customer.CurrentCell.RowIndex;
                SessionClass.CustomerID = Convert.ToInt64(Grid_Customer.Rows[RowIndex].Cells[0].Value);
                DrpDistributor.SelectedValue = Grid_Customer.Rows[RowIndex].Cells[1].Value.ToString();
                DrpVolumeClass.SelectedValue = Grid_Customer.Rows[RowIndex].Cells[2].Value.ToString();
                txtRegdate.Text = Grid_Customer.Rows[RowIndex].Cells[3].Value.ToString().Replace("&nbsp;", "");
                txtCNIC.Text = Grid_Customer.Rows[RowIndex].Cells[4].Value.ToString().Replace("&nbsp;", "");
                txtCustomerName.Text = Grid_Customer.Rows[RowIndex].Cells[6].Value.ToString().Replace("amp;", "");
                txtPhoneNo.Text = Grid_Customer.Rows[RowIndex].Cells[7].Value.ToString().Replace("&nbsp;", "");
                txtAddress.Text = Grid_Customer.Rows[RowIndex].Cells[8].Value.ToString().Replace("&nbsp;", "");
                chkIsActive.Checked = bool.Parse(Grid_Customer.Rows[RowIndex].Cells[9].Value.ToString());
                btnSave.Text = "Update";
                txtCustomerName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            penalNewCustomer.Visible = false;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            //penalNewCustomer.Visible = false;
            ClearAll();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            rbtnCredit.Checked = true;
            penalNewCustomer.Visible = true;
            // penalNewCustomer.Location = new Point(90, 90);
            penalNewCustomer.Dock = DockStyle.Fill;
            penalNewCustomer.BringToFront();
            SetControlVisibility(true);
            txtCNIC.Text = "n/a";
            txtAddress.Text = "n/a";
            txtEmailAddress.Text = "n/a";
            txtPhoneNo.Text = "n/a";
        }
        public void SetControlVisibility(bool _status)
        {
            lblOpenAmount.Visible = _status;
            lblOpenType.Visible = _status;
            rbtnCredit.Visible = _status;
            rbtnDebit.Visible = _status;
            txtOpeningAmount.Visible = _status;
        }
        private void Grid_Customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetControlVisibility(true);
            int _rowIndex = Grid_Customer.CurrentCell.RowIndex;
            if (e.ColumnIndex == Grid_Customer.Columns["Edit"].Index)
            {
                txtCustomerName.Text = Grid_Customer.Rows[_rowIndex].Cells["CUSTOMER_NAME"].Value.ToString();
                txtAddress.Text = Grid_Customer.Rows[_rowIndex].Cells["ADDRESS"].Value.ToString();
                txtPhoneNo.Text = Grid_Customer.Rows[_rowIndex].Cells["CONTACT_NUMBER"].Value.ToString();
                txtRegdate.Value = Convert.ToDateTime(Grid_Customer.Rows[_rowIndex].Cells["REGDATE"].Value.ToString());
                txtCNIC.Text = Grid_Customer.Rows[_rowIndex].Cells["CNIC"].Value.ToString();
                txtEmailAddress.Text = Grid_Customer.Rows[_rowIndex].Cells["EMAIL_ADDRESS"].Value.ToString();
                DrpDistributor.SelectedValue = Convert.ToInt32(Grid_Customer.Rows[_rowIndex].Cells["DISTRIBUTOR_ID"].Value.ToString());
                lblCustomerID.Text = Grid_Customer.Rows[_rowIndex].Cells["CUSTOMER_ID"].Value.ToString();
                chkIsActive.Checked = Convert.ToBoolean(Grid_Customer.Rows[_rowIndex].Cells["IS_ACTIVE"].Value.ToString());
                DateTime dayClose = Convert.ToDateTime(Grid_Customer.Rows[_rowIndex].Cells["MAX_DAY_CLOSE"].Value).Date;
                DateTime DocumentDate = Convert.ToDateTime(Grid_Customer.Rows[_rowIndex].Cells["TIME_STAMP"].Value).Date;
                if (dayClose < DocumentDate)
                {
                    if (Convert.ToInt32(Grid_Customer.Rows[_rowIndex].Cells["DEBIT_CREDIT"].Value) == 1)
                    {
                        rbtnCredit.Checked = true;
                    }
                    else
                    {
                        rbtnDebit.Checked = true;
                    }
                    txtOpeningAmount.Text = Math.Round(Convert.ToDecimal(Grid_Customer.Rows[_rowIndex].Cells["Opening"].Value), 0).ToString();
                    lblInvoiceID.Text = Grid_Customer.Rows[_rowIndex].Cells["SALE_INVOICE_ID"].Value.ToString();
                }
                else
                {
                    SetControlVisibility(false);
                }
                btnSave.Text = "Update";
                penalNewCustomer.Visible = true;
                penalNewCustomer.BringToFront();
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            CustomerDataController mController = new CustomerDataController();
            try
            {
                foreach (DataGridViewRow dr in Grid_Customer.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Select"].Value))
                    {
                        if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                        {
                            mController.UpdateCustomer(Convert.ToInt32(dr.Cells["CUSTOMER_ID"].Value), false, false, Constants.IntNullValue, Constants.IntNullValue,
                            Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(dr.Cells["DISTRIBUTOR_ID"].Value), "", "",
                            null, null, null, null, null, Constants.DateNullValue, 1, 1, null, "", Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.DateNullValue, Constants.IntNullValue);
                        }
                        else
                        {
                            mController.UpdateCustomer(Convert.ToInt32(dr.Cells["CUSTOMER_ID"].Value), false, true, Constants.IntNullValue, Constants.IntNullValue,
                            Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(dr.Cells["DISTRIBUTOR_ID"].Value), "", "",
                            null, null, null, null, null, Constants.DateNullValue, 1, 1, null, "", Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.DateNullValue, Constants.IntNullValue);
                        }
                    }
                }
                LoadCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChkAll.Checked = false;
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)Grid_Customer.DataSource).DefaultView.RowFilter = "CUSTOMER_CODE LIKE '%" + txtSeach.Text + "%' OR CUSTOMER_NAME LIKE '%" + txtSeach.Text + "%' OR CONTACT_NUMBER LIKE '%" + txtSeach.Text + "%' OR ADDRESS LIKE '%" + txtSeach.Text + "%' OR EMAIL_ADDRESS LIKE '%" + txtSeach.Text + "%'";
            ActiveInactiveText();
        }
        #endregion

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = Grid_Customer.Rows.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    Grid_Customer.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    Grid_Customer.Rows[i].Cells["Select"].Value = false;
                }
            }
        }

        private void Grid_Customer_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
        }

        private void cboxDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadCustomer();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void frmCustomer_Shown(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
        }
    }
}