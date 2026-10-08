using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormReportCustomerLedger : Form
    {
        public FormReportCustomerLedger()
        {
            InitializeComponent();
        }

        private void FormReportCustomerLedger_Load(object sender, EventArgs e)
        {
            //this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();

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
        /// Loads Routes To Route Combo
        /// </summary>
        private void LoadArea()
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            DrpRoute.DataSource = dt;
            DrpRoute.DisplayMember = "AREA_NAME";
            DrpRoute.ValueMember = "AREA_ID";
        }

        /// <summary>
        /// Loads Customers To Customer Combo
        /// </summary>
        private void LoadData()
        {
            if (drpDistributor.Items.Count > 0)
            {
                CustomerDataController mController = new CustomerDataController();
                DataTable dt = mController.SelectAllCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
                DrpCustomer.DataSource = dt;
                DrpCustomer.DisplayMember = "CUSTOMER_NAME";
                DrpCustomer.ValueMember = "CUSTOMER_ID";
            }
        }

        /// <summary>
        /// Gets Customer Opening Balance
        /// </summary>
        private decimal LoadCustomerOpBalance()
        {
            if (drpDistributor.Items.Count > 0 && DrpCustomer.Items.Count > 0)
            {
                CustomerDataController mController = new CustomerDataController();
                DataTable dt = mController.SelectPrincipalCustomerOpBalance(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), Constants.IntNullValue);
                return decimal.Parse(dt.Rows[0][0].ToString());
            }
            return 0;
        }

        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void LoadPrincipal()
        {
            //SKUPriceDetailController PController = new SKUPriceDetailController();
            //DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            //DrpPrincipal.DataSource = m_dt;
            //DrpPrincipal.DisplayMember = "Company_Name";
            //DrpPrincipal.ValueMember = "Company_Id";
        }

        /// <summary>
        /// Loads Routes And Customers
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistributor.DisplayMember == "DISTRIBUTOR_NAME" && drpDistributor.ValueMember == "DISTRIBUTOR_ID")
            {
                this.LoadArea();
                this.LoadData(); 
            }
        }

        /// <summary>
        /// Loads Customers
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Shows Customer Ledger Either in PDF or in Excel
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
        {
            btnViewPDF.Text = "Wait...";
            btnViewPDF.Enabled = false;
            DataControl dc = new DataControl();
            CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
            RptCustomerController RptCustomerCtl = new RptCustomerController();
            DataSet ds;
            ds = RptCustomerCtl.CustomerLedger_View(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()),
                      DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.CrpCustomerLedger CrpReport = new CORNBusinessLayer.Reports.CrpCustomerLedger();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("Location", drpDistributor.Text);
            CrpReport.SetParameterValue("Customer", DrpCustomer.Text);
            CrpReport.SetParameterValue("Op_Balance", LoadCustomerOpBalance());
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnViewPDF.Text = "View";
            btnViewPDF.Enabled = true;
        }

        /// <summary>
        /// Shows Customer Ledger Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        private void FormReportCustomerLedger_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 246, 110);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
