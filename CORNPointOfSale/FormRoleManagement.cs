using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormRoleManagement : Form
    {
        readonly RoleManagementController _mController = new RoleManagementController();
        readonly DataControl _dc = new DataControl();
        public FormRoleManagement()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormRoleManagement_Load(object sender, EventArgs e)
        {
            LoadRole();
            //LoadMod1StLayer();
            //LoadMod2NdtLayer();
            LoadMod3RdtLayer();
            int roleId = Convert.ToInt32(cboxRole.SelectedValue);
            GetUnAssingModule(roleId);
            GetAssingModule(roleId);
        }
        private void LoadRole()
        {
            DataTable dt = _mController.SelectRoleMaster(0, null, System.DateTime.Today, System.DateTime.Today, true);
            cboxRole.DataSource = dt;
            cboxRole.DisplayMember = "ROLE_NAME";
            cboxRole.ValueMember = "ROLE_ID";
        }
        private void LoadMod1StLayer()
        {
            DataTable dt = _mController.SelectModule(Constants.IntNullValue, null, Constants.IntNullValue, Constants.Mod_1st_Layer, Constants.DateNullValue, true);
            dt.DefaultView.Sort = "MODULE_DESCRIPTION";
            cboxFirstModuleLayer.DataSource = dt.DefaultView;
            cboxFirstModuleLayer.DisplayMember = "MODULE_DESCRIPTION";
            cboxFirstModuleLayer.ValueMember = "MODULE_ID";
        }
        private void LoadMod2NdtLayer()
        {
            if (cboxFirstModuleLayer.Items.Count > 0)
            {
                DataTable dt = _mController.SelectModule(Constants.IntNullValue, null, int.Parse(_dc.chkNull(cboxFirstModuleLayer.SelectedValue.ToString())), Constants.Mod_2nd_Layer, Constants.DateNullValue, true);
                dt.DefaultView.Sort = "MODULE_DESCRIPTION";
                cboxSecondModuleLayer.DataSource = dt.DefaultView;
                cboxSecondModuleLayer.DisplayMember = "MODULE_DESCRIPTION";
                cboxSecondModuleLayer.ValueMember = "MODULE_ID"; 
            }
        }
        private void LoadMod3RdtLayer()
        {
            DataTable dt = _mController.SelectModule(Constants.IntNullValue, null, Constants.IntNullValue, Constants.Mod_3rd_Layer, Constants.DateNullValue, true);
            dt.DefaultView.Sort = "MODULE_DESCRIPTION";
            cboxThirdModuleLayer.DataSource = dt.DefaultView;
            cboxThirdModuleLayer.DisplayMember = "MODULE_DESCRIPTION";
            cboxThirdModuleLayer.ValueMember = "MODULE_ID";
        }
        private void GetUnAssingModule(int roleId)
        {
            DataTable dt = _mController.GetAssignUnAssignModule(roleId, int.Parse(_dc.chkNull(cboxThirdModuleLayer.SelectedValue.ToString())), Constants.IntNullValue, 0);
            dt.DefaultView.Sort = "MODULE_DESCRIPTION";
            lstUnAssignModule.DataSource = dt.DefaultView;
            lstUnAssignModule.DisplayMember = "MODULE_DESCRIPTION";
            lstUnAssignModule.ValueMember = "MODULE_ID";
        }
        private void GetAssingModule(int roleId)
        {
            if (cboxThirdModuleLayer.Items.Count > 0)
            {
                DataTable dt = _mController.GetAssignUnAssignModule(roleId, int.Parse(_dc.chkNull(cboxThirdModuleLayer.SelectedValue.ToString())), Constants.IntNullValue, 1);
                dt.DefaultView.Sort = "MODULE_DESCRIPTION";
                lstAssignModule.DataSource = dt.DefaultView;
                lstAssignModule.DisplayMember = "MODULE_DESCRIPTION";
                lstAssignModule.ValueMember = "MODULE_ID"; 
            }
        }
        #endregion

        #region Cbox Checked Changed Events
        private void cboxRole_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
            catch (Exception)
            { }
        }
        private void cboxFirstModuleLayer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                LoadMod2NdtLayer();
                LoadMod3RdtLayer();
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
            catch (Exception)
            { }
        }
        private void cboxSecondModuleLayer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                LoadMod3RdtLayer();
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
            catch (Exception)
            { }
        }
        private void cboxThirdModuleLayer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
            catch (Exception)
            { }
        } 
        #endregion

        #region Add New Role
        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                cboxRole.Visible = false;
                txtNewRole.Text = null;
                txtNewRole.Visible = true;
                txtNewRole.Enabled = true;
                btnNew.Text = "Save";
            }
            else
            {
                if (txtNewRole.Text == "")
                {
                    ToastNotification.Show(this, "Enter Role Please", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
                else
                {
                    _mController.InsertRoleMaster(txtNewRole.Text, System.DateTime.Today, System.DateTime.Today, true);
                    LoadRole();
                }
                btnNew.Text = "New";
                cboxRole.Visible = true;
                txtNewRole.Visible = false;
            }
        } 
        #endregion

        #region Assign / UnAssign Modules

        private void btnAssign_Click_1(object sender, EventArgs e)
        {
            if (lstUnAssignModule.Items.Count > 0)
            {
                _mController.InsertRoleDetail(int.Parse(cboxRole.SelectedValue.ToString()), Convert.ToInt32(lstUnAssignModule.SelectedValue), 1);
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
        }
        private void btnUnAssign_Click_1(object sender, EventArgs e)
        {
            if (lstAssignModule.Items.Count > 0)
            {
                _mController.InsertRoleDetail(int.Parse(cboxRole.SelectedValue.ToString()), Convert.ToInt32(lstAssignModule.SelectedValue), 0);
                GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
            }
        }
        private void btnAssignAll_Click(object sender, EventArgs e)
        {
            int _rows = lstUnAssignModule.Items.Count;
            if (_rows > 0)
            {
                for (int i = 0; i < _rows; i++)
                {
                    _mController.InsertRoleDetail(int.Parse(cboxRole.SelectedValue.ToString()), Convert.ToInt32(lstUnAssignModule.SelectedValue), 1);
                    GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                    GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                }
            }
        }
        private void btnUnAssignAll_Click(object sender, EventArgs e)
        {
            int _rows = lstAssignModule.Items.Count;
            if (_rows > 0)
            {
                for (int i = 0; i < _rows; i++)
                {
                    _mController.InsertRoleDetail(int.Parse(cboxRole.SelectedValue.ToString()), Convert.ToInt32(lstAssignModule.SelectedValue), 0);
                    GetUnAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                    GetAssingModule(int.Parse(cboxRole.SelectedValue.ToString()));
                }
            }
        } 

        #endregion

        private void FormRoleManagement_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 370, 195);
            groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
