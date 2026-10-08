using System;
using System.Data;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using CORNDatabaseLayer.Classes;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using CORNDatabaseLayer.InputClasses;

namespace CORNBusinessLayer.Classes
{
    /// <summary>
    /// Class For Customer Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Customer
    /// </item>
    /// <term>
    /// Update Customer
    /// </term>
    /// <item>
    /// Get Customer
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class CustomerDataController
    {
        #region Constructor

        /// <summary>
        /// Constructor For CustomerDataController
        /// </summary>
        public CustomerDataController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Private Variables

        IDbTransaction mTransaction;
        IDbConnection mConnection;

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets Customer Credit Limit
        /// </summary>
        /// <remarks>
        /// Returns Customer Credit Limit as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <returns>Customer Credit Limit as Datatable</returns>
        public DataTable SelectCustomerCreditLimit(int p_Distributor_Id, long p_CustomerId, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCUSTOMER_PRINCIPAL_CREDITLIMIT mCustomer = new spSelectCUSTOMER_PRINCIPAL_CREDITLIMIT();
                mCustomer.Connection = mConnection;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.CUSTOMER_ID = p_CustomerId;
                mCustomer.PRINCIPAL_ID = p_Principal_Id;
                DataTable dt = mCustomer.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets All Customers Opening Credit
        /// </summary>
        /// <remarks>
        /// Returns All Customers Opening Credit as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Document_Date"></param>
        /// <returns>All Customers Opening Credit as Datatable</returns>
        public DataTable SelectOpeningCredit(int p_Distributor_Id, DateTime p_Document_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectOpCredit mDistGeoArea = new UspSelectOpCredit();
                mDistGeoArea.Connection = mConnection;
                mDistGeoArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistGeoArea.DOCUMENT_DATE = p_Document_Date;
                DataTable dt = mDistGeoArea.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        //-------------------------Select Credit Amount---------------------------------------
        public decimal SelectCreditAmount(int p_Distributor_Id, int p_CustomerID,DateTime p_fromdate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCurrentCreditAmount mCreditAmount = new spSelectCurrentCreditAmount();
                mCreditAmount.Connection = mConnection;
                mCreditAmount.DISTRIBUTOR_ID = p_Distributor_Id;
                mCreditAmount.CUSTOMER_ID = p_CustomerID;
                mCreditAmount.FROMDATE = p_fromdate;
                object obj = mCreditAmount.ExecuteScalar();
                return Math.Round(Convert.ToDecimal(obj), 2);
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return 0;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Gets Customers RouteWise
        /// </summary>
        /// <remarks>
        /// Returns Customers RouteWise as Datatable
        /// </remarks>
        /// <param name="strRoutes">Routes</param>
        /// <param name="strCustomerTypes">Type</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <returns>Customers RouteWise as Datatable</returns>
        public DataTable SelectCustomerByRoute(string strRoutes, string strCustomerTypes, int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectRouteCustomer mCustomer = new uspSelectRouteCustomer();
                mCustomer.Connection = mConnection;

                mCustomer.ROUTES = strRoutes;
                mCustomer.CUSTOMER_TYPES = strCustomerTypes;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                DataTable dt = mCustomer.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customer With Invoices
        /// </summary>
        /// <remarks>
        /// Retruns Customers With Invoices as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_document_date">Date</param>
        /// <returns>Customers With Invoices as Datatable</returns>
        public DataTable SelectPrincipalCustomer(int p_Distributor_Id, int p_PrincipalId, DateTime p_document_date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectInvoiceBuiltyInfo mCustData = new UspSelectInvoiceBuiltyInfo();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.PRINCIPAL_ID = p_PrincipalId;
                mCustData.Document_date = p_document_date;
                mCustData.CUSTOMER_ID = Constants.LongNullValue;
                mCustData.PRINCIPAL_ID = p_PrincipalId;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customers
        /// </summary>
        /// <remarks>
        /// Returns Customers as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Area">Market</param>
        /// <param name="p_Route">Route</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>Customers as Datatable</returns>
        public DataTable SelectPrincipalCustomer(int p_Distributor_Id, int p_Area, int p_Route, int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPRINCIPALCUSTOMER mCustData = new UspSelectPRINCIPALCUSTOMER();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.AREA_ID = p_Area;
                mCustData.ROUTE_ID = p_Route;
                mCustData.PRINCIPAL_ID = p_PrincipalId;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_CODE";
                dt = dv.ToTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customers
        /// </summary>
        /// <remarks>
        /// Returns Customers as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Area">Market</param>
        /// <param name="p_Route">Route</param>
        /// <returns>Customers as Datatable</returns>
        public DataTable SelectAllCustomer(int p_Distributor_Id, int p_Area, int p_Route)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCUSTOMER mCustData = new spSelectCUSTOMER();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.AREA_ID = p_Area;
                mCustData.ROUTE_ID = p_Route;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customer Opening Balance
        /// </summary>
        /// <remarks>
        /// Returns Customer Opening Balance as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_fromDate">DateFrom</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>Customer Opening Balance as Datatable</returns>
        public DataTable SelectPrincipalCustomerOpBalance(int p_Distributor_Id, int p_CustomerId, DateTime p_fromDate, int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerOpBalance mCustData = new UspCustomerOpBalance();
                mCustData.Connection = mConnection;

                mCustData.Distributor_id = p_Distributor_Id;
                mCustData.principal_id = p_PrincipalId;
                mCustData.From_Date = p_fromDate;
                mCustData.customer_id = p_CustomerId;
                DataTable dt = mCustData.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customer For Different Search Criterias
        /// </summary>
        /// <remarks>
        /// Returns Customer as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_FIELDNAME">FieldToSearchFor</param>
        /// <param name="p_PARAMETERNAME">ValueToSearch</param>
        /// <returns>Customer as Datatable</returns>
        public DataTable UspSelectCustomer(int p_Distributor_Id, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectCUSTOMER mCustData = new UspSelectCUSTOMER();
                mCustData.Connection = mConnection;
                mCustData.FEILDNAME = p_FIELDNAME;
                mCustData.PARAMETER = p_PARAMETERNAME;
                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                DataTable dt = mCustData.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customer For Different Search Criterias
        /// </summary>
        /// <remarks>
        /// Returns Customer as Datatable
        /// </remarks>
        /// <param name="p_User_Id">User</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_FIELDNAME">FieldToSearchFor</param>
        /// <param name="p_PARAMETERNAME">ValueToSearch</param>
        /// <returns>Customer as Datatable</returns>
        public DataTable UspSelectCustomer(int p_User_Id, int p_DistributorId, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptSelectCUSTOMER mCustData = new UspRptSelectCUSTOMER();
                mCustData.Connection = mConnection;
                mCustData.FEILDNAME = p_FIELDNAME;
                mCustData.PARAMETER = p_PARAMETERNAME;
                mCustData.USER_ID = p_User_Id;
                mCustData.DISTRIBUTOR_ID = p_DistributorId;
                DataTable dt = mCustData.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets Customer Credit/Advance Balance
        /// </summary>
        /// <remarks>
        /// Returns Customer Credit/Advance Balance
        /// </remarks>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="TranType">Type</param>
        /// <returns>Customer Credit/Advance Balance</returns>
        public DataTable SelectCustomerCreditBalance(long p_Customer_Id, int p_Principal_Id, int p_Distributor_id, int TranType)
        {
            IDbConnection mConnection = null;
            try
            {
                Configuration.GetAccountHead();

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectCustomerBalance mCustData = new UspSelectCustomerBalance();
                mCustData.Connection = mConnection;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal_Id;
                mCustData.DISTRIBUTOR_ID = p_Distributor_id;
                mCustData.TranType = TranType;
                mCustData.ACCOUNT_HEAD_ID = long.Parse(Configuration.AccountReceivable);

                DataTable dt = mCustData.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }


        public DataTable GetVendorPayment(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime p_VENDOR_LEDGER_DATE, int p_PAYMENT_MODE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetVendorPayment mLedgerDate = new uspGetVendorPayment();
                mLedgerDate.Connection = mConnection;
                mLedgerDate.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mLedgerDate.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mLedgerDate.VENDOR_LEDGER_DATE = p_VENDOR_LEDGER_DATE;
                mLedgerDate.PAYMENT_MODE = p_PAYMENT_MODE;
                DataTable dt = mLedgerDate.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        #endregion

        #region Insert, Update

        /// <summary>
        /// Shifts Customers Between Locations, Routes, Markets
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_fromDistributor_Id">LocationFrom</param>
        /// <param name="p_toDistributor">LocationTo</param>
        /// <param name="p_fromArea_Id">MarketFrom</param>
        /// <param name="p_to_area_id">MarketTo</param>
        /// <param name="p_FROM_ROUTE_ID">RouteFrom</param>
        /// <param name="p_TO_ROUTE_ID">RouteTo</param>
        /// <param name="p_CUSTOMER_ID">Customer</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool CustomerShifting(int p_fromDistributor_Id, int p_toDistributor, int p_fromArea_Id, int p_to_area_id, int p_FROM_ROUTE_ID, int p_TO_ROUTE_ID, int p_CUSTOMER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerShifting mCustomerShift = new UspCustomerShifting();
                mCustomerShift.Connection = mConnection;
                mCustomerShift.FROM_DISTRIBUTOR_ID = p_fromDistributor_Id;
                mCustomerShift.FROM_AREA_ID = p_fromArea_Id;
                mCustomerShift.TO_DISTRIBUTOR_ID = p_toDistributor;
                mCustomerShift.TO_AREA_ID = p_to_area_id;
                mCustomerShift.FROM_ROUTE_ID = p_FROM_ROUTE_ID;
                mCustomerShift.TO_ROUTE_ID = p_TO_ROUTE_ID;
                mCustomerShift.CUSTOMER_ID = p_CUSTOMER_ID;
                mCustomerShift.ExecuteQuery();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Inserts Customer Credit Limit
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Principal">Principal</param>
        /// <param name="p_CreditLimit">CreditLimit</param>
        /// <param name="p_CreditDays">CreditDays</param>
        /// <param name="p_ChannelTypeId">Channel</param>
        /// <param name="p_Category">Category</param>
        /// <param name="p_class">Class</param>
        /// <param name="p_Type">Type</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool InsertCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit, int p_CreditDays, int p_ChannelTypeId, int p_Category, string p_class, string p_Type, bool p_IsActive)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT mCustData = new spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT();

                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal;
                mCustData.CREDITLIMIT_VALUE = p_CreditLimit;
                mCustData.TIME_STAMP = DateTime.Today;
                mCustData.CREDIT_DAYS = p_CreditDays;
                mCustData.BUSINESS_TYPE_ID = p_Category;
                mCustData.CHANNEL_TYPE_ID = p_ChannelTypeId;
                mCustData.CLASSFICATION = p_class;
                mCustData.CUSTOMER_TYPE = p_Type;
                mCustData.IS_ACTIVE = p_IsActive;
                mCustData.ExecuteQuery();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Updates Customer Credit Limit
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Principal">Principal</param>
        /// <param name="p_CreditLimit">CreditLimit</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdateCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCUSTOMER_PRINCIPAL_CREDITLIMIT mCustData = new spUpdateCUSTOMER_PRINCIPAL_CREDITLIMIT();

                mCustData.Connection = mConnection;
                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal;
                mCustData.CREDITLIMIT_VALUE = p_CreditLimit;

                mCustData.ExecuteQuery();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Inserts Customer
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated Customer Code " + Inserted Customer ID On Success And "Some Error Update Record" On Failure
        /// </remarks>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Is_Gst_Registered">IsGSTReg</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="p_Channel_Type_Id">Type</param>
        /// <param name="p_Volume_Class_Id">Class</param>
        /// <param name="p_Business_Type_Id">BusinessType</param>
        /// <param name="p_Area_Id">Market</param>
        /// <param name="p_Route_Id">Route</param>
        /// <param name="p_Town_Id">Town</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Gst_Number">GSTNumber</param>
        /// <param name="p_Contact_Person">ContactPerson</param>
        /// <param name="p_Contact_Number">ContactNo</param>
        /// <param name="p_Email_Address">Email</param>
        /// <param name="p_Customer_Code">Code</param>
        /// <param name="p_Customer_Name">Name</param>
        /// <param name="p_Address">Address</param>
        /// <param name="p_RegDate">RegDate</param>
        /// <param name="p_Stand">Stand</param>
        /// <param name="p_Cooler">Cooler</param>
        /// <param name="p_CNIC">CNIC</param>
        /// <param name="p_NTN">NTN</param>
        /// <returns>"Record Updated Customer Code " + Inserted Customer ID On Success And "Some Error Update Record" On Failure</returns>
        public string InsertCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active, int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id, int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id,
                       string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address, string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate, byte p_Stand, byte p_Cooler, string p_CNIC, string p_NTN, int openingType, int openingAmount, int userID, DateTime currentDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertCUSTOMER mCustomer = new spInsertCUSTOMER();
                mCustomer.Connection = mConnection;
                mCustomer.Transaction = mTransaction;
                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.CNIC = p_CNIC;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.NTN = p_NTN;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.PROMOTION_CLASS = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.TOWN_ID = p_Town_Id;

                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.IS_COOLER = p_Cooler;
                mCustomer.IS_STAND = p_Stand;
                mCustomer.ExecuteQuery();
                //--------------------------------------------------------------
                spInsertSALE_INVOICE_MASTER2 mISom = new spInsertSALE_INVOICE_MASTER2();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;
                mISom.DISTRIBUTOR_ID = p_Distributor_Id;
                mISom.MANUAL_INVOICE_ID = "0";
                mISom.PRINCIPAL_ID = 0;
                mISom.AREA_ID = Constants.Credit_Amount_Id;
                mISom.DELIVERYMAN_ID = 0;
                mISom.ORDERBOOKER_ID = 0;
                mISom.DOCUMENT_DATE = currentDate;
                mISom.SOLD_TO = p_Customer_Id;
                mISom.TOTAL_AMOUNT = openingAmount;
                mISom.EXTRA_DISCOUNT_AMOUNT = 0;
                mISom.STANDARD_DISCOUNT_AMOUNT = 0;
                mISom.GST_AMOUNT = 0;
                mISom.SCHEME_AMOUNT = 0;
                mISom.IS_DELETED = false;
                mISom.TOTAL_NET_AMOUNT = openingAmount;

                mISom.CREDIT_AMOUNT = openingAmount;
                mISom.CURRENT_CREDIT_AMOUNT = openingAmount;

                if (openingType == 1) // Credit
                {
                    mISom.TOWN_ID = 1;
                }
                if (openingType == 2) // Debit
                {
                    mISom.TOWN_ID = 2;
                }
                mISom.USER_ID = userID;
                mISom.SALE_ORDER_ID = -1;
                mISom.TST_AMOUNT = 0;
                mISom.SED_AMOUNT = 0;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.LASTUPDATE_DATE = System.DateTime.Now;
                mISom.AUTHORISED_PERSON = null;
                mISom.IS_DELETED = false;
                mISom.POSTING = 0;
                mISom.TIL_ID = 0;
                mISom.SHIFT_ID = 0;
                mISom.LEGEND_ID = 25;
                mISom.ExecuteQuery();
                //--------------------------------------------------------------
                LedgerController LController = new LedgerController();
                Configuration.GetAccountHead();
                DistributorController Dcontroller = new DistributorController();
                string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_Id, 0);
                if (openingType == 1) // Credit
                {
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, Convert.ToDecimal(openingAmount), Convert.ToDecimal(0), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                }
                if (openingType == 2) // Debit
                {
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                    LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, Convert.ToDecimal(openingAmount), 0, currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                }
                return "1";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "0";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Inserts Or Updates Customer Tagging
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_saleInvoiceId">Invoice</param>
        /// <param name="p_CreditType">Type</param>
        /// <param name="p_CreditAmount">Amount</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdateCustomerTaging(long p_saleInvoiceId, int p_CreditType, decimal p_CreditAmount, string p_Remarks)
        {

            IDbConnection mConnection = null;
            try
            {
                spInsertCUSTOMER_CREDITTAGING mCustData = new spInsertCUSTOMER_CREDITTAGING();
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mCustData.Connection = mConnection;
                mCustData.SALE_INVOICE_ID = p_saleInvoiceId;
                mCustData.CREDIT_TYPE = p_CreditType;
                mCustData.CREDIT_AMOUNT = p_CreditAmount;
                mCustData.REMARKS = p_Remarks;
                return mCustData.ExecuteQuery();

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Updates Customer
        /// </summary>
        /// <remarks>
        /// Returns "Record Updated Customer Code " + Inserted Customer ID On Success And "Some Error Update Record" On Failure
        /// </remarks>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Is_Gst_Registered">GSTReg</param>
        /// <param name="p_Is_Active">IsActive</param>
        /// <param name="p_Channel_Type_Id">Channel</param>
        /// <param name="p_Volume_Class_Id">Class</param>
        /// <param name="p_Business_Type_Id">BusinessType</param>
        /// <param name="p_Area_Id">Market</param>
        /// <param name="p_Route_Id">Route</param>
        /// <param name="p_Town_Id">Town</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Gst_Number">GSTNo</param>
        /// <param name="p_Contact_Person">ContactPerson</param>
        /// <param name="p_Contact_Number">ContactNo</param>
        /// <param name="p_Email_Address">Email</param>
        /// <param name="p_Customer_Code">Code</param>
        /// <param name="p_Customer_Name">Name</param>
        /// <param name="p_Address">Address</param>
        /// <param name="p_RegDate">RegDate</param>
        /// <param name="p_Stand">Stand</param>
        /// <param name="p_Cooler">Cooler</param>
        /// <param name="p_CNIC">CNIC</param>
        /// <param name="p_NTN">NTN</param>
        /// <returns>"Record Updated Customer Code " + Inserted Customer ID On Success And "Some Error Update Record" On Failure</returns>
        public string UpdateCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active,
                       int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id, int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id, string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address,
                       string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate, byte p_Stand, byte p_Cooler, string p_CNIC, string p_NTN, int openingType, int openingAmount, int userID, DateTime currentDate, int p_saleInvoiceID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCUSTOMER mCustomer = new spUpdateCUSTOMER();
                mCustomer.Connection = mConnection;

                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.CNIC = p_CNIC;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.NTN = p_NTN;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.PROMOTION_CLASS = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.IS_COOLER = p_Cooler;
                mCustomer.IS_STAND = p_Stand;
                mCustomer.ExecuteQuery();
                if (p_Area_Id == 1) // if day is not closed yet after customer is added
                {
                    if (p_saleInvoiceID == 0)
                    {
                        spInsertSALE_INVOICE_MASTER2 mISom = new spInsertSALE_INVOICE_MASTER2();
                        mISom.Connection = mConnection;
                        mISom.Transaction = mTransaction;
                        mISom.DISTRIBUTOR_ID = p_Distributor_Id;
                        mISom.MANUAL_INVOICE_ID = "0";
                        mISom.PRINCIPAL_ID = 0;
                        mISom.AREA_ID = Constants.Credit_Amount_Id;
                        mISom.DELIVERYMAN_ID = 0;
                        mISom.ORDERBOOKER_ID = 0;
                        mISom.DOCUMENT_DATE = currentDate;
                        mISom.SOLD_TO = p_Customer_Id;
                        mISom.TOTAL_AMOUNT = openingAmount;
                        mISom.EXTRA_DISCOUNT_AMOUNT = 0;
                        mISom.STANDARD_DISCOUNT_AMOUNT = 0;
                        mISom.GST_AMOUNT = 0;
                        mISom.SCHEME_AMOUNT = 0;
                        mISom.IS_DELETED = false;
                        mISom.TOTAL_NET_AMOUNT = openingAmount;

                        mISom.CREDIT_AMOUNT = openingAmount;
                        mISom.CURRENT_CREDIT_AMOUNT = openingAmount;

                        if (openingType == 1) // Credit
                        {
                            mISom.TOWN_ID = 1;
                        }
                        if (openingType == 2) // Debit
                        {
                            mISom.TOWN_ID = 2;
                        }
                        mISom.USER_ID = userID;
                        mISom.SALE_ORDER_ID = -1;
                        mISom.TST_AMOUNT = 0;
                        mISom.SED_AMOUNT = 0;
                        mISom.TIME_STAMP = DateTime.Now;
                        mISom.LASTUPDATE_DATE = System.DateTime.Now;
                        mISom.AUTHORISED_PERSON = null;
                        mISom.IS_DELETED = false;
                        mISom.POSTING = 0;
                        mISom.TIL_ID = 0;
                        mISom.SHIFT_ID = 0;
                        mISom.LEGEND_ID = 25;
                        mISom.ExecuteQuery();
                        LedgerController LController = new LedgerController();
                        Configuration.GetAccountHead();
                        DistributorController Dcontroller = new DistributorController();
                        string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_Id, 0);
                        if (openingType == 1) // Credit
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, Convert.ToDecimal(openingAmount), Convert.ToDecimal(0), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                        }
                        if (openingType == 2) // Debit
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, Convert.ToDecimal(openingAmount), 0, currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                        }
                    }
                    //--------------------------------------------------------------
                    else
                    {

                        spUpdateSALE_INVOICE_MASTER mISom = new spUpdateSALE_INVOICE_MASTER();
                        mISom.Connection = mConnection;
                        mISom.Transaction = mTransaction;
                        mISom.SALE_INVOICE_ID = p_saleInvoiceID;
                        mISom.DISTRIBUTOR_ID = p_Distributor_Id;
                        //mISom.MANUAL_INVOICE_ID = "0";
                        mISom.PRINCIPAL_ID = 0;
                        mISom.AREA_ID = Constants.Credit_Amount_Id;
                        mISom.DELIVERYMAN_ID = 0;
                        mISom.ORDERBOOKER_ID = 0;
                        mISom.DOCUMENT_DATE = currentDate;
                        mISom.SOLD_TO = p_Customer_Id;
                        mISom.TOTAL_AMOUNT = openingAmount;
                        mISom.EXTRA_DISCOUNT_AMOUNT = 0;
                        mISom.STANDARD_DISCOUNT_AMOUNT = 0;
                        mISom.GST_AMOUNT = 0;
                        mISom.SCHEME_AMOUNT = 0;
                        mISom.IS_DELETED = false;
                        mISom.TOTAL_NET_AMOUNT = openingAmount;

                        mISom.CREDIT_AMOUNT = openingAmount;
                        mISom.CURRENT_CREDIT_AMOUNT = openingAmount;

                        if (openingType == 1) // Credit
                        {
                            mISom.TOWN_ID = 1;
                        }
                        if (openingType == 2) // Debit
                        {
                            mISom.TOWN_ID = 2;
                        }
                        mISom.USER_ID = userID;
                        mISom.SALE_ORDER_ID = -1;
                        //mISom.TST_AMOUNT = 0;
                        // mISom.SED_AMOUNT = 0;
                        mISom.TIME_STAMP = Constants.DateNullValue;
                        mISom.LASTUPDATE_DATE = System.DateTime.Now;
                        //mISom.AUTHORISED_PERSON = null;
                        mISom.IS_DELETED = false;
                        // mISom.POSTING = 0;
                        // mISom.TIL_ID = 0;
                        // mISom.SHIFT_ID = 0;
                        mISom.ExecuteQuery();
                        LedgerController LController = new LedgerController();
                        Configuration.GetAccountHead();
                        DistributorController Dcontroller = new DistributorController();
                        string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_Id, 0);
                        if (openingType == 1) // Credit
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, Convert.ToDecimal(openingAmount), Convert.ToDecimal(0), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                        }
                        if (openingType == 2) // Debit
                        {
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_Id, 0, Convert.ToDecimal(openingAmount), currentDate, "Opening Credit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                            LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_Id, Convert.ToDecimal(openingAmount), 0, currentDate, "Opening Debit", DateTime.Now, Constants.IntNullValue, Convert.ToInt32(p_Customer_Id), mISom.SALE_INVOICE_ID, "opng", Constants.Document_SaleInvoice, userID, mTransaction, mConnection, Constants.CreditSale, "");
                        }
                    }
                }
                return "Record Updated Customer Code " + p_Customer_Code;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Some error Update Record";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Inserts Customer From Excel File
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_TownId">Town</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="pFileName">ExcelFile</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool ImportCustomer(int p_TownId, int p_DistributorId, string pFileName)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;

            mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
            mConnection.Open();
            mTransaction = ProviderFactory.GetTransaction(mConnection);

            Sourcefile = new FileStream(pFileName, FileMode.Open);
            ReadSourceFile = new StreamReader(Sourcefile);
            string FileContents = "";
            try
            {
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spInsertCUSTOMER mDistRoute = new spInsertCUSTOMER();
                    mDistRoute.Connection = mConnection;
                    mDistRoute.Transaction = mTransaction;
                    mDistRoute.CUSTOMER_ID = long.Parse(ParametersArr[0].ToString());
                    mDistRoute.DISTRIBUTOR_ID = p_DistributorId;
                    mDistRoute.CUSTOMER_CODE = ParametersArr[1].ToString();
                    mDistRoute.CUSTOMER_NAME = ParametersArr[2].ToString();
                    mDistRoute.ADDRESS = ParametersArr[3].ToString();
                    mDistRoute.CONTACT_PERSON = ParametersArr[4].ToString();
                    mDistRoute.CONTACT_NUMBER = ParametersArr[5].ToString();
                    mDistRoute.IS_GST_REGISTERED = false;
                    mDistRoute.GST_NUMBER = null;
                    mDistRoute.IS_ACTIVE = true;
                    mDistRoute.REGDATE = System.DateTime.Now;
                    mDistRoute.TIME_STAMP = System.DateTime.Now;
                    mDistRoute.LASTUPDATE_DATE = System.DateTime.Now;
                    mDistRoute.TOWN_ID = p_TownId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[6].ToString());
                    mDistRoute.ROUTE_ID = int.Parse(ParametersArr[7].ToString());
                    mDistRoute.CHANNEL_TYPE_ID = int.Parse(ParametersArr[8].ToString());
                    mDistRoute.BUSINESS_TYPE_ID = int.Parse(ParametersArr[9].ToString());
                    mDistRoute.PROMOTION_CLASS = int.Parse(ParametersArr[10].ToString());
                    mDistRoute.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;


            }

            catch (Exception excp)
            {
                mTransaction.Rollback();
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }

        #endregion

        #endregion
    }
}
