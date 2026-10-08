using System;
using System.Data;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using CORNDatabaseLayer.Classes;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace CORNBusinessLayer.Classes
{
    /// <summary>
    /// Class For SKU Price Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert SKU Prices
    /// </item>
    /// <item>
    /// Get SKU Prices
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class SKUPriceDetailController
    {
        #region Constructors

        /// <summary>
        /// Constructor For SKUPriceDetailController
        /// </summary>
        public SKUPriceDetailController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets SKU Price Data
        /// </summary>
        /// <remarks>
        /// Returns SKU Price Data as Datatable
        /// </remarks>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Division_ID">Division</param>
        /// <param name="p_Category_ID">Category</param>
        /// <param name="p_Brand_id">Brand</param>
        /// <param name="p_Var_Id">Variant</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_sku_id">SKU</param>
        /// <param name="p_Type_id">Type</param>
        /// <param name="p_ClosedDate">CloseDate</param>
        /// <returns>SKU Price Data as Datatable</returns>
        public DataTable SelectDataPrice(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspSelectSKUPriceList ObjSelect = new UspSelectSKUPriceList();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = p_Principal_Id;
                ObjSelect.DIVISION_ID = p_Division_ID;
                ObjSelect.CATEGORY_ID = p_Category_ID;
                ObjSelect.BRAND_ID = p_Brand_id;
                ObjSelect.VAR_ID = p_Var_Id;
                ObjSelect.SKU_ID = p_sku_id;
                ObjSelect.TYPEID = p_Type_id;
                ObjSelect.USER_ID = p_User_Id;
                ObjSelect.DAYCLOSED = p_ClosedDate;
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
        public DataTable SelectDataPrice(string pSkuCode, int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspSelectSKUPriceList ObjSelect = new UspSelectSKUPriceList();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = p_Principal_Id;
                ObjSelect.DIVISION_ID = p_Division_ID;
                ObjSelect.CATEGORY_ID = p_Category_ID;
                ObjSelect.BRAND_ID = p_Brand_id;
                ObjSelect.VAR_ID = p_Var_Id;
                ObjSelect.SKU_ID = p_sku_id;
                ObjSelect.TYPEID = p_Type_id;
                ObjSelect.USER_ID = p_User_Id;
                ObjSelect.DAYCLOSED = p_ClosedDate;
                ObjSelect.skuCode = pSkuCode;
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

        public DataTable SelectDataPrice2(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspSelectSKUPriceList2 ObjSelect = new UspSelectSKUPriceList2();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = p_Principal_Id;
                ObjSelect.DIVISION_ID = p_Division_ID;
                ObjSelect.CATEGORY_ID = p_Category_ID;
                ObjSelect.BRAND_ID = p_Brand_id;
                ObjSelect.VAR_ID = p_Var_Id;
                ObjSelect.SKU_ID = p_sku_id;
                ObjSelect.TYPEID = p_Type_id;
                ObjSelect.USER_ID = p_User_Id;
                ObjSelect.DAYCLOSED = p_ClosedDate;
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

        /// <summary>
        /// Gets SKU Current Price Data
        /// </summary>
        /// <remarks>
        /// Returns SKU Current Price Data as Datatable
        /// </remarks>
        /// <param name="p_Uom_id">UOM</param>
        /// <param name="p_Company_id">Principal</param>
        /// <param name="p_Division_Id">Division</param>
        /// <param name="p_Brand_Id">Brand</param>
        /// <param name="p_Category_Id">Category</param>
        /// <param name="variant_Id">Variant</param>
        /// <param name="p_Iscurrent">IsCurrent</param>
        /// <param name="p_sku_id">SKU</param>
        /// <returns>SKU Current Price Data as Datatable</returns>
        public DataTable SelectSKuCurrentPrice(int p_Uom_id, int p_Company_id, int p_Division_Id, int p_Brand_Id, int p_Category_Id, int variant_Id, int p_Iscurrent, int p_sku_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectskuPriceInfo mSkuInfo = new spSelectskuPriceInfo();
                mSkuInfo.Connection = mConnection;

                mSkuInfo.UOM_ID = p_Uom_id;
                mSkuInfo.COMPANY_ID = p_Company_id;
                mSkuInfo.DIVISION_ID = p_Division_Id;
                mSkuInfo.BRAND_ID = p_Brand_Id;
                mSkuInfo.CATEGORY_ID = p_Category_Id;
                mSkuInfo.VARIANT_ID = variant_Id;
                mSkuInfo.ISACTIVE = true;
                mSkuInfo.ISCURRENT = p_Iscurrent;
                mSkuInfo.SKU_Id = p_sku_id;

                DataTable dt = mSkuInfo.ExecuteTable();
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

        #region Insert

        public string InsertSKU_PRICES(int p_Distributor_Id, int p_Sku_Id, int p_Uom_Id, decimal p_Distributor_Discount, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, DateTime p_date_effected, decimal p_SED_Tax, decimal WholesalePrice)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspProcessSKU_Prices mSkuPrices = new UspProcessSKU_Prices();
                mSkuPrices.Connection = mConnection;
                mSkuPrices.DISTRIBUTOR_ID = p_Distributor_Id;
                mSkuPrices.DISTRIBUTOR_PRICE = p_Distributor_Price;
                mSkuPrices.SKU_ID = p_Sku_Id;
                mSkuPrices.RETAIL_PRICE = p_Retail_Price;
                mSkuPrices.TAX_PRICE = p_Tax_Price;
                mSkuPrices.TRADE_PRICE = p_Trade_Price;
                mSkuPrices.DISTRIBUTOR_DISCOUNT = p_Distributor_Discount;
                mSkuPrices.TIME_STAMP = System.DateTime.Now;
                mSkuPrices.LASTUPDATE_DATE = System.DateTime.Now;
                mSkuPrices.DATE_EFFECTED = p_date_effected;
                mSkuPrices.SED_TAX = p_SED_Tax;
                mSkuPrices.WHOLESALE_PRICE = WholesalePrice;
                mSkuPrices.ExecuteQuery();
                return "Record Inserted";

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

        public bool ImportSKUPrices(int p_DistributorId, string pFileName, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spSelectSKUS mSKUS = new spSelectSKUS();
                    mSKUS.Connection = mConnection;
                    mSKUS.Transaction = mTransaction;
                    mSKUS.SKU_CODE = ParametersArr[0].ToString();
                    mSKUS.ISACTIVE = true;
                    DataTable dt = mSKUS.ExecuteTable();
                    if (dt.Rows.Count > 0)
                    {
                        UspProcessSKU_Prices mSKUPrice = new UspProcessSKU_Prices();
                        mSKUPrice.Connection = mConnection;
                        mSKUPrice.Transaction = mTransaction;
                        mSKUPrice.SKU_ID = int.Parse(dt.Rows[0]["SKU_Id"].ToString());
                        mSKUPrice.DISTRIBUTOR_ID = p_DistributorId;
                        mSKUPrice.PRINCIPAL_ID = p_Principal_Id;
                        mSKUPrice.DISTRIBUTOR_PRICE = decimal.Parse(ParametersArr[1].ToString());
                        mSKUPrice.TRADE_PRICE = decimal.Parse(ParametersArr[2].ToString());
                        mSKUPrice.RETAIL_PRICE = decimal.Parse(ParametersArr[3].ToString());
                        mSKUPrice.DISTRIBUTOR_DISCOUNT = decimal.Parse(ParametersArr[4].ToString());
                        mSKUPrice.TAX_PRICE = decimal.Parse(ParametersArr[5].ToString());
                        mSKUPrice.SED_TAX = decimal.Parse(ParametersArr[6].ToString());
                        mSKUPrice.DATE_EFFECTED = DateTime.Parse(ParametersArr[7].ToString());
                        mSKUPrice.WHOLESALE_PRICE = decimal.Parse(ParametersArr[8].ToString());
                        mSKUPrice.LASTUPDATE_DATE = DateTime.Now;
                        mSKUPrice.TIME_STAMP = DateTime.Now;
                        mSKUPrice.ExecuteQuery();
                    }

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
                throw;
                return false;
            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();
            }
        }

        public bool ImportSKUWithPrices(int p_DistributorId,int companyid,int userid, string pFileName)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {
                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spSelectSKUS mSKUS = new spSelectSKUS();
                    mSKUS.Connection = mConnection;
                    mSKUS.Transaction = mTransaction;
                    mSKUS.SKU_CODE = ParametersArr[1].ToString();
                    mSKUS.ISACTIVE = true;
                    DataTable dt = mSKUS.ExecuteTable();
                    if (dt.Rows.Count > 0)
                    {
                        continue;
                    }

                    spInsertSKUS2 mSkus = new spInsertSKUS2();
                    mSkus.Connection = mConnection;
                    mSkus.Transaction = mTransaction;
                    mSkus.SKU_NAME = ParametersArr[0].ToString();
                    mSkus.SKU_CODE = ParametersArr[1].ToString();
                    mSkus.BAR_CODE = "Manual";
                    mSkus.PRINCIPAL_ID = int.Parse(ParametersArr[2].ToString());    // Saction
                    mSkus.CATEGORY_ID = int.Parse(ParametersArr[3].ToString());
                    mSkus.PACKSIZE = ParametersArr[4].ToString();
                    mSkus.COLOR = ParametersArr[5].ToString();
                    mSkus.ISEXEMPTED = bool.Parse(ParametersArr[6].ToString());
                    mSkus.ISACTIVE = bool.Parse(ParametersArr[7].ToString());
                    mSkus.GST_ON = char.Parse(ParametersArr[8].ToString());
                    mSkus.MinLevel = int.Parse(ParametersArr[9].ToString());
                    mSkus.MaxLevel = int.Parse(ParametersArr[10].ToString());
                    mSkus.REORDER_LEVEL = int.Parse(ParametersArr[11].ToString());
                    mSkus.COMPANY_ID = companyid;
                    mSkus.USER_ID = userid;

                    mSkus.DIVISION_ID = 0;
                    mSkus.BRAND_ID = 0;
                    mSkus.SKU_TAG_ID = 0;
                    mSkus.SKU_SEASON = "";
                    mSkus.SKU_COUNTRY = "";
                    mSkus.GST_RATE_REG = 0;
                    mSkus.GST_RATE_UNREG = 0;
                    mSkus.TIME_STAMP = System.DateTime.Now;
                    mSkus.LASTUPDATE_DATE = System.DateTime.Now;
                    mSkus.IP_ADDRESS = null;
                    mSkus.ExecuteQuery();

                    UspProcessSKU_Prices mSkuPrices = new UspProcessSKU_Prices();
                    mSkuPrices.Connection = mConnection;
                    mSkuPrices.Transaction = mTransaction;
                    mSkuPrices.DISTRIBUTOR_ID = p_DistributorId;
                    mSkuPrices.DISTRIBUTOR_PRICE = decimal.Parse(ParametersArr[12].ToString());
                    mSkuPrices.SKU_ID = mSkus.SKU_ID;
                    mSkuPrices.RETAIL_PRICE = 0;
                    mSkuPrices.TRADE_PRICE = decimal.Parse(ParametersArr[13].ToString());
                    mSkuPrices.TAX_PRICE = decimal.Parse(ParametersArr[14].ToString());
                    mSkuPrices.WHOLESALE_PRICE = decimal.Parse(ParametersArr[15].ToString());
                    mSkuPrices.DISTRIBUTOR_DISCOUNT = 0;
                    mSkuPrices.TIME_STAMP = System.DateTime.Now;
                    mSkuPrices.LASTUPDATE_DATE = System.DateTime.Now;
                    mSkuPrices.SED_TAX = 0;
                    mSkuPrices.DATE_EFFECTED = DateTime.Parse(ParametersArr[16].ToString());
                    mSkuPrices.ExecuteQuery();
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
                throw;
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
