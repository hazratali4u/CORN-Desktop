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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace CORNPointOfSale
{
    public partial class FormReportIncoemStatementReport : Form
    {
        public FormReportIncoemStatementReport()
        {
            InitializeComponent();
        }

        private void FormReportIncoemStatementReport_Load(object sender, EventArgs e)
        {
            this.LoadAssingned();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;

            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }

        /// <summary>
        /// Loads Assigned Locations To Location Combo
        /// </summary>
        private void LoadAssingned()
        {
            drpDistributor.DataSource = null;
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }
        public DataTable DISTRIBUTOR_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["DISTRIBUTOR_ID"] = Constants.IntNullValue;
            dr["DISTRIBUTOR_NAME"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        /// <summary>
        /// Shows Report in Excel Or PDF
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
        {
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();
            dtFrom = Convert.ToDateTime(txtStartDate.Value);
            dtTo = Convert.ToDateTime(txtEndDate.Value);

            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataSet ds;
            ds = RptSaleCtl.SelectRptGrossProfit2(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue,dtFrom, dtTo);

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.CrpGrossProfitReport2 CrpReport = new CORNBusinessLayer.Reports.CrpGrossProfitReport2();
            ReportDocument SubReport = CrpReport.OpenSubreport("srGrossProfit");

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("From_Date", dtFrom);
            CrpReport.SetParameterValue("To_date", dtTo);
            CrpReport.SetParameterValue("Location", drpDistributor.SelectedText);
            CrpReport.SetParameterValue("Principal", "All");

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

        private void FormReportIncoemStatementReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 130);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

    }
}
