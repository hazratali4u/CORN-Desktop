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
    public partial class FormReportDailySale : Form
    {
        readonly DocumentPrintController _dPrint = new DocumentPrintController();
        readonly RptSaleController _rptSaleCtl = new RptSaleController();
        public FormReportDailySale()
        {
            InitializeComponent();
        }

        private void LoadAssingned()
        {
            drpDistributor.DataSource = null;
            drpDistributor.Items.Clear();
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
            if (drpDistributor.Items.Count > 0)
            {
                drpDistributor.SelectedIndex = 0;
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
        public DataTable USER_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["USER_ID"] = Constants.IntNullValue;
            dr["USER_NAME"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        private void LoadUser()
        {
            try
            {
                if (drpDistributor.DisplayMember == "DISTRIBUTOR_NAME" && drpDistributor.ValueMember == "DISTRIBUTOR_ID")
                {
                    Distributor_UserController _duController = new Distributor_UserController();
                    DataTable dt = _duController.SelectDistributorUser(46, Convert.ToInt32(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue);
                    drpCashier.DataSource = USER_ALL(dt);
                    drpCashier.DisplayMember = "USER_NAME";
                    drpCashier.ValueMember = "USER_ID";
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (drpDistributor.SelectedValue == null)
            {
                MessageBox.Show("Location not Exists", "CORN: POS");
                return;
            }
            if (drpCashier.SelectedValue == null)
            {
                MessageBox.Show("Cashier not Exists", "CORN: POS");
                return;
            }
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DataTable dt = _dPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds;
            if (rdbLocation.Checked)
            {
                ds = _rptSaleCtl.SelectSalePersonDSR(int.Parse(drpDistributor.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),
                    int.Parse(SessionClass.UserID.ToString()), 0);

                var crpReport = new CORNBusinessLayer.Reports.CrpLocationDSR();
                crpReport.SetDataSource(ds);
                crpReport.Refresh();
                crpReport.SetParameterValue("Location", drpDistributor.Text);
                crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
                crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
                crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                crpReport.SetParameterValue("Address", dt.Rows[0]["ADDRESS1"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = crpReport;
                _formReport.ShowDialog();
            }
            else if (rdbDate.Checked)
            {
                ds = _rptSaleCtl.PrintDailySalesReportDateWise(int.Parse(drpDistributor.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),
                    int.Parse(SessionClass.UserID.ToString()), 1);

                var crpReport = new CORNBusinessLayer.Reports.CrpDateDSR();
                crpReport.SetDataSource(ds);
                crpReport.Refresh();
                crpReport.SetParameterValue("Location", drpDistributor.Text);
                crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
                crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
                crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                crpReport.SetParameterValue("Address", dt.Rows[0]["ADDRESS1"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = crpReport;
                _formReport.ShowDialog();

            }
            else if (rdbCashier.Checked)
            {
                ds = _rptSaleCtl.SelectSalePersonDSR(int.Parse(drpDistributor.SelectedValue.ToString()),
                   DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),
                   int.Parse(drpCashier.SelectedValue.ToString()), 1);

                var crpReport = new CORNBusinessLayer.Reports.CrpLocationDSR();
                crpReport.SetDataSource(ds);
                crpReport.Refresh();
                crpReport.SetParameterValue("Location", drpDistributor.Text);
                crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
                crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
                crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                crpReport.SetParameterValue("Address", dt.Rows[0]["ADDRESS1"].ToString());


                CrystalDecisions.CrystalReports.Engine.TextObject txtQuotationNum = ((CrystalDecisions.CrystalReports.Engine.TextObject)crpReport.ReportDefinition.Sections["Section2"].ReportObjects["Text8"]);
                txtQuotationNum.Text = "Cashier";


                CrystalDecisions.CrystalReports.Engine.TextObject txtQuotationNum1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)crpReport.ReportDefinition.Sections["Section2"].ReportObjects["Text5"]);
                txtQuotationNum1.Text = "Cashier wise Daily Sale";

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = crpReport;
                _formReport.ShowDialog();
            }
            btnView.Text = "View";
            btnView.Enabled = true;
        }

        private void FormReportDailySale_Load(object sender, EventArgs e)
        {
            txtStartDate.Text = SessionClass.CurrentWorkDate.ToString();
            txtStartDate.Text = SessionClass.CurrentWorkDate.ToString();
            LoadAssingned();
            LoadUser();
            Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }

        private void FormReportDailySale_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 240, 115);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void rdbCashier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCashier.Checked)
            {
                drpCashier.Enabled = true;
            }
            else
            {
                drpCashier.Enabled = false;
            }
        }

        private void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUser();
        }
    }
}
