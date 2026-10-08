using System;
using System.Windows.Forms;
using CORNCommon.Classes;
using System.Data;
using CORNBusinessLayer.Classes;

namespace CORNPointOfSale
{
    static class SessionClass
    {
        #region int (Session Varialbles)

        public static int LoginStatus = Constants.IntNullValue;
        public static int UserID = Constants.IntNullValue;
        public static int DISTRIBUTOR_ID = Constants.IntNullValue;
        public static int PRINCIPAL_ID = Constants.IntNullValue;
        public static int CompanyID = Constants.IntNullValue;
        public static int RoleID = Constants.IntNullValue;
        public static int Til_ID { get; set; }
        public static int Shift_ID { get; set; }
        public static int ISREPRINT { get; set; }
        public static bool Is_POS_USER = false;
        //public static int LoginStatus = Constants.IntNullValue;
        //public static int UserID = 2;
        //public static int DISTRIBUTOR_ID = 2;
        //public static int PRINCIPAL_ID = 3;
        //public static int CompanyID = 1;
        public static bool DashboardViewOnly = true;

        #endregion

        #region long (Session Varialbles)

        public static long CustomerID = Constants.LongNullValue;
        public static long User_Log_ID = Constants.LongNullValue;

        #endregion

        #region Datatable (Session Varialbles)

        public static DataTable dtCustomer = null;
        public static DataTable dtNotes = null;
        public static DataTable dtLicenseData { get; set; }
        public static DataTable dtLoadPOSItems { get; set; }    // used in POS and item barcode form
        public static DataTable dtLoadItemsForStockRegister { get; set; }
        public static DataTable dtCategoryItemPriceHistory { get; set; }
        public static DataTable dtItemPriceHistory { get; set; }
        public static DataTable dtItemDetail { get; set; } // physical Stock
        public static DataTable dtItemLookup { get; set; } // Item Lookup in POS


        #endregion

        #region Datetime (Session Varialbles)

        public static DateTime CurrentWorkDate = Constants.DateNullValue;

        #endregion

        #region Bool

        public static bool IsDiscountAllowed = false;
        public static bool IsExpired = false;
        

        #endregion

        #region String

        public static string UserName = string.Empty;
        public static string UserName2 = string.Empty;
        public const string AppVersion = "Personal Edition";
        public static string CompanyName = string.Empty;

        public static string PoweredBy = string.Empty;
        public static string Version = string.Empty;
        public static string Edition = string.Empty;

        public static string ReceiptPrintSize = "3Inch"; // 3Inch encrypted form value => ChqoCWQFfP4= 
        public static string SalePriceEdit = "False"; // False encrypted form value => NaZvTV4ZSxU= 

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

        public static CORNBusinessLayer.Reports.RegionWiseSaleReport CrpReport { get; set; }
        #endregion

        #region Promotion (Session Variables)

        public static string PromotionId { get; set; }
        public static bool IsEditing { get; set; }
        public static string flow { get; set; }
        public static SchemeCollection_Controller SchCtrl { get; set; }
        public static clsListItems[] SchemeListItems { get; set; }
        public static clsListItems[] clsSKUGroupItems { get; set; }
        public static clsListItems[] clsUOMItems { get; set; }
        public static clsDetailListItems[] DistributorListItems { get; set; }
        public static clsDetailListItems[] CustTypeListItems { get; set; }
        public static clsDetailListItems[] CustListItems { get; set; }
        public static clsListItems[] clsSKUItems { get; set; }
        public static DataTable dt { get; set; }
        public static int SlabNo { get; set; }
        public static string IsEdit { get; set; }

        #endregion

        public static DataSet dsDataset { get; set; }

        public static int IsValidComputer { get; set; }

        public static int ShowDeliveryman { get; set; }

        public static byte[] InvLogo { get; set; }

        public static bool ShowLogo { get; set; }
    }
}
