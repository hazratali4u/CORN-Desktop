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
    public partial class FormReportPhysicalStockReport : Form
    {
        public FormReportPhysicalStockReport()
        {
            InitializeComponent();
        }

        private void FormReportPhysicalStockReport_Load(object sender, EventArgs e)
        {
            LoadLocation();
            this.txtFromDate.Value = SessionClass.CurrentWorkDate;      
        }
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        protected void LoadLocation()
        {
            try
            {
                DrpLocation.DataSource = null;
                DrpLocation.Items.Clear();
                if (rbtnItemWise.Checked)
                {
                    DistributorController DController = new DistributorController();
                    DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                    DrpLocation.DataSource = dt;
                    DrpLocation.DisplayMember = "DISTRIBUTOR_NAME";
                    DrpLocation.ValueMember = "DISTRIBUTOR_ID";
                }
                else
                {
                    DistributorController DController = new DistributorController();
                    DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                    DrpLocation.DataSource = DISTRIBUTOR_ALL(dt);
                    DrpLocation.DisplayMember = "DISTRIBUTOR_NAME";
                    DrpLocation.ValueMember = "DISTRIBUTOR_ID";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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
        /// Shows Physical Stock Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            RptInventoryController RptInventoryCtl = new RptInventoryController();
            try
            {
                if (rbtnItemWise.Checked)
                {
                    CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                    string FromDate = null;
                    CORNBusinessLayer.Reports.CrpPhysicalStockTaking CrpReport = new CORNBusinessLayer.Reports.CrpPhysicalStockTaking();
                    DataSet ds = null;
                    DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                    FromDate = parsed_date_fromdate.ToShortDateString();
                    DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));
                    ds = RptInventoryCtl.PhysicalStockTaking(Constants.IntNullValue, int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"));
                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();
                    CrpReport.SetParameterValue("Principal", "All");
                    CrpReport.SetParameterValue("Branch", this.DrpLocation.Text);
                    CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
                    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReport;
                    _formReport.ShowDialog();
                }
                else
                {
                    CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                    DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpLocation.SelectedValue.ToString()));
                    string FromDate = null;
                    CORNBusinessLayer.Reports.RptPhysicalStockSummary CrpReport = new CORNBusinessLayer.Reports.RptPhysicalStockSummary();
                    DataSet ds = null;
                    DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                    FromDate = parsed_date_fromdate.ToShortDateString();
                    ds = RptInventoryCtl.PhysicalStockTakingValueWise(Constants.IntNullValue, int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(SessionClass.UserID.ToString()));
                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();
                    CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
                    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReport;
                    _formReport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        /// <summary>
        /// Loads Principals And Locations
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void RblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocation();
        }

        private void rbtnItemWise_CheckedChanged(object sender, EventArgs e)
        {
            RblType_SelectedIndexChanged(null, null);
        }

        private void rbtnValueWise_CheckedChanged(object sender, EventArgs e)
        {
            RblType_SelectedIndexChanged(null, null);
        }

        private void FormReportPhysicalStockReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 235, 95);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
