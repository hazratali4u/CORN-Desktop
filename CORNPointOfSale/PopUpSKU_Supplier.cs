using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using CORNDataAccessLayer.Classes;

namespace CORNPointOfSale
{
    public partial class PopUpSKU_Supplier : Form
    {
        readonly SkuHierarchyController _mController = new SkuHierarchyController();
        public PopUpSKU_Supplier()
        {
            InitializeComponent();
        }

        #region Close Functions
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Save OR Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.TextLength == 0)
            {
                txtAmount.Text = "0";
            }
            int _amountType = 0;
            if (rbtnDebit.Checked)
            {
                _amountType = 1;
            }
            switch (btnSave.Text)
            {
                case "Save":
                    if (txtName.Text.Length == 0)
                    {
                        ToastNotification.Show(this, "Please Enter Principal Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        return;
                    }
                    _mController.InsertPrincipal(Constants.SKUPrincipal, Constants.IntNullValue, "", txtName.Text, null, true, SessionClass.CompanyID, ChkIsManualDiscount.Checked, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtContactPerson.Text, txtFaxNumber.Text, SessionClass.DISTRIBUTOR_ID, _amountType, Convert.ToInt32(txtAmount.Text), SessionClass.CurrentWorkDate);
                    WindupSave_Updation("Saved SuccessFully");
                    break;
                case "Update":
                    if (txtName.Text.Length == 0)
                    {
                        ToastNotification.Show(this, "Please Enter Principal Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        return;
                    }
                    _mController.UpdatePrincipal(Constants.SKUPrincipal, SupplierProperties._principalId, Constants.IntNullValue, "", txtName.Text, null, true, SessionClass.CompanyID, ChkIsManualDiscount.Checked, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtContactPerson.Text, txtFaxNumber.Text, SessionClass.DISTRIBUTOR_ID, _amountType, Convert.ToInt32(txtAmount.Text), SessionClass.CurrentWorkDate);
                    WindupSave_Updation("Update Successfully");
                    break;
            }
        }
        public void WindupSave_Updation(string _messsage)
        {
            ClearAll();
            this.Close();
            Form _SkuSupplier = Application.OpenForms["FormSKU_Supplier"];
            ToastNotification.Show(_SkuSupplier, _messsage, CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
            FormSKU_Supplier _formSupplier = Application.OpenForms["FormSKU_Supplier"] as FormSKU_Supplier;
            _formSupplier.LoadPrincipal();
            btnSave.Text = "Save";
        }
        #endregion

        #region Common Functions
        private void ClearAll()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtFaxNumber.Text = "";
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }
        #endregion

        #region PopUpLoad Event
        private void PopUpSKU_Supplier_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            if (SupplierProperties._NewOrUpdate == "New")
            {
                ClearAll();
                btnSave.Text = "Save";
            }
            else if (SupplierProperties._NewOrUpdate == "Update")
            {
                ClearAll();
                txtName.Text = SupplierProperties._name;
                txtEmail.Text = SupplierProperties._emailAddres;
                txtPhone.Text = SupplierProperties._phoneNumber;
                txtFaxNumber.Text = SupplierProperties._faxNumber;
                txtContactPerson.Text = SupplierProperties._contactPerson;
                txtAddress.Text = SupplierProperties._address;
                txtAmount.Text = SupplierProperties._amount.ToString();
                if (SupplierProperties._type == 1)
                {
                    rbtnDebit.Checked = true;
                }
                btnSave.Text = "Update";
                ChkIsManualDiscount.Checked = SupplierProperties._ISManualDiscount;
            }
        } 
        #endregion
        
        #region GetAutoCode
        /// <summary>
        /// Gets Code For New Principal, Division, Category And Brand
        /// </summary>
        private string GetAutoCode(string preeFix, int codeType)
        {
            SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
            return AutoCode.GetAutoCode(preeFix, codeType, Constants.LongNullValue);
        }

        /// <summary>
        /// Sets Code For Principal, Division, Category And Brand
        /// </summary>
        private void SetAutoCode(string preeFix, long cValue)
        {
            SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
            string result = AutoCode.GetAutoCode(preeFix, 1, cValue);
        } 
        #endregion

       
    }
}
