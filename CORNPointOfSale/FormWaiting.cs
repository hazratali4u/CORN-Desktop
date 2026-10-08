using System;
using System.ComponentModel;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.Runtime.InteropServices;

namespace CORNPointOfSale
{
    public partial class FormWaiting : Form
    {
        public static int _Type { get; set; }
        public static int _SubType { get; set; }
        public static int _CategoryID { get; set; } // Only Used in Item Price History ----- Type = 4

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public FormWaiting()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        private void FormWaiting_Load(object sender, EventArgs e)
        {
            circularProgress1.IsRunning = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Type == 0) // Item Prices
            {
                SkuController SKUCtl = new SkuController();
                SessionClass.dtLoadPOSItems = SKUCtl.SearchProduct(null, 5, SessionClass.DISTRIBUTOR_ID);
            }
            if (_Type == 1) // Item Barcode
            {
                SkuController SKUCtl = new SkuController();
                SessionClass.dtLoadPOSItems = SKUCtl.SearchProduct(null, 4, SessionClass.DISTRIBUTOR_ID); 
            }
            else if (_Type == 2)  // Stock Register
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                SessionClass.dtLoadItemsForStockRegister = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 12, SessionClass.CurrentWorkDate);
            }
            else if (_Type == 3)  // Stock Adjustment
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                SessionClass.dtLoadItemsForStockRegister = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 11, SessionClass.CurrentWorkDate);
            }
            else if (_Type == 4)  //Item Price History
            {
                if (_SubType == 1)
                {
                    SkuHierarchyController sController = new SkuHierarchyController();
                    SessionClass.dtCategoryItemPriceHistory = sController.SelectSKUCategories(Constants.IntNullValue, Constants.IntNullValue, true); 
                }
                if (_SubType == 2)
                {
                    SkuController mContoller = new SkuController();
                    SessionClass.dtItemPriceHistory = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, _CategoryID, Constants.IntNullValue, Constants.IntNullValue); 
                }
            }
            else if (_Type == 5)    // Physical Stock
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                SessionClass.dtItemDetail = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()), int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 47, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            }
            else if (_Type == 6)    // For Price Lookup in POS
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                SessionClass.dtItemLookup = PController.SelectDataPrice(null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 1, SessionClass.CurrentWorkDate);
            }
            else if (_Type == 7)    // Dashboard
            {
                SessionClass.dsDataset = CornPointHelper.DashboardClass.GetDashboardDataSet("DashboardProcedure");
            }
            if (_Type == 8) // POS 
            {
                SkuController SKUCtl = new SkuController();
                SessionClass.dtLoadPOSItems = SKUCtl.SearchProduct(null, 6, SessionClass.DISTRIBUTOR_ID);
            }
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
