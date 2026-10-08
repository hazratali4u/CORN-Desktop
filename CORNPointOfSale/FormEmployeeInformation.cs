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
using CORNDataAccessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormEmployeeInformation : Office2007Form
    {
        readonly Distributor_UserController _uController = new Distributor_UserController();
        public FormEmployeeInformation()
        {
            InitializeComponent();
        }

        #region Form Controle Events
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridEmployeeInformation.DataSource).DefaultView.RowFilter = "NIC_NO LIKE '%" + txtSearchEmployee.Text + "%' OR USER_CODE LIKE '%" + txtSearchEmployee.Text + "%' OR USER_NAME LIKE '%" + txtSearchEmployee.Text + "%' OR PHONE LIKE '%" + txtSearchEmployee.Text + "%' OR MOBILE LIKE '%" + txtSearchEmployee.Text + "%'  OR ADDRESS1 LIKE '%" + txtSearchEmployee.Text + "%'  OR SLASH_DESC LIKE '%" + txtSearchEmployee.Text + "%'";
            ActiveInactiveText();
        }

        public void RefreshGridView()
        {
            GridEmployeeInformation.Columns.Remove("Edit");
            GridEmployeeInformation.Columns.Remove("Select");
            GridEmployeeInformation.Columns.Remove("activeClm");
            this.LoadGrid();
            ActiveInactiveText();
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            EmployeeInformationProperties._newOrEdit = "New";
            PopUpEmployeeInformation _popFormEmployeeInformation = new PopUpEmployeeInformation();
            _popFormEmployeeInformation.ShowDialog();
        } 
        #endregion

        #region Load Functions
        private void FormEmployeeInformation_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            LoadGrid();
            txtSearchEmployee.Focus();
            GridEmployeeInformation.ColumnHeadersDefaultCellStyle.BackColor = Color.Snow;
            GridEmployeeInformation.EnableHeadersVisualStyles = false;
        }
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, 1);
            cboxDistributor.DataSource = dtDistributor;
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
            //cboxDistributor.SelectedIndex = 0;
        }
        #region Grid View
        public void LoadGrid()
        {
            try
            {
                GridEmployeeInformation.DataSource = null;
                GridEmployeeInformation.Rows.Clear();
                DataTable dt = new DataTable();
                dt = _uController.SelectDistributorUser(Constants.IntNullValue, Convert.ToInt32(cboxDistributor.SelectedValue.ToString()), SessionClass.CompanyID);
                this.GridEmployeeInformation.DataSource = dt;
                ArrangeGrid();
            }
            catch (Exception)
            {
            }
        }
        protected void ArrangeGrid()
        {
            try
            {
                GridEmployeeInformation.Columns.Remove("Edit");
                GridEmployeeInformation.Columns.Remove("Select");
                GridEmployeeInformation.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }

            foreach (DataGridViewColumn clm in GridEmployeeInformation.Columns)
            {
                clm.Visible = false;
            }
            GridEmployeeInformation.Columns["SLASH_DESC"].Visible = true;
            GridEmployeeInformation.Columns["NIC_NO"].Visible = true;
            GridEmployeeInformation.Columns["User_code"].Visible = true;
            GridEmployeeInformation.Columns["USER_NAME"].Visible = true;
            GridEmployeeInformation.Columns["PHONE"].Visible = true;
            GridEmployeeInformation.Columns["Mobile"].Visible = true;
            GridEmployeeInformation.Columns["Address1"].Visible = true;
            // Change Header Text
            GridEmployeeInformation.Columns["SLASH_DESC"].HeaderText = "Designation";
            GridEmployeeInformation.Columns["NIC_NO"].HeaderText = "CNIC";
            GridEmployeeInformation.Columns["User_code"].HeaderText = "Code";
            GridEmployeeInformation.Columns["USER_NAME"].HeaderText = "Name";
            GridEmployeeInformation.Columns["PHONE"].HeaderText = "Phone";
            GridEmployeeInformation.Columns["Mobile"].HeaderText = "Mobile";
            GridEmployeeInformation.Columns["Address1"].HeaderText = "Address";
            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridEmployeeInformation.Columns.Add(btnEdit);
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GridEmployeeInformation.Columns.Add(checkColumn);
            GridEmployeeInformation.Columns["Select"].DisplayIndex = 0;
            GridEmployeeInformation.Columns["SELECT"].HeaderText = "";
            //  Set Width Of Columns
            GridEmployeeInformation.Columns["Edit"].Width = 50;
            GridEmployeeInformation.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridEmployeeInformation.Columns["Select"].Width = 50;
            GridEmployeeInformation.Columns["NIC_NO"].Width = 120;
            GridEmployeeInformation.Columns["USER_CODE"].Width = 120;
            GridEmployeeInformation.Columns["USER_NAME"].Width = 120;
            GridEmployeeInformation.Columns["PHONE"].Width = 120;
            GridEmployeeInformation.Columns["MOBILE"].Width = 120;
            GridEmployeeInformation.Columns["Address1"].Width = 430;
            GridEmployeeInformation.Columns["SLASH_DESC"].Width = 120;
            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "   Status";
            GridEmployeeInformation.Columns.Add(activeClm);
            GridEmployeeInformation.Columns["activeClm"].DisplayIndex = GridEmployeeInformation.Columns["Edit"].Index - 1;
            GridEmployeeInformation.Columns["activeClm"].Width = 90;
            // Set Active and In Active Text
            GridEmployeeInformation.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridEmployeeInformation.Columns["activeClm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn clms in GridEmployeeInformation.Columns)
            {
                clms.ReadOnly = true;
            }
            GridEmployeeInformation.Columns["Select"].ReadOnly = false;
        } 
        #endregion
        private void cboxDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGridView();
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Grid Cell Content Click Event
        private void GridEmployeeInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridEmployeeInformation.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridEmployeeInformation.Columns["Edit"].Index)
            {
                EmployeeInformationProperties._userID = Convert.ToInt32(GridEmployeeInformation.Rows[_rowIndex].Cells["USER_ID"].Value.ToString());
                EmployeeInformationProperties._distributor = int.Parse(GridEmployeeInformation.Rows[_rowIndex].Cells["DISTRIBUTOR_ID"].Value.ToString());
                EmployeeInformationProperties._designation = GridEmployeeInformation.Rows[_rowIndex].Cells["SLASH_DESC"].Value.ToString();
                EmployeeInformationProperties._userName = GridEmployeeInformation.Rows[_rowIndex].Cells["USER_NAME"].Value.ToString();
                EmployeeInformationProperties._nicNo = GridEmployeeInformation.Rows[_rowIndex].Cells["NIC_NO"].Value.ToString();
                EmployeeInformationProperties._emailAddress = GridEmployeeInformation.Rows[_rowIndex].Cells["EMAIL"].Value.ToString();
                EmployeeInformationProperties._mobilNo = GridEmployeeInformation.Rows[_rowIndex].Cells["MOBILE"].Value.ToString();
                EmployeeInformationProperties._phoneNo = GridEmployeeInformation.Rows[_rowIndex].Cells["PHONE"].Value.ToString();
                EmployeeInformationProperties._isActive = Convert.ToBoolean(GridEmployeeInformation.Rows[_rowIndex].Cells["IS_ACTIVE"].Value.ToString());
                EmployeeInformationProperties._presentAddress = GridEmployeeInformation.Rows[_rowIndex].Cells["ADDRESS1"].Value.ToString();
                EmployeeInformationProperties._permanentAddress = GridEmployeeInformation.Rows[_rowIndex].Cells["ADDRESS2"].Value.ToString();
                EmployeeInformationProperties._ShiftID = Convert.ToInt32(GridEmployeeInformation.Rows[_rowIndex].Cells["SHIFT_ID"].Value.ToString());
                EmployeeInformationProperties._Department = GridEmployeeInformation.Rows[_rowIndex].Cells["Department"].Value.ToString();
                EmployeeInformationProperties._newOrEdit = "Edit";
                PopUpEmployeeInformation _popUpEmployeeInformation = new PopUpEmployeeInformation();
                _popUpEmployeeInformation.ShowDialog();
            }
        } 
        #endregion

        #region Active OR In Active Function
        private void btnActiveEmployee_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridEmployeeInformation,"Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridEmployeeInformation.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                _uController.UpdateDistributor_User(Convert.ToInt32(dr.Cells["USER_ID"].Value), Constants.IntNullValue, null, false, System.DateTime.Now, System.DateTime.Now, Constants.IntNullValue,
                                Constants.IntNullValue, Constants.IntNullValue, null, null, null, null, null
                                , null, null, null, null, Constants.IntNullValue, Constants.IntNullValue);
                            }
                            else
                            {
                                _uController.UpdateDistributor_User(Convert.ToInt32(dr.Cells["USER_ID"].Value), Constants.IntNullValue, null, true, System.DateTime.Now, System.DateTime.Now, Constants.IntNullValue,
                                Constants.IntNullValue, Constants.IntNullValue, null, null, null, null, null
                                , null, null, null, null, Constants.IntNullValue, Constants.IntNullValue);
                            }
                        }
                    }
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    RefreshGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
        } 
        #endregion

        #region Common Function
        private void btnAddNewEmployee_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddNewEmployee.BackColor = Color.FromArgb(255, 100, 0);
        }

        private void btnAddNewEmployee_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewEmployee.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridEmployeeInformation.Rows.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridEmployeeInformation.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridEmployeeInformation.Rows[i].Cells["Select"].Value = false;
                }
            }
        } 
        #endregion

        #region ActiveInactiveText Function
        private void FormEmployeeInformation_Shown(object sender, EventArgs e)
        {
            ActiveInactiveText();
        }
        public void ActiveInactiveText()
        {
            int _rows = GridEmployeeInformation.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridEmployeeInformation.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    GridEmployeeInformation.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridEmployeeInformation.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        } 
        #endregion
    }
}
