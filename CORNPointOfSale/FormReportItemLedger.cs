using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using CORNBusinessLayer.Reports;

namespace CORNPointOfSale
{
    public partial class FormReportItemLedger : Form
    {
        static string location = "";
        DataTable dtItems;
        public FormReportItemLedger()
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
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    location += dr[0].ToString() + ',';
                }
            }
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
            if (DrpSKU.SelectedValue == null)
            {
                MessageBox.Show("Invalid Item Selection", "CORN: POS");
                return;
            }
            //DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            //DataSet ds = RptSaleCtl.GetSKUPriceHistory(int.Parse(DrpSKU.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpCategory.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),DrpPrices.SelectedIndex);
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController mController = new DocumentPrintController();
            RptInventoryController RptInventoryCtl = new RptInventoryController();
            CrpSKULedger CrpReport = new CrpSKULedger();
            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = null;
            if (drpDistributor.SelectedValue.ToString() == "All")
            {
                ds = RptInventoryCtl.GetSKULedgerData(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text + " 23:59:59"), Constants.IntNullValue, Convert.ToInt32(DrpSKU.SelectedValue.ToString()), location, Constants.IntNullValue);

            }
            else
            {
                ds = RptInventoryCtl.GetSKULedgerData(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text + " 23:59:59"), Constants.IntNullValue, Convert.ToInt32(DrpSKU.SelectedValue.ToString()), drpDistributor.SelectedValue.ToString(), Constants.IntNullValue);
            }
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Location", drpDistributor.Text);
            CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnView.Text = "View";
            btnView.Enabled = true;
            //if (DrpPrices.SelectedIndex == 0)
            //{

            //    CORNBusinessLayer.Reports.CrpSKULedger CrpReport = new CORNBusinessLayer.Reports.CrpSKULedger();

            //    CrpReport.SetDataSource(ds);
            //    CrpReport.Refresh();

            //    CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
            //    CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
            //    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            //    CrpReport.SetParameterValue("Location", drpDistributor.Text);
            //    CrpReport.SetParameterValue("Principal", "All");
            //    CrpReport.SetParameterValue("SKU", DrpSKU.Text);
            //    CrpReport.SetParameterValue("Price", DrpPrices.Text);
            //    FormReport _formReport = new FormReport();
            //    _formReport.crvReportViewer.ReportSource = CrpReport;
            //    _formReport.ShowDialog();
            //}
            //else
            //{
            //    CORNBusinessLayer.Reports.CrpSKULedger CrpReport = new CORNBusinessLayer.Reports.CrpSKULedger();

            //    CrpReport.SetDataSource(ds);
            //    CrpReport.Refresh();
            //    CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
            //    CrpReport.SetParameterValue("To_Date", DateTime.Parse(txtEndDate.Text));
            //    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            //    CrpReport.SetParameterValue("Location", drpDistributor.Text);
            //    CrpReport.SetParameterValue("Principal", "All");
            //    CrpReport.SetParameterValue("SKU", DrpSKU.Text);
            //    CrpReport.SetParameterValue("Price", DrpPrices.Text);
            //    CrpReport.SetParameterValue("ReportType", int.Parse(DrpPrices.SelectedValue.ToString()));
            //    FormReport _formReport = new FormReport();
            //    _formReport.crvReportViewer.ReportSource = CrpReport;
            //    _formReport.ShowDialog();
            //}
        }
        /// <summary>
        /// Loads SKUS To SKU Combo
        /// </summary>
        private void LoadSKUDetail()
        {
            DataTable dtItems = new DataTable();
            try
            {
                dtItems.Columns.Add("Id", typeof(Int32));
                dtItems.Columns.Add("SkuDetail", typeof(string));
                dtItems.Clear();
            }
            catch (Exception)
            {
            }
            if (DrpCategory.DisplayMember == "SKU_HIE_NAME" && DrpCategory.ValueMember == "SKU_HIE_ID")
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
                //DrpSKU.DataSource = SKU_ALL(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    dtItems.Rows.Add(Convert.ToInt32(dr["SKU_ID"]), dr["SKUDETAIL"].ToString());
                }
                foreach (DataRow dr in dt.Rows)
                {
                    dtItems.Rows.Add(Convert.ToInt32(dr["SKU_ID"]), dr["SKUDETAIL1"].ToString());
                }
                DrpSKU.DataSource = dtItems;
                DrpSKU.DisplayMember = "SkuDetail";
                DrpSKU.ValueMember = "Id";
            }
        }
        public DataTable SKU_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["SKU_ID"] = Constants.IntNullValue;
            dr["SKUDETAIL"] = "All";
            dt.Rows.InsertAt(dr, 0);
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
            dt.Rows.InsertAt(dr, 0);
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
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
