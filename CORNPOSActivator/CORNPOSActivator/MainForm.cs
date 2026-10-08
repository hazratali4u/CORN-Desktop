using CORNCommon.Classes;
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
    public partial class MainForm : Form
    {
        APICaller call = new APICaller();
        DataTable custList;
        public MainForm()
        {
            InitializeComponent();
            //txtKey.Text = "e/h4L35aGf/RL/dTjtNk0WsFrS0oI7JP8Ww9X7so6yqffhGsg76Gdy1k29n+JX9/2FqwP+4c7Xp/98Hxf8ZpDw6+6+5wN9fKqVmUfvFMe7JWPfZgB3kC0w==";
            cmbSalutation.SelectedIndex = 0;
            bwCustCombo_DoWork(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();
            if (txtKey.Text.Trim().Length > 0)
            {
                try
                {
                    //string enc = "Faisal and Co Pvt Ltd*03354000021*3930-4390*faisal@email.com*20 lahore town lahore";
                    //txtKey.Text = Cryptography.Encrypt(enc, Cryptography.CryptographyKey);
                    string decrypted = Cryptography.Decrypt(txtKey.Text.Trim(), Cryptography.CryptographyKey);
                    string[] delimitted = decrypted.Split('*');
                    if (delimitted.Length == 5 && !delimitted[4].Equals("renewal"))
                    {
                        txtCustomerName.Text = delimitted[0];
                        txtPhone.Text = delimitted[1];
                        txtNtn.Text = delimitted[2];
                        txtEmail.Text = delimitted[3];
                        txtAddress.Text = delimitted[4];
                    }
                    else
                    {
                        ClearCustomerFields();
                        MessageBox.Show("Please provide valid customer key");
                    }

                }
                catch (Exception ex)
                {
                    ClearCustomerFields();
                    MessageBox.Show("Please provide valid customer key");

                }
            }
            else
            {
                MessageBox.Show("Please provide customer key");
            }
        }
        public void ClearCustomerFields()
        {
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtNtn.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbSalutation.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim().Length == 0 || txtPhone.Text.Trim().Length == 0 ||
                txtNtn.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 ||
                txtAddress.Text.Trim().Length == 0 || txtFirstName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter all fields data\n" +
                                "Customer Name\n" +
                                "Phone No\n" +
                                "NTN\n" +
                                "Email\n" +
                                "Address\n" +
                                "Contact Person First Name and Last Name");
            }
            else
            {
                // save to team suite now 
                try
                {
                    SpData data = new SpData
                    {
                        SpName = "[CRM].[procActivationKeyGenSaveCustomer]",
                        Parameters = new Dictionary<string, object>
                        {
                            { "UserCode", APIResult.UserID },
                            { "FullName", txtCustomerName.Text.Trim() },
                            { "Phone", txtPhone.Text.Trim() },
                            { "NTN", txtNtn.Text.Trim() },
                            { "OfficialEmail", txtEmail.Text.Trim() },
                            { "Address", txtAddress.Text.Trim() },
                            { "Salutation", cmbSalutation.Text.Trim() },
                            { "FirstName", txtFirstName.Text.Trim() },
                            { "LastName", txtLastName.Text.Trim() }
                        }
                    };

                    var result = call.ExecStoreProcedure(data);
                    long totalRows = 0;
                    if (result != null)
                    {
                        foreach (DataRow row in result.Rows)
                        {
                            totalRows = Convert.ToInt64(row[0].ToString());
                        }

                        if (totalRows > 0)
                        {
                            MessageBox.Show("Saved successfully!!!");
                            ClearCustomerFields();
                            txtKey.Clear();
                            bwCustCombo_DoWork(null, null);
                        }
                        else if (totalRows == -1)
                        {
                            MessageBox.Show("Customer already exist");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save the customer");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong!!!\n" + ex.Message);
                }
            }
        }

        private void bwCustCombo_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadComboBoxCustomer();
        }
        private void LoadComboBoxCustomer()
        {
            try
            {
                SpData data = new SpData
                {
                    SpName = "[CRM].[procActivationKeyGenCustomersList]",
                    Parameters = new Dictionary<string, object>
                        {
                            { "UserCode", APIResult.UserID }
                        }
                };

                var result = call.ExecStoreProcedure(data);
                custList = result;

                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.ValueMember = "ID";
                cmbCustomer.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer list is not populated");
            }
        }

        private void btnRebind_Click(object sender, EventArgs e)
        {
            bwCustCombo_DoWork(null, null);
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmbVal = Convert.ToInt64(cmbCustomer.SelectedValue);
            if (cmbVal > 0)
            {
                foreach (DataRow row in custList.Rows)
                {
                    if (cmbVal == Convert.ToInt64(row[0]))
                    {
                        txtSubscDate.Text = Convert.ToDateTime(row[2]).ToString("dd-MMM-yyyy");
                        txtRenewalDate.Text = Convert.ToDateTime(row[3]).ToString("dd-MMM-yyyy");
                        txtActivationKey.Clear();
                        txtRenewalKey.Clear();
                        break;
                    }
                    else
                    {
                        txtSubscDate.Text = "";
                        txtRenewalDate.Text = "";
                    }
                }
            }
            else
            {
                txtSubscDate.Text = "";
                txtRenewalDate.Text = "";
                txtActivationKey.Clear();
                txtRenewalKey.Clear();
            }

        }

        private void btnActivationKey_Click(object sender, EventArgs e)
        {
            var cmbVal = Convert.ToInt64(cmbCustomer.SelectedValue);
            if (cmbVal > 0)
            {
                foreach (DataRow row in custList.Rows)
                {
                    if (cmbVal == Convert.ToInt64(row[0]))
                    {
                        txtSubscDate.Text = Convert.ToDateTime(row[2]).ToString("dd-MMM-yyyy");
                        txtRenewalDate.Text = Convert.ToDateTime(row[3]).ToString("dd-MMM-yyyy");

                        var txtToEnc = row[0] + "*" + row[1] + "*" + txtSubscDate.Text + "*" + txtRenewalDate.Text;
                        txtActivationKey.Text = Cryptography.Encrypt(txtToEnc, Cryptography.CryptographyKey);
                        txtRenewalKey.Clear();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select customer");
                txtActivationKey.Clear();
            }
        }

        private void btnRenewalKey_Click(object sender, EventArgs e)
        {
            var cmbVal = Convert.ToInt64(cmbCustomer.SelectedValue);
            if (cmbVal > 0)
            {
                foreach (DataRow row in custList.Rows)
                {
                    if (cmbVal == Convert.ToInt64(row[0]))
                    {
                        txtSubscDate.Text = Convert.ToDateTime(row[2]).ToString("dd-MMM-yyyy");
                        txtRenewalDate.Text = Convert.ToDateTime(row[3]).ToString("dd-MMM-yyyy");

                        var txtToEnc = row[0] + "*" + row[1] + "*" + txtSubscDate.Text + "*" + txtRenewalDate.Text + "*renewal";
                        txtRenewalKey.Text = Cryptography.Encrypt(txtToEnc, Cryptography.CryptographyKey);
                        txtActivationKey.Clear();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select customer");
                txtRenewalKey.Clear();
            }
        }
    }
}