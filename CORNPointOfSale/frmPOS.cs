using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.Drawing;
using System.Collections;
using DevComponents.DotNetBar;
using System.IO;
//using System.Runtime.InteropServices;

namespace CORNPointOfSale
{
    public partial class frmPOS : Office2007Form
    {
        #region Variables
        public static bool _frmCustomerEnable { get; set; }
        readonly DataControl _dc = new DataControl();
        readonly DistributorController _mDist = new DistributorController();
        readonly OrderEntryController _mOrderController = new OrderEntryController();
        readonly SKUPriceDetailController _pController = new SKUPriceDetailController();
        bool _paint = false;
        string _expiryDate;
        string PaymentMode;
        string mop;
        DataTable _dtSectionOrderID;
        string InvImage = "";
        DataTable _purchaseSku;
        DataTable _dtFreeSku;
        DataTable _customers;
        DataTable _dtSectionSaleHold;
        string _invoiceNumber;
        DataTable Dtsku_Price;
        DataTable _psDt = null;

        static int order = 0;
        long _saleInvId;
        decimal _cashRcd;
        decimal _ttamount;
        decimal _ntamount;
        decimal _discouunt;
        int _discountType;
        // private static int _mCustomerTypeId;
        private static int _mCustomerVolClassId;
        private int mTownId;
        private static int _rowId;
        private static int _unitType;
        public int Onhold = 0;
        public long NewCustomerId;
        private System.Drawing.Printing.PrintDocument _prnDocument;
        long _saleInvoiceId = 0;
        private int Credit_Note_id;
        public int PrintType;
        private readonly Font _saleFont = new Font("Arial Narrow", 8, FontStyle.Bold);
        private static string CompanyName;
        private static string HirarchyNameQuiz2; //AFTER COMPANY NAME ON INVOICE IP_ADDREES OF DISTRIBUTOR
        private static string Address;
        public static string CompanyPhonNmbr;
        public static string CompanyPhonNmbr1;
        public static string ntnNo;

        // for Report:
        private int CurrentY;
        private int CurrentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;

        private bool ReadInvoice;

        private int XNoOfuntit;
        private int YNoOfUnit;

        // for Invoice Head:
        private string InvTitle;
        private string InvTitle1;
        private string InvSubTitle1;
        private string InvSubTitle2;
        private string InvSubTitle3;
        private string InvSubTitle4;
        private string InvSubTitle5;
        private string InvSubTitle51;
        private string InvSubTitle52;
        // Font and Color:------------------
        // Title Font
        private Font InvTitleFont = new Font("Arial", 12, FontStyle.Bold);
        // Title Font height
        private int InvTitleHeight;
        private int InvSubTitleHeight;
        // SubTitle Font
        private Font InvSubTitleFont = new Font("Arial", 12, FontStyle.Regular);
        private Font InvSubTitle2Font = new Font("Arial", 7, FontStyle.Regular);
        private Font InvSubTitle3Font = new Font("Arial", 10, FontStyle.Regular);
        // private Font InvSubTitleFont4 = new Font("Arial", 12, FontStyle.Bold);
        // SubTitle Font height

        // Invoice Font
        private Font InvoiceFont = new Font("Arial", 9, FontStyle.Regular);
        private Font InvoiceFontBold = new Font("Arial", 9, FontStyle.Bold);
        private Font InvoiceFont2 = new Font("Arial", 7, FontStyle.Bold);
        private Font InvoiceFont3 = new Font("Arial", 7, FontStyle.Bold);
        private Font InvoiceFont4 = new Font("Arial", 7, FontStyle.Bold);
        private Font InvoiceFontNew = new Font("Arial", 7, FontStyle.Regular);
        // Invoice Font height
        private int InvoiceFontHeight;
        // Blue Color
        private readonly SolidBrush _blueBrush = new SolidBrush(Color.Blue);
        // Red Color
        private readonly SolidBrush _redBrush = new SolidBrush(Color.Red);
        // Black Color
        private readonly SolidBrush _blackBrush = new SolidBrush(Color.Black);

        PromotionCollections_Controller Arpc = new PromotionCollections_Controller();
        // Numeric Values set to right Align
        //StringFormat _stringFormateRight = new StringFormat(StringFormatFlags.DirectionRightToLeft);
        StringFormat _stringFormate = new StringFormat();
        #endregion

        DataTable dtOrder = new DataTable();
        OrderEntryController or = new OrderEntryController();
        long SALE_ORDER_ID = Constants.LongNullValue;

        public frmPOS()
        {
            InitializeComponent();
        }

        #region Buttons Cash/Credit/Both
        private void btnPayMode1_Click(object sender, EventArgs e)
        {
            RblPayMode1.Checked = true;
            txtBalance.Text = lblPayableAmount.Text;
            btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
            btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);

        }

        private void btnPayMode4_Click(object sender, EventArgs e)
        {
            RblPayMode4.Checked = true;
            btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
            btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            txtBalance.Text = "0.00";
        }

        private void btnPayMode3_Click(object sender, EventArgs e)
        {
            RblPayMode3.Checked = true;
            txtBalance.Text = "0.00";
            btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
            btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
        }

        private void btnPayMode2_Click(object sender, EventArgs e)
        {
            RblPayMode2.Checked = true;
            txtBalance.Text = lblPayableAmount.Text;
            btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
            btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
        }
        #endregion

