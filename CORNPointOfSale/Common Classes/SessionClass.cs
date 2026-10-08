using System;
using System.Windows.Forms;
using CORNCommon.Classes;
using System.Data;

namespace CORN
{
    static class SessionClass
    {
        #region int (Session Varialbles)

        public static int LoginStatus = Constants.IntNullValue;
        public static int UserID = Constants.IntNullValue;
        public static int DISTRIBUTOR_ID = Constants.IntNullValue;
        public static int PRINCIPAL_ID = Constants.IntNullValue;
        public static int CompanyID = Constants.IntNullValue;

        #endregion

        #region long (Session Varialbles)

        public static long CustomerID = Constants.LongNullValue;

        #endregion

        #region Datatable (Session Varialbles)

        public static DataTable dtCustomer = null;

        #endregion

        #region Datetime (Session Varialbles)

        public static DateTime CurrentWorkDate = Constants.DateNullValue;

        #endregion

        #region Bool

        public static bool IsDiscountAllowed = false;

        #endregion

        #region String

        public static string UserName = string.Empty;

        #endregion

        #region Price Lookup

        public static bool bFromPriceLookup = false;

        #endregion

        #region Reports

        public static int ReportType = 1;
        
        public static DataSet ds = null;
        
        public static string HirarchyNameQuiz = string.Empty;
        public static string lbluserlogin = string.Empty;
        public static string lblLoacation = string.Empty;
        public static string CompanyPhonNmbr = string.Empty;

        public static DateTime dtFrom = Constants.DateNullValue;
        public static DateTime dtTo = Constants.DateNullValue;
        #endregion
    }
}
