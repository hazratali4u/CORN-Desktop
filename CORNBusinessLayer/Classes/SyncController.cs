using System;
using System.Data;
using CORNDataAccessLayer.Classes;
using CORNDatabaseLayer.Classes;
using CORNCommon.Classes;
using System.Collections;
using CORNDatabaseLayer.InputClasses;
using System.Windows.Forms;

namespace CORNBusinessLayer.Classes
{
 
	public class SyncController
	{
        #region Constructors
        public SyncController()
		{
			//
			// TODO: Add constructor logic here
			//
			 
		}
		#endregion					
		
		#region LIVE API METHODS
        
        public static DataTable GetLocations()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spLiveGetLocations liveGetLocs = new spLiveGetLocations();
                liveGetLocs.Connection = mConnection;
                DataTable dt = liveGetLocs.ExecuteTable();
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

        public static DataTable GetTills(int p_location_ID, int p_TYPEID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectTil liveTills = new spSelectTil();
                liveTills.Connection = mConnection;
                liveTills.LOCATION_ID = p_location_ID;
                liveTills.TYPEID = p_TYPEID;
                DataTable dt = liveTills.ExecuteTable();
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

        public static DataTable GetShifts(int p_location_ID, int p_TYPEID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectShift liveShifts = new spSelectShift();
                liveShifts.Connection = mConnection;
                liveShifts.LOCATION_ID = p_location_ID;
                liveShifts.TYPEID = p_TYPEID;

                DataTable dt = liveShifts.ExecuteTable();
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

        public static DataTable GetPrincipals(int pSkuTypeHieId, int pCompanyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPRINCIPAL mPrincipal = new spSelectPRINCIPAL();
                mPrincipal.Connection = mConnection;
                mPrincipal.SKU_HIE_TYPE_ID = pSkuTypeHieId;
                mPrincipal.COMPANY_ID = pCompanyid;
                DataTable dt = mPrincipal.ExecuteTable();
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

        public static DataTable GetSkuHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, bool p_Is_Active, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
                mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
                mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
                mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
                mSkuHierarchy.TIME_STAMP = Constants.DateNullValue;
                mSkuHierarchy.LASTUPDATE_DATE = Constants.DateNullValue;
                mSkuHierarchy.IP_ADDRESS = null;
                mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;


                DataTable dt = mSkuHierarchy.ExecuteTable();
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
        public static DataTable GetAllCustomers(int p_Distributor_Id, int p_Area, int p_Route)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
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

        public static DataTable GetAllUser(string p_LoginId, string p_Password)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelect_USER mSlashUser = new spSelect_USER();
                mSlashUser.Connection = mConnection;
                mSlashUser.LOGIN_ID = p_LoginId;
                mSlashUser.PASSWORD = p_Password;
                mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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

        public static DataTable GetDistributorUsers(int p_Type, int p_Distributor_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDISTRIBUTOR_USERInfo mDistUser = new uspSelectDISTRIBUTOR_USERInfo();
                mDistUser.Connection = mConnection;

                mDistUser.TYPE = p_Type;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;

                DataTable dt = mDistUser.ExecuteTable();
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

        public static DataTable GetRoleMaster(int p_Role_ID, string p_ROLE_NAME, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, bool p_IS_ACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectROLE_MASTER ObjSelect = new spSelectROLE_MASTER();
                ObjSelect.Connection = mConnection;
                ObjSelect.ROLE_ID = p_Role_ID;
                ObjSelect.ROLE_NAME = p_ROLE_NAME;
                ObjSelect.TIME_STAMP = p_TIME_STAMP;
                ObjSelect.LASTUPDATE_DATE = p_LASTUPDATE_DATE;

                DataTable dt = ObjSelect.ExecuteTable();
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

        public static DataTable GetRoleDetails()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectROLE_DETAIL01 ObjSelect = new spSelectROLE_DETAIL01();
                ObjSelect.Connection = mConnection;
                ObjSelect.ROLE_ID = Constants.IntNullValue;
                ObjSelect.ROLE_DETAIL_ID = Constants.IntNullValue;

                DataTable dt = ObjSelect.ExecuteTable();
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

        public static DataTable GetDistributorUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDistributorUserAssignment mUserAssing = new uspSelectDistributorUserAssignment();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.DISTRIBUTOR_ID = DistributorId;
                mUserAssing.COMPANY_ID = Companyid;
                DataTable dt = mUserAssing.ExecuteTable();
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

        public static DataTable GetSkus(int p_company_id, int p_division_id, int p_category_id, int p_brand_id, int Companyid, int p_TAGID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(LiveConfiguration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSkuInfo2 mspSelectSkuInfo = new uspSelectSkuInfo2();
                mspSelectSkuInfo.brand_id = p_brand_id;
                mspSelectSkuInfo.category_id = p_category_id;
                mspSelectSkuInfo.Principal_id = p_company_id;
                mspSelectSkuInfo.Connection = mConnection;
                mspSelectSkuInfo.division_id = p_division_id;
                mspSelectSkuInfo.Company_id = Companyid;
                mspSelectSkuInfo.TAG_ID = p_TAGID;

                DataTable dt = mspSelectSkuInfo.ExecuteTable();

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

        //      #region LOCAL DB INSERTIONS 

        //      public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int Companyid)
        //{
        //	IDbConnection mConnection = null;
        //	try
        //	{
        //		mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //		mConnection.Open();
        //		uspSelectDistributorInfo mDistributorInfo = new uspSelectDistributorInfo();
        //		mDistributorInfo.Connection = mConnection;
        //		mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_ID;
        //              mDistributorInfo.USER_ID = p_User_Id;
        //              mDistributorInfo.COMPANY_ID = Companyid;   

        //		DataTable dt = mDistributorInfo.ExecuteTable();
        //		return dt;

        //	}
        //	catch(Exception exp)
        //	{
        //		ExceptionPublisher.PublishException(exp);				
        //		return null;
        //	}
        //	finally
        //	{
        //		if(mConnection != null && mConnection.State == ConnectionState.Open)
        //		{
        //			mConnection.Close();
        //		}
        //	}

        //}

        //      public DataTable GetLicenseData()
        //      {
        //          DataTable dt = new DataTable();

        //          IDbConnection mConnection = null;
        //          try
        //          {
        //              mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //              if (mConnection == null)
        //              {

        //              }
        //              mConnection.Open();

        //              uspGetLicenseData obj = new uspGetLicenseData();
        //              obj.Connection = mConnection;
        //              dt = obj.ExecuteTable();
        //              return dt;

        //          }
        //          catch (Exception exp)
        //          {
        //              MessageBox.Show(exp.Message);
        //              ExceptionPublisher.PublishException(exp);
        //              return null;
        //          }
        //          finally
        //          {
        //              if (mConnection != null && mConnection.State == ConnectionState.Open)
        //              {
        //                  mConnection.Close();
        //              }
        //          }
        //      }

        //      public bool UpdateLicenseData(string custId, string dtmLastModified, string subscDate, string renewalDate)
        //      {
        //          IDbConnection mConnection = null;
        //          try
        //          {
        //              mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //              mConnection.Open();
        //              uspUpdateLicense mLicense = new uspUpdateLicense();
        //              mLicense.Connection = mConnection;
        //              mLicense.SUBSCDATE = subscDate;
        //              mLicense.RENEWALDATE = renewalDate;
        //              mLicense.CUSTID = custId;
        //              mLicense.DTMLASTMOD = dtmLastModified;

        //              mLicense.ExecuteQuery();

        //              return true;

        //          }
        //          catch (Exception exp)
        //          {
        //              ExceptionPublisher.PublishException(exp);
        //              return false;
        //          }
        //          finally
        //          {
        //              if (mConnection != null && mConnection.State == ConnectionState.Open)
        //              {
        //                  mConnection.Close();
        //              }
        //          }

        //      }
        //      public string InsertLicense(int p_DAYS, string p_LICENSE, DateTime p_TRANSACTION_DATE)
        //      {
        //          IDbConnection mConnection = null;
        //          try
        //          {
        //              mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //              mConnection.Open();
        //              uspInsertLicense mLicense = new uspInsertLicense();
        //              mLicense.Connection = mConnection;
        //              mLicense.DAYS = p_DAYS;
        //              mLicense.LICENSE = p_LICENSE;
        //              mLicense.TRANSACTION_DATE = p_TRANSACTION_DATE;

        //              mLicense.ExecuteQuery();

        //              return "Record Inserted";

        //          }
        //          catch (Exception exp)
        //          {
        //              ExceptionPublisher.PublishException(exp);
        //              return null;
        //          }
        //          finally
        //          {
        //              if (mConnection != null && mConnection.State == ConnectionState.Open)
        //              {
        //                  mConnection.Close();
        //              }
        //          }
        //      }

        //      #endregion
    }
}
