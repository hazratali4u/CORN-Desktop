using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using System.Threading;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormSplash : Form
    {
        DistributorController mDist = new DistributorController();
        public FormSplash()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }
        private void FormSplash_Load(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SessionClass.dtLicenseData = mDist.GetLicenseData();
            if (SessionClass.dtLicenseData == null)
            {
                btnexist_Click(null, null);
            }
            SessionClass.IsValidComputer = 1;
            //if (System.Configuration.ConfigurationManager.AppSettings["ComputerInfo"].ToString() == CORNCommon.Classes.Cryptography.Encrypt(CORNCommon.Classes.ComputerInfo.Value(), Constants.CryptographyKey))
            //{
            //    SessionClass.IsValidComputer = 1;
            //}
            //else
            //{
            //    SessionClass.IsValidComputer = 0;
            //}


            // NOW first DOWNLOAD/SYNC MASTER DATA from SERVER
            int days = 0;
            int max_days = 0;
            bool IsMasterNotSynced = false;
            DataTable dtLicenseData = SessionClass.dtLicenseData;
            try
            {
                days = Convert.ToInt32(Cryptography.Decrypt(dtLicenseData.Rows[0]["DIAS"].ToString(), Constants.CryptographyKey));
                max_days = Convert.ToInt32(Cryptography.Decrypt(dtLicenseData.Rows[0]["MAX_DIAS"].ToString(), Constants.CryptographyKey));
                if(dtLicenseData.Rows[0]["DECNYSTONRETSAMSI"] != DBNull.Value)
                {
                    IsMasterNotSynced = Convert.ToBoolean(Cryptography.Decrypt(dtLicenseData.Rows[0]["DECNYSTONRETSAMSI"].ToString(), Constants.CryptographyKey));
                }

                //IsMasterNotSynced = true;
                if (IsMasterNotSynced && max_days > days)
                {
                    SessionClass.CompanyID = 1;

                    //now start sync LOCATIONS
                    DataTable dt = SyncController.GetLocations();
                    if (dt != null)
                    {
                        byte[] imageData = null;
                        // insert into location table now
                        foreach (DataRow row in dt.Rows)
                        {
                            imageData = null;
                            if (!row.IsNull("Logo"))
                            {
                                imageData = (byte[])row["Logo"];
                            }

                            new DistributorController().InsertDistributor(Convert.ToInt32(row["COMPANY_ID"]),
                                Convert.ToInt32(row["DIST_CLASS_ID"]), Convert.ToBoolean(row["ISDELETED"]),
                                Convert.ToDateTime(row["TIME_STAMP"]), Convert.ToDateTime(row["LASTUPDATE_DATE"]),
                                //Convert.ToInt32(row["DIVISION_ID"]), Convert.ToInt32(row["USER_ID"]),
                                //Convert.ToInt32(row["REGION_ID"]), Convert.ToInt32(row["ZONE_ID"]),
                                Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,
                                Convert.ToInt32(row["SUBZONE_ID"]),
                                row["CONTACT_PERSON"] != null ? row["CONTACT_PERSON"].ToString() : null,
                                row["CONTACT_NUMBER"] != null ? row["CONTACT_NUMBER"].ToString() : null,
                                row["GST_NUMBER"] != null ? row["GST_NUMBER"].ToString() : null,
                                row["PASSWORD"] != null ? row["PASSWORD"].ToString() : null,
                                row["ADDRESS1"] != null ? row["ADDRESS1"].ToString() : null,
                                row["ADDRESS2"] != null ? row["ADDRESS2"].ToString() : null,
                                row["DISTRIBUTOR_CODE"] != null ? row["DISTRIBUTOR_CODE"].ToString() : null,
                                row["DISTRIBUTOR_NAME"] != null ? row["DISTRIBUTOR_NAME"].ToString() : null,
                                row["IP_ADDRESS"] != null ? row["IP_ADDRESS"].ToString() : null,
                                Convert.ToBoolean(row["IS_REGISTERED"]), Convert.ToInt32(row["CREDIT_LEVEL"]),
                                Constants.IntNullValue,
                                //(byte[])row["Logo"], 
                                imageData,
                                Convert.ToBoolean(row["ShowLogo"]),
                                Convert.ToInt32(row["DISTRIBUTOR_ID"]));

                        }
                    }
                    //now start sync TILLS
                    DataTable dtTills = SyncController.GetTills(0, 1);
                    if (dtTills != null)
                    {
                        // insert into TILLS table now
                        foreach (DataRow row in dtTills.Rows)
                        {
                            new UserController().InsertTil(Convert.ToInt32(row["LOCATION_ID"]),
                                row["TIL_DESCRIPTION"].ToString(), 0, Convert.ToInt32(row["TIL_ID"]));
                        }
                    }

                    //now start sync Shifts
                    DataTable dtShifts = SyncController.GetShifts(0, 2);
                    if (dtShifts != null)
                    {
                        // insert into SHIFT table now
                        foreach (DataRow row in dtShifts.Rows)
                        {
                            new Distributor_UserController().InsertShift(Convert.ToInt32(row["LOCATION_ID"]),
                                row["Start Time"].ToString(), row["End Time"].ToString(), Convert.ToInt32(row["SHIFT_ID"]));
                        }
                    }


                    //now start sync SUPPLIERS
                    DataTable dtSuppliers = SyncController.GetPrincipals(Constants.SKUPrincipal, SessionClass.CompanyID);
                    if (dtSuppliers != null)
                    {
                        // insert into SUPPLIER table now
                        foreach (DataRow row in dtSuppliers.Rows)
                        {
                            SessionClass.DISTRIBUTOR_ID = Convert.ToInt32(row["COMPANY_ID"]);

                            new SkuHierarchyController().InsertPrincipal(Constants.SKUPrincipal,
                                Constants.IntNullValue, "",
                                row["SKU_HIE_NAME"].ToString(), null, Convert.ToBoolean(row["IS_ACTIVE"]),
                                Convert.ToInt32(row["COMPANY_ID"]), Convert.ToBoolean(row["IS_MANUALDISCOUNT"]),
                                row["ADDRESS"] != null ? row["ADDRESS"].ToString() : null,
                                row["NTN"] != null ? row["NTN"].ToString() : null,
                                row["STRN"] != null ? row["STRN"].ToString() : null,
                                row["CONTACT_PERSON"] != null ? row["CONTACT_PERSON"].ToString() : null,
                                row["FaxNumber"] != null ? row["FaxNumber"].ToString() : null,
                                SessionClass.DISTRIBUTOR_ID, Convert.ToInt32(row["Opening_Type"]), Convert.ToInt32(row["Opening_Amount"]),
                                SessionClass.CurrentWorkDate, Convert.ToInt32(row["SKU_HIE_ID"]), Convert.ToInt32(row["PRINCIPAL_ADDRESS_ID"]));
                        }
                    }

                    //now start sync ITEM HIERARCHY i.e. SECTIONS - CATEGORIES - BRANDS

                    DataTable dtSections = SyncController.GetSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                    if (dtSections != null)
                    {
                        // insert into SKU HIERARCHY table FOR SECTION now
                        foreach (DataRow row in dtSections.Rows)
                        {
                            new SkuHierarchyController().InsertHierarchy(Constants.SKUSection,
                                0, null,
                                row["SKU_HIE_NAME"].ToString(), null,
                                Convert.ToBoolean(row["IS_ACTIVE"]),
                                SessionClass.CompanyID, Convert.ToInt32(row["SKU_HIE_ID"]));
                        }
                    }

                    DataTable dtCats = SyncController.GetSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                    if (dtCats != null)
                    {
                        // insert into SKU HIERARCHY table FOR CATEGORY now
                        foreach (DataRow row in dtCats.Rows)
                        {
                            new SkuHierarchyController().InsertHierarchy(Constants.SKUCategory,
                                Convert.ToInt32(row["PARENT_SKU_HIE_ID"]), null,
                                row["SKU_HIE_NAME"].ToString(), null,
                                Convert.ToBoolean(row["IS_ACTIVE"]),
                                SessionClass.CompanyID, Convert.ToInt32(row["SKU_HIE_ID"]));
                        }
                    }

                    DataTable dtBrands = SyncController.GetSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                    if (dtBrands != null)
                    {
                        // insert into SKU HIERARCHY table FOR BRAND now
                        foreach (DataRow row in dtBrands.Rows)
                        {
                            new SkuHierarchyController().InsertHierarchy(Constants.SKUBrand,
                                0, null,
                                row["SKU_HIE_NAME"].ToString(), null,
                                Convert.ToBoolean(row["IS_ACTIVE"]),
                                SessionClass.CompanyID, Convert.ToInt32(row["SKU_HIE_ID"]));
                        }
                    }

                    //now start sync CUSTOMERS
                    DataTable dtCust = SyncController.GetAllCustomers(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
                    if (dtCust != null)
                    {
                        // insert into CUSTOMERS table now
                        foreach (DataRow row in dtCust.Rows)
                        {

                            new CustomerDataController().InsertCustomer(Convert.ToInt32(row["CUSTOMER_ID"]),
                                Convert.ToBoolean(row["IS_GST_REGISTERED"]), Convert.ToBoolean(row["IS_ACTIVE"]),
                                Constants.IntNullValue, Convert.ToInt32(row["PROMOTION_CLASS"]),
                                Constants.IntNullValue, 0, Constants.IntNullValue, Constants.IntNullValue,
                                Convert.ToInt32(row["DISTRIBUTOR_ID"]), "", "", row["CONTACT_NUMBER"].ToString(),
                                row["EMAIL_ADDRESS"].ToString(), row["CUSTOMER_CODE"].ToString(),
                                row["CUSTOMER_NAME"].ToString(), row["ADDRESS"].ToString(),
                                Convert.ToDateTime(row["REGDATE"]), 1, 1, row["CNIC"].ToString(), "",
                                Convert.ToInt32(row["Opening_Type"]), Convert.ToInt32(row["Opening"]),
                                Convert.ToInt32(row["USER_ID"]), Convert.ToDateTime(row["DOCUMENT_DATE"]));

                        }
                    }


                    //now start sync ROLE
                    DataTable dtRole = SyncController.GetRoleMaster(0, null, DateTime.Today, DateTime.Today, true);
                    if (dtRole != null)
                    {
                        // insert into ROLE table now
                        foreach (DataRow row in dtRole.Rows)
                        {
                            new RoleManagementController().InsertRoleMaster(row["ROLE_NAME"].ToString(),
                                Convert.ToDateTime(row["TIME_STAMP"]), Convert.ToDateTime(row["LASTUPDATE_DATE"]),
                                true, Convert.ToInt32(row["ROLE_ID"]));
                        }
                    }

                    //now start sync ROLE DETAILS
                    DataTable dtRoleDet = SyncController.GetRoleDetails();
                    if (dtRoleDet != null)
                    {
                        // insert into ROLE table now
                        foreach (DataRow row in dtRoleDet.Rows)
                        {
                            new RoleManagementController().InsertRoleDetail(Convert.ToInt32(row["ROLE_ID"]),
                                Convert.ToInt32(row["MODULE_ID"]), 1, Convert.ToInt32(row["ROLE_DETAIL_ID"]));
                        }
                    }

                    //now start sync Employees i.e. DISTRIBUTOR USERS
                    DataTable dtEmps = SyncController.GetDistributorUsers(Constants.IntNullValue, Constants.IntNullValue, SessionClass.CompanyID);
                    if (dtEmps != null)
                    {
                        // insert into DISTRIBUTOR USERS table now
                        foreach (DataRow row in dtEmps.Rows)
                        {
                            new Distributor_UserController().InsertDistributor_User(SessionClass.CompanyID,
                                row["NIC_NO"].ToString(), Convert.ToBoolean(row["IS_ACTIVE"]),
                                Convert.ToDateTime(row["TIME_STAMP"]), Convert.ToDateTime(row["LASTUPDATE_DATE"]),
                                Convert.ToInt32(row["USER_TYPE_ID"]), Convert.ToInt32(row["DISTRIBUTOR_ID"]),
                                Constants.IntNullValue, row["EMAIL"].ToString(),
                                row["ADDRESS1"].ToString(), row["ADDRESS2"].ToString(), "", "",
                                row["MOBILE"].ToString(), row["USER_CODE"].ToString(),
                                row["USER_NAME"].ToString(), row["PHONE"].ToString(),
                                Convert.ToInt32(row["SHIFT_ID"]), Convert.ToInt32(row["DEPARTMENT_ID"]),
                                Convert.ToInt32(row["USER_ID"]));
                        }
                    }

                    //now start sync USERS
                    DataTable dtUsers = SyncController.GetAllUser(null, null);
                    if (dtUsers != null)
                    {
                        // insert into USERS table now
                        foreach (DataRow row in dtUsers.Rows)
                        {
                            new UserController().InsertSlashUser(Convert.ToInt32(row["USER_ID"]),
                                Convert.ToInt32(row["COMPANY_ID"]), Convert.ToInt32(row["DISTRIBUTOR_ID"]),
                                row["LOGIN_ID"].ToString(), row["PASSWORD"].ToString(),
                                Convert.ToInt32(row["ROLE_ID"]), Convert.ToBoolean(row["IsDiscountAllowed"]),
                                Convert.ToInt32(row["Til"]));
                        }
                    }

                    //now start sync DISTRIBUTOR AND USER ASSINMENTS DETAILS
                    DataTable dtDistUsrAssigns = SyncController.GetDistributorUserAssignment(0, 0, 0, SessionClass.CompanyID);
                    if (dtDistUsrAssigns != null)
                    {
                        // insert into DISTRIBUTOR_ASSIGNMENT table now
                        foreach (DataRow row in dtDistUsrAssigns.Rows)
                        {
                            new UserController().InsertUserAssignment(Convert.ToInt32(row["USER_ID"]),
                                Convert.ToInt32(row["DISTRIBUTOR_TYPE"]),
                                Convert.ToInt32(row["DISTRIBUTOR_ID"]),
                                Convert.ToInt32(row["DISTRIBUTOR_ID"]));
                        }
                    }

                    //now start sync SKUS DETAILS
                    DataTable dtSkus = SyncController.GetSkus(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.CompanyID, Constants.IntNullValue);
                    if (dtSkus != null)
                    {
                        // insert into SKUS table now
                        foreach (DataRow row in dtSkus.Rows)
                        {
                            try
                            {
                                //var uom = row["UOM_ID"];
                                //int uomIntVal = Constants.IntNullValue;
                                //if (uom != DBNull.Value)
                                //{
                                //    uomIntVal = Convert.ToInt32(row["UOM_ID"]);
                                //}

                                new SkuController().InsertSKUS2(true, true, char.Parse(row["GST_ON"].ToString()),
                                    Convert.ToInt32(row["Principal_Id"]), Convert.ToInt32(row["DIVISION_ID"]),
                                    Convert.ToInt32(row["CATEGORY_ID"]), Convert.ToInt32(row["BRAND_ID"]),
                                    Constants.IntNullValue, 0, 0,
                                    row["UNITS_IN_CASE"].ToString(), row["SKU_Code"].ToString(),
                                    row["SKU_NAME"].ToString(), null,
                                    row["PACKSIZE"].ToString(), Convert.ToInt32(row["USER_ID"]),
                                    SessionClass.CompanyID, row["BAR_CODE"].ToString(), null, 0, "", "",
                                    Convert.ToInt32(row["MinLevel"]), Convert.ToInt32(row["MaxLevel"]),
                                    Convert.ToInt32(row["REORDER_LEVEL"]),
                                    Convert.ToInt32(row["DISTRIBUTOR_ID"]),
                                    Convert.ToDecimal(row["DISTRIBUTOR_PRICE"]),
                                    Convert.ToDecimal(row["TRADE_PRICE"]),
                                    Convert.ToDecimal(row["WHOLESALE_PRICE"]),
                                    Convert.ToDecimal(row["TAX_PRICE"]),
                                    Convert.ToDateTime(row["DATE_EFFECTED"]), 0,
                                    row["WS_QUANTITY"] != DBNull.Value ? Convert.ToDecimal(row["WS_QUANTITY"]) : 0,
                                    row["UOM_ID"] != DBNull.Value ? Convert.ToInt32(row["UOM_ID"]) : Constants.IntNullValue,
                                    Convert.ToInt32(row["SKU_ID"]));
                            }
                            catch (Exception ex)
                            {
                                //var ab = ex.Message;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                backgroundWorker1.ReportProgress(100);
                return;
            }
            
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                backgroundWorker1.ReportProgress(100);
                return;
            }
            backgroundWorker1.ReportProgress(100);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblError.Text = "Database Connection Lost";
            }
            else
            {                
                //if (Screen.PrimaryScreen.Bounds.Height >= 768 && SessionClass.IsValidComputer == 1)
                //{
                    FormLogin _formLogin = new FormLogin();
                    _formLogin.Show();
                    this.Hide();
                //}
                //else
                //{
                //    if (SessionClass.IsValidComputer == 0)
                //    {
                //        lblError.Text = "Invalid Key.\n Please Contact to Administrator";
                //    }
                //    else
                //    {
                //        lblError.Text = "Application doesn't Support Current Resolution.\nYour Current Resolution Height is less than 768."; 
                //    }
                //}
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarX1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
            progressBarX1.Value = e.ProgressPercentage;
        }

        private void btnexist_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
