using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using CORNDataAccessLayer.Classes;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace CORNPointOfSale
{
    public partial class PopUpNewCompany : Form
    {
        CompanyController mController = new CompanyController();
        MainFrom frmMain = null;
        bool exit = true;
        public PopUpNewCompany(MainFrom frm)
        {
            this.frmMain = frm;
            InitializeComponent();
        }

        #region Form Events
        private void btnClosePopUp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            //ClearAll();
            //this.Close();
            Application.Exit();
        }
        #endregion


        #region Clear All Fields

        //private void ClearAll()
        //{
        //    txtName.Text = "";
        //    txtAddress.Text = "";
        //    txtPhone.Text = "";
        //    txtNtn.Text = "";
        //    txtWebsite.Text = "";
        //    txtEmailAddress.Text = "";
        //    btnSave.Text = "Save";
        //}

        #endregion

        #region Update Company
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtAddress.Text.Trim() != string.Empty && txtName.Text.Trim() != string.Empty && txtPhone.Text.Trim() != string.Empty
                && txtNtn.Text.Trim() != string.Empty && txtEmailAddress.Text.Trim() != string.Empty)
            {
                UpdateCompany();
            }
            else
            {
                ToastNotification.Show(this, "Please Enter Company Name, Phone, NTN, Email and Address", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        public void UpdateCompany()
        {
            try
            {
                string result = mController.UpdateCompany(1, txtEmailAddress.Text.Trim(), txtPhone.Text.Trim(), txtWebsite.Text.Trim(), txtName.Text.Trim(), txtAddress.Text.Trim(), txtNtn.Text.Trim());
                exit = false;
                //ClearAll();
                this.Close();
                //Form _formNewLocation = Application.OpenForms["FormNewLocation2"];
                ToastNotification.Show(frmMain, "Saved Successfully", CORNPointOfSale.Properties.Resources.Tick, 3000, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                //FormNewLocation2 _form = Application.OpenForms["FormNewLocation2"] as FormNewLocation2;
                //_form.RefreshGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.Message);
            }


        }
        #endregion

        private void PopUpNewCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exit)
            {
                Application.Exit();
            }
        }
    }
}
