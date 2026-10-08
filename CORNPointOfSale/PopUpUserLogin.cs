using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class PopUpUserLogin : Form
    {
        readonly RoleManagementController _mController = new RoleManagementController();
        readonly UserController _uController = new UserController();
        readonly DistributorController _dController = new DistributorController();
        Distributor_UserController _duController = new Distributor_UserController();
        public PopUpUserLogin()
        {
            InitializeComponent();
        }

        #region Common
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected void ClearControls()
        {
            txtLoginID.Text = null;
            txtPassword.Text = null;
            cboxBaseLocation.SelectedIndex = 0;
            //cboxName.SelectedIndex = 0;
            cboxRoles.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        private void cboxBaseLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadUser();
                LoadTil();
            }
            catch (Exception)
            {
            }
        }
        public void WindupSave_Updation(string _messsage)
        {
            ClearControls();
            this.Close();
            Form _userLogin = Application.OpenForms["FormUserLogin"];
            ToastNotification.Show(_userLogin, _messsage, CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
            FormUserLogin _formUserLogin = Application.OpenForms["FormUserLogin"] as FormUserLogin;
            _formUserLogin.RefreshGridView();
            btnSave.Text = "Save";
        }
        private void PopUpUserLogin_Shown(object sender, EventArgs e)
        {
            if (UserLoginProperties._newOrEdit == "Edit")
            {
                cboxBaseLocation.SelectedValue = UserLoginProperties._distributor;
                cboxName.SelectedValue = UserLoginProperties._userID;
                cboxRoles.SelectedValue = UserLoginProperties._role;
                txtLoginID.Text = UserLoginProperties._logingID;
                txtPassword.Text = UserLoginProperties._password;
                chkIsActive.Checked = UserLoginProperties._isActive;
                chkManualDiscount.Checked = UserLoginProperties._IsManualDiscount;
                if (UserLoginProperties._Till > 0)
                {
                    ChkPOSUser.Checked = true;
                    label2.Visible = true;
                    ddTil.SelectedValue = UserLoginProperties._Till;
                }
                else
                {
                    ChkPOSUser.Checked = false;
                    label2.Visible = false;
                }
                btnSave.Text = "Update";
            }
            else if (UserLoginProperties._newOrEdit == "New")
            {
                chkIsActive.Checked = true;
                chkIsActive.Enabled = false;
                ClearControls();
            }
        } 
        #endregion

        #region Load Functions
        private void PopUpUserLogin_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            LoadUser();
            LoadRole();
            LoadTil();
        }
        private void LoadDistributor()
        {
            DataTable dtDistributor = _dController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
            cboxBaseLocation.DataSource = dtDistributor;
            cboxBaseLocation.DisplayMember = "DISTRIBUTOR_NAME";
            cboxBaseLocation.ValueMember = "DISTRIBUTOR_ID";
        }
        private void LoadUser()
        {
            if (cboxBaseLocation.Items.Count > 0)
            {
                DataTable dt = _duController.SelectDistributorUser(Constants.IntNullValue, int.Parse(cboxBaseLocation.SelectedValue.ToString()), Constants.IntNullValue);
                cboxName.DataSource = dt;
                cboxName.DisplayMember = "USER_NAME";
                cboxName.ValueMember = "USER_ID";
            }
            if (cboxName.Items.Count > 0)
            {
                cboxName.SelectedIndex = 0;
            }
        }
        protected void LoadTil()
        {
            if (cboxBaseLocation.DisplayMember != "DISTRIBUTOR_NAME" || cboxBaseLocation.ValueMember != "DISTRIBUTOR_ID")
            {
                return;
            }
            UserController _mController = new UserController();
            DataTable dt = _mController.SelectTil(Convert.ToInt32(cboxBaseLocation.SelectedValue.ToString()),0);
            ddTil.DataSource = dt;
            ddTil.DisplayMember = "Til_Desc";
            ddTil.ValueMember = "TIL_ID";
        }
        protected void LoadRole()
        {
            DataTable dt = _mController.SelectRoleMaster(Constants.IntNullValue, null, Constants.DateNullValue, Constants.DateNullValue, true);
            cboxRoles.DataSource = dt;
            cboxRoles.DisplayMember = "ROLE_NAME";
            cboxRoles.ValueMember = "ROLE_ID";
        } 
        #endregion

        #region Save Click _Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboxBaseLocation.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Distributor", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxName.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Employee", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxRoles.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Role", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            } 
            if(txtLoginID.Text == String.Empty)
            {
                ToastNotification.Show(this, "Please Enter Login ID", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                ToastNotification.Show(this, "Please Enter Password", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (ChkPOSUser.Checked == true && ddTil.Items.Count == 0)
            {
                ToastNotification.Show(this, "There is no Til at this location", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            Save_update_Login();
        }
        public void Save_update_Login()
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    DataTable dt = _uController.SelectSlashUser(txtLoginID.Text, CORNCommon.Classes.Cryptography.Encrypt(txtPassword.Text, Constants.CryptographyKey));
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Login id Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int _tilNumber;
                    if (!ChkPOSUser.Checked)
                    {
                        _tilNumber = Constants.IntNullValue;
                    }
                    else
                    {
                        _tilNumber = Convert.ToInt32(ddTil.SelectedValue.ToString());
                    }
                    _uController.InsertSlashUser(int.Parse(cboxName.SelectedValue.ToString()), SessionClass.CompanyID, int.Parse(cboxBaseLocation.SelectedValue.ToString()), txtLoginID.Text, CORNCommon.Classes.Cryptography.Encrypt(txtPassword.Text, Constants.CryptographyKey), int.Parse(cboxRoles.SelectedValue.ToString()), chkManualDiscount.Checked, _tilNumber);
                    WindupSave_Updation("Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Update")
            {
                try
                {
                    int _tilNumber;
                    if (!ChkPOSUser.Checked)
                    {
                        _tilNumber = Constants.IntNullValue;
                    }
                    else
                    {
                        _tilNumber = Convert.ToInt32(ddTil.SelectedValue.ToString());
                    }
                    _uController.UpdateUser(int.Parse(cboxName.SelectedValue.ToString()), SessionClass.CompanyID, txtLoginID.Text, CORNCommon.Classes.Cryptography.Encrypt(txtPassword.Text, Constants.CryptographyKey), int.Parse(cboxRoles.SelectedValue.ToString()), chkIsActive.Checked, int.Parse(cboxBaseLocation.SelectedValue.ToString()), chkManualDiscount.Checked, _tilNumber);
                    WindupSave_Updation("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void ChkPOSUser_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPOSUser.Checked)
            {
                label2.Visible = true;
                ddTil.Visible = true;
            }
            else
            {
                label2.Visible = false;
                ddTil.Visible = false;
            }
        }

        private void ddTil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
