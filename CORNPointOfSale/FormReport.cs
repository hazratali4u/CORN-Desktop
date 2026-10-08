using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CrystalDecisions;

namespace CORNPointOfSale
{
    public partial class FormReport : Form
    {
        RptSaleController rptSaleCtl = new RptSaleController();
        RptAccountController rptAccountCtl = new RptAccountController();
        public static int _reportTypeID { get; set; }

        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            if (_reportTypeID == 1)
            {
                SaleReport();
            }
            if (_reportTypeID == 2)
            {
                CustomerList();
            }
            else if (_reportTypeID == 3)
            {
                LowStockList();
            }
        }

        #region crpSalesReportPos
        public void SaleReport()
        {
            DataSet ds = null;
            if (SessionClass.ReportType == 1)
            {
                CORNBusinessLayer.Reports.crpSalesReportPos crpReport = new CORNBusinessLayer.Reports.crpSalesReportPos();
                crpReport.SetDataSource(SessionClass.ds);
                crpReport.Refresh();
                crpReport.SetParameterValue("COMPANY_NAME", SessionClass.HirarchyNameQuiz);
                crpReport.SetParameterValue("FROM_DATE", SessionClass.dtFrom);
                crpReport.SetParameterValue("TO_DATE", SessionClass.dtTo);
                crpReport.SetParameterValue("USER_NAME", SessionClass.lbluserlogin);
                crpReport.SetParameterValue("LOCATION", SessionClass.lblLoacation);
                crpReport.SetParameterValue("PHONE_NUMBER", SessionClass.CompanyPhonNmbr);
                crvReportViewer.ReportSource = crpReport;
                _reportTypeID = 0;
            }
            else // incase of malee
            {
                CORNBusinessLayer.Reports.crpSalesReportPos2 crpReport2 = new CORNBusinessLayer.Reports.crpSalesReportPos2();
                crpReport2.SetDataSource(SessionClass.ds);
                crpReport2.Refresh();
                crpReport2.SetParameterValue("COMPANY_NAME", SessionClass.HirarchyNameQuiz);
                crpReport2.SetParameterValue("FROM_DATE", SessionClass.dtFrom);
                crpReport2.SetParameterValue("TO_DATE", SessionClass.dtTo);
                crpReport2.SetParameterValue("USER_NAME", SessionClass.lbluserlogin);
                crpReport2.SetParameterValue("LOCATION", SessionClass.lblLoacation);
                crpReport2.SetParameterValue("PHONE_NUMBER", SessionClass.CompanyPhonNmbr);
                crvReportViewer.ReportSource = crpReport2;
                _reportTypeID = 0;
            }
        } 
        #endregion

        #region CrpCustomerList
        public void CustomerList()
        {
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            DataTable dt = mDocumentPrntControl.SelectReportTitle(SessionClass.DISTRIBUTOR_ID);
            CORNBusinessLayer.Reports.CrpCustomerList crpReport = new CORNBusinessLayer.Reports.CrpCustomerList();
            crpReport.SetDataSource(rptSaleCtl.SelectPrincipalWiseCustomer(SessionClass.DISTRIBUTOR_ID, 1));
            crpReport.Refresh();
            crpReport.SetParameterValue("COMPANYNAME", dt.Rows[0]["COMPANY_NAME"].ToString());
            crpReport.SetParameterValue("Distributor_name", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
            crvReportViewer.ReportSource = crpReport;
            _reportTypeID = 0;
        }
        #endregion

        #region CrpLowStockList
        public void LowStockList()
        {
            SkuController skuController = new SkuController();
            DataTable dt = skuController.LowStockList(SessionClass.DISTRIBUTOR_ID);
            CORNBusinessLayer.Reports.CrpLowStockList crpReport = new CORNBusinessLayer.Reports.CrpLowStockList();
            crpReport.SetDataSource(dt);
            crpReport.Refresh();
            //crpReport.SetParameterValue("COMPANYNAME", "");
            //crpReport.SetParameterValue("COMPANYNAME", dt.Rows[0]["COMPANY_NAME"].ToString());
            crvReportViewer.ReportSource = crpReport;
            _reportTypeID = 0;
        }
        #endregion

        #region nCSVsBankDeposit
        public void NCSVsBankDeposit(DateTime _toDate)
        {
            CORNBusinessLayer.Reports.CrpNCSVSBankDeposit crpReport = new CORNBusinessLayer.Reports.CrpNCSVSBankDeposit();
            crpReport.SetDataSource(rptAccountCtl.SelectNCSvsDeposit(SessionClass.PRINCIPAL_ID, _toDate));
            crpReport.Refresh();
            crpReport.SetParameterValue("COMPANY_NAME", SessionClass.HirarchyNameQuiz);
            crpReport.SetParameterValue("upToDate", _toDate);
            crvReportViewer.ReportSource = crpReport;
        } 
        #endregion
    }
}
