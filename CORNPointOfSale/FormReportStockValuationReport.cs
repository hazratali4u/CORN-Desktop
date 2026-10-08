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
    public partial class FormReportStockValuationReport : Form
    {
        public FormReportStockValuationReport()
        {
            InitializeComponent();
        }

        private void FormReportStockValuationReport_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
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
        /// Shows Stock Valuation Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        /// <summary>
        /// Shows Stock Valuation Report in Either PDF Or in Excel
        /// </summary>
        /// <param name="p_Report_Type"></param>
        private void ShowReport(int p_Report_Type)
        {
            int _rbtnValue = 0;
            if (rbtnSummary.Checked)
            {
                _rbtnValue = 1;
            }
            btnViewPDF.Text = "Wait...";
            btnViewPDF.Enabled = false;
            DocumentPrintController mController = new DocumentPrintController();
            RptInventoryController RptInventoryCtl = new RptInventoryController();
            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = RptInventoryCtl.SelectStockValuation(DateTime.Parse(txtEndDate.Text), int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), _rbtnValue);

            if (rbtnDetail.Checked)
            {
                if (drpDistributor.Text == "All")
                {
                    CORNBusinessLayer.Reports.CrpStockValuationDetailAllLocations CrpReportDetailAll = new CORNBusinessLayer.Reports.CrpStockValuationDetailAllLocations();
                    CrpReportDetailAll.SetDataSource(ds);
                    CrpReportDetailAll.Refresh();
                    CrpReportDetailAll.SetParameterValue("division", drpDistributor.Text);
                    CrpReportDetailAll.SetParameterValue("todate", txtEndDate.Text);
                    CrpReportDetailAll.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                    CrpReportDetailAll.SetParameterValue("Principal", "All");
                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReportDetailAll;
                    _formReport.ShowDialog();
                }

                else
                {
                    CORNBusinessLayer.Reports.CrpStockValuationDetailSingleLocations CrpReportDetailSingle = new CORNBusinessLayer.Reports.CrpStockValuationDetailSingleLocations();
                    CrpReportDetailSingle.SetDataSource(ds);
                    CrpReportDetailSingle.Refresh();
                    CrpReportDetailSingle.SetParameterValue("division", drpDistributor.Text);
                    CrpReportDetailSingle.SetParameterValue("todate", txtEndDate.Text);
                    CrpReportDetailSingle.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                    CrpReportDetailSingle.SetParameterValue("Principal", "All");
                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReportDetailSingle;
                    _formReport.ShowDialog();
                }
            }
            else
            {
                CORNBusinessLayer.Reports.CrpStockValuationSummary CrpReportStockValuationSummary = new CORNBusinessLayer.Reports.CrpStockValuationSummary();
                CrpReportStockValuationSummary.SetDataSource(ds);
                CrpReportStockValuationSummary.Refresh();
                CrpReportStockValuationSummary.SetParameterValue("division", drpDistributor.Text);
                CrpReportStockValuationSummary.SetParameterValue("todate", txtEndDate.Text);
                CrpReportStockValuationSummary.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReportStockValuationSummary;
                _formReport.ShowDialog();
            }
            btnViewPDF.Text = "View";
            btnViewPDF.Enabled = true;
        }

        private void FormReportStockValuationReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 85);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
