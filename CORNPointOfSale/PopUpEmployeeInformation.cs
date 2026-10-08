using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class PopUpEmployeeInformation : Form
    {
        readonly Distributor_UserController _uController = new Distributor_UserController();
        public PopUpEmployeeInformation()
        {
            InitializeComponent();
        }

        #region Form Controle Events


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
            try
            {
                txtName.Text = null;
                txtPhoneNumber.Text = null;
                txtMobile.Text = null;
                txtPresentAddress.Text = null;
                txtPermanentAddress.Text = null;
                txtEmail.Text = null;
                txtCNIC.Text = null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        #endregion
        
        #region Load Functions
        private void PopUpEmployeeInformation_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            LoadDesignation();
            LoadDepartment();
            LoadShift();
            //txtShiftFrom.Value = System.DateTime.Now;
            //txtShiftTo.Value = System.DateTime.Now;
        }
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, 1);
            cboxBaseLocation.DataSource = dtDistributor;
            cboxBaseLocation.DisplayMember = "DISTRIBUTOR_NAME";
            cboxBaseLocation.ValueMember = "DISTRIBUTOR_ID";
        }
        private void LoadShift()
        {
            try
            {
                UserController _mCtrl = new UserController();
                DataTable dt = new DataTable();
                dt = _mCtrl.SelectShift(Convert.ToInt32(cboxBaseLocation.SelectedValue.ToString()), 0);
                cboxShift.DataSource = dt;
                cboxShift.DisplayMember = "Shift_desc";
                cboxShift.ValueMember = "SHIFT_ID";
            }
            catch (Exception)
            {
            }
        }
        private void LoadDesignation()
        {
            SLASHCodesController mController = new SLASHCodesController();
            DataTable m_dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.SaleForce, null, Constants.IntNullValue, true);
            cboxDesignation.DataSource = m_dt;
            cboxDesignation.DisplayMember = "SLASH_DESC";
            cboxDesignation.ValueMember = "REF_ID";
        }
        private void LoadDepartment()
        {
            SLASHCodesController mController = new SLASHCodesController();
            DataTable m_dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Depoartment_Id, null, Constants.IntNullValue, true);
            cboxDepartment.DataSource = m_dt;
            cboxDepartment.DisplayMember = "SLASH_DESC";
            cboxDepartment.ValueMember = "REF_ID";
        } 
        #endregion

        #region Save OR Update Function
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboxBaseLocation.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Base Location", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxDesignation.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Designation", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxDepartment.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Department", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxShift.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Shift", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtName.Text != string.Empty )
            {
                Save_Update_Users();
                return;
            }
            ToastNotification.Show(this, "Please Enter Employee Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }
        public void Save_Update_Users()
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    SETTINGS_TABLE_Controller mAutoCode = new SETTINGS_TABLE_Controller();

                    string strcode = "";
                    SessionClass.UserID = int.Parse(mAutoCode.GetAutoCustomerCode("EM", 0, Constants.LongNullValue).ToString());

                    if (SessionClass.UserID.ToString().Length == 1)
                    {
                        strcode = "EM" + "000" + SessionClass.UserID.ToString();
                    }
                    else if (SessionClass.UserID.ToString().Length == 2)
                    {
                        strcode = "EM" + "00" + SessionClass.UserID.ToString();
                    }
                    else if (SessionClass.UserID.ToString().Length == 3)
                    {
                        strcode = "EM" + "0" + SessionClass.UserID.ToString();
                    }
                    else
                    {
                        strcode = "EM" + SessionClass.UserID.ToString();
                    }

                    string SaleForceId = _uController.InsertDistributor_User(SessionClass.CompanyID, txtCNIC.Text, true, System.DateTime.Now, System.DateTime.Now, int.Parse(cboxDesignation.SelectedValue.ToString()),
                        Convert.ToInt32(cboxBaseLocation.SelectedValue), Constants.IntNullValue, txtEmail.Text, txtPresentAddress.Text, txtPermanentAddress.Text, "", ""
                        , txtMobile.Text, strcode, txtName.Text, txtPhoneNumber.Text, Convert.ToInt32(cboxShift.SelectedValue.ToString()), Convert.ToInt32(cboxDepartment.SelectedValue.ToString()));

                    mAutoCode.GetAutoCustomerCode("EM", 1, long.Parse(SessionClass.UserID.ToString()));
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
                    _uController.UpdateDistributor_User(EmployeeInformationProperties._userID, SessionClass.CompanyID, txtCNIC.Text, chkIsActive.Checked, System.DateTime.Now, System.DateTime.Now, int.Parse(cboxDesignation.SelectedValue.ToString()),
                                int.Parse(cboxBaseLocation.SelectedValue.ToString()), Constants.IntNullValue, txtEmail.Text, txtPresentAddress.Text, txtPermanentAddress.Text, "", ""
                                , txtMobile.Text, null, txtName.Text, txtPhoneNumber.Text, Convert.ToInt32(cboxShift.SelectedValue.ToString()), Convert.ToInt32(cboxDepartment.SelectedValue.ToString()));
                    WindupSave_Updation("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void WindupSave_Updation(string _messsage)
        {
            ClearControls();
            this.Close();
            Form _employeeInformation = Application.OpenForms["FormEmployeeInformation"];
            ToastNotification.Show(_employeeInformation, _messsage, CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
            FormEmployeeInformation _formEmployee = Application.OpenForms["FormEmployeeInformation"] as FormEmployeeInformation;
            _formEmployee.RefreshGridView();
            btnSave.Text = "Save";
        }
        #endregion

        #region PopUp Form Shown Event
        private void PopUpEmployeeInformation_Shown(object sender, EventArgs e)
        {
            if (EmployeeInformationProperties._newOrEdit == "Edit")
            {
                cboxBaseLocation.SelectedValue = EmployeeInformationProperties._distributor;
                cboxDesignation.SelectedIndex = cboxDesignation.FindString(EmployeeInformationProperties._designation);
                cboxDepartment.SelectedIndex = cboxDepartment.FindString(EmployeeInformationProperties._Department);
                txtName.Text = EmployeeInformationProperties._userName;
                txtCNIC.Text = EmployeeInformationProperties._nicNo;
                txtEmail.Text = EmployeeInformationProperties._emailAddress;
                txtMobile.Text = EmployeeInformationProperties._mobilNo;
                txtPhoneNumber.Text = EmployeeInformationProperties._phoneNo;
                txtPresentAddress.Text = EmployeeInformationProperties._presentAddress;
                txtPermanentAddress.Text = EmployeeInformationProperties._permanentAddress;
                chkIsActive.Checked = EmployeeInformationProperties._isActive;
                cboxShift.SelectedValue = EmployeeInformationProperties._ShiftID;
                btnSave.Text = "Update";
            }
            else if (EmployeeInformationProperties._newOrEdit == "New")
            {
                ClearFields();
            }
        } 
        #endregion

        #region ClearFields
        public void ClearFields()
        {
            txtCNIC.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            txtPermanentAddress.Text = "";
            txtPresentAddress.Text = "";
            txtPhoneNumber.Text = "";
            btnSave.Text = "Save";
            chkIsActive.Checked = true;
        }
        #endregion

        private void cboxBaseLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxBaseLocation.DisplayMember == "DISTRIBUTOR_NAME" && cboxBaseLocation.ValueMember == "DISTRIBUTOR_ID")
            {
                LoadShift();
            }
        }
    }
}
