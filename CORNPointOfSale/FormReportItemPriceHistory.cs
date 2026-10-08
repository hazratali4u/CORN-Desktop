using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormReportItemPriceHistory : Form
    {
        public FormReportItemPriceHistory()
        {
            InitializeComponent();
        }

        private void ItemPriceHistory_Load(object sender, EventArgs e)
        {
            DrpPrices.SelectedIndex = 0;
            this.LoadDistributor();
            
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            
        }
        
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = dt;
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }
        /// <summary>
        /// Shows SKU Price History in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }
        /// <summary>
        /// Shows SKU Price History Report in Excel Or PDF
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
        {
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController DPrint = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();

            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = RptSaleCtl.GetSKUPriceHistory(int.Parse(DrpSKU.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpCategory.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),DrpPrices.SelectedIndex);

            if (DrpPrices.SelectedIndex == 0)
            {

                CORNBusinessLayer.Reports.CrpSKUPriceHistory CrpReport = new CORNBusinessLayer.Reports.CrpSKUPriceHistory();

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
                CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("Location", drpDistributor.Text);
                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("SKU", DrpSKU.Text);
                CrpReport.SetParameterValue("Price", DrpPrices.Text);
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            else
            {
                CORNBusinessLayer.Reports.CrpSKUPriceHistory2 CrpReport = new CORNBusinessLayer.Reports.CrpSKUPriceHistory2();

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();
                CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
                CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("Location", drpDistributor.Text);
                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("SKU", DrpSKU.Text);
                CrpReport.SetParameterValue("Price", DrpPrices.Text);
                CrpReport.SetParameterValue("ReportType", int.Parse(DrpPrices.SelectedValue.ToString()));
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            btnView.Text = "View";
            btnView.Enabled = true;
        }
        /// <summary>
        /// Loads SKUS To SKU Combo
        /// </summary>
        private void LoadSKUDetail()
        {
            if (DrpCategory.DisplayMember == "SKU_HIE_NAME" && DrpCategory.ValueMember == "SKU_HIE_ID" )
            {
                DrpSKU.DataSource = null;
                DrpSKU.Items.Clear();
                //SkuController mContoller = new SkuController();
                //DataTable dt = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpCategory.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
                FormWaiting._Type = 4;
                FormWaiting._SubType = 2;
                FormWaiting._CategoryID = int.Parse(DrpCategory.SelectedValue.ToString());
                FormWaiting _frmW8 = new FormWaiting();
                _frmW8.ShowDialog();
                DataTable dt = SessionClass.dtItemPriceHistory;
                DrpSKU.DataSource = SKU_ALL(dt);
                DrpSKU.DisplayMember = "SKUDETAIL";
                DrpSKU.ValueMember = "SKU_ID";
            }
        }
         public DataTable SKU_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["SKU_ID"] = Constants.IntNullValue;
            dr["SKUDETAIL"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads SKU Categories To Category Combo
        /// </summary>
        private void LoadCategory()
        {
            DrpCategory.DataSource = null;
            DrpCategory.Items.Clear();
            FormWaiting._Type = 4;
            FormWaiting._SubType = 1;
            FormWaiting _frmW8 = new FormWaiting();
            _frmW8.ShowDialog();
            //SkuHierarchyController sController = new SkuHierarchyController();
            //DataTable dt = sController.SelectSKUCategories(Constants.IntNullValue,Constants.IntNullValue, true);
            DataTable dt = SessionClass.dtCategoryItemPriceHistory;
            DrpCategory.DataSource = Category_ALL(dt);
            DrpCategory.DisplayMember = "SKU_HIE_NAME";
            DrpCategory.ValueMember = "SKU_HIE_ID";
            this.LoadSKUDetail();
        }
         public DataTable Category_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["SKU_HIE_ID"] = Constants.IntNullValue;
            dr["SKU_HIE_NAME"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads SKUS
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSKUDetail();
        }

        private void FormReportItemPriceHistory_Shown(object sender, EventArgs e)
        {
            this.LoadCategory();
           // LoadSKUDetail();
        }

        private void FormReportItemPriceHistory_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 235, 120);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
