using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class frmAllowDiscount : Office2007Form
    {
        private frmPOS objfrmPOS;

        public frmAllowDiscount()
        {
            InitializeComponent();
        }

        public frmAllowDiscount(frmPOS objfrmPOS) : this()
        {
            this.objfrmPOS = objfrmPOS;
        }


        #region Common Functions
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0)
            {
                UserController mController = new UserController();
                DataTable dtLogin = mController.SelectSlashUser(txtLogin.Text, CORNCommon.Classes.Cryptography.Encrypt(txtPassword.Text, Constants.CryptographyKey));
                //DataTable dtLogin = mController.SelectSlashUser(txtLogin.Text, txtPassword.Text);
                if (dtLogin.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtLogin.Rows[0]["IsDiscountAllowed"]))
                    {
                        objfrmPOS.AllowDiscount(dtLogin.Rows[0]["USER_NAME"].ToString());
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Discount Not Allowed", "CORN : POS");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong User Id/Password", "CORN : POS");
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void frmAllowDiscount_Load(object sender, EventArgs e)
        {
            this.txtLogin.Focus();
        }
        #endregion

    }
}
