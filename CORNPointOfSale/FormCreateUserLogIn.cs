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
using DevComponents.DotNetBar;
using CORNDataAccessLayer.Classes;

namespace CORNPointOfSale
{
    public partial class FormUserLogin : Form
    {
        readonly RoleManagementController _mController = new RoleManagementController();
        readonly UserController _uController = new UserController();
        readonly DistributorController _dController = new DistributorController();
        Distributor_UserController _duController = new Distributor_UserController();
        //
        
        public FormUserLogin()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            LoadGird();
            GridCreateUserLogin.BackgroundColor = Color.White;
        }
        private void LoadGird()
        {
            GridCreateUserLogin.DataSource = null;
            GridCreateUserLogin.Rows.Clear();
            DataTable dtDistributor = new DataTable();
            dtDistributor.Rows.Clear();
            dtDistributor = _uController.SelectSlashUser(null, null);
            foreach (DataRow row in dtDistributor.Rows)
            {
                row["PASSWORD"] = CORNCommon.Classes.Cryptography.Decrypt(row["PASSWORD"].ToString(), Constants.CryptographyKey);
            }
            GridCreateUserLogin.DataSource = dtDistributor;

            try
            {
                GridCreateUserLogin.Columns.Remove("Edit");
                GridCreateUserLogin.Columns.Remove("Select");
                GridCreateUserLogin.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }

            GridCreateUserLogin.Columns["USER_ID"].Visible = false;
            GridCreateUserLogin.Columns["DISTRIBUTOR_ID"].Visible = false;
            GridCreateUserLogin.Columns["ROLE_ID"].Visible = false;
            GridCreateUserLogin.Columns["USER_DETAIL"].Visible = false;
            GridCreateUserLogin.Columns["COMPANY_ID"].Visible = false;
            GridCreateUserLogin.Columns["ADDRESS1"].Visible = false;
            GridCreateUserLogin.Columns["EMAIL_ADDRESS"].Visible = false;
            GridCreateUserLogin.Columns["PHONE"].Visible = false;
            GridCreateUserLogin.Columns["NTN_NO"].Visible = false;
            GridCreateUserLogin.Columns["WEBSITE"].Visible = false;
            GridCreateUserLogin.Columns["COMPANY_NAME"].Visible = false;
            GridCreateUserLogin.Columns["IS_ACTIVE"].Visible = false;
            GridCreateUserLogin.Columns["User_code"].Visible = false;
            GridCreateUserLogin.Columns["IsDiscountAllowed"].Visible = false;
            GridCreateUserLogin.Columns["Til"].Visible = false;
            GridCreateUserLogin.Columns["SHIFT_ID"].Visible = false;
            GridCreateUserLogin.Columns["Deliveryman"].Visible = false;
            GridCreateUserLogin.Columns["ShowLogo"].Visible = false;

            
            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "  Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridCreateUserLogin.Columns.Add(btnEdit);

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GridCreateUserLogin.Columns.Add(checkColumn);
            GridCreateUserLogin.Columns["Select"].DisplayIndex = 0;
            GridCreateUserLogin.Columns["SELECT"].HeaderText = "";

            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "   Status";
            GridCreateUserLogin.Columns.Add(activeClm);
            GridCreateUserLogin.Columns["activeClm"].DisplayIndex = GridCreateUserLogin.Columns["Edit"].Index - 1;

            // Change Header Text
            GridCreateUserLogin.Columns["Select"].HeaderText = "";
            GridCreateUserLogin.Columns["User_Name"].HeaderText = "Name";
            GridCreateUserLogin.Columns["Login_id"].HeaderText = "Login ID";
            GridCreateUserLogin.Columns["Password"].HeaderText = "Password";
            GridCreateUserLogin.Columns["Role_Name"].HeaderText = "Role";
           // GridCreateUserLogin.Columns["Distributor_Name"].HeaderText = "Base Location";

            GridCreateUserLogin.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Set Width
            //GridCreateUserLogin.Columns["Distributor_Name"].Width = 180;
            GridCreateUserLogin.Columns["Select"].Width = 50;
            GridCreateUserLogin.Columns["User_Name"].Width = 360;
            GridCreateUserLogin.Columns["Login_id"].Width = 120;
            GridCreateUserLogin.Columns["Password"].Width = 120;
            GridCreateUserLogin.Columns["Role_Name"].Width = 120;
            GridCreateUserLogin.Columns["Edit"].Width = 70;
            GridCreateUserLogin.Columns["activeClm"].Width = 90;
           
            foreach (DataGridViewColumn clms in GridCreateUserLogin.Columns)
            {
                clms.ReadOnly = true;
            }
            GridCreateUserLogin.Columns["Select"].ReadOnly = false;
        } 
        #endregion
       
