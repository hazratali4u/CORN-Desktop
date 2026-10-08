using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace CORNPointOfSale
{
    public partial class frmActivate : Form
    {
        CompanyController mController = new CompanyController();
        DistributorController mDist = new DistributorController();
        string companyName = "";
        string keyName = "Registration";
        public frmActivate()
        {
            InitializeComponent();
        }

        private void frmActivate_Load(object sender, EventArgs e)
        {
            DataTable dtLicenseData = SessionClass.dtLicenseData;
            try
            {
                var strCustID = Cryptography.Decrypt(dtLicenseData.Rows[0]["DITSUC"].ToString(), Constants.CryptographyKey);
                if (!string.IsNullOrEmpty(strCustID))
                {
                    keyName = "Renewal";
                }
            }
            catch { };

            lblRegKey.Text = keyName + " Key";

            DataTable dt = mController.SelectCompany(Constants.IntNullValue, Constants.IntNullValue);
            if (dt != null)
            {
                string fullName = "";
                string phone = "";
                string ntn = "";
                string email = "";
                string address = "";

                foreach (DataRow row in dt.Rows)
                {
                    fullName = row[1].ToString();
                    companyName = row[1].ToString();
                    phone = row[4].ToString();
                    ntn = row[5].ToString();
                    email = row[7].ToString();
                    address = row[2].ToString();
                }

                string enc = fullName + "*" + phone + "*" + ntn + "*" + email + "*" + address;
                txtLocalKey.Text = Cryptography.Encrypt(enc, Constants.CryptographyKey);
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            string custId = "", custName = "", subscDate = "", renewalDate = "";

            if (txtRegKey.Text.Trim().Length > 0)
            {
                try
                {
                    string decrypted = Cryptography.Decrypt(txtRegKey.Text.Trim(), Constants.CryptographyKey);
                    string[] delimitted = decrypted.Split('*');

                    if (keyName.Equals("Renewal"))
                    {
                        if (delimitted.Length == 5)
                        {
                            // then its OK 
                            if (delimitted[4].Equals("renewal"))
                            {
                                // then its ok
                            }
                            else
                            {
                                MessageBox.Show("Invalid " + keyName + " Key");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid " + keyName + " Key");
                            return;
                        }
                    }

                    custId = delimitted[0];
                    custName = delimitted[1];
                    subscDate = delimitted[2];
                    renewalDate = delimitted[3];

                    if (!string.IsNullOrEmpty(custId) && !string.IsNullOrEmpty(custName)
                        && !string.IsNullOrEmpty(subscDate) && !string.IsNullOrEmpty(renewalDate))
                    {
                        bool validate = companyName == custName;
                        if (validate)
                        {
                            string encCustId = Cryptography.Encrypt(custId, Constants.CryptographyKey);
                            string encDtmLastModified = Cryptography.Encrypt(DateTime.Now.ToString("dd-MMM-yyyy HH:mm"), Constants.CryptographyKey);
                            string encSubscDate = Cryptography.Encrypt(subscDate, Constants.CryptographyKey);
                            string encRenewalDate = Cryptography.Encrypt(renewalDate, Constants.CryptographyKey);

                            var result = mDist.UpdateLicenseData(encCustId, encDtmLastModified, encSubscDate, encRenewalDate);
                            if (result)
                            {
                                if (keyName.Equals("Renewal"))
                                {
                                    MessageBox.Show("Reactivated successfully, now application will be restarted");
                                }
                                else
                                {
                                    MessageBox.Show("Activated successfully, now application will be restarted");
                                }
                                
                                //LOGOFF
                                Application.Restart();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect information, please contact CORN POS office");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incomplete information, please contact CORN POS office");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid "+ keyName + " Key");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please provide "+ keyName + " Key");
            }
            //MessageBox.Show(custId + " " + custName + " " + subscDate + " " + renewalDate);
        }
    }
}