        #region Set UI Colors
        public void SetColors()
        {
            //this.BackColor = Color.FromArgb(255, 178, 76, 90);
            this.BackColor = Color.FromArgb(255, 194, 77, 90);
            penalBottom.BackColor = Color.FromArgb(255, 194, 77, 90);

            //penalBottom.CanvasColor = Color.FromArgb(255, 194, 77, 90);
            //penalBottom.Style.BackColor = Color.FromArgb(255, 194, 77, 90);
            //penalBottom.Style.BackColor2 = Color.FromArgb(255, 194, 77, 90);

            PenalHeader.CanvasColor = Color.FromArgb(255, 194, 77, 90);
            PenalHeader.Style.BackColor = Color.FromArgb(255, 194, 77, 90);
            PenalHeader.Style.BackColor2 = Color.FromArgb(255, 194, 77, 90);
            //PenalCustomer.BackColor = Color.FromArgb(255, 218, 98, 98);
            PenalUnHold.BackColor = Color.FromArgb(255, 218, 98, 98);
            btnExit.BackColor = Color.FromArgb(255, 218, 98, 98);
            PenalRight.BackColor = Color.FromArgb(255, 42, 53, 66);
            PenalMain.BackColor = Color.FromArgb(255, 218, 98, 98);
            PenalPayment.BackColor = Color.FromArgb(255, 218, 98, 98);
            txtskuCode.BackColor = Color.FromArgb(255, 218, 98, 98);
            txtskuName.BackColor = Color.FromArgb(255, 218, 98, 98);
            txtQuantity.BackColor = Color.FromArgb(255, 218, 98, 98);
            txtUnitRate.BackColor = Color.FromArgb(255, 218, 98, 98);
            //drpCustomer.BackColor = Color.FromArgb(255, 218, 98, 98);
            //
            txtskuCode.Border.BorderColor = Color.FromArgb(255, 254, 135, 135);
            txtskuName.Border.BorderColor = Color.FromArgb(255, 254, 135, 135);
            txtQuantity.Border.BorderColor = Color.FromArgb(255, 254, 135, 135);
            txtUnitRate.Border.BorderColor = Color.FromArgb(255, 254, 135, 135);
            //drpCustomer.Border.BorderColor = Color.FromArgb(255, 254, 135, 135);
            //
            txtamount.BackColor = Color.FromArgb(255, 218, 98, 98);
            PenalUpSaleItems.BackColor = Color.FromArgb(255, 218, 98, 98);
            PenalLogHistory.BackColor = Color.FromArgb(255, 218, 98, 98);
            // Button Cash
            btnPayMode1.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Credit Card
            btnPayMode3.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Both
            btnPayMode2.StyleMouseOver.Alignment = StringAlignment.Center;
            // Credit
            btnPayMode4.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button View Sale Report
            btnViewSaleReport.CanvasColor = Color.FromArgb(205, 92, 92);
            btnViewSaleReport.Style.BackColor1.Color = Color.FromArgb(255, 218, 98, 98);
            btnViewSaleReport.Style.BackColor2.Color = Color.FromArgb(255, 218, 98, 98);
            btnViewSaleReport.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnViewSaleReport.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnViewSaleReport.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Reprint
            btnRePrint.CanvasColor = Color.FromArgb(205, 92, 92);
            btnRePrint.Style.BackColor1.Color = Color.FromArgb(255, 218, 98, 98);
            btnRePrint.Style.BackColor2.Color = Color.FromArgb(255, 218, 98, 98);
            btnRePrint.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnRePrint.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnRePrint.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button VOID
            btnCalculate.CanvasColor = Color.FromArgb(255, 244, 155, 108);
            btnCalculate.Style.BackColor1.Color = Color.FromArgb(255, 244, 155, 108);
            btnCalculate.Style.BackColor2.Color = Color.FromArgb(255, 244, 155, 108);
            //btnCalculate.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            //btnCalculate.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnCalculate.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Payment
            btnPayment.CanvasColor = Color.FromArgb(255, 15, 156, 134);
            btnPayment.Style.BackColor1.Color = Color.FromArgb(255, 15, 156, 134);
            btnPayment.Style.BackColor2.Color = Color.FromArgb(255, 15, 156, 134);
            //btnPayment.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            //btnPayment.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnPayment.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button New Customer
            btnNewCustomer.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnNewCustomer.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnNewCustomer.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnNewCustomer.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnNewCustomer.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnNewCustomer.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnNewCustomer.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Hold
            btnHold.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnHold.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnHold.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnHold.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnHold.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnHold.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnHold.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Un Hold
            btnUnhold.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnUnhold.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnUnhold.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnUnhold.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnUnhold.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnUnhold.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnUnhold.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Price Lookup
            btnPriceLookup.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnPriceLookup.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnPriceLookup.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnPriceLookup.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnPriceLookup.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnPriceLookup.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnPriceLookup.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Day Close
            btnDayClose.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnDayClose.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnDayClose.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnDayClose.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnDayClose.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnDayClose.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnDayClose.StyleMouseOver.Alignment = StringAlignment.Center;
            //// Button Exit
            btnExit.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            //btnExit.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            //btnExit.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            //btnExit.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            //btnExit.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            //btnExit.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnExit.StyleMouseOver.Alignment = StringAlignment.Center;
            // Button Sale Mode
            btnToggleMode.CanvasColor = Color.FromArgb(255, 115, 49, 49);
            btnToggleMode.Style.BackColor1.Color = Color.FromArgb(255, 115, 49, 49);
            btnToggleMode.Style.BackColor2.Color = Color.FromArgb(255, 115, 49, 49);
            btnToggleMode.Style.ForeColor.Color = Color.FromArgb(255, 255, 192, 192);
            btnToggleMode.StyleMouseOver.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            btnToggleMode.StyleMouseOver.BackColor2.Color = Color.FromArgb(255, 194, 77, 90);
            btnToggleMode.StyleMouseOver.Alignment = StringAlignment.Center;
            //TextBox Gross Sale
            txtGrossAmount.BackColor = Color.FromArgb(255, 57, 76, 88);
            txtGrossAmount.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            txtGrossAmount.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            txtGrossAmount.ForeColor = Color.FromArgb(255, 165, 220, 255);
            //TextBox numtxtTotalExtraDiscnt
            numtxtTotalExtraDiscnt.BackColor = Color.FromArgb(255, 57, 76, 88);
            numtxtTotalExtraDiscnt.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            numtxtTotalExtraDiscnt.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            numtxtTotalExtraDiscnt.ForeColor = Color.FromArgb(255, 165, 220, 255);
            //TextBox txtAuthorisedBy
            txtAuthorisedBy.BackColor = Color.FromArgb(255, 57, 76, 88);
            txtAuthorisedBy.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            txtAuthorisedBy.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            txtAuthorisedBy.ForeColor = Color.FromArgb(255, 165, 220, 255);
            //TextBox numTxtTotalGST
            numTxtTotalGST.BackColor = Color.FromArgb(255, 57, 76, 88);
            numTxtTotalGST.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            numTxtTotalGST.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            numTxtTotalGST.ForeColor = Color.FromArgb(255, 165, 220, 255);
            //TextBox numtxtTotalExtraDiscnt
            numTxtTotlAmnt.BackColor = Color.FromArgb(255, 57, 76, 88);
            numTxtTotlAmnt.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            numTxtTotlAmnt.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            numTxtTotlAmnt.ForeColor = Color.FromArgb(255, 165, 220, 255);
        }
        #endregion
        public void SetResolution()
        {
            PenalPaymentEnternal.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - 417, (Screen.PrimaryScreen.WorkingArea.Height / 2) - 214);
            //
            int MainPanelswidth = Screen.PrimaryScreen.WorkingArea.Width - 248;
            PenalMain.Width = MainPanelswidth;
            penalBottom.Width = MainPanelswidth;
            penalBottom.Location = new Point(PenalMain.Location.X, penalBottom.Location.Y);
            decimal width = Convert.ToDecimal(PenalMain.Width);
            decimal PercentageUpsale = 0.4316M;
            decimal PercentageLoginHistory = 0.37M;
            PenalLogHistory.Width = Convert.ToInt32(width * PercentageLoginHistory);
            PenalUpSaleItems.Width = Convert.ToInt32(width * PercentageUpsale);
            btnViewSaleReport.Width = Convert.ToInt32(width * 0.19M);
            btnRePrint.Width = Convert.ToInt32(width * 0.19M);
            reprintdate.Width = Convert.ToInt32(width * 0.19M);
            btnViewSaleReport.Location = new Point(PenalLogHistory.Width + (Convert.ToInt32(PenalMain.Width * 0.0045M)), btnViewSaleReport.Location.Y);
            btnRePrint.Location = new Point(PenalLogHistory.Width + (Convert.ToInt32(PenalMain.Width * 0.0045M)), btnRePrint.Location.Y);
            reprintdate.Location = new Point(PenalLogHistory.Width + (Convert.ToInt32(PenalMain.Width * 0.0045M)), reprintdate.Location.Y);
            SetGridColumnsWidth();
        }
        public void SetGridColumnsWidth()
        {
            GrdPurchase.Columns["SKU_NAME"].Width = Convert.ToInt32(GrdPurchase.Width - 520);
        }
        private void frmPOS_Load(object sender, EventArgs e)
        {
            //AllocConsole();

            btnSummary.Visible = false;
            btnViewSalesReport.Visible = false;

            DataTable dtRole = MainFrom.dtPrivileges;
            int _rows = dtRole.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                string _btnName = "_" + dtRole.Rows[i].ItemArray[0].ToString();
                if (_btnName == "_173")
                {
                    btnSummary.Visible = true;
                    continue;
                }
                if (_btnName == "_174")
                {
                    btnViewSalesReport.Visible = true;
                    continue;
                }
            }

            _dtSectionOrderID = new DataTable();
            try
            {
                _dtSectionOrderID.Rows.Clear();
            }
            catch (Exception)
            {
            }
            _dtSectionOrderID.Columns.Add("OrderId", typeof(Int32));
            reprintdate.Text = SessionClass.CurrentWorkDate.ToString();
            SetColors();
            try
            {
                this.LoadOnHoldInvoicNumber();
                this.txtQuantity.Text = "1";
                this.txtstartDate.Value = SessionClass.CurrentWorkDate;
                this.txtEndDate.Value = SessionClass.CurrentWorkDate;
                lblCurrentWorkingDate.Text = SessionClass.CurrentWorkDate.ToString("dd-MMM-yyyy");
                LoadloginDetail();
                if (SessionClass.IsDiscountAllowed)
                {
                    txtAuthorisedBy.Text = SessionClass.UserName;
                    cbDiscount.Checked = true;
                    cbDiscount.Enabled = false;
                    numtxtTotalExtraDiscnt.ReadOnly = false;
                    txtAuthorisedBy.ReadOnly = false;
                }
                else
                {
                    cbDiscount.Checked = false;
                    cbDiscount.Enabled = true;
                    numtxtTotalExtraDiscnt.ReadOnly = true;
                    txtAuthorisedBy.ReadOnly = true;
                }
                btnHold.Enabled = true;
                btnUnhold.Enabled = true;
                btnNewCustomer.Enabled = true;
                btnPriceLookup.Enabled = true;
                _unitType = 0;
                CreatTable();
                LoadPromotion();
                LoadCustomerData();
                GetNotes();
                if (SessionClass.ShowDeliveryman == 1)
                {
                    LoadDeliveryman();
                    lblDeliveryman.Visible = true;
                    cboxDeliveryman.Visible = true;
                }
                //GetLicense();
            }
            catch (Exception eee)
            {
                MessageBox.Show("Error: on Form Loading Event" + eee.Message);
            }
            SetResolution();
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        private void frmPOS_Shown(object sender, EventArgs e)
        {
            if (SessionClass.RoleID != 1)
            {
                this.LoadProducts();
                txtskuCode.Focus();
            }
        }
        private void GetNotes()
        {
            DistributorController m_Controller = new DistributorController();
            SessionClass.dtNotes = m_Controller.GetSlipNotes(3, SessionClass.DISTRIBUTOR_ID);
        }
        private void CreatTable()
        {
            _purchaseSku = new DataTable();
            _purchaseSku.Columns.Add("SALE_ORDER_DETAIL_ID", typeof(long));
            _purchaseSku.Columns.Add("DistributorId", typeof(int));
            _purchaseSku.Columns.Add("SALE_ORDER_ID", typeof(int));
            _purchaseSku.Columns.Add("SKU_ID", typeof(int));
            _purchaseSku.Columns.Add("SKU_Code", typeof(string));
            _purchaseSku.Columns.Add("SKU_Name", typeof(string));
            _purchaseSku.Columns.Add("BATCH_NO", typeof(string));
            _purchaseSku.Columns.Add("UNIT_PRICE", typeof(decimal));
            _purchaseSku.Columns.Add("QUANTITY_UNIT", typeof(decimal));
            _purchaseSku.Columns.Add("AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("STANDARD_DISCOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("STANDARD_DISCOUNT_PER", typeof(decimal));
            _purchaseSku.Columns.Add("EXTRA_DISCOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("RETAIL_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("GST_RATE", typeof(decimal));
            _purchaseSku.Columns.Add("GST_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("TST_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("CLAIM_EXTRA_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("CLAIM_STANDARD_DISCOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("CLAIM_PER", typeof(decimal));
            _purchaseSku.Columns.Add("SED_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("NET_AMOUNT", typeof(decimal));
            _purchaseSku.Columns.Add("QUANTITY_CTN", typeof(decimal));
            _purchaseSku.Columns.Add("PACKSIZE", typeof(string));
            _purchaseSku.Columns.Add("IS_DELETED", typeof(bool));
            _purchaseSku.Columns.Add("SkuImage", typeof(string));
            _purchaseSku.Columns.Add("COLOR", typeof(string));
            _purchaseSku.Columns.Add("TRADE_PRICE", typeof(string));
            _purchaseSku.Columns.Add("AMOUNT_TEMP", typeof(int));
            _purchaseSku.Columns.Add("CHECK_DELETE", typeof(int));
            _purchaseSku.Columns.Add("ORDER", typeof(int));
        }
        private void CreateFreeSku()
        {
            _dtFreeSku = new DataTable();
            _dtFreeSku.Columns.Add("SKU_ID", typeof(int));
            _dtFreeSku.Columns.Add("SKU_Code", typeof(string));
            _dtFreeSku.Columns.Add("SKU_Name", typeof(string));
            _dtFreeSku.Columns.Add("UNIT_PRICE", typeof(decimal));
            _dtFreeSku.Columns.Add("Quantity", typeof(decimal));
            _dtFreeSku.Columns.Add("AMOUNT", typeof(decimal));
            _dtFreeSku.Columns.Add("GST_RATE", typeof(decimal));
            _dtFreeSku.Columns.Add("GST_AMOUNT", typeof(decimal));
            _dtFreeSku.Columns.Add("TST_AMOUNT", typeof(decimal));
            _dtFreeSku.Columns.Add("PROMOTION_ID", typeof(int));
            _dtFreeSku.Columns.Add("BASKET_ID", typeof(int));
            _dtFreeSku.Columns.Add("BASKET_DETAIL_ID", typeof(int));
            _dtFreeSku.Columns.Add("PROMOTION_OFFER_ID", typeof(int));

            _dtFreeSku.Columns.Add("CHECK_DELETE", typeof(int));
            _dtFreeSku.Columns.Add("AMOUNT_TEMP", typeof(int));
            _dtFreeSku.Columns.Add("P_SKU_ID", typeof(int));
        }
        private bool CheckDublicateSku()
        {
            DataRow[] foundRows = _purchaseSku.Select("SKU_CODE  = '" + txtskuCode.Text + "'");

            if (foundRows.Length == 0)
            {
                return true;
            }
            return false;
        }
        public void LoadCustomerData()
        {
            try
            {
                CustomerDataController mController = new CustomerDataController();
                DataTable dtCustomer = mController.SelectPrincipalCustomer(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
                drpCustomer.DataSource = dtCustomer;
                _customers = dtCustomer;
                drpCustomer.ValueMember = "CUSTOMER_ID";
                drpCustomer.DisplayMember = "CUSTOMER_NAME";
                if (SessionClass.CustomerID == Constants.LongNullValue)
                {
                    DataRow[] foundRows = dtCustomer.Select("CUSTOMER_ID  = '" + drpCustomer.SelectedValue + "'");
                    if (foundRows.Length > 0)
                    {
                        SessionClass.CustomerID = long.Parse(foundRows[0]["CUSTOMER_ID"].ToString());
                        _mCustomerVolClassId = int.Parse(foundRows[0]["VOLUME_CLASS_ID"].ToString());
                        drpCustomer.SelectedValue = SessionClass.CustomerID.ToString();
                    }

                }
                else
                {
                    drpCustomer.SelectedValue = SessionClass.CustomerID.ToString();
                }
                if (SessionClass.dtCustomer == null)
                {
                    SessionClass.dtCustomer = dtCustomer;
                }
                drpCustomer.SelectedIndex = 0;
            }
            catch (Exception)
            { }
        }
        private void LoadloginDetail()
        {
            try
            {
                UserController userControl = new UserController();
                var dt = userControl.SelectSlashUser2(SessionClass.UserID);
                lbllogintimedate.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");//DateTime.Now.ToString("MM/dd/yyyy");
                lbluserlogin.Text = dt.Rows[0]["USER_NAME"].ToString();
                lblLoacation.Text = dt.Rows[0]["DISTRIBUTOR_NAME"].ToString();
                if (dt.Rows[0]["Logo"].ToString().Length > 0 && dt.Rows[0]["Logo"] != null)
                {
                    SessionClass.InvLogo = (byte[])dt.Rows[0]["Logo"];
                }
                FormSalesSummary._location = lblLoacation.Text;
                lblTill.Text = dt.Rows[0]["Til"].ToString() + "-";
                try
                {
                    SessionClass.Til_ID = Convert.ToInt32(dt.Rows[0]["Til"].ToString());
                }
                catch (Exception)
                {
                    SessionClass.Til_ID = 0;
                }
                CompanyPhonNmbr = dt.Rows[0]["CONTACT_NUMBER"].ToString(); //Location Contact Number
                CompanyPhonNmbr1 = dt.Rows[0]["CONTACT_PERSON"].ToString(); //Location Contact Number
                ntnNo = dt.Rows[0]["NTN_NO"].ToString(); //NTN Number
                HirarchyNameQuiz2 = dt.Rows[0]["LC2"].ToString();
                Address = dt.Rows[0]["LocationAddress"].ToString();
                SessionClass.DISTRIBUTOR_ID = Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"]);
                SessionClass.IsDiscountAllowed = Convert.ToBoolean(dt.Rows[0]["IsDiscountAllowed"]);
                var dt2 = userControl.SelectUserPrincipal(SessionClass.UserID);
                CompanyName = dt.Rows[0]["COMPANY_NAME"].ToString();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message + "\r\nError Location: LoadloginDetail();");
                ExceptionPublisher.PublishException(eee);
                throw;
            }
        }
        private void LoadDeliveryman()
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt.Columns.Add("Name", typeof(string));
                dtt.Columns.Add("id", typeof(int));
                dtt.Rows.Add("No Deliveryman", SessionClass.UserID);
                Distributor_UserController _duController = new Distributor_UserController();
                DataTable dt = _duController.SelectDistributorUser(48, SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue);
                foreach (DataRow dr in dt.Rows)
                {
                    dtt.Rows.Add(dr["USER_NAME"].ToString(), Convert.ToInt32(dr["USER_ID"].ToString()));
                }
                cboxDeliveryman.DataSource = dtt;
                cboxDeliveryman.DisplayMember = "Name";
                cboxDeliveryman.ValueMember = "id";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw;
            }
        }

        private void LoadProducts()
        {
            txtskuCode.Text = "Loading...";
            txtskuCode.Enabled = false;
            SkuController SKUCtl = new SkuController();
            Dtsku_Price = SKUCtl.SearchProduct(null, 6, SessionClass.DISTRIBUTOR_ID);
            //string[] itemArr = new string[Dtsku_Price.Rows.Count];
            //int i = 0;
            //foreach (DataRow dr in Dtsku_Price.Rows)
            //{
            //    itemArr.SetValue(dr["SkuDetail"].ToString(), i);
            //    i++;
            //}
            //txtskuCode.Values = itemArr;
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (DataRow dr in Dtsku_Price.Rows)
            {
                acsc.Add(dr["SkuDetail"].ToString());
            }
            txtskuCode.AutoCompleteCustomSource = acsc;
            txtskuCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtskuCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtskuCode.Text = "";
            txtskuCode.Enabled = true;
        }
        #region SKU Code (Keyup Event)
        private void txtskuCode_KeyUp(object sender, KeyEventArgs e)
        {
            DataControl dc = new DataControl();
            try
            {
                if (e.KeyCode == Keys.Enter || (txtskuCode.Text.Trim().Length >= 4 && e.KeyCode == Keys.Space))
                {
                    if (txtskuCode.Text.Trim() == "")
                    {
                        txtskuCode.Focus();
                        return;
                    }
                    if (txtskuCode.Text.Trim().Length > 0)
                    {
                        string SelectedText = txtskuCode.Text.Trim();
                        if (SelectedText.Contains("-"))
                        {
                            txtskuCode.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
                            if (SelectedText.Contains(":"))
                            {
                                txtskuName.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                                if (SelectedText.Contains("["))
                                {
                                    txtUnitRate.Text = SelectedText.Substring(SelectedText.IndexOf(":") + 1, SelectedText.IndexOf("[") - SelectedText.IndexOf(":") - 1);
                                    txtamount.Text = (Convert.ToDecimal(_dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(dc.chkNull_0(txtUnitRate.Text))).ToString();
                                    btnSave_Click(null, null);
                                    txtskuCode.Focus();
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in Dtsku_Price.Rows)
                            {   
                                if (dr["SKU_CODE"].ToString().ToLower() == txtskuCode.Text.Trim().ToLower())
                                {
                                    txtskuCode.Text = dr["SKU_CODE"].ToString().Trim();
                                    txtskuName.Text = dr["SKU_NAME"].ToString();
                                    txtUnitRate.Text = dr["TRADE_PRICE"].ToString();
                                    txtamount.Text = (Convert.ToDecimal(_dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(dc.chkNull_0(txtUnitRate.Text))).ToString();
                                    btnSave_Click(null, null);
                                    txtskuCode.Focus();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GrdPurchase.Rows.Count > 0)
                        {
                            if (SessionClass.bFromPriceLookup)
                            {
                                SessionClass.bFromPriceLookup = false;
                                txtskuCode.Focus();
                            }
                            else
                            {
                                if (cbDiscount.Checked)
                                {
                                    numtxtTotalExtraDiscnt.Focus();
                                }
                                else
                                {
                                    txtCashReceived.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                ExceptionPublisher.PublishException(ee);
            }
            foreach (DataGridViewRow row in GrdPurchase.Rows)
            {
                row.Height = 28;
            }
        }
        #endregion
        private void txtskuCode_TextChanged1(object sender, EventArgs e)
        {
            //DataControl dc = new DataControl();
            //if (txtskuCode.Text.Trim().Length > 0)
            //{
            //    string SelectedText = txtskuCode.Text.Trim();

            //    if (SelectedText.Contains("-"))
            //    {
            //        txtskuCode.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
            //        if (SelectedText.Contains(":"))
            //        {
            //            txtskuName.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
            //            if (SelectedText.Contains("["))
            //            {
            //                txtUnitRate.Text = SelectedText.Substring(SelectedText.IndexOf(":") + 1, SelectedText.IndexOf("[") - SelectedText.IndexOf(":") - 1);
            //                txtamount.Text = (Convert.ToDecimal(_dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(dc.chkNull_0(txtUnitRate.Text))).ToString();
            //                btnSave_Click(null, null);
            //                txtskuCode.Focus();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach (DataRow dr in Dtsku_Price.Rows)
            //        {
            //            if (dr["SKU_CODE"].ToString().Trim() == txtskuCode.Text.Trim())
            //            {
            //                txtskuCode.Text = dr["SKU_CODE"].ToString().Trim();
            //                txtskuName.Text = dr["SKU_NAME"].ToString();
            //                txtUnitRate.Text = dr["TRADE_PRICE"].ToString();
            //                txtamount.Text = (Convert.ToDecimal(_dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(dc.chkNull_0(txtUnitRate.Text))).ToString();
            //                btnSave_Click(null, null);
            //                txtskuCode.Focus();
            //                break;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    if (GrdPurchase.Rows.Count > 0)
            //    {
            //        if (cbDiscount.Checked)
            //        {
            //            numtxtTotalExtraDiscnt.Focus();
            //        }
            //        else
            //        {
            //            txtCashReceived.Focus();
            //        }
            //    }
            //}
        }
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            DataControl dc = new DataControl();
            if (e.KeyCode == Keys.Tab)
            {
                if (txtskuCode.Text.Trim().Length > 0)
                {
                    string SelectedText = txtskuCode.Text.Trim();
                    if (SelectedText.Contains("-"))
                    {
                        txtskuCode.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
                        if (SelectedText.Contains(":"))
                        {
                            txtskuName.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                            if (SelectedText.Contains("["))
                            {
                                txtUnitRate.Text = SelectedText.Substring(SelectedText.IndexOf(":") + 1, SelectedText.IndexOf("[") - SelectedText.IndexOf(":") - 1);
                                txtamount.Text = (Convert.ToDecimal(_dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(dc.chkNull_0(txtUnitRate.Text))).ToString();
                                btnSave_Click(null, null);
                            }
                        }
                    }
                }
                else
                {
                    txtQuantity.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtskuCode.Focus();
            }
        }
        private decimal CheckStockStatus(int skuId, decimal Qty)
        {
            //var mController = new PhaysicalStockController();
            //DataTable dt = mController.SelectSKUClosingStock(SessionClass.DISTRIBUTOR_ID, skuId, "N/A", SessionClass.CurrentWorkDate);

            //if (dt.Rows.Count > 0)
            //{
            //        if (decimal.Parse(dt.Rows[0][0].ToString()) >= Qty)
            //        {
            //            return -1;
            //        }
            //        return decimal.Parse(dt.Rows[0][0].ToString());
            //}
            //return 0;
            return -1;
        }
        private decimal RetailPrice(decimal tradePrice, decimal wholesalePrice, decimal Ws_Qty, decimal quantity)
        {
            if (wholesalePrice != 0 && quantity >= Ws_Qty)
            {
                return wholesalePrice;
            }
            else
            {
                return tradePrice;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataControl _dc = new DataControl();
                decimal Quantity = decimal.Parse(_dc.chkNull_0(txtQuantity.Text));
                //btnToggleMode.Enabled = false;
                DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtskuCode.Text.Trim() + "'");
                if (foundRows.Length > 0)
                {
                    decimal mTradePrice = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString()));
                    decimal mWholesalePrice = decimal.Parse(_dc.chkNull_0(foundRows[0]["WHOLESALE_PRICE"].ToString()));
                    decimal mWSQuantity = decimal.Parse(_dc.chkNull_0(foundRows[0]["WS_QUANTITY"].ToString()));
                    if (btnSave.Text == "Add SKU")
                    {
                        if (btnToggleMode.Text == "SALE MODE")//code for order invoice without negative entry
                        {
                            if (Quantity > 0)
                            {
                                decimal currentStock = 0;

                                if (CheckDublicateSku())
                                {
                                    currentStock = CheckStockStatus(int.Parse(_dc.chkNull_0(foundRows[0]["SKU_ID"].ToString())), Quantity);
                                    mTradePrice = RetailPrice(mTradePrice, mWholesalePrice, mWSQuantity, decimal.Parse(txtQuantity.Text));
                                    if (currentStock == -1)
                                    {
                                        DataRow dr = _purchaseSku.NewRow();
                                        dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                                        dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                        dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                        dr["ORDER"] = order + 1;
                                        order = order + 1;
                                        dr["QUANTITY_UNIT"] = Quantity;
                                        dr["UNIT_PRICE"] = mTradePrice.ToString();
                                        dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                                        dr["TST_AMOUNT"] = 0;
                                        dr["GST_RATE"] = 0;
                                        dr["GST_AMOUNT"] = 0;
                                        dr["NET_AMOUNT"] = 0;
                                        _purchaseSku.Rows.Add(dr);
                                        txtskuCode.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show(txtskuName.Text + " Current closing Stock is " + currentStock);
                                        return;
                                    }
                                }
                                else
                                {

                                    DataRow[] foundRowsexist = _purchaseSku.Select("SKU_CODE  = '" + txtskuCode.Text.Trim() + "'");//QUANTITY_UNIT
                                    mTradePrice = RetailPrice(mTradePrice, mWholesalePrice, mWSQuantity, Convert.ToDecimal(foundRowsexist[0]["QUANTITY_UNIT"]) + decimal.Parse(txtQuantity.Text));
                                    if (foundRowsexist.Length > 0)
                                    {
                                        currentStock = CheckStockStatus(int.Parse(_dc.chkNull_0(foundRowsexist[0]["SKU_ID"].ToString())), decimal.Parse(foundRowsexist[0]["QUANTITY_UNIT"].ToString()) + Quantity);
                                        if (currentStock == -1)
                                        {
                                            foundRowsexist[0]["QUANTITY_UNIT"] = decimal.Parse(foundRowsexist[0]["QUANTITY_UNIT"].ToString()) + Quantity;
                                            //foundRowsexist[0]["AMOUNT"] = decimal.Parse(foundRowsexist[0]["AMOUNT"].ToString()) + (mTradePrice * Quantity);
                                            foundRowsexist[0]["AMOUNT"] = mTradePrice * Convert.ToDecimal(foundRowsexist[0]["QUANTITY_UNIT"]);
                                            foundRowsexist[0]["UNIT_PRICE"] = Convert.ToDecimal(mTradePrice);
                                        }
                                        else
                                        {
                                            MessageBox.Show(txtskuName.Text + " Current closing Stock is " + currentStock);
                                            return;

                                        }
                                    }
                                }
                                txtskuCode.Focus();
                            }
                        }
                        else //Refund Mode
                        {
                            if (Quantity > 0)
                            {
                                Quantity = Quantity - (Quantity * 2);
                            }
                            DataRow[] foundRowsexist = _purchaseSku.Select("SKU_CODE  = '" + txtskuCode.Text.Trim() + "'");
                            if (foundRowsexist.Length == 0)
                            {
                                DataRow dr = _purchaseSku.NewRow();
                                dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                                dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                dr["ORDER"] = order + 1;
                                order = order + 1;
                                dr["QUANTITY_UNIT"] = Quantity;
                                dr["UNIT_PRICE"] = mTradePrice.ToString();
                                dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                                dr["TST_AMOUNT"] = 0;
                                dr["GST_RATE"] = 0;
                                dr["GST_AMOUNT"] = 0;
                                dr["NET_AMOUNT"] = 0;
                                _purchaseSku.Rows.Add(dr);
                            }
                            else
                            {
                                //if -1 then update existing else 
                                if (Quantity < 0)
                                {
                                    foundRowsexist[0]["QUANTITY_UNIT"] = decimal.Parse(foundRowsexist[0]["QUANTITY_UNIT"].ToString()) + Quantity;
                                    foundRowsexist[0]["AMOUNT"] = decimal.Parse(foundRowsexist[0]["AMOUNT"].ToString()) + (mTradePrice * Quantity);
                                }
                            }
                        }
                    }
                    EnableDisableController(false);
                    ClearAll12();
                    btnSaveOrder.Enabled = true;
                    Calculate();
                    LoadGird();
                    txtskuCode.Focus();
                }
            }
            catch (Exception ej)
            {
                string t = ej.Message.ToString();
            }
            txtskuCode.Focus();
        }
        private void EnableDisableController(bool cValue)
        {
            try
            {
                if (cValue != true) return;
                if (txtGrossAmount.Text == "") return;
                if (decimal.Parse(txtGrossAmount.Text) <= 0) return;
                drpCustomer.Enabled = true;
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        private void LoadGird()
        {
            GrdPurchase.AutoGenerateColumns = false;
            DataView view = _purchaseSku.DefaultView;
            view.Sort = "ORDER DESC";
            _purchaseSku = view.ToTable();
            GrdPurchase.Rows.Clear();
            foreach (DataRow dr in _purchaseSku.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(GrdPurchase);
                row.Cells[0].Value = dr["SKU_ID"];
                row.Cells[1].Value = dr["SKU_CODE"];
                row.Cells[2].Value = dr["SKU_NAME"];
                row.Cells[3].Value = dr["COLOR"];
                row.Cells[4].Value = dr["PACKSIZE"];
                row.Cells[5].Value = dr["QUANTITY_UNIT"];
                row.Cells[6].Value = String.Format("{0:0.00}", dr["UNIT_PRICE"]);
                row.Cells[7].Value = String.Format("{0:0.00}", dr["Amount"]);
                row.Cells[8].Value = String.Format("{0:0.00}", dr["NET_AMOUNT"]);
                row.Cells[9].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GrdPurchase.Rows.Add(row);
                row.Cells[5].ReadOnly = false;
                if (SessionClass.SalePriceEdit == "True")
                {
                    row.Cells[6].ReadOnly = false;
                }
            }
            txtskuCode.Focus();
        }
        private void ClearAll12()
        {
            try
            {
                txtskuCode.Text = "";
                txtskuName.Text = "";
                txtUnitRate.Text = "";
                txtamount.Text = "";
                txtQuantity.Text = btnToggleMode.Text != "SALE MODE" ? "-1" : "1";
                btnSave.Text = "Add SKU";
                btnSaveOrder.Enabled = true;
                txtskuCode.Enabled = true;
                txtskuCode.Focus();
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        private void ClearAll()
        {
            try
            {
                txtskuCode.Text = "";
                txtskuName.Text = "";
                txtUnitRate.Text = "";
                txtamount.Text = "";
                numTxtTotlAmnt.Text = "0.00";
                btnToggleMode.Text = "SALE MODE";
                btnToggleMode.Enabled = true;
                txtQuantity.Text = btnToggleMode.Text != "SALE MODE" ? "-1" : "1";
                txtCashReceived.Text = "";
                txtBalance.Text = "";
                lblPayableAmount.Text = "";
                btnSave.Text = "Add SKU";
                btnSaveOrder.Enabled = true;
                txtskuCode.Enabled = true;
                txtskuCode.Focus();
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        protected void Calculate()
        {
            try
            {
                decimal ObjGrossSales = 0;
                decimal ObjStandardDiscount = 0;
                decimal ObjExtraDiscount = 0;
                decimal ObjTotalGST = 0;
                decimal ObjTotalSED = 0;
                decimal ObjTotalTST = 0;
                decimal ObjFreeGSTAmount = 0;
                decimal ObjFreeGrossAmt = 0;
                decimal ObjFreeTST = 0;
                decimal ProductExtDist = 0;
                decimal ProductStdDist = 0;
                decimal amount = 0;

                OrderEntryController or = new OrderEntryController();
                SKUGroupController GroupCtl = new SKUGroupController();
                DataTable dt = _purchaseSku;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["STANDARD_DISCOUNT"] = 0;
                    dr["STANDARD_DISCOUNT_PER"] = 0;
                    dr["EXTRA_DISCOUNT"] = 0;
                    dr["CLAIM_EXTRA_AMOUNT"] = 0;
                    dr["CLAIM_STANDARD_DISCOUNT"] = 0;
                    dr["CLAIM_PER"] = 0;
                    dr["SED_AMOUNT"] = 0;
                    dr["GST_AMOUNT"] = 0;
                    dr["TST_AMOUNT"] = 0;
                    dr["GST_RATE"] = 0;
                    amount = Convert.ToDecimal(dr["AMOUNT"]);
                }
                CreateFreeSku();
                LoadFreeGrid();
                if (dt.Rows.Count > 0)
                {
                    if (Arpc != null)
                    {
                        ArrayList ARlistOffer = or.GetPromotionOffers(Arpc, _mCustomerVolClassId, 90, dt, false);
                        for (int i = 0; i < ARlistOffer.Count; i++)
                        {
                            numtxtTotalExtraDiscnt.ReadOnly = false;
                            PromoOffers_Collection pofferCol = (PromoOffers_Collection)ARlistOffer[i];
                            if (pofferCol.SKU_ID > 0)
                            {
                                #region slab on SKU
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (int.Parse(dr["SKU_ID"].ToString()) == pofferCol.SKU_ID)
                                    {
                                        if (pofferCol.Is_And == true)
                                        {
                                            if (pofferCol.Offer_Value > 0)
                                            {
                                                dr["EXTRA_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())) + pofferCol.Offer_Value;
                                            }
                                            if (pofferCol.Discount > 0)
                                            {
                                                dr["EXTRA_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())) + (decimal.Parse(pofferCol.Discount.ToString()) / 100) * (decimal.Parse(dr["AMOUNT"].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (pofferCol.Offer_Value > 0)
                                            {
                                                dr["STANDARD_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT"].ToString())) + pofferCol.Offer_Value;
                                            }
                                            if (pofferCol.Discount > 0)
                                            {
                                                dr["STANDARD_DISCOUNT_PER"] = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT_PER"].ToString())) + (decimal.Parse(pofferCol.Discount.ToString()) / 100);
                                            }
                                        }
                                        if (pofferCol.Free_SKU_ID > 0)
                                        {
                                            DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + pofferCol.Free_SKU_ID.ToString() + "'");
                                            int RowId = FreeSKUExist(_dtFreeSku, pofferCol.Free_SKU_ID);
                                            if (foundRows.Length > 0)
                                            {
                                                if (RowId < 0)
                                                {
                                                    DataRow dr1 = _dtFreeSku.NewRow();
                                                    dr1["P_SKU_ID"] = dr["SKU_ID"];
                                                    dr1["SKU_ID"] = foundRows[0]["SKU_ID"];
                                                    dr1["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                                    dr1["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                                    if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["GST_AMOUNT"] = (decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) / 100) * decimal.Parse(dr1["AMOUNT"].ToString());
                                                        dr1["TST_AMOUNT"] = 0;
                                                    }
                                                    else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["TST_AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["GST_AMOUNT"] = 0;
                                                    }
                                                    else
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["GST_AMOUNT"] = 0;
                                                        dr1["TST_AMOUNT"] = 0;
                                                    }
                                                    dr1["PROMOTION_ID"] = pofferCol.Promotion_ID.ToString();
                                                    dr1["BASKET_ID"] = pofferCol.Basket_ID.ToString();
                                                    dr1["BASKET_DETAIL_ID"] = pofferCol.BasketDetail_ID.ToString();
                                                    dr1["PROMOTION_OFFER_ID"] = pofferCol.PromoOffer_ID.ToString();
                                                    ObjFreeGrossAmt += decimal.Parse(dr1["AMOUNT"].ToString());
                                                    ObjFreeGSTAmount += decimal.Parse(_dc.chkNull_0(dr1["GST_AMOUNT"].ToString()));
                                                    ObjFreeTST += decimal.Parse(_dc.chkNull_0(dr1["TST_AMOUNT"].ToString()));
                                                    _dtFreeSku.Rows.Add(dr1);
                                                }
                                                else
                                                {
                                                    DataRow dr1 = _dtFreeSku.Rows[RowId];
                                                    ObjFreeGrossAmt = ObjFreeGrossAmt - decimal.Parse(dr1["AMOUNT"].ToString());
                                                    ObjFreeGSTAmount = ObjFreeGSTAmount - decimal.Parse(dr1["GST_AMOUNT"].ToString());
                                                    dr1["P_SKU_ID"] = dr["SKU_ID"];
                                                    dr1["SKU_ID"] = foundRows[0]["SKU_ID"];
                                                    dr1["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                                    dr1["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                                    dr1["Quantity"] = int.Parse(dr1["Quantity"].ToString()) + pofferCol.Quantity;
                                                    if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["GST_AMOUNT"] = (decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) / 100) * decimal.Parse(dr1["AMOUNT"].ToString());
                                                        dr1["TST_AMOUNT"] = 0;
                                                    }
                                                    else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["TST_AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                        dr1["GST_AMOUNT"] = 0;
                                                    }
                                                    else
                                                    {
                                                        dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                        dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                        dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                        dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    }
                                                    dr1["PROMOTION_ID"] = pofferCol.Promotion_ID.ToString();
                                                    dr1["BASKET_ID"] = pofferCol.Basket_ID.ToString();
                                                    dr1["BASKET_DETAIL_ID"] = pofferCol.BasketDetail_ID.ToString();
                                                    dr1["PROMOTION_OFFER_ID"] = pofferCol.PromoOffer_ID.ToString();
                                                    ObjFreeGrossAmt += decimal.Parse(dr1["AMOUNT"].ToString());
                                                    ObjFreeGSTAmount += decimal.Parse(_dc.chkNull_0(dr1["GST_AMOUNT"].ToString()));
                                                    ObjFreeTST += decimal.Parse(_dc.chkNull_0(dr1["TST_AMOUNT"].ToString()));
                                                }
                                            }
                                        }
                                        LoadFreeGrid();
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region slab on SKU Group
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (GroupCtl.ExistsInGroup(Constants.IntNullValue, pofferCol.Group_ID, int.Parse(dr["SKU_ID"].ToString())))
                                    {
                                        if (pofferCol.Is_And == true)
                                        {
                                            if (pofferCol.Offer_Value > 0)
                                            {
                                                dr["EXTRA_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())) + pofferCol.Offer_Value;
                                            }
                                            if (pofferCol.Discount > 0)
                                            {
                                                dr["EXTRA_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())) + ((decimal.Parse(pofferCol.Discount.ToString())) / 100) * (decimal.Parse(dr["AMOUNT"].ToString()) - decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())));
                                            }
                                        }
                                        else
                                        {
                                            if (pofferCol.Offer_Value > 0)
                                            {
                                                dr["STANDARD_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT"].ToString())) + pofferCol.Offer_Value;
                                            }
                                            if (pofferCol.Discount > 0)
                                            {
                                                dr["STANDARD_DISCOUNT_PER"] = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT_PER"].ToString())) + (decimal.Parse(pofferCol.Discount.ToString()) / 100);
                                            }
                                        }
                                    }
                                    #region Free SKU

                                    if (pofferCol.Free_SKU_ID > 0)
                                    {
                                        DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + pofferCol.Free_SKU_ID.ToString() + "'");
                                        int RowId = FreeSKUExist(_dtFreeSku, pofferCol.Free_SKU_ID);
                                        if (foundRows.Length > 0)
                                        {
                                            if (RowId < 0)
                                            {
                                                DataRow dr1 = _dtFreeSku.NewRow();
                                                dr1["P_SKU_ID"] = dr["SKU_ID"];
                                                dr1["SKU_ID"] = foundRows[0]["SKU_ID"];
                                                dr1["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                                dr1["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                                dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = (decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) / 100) * decimal.Parse(dr1["AMOUNT"].ToString());
                                                    dr1["TST_AMOUNT"] = 0;
                                                }
                                                else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["TST_AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = 0;
                                                }
                                                else
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = 0;
                                                    dr1["TST_AMOUNT"] = 0;
                                                }
                                                dr1["PROMOTION_ID"] = pofferCol.Promotion_ID.ToString();
                                                dr1["BASKET_ID"] = pofferCol.Basket_ID.ToString();
                                                dr1["BASKET_DETAIL_ID"] = pofferCol.BasketDetail_ID.ToString();
                                                dr1["PROMOTION_OFFER_ID"] = pofferCol.PromoOffer_ID.ToString();
                                                ObjFreeGrossAmt += decimal.Parse(dr1["AMOUNT"].ToString());
                                                ObjFreeGSTAmount += decimal.Parse(_dc.chkNull_0(dr1["GST_AMOUNT"].ToString()));
                                                ObjFreeTST += decimal.Parse(_dc.chkNull_0(dr1["TST_AMOUNT"].ToString()));
                                                _dtFreeSku.Rows.Add(dr1);
                                            }
                                            else
                                            {
                                                DataRow dr1 = _dtFreeSku.Rows[RowId];
                                                ObjFreeGrossAmt = ObjFreeGrossAmt - decimal.Parse(dr1["AMOUNT"].ToString());
                                                ObjFreeGSTAmount = ObjFreeGSTAmount - decimal.Parse(dr1["GST_AMOUNT"].ToString());
                                                dr1["P_SKU_ID"] = dr["SKU_ID"];
                                                dr1["SKU_ID"] = foundRows[0]["SKU_ID"];
                                                dr1["SKU_Code"] = foundRows[0]["SKU_CODE"];
                                                dr1["SKU_Name"] = foundRows[0]["SKU_NAME"];
                                                dr1["Quantity"] = int.Parse(dr1["Quantity"].ToString()) + pofferCol.Quantity;
                                                if (foundRows[0]["GST_ON"].ToString().Trim() == "T")
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = (decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) / 100) * decimal.Parse(dr1["AMOUNT"].ToString());
                                                    dr1["TST_AMOUNT"] = 0;
                                                }
                                                else if (foundRows[0]["GST_ON"].ToString().Trim() == "R")
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["TST_AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = 0;
                                                }
                                                else
                                                {
                                                    dr1["UNIT_PRICE"] = foundRows[0]["TRADE_PRICE"];
                                                    dr1["Quantity"] = pofferCol.Quantity.ToString();
                                                    dr1["GST_RATE"] = foundRows[0]["GST_RATE_TP"];
                                                    dr1["AMOUNT"] = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString())) * decimal.Parse(pofferCol.Quantity.ToString());
                                                    dr1["GST_AMOUNT"] = 0;
                                                    dr1["TST_AMOUNT"] = 0;
                                                }
                                                dr1["PROMOTION_ID"] = pofferCol.Promotion_ID.ToString();
                                                dr1["BASKET_ID"] = pofferCol.Basket_ID.ToString();
                                                dr1["BASKET_DETAIL_ID"] = pofferCol.BasketDetail_ID.ToString();
                                                dr1["PROMOTION_OFFER_ID"] = pofferCol.PromoOffer_ID.ToString();
                                                ObjFreeGrossAmt += decimal.Parse(dr1["AMOUNT"].ToString());
                                                ObjFreeGSTAmount += decimal.Parse(_dc.chkNull_0(dr1["GST_AMOUNT"].ToString()));
                                                ObjFreeTST += decimal.Parse(_dc.chkNull_0(dr1["TST_AMOUNT"].ToString()));
                                            }
                                            LoadFreeGrid();
                                        }
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                        }
                    }
                    #region Recalculate Products

                    foreach (DataRow dr in dt.Rows)
                    {
                        ProductStdDist = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT_PER"].ToString())) * (decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString())) - decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())));
                        if (ProductStdDist > 0)
                        {
                            dr["STANDARD_DISCOUNT"] = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT_PER"].ToString())) * (decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString())) - decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString())));
                        }
                        ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                        ObjStandardDiscount += decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT"].ToString()));
                        ObjExtraDiscount += decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString()));
                        ObjTotalSED += decimal.Parse(_dc.chkNull_0(dr["SED_AMOUNT"].ToString()));

                        #region GST Calculation
                        decimal TempAmount = decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                        decimal TempDiscount = decimal.Parse(_dc.chkNull_0(dr["STANDARD_DISCOUNT"].ToString()));
                        decimal TempExtraDisAmt = decimal.Parse(_dc.chkNull_0(dr["EXTRA_DISCOUNT"].ToString()));
                        dr["GST_AMOUNT"] = (TempAmount - TempDiscount - TempExtraDisAmt) * decimal.Parse(_dc.chkNull_0(dr["GST_RATE"].ToString())) / 100;
                        dr["NET_AMOUNT"] = (TempAmount - TempDiscount - TempExtraDisAmt) + decimal.Parse(_dc.chkNull_0(dr["GST_AMOUNT"].ToString())) + decimal.Parse(_dc.chkNull_0(dr["TST_AMOUNT"].ToString()));
                        ObjTotalGST += decimal.Parse(_dc.chkNull_0(dr["GST_AMOUNT"].ToString()));
                        ObjTotalTST += decimal.Parse(_dc.chkNull_0(dr["TST_AMOUNT"].ToString()));
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region Reversecalulate Products
                    if (amount > 0)
                    {
                        decimal ObjTaxableAmount = 0;
                        decimal ObjClaimAblePer = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                        }
                        if (decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text)) > 0)
                        {
                            ProductExtDist = decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text)) / (ObjGrossSales - ObjTaxableAmount);
                        }
                        ObjGrossSales = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            decimal TempAmount = 0;
                            decimal TempDiscount = 0;
                            decimal TempExtraDisAmt = 0;
                            #region GST Calculation
                            TempAmount = decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                            dr["NET_AMOUNT"] = (TempAmount - TempDiscount - TempExtraDisAmt);
                            ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                            #endregion
                        }
                    }
                    #endregion
                }
                #region Set Total Values
                txtGrossAmount.Text = Convert.ToString(Math.Round(ObjGrossSales, 2));
                if (ObjGrossSales != 0)
                {
                    numtxtTotalExtraDiscnt.Text = Convert.ToString(Math.Round(ObjStandardDiscount, 2));
                    numTxtTotalGST.Text = Convert.ToString(Math.Round(ObjTotalGST + ObjFreeGSTAmount, 2));
                    numTxtTotlAmnt.Text = Convert.ToString(Math.Round(ObjGrossSales - ObjStandardDiscount + ObjTotalGST + ObjFreeGSTAmount + ObjTotalTST, 2));
                    txtBalance.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Text)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();
                    lblPayableAmount.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Text)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();
                }
                else
                {
                    numtxtTotalExtraDiscnt.Text = "0.00";
                    numTxtTotalGST.Text = Convert.ToString(Math.Round(ObjTotalGST + ObjFreeGSTAmount, 2));
                    numTxtTotlAmnt.Text = Convert.ToString(Math.Round(ObjGrossSales - Convert.ToDecimal(numtxtTotalExtraDiscnt.Text) + ObjTotalGST + ObjFreeGSTAmount + ObjTotalTST, 2));
                    txtBalance.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Text)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();
                    lblPayableAmount.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Text)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();
                }
                #endregion
                btnSaveOrder.Enabled = true;
                if (!RblPayMode3.Checked)
                {
                    txtCashReceived.ReadOnly = false;
                }
                else
                {
                    txtCashReceived.ReadOnly = true;
                    btnSaveOrder.Focus();
                }
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
            txtskuCode.Focus();
        }
        private int FreeSKUExist(DataTable dt, int skuId)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["SKU_ID"].ToString()) == skuId)
                {
                    return i;
                }
            }
            return -1;
        }
        private void LoadPromotion()
        {
            if (SessionClass.DISTRIBUTOR_ID > 0)
            {
                return;
                SKUPriceDetailController pController = new SKUPriceDetailController();
                DataTable dt = pController.SelectDataPrice(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, 5, Constants.DateNullValue);
                if ((int.Parse(dt.Rows[0]["Is_ManualDiscount"].ToString()) > 0))
                {
                    OrderEntryController orderController = new OrderEntryController();
                    PromotionCollections_Controller Arpc = orderController.LoadSchemes(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, SessionClass.CurrentWorkDate);
                    numtxtTotalExtraDiscnt.ReadOnly = true;
                }
                else
                {
                    numtxtTotalExtraDiscnt.ReadOnly = false;
                }
            }
        }
        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = true;
                if (_purchaseSku.Rows.Count > 0)
                {
                    decimal currentStock = 0;
                    foreach (DataRow dr in _purchaseSku.Rows)
                    {
                        currentStock = CheckStockStatus(int.Parse(_dc.chkNull_0(dr["SKU_ID"].ToString())), Convert.ToDecimal(_dc.chkNull_0(dr["QUANTITY_UNIT"].ToString())));
                        if (currentStock != -1)
                        {
                            MessageBox.Show(dr["SKU_NAME"] + " Current closing Stock is " + currentStock);
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    DataControl dc = new DataControl();
                    if (RblPayMode1.Checked)
                    {
                        if (Convert.ToDecimal(dc.chkNull_0(txtCashReceived.Text)) < Convert.ToDecimal(dc.chkNull_0(numTxtTotlAmnt.Text)))
                        {
                            if (MessageBox.Show("Cash received cannot be less than Net Amount!", "CORN : POS", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                txtCashReceived.Focus();
                                return;
                            }
                        }
                    }
                    else if (RblPayMode2.Checked)
                    {
                        if (Convert.ToDecimal(dc.chkNull_0(txtCashReceived.Text)) > Convert.ToDecimal(dc.chkNull_0(numTxtTotlAmnt.Text)))
                        {
                            if (MessageBox.Show("Cash received cannot be greater than Net Amount!", "CORN : POS", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                txtCashReceived.Focus();
                                return;
                            }
                        }
                    }
                    string manualId = btnToggleMode.Text != "SALE MODE" ? "1" : "2";
                    int intRblPayMode = 214;
                    if (RblPayMode2.Checked)
                    {
                        intRblPayMode = 217;
                    }
                    else if (RblPayMode3.Checked)
                    {
                        intRblPayMode = 215;
                    }
                    else if (RblPayMode4.Checked)
                    {
                        intRblPayMode = Constants.Credit_Amount_Id;
                    }

                    if (_purchaseSku.Rows.Count > 0)
                    {
                        decimal totalAmount = decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text));
                        decimal discount = decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
                        decimal gst = decimal.Parse(_dc.chkNull_0(numTxtTotalGST.Text));
                        decimal netAmount = 0;
                        int discountType = 0;
                        if (rbtnage.Checked)
                        {
                            if(discount > 0)
                            {
                                discountType = 1;
                            }
                            discount = (decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text)) / 100) * decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
                        }
                        if (totalAmount < 0)
                        {
                            netAmount = (totalAmount + discount) - gst;
                        }
                        else
                        {
                            netAmount = (totalAmount - discount) + gst;
                        }
                        string OrderIdConcatSectionSale = "";
                        int Ids = _dtSectionOrderID.Rows.Count;
                        if (Ids > 0)
                        {
                            OrderIdConcatSectionSale = _dtSectionOrderID.Rows[0]["OrderId"].ToString();
                            for (int i = 1; i < Ids; i++)
                            {
                                OrderIdConcatSectionSale = OrderIdConcatSectionSale + "," + _dtSectionOrderID.Rows[i]["OrderId"].ToString();
                            }
                            OrderIdConcatSectionSale = OrderIdConcatSectionSale + ",";
                        }
                        long orderId = 0;
                        if (ddonHoldList.Items.Count > 0)
                        {
                            if (((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey != Constants.LongNullValue.ToString() && ((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey != "")
                            {
                                orderId = long.Parse(((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey.ToString());
                            }
                        }
                        if (orderId > 0)
                        {
                            OrderIdConcatSectionSale = orderId + ",";
                        }
                        int _PaymetnType = 0;
                        if (RblPayMode1.Checked)
                        {
                            _PaymetnType = Constants.Cash_Order_Id; // 214
                        }
                        if (RblPayMode2.Checked)
                        {
                            _PaymetnType = Constants.CashAndCredit_Order_Id; // 217
                        }
                        if (RblPayMode3.Checked)
                        {
                            _PaymetnType = Constants.Credit_Order_Id; // 215
                        }
                        if (RblPayMode4.Checked)
                        {
                            _PaymetnType = Constants.Credit_Amount_Id; // 218
                        }
                        int deliveryman = SessionClass.UserID;
                        if (cboxDeliveryman.Visible == true)
                        {
                            try
                            {
                                deliveryman = Convert.ToInt32(cboxDeliveryman.SelectedValue.ToString());
                            }
                            catch (Exception)
                            {
                                //MessageBox.Show(this, "Please Select Rider", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                                deliveryman = SessionClass.UserID;
                            }
                        }

                        _saleInvoiceId = _mOrderController.Add_Invoice2(SessionClass.DISTRIBUTOR_ID, manualId, mTownId, _PaymetnType, 0, long.Parse(drpCustomer.SelectedValue.ToString()), 0, 0, deliveryman, orderId,
                        decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text)), discount, decimal.Parse(_dc.chkNull_0(txtCashReceived.Text)), decimal.Parse(_dc.chkNull_0(numTxtTotalGST.Text)), netAmount, 0, intRblPayMode,
                        _purchaseSku, _dtFreeSku, SessionClass.UserID, decimal.Parse(_dc.chkNull_0(txtCashReceived.Text)), SessionClass.CurrentWorkDate, 0, 0, _dc.chkNull_0(txtAuthorisedBy.Text), SessionClass.Til_ID, SessionClass.Shift_ID, discountType, _dtSectionOrderID, OrderIdConcatSectionSale);

                        if (_saleInvoiceId == -2 || _saleInvoiceId == -1)
                        {
                            MessageBox.Show("Insertion Failed!!!.", "CORN : POS");
                        }
                        else
                        {
                            if (chkPrint.Checked)
                            {
                                if (System.Configuration.ConfigurationSettings.AppSettings["IsPrint"] == "1")
                                {
                                    if (txt_chkprint.Text != "")
                                    {
                                        int i = int.Parse(txt_chkprint.Text);
                                        if (i > 0)
                                        {
                                            for (int g = 0; g < i; g++)
                                            {
                                                PrintReport(3);
                                            }
                                        }
                                    }
                                }
                            }
                            ClearMasterAll();
                            SALE_ORDER_ID = Constants.LongNullValue;
                            if (orderId > 0)   // Count Again Hold Bills
                            {
                                LoadOnHoldInvoicNumber();
                            }
                            //btnToggleMode.Enabled = true;
                            txtskuCode.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No product added", "CORN : POS");
                    }
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Insertion Failed!!!.", "CORN : POS");
            }
            PenalPayment.Visible = false;
            txtskuCode.Focus();
            PenalHeader.Dock = DockStyle.Top;
            LoadCustomerData();
        }
        protected void btnVoid_Click(object sender, EventArgs e)//cancel button click 
        {

            if (SALE_ORDER_ID != Constants.LongNullValue)
            {
                _mOrderController.Update_Order(SALE_ORDER_ID);
                LoadOnHoldInvoicNumber();
            }
            ClearAll();
            ClearMasterAll();
            //btnToggleMode.Enabled = true;
            txtskuCode.Focus();
            SALE_ORDER_ID = Constants.LongNullValue;
        }
        public void LoadOnHoldInvoicNumber()
        {
            dtOrder = or.SelectPendingOrder(SessionClass.DISTRIBUTOR_ID, 0, 0, 0, 0, Constants.Order_Pending_Id, 1, SessionClass.UserID, SessionClass.CurrentWorkDate);
            lblonHold.Text = Convert.ToString(dtOrder.Rows.Count);
        }
        private void LoadPendingOrder()
        {
            try
            {
                ddonHoldList.Items.Clear();
                dtOrder = or.SelectPendingOrder(SessionClass.DISTRIBUTOR_ID, 0, 0, 0, 0, Constants.Order_Pending_Id, 1, SessionClass.UserID, SessionClass.CurrentWorkDate);
                ddonHoldList.Items.Add(new clsListItems("Select To Unhold", Constants.LongNullValue.ToString()));
                clsFormUtil.FillComboBox(ddonHoldList, dtOrder, "SALE_ORDER_ID", "SALE_ORDER_ID2");
                ddonHoldList.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }
        private void RblPayMode3_CheckedChanged(object sender, EventArgs e)
        {
            txtCashReceived.Text = "";
            txtCashReceived.ReadOnly = true;
            btnSaveOrder.Focus();
        }
        private void RblPayMode4_CheckedChanged(object sender, EventArgs e)
        {
            txtCashReceived.Text = "";
            txtCashReceived.ReadOnly = true;
            btnSaveOrder.Focus();
        }
        private void RblPayMode2_CheckedChanged(object sender, EventArgs e)
        {
            txtCashReceived.ReadOnly = false;
            txtCashReceived.Focus();
        }
        private void RblPayMode1_CheckedChanged(object sender, EventArgs e)
        {
            txtCashReceived.ReadOnly = false;
            txtCashReceived.Focus();
        }
        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            if (btnToggleMode.Text == "SALE MODE")
            {
                btnToggleMode.Text = "REFUND\r\nMODE";
                txtQuantity.Text = "-1";
            }
            else
            {
                btnToggleMode.Text = "SALE MODE";
                txtQuantity.Text = "1";
            }

        }
        private void GrdPurchase_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {

                DataView view = _purchaseSku.DefaultView;
                view.Sort = "ORDER DESC";
                _purchaseSku = view.ToTable();
                var skuId = GrdPurchase.Rows[e.RowIndex].Cells[0].Value;

                if (_dtFreeSku != null)
                {
                    foreach (DataRow dr in _dtFreeSku.Rows)
                    {
                        var chk = dr["P_SKU_ID"].ToString(); //free SKU_ID
                        if (skuId != chk) continue;
                        if ((dr["AMOUNT"].ToString() == "0"))
                        {
                            dr["AMOUNT"] = dr["AMOUNT_TEMP"];
                            dr["CHECK_DELETE"] = "0";
                        }
                        else
                        {
                            dr["AMOUNT_TEMP"] = dr["AMOUNT"];
                            dr["AMOUNT"] = "0";
                            dr["CHECK_DELETE"] = "1";
                        }
                    }
                }
                _purchaseSku.Rows.RemoveAt(e.RowIndex);
                LoadGird();
                LoadFreeGrid();
                btnCalculate.Enabled = true;
                Calculate();
                if (_purchaseSku.Rows.Count <= 0)
                {
                    //btnToggleMode.Enabled = true;
                    txtCashReceived.Text = "";
                    txtBalance.Text = "0.00";
                    lblPayableAmount.Text = "0.00";
                }
                txtskuCode.Focus();
            }
        }
        #region JavaScriptFunctions

        private void CalculateNetAndBalance()
        {
            decimal gross = 0; decimal disc = 0; decimal tax = 0; decimal totalamount = 0; decimal paydamount = 0; decimal balance = 0;

            gross = Convert.ToDecimal(_dc.chkNull_0(txtGrossAmount.Text));
            if (rbtnage.Checked)
            {
                disc = (gross / 100) * Convert.ToDecimal(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
            }
            else
            {
                disc = Convert.ToDecimal(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
            }
            tax = Convert.ToDecimal(_dc.chkNull_0(numTxtTotalGST.Text));
            totalamount = Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Text));
            paydamount = Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text));
            balance = Convert.ToDecimal(_dc.chkNull_0(txtBalance.Text));

            if (btnToggleMode.Text == "SALE MODE")
            {
                if (disc < 0)
                {
                    disc = 0;
                }
                if (gross > 0)
                {
                    numTxtTotlAmnt.Text = (gross - disc + tax).ToString();
                }
                if (gross > 0)
                {
                    txtBalance.Text = (gross - disc + tax).ToString();
                    lblPayableAmount.Text = (gross - disc + tax).ToString();
                }
                if (paydamount > 0)
                {
                    txtBalance.Text = ((gross - disc + tax) - paydamount).ToString();
                    lblPayableAmount.Text = ((gross - disc + tax) - paydamount).ToString();
                }
            }
            else
            {
                if (totalamount < 0)
                {
                    numTxtTotlAmnt.Text = (gross - disc + tax).ToString();
                }
                else if (totalamount > 0)
                {
                    if (disc < 0)
                    {
                        numTxtTotlAmnt.Text = (gross + disc - tax).ToString();
                    }
                }
                else if (totalamount < 0)
                {
                    numTxtTotlAmnt.Text = (gross + disc - tax).ToString();
                }
                else if (totalamount > 0)
                {
                    numTxtTotlAmnt.Text = (gross - disc + tax).ToString();
                }

                if (paydamount > 0)
                {
                    txtBalance.Text = ((gross + disc - tax) + paydamount).ToString();
                    lblPayableAmount.Text = ((gross + disc - tax) + paydamount).ToString();
                }
                else if (paydamount > 0)
                {
                    if (totalamount > 0)
                    {
                        txtBalance.Text = ((gross - disc + tax) - paydamount).ToString();
                        lblPayableAmount.Text = ((gross - disc + tax) - paydamount).ToString();
                    }
                }
            }
        }

        #endregion
        private void numtxtTotalExtraDiscnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
            if (e.KeyChar == '\r')
            {
                CalculateNetAndBalance();
                //btnPayment_Click(null, null);
                txtskuCode.Text = string.Empty;
                txtAuthorisedBy.Focus();
            }
        }
        private void numtxtTotalExtraDiscnt_Leave(object sender, EventArgs e)
        {
            CalculateNetAndBalance();
            txtAuthorisedBy.Focus();
        }
        private void txtAuthorisedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CalculateNetAndBalance();
                txtCashReceived.Focus();
            }
        }
        private void txtCashReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CalculateNetAndBalance();
                btnSaveOrder.Focus();
            }
        }
        private void ClearMasterAll()
        {
            try
            {
                txtskuCode.Focus();
                EnableDisableController(true);
                btnSaveOrder.Enabled = true;
                CreatTable();
                CreateFreeSku();
                LoadGird();
                LoadFreeGrid();
                txtGrossAmount.Text = "";
                numtxtTotalExtraDiscnt.Text = "";
                numTxtTotalGST.Text = "";
                numTxtTotlAmnt.Text = "";
                txtCashReceived.Text = "";
                txtBalance.Text = "";
                lblPayableAmount.Text = "";
                btnToggleMode.Text = "SALE MODE";
                btnToggleMode.Enabled = true;
                txtQuantity.Text = btnToggleMode.Text != "SALE MODE" ? "-1" : "1";
                _rowId = 0;
                _mCustomerVolClassId = 0;
                chkSectionSale.Checked = false;
                if (SessionClass.IsDiscountAllowed)
                {
                    txtAuthorisedBy.Text = SessionClass.UserName;
                    cbDiscount.Checked = true;
                    cbDiscount.Enabled = false;
                    numtxtTotalExtraDiscnt.ReadOnly = false;
                    txtAuthorisedBy.ReadOnly = false;
                }
                else
                {
                    txtAuthorisedBy.Text = string.Empty;
                    cbDiscount.Checked = false;
                    numtxtTotalExtraDiscnt.ReadOnly = true;
                    txtAuthorisedBy.ReadOnly = true;
                }
                try
                {
                    _dtSectionOrderID.Rows.Clear();
                }
                catch (Exception)
                {
                }
                try
                {
                    ddonHoldList.SelectedIndex = 0;
                }
                catch (Exception)
                {
                }
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        private void LoadFreeGrid()
        {
            GrdFreeSKU.AutoGenerateColumns = false;
            GrdFreeSKU.Rows.Clear();
            foreach (DataRow dr in _dtFreeSku.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(GrdFreeSKU);
                row.Cells[0].Value = dr["SKU_IDF"];
                row.Cells[1].Value = dr["SKU_CodeF"];
                row.Cells[2].Value = dr["SKU_NameF"];
                row.Cells[3].Value = dr["QuantityF"];
                GrdFreeSKU.Rows.Add(row);
            }
        }
        #region PrintINvoice

        private void PrintReport(int type)
        {
            try
            {
                if (type == 1) // old 3inch receipt which code of all design is in Draw e.Graphics .NET code
                {
                    PrintType = type;
                    _prnDocument = new System.Drawing.Printing.PrintDocument();
                    _prnDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnDocument_PrintPage);
                    _prnDocument.Print();
                    //PrintPreviewDialog _dlg = new PrintPreviewDialog();
                    //_dlg.Document = _prnDocument;
                    //_dlg.ShowDialog();

                }
                else if (type == 3) // 3 inch receipt newly designed in Crystal Reports
                {
                    _discouunt = 0;
                    _discountType = 0;
                    var invoiceCreditHeading = "";
                    string invNumb = "";
                    long idToPrint = 0;
                    decimal amountDue = 0;
                    decimal totalAmount = 0;
                    string SaleInvTitle = "Sale Invoice";

                    if (_saleInvoiceId == 0 && _saleInvId > 0)
                    {
                        _saleInvoiceId = _saleInvId;
                    }

                    if(_psDt == null)
                    {
                        _psDt = new RptCustomerController().SelectCustomerInvoiceDetail(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, 1, _saleInvoiceId, SessionClass.CurrentWorkDate , SessionClass.CurrentWorkDate);
                    }

                    foreach (DataRow dr in _psDt.Rows)
                    {

                        var invType = dr["InvoiceType"].ToString();

                        //Discount things

                        totalAmount = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
                        amountDue = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);
                        _discouunt = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);
                        _discountType = Convert.ToInt32(dr["DISCOUNT_TYPE"]);

                        if (invType == "SaleInvoice")
                        {
                            idToPrint = _saleInvoiceId;
                            _invoiceNumber = lblTill.Text + idToPrint.ToString();
                            //InvSubTitle3 = "Sale Invoice";//sale mode
                            invoiceCreditHeading = lblTill.Text;
                        }
                        else
                        {
                            idToPrint = _saleInvoiceId;
                            _invoiceNumber = lblTill.Text + idToPrint.ToString();
                            //InvSubTitle3 = "Refund Invoice";
                            SaleInvTitle = "Sale Return";
                            invoiceCreditHeading = lblTill.Text;
                        }
                        break;
                    }

                    if (SessionClass.ISREPRINT == 1)
                    {
                        invNumb = invoiceCreditHeading + idToPrint;
                        SaleInvTitle = "Duplicate " + SaleInvTitle;
                        //g.DrawString(invoiceCreditHeading + idToPrint + "  (Duplicate)", InvoiceFontNew, _blueBrush, 5, CurrentY);
                    }
                    else
                    {
                        invNumb = invoiceCreditHeading + idToPrint;
                        //g.DrawString(invoiceCreditHeading + idToPrint, InvoiceFontNew, _blueBrush, 5, CurrentY);
                    }

                    if (SessionClass.ReceiptPrintSize == "3Inch")
                    {
                        CORNBusinessLayer.Reports.CrpSaleInv3inch crpReport = new CORNBusinessLayer.Reports.CrpSaleInv3inch();

                        //SUB REPORT DATASOURCE SETTING BEFORE MAIN REPORT DATASET SETTING
                        crpReport.Subreports[0].SetDataSource(SessionClass.dtNotes);

                        crpReport.SetDataSource(_psDt);
                        //crpReport.Refresh();
                        crpReport.SetParameterValue("SaleInvTitle", SaleInvTitle);
                        crpReport.SetParameterValue("InvNumb", invNumb);
                        crpReport.SetParameterValue("CompanyName", CompanyName);
                        crpReport.SetParameterValue("CompAddress", Address);

                        if (!string.IsNullOrEmpty(CompanyPhonNmbr))
                        {
                            crpReport.SetParameterValue("Phone1", "Ph#: " + CompanyPhonNmbr);
                        }
                        else
                        {
                            crpReport.SetParameterValue("Phone1", "");
                        }

                        if (!string.IsNullOrEmpty(CompanyPhonNmbr1))
                        {
                            crpReport.SetParameterValue("Phone2", "Ph#: " + CompanyPhonNmbr1);
                        }
                        else
                        {
                            crpReport.SetParameterValue("Phone2", "");
                        }

                        if (!string.IsNullOrEmpty(ntnNo))
                        {
                            crpReport.SetParameterValue("NTN", "NTN: " + ntnNo);
                        }
                        else
                        {
                            crpReport.SetParameterValue("NTN", "");
                        }

                        //discount changes
                        if (_discouunt != 0)
                        {                            

                            if (rbtnage.Checked || _discountType == 1)
                            {
                                crpReport.SetParameterValue("DiscountLbl", "Discount(%):");
                                if (_discountType == 1)
                                {
                                    _discouunt = (_discouunt / totalAmount) * 100;
                                }                                
                            }
                            else
                            {
                                crpReport.SetParameterValue("DiscountLbl", "Discount:");
                            }

                            crpReport.SetParameterValue("Discount", _discouunt);
                            crpReport.SetParameterValue("AmountDue", amountDue);
                            crpReport.SetParameterValue("AmountDueLbl", "Amount Due:");
                        }
                        else
                        {
                            crpReport.SetParameterValue("Discount", "0");
                            crpReport.SetParameterValue("DiscountLbl", "");
                            crpReport.SetParameterValue("AmountDue", "0");
                            crpReport.SetParameterValue("AmountDueLbl", "");
                        }

                        crpReport.PrintToPrinter(1, false, 0, 0);

                    }
                    else if (SessionClass.ReceiptPrintSize == "A4")
                    {
                        CORNBusinessLayer.Reports.CrpSaleInvA4 crpReportA4 = new CORNBusinessLayer.Reports.CrpSaleInvA4();

                        //SUB REPORT DATASOURCE SETTING BEFORE MAIN REPORT DATASET SETTING
                        crpReportA4.Subreports[0].SetDataSource(SessionClass.dtNotes);

                        crpReportA4.SetDataSource(_psDt);
                        //crpReport.Refresh();
                        crpReportA4.SetParameterValue("SaleInvTitle", SaleInvTitle);
                        crpReportA4.SetParameterValue("InvNumb", invNumb);
                        crpReportA4.SetParameterValue("CompanyName", CompanyName);
                        crpReportA4.SetParameterValue("CompAddress", Address);

                        if (!string.IsNullOrEmpty(CompanyPhonNmbr))
                        {
                            crpReportA4.SetParameterValue("Phone1", "Ph#: " + CompanyPhonNmbr);
                        }
                        else
                        {
                            crpReportA4.SetParameterValue("Phone1", "");
                        }

                        if (!string.IsNullOrEmpty(CompanyPhonNmbr1))
                        {
                            crpReportA4.SetParameterValue("Phone2", "Ph#: " + CompanyPhonNmbr1);
                        }
                        else
                        {
                            crpReportA4.SetParameterValue("Phone2", "");
                        }

                        if (!string.IsNullOrEmpty(ntnNo))
                        {
                            crpReportA4.SetParameterValue("NTN", "NTN: " + ntnNo);
                        }
                        else
                        {
                            crpReportA4.SetParameterValue("NTN", "");
                        }

                        //discount changes
                        if (_discouunt != 0)
                        {
                            if (rbtnage.Checked || _discountType == 1)
                            {
                                crpReportA4.SetParameterValue("DiscountLbl", "Discount(%):");
                                _discouunt = (_discouunt / totalAmount) * 100;
                            }
                            else
                            {
                                crpReportA4.SetParameterValue("DiscountLbl", "Discount:");
                            }

                            crpReportA4.SetParameterValue("Discount", _discouunt);
                            crpReportA4.SetParameterValue("AmountDue", amountDue);
                            crpReportA4.SetParameterValue("AmountDueLbl", "Amount Due:");
                        }
                        else
                        {
                            crpReportA4.SetParameterValue("Discount", "0");
                            crpReportA4.SetParameterValue("DiscountLbl", "");
                            crpReportA4.SetParameterValue("AmountDue", "0");
                            crpReportA4.SetParameterValue("AmountDueLbl", "");
                        }

                        crpReportA4.PrintToPrinter(1, false, 0, 0);
                    }
                    else
                    {
                        MessageBox.Show("No page size selected in configuration to print the receipt, please contact the support team");
                    }

                    

                    //FormReport _formReport = new FormReport();
                    //_formReport.crvReportViewer.ReportSource = crpReport;
                    //_formReport.ShowDialog();
                }
                _psDt = null;
                SessionClass.ISREPRINT = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "CORN : POS");
                ExceptionPublisher.PublishException(e);
            }
        }
        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            leftMargin = (int)e.MarginBounds.Left;//100
            rightMargin = (int)e.MarginBounds.Right;//215
            topMargin = (int)e.MarginBounds.Top;//100
            topMargin = 0;
            bottomMargin = (int)e.MarginBounds.Bottom;//1069
            InvoiceWidth = (int)e.MarginBounds.Width;//115
            InvoiceHeight = (int)e.MarginBounds.Height;//969

            if (PrintType != 4)
            {
                SetInvoiceHead(e.Graphics); // Draw Invoice Head
                SetInvoiceData(e.Graphics, e); // Draw Invoice Data
            }
            else if (PrintType == 4)
            {
                SetSaleReportHead(e.Graphics);
            }

            ReadInvoice = true;
        }
        private void SetInvoiceHead(Graphics g)
        {
            ReadInvoiceHead();
            System.Drawing.Image img = null;
            if (lblIsPrint.Text == "1")         // reprint
            {
                if (_psDt.Rows.Count > 0)
                {
                    foreach (DataRow dr in _psDt.Rows)
                    {
                        CurrentY = topMargin;
                        CurrentX = leftMargin;
                        const int imageHeight = 0;
                        InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
                        InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));
                        // Get Titles Length:
                        int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
                        int lenInvTitle1 = (int)g.MeasureString(InvTitle1, InvSubTitleFont).Width;
                        int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
                        int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitle3Font).Width;
                        int lenInvSubTitle5 = (int)g.MeasureString(InvSubTitle5, InvSubTitle2Font).Width;
                        int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
                        int lenInvSubTitle4 = (int)g.MeasureString(InvSubTitle4, InvSubTitleFont).Width;

                        // Set Titles Left:
                        int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
                        int xInvTitle1 = CurrentX + (InvoiceWidth - lenInvTitle1) / 2;
                        int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
                        int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
                        
                        int xInvSubTitle5 = CurrentX + (InvoiceWidth - lenInvSubTitle5) / 2;
                        //int xInvSubTitle5 = rightMargin + (InvoiceWidth - lenInvSubTitle5) / 2; // right alignment

                        int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;
                        int xInvSubTitle4 = CurrentX + (InvoiceWidth - lenInvSubTitle4) / 2;

                        
                        // Draw Invoice Head:

                        try
                        {
                            if (SessionClass.ShowLogo)
                            {
                                img = byteArrayToImage(SessionClass.InvLogo);
                                // img = System.Drawing.Image.FromFile(Application.StartupPath + @"\InvLogo.png"); 
                            }
                        }
                        catch (Exception)
                        {

                        }
                        if (SessionClass.ShowLogo)
                        {
                            g.DrawImage(img, 14, CurrentY + 10);
                            CurrentY = CurrentY + 10;
                            if (InvTitle != "")  // Company Name
                            {
                                CurrentY = CurrentY + imageHeight;
                                g.DrawString(InvTitle, InvTitleFont, _blueBrush, 90, CurrentY);
                            }
                            if (InvTitle1 != "") // Empty
                            {
                                CurrentY = CurrentY + InvTitleHeight;
                                g.DrawString(InvTitle1, InvSubTitleFont, _blueBrush, 90, CurrentY);
                            }
                            //if (InvSubTitle1 != "")   // Branch
                            //{
                            //    CurrentY = CurrentY + InvTitleHeight;
                            //    g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, 90, CurrentY);  //xInvSubTitle1
                            //} 
                            if (InvSubTitle2 != "") // Address
                            {
                                CurrentY = CurrentY + InvSubTitleHeight + 3;
                                if (InvSubTitle2.Length > 25)
                                {
                                    g.DrawString(InvSubTitle2.Substring(0, 24), InvSubTitle3Font, _blueBrush, 90, CurrentY); //xInvSubTitle2 _ CurrentY
                                }
                                else
                                {
                                    g.DrawString(InvSubTitle2, InvSubTitle3Font, _blueBrush, 90, CurrentY); //xInvSubTitle2 _ CurrentY
                                }
                            }
                            if (true)  // Phone 1
                            {
                                CurrentY = CurrentY + InvSubTitleHeight;
                                g.DrawString("Ph1 #: " + InvSubTitle5, InvSubTitle2Font, _blueBrush, 90, CurrentY); //xInvSubTitle5 _ 
                            }
                            if (InvSubTitle51 != "")   //  Contact Person (Phone 2)
                            {
                                CurrentY = CurrentY + InvSubTitleHeight;
                                g.DrawString("Ph2 #: " + InvSubTitle51, InvSubTitle2Font, _blueBrush, 90, CurrentY); //xInvSubTitle5 _ 
                            }
                            if (InvSubTitle52 != "")   //  NTN NO
                            {
                                //CurrentY = CurrentY + InvSubTitleHeight;
                                //g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, 90, CurrentY); //xInvSubTitle5 _ 
                                g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, 8, CurrentY); //xInvSubTitle5 _ 
                            }
                        }
                        else
                        {
                            if (InvTitle != "") // Company
                            {
                                CurrentY = CurrentY + imageHeight;
                                g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
                            }
                            if (InvTitle1 != "") // Empty
                            {
                                CurrentY = CurrentY + InvTitleHeight;
                                g.DrawString(InvTitle1, InvSubTitleFont, _blueBrush, xInvTitle1, CurrentY);
                            }
                            //if (InvSubTitle1 != "")   //Branch
                            //{
                            //    CurrentY = CurrentY + InvTitleHeight;
                            //    g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);  //xInvSubTitle1
                            //}
                            if (InvSubTitle2 != "") //Address
                            {
                                CurrentY = CurrentY + InvSubTitleHeight + 3;
                                if (InvSubTitle2.Length > 25)
                                {
                                    g.DrawString(InvSubTitle2.Substring(0, 24), InvSubTitle3Font, _blueBrush, xInvSubTitle2, CurrentY); //xInvSubTitle2 _ CurrentY
                                }
                                else
                                {
                                    g.DrawString(InvSubTitle2, InvSubTitle3Font, _blueBrush, xInvSubTitle2, CurrentY); //xInvSubTitle2 _ CurrentY
                                }
                            }
                            if (true) // Phone 1
                            {
                                CurrentY = CurrentY + InvSubTitleHeight;
                                g.DrawString("Ph1 #: " + InvSubTitle5, InvSubTitle2Font, _blueBrush, xInvSubTitle5 + 20, CurrentY); //xInvSubTitle5 _ 
                            }
                            if (InvSubTitle51 != "")   //  Contact Person (Phone 2)
                            {
                                CurrentY = CurrentY + InvSubTitleHeight;
                                g.DrawString("Ph2 #: " + InvSubTitle51, InvSubTitle2Font, _blueBrush, xInvSubTitle5 + 20, CurrentY); //xInvSubTitle5 _ 
                            }
                            if (InvSubTitle52 != "")   //  NTN NO
                            {
                                //CurrentY = CurrentY + InvSubTitleHeight;
                                //g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, xInvSubTitle5, CurrentY); //xInvSubTitle5 _ 
                                g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, 7, CurrentY); //xInvSubTitle5 _ 
                            }
                        }

                        long idToPrint = 0;
                        var invoiceCreditHeading = "";

                        var invType = dr["InvoiceType"].ToString();

                        if (invType == "SaleInvoice")
                        {
                            idToPrint = _saleInvId;
                            _invoiceNumber = lblTill.Text + idToPrint.ToString();
                            InvSubTitle3 = "Sale Invoice";//sale mode
                            invoiceCreditHeading = "INV #  " + lblTill.Text;
                        }
                        else
                        {
                            idToPrint = _saleInvId;
                            _invoiceNumber = lblTill.Text + idToPrint.ToString();
                            InvSubTitle3 = "Refund Invoice";
                            invoiceCreditHeading = "INV #  " + lblTill.Text;
                        }

                        if (InvSubTitle3 != "")
                        {
                            CurrentY = CurrentY + InvSubTitleHeight + 10;
                            g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 5, CurrentY);
                        }
                        //For Payment Mode
                        InvSubTitle4 = "MOP: ";

                        var MOP = dr["MOP"].ToString();
                        PaymentMode = dr["MOP"].ToString();
                        if (MOP == "Cash")
                        {
                            g.DrawString(InvSubTitle4 + MOP, InvSubTitle2Font, _blueBrush, 200, CurrentY+8);
                        }
                        else if (MOP == "Credit")
                        {
                            g.DrawString(InvSubTitle4 + MOP, InvSubTitle2Font, _blueBrush, 200, CurrentY+8);
                        }
                        else
                        {
                            g.DrawString(InvSubTitle4 + MOP, InvSubTitle2Font, _blueBrush, 200, CurrentY+8);
                        }
                        // Draw line:
                        CurrentY = CurrentY + 20;
                        g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                        CurrentY = CurrentY + 2;
                        if (SessionClass.ISREPRINT == 1)
                        {
                            g.DrawString(invoiceCreditHeading + idToPrint + "  (Duplicate)", InvoiceFontNew, _blueBrush, 5, CurrentY);
                        }
                        else
                        {
                            g.DrawString(invoiceCreditHeading + idToPrint, InvoiceFontNew, _blueBrush, 5, CurrentY);
                        }

                        g.DrawString("Units: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                        XNoOfuntit = (int)g.MeasureString("Units: ", InvoiceFontNew).Width + 150;
                        YNoOfUnit = CurrentY;
                        CurrentY = CurrentY + 15;
                        //g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                        //CurrentY = CurrentY + 2;
                        g.DrawString("Date: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                        //----------------------------Barcode----------------------
                        //int length = _invoiceNumber.Length;
                        //if (length != 11)
                        //{
                        //    int _zeros = 12 - length;
                        //    char[] _sep = new char[] { '-' };
                        //    string[] _strings = _invoiceNumber.Split(_sep, StringSplitOptions.None);
                        //    for (int i = 0; i < _zeros; i++)
                        //    {
                        //        _strings[1] = "0" + _strings[1];
                        //    }
                        //    _invoiceNumber = _strings[0] + _strings[1];
                        //}
                        //g.DrawString("*" + _invoiceNumber + "*", new System.Drawing.Font("IDAutomationHC39M Free Version", 7, FontStyle.Regular), Brushes.Black, 140, CurrentY + 15);
                        //----------------------------------------------------------
                        // CurrentY = CurrentY + 15;
                        string time = DateTime.Now.ToString("hh:mm tt");
                        if (_psDt.Rows.Count > 0)
                        {
                            time = Convert.ToDateTime(_psDt.Rows[0].ItemArray[16]).ToString("HH:mm tt");
                        }
                        g.DrawString(SessionClass.CurrentWorkDate.ToString("dd-MMM-yy") + ' ' + time, InvoiceFontNew, _blueBrush, 180, CurrentY);
                        g.DrawString("Cashier: ", InvoiceFontNew, _blueBrush, 5, CurrentY);
                        // CurrentY = CurrentY + 15;
                        g.DrawString(lbluserlogin.Text, InvoiceFontNew, _blueBrush, 70, CurrentY);
                        CurrentY = CurrentY + 15;
                        //g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);//
                        string customerName = "";
                        if (_psDt.Rows.Count > 0)
                        {
                            customerName = _psDt.Rows[0].ItemArray[3].ToString();
                        }
                        g.DrawString("Customer: " + customerName, InvoiceFontNew, _blueBrush, 5, CurrentY);
                        g.DrawString("Cell#: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                        g.DrawString(lblCustCell.Text, InvoiceFontNew, _blueBrush, 180, CurrentY);
                        CurrentY = CurrentY + 15;
                        g.DrawString("Address: ", InvoiceFontNew, _blueBrush, 5, CurrentY);
                        g.DrawString(lblCustAddress.Text, InvoiceFontNew, _blueBrush, 50, CurrentY);
                        CurrentY = CurrentY + 15;
                        g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                        break;
                    }
                }
            }
            else    // First time print
            {
                CurrentY = topMargin;
                CurrentX = leftMargin;
                const int imageHeight = 0;
                InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
                InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

                // Get Titles Length:
                int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
                int lenInvTitle1 = (int)g.MeasureString(InvTitle1, InvSubTitleFont).Width;
                int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
                int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitle3Font).Width;
                int lenInvSubTitle5 = (int)g.MeasureString(InvSubTitle5, InvSubTitle2Font).Width;
                int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
                int lenInvSubTitle4 = (int)g.MeasureString(InvSubTitle4, InvSubTitleFont).Width;
                // Set Titles Left:
                int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
                int xInvTitle1 = CurrentX + (InvoiceWidth - lenInvTitle1) / 2;
                int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
                int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;

                int xInvSubTitle5 = CurrentX + (InvoiceWidth - lenInvSubTitle5) / 2;
                //int xInvSubTitle5 = rightMargin + (InvoiceWidth - lenInvSubTitle5) / 2; // right alignment

                int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;
                int xInvSubTitle4 = CurrentX + (InvoiceWidth - lenInvSubTitle4) / 2;

                
                // Draw Invoice Head:
                try
                {
                    if (SessionClass.ShowLogo)
                    {
                        img = byteArrayToImage(SessionClass.InvLogo);
                        // img = System.Drawing.Image.FromFile(Application.StartupPath + @"\InvLogo.png");
                    }
                }
                catch (Exception)
                {

                }
                if (SessionClass.ShowLogo)
                {
                    g.DrawImage(img, 14, CurrentY + 10);
                    CurrentY = CurrentY + 10;
                    if (InvTitle != "") // Company Name
                    {
                        CurrentY = CurrentY + imageHeight;
                        g.DrawString(InvTitle, InvTitleFont, _blueBrush, 90, CurrentY);
                    }
                    if (InvTitle1 != "") // Empty
                    {
                        CurrentY = CurrentY + InvTitleHeight;
                        g.DrawString(InvTitle1, InvSubTitleFont, _blueBrush, 90, CurrentY);
                    }
                    //if (InvSubTitle1 != "") // Branch Name   
                    //{
                    //    CurrentY = CurrentY + InvTitleHeight;
                    //    g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, 90, CurrentY);  //xInvSubTitle1
                    //}
                    if (InvSubTitle2 != "") // Address
                    {
                        CurrentY = CurrentY + InvSubTitleHeight + 3;
                        if (InvSubTitle2.Length > 25)
                        {
                            g.DrawString(InvSubTitle2.Substring(0, 24), InvSubTitle3Font, _blueBrush, 90, CurrentY); //xInvSubTitle2 _ CurrentY
                        }
                        else
                        {
                            g.DrawString(InvSubTitle2, InvSubTitle3Font, _blueBrush, 90, CurrentY); //xInvSubTitle2 _ CurrentY
                        }
                    }
                    if (true) // Phone 1
                    {
                        CurrentY = CurrentY + InvSubTitleHeight;
                        g.DrawString("Ph1 #: " + InvSubTitle5, InvSubTitle2Font, _blueBrush, 90, CurrentY); //xInvSubTitle5 _ 
                    }
                    if (InvSubTitle51 != "")     // Contact Person(Phone No 2) 
                    {
                        CurrentY = CurrentY + InvSubTitleHeight;
                        g.DrawString("Ph2 #: " + InvSubTitle51, InvSubTitle2Font, _blueBrush, 90, CurrentY); //xInvSubTitle5 _ 
                    }
                    if (InvSubTitle52 != "")   //  NTN NO
                    {
                        //CurrentY = CurrentY + InvSubTitleHeight;
                        //g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, xInvSubTitle5, CurrentY); //xInvSubTitle5 _ 
                        g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, 8, CurrentY); //xInvSubTitle5 _ 
                    }
                }
                else
                {
                    if (InvTitle != "")
                    {
                        CurrentY = CurrentY + imageHeight;
                        g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
                    }
                    if (InvTitle1 != "")
                    {
                        CurrentY = CurrentY + InvTitleHeight;
                        g.DrawString(InvTitle1, InvSubTitleFont, _blueBrush, xInvTitle1, CurrentY);
                    }
                    //if (InvSubTitle1 != "")
                    //{
                    //    CurrentY = CurrentY + InvTitleHeight + 3;
                    //    g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);  //xInvSubTitle1
                    //}
                    if (InvSubTitle2 != "") // Address
                    {
                        CurrentY = CurrentY + InvSubTitleHeight;
                        if (InvSubTitle2.Length > 25)
                        {
                            g.DrawString(InvSubTitle2.Substring(0, 24), InvSubTitle3Font, _blueBrush, xInvSubTitle2, CurrentY); //xInvSubTitle2 _ CurrentY
                        }
                        else
                        {
                            g.DrawString(InvSubTitle2, InvSubTitle3Font, _blueBrush, xInvSubTitle2, CurrentY); //xInvSubTitle2 _ CurrentY
                        }
                    }
                    if (true) // Phone No 1
                    {
                        CurrentY = CurrentY + InvSubTitleHeight;
                        g.DrawString("Ph1 #: " + InvSubTitle5, InvSubTitle2Font, _blueBrush, xInvSubTitle5 + 20, CurrentY); //xInvSubTitle5 _ 
                    }
                    if (InvSubTitle51 != "")     // Contact Person(Phone No2) 
                    {
                        CurrentY = CurrentY + InvSubTitleHeight;
                        g.DrawString("Ph2 #: " + InvSubTitle51, InvSubTitle2Font, _blueBrush, xInvSubTitle5 + 20, CurrentY); //xInvSubTitle5 _ 
                    }
                    if (InvSubTitle52 != "")   //  NTN NO
                    {
                        //CurrentY = CurrentY + InvSubTitleHeight;
                        //g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, xInvSubTitle5, CurrentY); //xInvSubTitle5 _ 
                        g.DrawString("NTN #: " + InvSubTitle52, InvSubTitle2Font, _blueBrush, 8, CurrentY); //xInvSubTitle5 _ 
                    }
                }

                long idToPrint = 0;
                string invoiceCreditHeading = "";
                if (btnToggleMode.Text == "SALE MODE")
                {
                    idToPrint = _saleInvoiceId;
                    _invoiceNumber = lblTill.Text + idToPrint.ToString();
                    InvSubTitle3 = "Sale Invoice";//slae mode
                    invoiceCreditHeading = "INV #  " + lblTill.Text;
                }
                else
                {
                    //refund mode
                    idToPrint = _saleInvoiceId;
                    _invoiceNumber = lblTill.Text + idToPrint.ToString();
                    InvSubTitle3 = "Refund Invoice";
                    invoiceCreditHeading = "INV #  " + lblTill.Text;
                }
                if (InvSubTitle3 != "")
                {
                    CurrentY = CurrentY + InvSubTitleHeight + 10;
                    g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 5, CurrentY);
                }
                //For Payment Mode
                InvSubTitle4 = "MOP: ";
                string strRblPayMode = "Cash";
                PaymentMode = strRblPayMode;
                if (RblPayMode2.Checked)
                {
                    strRblPayMode = "Mix Mode";
                }
                else if (RblPayMode3.Checked)
                {
                    strRblPayMode = RblPayMode3.Text;
                }
                else if (RblPayMode4.Checked)
                {
                    strRblPayMode = RblPayMode4.Text;
                }
                PaymentMode = strRblPayMode;
                g.DrawString(InvSubTitle4 + strRblPayMode, InvSubTitle2Font, _blueBrush, 200, CurrentY+8);

                // Draw line:
                CurrentY = CurrentY + 20;
                g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                CurrentY = CurrentY + 10;
                if (SessionClass.ISREPRINT == 1)
                {
                    g.DrawString(invoiceCreditHeading + idToPrint + "  (Duplicate)", InvoiceFontNew, _blueBrush, 5, CurrentY);
                }
                else
                {
                    g.DrawString(invoiceCreditHeading + idToPrint, InvoiceFontNew, _blueBrush, 5, CurrentY);
                }
                g.DrawString("Units: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                XNoOfuntit = (int)g.MeasureString("Units: ", InvoiceFontNew).Width + 150;
                YNoOfUnit = CurrentY;
                CurrentY = CurrentY + 15;
                //g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                //CurrentY = CurrentY + 2;
                g.DrawString("Date: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                //----------------------------Barcode----------------------
                //int length = _invoiceNumber.Length;
                //if (length != 11)
                //{
                //    int _zeros = 12 - length;
                //    char[] _sep = new char[] { '-' };
                //    string[] _strings = _invoiceNumber.Split(_sep, StringSplitOptions.None);
                //    for (int i = 0; i < _zeros; i++)
                //    {
                //        _strings[1] = "0" + _strings[1];
                //    }
                //    _invoiceNumber = _strings[0] + _strings[1];
                //}
                //g.DrawString("*" + _invoiceNumber + "*", new System.Drawing.Font("IDAutomationHC39M Free Version", 7, FontStyle.Regular), Brushes.Black, 140, CurrentY + 15);
                //----------------------------------------------------------
                // CurrentY = CurrentY + 15;
                g.DrawString(SessionClass.CurrentWorkDate.ToString("dd-MMM-yy") + ' ' + DateTime.Now.ToString("hh:mm tt"), InvoiceFontNew, _blueBrush, 180, CurrentY);
                //CurrentY = CurrentY + 15;
                g.DrawString("Cashier: ", InvoiceFontNew, _blueBrush, 5, CurrentY);
                //CurrentY = CurrentY + 15;
                g.DrawString(lbluserlogin.Text, InvoiceFontNew, _blueBrush, 50, CurrentY);
                CurrentY = CurrentY + 15;
                //g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);//
                //CurrentY = CurrentY + 2;
                string customerName = "Walk In Customer";
                customerName = drpCustomer.Text;
                g.DrawString("Customer: " + customerName, InvoiceFontNew, _blueBrush, 5, CurrentY);
                g.DrawString("Cell#: ", InvoiceFontNew, _blueBrush, 150, CurrentY);
                g.DrawString(lblCustCell.Text, InvoiceFontNew, _blueBrush, 180, CurrentY);
                CurrentY = CurrentY + 15;
                g.DrawString("Address: ", InvoiceFontNew, _blueBrush, 5, CurrentY);
                g.DrawString(lblCustAddress.Text, InvoiceFontNew, _blueBrush, 50, CurrentY);
                CurrentY = CurrentY + 15;
                g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
            }
            //  }

        }
        private void SetSaleReportHead(Graphics g)
        {
            var dt = _mOrderController.SelectSaleReport(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, Convert.ToDateTime(txtstartDate.Text), Convert.ToDateTime(txtEndDate.Text));
            decimal totalGrossSale = 0;
            decimal totalDiscount = 0;
            decimal totalGst = 0;
            decimal totalNetAMount = 0;
            decimal totalCredit = 0;
            totalGrossSale = Math.Round(decimal.Parse(dt.Rows[0]["TOTAL_AMOUNT"].ToString()), 2);
            totalDiscount = Math.Round(decimal.Parse(dt.Rows[0]["DISCOUNT"].ToString()), 2);
            totalGst = Math.Round(decimal.Parse(dt.Rows[0]["GST_AMOUNT"].ToString()), 2);
            totalNetAMount = Math.Round(decimal.Parse(dt.Rows[0]["NET_TOTAL"].ToString()), 2);
            totalCredit = Math.Round(decimal.Parse(dt.Rows[0]["CREDIT_AMOUNT"].ToString()), 2);
            ReadInvoiceHead();

            CurrentY = topMargin;
            CurrentX = leftMargin;
            const int imageHeight = 100;
            InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
            int lenInvTitle1 = (int)g.MeasureString(InvTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
            int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
            int xInvTitle1 = CurrentX + (InvoiceWidth - lenInvTitle1) / 2;
            int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
            int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
            int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

            // Draw Invoice Head:
            if (InvTitle != "")
            {
                CurrentY = CurrentY + imageHeight;
                g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
            }
            if (InvTitle1 != "")
            {
                CurrentY = CurrentY + imageHeight;
                g.DrawString(InvTitle1, InvSubTitleFont, _blueBrush, xInvTitle1, CurrentY);
            }
            if (InvSubTitle1 != "")
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);
            }
            if (InvSubTitle2 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle2, InvSubTitleFont, _blueBrush, xInvSubTitle2, CurrentY);
            }
            InvSubTitle3 = "SALES REPORT";//
            CurrentY = CurrentY + InvSubTitleHeight + 10;
            g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 100, CurrentY);

            CurrentY = CurrentY + InvSubTitleHeight + 15;
            g.DrawString("From  :" + txtstartDate.Text + "   To  :" + txtEndDate.Text, InvSubTitleFont, _blueBrush, 10, CurrentY);

            // Draw line:

            // totalGrossSale=totalGrossSale-totalDiscount-totalGST;
            CurrentY = CurrentY + InvSubTitleHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 1), 10, CurrentY, 290, CurrentY);

            CurrentY = CurrentY + 20;
            g.DrawString("Total Amount  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalGrossSale.ToString(), _saleFont, _blueBrush, 200, CurrentY);
            CurrentY = CurrentY + 30;

            g.DrawString("Discount  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalDiscount.ToString(), _saleFont, _blueBrush, 200, CurrentY);

            CurrentY = CurrentY + 30;
            g.DrawString("GST  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalGst.ToString(), _saleFont, _blueBrush, 200, CurrentY);

            CurrentY = CurrentY + 30;
            g.DrawString("Credit  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalCredit.ToString(), _saleFont, _blueBrush, 200, CurrentY);

            CurrentY = CurrentY + 30;
            g.DrawString("Net Sale  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalNetAMount.ToString(), _saleFont, _blueBrush, 200, CurrentY);

            CurrentY = CurrentY + 30;
            g.DrawString("Cash Recieved  : ", _saleFont, _blueBrush, 30, CurrentY);
            g.DrawString(totalNetAMount.ToString(), _saleFont, _blueBrush, 200, CurrentY);
            CurrentY = CurrentY + 30;

            g.DrawLine(new Pen(Brushes.Black, 1), 10, CurrentY, 290, CurrentY);
            CurrentY = CurrentY + 15;
            // g.DrawString("User  :" + _dc.chkNull_0(ddsalesForce.SelectedItem.ToString()), SaleFont, BlueBrush, 10, CurrentY);
            g.DrawString("Date : " + DateTime.Now.ToString("dd-MMM-yyyy"), _saleFont, _blueBrush, 200, CurrentY);
            CurrentY = CurrentY + 40;
            g.DrawString("Powered By:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 10, CurrentY);
        }
        private void ReadInvoiceHead()
        {
            //Titles and Image of invoice:
            InvTitle = CompanyName;
            InvTitle1 = HirarchyNameQuiz2;
            InvSubTitle1 = lblLoacation.Text;
            InvSubTitle2 = Address;
            InvSubTitle5 = CompanyPhonNmbr1; //lblphone.Text; 
            InvSubTitle51 = CompanyPhonNmbr; //lblphone1.Text; 
            InvSubTitle52 = ntnNo; //lblphone1.Text; 
            // InvSubTitle3 = lblphone.Text;
            // InvImage = Application.StartupPath + @"\Images\" + "InvPic.jpg";
        }
        private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Set Numeric Values to Right Align
            _stringFormate.Alignment = StringAlignment.Far;
            // Set Invoice Table:
            string fieldValue = "";
            decimal fieldValue2 = 0;
            int currentRecord = 0;

            // Set Table Head:
            const int xProductId = 5; //leftMargin;
            //  CurrentY = CurrentY + 20;//InvoiceFontHeight;
            //  g.DrawLine(new Pen(Brushes.Black), 10, CurrentY, 290, CurrentY);
            CurrentY = CurrentY + 5;//InvoiceFontHeight;
            g.DrawString("Item Name", InvoiceFont, _blueBrush, xProductId, CurrentY);

            int xProductName = xProductId + (int)g.MeasureString("Item", InvoiceFont).Width + 115;
            g.DrawString("Qty", InvoiceFont, _blueBrush, xProductName, CurrentY);


            int xUnitPrice = xProductName + (int)g.MeasureString("Qty", InvoiceFont).Width + 10;
            g.DrawString("Price", InvoiceFont, _blueBrush, xUnitPrice, CurrentY);

            int xQuantity = xUnitPrice + (int)g.MeasureString("Price", InvoiceFont).Width + 10;
            g.DrawString("Total", InvoiceFont, _blueBrush, xQuantity + 5, CurrentY);



            // Set Invoice Table:
            CurrentY = CurrentY + 20;//InvoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
            CurrentY = CurrentY + 10;//InvoiceFontHeight + 8;
            //while (CurrentRecord < RecordsPerPage)
            decimal numberOfUnit = 0;

            if (lblIsPrint.Text == "1")
            {
                if (_psDt.Rows.Count > 0)
                {
                    foreach (DataRow dr in _psDt.Rows)
                    {
                        decimal chkdiscount = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);
                        //if (chkdiscount < 0)
                        //{
                        //    fieldValue = dr["BAR_CODE"] + " " + "    UPSELL";
                        //    g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);
                        //}
                        //else
                        //{
                        //    fieldValue = dr["BAR_CODE"].ToString();
                        //    g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);
                        //}

                        //For Refund Check
                        decimal qty = 0;
                        qty = Convert.ToDecimal(dr["QUANTITY_UNIT"]);


                        if (qty > 0)
                        {
                            fieldValue = dr["SKU_NAME"].ToString().ToUpper();// name
                            if (fieldValue.Length > 20)
                                fieldValue = fieldValue.Remove(20, fieldValue.Length - 20);
                            g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductId, CurrentY);
                        }
                        else
                        {
                            fieldValue = dr["SKU_NAME"] + "_" + "(Rfnd)";// name
                            if (fieldValue.Length > 20)
                                fieldValue = fieldValue.Remove(20, fieldValue.Length - 20);
                            g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductId, CurrentY);
                        }
                        fieldValue = String.Format("{0:0.00}", dr["QUANTITY_UNIT"]);  //quantity
                        numberOfUnit += Convert.ToDecimal(dr["QUANTITY_UNIT"].ToString());
                        g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductName + 20, CurrentY, _stringFormate);

                        decimal untPrice = Convert.ToDecimal(dr["UNIT_PRICE"]);

                        // FieldValue2 = Math.Ceiling(Convert.ToDecimal((unt_price)));//Price
                        fieldValue2 = Convert.ToDecimal(untPrice);//Price

                        fieldValue = String.Format("{0:0.0}", fieldValue2);
                        g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xUnitPrice + 37, CurrentY, _stringFormate);

                        untPrice = Convert.ToDecimal(dr["AMOUNT"]);

                        // FieldValue2 = Math.Ceiling(Convert.ToDecimal((unt_price)));//Total
                        fieldValue2 = Convert.ToDecimal(untPrice);//Total

                        fieldValue = String.Format("{0:0.0}", fieldValue2);
                        g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xQuantity + 40, CurrentY, _stringFormate);

                        CurrentY = CurrentY + 15;
                        // g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
                        // CurrentY = CurrentY + 10;
                        currentRecord++;
                        if (chkdiscount >= 0)
                        {
                            _cashRcd = Convert.ToDecimal(dr["CASH_RECIEVED"]);//CAsh Rec
                            _discouunt = Convert.ToDecimal(dr["EXTRA_DISCOUNT_AMOUNT"]);//Discount Amount
                            _discountType = Convert.ToInt32(dr["DISCOUNT_TYPE"]);//Discount Type
                            _ttamount = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);//Sub-total
                            _ntamount = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);//Net total
                            if (_discountType == 1)
                            {
                                _discouunt = (_discouunt / _ttamount) * 100;
                            }
                        }
                    }
                    if (currentRecord > 0)
                    {
                        if (numberOfUnit < 0)
                        {
                            numberOfUnit = numberOfUnit * (-1);
                        }

                        g.DrawString(String.Format("{0:0.0}", numberOfUnit), InvoiceFontNew, _blackBrush, XNoOfuntit, YNoOfUnit);

                        SetPrintInvoiceTotal(g);

                        g.Dispose();
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dr in GrdPurchase.Rows)
                {
                    decimal qty = Convert.ToDecimal(dr.Cells[5].Value);
                    // qty = Convert.ToDecimal(qty);
                    if (qty > 0)
                    {
                        fieldValue = dr.Cells[2].Value.ToString().ToUpper();// name
                        if (fieldValue.Length > 20)
                            fieldValue = fieldValue.Remove(20, fieldValue.Length - 20);
                        g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductId, CurrentY);

                    }
                    else
                    {
                        fieldValue = dr.Cells[2].Value.ToString().ToUpper() + "_" + "Rfnd";// name
                        if (fieldValue.Length > 20)
                            fieldValue = fieldValue.Remove(20, fieldValue.Length - 20);
                        g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductId, CurrentY);
                    }
                    fieldValue = String.Format("{0:0.00}", dr.Cells[5].Value);  //quantity

                    g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductName + 20, CurrentY, _stringFormate);
                    numberOfUnit += Convert.ToDecimal(dr.Cells[5].Value);

                    //  FieldValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(dr.Cells[6].Text)));//price
                    fieldValue2 = Convert.ToDecimal(_dc.chkNull_0(dr.Cells[6].Value.ToString()));//price

                    fieldValue = String.Format("{0:0.00}", fieldValue2);
                    g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xUnitPrice + 37, CurrentY, _stringFormate);

                    // FieldValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(dr.Cells[7].Text)));//total
                    fieldValue2 = Convert.ToDecimal(_dc.chkNull_0(dr.Cells[7].Value.ToString()));//total

                    fieldValue = String.Format("{0:0.00}", fieldValue2);
                    g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xQuantity + 40, CurrentY, _stringFormate);

                    CurrentY = CurrentY + 15;
                    //   g.DrawLine(new Pen(Brushes.Black, 1), 10, CurrentY, 290, CurrentY);
                    //   CurrentY = CurrentY + 10;
                    currentRecord++;
                    // }
                }
                if (GrdFreeSKU.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dr2 in GrdFreeSKU.Rows)
                    {
                        int i = 0;
                        i = Convert.ToInt32(dr2.Cells[9].Value);
                        if (i == 0)
                        {
                            fieldValue = dr2.Cells[1].Value.ToString() + " " + "(UPSll)";//  bar code
                            g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);

                            fieldValue = dr2.Cells[3].Value.ToString();  //quantity

                            g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductName + 20, CurrentY, _stringFormate);

                            numberOfUnit += Convert.ToInt32(dr2.Cells[3].Value.ToString());
                            CurrentY = CurrentY + 12;
                            fieldValue = dr2.Cells[2].Value.ToString();// name
                            if (fieldValue.Length > 30)
                                fieldValue = fieldValue.Remove(22, fieldValue.Length - 22);
                            g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xProductId, CurrentY);
                            CurrentY = CurrentY + 15;
                            currentRecord++;
                        }
                    }
                }
                if (currentRecord > 0)
                {
                    if (numberOfUnit < 0)
                    {
                        numberOfUnit = numberOfUnit * (-1);
                    }

                    g.DrawString(String.Format("{0:0.00}", numberOfUnit), InvoiceFontNew, _blackBrush, XNoOfuntit, YNoOfUnit);

                    SetInvoiceTotal(g);

                    g.Dispose();
                }
            }
        }

        // For First Time Print
        private void SetInvoiceTotal(Graphics g)
        {
            _stringFormate.Alignment = StringAlignment.Far;
            string invoiceValue = "";
            decimal invoiceValue2 = 0;
            decimal netAmount = 0;
            decimal totalAmount = decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text));
            decimal discount = decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
            if (rbtnage.Checked)
            {
                discount = (totalAmount / 100) * discount;
            }
            decimal gst = decimal.Parse(_dc.chkNull_0(numTxtTotalGST.Text));
            decimal balance = 0;

            if (totalAmount > 0)
            {
                netAmount = (totalAmount - discount) + gst;
            }
            else
            {
                netAmount = (totalAmount + discount) - gst;
            }
            decimal resAmount = decimal.Parse(_dc.chkNull_0(txtCashReceived.Text));

            if (netAmount < 0 && RblPayMode3.Checked != true && RblPayMode4.Checked != true)
            {
                balance = netAmount + resAmount;
            }
            else if (RblPayMode3.Checked != true && RblPayMode4.Checked != true)
            {
                balance = netAmount - resAmount;
            }

            g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
            CurrentY = CurrentY + 5;
            g.DrawString("Total Amount:", InvoiceFont, _redBrush, 50, CurrentY);
            //invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(txtGrossAmount.Text)));
            invoiceValue2 = Convert.ToDecimal(_dc.chkNull_0(txtGrossAmount.Text));
            invoiceValue = String.Format("{0:0.00}", invoiceValue2);
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
            CurrentY = CurrentY + 15;//InvoiceFontHeight;

            if (discount != 0)
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                if (rbtnage.Checked)
                {
                    g.DrawString("Discount(%):", InvoiceFont, _redBrush, 50, CurrentY);
                }
                else
                {
                    g.DrawString("Discount:", InvoiceFont, _redBrush, 50, CurrentY);

                }
                //invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text)));
                invoiceValue2 = Convert.ToDecimal(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text));
                invoiceValue = String.Format("{0:0.00}", invoiceValue2);

                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 15;//InvoiceFontHeight;
            }

            CurrentY = CurrentY + 5;//InvoiceFontHeight;
            g.DrawString("Amount Due:", InvoiceFont, _redBrush, 50, CurrentY);
            //invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(netAmount.ToString())));
            invoiceValue2 = Convert.ToDecimal(_dc.chkNull_0(netAmount.ToString()));
            invoiceValue = String.Format("{0:0.00}", invoiceValue2);
            decimal amountdue = invoiceValue2;
            //int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
            CurrentY = CurrentY + 12;//InvoiceFontHeight;

            if (PrintType != 2)
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                g.DrawString("Cash Paid In:", InvoiceFont, _redBrush, 50, CurrentY);
                //invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text)));
                invoiceValue2 = Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text));
                invoiceValue = String.Format("{0:0.00}", invoiceValue2);
                decimal cashpaid = invoiceValue2;
                //int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 15;//InvoiceFontHeight;
                if (RblPayMode1.Checked == true && SessionClass.ISREPRINT == 0)
                {
                    CurrentY = CurrentY + 5;//InvoiceFontHeight;
                    g.DrawString("Customer Balance:", InvoiceFont, _redBrush, 50, CurrentY);
                    invoiceValue2 = Convert.ToDecimal(_dc.chkNull_0(balance.ToString()));
                    //invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(balance.ToString())));
                    invoiceValue = String.Format("{0:0.00}", cashpaid - amountdue);
                    g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);

                    CurrentY = CurrentY + 20;//InvoiceFontHeight;
                }
            }
            g.DrawLine(new Pen(Brushes.Black, 1 / 2), 5, CurrentY, 290, CurrentY);
            if (PaymentMode != "Cash")
            {
                CurrentY = CurrentY + 5;
                g.DrawString("Customer Account Balance:", InvoiceFont, _redBrush, 5, CurrentY);
                g.DrawString(GetCustomerCredit(), InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 20;
                g.DrawLine(new Pen(Brushes.Black, 1 / 2), 5, CurrentY, 290, CurrentY);
            }

            //nOTES
            for (int i = 0; i < SessionClass.dtNotes.Rows.Count; i++)
            {
                CurrentY = CurrentY + 12;
                g.DrawString("\u2022 " + SessionClass.dtNotes.Rows[i].ItemArray[0].ToString(), InvoiceFont2, _blackBrush, 5, CurrentY);
            }

            CurrentY = CurrentY + 20;//InvoiceFontHeight;

            g.DrawString("Thanks For Shopping.", InvoiceFont, _blackBrush, 80, CurrentY);
            CurrentY = CurrentY + 20;//InvoiceFontHeight;

            g.DrawString("Powered By:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 5, CurrentY);
        }

        //For RePrint Invoice
        private void SetPrintInvoiceTotal(Graphics g)
        {
            _stringFormate.Alignment = StringAlignment.Far;
            g.DrawLine(new Pen(Brushes.Black, 1), 5, CurrentY, 290, CurrentY);
            CurrentY = CurrentY + 5;

            g.DrawString("Total Amount:", InvoiceFont, _redBrush, 50, CurrentY);
            string invoiceValue = String.Format("{0:0.00}", _ttamount);
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
            CurrentY = CurrentY + 20;//InvoiceFontHeight;
            //g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 290, CurrentY);

            if (_discouunt != 0)
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                if (_discountType == 0)
                {
                    g.DrawString("Discount:", InvoiceFont, _redBrush, 50, CurrentY);
                }
                else
                {
                    g.DrawString("Discount(%):", InvoiceFont, _redBrush, 50, CurrentY);
                }
                invoiceValue = String.Format("{0:0.00}", _discouunt);
                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 20;//InvoiceFontHeight;
            }
            CurrentY = CurrentY + 5;//InvoiceFontHeight;
            g.DrawString("Amount Due:", InvoiceFont, _redBrush, 50, CurrentY);

            invoiceValue = String.Format("{0:0.00}", _ntamount);
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
            CurrentY = CurrentY + 12;//InvoiceFontHeight;
            if (PrintType != 2)
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                g.DrawString("Cash Paid In:", InvoiceFont, _redBrush, 50, CurrentY);
                invoiceValue = String.Format("{0:0.00}", _cashRcd);
                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 20;//InvoiceFontHeight;
                if (RblPayMode1.Checked == true && SessionClass.ISREPRINT == 0)
                {
                    CurrentY = CurrentY + 5;//InvoiceFontHeight;
                    g.DrawString("Customer Balance:", InvoiceFont, _redBrush, 50, CurrentY);
                    if (_ntamount > 0)
                    {
                        invoiceValue = String.Format("{0:0.00}", _ntamount - _cashRcd);
                    }

                    else
                    {
                        invoiceValue = String.Format("{0:0.00}", _ntamount + _cashRcd);
                    }

                    g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                    CurrentY = CurrentY + 20;//InvoiceFontHeight;
                }
            }
            g.DrawLine(new Pen(Brushes.Black, 1 / 2), 5, CurrentY, 290, CurrentY);
            if (PaymentMode != "Cash")
            {
                CurrentY = CurrentY + 5;
                g.DrawString("Customer Account Balance:", InvoiceFont, _redBrush, 5, CurrentY);
                g.DrawString(GetCustomerCredit(), InvoiceFont, _blackBrush, 260, CurrentY, _stringFormate);
                CurrentY = CurrentY + 20;
                g.DrawLine(new Pen(Brushes.Black, 1 / 2), 5, CurrentY, 290, CurrentY);
            }
            //nOTES
            for (int i = 0; i < SessionClass.dtNotes.Rows.Count; i++)
            {
                CurrentY = CurrentY + 12;
                g.DrawString("\u2022 " + SessionClass.dtNotes.Rows[i].ItemArray[0].ToString(), InvoiceFont2, _blackBrush, 5, CurrentY);
            }
            CurrentY = CurrentY + 20;
            g.DrawString("Thanks For Shopping.", InvoiceFont, _blackBrush, 80, CurrentY);
            CurrentY = CurrentY + 20;//InvoiceFontHeight;
            g.DrawString("Powered By:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 5, CurrentY);
            _psDt = null;
            lblIsPrint.Text = "0";
        }

        #endregion
        protected void btnViewSalesReport_Click(object sender, EventArgs e)
        {
            SessionClass.HirarchyNameQuiz = CompanyName;
            SessionClass.dtFrom = txtstartDate.Value;
            SessionClass.dtTo = txtEndDate.Value;
            SessionClass.lbluserlogin = lbluserlogin.Text;
            SessionClass.lblLoacation = lblLoacation.Text;
            SessionClass.CompanyPhonNmbr = CompanyPhonNmbr;

            RptSaleController rptSaleCtl = new RptSaleController();
            if (SessionClass.RoleID == 1)
            {
                SessionClass.ds = rptSaleCtl.SelectSaleReport(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, Convert.ToDateTime(txtEndDate.Value.ToShortDateString() + " 00:00:0"), Convert.ToDateTime(txtEndDate.Value.ToShortDateString() + " 23:59:59"), 1, 3);
            }
            else
            {
                SessionClass.ds = rptSaleCtl.SelectSaleReport(SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Convert.ToDateTime(txtEndDate.Value.ToShortDateString() + " 00:00:0"), Convert.ToDateTime(txtEndDate.Value.ToShortDateString() + " 23:59:59"), 1, 3);
            }
            FormReport._reportTypeID = 1;
            FormReport objreportViewer = new FormReport();
            objreportViewer.ShowDialog();

        }
        private void showReport(int type)
        {
            try
            {
                RptSaleController rptSaleCtl = new RptSaleController();
                DataSet ds = null;
                if (type == 1)
                {
                    CORNBusinessLayer.Reports.crpSalesReportPos crpReport = new CORNBusinessLayer.Reports.crpSalesReportPos();
                    ds = rptSaleCtl.SelectSaleReport(SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, txtstartDate.Value, Convert.ToDateTime(txtEndDate.Value.ToShortDateString() + " 23:59:59"), type, Constants.IntNullValue);
                    crpReport.SetDataSource(ds);
                    crpReport.Refresh();
                    crpReport.SetParameterValue("COMPANY_NAME", CompanyName);
                    crpReport.SetParameterValue("FROM_DATE", txtstartDate.Value);
                    crpReport.SetParameterValue("TO_DATE", txtEndDate.Value);
                    crpReport.SetParameterValue("USER_NAME", lbluserlogin.Text);
                    crpReport.SetParameterValue("LOCATION", lblLoacation.Text);
                    crpReport.SetParameterValue("PHONE_NUMBER", CompanyPhonNmbr);
                }
                else // incase of malee
                {
                    //type = 2;
                    //CORNBusinessLayer.Reports.crpSalesReportPos2 crpReport2 = new CORNBusinessLayer.Reports.crpSalesReportPos2();
                    //ds = rptSaleCtl.SelectSaleReport(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), int.Parse(Session["UserId"].ToString()), DateTime.Parse(txtstartDate.Text), DateTime.Parse(txtEndDate.Text + " 23:59:59"), type);
                    //crpReport2.SetDataSource(ds);
                    //crpReport2.Refresh();
                    //crpReport2.SetParameterValue("COMPANY_NAME", CompanyName);
                    //crpReport2.SetParameterValue("FROM_DATE", DateTime.Parse(txtstartDate.Text));
                    //crpReport2.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
                    //crpReport2.SetParameterValue("USER_NAME", lbluserlogin.Text);
                    //crpReport2.SetParameterValue("LOCATION", lblLoacation.Text);
                    //crpReport2.SetParameterValue("PHONE_NUMBER", CompanyPhonNmbr);
                    //Session.Add("CrpReport", crpReport2);
                    //Session.Add("ReportType", 0);
                    //const string url = "'Default.aspx'";
                    //const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                    //Type cstype = GetType();
                    //ClientScriptManager cs = Page.ClientScript;
                    //cs.RegisterStartupScript(cstype, "OpenWindow", script);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnRePrint_Click(object sender, EventArgs e)
        {
            if (lblDuplicate.Text == "0")
            {
                penalDates.Visible = true;

                penalDates.BringToFront();
                penalDates.Location = new Point(btnViewSaleReport.Location.X, 1);
                penalDates.Width = btnViewSaleReport.Width;
                penalDates.Height = btnViewSaleReport.Height + btnRePrint.Height + 50;
                txtdatefrom.Width = penalDates.Width - 10;
                txtdateto.Width = penalDates.Width - 10;
                btnRePrint.Text = "EXIT";
                lblDuplicate.Text = "1";
                DisableControls();

                lblSKUCode.Text = "Invoice #";
                lblQuantity.Visible = false;
                txtQuantity.Visible = false;
                txtskuCode.Visible = false;
                txtInvoiceNo.Visible = true;
                txtInvoiceNo.BringToFront();
                txtInvoiceNo.Focus();
                LoadGridAllInvoices();
            }
            else if (lblDuplicate.Text == "1")
            {
                btnRePrint.Text = "REPRINT";
                lblDuplicate.Text = "0";
                GrdPrintInvoice.DataSource = null;
                GrdPrintInvoice.Rows.Clear();
                EnableControls();
                _psDt = new DataTable();
                PenalSaleReportMain.Visible = false;
                lblSKUCode.Text = "Item Code";
                lblQuantity.Visible = true;
                txtQuantity.Visible = true;
                txtInvoiceNo.Visible = false;
                txtskuCode.Visible = true;
                txtskuCode.BringToFront();
                txtskuCode.Focus();
            }
        }
        private void txtInvoiceNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    GrdPrintInvoice.DataSource = null;
                    GrdPrintInvoice.Rows.Clear();
                    LoadGridInvoices(Convert.ToInt32(txtInvoiceNo.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Invoice Number", "CORN: POS");
                }
            }
        }
        private void btnGO_Click(object sender, EventArgs e)
        {
            LoadGridInvoices(0);
            penalDates.Visible = false;
            penalDates.SendToBack();
            txtInvoiceNo.Focus();
        }
        private void DisableControls()
        {
            txtCashReceived.Enabled = false;
            numTxtTotalGST.ReadOnly = true;
            RblPayMode1.Enabled = false;
            RblPayMode2.Enabled = false;
            RblPayMode3.Enabled = false;
            txtskuCode.ReadOnly = true;
            btnCalculate.Enabled = false;
            btnPayment.Enabled = false;
            btnSaveOrder.Enabled = false;
            btnHold.Enabled = false;
            btnUnhold.Enabled = false;
            btnPriceLookup.Enabled = false;
            GrdPurchase.Visible = false;
            GrdPrintInvoice.Visible = true;
            GrdPrintInvoice.BringToFront();
        }
        private void EnableControls()
        {
            txtQuantity.Text = "1";
            btnCalculate.Enabled = true;
            btnSaveOrder.Enabled = true;
            btnRePrint.Enabled = true;
            txtCashReceived.Enabled = true;
            numTxtTotalGST.ReadOnly = false;
            RblPayMode1.Enabled = true;
            btnPayment.Enabled = true;
            RblPayMode2.Enabled = true;
            RblPayMode3.Enabled = true;
            txtskuCode.ReadOnly = false;
            btnHold.Enabled = true;
            btnUnhold.Enabled = true;
            btnPriceLookup.Enabled = true;
            GrdPrintInvoice.Visible = false;
            GrdPurchase.Visible = true;
            GrdPurchase.BringToFront();
            txtskuCode.Focus();
        }
        private void LoadGridInvoices(int InvoiceNo)
        {
            RptCustomerController rcc = new RptCustomerController();
            GrdPrintInvoice.AutoGenerateColumns = false;
            GrdPrintInvoice.Visible = true;
            GrdPrintInvoice.BringToFront();
            //DataTable pi_dt = rcc.SelectCustomerInvoicePrint(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, 0, reprintdate.Value, reprintdate.Value);
            DataTable pi_dt;

            if (InvoiceNo == 0)
            {
                pi_dt = rcc.SelectCustomerInvoicePrint(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, 0, txtdatefrom.Value, txtdateto.Value);
            }
            else
            {
                pi_dt = rcc.SelectCustomerInvoicePrint(SessionClass.DISTRIBUTOR_ID, InvoiceNo, 2, Constants.DateNullValue, Constants.DateNullValue);
            }
            string date;
            string time;
            GrdPrintInvoice.Rows.Clear();
            foreach (DataRow dr in pi_dt.Rows)
            {
                date = Convert.ToDateTime(dr["DOCUMENT_DATE"]).ToString("dd-MM-yyyy");
                time = Convert.ToDateTime(dr["TIME_STAMP"]).ToString("hh:mm tt");
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(GrdPrintInvoice);
                row.Cells[0].Value = dr["SALE_INVOICE_ID"];
                row.Cells[1].Value = dr["CUSTOMER"];
                row.Cells[2].Value = String.Format("{0:0.00}", dr["TOTAL_AMOUNT"]);
                row.Cells[3].Value = String.Format("{0:0.00}", dr["EXTRA_DISCOUNT_AMOUNT"]);
                row.Cells[4].Value = String.Format("{0:0.00}", dr["GST_AMOUNT"]);
                row.Cells[5].Value = String.Format("{0:0.00}", dr["STANDARD_DISCOUNT_AMOUNT"]);
                row.Cells[6].Value = String.Format("{0:0.00}", dr["TOTAL_NET_AMOUNT"]);
                row.Cells[7].Value = dr["TYPE"];
                //row.Cells[8].Value = date + " " + time;
                row.Cells[8].Value = time;
                row.Cells[9].Value = "Print";
                GrdPrintInvoice.Rows.Add(row);
            }
            GrdPrintInvoice.Columns["SALE_INVOICE_ID"].Width = 50;
            GrdPrintInvoice.Columns["btnPrint"].Width = 50;
            foreach (DataGridViewRow row in GrdPrintInvoice.Rows)
            {
                row.Height = 28;
            }
        }
        private void LoadGridAllInvoices()
        {
            RptCustomerController rcc = new RptCustomerController();
            GrdPrintInvoice.AutoGenerateColumns = false;
            GrdPrintInvoice.Visible = true;
            GrdPrintInvoice.BringToFront();
            DataTable pi_dt;
            pi_dt = rcc.SelectCustomerInvoicePrint(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, 0, SessionClass.CurrentWorkDate, SessionClass.CurrentWorkDate);
            string date;
            string time;
            GrdPrintInvoice.Rows.Clear();
            foreach (DataRow dr in pi_dt.Rows)
            {
                date = Convert.ToDateTime(dr["DOCUMENT_DATE"]).ToString("dd-MM-yyyy");
                time = Convert.ToDateTime(dr["TIME_STAMP"]).ToString("hh:mm tt");
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(GrdPrintInvoice);
                row.Cells[0].Value = dr["SALE_INVOICE_ID"];
                row.Cells[1].Value = dr["CUSTOMER"];
                row.Cells[2].Value = String.Format("{0:0.00}", dr["TOTAL_AMOUNT"]);
                row.Cells[3].Value = String.Format("{0:0.00}", dr["EXTRA_DISCOUNT_AMOUNT"]);
                row.Cells[4].Value = String.Format("{0:0.00}", dr["GST_AMOUNT"]);
                row.Cells[5].Value = String.Format("{0:0.00}", dr["STANDARD_DISCOUNT_AMOUNT"]);
                row.Cells[6].Value = String.Format("{0:0.00}", dr["TOTAL_NET_AMOUNT"]);
                row.Cells[7].Value = dr["TYPE"];
                //row.Cells[8].Value = date + " " + time;
                row.Cells[8].Value = time;
                row.Cells[9].Value = "Print";
                GrdPrintInvoice.Rows.Add(row);
            }
            GrdPrintInvoice.Columns["SALE_INVOICE_ID"].Width = 50;
            GrdPrintInvoice.Columns["btnPrint"].Width = 50;
            foreach (DataGridViewRow row in GrdPrintInvoice.Rows)
            {
                row.Height = 28;
            }
        }
        protected void btn_exitprint_Click(object sender, EventArgs e)
        {
            EnableControls();
            _psDt = new DataTable();
            GrdPrintInvoice.DataSource = null;
            PenalSaleReportMain.Visible = false;
        }
        public void DataFromPriceLookup(int SKUID)
        {
            SessionClass.bFromPriceLookup = true;
            DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + SKUID + "'");
            if (foundRows.Length > 0)
            {
                txtskuCode.Text = foundRows[0]["SKU_CODE"].ToString();
                txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
                txtUnitRate.Text = foundRows[0]["TRADE_PRICE"].ToString();
                btnSave_Click(null, null);
            }
            txtskuCode.Focus();
        }
        public void GetFocuss()
        {
            txtskuCode.Focus();
        }
        private void btnHold_Click(object sender, EventArgs e)
        {
            if (_purchaseSku.Rows.Count > 0)
            {
                long result;
                string ManualID = btnToggleMode.Text == "SALE MODE" ? "1" : "2";
                string CustomerID = drpCustomer.SelectedValue.ToString();
                //used 1 for sale mode
                DataControl _dc = new DataControl();
                OrderEntryController _mOrderController = new OrderEntryController();

                if (SALE_ORDER_ID == Constants.LongNullValue)
                {  // oRDER TYPE id = 1 FOR HOLD Orders From Payment POS and 2 for hold orders from Section POS
                    result = _mOrderController.Add_Order(SessionClass.DISTRIBUTOR_ID, ManualID, 0, 0, 0, long.Parse(CustomerID), 0, 0, 0, 1, decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text)), decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text)),
                                0, decimal.Parse(_dc.chkNull_0(numTxtTotalGST.Text)), decimal.Parse(_dc.chkNull_0(numTxtTotlAmnt.Text)),
                                0, Constants.Order_Pending_Id, _purchaseSku, _dtFreeSku, SessionClass.UserID, SessionClass.CurrentWorkDate, 0, 0);
                    if (result != 0)
                    {
                        ClearMasterAll();
                    }
                }
                else
                {
                    result = _mOrderController.Update_Order(SALE_ORDER_ID, SessionClass.DISTRIBUTOR_ID, SessionClass.CurrentWorkDate, long.Parse(CustomerID), 1,
                                                 decimal.Parse(_dc.chkNull_0(txtGrossAmount.Text)), decimal.Parse(_dc.chkNull_0(numtxtTotalExtraDiscnt.Text)), 0, decimal.Parse(_dc.chkNull_0(numTxtTotalGST.Text)), decimal.Parse(_dc.chkNull_0(numTxtTotlAmnt.Text)), 0, _purchaseSku, _dtFreeSku, SessionClass.UserID);
                    if (result == 0) return;
                }

                if (result != 0)
                {
                    ddonHoldList.Enabled = false;
                    ClearMasterAll();
                    SALE_ORDER_ID = Constants.LongNullValue;
                }
            }
            else
            {
                MessageBox.Show("Nothing To Hold", "CORN : POS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            LoadOnHoldInvoicNumber();
            LoadPendingOrder();
            txtskuCode.Focus();
        }
        private void btnUnhold_Click(object sender, EventArgs e)
        {
            if (lblonHold.Text == "0")
            {
                MessageBox.Show("Nothing To UnHold", "CORN : POS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                ddonHoldList.Enabled = true;
                LoadPendingOrder();
                chkSectionSale.Checked = false;
            }
        }
        private void GrdPrintInvoice_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _saleInvId = Convert.ToInt32(GrdPrintInvoice.Rows[e.RowIndex].Cells[0].Value);
            RptCustomerController rcc = new RptCustomerController();
            _psDt = rcc.SelectCustomerInvoiceDetail(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, 1, _saleInvId, reprintdate.Value, reprintdate.Value);

            if (_saleInvId == -2 && _saleInvId == -1) return;
            if (System.Configuration.ConfigurationSettings.AppSettings["IsPrint"] == "1")
            {
                lblIsPrint.Text = "1";
                SessionClass.ISREPRINT = 1;
                PrintReport(3);
            }
        }
        private void btnDayClose_Click(object sender, EventArgs e)
        {
            frmDayClose objfrmDayClose = new frmDayClose();
            objfrmDayClose.ShowDialog();
        }
        private void cbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDiscount.Checked)
            {
                if (GrdPurchase.Rows.Count > 0)
                {
                    if (!SessionClass.IsDiscountAllowed)
                    {
                        frmAllowDiscount objfrmAllowDiscount = new frmAllowDiscount(this);
                        objfrmAllowDiscount.ShowDialog();
                        numtxtTotalExtraDiscnt.Focus();
                    }
                }
                else
                {
                    txtskuCode.Focus();
                    // MessageBox.Show("No Product FoundABC!", "CORN : POS");
                }
            }
        }
        public void AllowDiscount(string strAuthorized)
        {
            numtxtTotalExtraDiscnt.ReadOnly = false;
            txtAuthorisedBy.ReadOnly = false;
            txtAuthorisedBy.Text = strAuthorized;
            numtxtTotalExtraDiscnt.Focus();
        }
        private void ddonHoldList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (long.Parse(((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey) != Constants.LongNullValue)
                {
                    DataRow[] foundRows = dtOrder.Select("SALE_ORDER_ID  = '" + ((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey + "'");
                    if (foundRows.Length > 0)
                    {
                        SALE_ORDER_ID = Convert.ToInt64(((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey);
                        if (foundRows[0]["MANUAL_ORDER_ID"].ToString() == "1")
                        {
                            btnToggleMode.Text = "SALE MODE";
                        }
                        else
                        {
                            btnToggleMode.Text = "REFUND\r\nMODE";
                        }
                        txtGrossAmount.Text = (Math.Round(decimal.Parse(foundRows[0]["TOTAL_AMOUNT"].ToString()), 2)).ToString();
                        decimal extraDiscount = decimal.Parse(foundRows[0]["EXTRA_DISCOUNT_AMOUNT"].ToString());
                        numtxtTotalExtraDiscnt.Text = (Math.Round(extraDiscount, 2)).ToString();
                        numTxtTotalGST.Text = (Math.Round(decimal.Parse(foundRows[0]["GST_AMOUNT"].ToString()), 2)).ToString();
                        numTxtTotlAmnt.Text = (Math.Round(decimal.Parse(foundRows[0]["TOTAL_NET_AMOUNT"].ToString()), 2)).ToString();
                        numtxtTotalExtraDiscnt.Text = (Math.Round(decimal.Parse(foundRows[0]["EXTRA_DISCOUNT_AMOUNT"].ToString()), 2)).ToString();
                        SessionClass.CustomerID = long.Parse(foundRows[0]["CUSTOMER_ID"].ToString());
                        drpCustomer.SelectedValue = Convert.ToInt64(foundRows[0]["CUSTOMER_ID"].ToString());
                        ExistenOrderDetail(long.Parse(((CORNCommon.Classes.clsListItems)(ddonHoldList.SelectedItem)).ItemKey.ToString()));
                        EnableDisableController(false);
                        btnSaveOrder.Enabled = true;
                        ClearAll();

                        if (foundRows[0]["ORDER_TYPE_ID"].ToString() == "214")
                        {
                            RblPayMode1.Checked = true;
                        }
                        else if (foundRows[0]["ORDER_TYPE_ID"].ToString() == "217")
                        {
                            RblPayMode2.Checked = true;
                        }
                        else if (foundRows[0]["ORDER_TYPE_ID"].ToString() == "215")
                        {
                            RblPayMode3.Checked = true;
                        }

                        //RblPayMode.SelectedValue = foundRows[0]["ORDER_TYPE_ID"].ToString();
                        Calculate();
                        ddonHoldList.Enabled = false;
                    }
                }
                else
                {
                    CreateFreeSku();
                    CreatTable();
                    LoadGird();
                    LoadFreeGrid();
                    ClearMasterAll();
                }
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        private void ExistenOrderDetail(long orderId)
        {
            try
            {
                _purchaseSku = _mOrderController.SelectOrderDetail(SessionClass.DISTRIBUTOR_ID, orderId);
                _dtFreeSku = _mOrderController.SelectOrderPromotion(SessionClass.DISTRIBUTOR_ID, orderId);
                LoadGird();
                LoadFreeGrid();
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        public decimal MergeItemsOfSameID(int skuID, decimal Quantity)    // While comming from Section Sale
        {
            decimal QuantityUnit = Quantity;
            DataRow[] dr = _purchaseSku.Select("SKU_ID = '" + skuID + "'");
            if (dr.Length > 0)
            {
                QuantityUnit = Convert.ToDecimal(dr[0]["QUANTITY_UNIT"]) + Quantity;
            }
            return QuantityUnit;
        }
        private void ExistenOrderDetail1(long orderId)
        {
            try
            {
                DataTable dt1 = _mOrderController.SelectOrderDetail(SessionClass.DISTRIBUTOR_ID, orderId);
                if (dt1.Rows.Count > 0)
                {
                    if (_purchaseSku.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            decimal qty = MergeItemsOfSameID(Convert.ToInt32(dr["SKU_ID"].ToString()), Convert.ToDecimal(dr["QUANTITY_UNIT"].ToString()));
                            if (qty == Convert.ToDecimal(dr["QUANTITY_UNIT"].ToString()))
                            {
                                _purchaseSku.ImportRow(dr);
                            }
                            else
                            {
                                foreach (DataRow dr2 in _purchaseSku.Rows)
                                {
                                    if (Convert.ToInt32(dr2["SKU_ID"].ToString()) == Convert.ToInt32(Convert.ToInt32(dr["SKU_ID"].ToString())))
                                    {
                                        dr2.Delete();
                                        break;
                                    }
                                }
                                dr["QUANTITY_UNIT"] = qty;
                                dr["AMOUNT"] = qty * Convert.ToDecimal(dr["UNIT_PRICE"]);
                                _purchaseSku.ImportRow(dr);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            _purchaseSku.ImportRow(dr);
                        }
                    }
                }
                DataTable dt2 = _mOrderController.SelectOrderPromotion(SessionClass.DISTRIBUTOR_ID, orderId);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt2.Rows)
                    {
                        _dtFreeSku.ImportRow(dr);
                    }
                }
                LoadGird();
                LoadFreeGrid();
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
        private void btnNewCustomer_Click_1(object sender, EventArgs e)
        {
            if (_frmCustomerEnable == false)
            {
                return;
            }
            frmCustomer _formCustomer = new frmCustomer();
            _formCustomer.StartPosition = FormStartPosition.CenterScreen;
            _formCustomer.ShowDialog();
        }
        private void btnPriceLookup_Click(object sender, EventArgs e)
        {
            frmPriceLookup objPriceLookup = new frmPriceLookup();
            objPriceLookup.ShowDialog();
        }
        public string GetCustomerCredit()
        {
            try
            {
                CustomerDataController dController = new CustomerDataController();
                decimal _CustomerCredit = dController.SelectCreditAmount(SessionClass.DISTRIBUTOR_ID, Convert.ToInt32(drpCustomer.SelectedValue.ToString()), SessionClass.CurrentWorkDate);
                return _CustomerCredit.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }
        #region Button Payment (Click Function)
        private void btnPayment_Click(object sender, EventArgs e)
        {
            //expandablePanel1.AnimationTime = 100;
            ////expandablePanel1.Dock = DockStyle.Fill;
            //expandablePanel1.Visible = true;
            //expandablePanel1.Expanded = true;
            //return;
            try
            {
                if (Convert.ToInt32(drpCustomer.SelectedValue.ToString()) <= 0)
                {
                    MessageBox.Show(this, "Please Select Customer", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    drpCustomer.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please Select Customer", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                drpCustomer.Focus();
                return;
            }
            lblCustomerCredit.Text = GetCustomerCredit();
            lblCustomerName.Text = drpCustomer.Text;
            RblPayMode1.Checked = true;
            //PenalPayment.BackColor = Color.FromArgb(194, 77, 90);
            PenalPayment.Location = new Point(250, 100);
            PenalPayment.Dock = DockStyle.Top;
            PenalPayment.Width = 1347;
            PenalPayment.Height = 1347;
            PenalHeader.Dock = DockStyle.None;
            PenalPayment.BringToFront();
            GetTotalQuantity();
            if (RblPayMode1.Checked)
            {
                btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
                btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            }
            else if (RblPayMode2.Checked)
            {
                btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
                btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            }
            else if (RblPayMode3.Checked)
            {
                btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
                btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
            }
            else if (RblPayMode4.Checked)
            {
                btnPayMode3.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode2.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode1.Style.BackColor1.Color = Color.FromArgb(255, 194, 77, 90);
                btnPayMode4.Style.BackColor1.Color = Color.FromArgb(255, 128, 64, 64);
            }
            PenalPayment.Visible = true;
            txtCashReceived.Focus();

        }
        #endregion
        #region Get Total Quantity
        public void GetTotalQuantity()
        {
            decimal _quantity = 0;
            int _rows = GrdPurchase.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                _quantity = _quantity + Convert.ToDecimal(GrdPurchase.Rows[i].Cells["QUANTITY_UNIT"].Value);
            }
            lblTotalQuantity.Text = _quantity.ToString();
            txtskuCode.Focus();
        }
        #endregion
        #region Common Functions

        private void btnVoid1_Click(object sender, EventArgs e)
        {
            PenalPayment.Visible = false;
            txtCashReceived.Text = "";
            PenalHeader.Dock = DockStyle.Top;
            txtskuCode.Focus();
        }

        private void frmPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _psDt = new DataTable();
            SessionClass.LoginStatus = Constants.IntNullValue;
        }

        private void btnViewSaleReport_Click(object sender, EventArgs e)
        {
            int resolutionWidth = Screen.PrimaryScreen.WorkingArea.Width;
            PenalSaleReport.Location = new Point(((resolutionWidth / 2) - 217), PenalSaleReport.Location.Y);
            PenalSaleReportMain.Visible = true;
            PenalSaleReportMain.Location = new Point(250, 100);
            PenalSaleReportMain.Dock = DockStyle.Top;
            PenalSaleReportMain.Width = 1347;
            PenalSaleReportMain.Height = 1347;
            PenalHeader.Dock = DockStyle.None;
            PenalSaleReportMain.BringToFront();
        }

        private void txtCashReceived_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void txt_chkprint_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtCashReceived.TextLength <= 0)
            {
                txtBalance.Text = lblPayableAmount.Text;
            }
            else
            {
                decimal _balance = DataControl.chkDecimalZero(txtCashReceived.Text) - Convert.ToDecimal(lblPayableAmount.Text);// Convert.ToDecimal(txtCashReceived.Text);
                txtBalance.Text = _balance.ToString();
            }
        }
        #endregion

        private void txtCashReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveOrder_Click(null, null);
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            FormSalesSummary _formSalesSummary = new FormSalesSummary();
            _formSalesSummary.ShowDialog();
        }

        #region Paint Events to Change Border Colors of Controles
        private void PenalLogHistory_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalLogHistory.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnViewSaleReport_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnViewSaleReport.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        private void btnReprint_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnRePrint.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        private void PenalUpSaleItems_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalUpSaleItems.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void PenalMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalMain.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnNewCustomer_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnNewCustomer.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnHold_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnHold.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnUnhold_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnUnhold.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnPriceLookup_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnPriceLookup.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnDayClose_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnDayClose.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnToggleMode_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnToggleMode.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void PenalCustomer_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.PenalCustomer.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        private void btnExit_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnExit.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        private void PenalUnHold_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalUnHold.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void PenalHeader_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalHeader.ClientRectangle, Color.FromArgb(255, 194, 77, 90), ButtonBorderStyle.Solid);

        }

        private void PenalRight_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.PenalRight.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel3.ClientRectangle, Color.FromArgb(255, 0, 195, 198), ButtonBorderStyle.Solid);
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel4.ClientRectangle, Color.FromArgb(255, 0, 195, 198), ButtonBorderStyle.Solid);
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel6.ClientRectangle, Color.FromArgb(255, 0, 195, 198), ButtonBorderStyle.Solid);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.FromArgb(255, 0, 195, 198), ButtonBorderStyle.Solid);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle, Color.FromArgb(255, 0, 195, 198), ButtonBorderStyle.Solid);
        }

        private void btnPayMode2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnPayMode2.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnPayMode4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnPayMode4.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnPayMode3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnPayMode3.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }

        private void btnPayMode1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.btnPayMode1.ClientRectangle, Color.FromArgb(255, 254, 135, 135), ButtonBorderStyle.Solid);
        }
        #endregion

        private void frmPOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainFrom _frmMain = Application.OpenForms["MainFrom"] as MainFrom;
            try
            {
                _frmMain.ribbonControl1.Expanded = true;
            }
            catch (Exception)
            {
            }
            //MainFrom _formEmployee = Application.OpenForms["MainFrom"] as MainFrom;
            //_frmMain.LoadDashBoard();
        }

        private void numtxtTotalExtraDiscnt_EnabledChanged(object sender, EventArgs e)
        {
            numTxtTotlAmnt.BackColor = Color.FromArgb(255, 57, 76, 88);
            numTxtTotlAmnt.Border.BorderColor = Color.FromArgb(255, 97, 129, 149);
            numTxtTotlAmnt.Border.BorderColor2 = Color.FromArgb(255, 97, 129, 149);
            numTxtTotlAmnt.ForeColor = Color.FromArgb(255, 165, 220, 255);
        }

        private void numTxtTotlAmnt_MouseDown(object sender, MouseEventArgs e)
        {
            lblLoacation.Focus();
        }

        private void btnPayment_Paint(object sender, PaintEventArgs e)
        {
            if (_paint == true)
            {
                ControlPaint.DrawBorder(e.Graphics, this.btnPayment.ClientRectangle, Color.FromArgb(255, 00, 00, 00), ButtonBorderStyle.Dashed);
                _paint = false;
            }
        }

        private void btnPayment_Leave(object sender, EventArgs e)
        {
            btnPayment.Invalidate();
            btnPayment.Refresh();
        }

        private void txtAuthorisedBy_MouseDown(object sender, MouseEventArgs e)
        {
            lblLoacation.Focus();
        }

        private void numtxtTotalExtraDiscnt_MouseDown(object sender, MouseEventArgs e)
        {
            if (numtxtTotalExtraDiscnt.ReadOnly)
            {
                lblLoacation.Focus();
            }
        }

        private void numtxtTotalExtraDiscnt_MouseEnter(object sender, EventArgs e)
        {
            if (numtxtTotalExtraDiscnt.ReadOnly == false)
            {
                Cursor = Cursors.IBeam;
            }
        }

        private void numtxtTotalExtraDiscnt_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void numTxtTotalGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void btnPayment_TabIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void frmPOS_Activated(object sender, EventArgs e)
        {
            txtskuCode.Focus();
        }

        private void txtQuantity_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtskuCode.Focus();
            try
            {
                DataRow[] dr = _customers.Select("CUSTOMER_ID = '" + drpCustomer.SelectedValue + "'");
                if (dr.Length > 0)
                {
                    lblCustCell.Text = dr[0]["CONTACT_NUMBER"].ToString();
                    string address = dr[0]["ADDRESS"].ToString();
                    int lenght = address.Length;
                    if (lenght >= 45)
                    {
                        lblCustAddress.Text = address.Substring(0, 45);
                    }
                    else
                    {
                        lblCustAddress.Text = address;
                    }
                }
                else
                {
                    lblCustAddress.Text = "";
                    lblCustCell.Text = "";
                }
            }
            catch (Exception)
            {
                lblCustAddress.Text = "";
                lblCustCell.Text = "";
            }
            txtskuCode.Focus();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnGoToDiscount_Click(object sender, EventArgs e)
        {
            if (GrdPurchase.Rows.Count > 0)
            {
                if (SessionClass.IsDiscountAllowed)
                {
                    numtxtTotalExtraDiscnt.Focus();
                }
                else
                {
                    cbDiscount.Checked = true;
                }
            }
            else
            {
                txtskuCode.Focus();
            }
        }

        private void rbtnvalue_CheckedChanged(object sender, EventArgs e)
        {
            CalculateNetAndBalance();
            txtskuCode.Focus();
        }

        private void chkSectionSale_CheckedChanged(object sender, EventArgs e)
        {
            txtSectionSlipNo.Text = "";
            if (chkSectionSale.Checked)
            {
                try
                {
                    //_dtSectionOrderID.Rows.Clear();
                }
                catch (Exception)
                {
                }
                try
                {
                    lblUnhold.Text = "Loading...";
                    _dtSectionSaleHold = or.SelectPendingOrder(SessionClass.DISTRIBUTOR_ID, 0, 0, 0, 0, Constants.Order_Pending_Id, 2, SessionClass.UserID, SessionClass.CurrentWorkDate);
                }
                catch (Exception ecd)
                {
                    MessageBox.Show("Error Occured:\nSection Sale Orders Cant't Loaded", "CORN: POS");
                    ExceptionPublisher.PublishException(ecd);
                }
                lblUnhold.Text = "SECTION SALE";
                ddonHoldList.Visible = false;
                txtSectionSlipNo.Visible = true;
                txtSectionSlipNo.BringToFront();
                txtSectionSlipNo.Focus();
            }
            else
            {
                lblUnhold.Text = "UNHOLD";
                ddonHoldList.Visible = true;
                ddonHoldList.BringToFront();
                txtSectionSlipNo.Visible = false;
            }
        }

        private void txtSectionSlipNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtSectionSlipNo.Text != "")
                    {
                        DataRow[] dr = _dtSectionOrderID.Select("OrderId = '" + Convert.ToInt32(txtSectionSlipNo.Text) + "' ");
                        if (dr.Length > 0)
                        {
                            MessageBox.Show("This Slip is Already Selected", "CORN: POS");
                            return;
                        }
                        DataRow[] foundRows = _dtSectionSaleHold.Select("SALE_ORDER_ID  = '" + Convert.ToInt32(txtSectionSlipNo.Text) + "'");
                        if (foundRows.Length > 0)
                        {
                            SALE_ORDER_ID = Convert.ToInt32(txtSectionSlipNo.Text);
                            txtGrossAmount.Text = (Math.Round(decimal.Parse(foundRows[0]["TOTAL_AMOUNT"].ToString()), 2)).ToString();
                            decimal extraDiscount = decimal.Parse(foundRows[0]["EXTRA_DISCOUNT_AMOUNT"].ToString());
                            numtxtTotalExtraDiscnt.Text = (Math.Round(extraDiscount, 2)).ToString();
                            numTxtTotalGST.Text = (Math.Round(decimal.Parse(foundRows[0]["GST_AMOUNT"].ToString()), 2)).ToString();
                            numTxtTotlAmnt.Text = (Math.Round(decimal.Parse(foundRows[0]["TOTAL_NET_AMOUNT"].ToString()), 2)).ToString();
                            numtxtTotalExtraDiscnt.Text = (Math.Round(decimal.Parse(foundRows[0]["EXTRA_DISCOUNT_AMOUNT"].ToString()), 2)).ToString();
                            ExistenOrderDetail1(Convert.ToInt64(txtSectionSlipNo.Text));
                            EnableDisableController(false);
                            btnSaveOrder.Enabled = true;
                            ClearAll();
                            Calculate();
                            ddonHoldList.Enabled = false;
                            _dtSectionOrderID.Rows.Add(Convert.ToInt32(txtSectionSlipNo.Text));
                            txtSectionSlipNo.Text = "";
                            txtSectionSlipNo.Focus();
                            drpCustomer.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Slip Not Found.", ""); ;
                        }
                    }
                    else
                    {
                        txtskuCode.Focus();
                    }
                }
                catch (Exception eee)
                {
                    eee.Message.ToString();
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmCustomer _formCustomer = new frmCustomer();
            _formCustomer.StartPosition = FormStartPosition.CenterScreen;
            _formCustomer.ShowDialog();
            txtskuCode.Focus();
        }

        private void GrdPurchase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GrdPurchase.Rows.Count > 0)
                if (e.ColumnIndex == 5 || (e.ColumnIndex == 6 && SessionClass.SalePriceEdit == "True"))
                {
                    DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + GrdPurchase.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "'");
                    if (foundRows.Length > 0)
                    {
                        decimal mTradePrice = decimal.Parse(_dc.chkNull_0(foundRows[0]["TRADE_PRICE"].ToString()));

                        if (e.ColumnIndex == 6 && SessionClass.SalePriceEdit == "True")
                        {
                            mTradePrice = decimal.Parse(_dc.chkNull_0(GrdPurchase.Rows[e.RowIndex].Cells[6].Value.ToString()));
                        }

                        decimal mWholesalePrice = decimal.Parse(_dc.chkNull_0(foundRows[0]["WHOLESALE_PRICE"].ToString()));
                        decimal mWSQuantity = decimal.Parse(_dc.chkNull_0(foundRows[0]["WS_QUANTITY"].ToString()));
                        decimal Quantity = decimal.Parse(_dc.chkNull_0(GrdPurchase.Rows[e.RowIndex].Cells[5].Value.ToString()));
                        decimal currentStock = 0;
                        if (btnToggleMode.Text == "SALE MODE")
                        {
                            DataRow[] foundRowsexist = _purchaseSku.Select("SKU_CODE  = '" + GrdPurchase.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "'");
                            mTradePrice = RetailPrice(mTradePrice, mWholesalePrice, mWSQuantity, Quantity);
                            if (foundRowsexist.Length > 0)
                            {
                                currentStock = CheckStockStatus(int.Parse(_dc.chkNull_0(foundRowsexist[0]["SKU_ID"].ToString())), Quantity);
                                if (currentStock == -1)
                                {
                                    foundRowsexist[0]["QUANTITY_UNIT"] = Quantity;
                                    foundRowsexist[0]["AMOUNT"] = mTradePrice * Convert.ToDecimal(foundRowsexist[0]["QUANTITY_UNIT"]);
                                    foundRowsexist[0]["UNIT_PRICE"] = Convert.ToDecimal(mTradePrice);
                                }
                                else
                                {
                                    MessageBox.Show(txtskuName.Text + " Current closing Stock is " + currentStock);
                                    return;
                                }
                            }                            
                        }
                        else
                        {
                            DataRow[] foundRowsexist = _purchaseSku.Select("SKU_CODE  = '" + GrdPurchase.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "'");
                            if (foundRowsexist.Length > 0)
                            {
                                if (Quantity < 0)
                                {
                                    foundRowsexist[0]["QUANTITY_UNIT"] = Quantity;
                                    foundRowsexist[0]["AMOUNT"] = (mTradePrice * Quantity);
                                }
                            }
                        }
                        EnableDisableController(false);
                        ClearAll12();
                        btnSaveOrder.Enabled = true;
                        Calculate();
                        LoadGird();
                        txtskuCode.Focus();
                    }
                }
        }
    }
}