        #region Form Controles Event
        private void btnAddLogin_Click(object sender, EventArgs e)
        {
            UserLoginProperties._newOrEdit = "New";
            PopUpUserLogin _popUpUserLogin = new PopUpUserLogin();
            _popUpUserLogin.ShowDialog();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridCreateUserLogin.DataSource).DefaultView.RowFilter = "USER_CODE LIKE '%" + txtSearch.Text + "%' OR USER_NAME LIKE '%" + txtSearch.Text + "%' OR LOGIN_ID LIKE '%" + txtSearch.Text + "%' OR Password LIKE '%" + txtSearch.Text + "%' OR ROLE_NAME LIKE '%" + txtSearch.Text + "%'";
            ActiveInactiveText();
        }
        public void RefreshGridView()
        {
            GridCreateUserLogin.Columns.Remove("Edit");
            GridCreateUserLogin.Columns.Remove("Select");
            GridCreateUserLogin.Columns.Remove("activeClm");
            this.LoadGird();
            ActiveInactiveText();
        } 
        #endregion

        #region Active_InActive Users
        private void btnActiveLogin_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridCreateUserLogin,"Are you sure to Delete?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridCreateUserLogin.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                _uController.UpdateUser(Convert.ToInt32(dr.Cells["USER_ID"].Value), Constants.IntNullValue, null, null, Constants.IntNullValue, false, Constants.IntNullValue,false,Constants.IntNullValue);
                            }
                            else
                            {
                                _uController.UpdateUser(Convert.ToInt32(dr.Cells["USER_ID"].Value), Constants.IntNullValue, null, null, Constants.IntNullValue, true, Constants.IntNullValue, false, Constants.IntNullValue);
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

        #region Edit User
        private void GridCreateUserLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridCreateUserLogin.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridCreateUserLogin.Columns["Edit"].Index)
            {
                UserLoginProperties._role = Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["ROLE_ID"].Value.ToString());
                if (Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["USER_ID"].Value.ToString()) == 1)
                {
                    return;
                }
                UserLoginProperties._distributor = Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["DISTRIBUTOR_ID"].Value.ToString());
                UserLoginProperties._userID = Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["USER_ID"].Value.ToString());
                UserLoginProperties._userName = Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["USER_ID"].Value);
                UserLoginProperties._logingID = GridCreateUserLogin.Rows[_rowIndex].Cells["LOGIN_ID"].Value.ToString();
                UserLoginProperties._password = GridCreateUserLogin.Rows[_rowIndex].Cells["PASSWORD"].Value.ToString();
                UserLoginProperties._isActive = Convert.ToBoolean(GridCreateUserLogin.Rows[_rowIndex].Cells["IS_ACTIVE"].Value.ToString());
                UserLoginProperties._IsManualDiscount = Convert.ToBoolean(GridCreateUserLogin.Rows[_rowIndex].Cells["IsDiscountAllowed"].Value.ToString());
                try
                {
                    UserLoginProperties._Till = Convert.ToInt32(GridCreateUserLogin.Rows[_rowIndex].Cells["Til"].Value.ToString());
                }
                catch (Exception)
                {
                }
                UserLoginProperties._newOrEdit = "Edit";
                PopUpUserLogin _popUpUserLogin = new PopUpUserLogin();
                _popUpUserLogin.ShowDialog();
            }
        } 
        #endregion

        private void ChkAllGrid_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridCreateUserLogin.Rows.Count;
            if (ChkAllGrid.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridCreateUserLogin.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridCreateUserLogin.Rows[i].Cells["Select"].Value = false;
                }
            }
        }

        #region ActiveInactiveText Function
        private void FormCreateUserLogin_Shown(object sender, EventArgs e)
        {
            ActiveInactiveText();
        }
        public void ActiveInactiveText()
        {
            int _rows = GridCreateUserLogin.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridCreateUserLogin.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    GridCreateUserLogin.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridCreateUserLogin.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        }
        #endregion
    }
}
