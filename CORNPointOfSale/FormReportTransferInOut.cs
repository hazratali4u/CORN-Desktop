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
    public partial class FormReportTransferInOut : Form
    {
        public FormReportTransferInOut()
        {
            InitializeComponent();
        }

        private void FormReportTransferInOut_Load(object sender, EventArgs e)
        {
            LoadPrincipal();
            LoadLocation();
            txtFromDate.Value = SessionClass.CurrentWorkDate;
            txtToDate.Value = SessionClass.CurrentWorkDate;
            DrpReportType.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        protected void LoadPrincipal()
        {
            try
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
                DrpPrincipal.DataSource = m_dt;
                DrpPrincipal.DisplayMember = "Company_Name";
                DrpPrincipal.ValueMember = "Company_Id";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        protected void LoadLocation()
        {
            drpDistributor.DataSource = null;
            drpDistributor.Items.Clear();
            if (DrpReportType.SelectedIndex == 2)
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = dt;
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
            }
            else
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
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
        /// Shows Transfer In/Out Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string _rbtnText = "Transfer In";
                int _rbtnValue = 0;
                if (rbtnTransferOut.Checked)
                {
                    _rbtnText = "Transfer Out";
                    _rbtnValue = 1;
                }
                if (DrpReportType.SelectedIndex == 2)
                {
                    btnViewPDF.Text = "Wait...";
                    btnViewPDF.Enabled = false;
                    CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                    RptInventoryController RptInventoryCtl = new RptInventoryController();

                    string FromDate = null;
                    string ToDate = null;
                    string TransferType = null;
                    string TransferTo_FromHeader = null;
                    CORNBusinessLayer.Reports.CrpTransferInOutValues CrpReport = new CORNBusinessLayer.Reports.CrpTransferInOutValues();
                    DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                    DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
                    FromDate = parsed_date_fromdate.ToShortDateString();
                    ToDate = parsed_date_todate.ToShortDateString();

                    DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                    DataSet ds = RptInventoryCtl.TransferInOutValue(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 00:00:00"), _rbtnText, int.Parse(SessionClass.UserID.ToString()));

                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();

                    FromDate = this.txtFromDate.Text;
                    ToDate = this.txtToDate.Text;
                    if (_rbtnText == "Transfer In")
                    {
                        TransferType = "Branch Transfer In Report value wise";
                        TransferTo_FromHeader = "Transfer From";
                    }
                    else
                    {
                        TransferType = "Branch Transfer Out Report value wise";
                        TransferTo_FromHeader = "Transfer To";
                    }
                    CrpReport.SetParameterValue("FromDate", FromDate);
                    CrpReport.SetParameterValue("ToDate", ToDate);
                    CrpReport.SetParameterValue("Principal", this.DrpPrincipal.Text);
                    CrpReport.SetParameterValue("TransferTo_FromHeader", TransferType);
                    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReport;
                    _formReport.ShowDialog();
                    btnViewPDF.Text = "View";
                    btnViewPDF.Enabled = true;
                }
                else
                {
                    btnViewPDF.Text = "Wait...";
                    btnViewPDF.Enabled = false;
                    CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                    RptInventoryController RptInventoryCtl = new RptInventoryController();

                    string FromDate = null;
                    string ToDate = null;
                    string TransferType = null;
                    string TransferTo_FromHeader = null;
                    CORNBusinessLayer.Reports.CrpTransferIn CrpReport = new CORNBusinessLayer.Reports.CrpTransferIn();
                    DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                    DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
                    FromDate = parsed_date_fromdate.ToShortDateString();
                    ToDate = parsed_date_todate.ToShortDateString();

                    DataSet ds = RptInventoryCtl.TransferIn(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 00:00:00"), _rbtnText, DrpReportType.SelectedIndex);
                    DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();

                    CrpReport.SetParameterValue("BranchName", this.drpDistributor.Text);
                    FromDate = this.txtFromDate.Text;
                    ToDate = this.txtToDate.Text;
                    if (_rbtnText == "Transfer In")
                    {
                        TransferType = "Branch Transfer In Report";
                        TransferTo_FromHeader = "Transfer From";
                    }
                    else
                    {
                        TransferType = "Branch Transfer Out Report";
                        TransferTo_FromHeader = "Transfer To";
                    }
                    CrpReport.SetParameterValue("FromDate", FromDate);
                    CrpReport.SetParameterValue("ToDate", ToDate);
                    CrpReport.SetParameterValue("TransferType", TransferType);
                    CrpReport.SetParameterValue("Principal", this.DrpPrincipal.Text);
                    CrpReport.SetParameterValue("TransferTo_FromHeader", TransferTo_FromHeader);
                    CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                    FormReport _formReport = new FormReport();
                    _formReport.crvReportViewer.ReportSource = CrpReport;
                    _formReport.ShowDialog();
                    btnViewPDF.Text = "View";
                    btnViewPDF.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnViewPDF.Text = "View";
                btnViewPDF.Enabled = true;
                ex.ToString();
            }
        }

        /// <summary>
        /// Loads Locations
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadLocation();
        }

        private void FormReportTransferInOut_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 240, 115);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
