using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using DevComponents.DotNetBar;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormChangePassword : Form
    {
        readonly UserController _userInfo = new UserController();
        DataTable _dtLoginId = new DataTable();
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "" || txtCurrentPassword.Text == "" || txtNewPassword.Text == "")
            {
                ToastNotification.Show(this, "Fill All The Fields", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
            else
            {
                bool status = UpdatePassword();
                if (status)
                {
                    ToastNotification.Show(this, "Password has been changed Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    ResetFields();
                }
            }
        }

        protected bool UpdatePassword()
        {
            try
            {
                _dtLoginId = _userInfo.SelectSlashUser(SessionClass.UserID);
                if (txtCurrentPassword.Text == CORNCommon.Classes.Cryptography.Decrypt(_dtLoginId.Rows[0]["PASSWORD"].ToString(), Constants.CryptographyKey))
                {
                    _userInfo.UpdateUser(SessionClass.UserID, SessionClass.CompanyID, _dtLoginId.Rows[0]["LOGIN_ID"].ToString(), CORNCommon.Classes.Cryptography.Encrypt(txtConfirmPassword.Text, Constants.CryptographyKey), Constants.IntNullValue, true, SessionClass.DISTRIBUTOR_ID, false, Constants.IntNullValue);
                    return true;
                }
                ToastNotification.Show(this, "Invalid Current Password", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        public void ResetFields()
        {
            txtConfirmPassword.Text = string.Empty;
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }

        private void FormChangePassword_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 210, 140);
            groupPanel2.Location = new Point(points[0], points[1]);

        }
    }
}
