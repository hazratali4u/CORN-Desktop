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
    public partial class FormReportDepositSlipDetail : Form
    {
        public FormReportDepositSlipDetail()
        {
            InitializeComponent();
        }

        private void FormReportDepositSlipDetail_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadAccount();
            txtFromDate.Value = System.DateTime.Today;
            txtToDate.Value = System.DateTime.Today;
        }

        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        protected void LoadLocation()
        {
            try
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = dt;
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// Loads Account Heads To Account Combo
        /// </summary>
        protected void LoadAccount()
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, 43);
            drpAccount.DataSource = Account_ALL(dt);
            drpAccount.DisplayMember = "ACCOUNT_NAME";
            drpAccount.ValueMember = "ACCOUNT_HEAD_ID";
        }
        public DataTable Account_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["ACCOUNT_HEAD_ID"] = 0;
            dr["ACCOUNT_NAME"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Shows Deposit Slip Detail in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            try
            {
                CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                RptAccountController RptAccountCtl = new RptAccountController();

                string FromDate = null;
                string ToDate = null;
                CORNBusinessLayer.Reports.CrpBankDepositSlipDetail CrpReport = new CORNBusinessLayer.Reports.CrpBankDepositSlipDetail();
                DataSet ds = null;
                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
                FromDate = parsed_date_fromdate.ToShortDateString();
                ToDate = parsed_date_todate.ToShortDateString();

                ds = RptAccountCtl.BankDepositSlipDetail(0, int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 23:59:59"), Convert.ToInt32(this.drpAccount.SelectedValue.ToString()));
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("Branch", this.drpDistributor.Text);
                CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
                CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);
                CrpReport.SetParameterValue("Account", this.drpAccount.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormReportDepositSlipDetail_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 235, 110);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
