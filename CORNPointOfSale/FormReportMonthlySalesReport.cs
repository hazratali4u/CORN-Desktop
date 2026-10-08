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
    public partial class FormReportMonthlySalesReport : Form
    {
        public FormReportMonthlySalesReport()
        {
            InitializeComponent();
        }

        private void FormReportMonthlySalesReport_Load(object sender, EventArgs e)
        {
            this.DistributorType();
            DrpReportType.SelectedIndex = 0;
            this.LoadAssingned();
            this.UnitType();
            SetDivs();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartYear.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndYear.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;

            txtFromMonth.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtToMonth.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;

            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        public void UnitType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(Int32));
            dt.Rows.Add("Year Wise", 0);
            dt.Rows.Add("Month Wise", 1);
            dt.Rows.Add("Date Wise", 2);
            DrpUnitType.DataSource = dt;
            DrpUnitType.DisplayMember = "Display";
            DrpUnitType.ValueMember = "Value";
            DrpUnitType.SelectedIndex = 0;
        }
        /// <summary>
        /// Loads LocationTypes To LocationType Combo
        /// </summary>
        private void DistributorType()
        {
            DistributorController dController = new DistributorController();
            DataTable dt = dController.SelectDistributorTypeInfo(Constants.IntNullValue);
            ddDistributorType.DataSource = dt;
            ddDistributorType.DisplayMember = "TYPENAME";
            ddDistributorType.ValueMember = "DISTRIBUTOR_TYPE_ID";
            if (ddDistributorType.Items.Count > 0)
            {
                ddDistributorType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Loads Assigned Locations To Location Combo
        /// </summary>
        private void LoadAssingned()
        {
            if (ddDistributorType.DisplayMember == "TYPENAME" && ddDistributorType.ValueMember == "DISTRIBUTOR_TYPE_ID")
            {
                drpDistributor.DataSource = null;
                drpDistributor.Items.Clear();
                UserController mUserController = new UserController();
                DataTable dt = mUserController.SelectUserAssignment(int.Parse(SessionClass.UserID.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 1, int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
                drpDistributor.DisplayMember = "distributor_name";
                drpDistributor.ValueMember = "distributor_id";
            }
        }
         public DataTable DISTRIBUTOR_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["DISTRIBUTOR_ID"] = Constants.IntNullValue;
            dr["DISTRIBUTOR_NAME"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads Assigned Locations
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAssingned();
        }

        /// <summary>
        /// Shows Report in Excel Or PDF
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
        {
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();
            if (DrpUnitType.SelectedValue.ToString() == "0")
            {
                dtFrom = new DateTime(Convert.ToInt32(this.txtStartYear.Value.ToString("yyyy")), 1, 1);
                dtTo = new DateTime(Convert.ToInt32(this.txtEndYear.Value.ToString("yyyy")), 12, 31);
            }
            else if (DrpUnitType.SelectedValue.ToString() == "1")
            {
                DateTime dtFromMonth = Convert.ToDateTime(txtFromMonth.Value);
                dtFrom = new DateTime(dtFromMonth.Year, dtFromMonth.Month, 1);

                DateTime dtToMonth = Convert.ToDateTime(txtToMonth.Value);
                dtTo = new DateTime(dtToMonth.Year, dtToMonth.Month, 1);
                dtTo = dtTo.AddMonths(1).AddDays(-1);
            }
            else
            {
                dtFrom = Convert.ToDateTime(txtStartDate.Value);
                dtTo = Convert.ToDateTime(txtEndDate.Value);
            }

            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataSet ds ;
            if (rbtnTradePrice.Checked)
            {
                ds = RptSaleCtl.GetDistributorReconcilation(byte.Parse(DrpUnitType.SelectedIndex.ToString()), Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), dtFrom, dtTo, int.Parse(SessionClass.UserID.ToString()), byte.Parse(DrpReportType.SelectedIndex.ToString()), 0);
            }
            else
            {
                ds = RptSaleCtl.GetDistributorReconcilation(byte.Parse(DrpUnitType.SelectedIndex.ToString()), Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), dtFrom, dtTo, int.Parse(SessionClass.UserID.ToString()), byte.Parse(DrpReportType.SelectedIndex.ToString()), 1);
            }

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.CrpMonthSaleValume CrpReport = new CORNBusinessLayer.Reports.CrpMonthSaleValume();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("FromDate", dtFrom);
            CrpReport.SetParameterValue("ToDate", dtTo);
            CrpReport.SetParameterValue("Principal", "All");
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("ReportType", DrpReportType.Text);
            CrpReport.SetParameterValue("ParameterType", DrpReportType.Text);
            if (rbtnTradePrice.Checked)
            {
                CrpReport.SetParameterValue("Price", "Trade Price");
            }
            else if (rbtnPurchasePrice.Checked)
            {
                CrpReport.SetParameterValue("Price", "Purchase Price");
            }
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnView.Text = "View";
            btnView.Enabled = true;
        }

        /// <summary>
        /// Shows Monthly Sale Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        /// <summary>
        /// Sets Date, Month And Year Divisions Visibility
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpUnitType.Items.Count > 0)
            {
                SetDivs(); 
            }
        }

        /// <summary>
        /// Sets Date, Month And Year Divisions Visibility As Per Report Type
        /// </summary>
        private void SetDivs()
        {
            try
            {
                if (DrpUnitType.SelectedValue.ToString() == "0")
                {
                    panelDate.Visible = false;
                    panelMonth.Visible = false;
                    panelYear.Visible = true;
                }
                else if (DrpUnitType.SelectedValue.ToString() == "1")
                {
                    panelDate.Visible = false;
                    panelMonth.Visible = true;
                    panelYear.Visible = false;
                }
                else if (DrpUnitType.SelectedValue.ToString() == "2")
                {
                    panelDate.Visible = true;
                    panelMonth.Visible = false;
                    panelYear.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void FormReportMonthlySalesReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 130);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

        private void panelYear_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
