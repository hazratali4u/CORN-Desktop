using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using Microsoft.Win32;

namespace CORNPointOfSale
{
    public partial class FormLogin : Form
    {
        UserController mController = new UserController();
        RoleManagementController ObjRole = new RoleManagementController();
        DistributorController mDist = new DistributorController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            int days = 0;
            int max_days = 0;
            string strCustID = null;
            string strRenewalDate = null;
            
            DataTable dtLicenseData = SessionClass.dtLicenseData;
            try
            {
                // zero = XwlEcTFZuOA=
                // 15 = ENU30lmujv0=
                // 30 = 7mjgMIekaSU=
                days = Convert.ToInt32(Cryptography.Decrypt(dtLicenseData.Rows[0]["DIAS"].ToString(), Constants.CryptographyKey));
                max_days = Convert.ToInt32(Cryptography.Decrypt(dtLicenseData.Rows[0]["MAX_DIAS"].ToString(), Constants.CryptographyKey));
                strCustID = Cryptography.Decrypt(dtLicenseData.Rows[0]["DITSUC"].ToString(), Constants.CryptographyKey);
                strRenewalDate = Cryptography.Decrypt(dtLicenseData.Rows[0]["ETADLAWENER"].ToString(), Constants.CryptographyKey);

                if (DBNull.Value == dtLicenseData.Rows[0]["EZISEEHCRAP"])
                {
                    // do nothing
                }
                else
                {
                    SessionClass.ReceiptPrintSize = Cryptography.Decrypt(dtLicenseData.Rows[0]["EZISEEHCRAP"].ToString(), Constants.CryptographyKey);
                }

                if (DBNull.Value == dtLicenseData.Rows[0]["TIDEECIRPELAS"])
                {
                    // do nothing
                }
                else
                {
                    SessionClass.SalePriceEdit = Cryptography.Decrypt(dtLicenseData.Rows[0]["TIDEECIRPELAS"].ToString(), Constants.CryptographyKey);
                }

                if (string.IsNullOrEmpty(strRenewalDate))
                {
                    // update date to current date upto max_days value
                    DateTime dt = DateTime.Now.Date.AddDays(max_days - days);
                    string encStrRenewalDate = Cryptography.Encrypt(dt.ToString("dd-MMM-yyyy"), Constants.CryptographyKey);
                    //save now
                    mDist.UpdateLicenseDataTrialVersionDate(encStrRenewalDate);

                    strRenewalDate = dt.ToString("dd-MMM-yyyy");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                MessageBox.Show("Unauthorized Activity Performed, Contact to Administrator", "CORN POS");
                ExceptionPublisher.PublishException(exp);
                Application.Exit();

            }
            if (dtLicenseData.Rows.Count > 0)
            {
                //HKUD\Software\Fast Services\CORN Point of Sale\Version
                string version = "1.0";
                version = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\CORN Point of Sale\CORN POS", "Version", version);

                //MessageBox.Show(version + " - hey");


                //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Fast Services");//\CORN Point of Sale");
                //if (key != null)
                //{
                //    version = "" + key.GetValue("Version");
                //    key.Close();
                //}

                if (string.IsNullOrEmpty(version))
                {
                    version = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CORN Point of Sale\CORN POS", "Version", version);

                    if (string.IsNullOrEmpty(version))
                    {
                        version = "1.0";
                    }
                }

                SessionClass.Version = version;
                SessionClass.PoweredBy = "Powered By CORN POS";

                lblVersion.Text = "Version: " + SessionClass.Version + " " + SessionClass.PoweredBy;

                //days = 3;
                //max_days = 30;

                DateTime renewalDte = !string.IsNullOrEmpty(strRenewalDate) ? Convert.ToDateTime(strRenewalDate) : DateTime.Now;

                if (string.IsNullOrEmpty(strCustID)) // old logic of checking expiry and trial version
                {
                    if (days >= max_days || (!string.IsNullOrEmpty(strRenewalDate) && DateTime.Now.Date >= renewalDte.Date))
                    {
                        this.lblExp.Text = "Your License has been Expired!!!";
                        this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.lblExp.ForeColor = System.Drawing.Color.Red;
                        this.lblExp.Location = new System.Drawing.Point(19, 485);

                        MessageBox.Show("Dear Customer!\nYour License has been expired, Please Contact to Administrator", "CORN POS");
                        SessionClass.IsExpired = true;
                        //Application.Exit();
                    }
                    else
                    {
                        SessionClass.Edition = "Trial Version";

                        if (days >= (max_days - 10))
                        {
                            int _remaingindays = max_days - days;

                            if (_remaingindays == 10)
                            {
                                MessageBox.Show("Dear Customer!\nYour License will be expired after '" + _remaingindays + "' Days, Please Contact to Administrator", "CORN POS");
                            }

                            if (_remaingindays > 1)
                            {
                                SessionClass.Edition = SessionClass.Edition + " (" + _remaingindays + " Days to expire)";

                                this.lblEdition.Text = SessionClass.Edition;
                            }
                            else
                            {
                                SessionClass.Edition = SessionClass.Edition + " (" + _remaingindays + " Day to expire)";
                                this.lblEdition.Text = SessionClass.Edition;
                            }
                            this.lblEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            this.lblEdition.ForeColor = System.Drawing.Color.DarkOrange;
                            this.lblEdition.Location = new System.Drawing.Point(51, 301);
                        }
                        else
                        {
                            //this.lblEdition.Location = new System.Drawing.Point(80, 485);
                            if (!string.IsNullOrEmpty(strRenewalDate))
                            {
                                SessionClass.Edition = SessionClass.Edition + " (Expiry Date : " + renewalDte.ToString("dd MMM yyyy") + ")";
                            }
                            else
                            {
                                SessionClass.Edition = SessionClass.Edition + " (Expiry Date : " + DateTime.Now.AddDays(max_days - days).ToString("dd MMM yyyy") + ")";
                            }
                            lblEdition.Text = SessionClass.Edition;
                        }

                        txtUserID.Focus();
                        btnSignIn_Click(null, null);
                    }
                }
                else // new logic of checking expiry and trial version
                {
                    SessionClass.Edition = "";
                    renewalDte = Convert.ToDateTime(strRenewalDate);
                    
                    if (DateTime.Now.Date < renewalDte)
                    {
                        int daysLeft = Convert.ToInt32((renewalDte - DateTime.Now.Date).TotalDays);
                        if (daysLeft > 10)
                        {
                            SessionClass.Edition = SessionClass.Edition + " (Expiry Date : " + strRenewalDate + ")";
                            lblEdition.Text = SessionClass.Edition;
                        }
                        else
                        {
                            if (daysLeft == 10)
                            {
                                MessageBox.Show("Dear Customer!\nYour License will be expired after '" + daysLeft + "' Days, Please Contact to Administrator", "CORN POS");
                            }

                            if (daysLeft > 1)
                            {
                                SessionClass.Edition = SessionClass.Edition + " (" + daysLeft + " Days to expire)";

                                this.lblEdition.Text = SessionClass.Edition;
                            }
                            else
                            {
                                SessionClass.Edition = SessionClass.Edition + " (" + daysLeft + " Day to expire)";
                                this.lblEdition.Text = SessionClass.Edition;
                            }
                            this.lblEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            this.lblEdition.ForeColor = System.Drawing.Color.DarkOrange;
                            this.lblEdition.Location = new System.Drawing.Point(51, 301);
                        }

                        txtUserID.Focus();
                        btnSignIn_Click(null, null);
                    }
                    else
                    {
                        this.lblExp.Text = "Your License has been Expired!!!";
                        this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.lblExp.ForeColor = System.Drawing.Color.Red;
                        this.lblExp.Location = new System.Drawing.Point(19, 485);

                        MessageBox.Show("Dear Customer!\nYour License has been expired, Please Contact to Administrator", "CORN POS");
                        SessionClass.IsExpired = true;
                        //Application.Exit();
                    }
                }
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }

        public void ValidateUser()
        {

            if (txtUserID.Text == "" || txtPassword.Text == "")
            {
                return;
            }
            else
            {
                DataTable dt = mController.SelectSlashUser(txtUserID.Text, CORNCommon.Classes.Cryptography.Encrypt(txtPassword.Text, Constants.CryptographyKey));
                //DataTable dt = mController.SelectSlashUser(txtUserID.Text, txtPassword.Text);
                if (dt.Rows.Count > 0)
                {

                    if (Convert.ToBoolean(dt.Rows[0]["IS_ACTIVE"]))
                    {

                    }
                    else
                    {
                        MessageBox.Show("This user is InActive");
                        return;
                    }
                    SessionClass.UserID = Convert.ToInt32(dt.Rows[0]["USER_ID"].ToString());
                    SessionClass.UserName = dt.Rows[0]["USER_NAME"].ToString();
                    SessionClass.DISTRIBUTOR_ID = Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"]);
                    SessionClass.CompanyID = Convert.ToInt32(dt.Rows[0]["COMPANY_ID"].ToString());
                    SessionClass.Shift_ID = Convert.ToInt32(dt.Rows[0]["SHIFT_ID"].ToString());
                    SessionClass.RoleID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"].ToString());
                    SessionClass.CompanyName = dt.Rows[0]["COMPANY_NAME"].ToString();
                    try
                    {
                        SessionClass.ShowLogo = Convert.ToBoolean(dt.Rows[0]["ShowLogo"]);
                    }
                    catch (Exception)
                    {
                        SessionClass.ShowLogo = false;
                    }
                    try
                    {
                        SessionClass.ShowDeliveryman = Convert.ToInt32(dt.Rows[0]["Deliveryman"].ToString());
                    }
                    catch (Exception)
                    {
                        SessionClass.ShowDeliveryman = 0;
                    }
                    try
                    {
                        if (Convert.ToInt32(dt.Rows[0]["Til"].ToString()) > 0)
                        {
                            SessionClass.Is_POS_USER = true;
                        }
                        else
                        {
                            SessionClass.Is_POS_USER = false;
                        }
                    }
                    catch (Exception)
                    {
                        SessionClass.Is_POS_USER = false;
                    }
                    LastClosedDay(Convert.ToInt32(dt.Rows[0]["USER_ID"]), Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"]));
                    //SessionClass.IsDiscountAllowed = Convert.ToBoolean(dt.Rows[0]["IsDiscountAllowed"]);
                    var userLogId = mController.InsertUserLoginTime(Convert.ToInt32(dt.Rows[0]["USER_ID"]));
                    SessionClass.User_Log_ID = userLogId;
                    if (dt.Rows[0]["ROLE_ID"].ToString() == "49")
                    {
                        SessionClass.LoginStatus = 2;
                        this.Hide();
                        LoadMainForm();
                    }
                    else
                    {
                        if (SessionClass.IsExpired && SessionClass.RoleID > 1)
                        {
                            MessageBox.Show("Please Enter Admin User to activate software", "CORN : POS");
                            return;
                        }
                        else
                        {
                            SessionClass.LoginStatus = 1;
                            this.Hide();
                            LoadMainForm();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid User Id & Password", "CORN : POS");
                }
            }
        }

        private void LoadMainForm()
        {
            RoleManagementController m_controller = new RoleManagementController();
            MainFrom _formMain = new MainFrom();
            MainFrom.dtPrivileges = m_controller.SelectRoleWiseModule(SessionClass.RoleID, 6, 0);
            _formMain.Show();
        }
        private void LastClosedDay(int UserId, int p_Distributor)
        {
            DistributorController mDayClose = new DistributorController();
            DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
            if (dt.Rows.Count > 0)
            {
                SessionClass.CurrentWorkDate = Convert.ToDateTime(dt.Rows[0]["CLOSING_DATE"].ToString());
            }
            else
            {
                SessionClass.CurrentWorkDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            }
        }

        #region Common Functions
        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(null, null);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(null, null);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            { }
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnSignIn_Click(null, null);
            //try
            //{
            //    var appSettings = ConfigurationManager.AppSettings;

            //    if (appSettings.Count == 0)
            //    {
            //        Console.WriteLine("AppSettings is empty.");
            //    }
            //    else
            //    {
            //        foreach (var key in appSettings.AllKeys)
            //        {
            //            MessageBox.Show("Key: {0} Value: {1}" + key + appSettings[key]);
            //        }
            //    }
            //}
            //catch (ConfigurationErrorsException)
            //{
            //    MessageBox.Show("Error reading app settings");
            //}
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 180, 270);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
