using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNBusinessLayer.Classes;
using System.IO;
using CORNCommon.Classes;
using System.Reflection;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace CORNPointOfSale
{
    public partial class MainFrom : Office2007RibbonForm
    {
        public static DataTable dtPrivileges { get; set; }
        public MainFrom()
        {
            InitializeComponent();
        }

        #region Button Click Events
        private void newLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormNewLocation2 _fromNewLocation2 = new FormNewLocation2();
            Show(_fromNewLocation2);
        }

        private void menuEmployeeInformation_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormEmployeeInformation _formEmpInfo = new FormEmployeeInformation();
            Show(_formEmpInfo);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormChangePassword _formChangePassword = new FormChangePassword();
            Show(_formChangePassword);
        }

        private void userLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormUserLogin _formUserLogin = new FormUserLogin();
            Show(_formUserLogin);
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormDepartment_Designation _formDep_Desi = new FormDepartment_Designation();
            Show(_formDep_Desi);
        }

        private void roleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormRoleManagement _formRoleManagement = new FormRoleManagement();
            Show(_formRoleManagement);
        }

        private void userAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormUserAssignment _formUserAssignment = new FormUserAssignment();
            Show(_formUserAssignment);
        }

        private void chartOfAccountToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormChartOfAccount _formChartofAccount = new FormChartOfAccount();
            Show(_formChartofAccount);
        }

        private void voucherEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormVoucherEntery _foromVoucherEntry = new FormVoucherEntery();
            Show(_foromVoucherEntry);
        }

        private void branchExpenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormBranchExpense _formBranchExpense = new FormBranchExpense();
            Show(_formBranchExpense);
        }

        private void pointOfSaleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ribbonControl1.Expanded = false;
            ClosePreviousForms();
            frmPOS _formPOS = new frmPOS();
            Show(_formPOS);
            _formPOS.WindowState = FormWindowState.Minimized;
            _formPOS.WindowState = FormWindowState.Maximized;
        }

        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            { }
        }

        private void itemsSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Supplier _formSupplier = new FormSKU_Supplier();
            Show(_formSupplier);
        }

        private void itemHierarchyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Hierarchy _formskuHierarchy = new FormSKU_Hierarchy();
            Show(_formskuHierarchy);
        }

        private void itemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Information _formSKSUinfo = new FormSKU_Information();
            Show(_formSKSUinfo);
        }

        private void itemPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Price _formPrice = new FormSKU_Price();
            Show(_formPrice);
        }

        private void itemGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Group _formGroup = new FormSKU_Group();
            Show(_formGroup);
        }
        private void stockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockRegisterr _fromStockRegister = new FormStockRegisterr();
            Show(_fromStockRegister);
        }

        private void stockAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockAdjustment _formstockAdjustment = new FormStockAdjustment();
            Show(_formstockAdjustment);
        }
        private void physicalStockTakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormPhysicalStockTaking _formPhysicalStock = new FormPhysicalStockTaking();
            Show(_formPhysicalStock);
        }
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormItemsLookUp _formItemLookUp = new FormItemsLookUp();
            Show(_formItemLookUp);
        }
        private void salePromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormPromotion _fromPromotion = new FormPromotion();
            Show(_fromPromotion);
        }
        #endregion

        #region Common Functions
        private void MainFrom_Load(object sender, EventArgs e)
        {
            // #1
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.White;
                    // 4#
                    break;
                }
            }
            SetUserLoginDetail();
            if (!SessionClass.IsExpired) // i.e. renewal date is not expired - so open in normal mode
            {
                SetUserPrivileges();
                LoadPosScreenDirectly();
                if (string.IsNullOrEmpty(SessionClass.CompanyName))
                {
                    //NewLocationProperties._newOrEdit = "New";
                    PopUpNewCompany _frmPopUpNewCompany = new PopUpNewCompany(this);
                    _frmPopUpNewCompany.ShowDialog();
                }
            }
            else // i.e. renewal date is EXPIRED - so open ONLY ACTIVATION SCREEN - AND SELECT SUPPORT TAB
            {
                _461.Enabled = true;
                ribbonTabItem1_Click(null, null);
                ribbonTabItem5.Checked = true;
                _461_Click(null, null);
            }
        }
        public void LoadPosScreenDirectly()
        {
            if (SessionClass.Is_POS_USER)
            {
               pointOfSaleToolStripMenuItem2_Click(null, null);
            }
        }

        public void SetUserLoginDetail()
        {
            lblUserName.Text = "User Name: ";
            lblName.Text = SessionClass.UserName;
            lblCurrentDate.Text = "          Current Working Date: ";
            lblDate.Text = SessionClass.CurrentWorkDate.ToString("dd-MMM-yyyy");
            lblLoginAt.Text = "          Login at: ";
            lblLoginInfo.Text = DateTime.Now.ToString("dd-MM-yyy      hh:mm tt");

            toolStripStatusLabel1.Text = "Version: " + SessionClass.Version + " " + SessionClass.PoweredBy;
            this.Text = "CORN POS - " + SessionClass.Edition;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReport _rpt = new FormReport();
            _rpt.Show();
        }
        public void ClosePreviousForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }
        public void Show(Form _form)
        {
            _form.MdiParent = this;
            _form.StartPosition = FormStartPosition.CenterParent;
            _form.BringToFront();
            //_form.Text = "Personal Edition";
            _form.Show();
            _form.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region Show Report Viewer
        public void ShowReportViewer(int ReportType)
        {
            FormReport._reportTypeID = ReportType;
            FormReport _formRpt = new FormReport();
            _formRpt.ShowDialog();
        }
        #endregion

        #region Buttons Click Events For Report

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportViewer(2);
        }

        private void nCSVsBankDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            //FormReportNCSvsBankDeposit _formNCSvsBankDeposit = new FormReportNCSvsBankDeposit();
            FormReportDailySale _formNCSvsBankDeposit = new FormReportDailySale();
            Show(_formNCSvsBankDeposit);
        }
        private void salesCloosingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportSalesAndClosingStock _formSalesAndClosingStock = new FormReportSalesAndClosingStock();
            Show(_formSalesAndClosingStock);
        }

        private void itemWiseBranchSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportItemWiseBranchSale _formReportItemWiseBranchSale = new FormReportItemWiseBranchSale();
            Show(_formReportItemWiseBranchSale);
        }

        private void dataUpdateStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportDataUpdateStatus _formReportDataUpdateStatus = new FormReportDataUpdateStatus();
            Show(_formReportDataUpdateStatus);
        }

        private void itemPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportItemPriceList _formReprotItemPriceList = new FormReportItemPriceList();
            Show(_formReprotItemPriceList);
        }

        private void monthlySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportMonthlySalesReport _formReportMonthlySalesReport = new FormReportMonthlySalesReport();
            Show(_formReportMonthlySalesReport);
        }

        private void itemPriceStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportItemPriceStructure _formReportItemPriceStructure = new FormReportItemPriceStructure();
            Show(_formReportItemPriceStructure);
        }

        private void dateWiseDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportDateWiseDiscount _formReportDateWiseDiscount = new FormReportDateWiseDiscount();
            Show(_formReportDateWiseDiscount);
        }

        private void userLoginHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportUserLoginHistory _formReportUserLoginHistory = new FormReportUserLoginHistory();
            Show(_formReportUserLoginHistory);
        }

        private void itemPriceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportItemPriceHistory _formReportItemPriceHistory = new FormReportItemPriceHistory();
            Show(_formReportItemPriceHistory);
        }

        private void stockReconciliationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportStockReconciliation _formReportStockReconciliation = new FormReportStockReconciliation();
            Show(_formReportStockReconciliation);
        }

        private void dateWiseStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportDateWiseStockReport _formReportDateWiseStockReport = new FormReportDateWiseStockReport();
            Show(_formReportDateWiseStockReport);
        }

        private void transferInOutReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportTransferInOut _formReportTransferInOut = new FormReportTransferInOut();
            Show(_formReportTransferInOut);
        }

        private void physicalStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportPhysicalStockReport _formReportPhysicalStockReport = new FormReportPhysicalStockReport();
            Show(_formReportPhysicalStockReport);
        }

        private void purchaseDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportPurchaseDocument _formReportPurchaseDocument = new FormReportPurchaseDocument();
            Show(_formReportPurchaseDocument);
        }

        private void stockValuationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportStockValuationReport _formReportStockValuationReport = new FormReportStockValuationReport();
            Show(_formReportStockValuationReport);
        }

        private void voucherViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportVoucherView _formReportVoucherView = new FormReportVoucherView();
            Show(_formReportVoucherView);
        }

        private void pettyExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportPettyExpense _formReportPettyExpense = new FormReportPettyExpense();
            Show(_formReportPettyExpense);
        }

        private void depositSlipDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportIncoemStatementReport _formReportIncomeStatement = new FormReportIncoemStatementReport();
            Show(_formReportIncomeStatement);
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportGeneralLedger _formReportGeneralLedger = new FormReportGeneralLedger();
            Show(_formReportGeneralLedger);
        }

        private void pettyExpenseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportPettyExpenseSummary _formReportPettyExpenseSummary = new FormReportPettyExpenseSummary();
            Show(_formReportPettyExpenseSummary);
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportTrialBalance _formReportTrialBalance = new FormReportTrialBalance();
            Show(_formReportTrialBalance);
        }

        private void chartOfAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportChartOfAccount _formReportChartOfAccount = new FormReportChartOfAccount();
            Show(_formReportChartOfAccount);
        }

        private void gLLogDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportGLlogDetail _formReportGLlogDetail = new FormReportGLlogDetail();
            Show(_formReportGLlogDetail);
        }

        private void customerMonthlyReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportCustomerMonthlyReport _formReportCustomerMonthlyReport = new FormReportCustomerMonthlyReport();
            Show(_formReportCustomerMonthlyReport);
        }

        private void customerInvoiceWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportCustomerInvoiceWiseSale _formReportCustomerInvoiceWiseSale = new FormReportCustomerInvoiceWiseSale();
            Show(_formReportCustomerInvoiceWiseSale);
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportCustomerLedger _formFormReportCustomerLedger = new FormReportCustomerLedger();
            Show(_formFormReportCustomerLedger);
        }
        private void Payments_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormChequeEntry _formFormChequeEntry = new FormChequeEntry();
            Show(_formFormChequeEntry);
        }

        private void customerSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportCustomerSaleReport _formReportCustomerSaleReport = new FormReportCustomerSaleReport();
            Show(_formReportCustomerSaleReport);
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormImportData _formImportData = new FormImportData();
            Show(_formImportData);
        }
        #endregion

        private void ToolEmployeeInfo_Click(object sender, EventArgs e)
        {
            menuEmployeeInformation_Click(null, null);
        }

        private void ToolSupplier_Click(object sender, EventArgs e)
        {
            itemsSupplierToolStripMenuItem_Click(null, null);
        }

        private void ToolItemBarcode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pending");
        }

        private void ToolItemLookup_Click(object sender, EventArgs e)
        {
            itemToolStripMenuItem_Click(null, null);
        }

        private void ToolPurchase_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormPurchase _fromPurchase = new FormPurchase();
            Show(_fromPurchase);
        }

        private void ToolReturn_Click(object sender, EventArgs e)
        {
            stockRegisterToolStripMenuItem_Click(null, null);
        }

        private void ToolPointOfSale_Click(object sender, EventArgs e)
        {
            pointOfSaleToolStripMenuItem2_Click(null, null);
        }

        private void ToolPettyExpense_Click(object sender, EventArgs e)
        {
            branchExpenseToolStripMenuItem1_Click(null, null);
        }

        private void VendorPayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pending");
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormPurchase _formPurchase = new FormPurchase();
            Show(_formPurchase);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnSlipNotes_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSlipNotes _formSlipNotes = new FormSlipNotes();
            Show(_formSlipNotes);
        }

        private void supplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSupplierPayment _formSupplierPayment = new FormSupplierPayment();
            Show(_formSupplierPayment);
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportSupplierLedger _formReportSupplierLedger = new FormReportSupplierLedger();
            Show(_formReportSupplierLedger);
        }

        private void btnNewTil_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormTil _formTil = new FormTil();
            Show(_formTil);
        }

        private void newShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormShift _formShift = new FormShift();
            Show(_formShift);
        }

        private void itemBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSKU_Barcode _formSKU_Barcode = new FormSKU_Barcode();
            Show(_formSKU_Barcode);
        }

        private void shiftCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormShiftClose _formShiftClose = new FormShiftClose();
            Show(_formShiftClose);
        }

        private void buttonItem46_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem63_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            formCustomer _formShiftClose = new formCustomer();
            Show(_formShiftClose);
        }

        private void btnLogouts_Click(object sender, EventArgs e)
        {
            UserController UserCtl = new UserController();
            UserCtl.InsertUserLogoutTime(Convert.ToInt32(SessionClass.User_Log_ID), Convert.ToInt32(SessionClass.UserID));
            Application.Restart();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockRegisterr _form = new FormStockRegisterr();
            FormStockRegisterr._LoadedFrom = 4;
            FormStockRegisterr._TitalText = "Transfer In";
            Show(_form);
        }

        private void btnTransferOut_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockRegisterr _form = new FormStockRegisterr();
            FormStockRegisterr._LoadedFrom = 5;
            FormStockRegisterr._TitalText = "Transfer Out";
            Show(_form);
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockRegisterr _form = new FormStockRegisterr();
            FormStockRegisterr._LoadedFrom = 3;
            FormStockRegisterr._TitalText = "Purchase Return";
            Show(_form);
        }

        private void btnDamage_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormStockRegisterr _form = new FormStockRegisterr();
            FormStockRegisterr._LoadedFrom = 6;
            FormStockRegisterr._TitalText = "Damage";
            Show(_form);
        }

        public void SetUserPrivileges()
        {
            frmPOS._frmCustomerEnable = false;
            int _rows = dtPrivileges.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                string _btnName = "_" + dtPrivileges.Rows[i].ItemArray[0].ToString();
                if (_btnName == "_150")
                {
                    _150.Enabled = true;
                    continue;
                }
                if (_btnName == "_171")
                {
                    _171.Enabled = true;
                    continue;
                }
                if (_btnName == "_175") // support ticket module id = 175
                {
                    _1710.Enabled = true;
                    continue;
                }
                if (_btnName == "_174") // video tutorials module id =174
                {
                    _1500.Enabled = true;
                    continue;
                }
                else if (_btnName == "_176") // request a feature module id = 176
                {
                    _460.Enabled = true;
                    continue;
                }
                else if (_btnName == "_177") // activate software module id= 177
                {
                    _461.Enabled = true;
                    continue;
                }
                if (_btnName == "_178") // Low Stock Alert REPORT module id = 178
                {
                    _1721.Enabled = true;
                    continue;
                }
                if (_btnName == "_172")
                {
                    _172.Enabled = true;
                    continue;
                }
                else if (_btnName == "_9")
                {
                    _9.Enabled = true;
                    continue;
                }
                else if (_btnName == "_153")
                {
                    _153.Enabled = true;
                    continue;
                }
                else if (_btnName == "_154")
                {
                    _154.Enabled = true;
                    continue;
                }
                else if (_btnName == "_155")
                {
                    _155.Enabled = true;
                    continue;
                }
                else if (_btnName == "_144")
                {
                    _144.Enabled = true;
                    continue;
                }
                else if (_btnName == "_20")
                {
                    _20.Enabled = true;
                    continue;
                }
                else if (_btnName == "_22")
                {
                    _22.Enabled = true;
                    continue;
                }
                else if (_btnName == "_21")
                {
                    _21.Enabled = true;
                    continue;
                }
                else if (_btnName == "_129")
                {
                    _129.Enabled = true;
                    continue;
                }
                else if (_btnName == "_80")
                {
                    _80.Enabled = true;
                    continue;
                }
                else if (_btnName == "_147")
                {
                    _147.Enabled = true;
                    continue;
                }
                else if (_btnName == "_12")
                {
                    _12.Enabled = true;
                    continue;
                }
                else if (_btnName == "_13")
                {
                    _13.Enabled = true;
                    continue;
                }
                else if (_btnName == "_14")
                {
                    _14.Enabled = true;
                    continue;
                }
                else if (_btnName == "_15")
                {
                    _15.Enabled = true;
                    continue;
                }
                else if (_btnName == "_145")
                {
                    _145.Enabled = true;
                    continue;
                }
                else if (_btnName == "_156")
                {
                    _156.Enabled = true;
                    frmPOS._frmCustomerEnable = true;
                    continue;
                }
                else if (_btnName == "_19")
                {
                    _19.Enabled = true;
                    continue;
                }
                else if (_btnName == "_48")
                {
                    // _48.Enabled = true;
                    continue;
                }
                else if (_btnName == "_30")
                {
                    _30.Enabled = true;
                    continue;
                }
                else if (_btnName == "_40")
                {
                    _40.Enabled = true;
                    continue;
                }
                else if (_btnName == "_157")
                {
                    _157.Enabled = true;
                    continue;
                }
                else if (_btnName == "_158")
                {
                    _158.Enabled = true;
                    continue;
                }
                else if (_btnName == "_159")
                {
                    _159.Enabled = true;
                    continue;
                }
                else if (_btnName == "_160")
                {
                    _160.Enabled = true;
                    continue;
                }
                else if (_btnName == "_62")
                {
                    _62.Enabled = true;
                    continue;
                }
                else if (_btnName == "_149")
                {
                    _149.Enabled = true;
                    continue;
                }
                else if (_btnName == "_47")
                {
                    _47.Enabled = true;
                    continue;
                }
                else if (_btnName == "_63")
                {
                    _63.Enabled = true;
                    continue;
                }
                else if (_btnName == "_67")
                {
                    _67.Enabled = true;
                    continue;
                }
                else if (_btnName == "_73")
                {
                    _73.Enabled = true;
                    continue;
                }
                else if (_btnName == "_86")
                {
                    _86.Enabled = true;
                    continue;
                }
                else if (_btnName == "_123")
                {
                    _123.Enabled = true;
                    continue;
                }
                else if (_btnName == "_150")
                {
                    _150.Enabled = true;
                    continue;
                }
                else if (_btnName == "_46")
                {
                    _46.Enabled = true;
                    continue;
                }
                else if (_btnName == "_45")
                {
                    _45.Enabled = true;
                    continue;
                }
                else if (_btnName == "_61")
                {
                    _61.Enabled = true;
                    continue;
                }
                else if (_btnName == "_74")
                {
                    _74.Enabled = true;
                    continue;
                }
                else if (_btnName == "_151")
                {
                    _151.Enabled = true;
                    continue;
                }
                else if (_btnName == "_170")
                {
                    _170.Enabled = true;
                    continue;
                }
                else if (_btnName == "_60")
                {
                    _60.Enabled = true;
                    continue;
                }
                else if (_btnName == "_121")
                {
                    _121.Enabled = true;
                    continue;
                }
                else if (_btnName == "_122")
                {
                    _122.Enabled = true;
                    continue;
                }
                else if (_btnName == "_152")
                {
                    _152.Enabled = true;
                    continue;
                }
                else if (_btnName == "_112")
                {
                    _112.Enabled = true;
                    continue;
                }
                else if (_btnName == "_120")
                {
                    _120.Enabled = true;
                    continue;
                }
                else if (_btnName == "_77")
                {
                    _77.Enabled = true;
                    continue;
                }
                else if (_btnName == "_78")
                {
                    _78.Enabled = true;
                    continue;
                }
                else if (_btnName == "_84")
                {
                    _84.Enabled = true;
                    continue;
                }
                else if (_btnName == "_111")
                {
                    _111.Enabled = true;
                    continue;
                }
                else if (_btnName == "_34")
                {
                    _34.Enabled = true;
                    continue;
                }
                else if (_btnName == "_35")
                {
                    _35.Enabled = true;
                    continue;
                }
                else if (_btnName == "_17")
                {
                    _17.Enabled = true;
                    continue;
                }
                else if (_btnName == "_36")
                {
                    //  _36.Enabled = true;
                    continue;
                }
                else if (_btnName == "_87")
                {
                    _87.Enabled = true;
                    continue;
                }
                else if (_btnName == "_161")
                {
                    _161.Enabled = true;
                    continue;
                }
                else if (_btnName == "_58")
                {
                    _58.Enabled = true;
                    continue;
                }
                else if (_btnName == "_37")
                {
                    _37.Enabled = true;
                    continue;
                }
                else if (_btnName == "_75")
                {
                    _75.Enabled = true;
                    continue;
                }
                else if (_btnName == "_59")
                {
                    _59.Enabled = true;
                    continue;
                }
                else if (_btnName == "_68")
                {
                    _68.Enabled = true;
                    continue;
                }
                else if (_btnName == "_100")
                {
                    _100.Enabled = true;
                    continue;
                }
                else if (_btnName == "_106")
                {
                    _106.Enabled = true;
                    continue;
                }
                else if (_btnName == "_103")
                {
                    _103.Enabled = true;
                    continue;
                }
                else if (_btnName == "_116")
                {
                    _116.Enabled = true;
                    continue;
                }
                else if (_btnName == "_162")
                {
                    _162.Enabled = true;
                    continue;
                }
                else if (_btnName == "_163")
                {
                    _163.Enabled = true;
                    continue;
                }
                else if (_btnName == "_164")
                {
                    _164.Enabled = true;
                    continue;
                }
                else if (_btnName == "_166")
                {
                    _166.Enabled = true;
                    continue;
                }
                //else if (_btnName == "_167")
                //{
                //    _167.Enabled = true;
                //    continue;
                //}
                //else if (_btnName == "_168")
                //{
                //    _168.Enabled = true;
                //    continue;
                //}
                //else if (_btnName == "_169")
                //{
                //    _169.Enabled = true;
                //    continue;
                //}
            }
        }

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            string _driveName = "";
            var deriveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo info in deriveInfo)
            {
                if (info.DriveType == DriveType.Fixed)
                {
                    _driveName = info.Name.ToString();
                }
            }
            SaveFileDialog _dlg = new SaveFileDialog();
            _dlg.InitialDirectory = _driveName;
            _dlg.RestoreDirectory = true;
            _dlg.Title = "Save Backup file";
            _dlg.DefaultExt = "BAK";
            _dlg.Filter = "Backup Files (*.BAK)|*.BAK";
            if (_dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(_dlg.FileName))
                {
                    File.Delete(_dlg.FileName);
                }
                lblFileName.Text = _dlg.FileName.Replace(@"\\", @"\");
                SLASHCodesController _controller = new SLASHCodesController();
                string _result = _controller.BackupRestore(lblFileName.Text, Configuration.DatabaseName, 1);
                if (_result == "YES")
                {
                    MessageBox.Show(this, "Backup has been taken successfully", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, _result, "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string _driveName = "";
            var deriveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo info in deriveInfo)
            {
                if (info.DriveType == DriveType.Fixed)
                {
                    _driveName = info.Name.ToString();
                }

            }
            OpenFileDialog _dlg = new OpenFileDialog();
            _dlg.InitialDirectory = _driveName;
            _dlg.RestoreDirectory = true;
            _dlg.Title = "Select file";
            _dlg.DefaultExt = "BAK";
            _dlg.Filter = "Backup Files (*.BAK)|*.BAK";
            if (_dlg.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = _dlg.FileName.Replace(@"\\", @"\");
                SLASHCodesController _controller = new SLASHCodesController();
                string _result = _controller.BackupRestore(lblFileName.Text, Configuration.DatabaseName, 2);
                if (_result == "YES")
                {
                    MessageBox.Show(this, "Restored successfully", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Some error occured:\nCheck Database with name \" '" + Configuration.DatabaseName + "' \" is exist or not", "CORN:POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnABC_Click(object sender, EventArgs e)
        {
            FormShiftOpeningAmount frm = new FormShiftOpeningAmount();
            frm.ShowDialog();
        }

        private void _46_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormRollBack _formFormRollBack = new FormRollBack();
            Show(_formFormRollBack);
        }
        private void _460_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            MessageBox.Show("This feature is not available in this edition of software", "CORN POS");
            //frmRequestAFeature _frmRequestAFeature = new frmRequestAFeature();
            //Show(_frmRequestAFeature);
        }
        private void _461_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            frmActivate _frmActivate = new frmActivate();
            Show(_frmActivate);
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormSMS _formsms = new FormSMS();
            Show(_formsms);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowForm("");
        }
        private void ShowForm(string strFormName)
        {
            object[] objParameters;

            try
            {
                strFormName = "frmMainDashBoard";

                if (strFormName != null)
                {
                    //Assembly asm = Assembly.GetEntryAssembly();

                    //string path = asm.GetName().ToString();
                    //path = path.Substring(0, path.IndexOf(","));

                    //string formName = path + "." + strFormName;

                    //Type formType = asm.GetType(formName, true);
                    //Form form = (Form)Activator.CreateInstance(formType);
                    frmMainDashBoard form = new frmMainDashBoard();
                    form.ControlBox = true;
                    form.IsMdiContainer = false;
                    form.AutoScroll = true;
                    form.AutoSize = true;

                    form.WindowState = FormWindowState.Maximized;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    SessionClass.DashboardViewOnly = false;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadDashboard(string strFormName)
        {
            object[] objParameters;

            try
            {
                strFormName = "frmMainDashBoard";

                if (strFormName != null)
                {
                    //Assembly asm = Assembly.GetEntryAssembly();

                    //string path = asm.GetName().ToString();
                    //path = path.Substring(0, path.IndexOf(","));

                    //string formName = path + "." + strFormName;

                    //Type formType = asm.GetType(formName, true);
                    //Form form = (Form)Activator.CreateInstance(formType);

                    frmMainDashBoard form = new frmMainDashBoard();
                    form.IsMdiContainer = false;
                    form.MdiParent = this;
                    form.AutoScroll = true;
                    form.ControlBox = false;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.BringToFront();
                    SessionClass.DashboardViewOnly = true;
                    form.WindowState = FormWindowState.Minimized;
                    form.Show();
                    form.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MainFrom_Shown(object sender, EventArgs e)
        {
            //if (SessionClass.Is_POS_USER == false)
            //{
            //    LoadDashboard("");
            //}
        }
        public void LoadDashBoard()
        {
            LoadDashboard("");
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (!IsFormOpen())
            {
                LoadDashBoard(); //btn Dashboard Viewer 
            }
        }
        public bool IsFormOpen()
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == "frmMainDashBoard")
                    return true;
            return false;
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
        }

        private void _171_Click(object sender, EventArgs e)
        {
            ribbonControl1.Expanded = false;
            ClosePreviousForms();
            //frmSectionSale _formPOS = new frmSectionSale();
            //Show(_formPOS);
            //_formPOS.WindowState = FormWindowState.Minimized;
            //_formPOS.WindowState = FormWindowState.Maximized;
        }
        private void _1710_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            MessageBox.Show("This feature is not available in this edition of software", "CORN POS");
        }
        private void _1500_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            frmVideoTutorial _frmVdoTutorial = new frmVideoTutorial();
            Show(_frmVdoTutorial);
            Process.Start(@"https://docs.google.com/document/d/14Fg9OZpQOYmFajBCn_8Jspw4Z5n2mOfilWiiECGG320/edit?usp=sharing");
        }

        private void _172_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            FormReportItemLedger _formPOS = new FormReportItemLedger();
            Show(_formPOS);
            _formPOS.WindowState = FormWindowState.Minimized;
            _formPOS.WindowState = FormWindowState.Maximized;
        }
        private void _1721_Click(object sender, EventArgs e)
        {
            ClosePreviousForms();
            ShowReportViewer(3);

        }
        //public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        //{
        //    //var ratioX = (double)maxWidth / image.Width;
        //    //var ratioY = (double)maxHeight / image.Height;
        //    //var ratio = Math.Min(ratioX, ratioY);

        //    //var newWidth = (int)(image.Width * ratio);
        //    //var newHeight = (int)(image.Height * ratio);

        //    //var newImage = new Bitmap(newWidth, newHeight);

        //    //using (var graphics = Graphics.FromImage(newImage))
        //    //    graphics.DrawImage(image, 0, 0, newWidth, newHeight);

        //    Bitmap newImage = new Bitmap(maxWidth, maxHeight);
        //    using (Graphics gr = Graphics.FromImage(newImage))
        //    {
        //        gr.SmoothingMode = SmoothingMode.HighQuality;
        //        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        gr.DrawImage(image, new Rectangle(0, 0, maxWidth, maxHeight));
        //    }

        //    return newImage;
        //}
        //public byte[] ReadFile(string sPath)
        //{
        //    byte[] data = null;
        //    FileInfo fInfo = new FileInfo(sPath);
        //    long numBytes = fInfo.Length;
        //    FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fStream);
        //    data = br.ReadBytes((int)numBytes);
        //    return data;
        //}
        //private void btnLogo_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.Title = "Select Logo";
        //    dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
        //    dlg.Multiselect = false;
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {

        //        Bitmap img = new Bitmap(dlg.FileName);
        //        int imageHeight = Convert.ToInt32(img.Height);
        //        int imageWidth = Convert.ToInt32(img.Width);
        //        if (imageHeight >= 100 && imageWidth >= 100)
        //        {
        //            var fileName = dlg.FileName;
        //            string ext = Path.GetExtension(dlg.FileName);
        //            string imgName = Path.GetFileNameWithoutExtension(fileName);

        //            using (var image = Image.FromFile(fileName))
        //            using (var newImage = ScaleImage(image, 60, 70))
        //            {
        //                newImage.Save(Application.StartupPath + @"\InvLogo.png");
        //            }
        //            // Save to db
        //           // byte[] imageData = ReadFile(Application.StartupPath + @"\InvLogo.png");
        //        }
        //        else
        //        {
        //            MessageBox.Show(this, "Minimum Size of Image should be 100 x 100.", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
    }
}
