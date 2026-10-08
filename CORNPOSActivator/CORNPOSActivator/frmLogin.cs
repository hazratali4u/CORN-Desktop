using CORNPOSAPICaller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CORNPOSActivator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Please provide username/password");
                return;
            }

            APICaller call = new APICaller();
            var result = call.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (result != null)
            {
                this.Hide();

                APIResult.AccessToken = result.Access_Token;
                APIResult.UserID = result.UserId;
                APIResult.Username = result.UserName;

                MainForm frm = new MainForm();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username/password");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
