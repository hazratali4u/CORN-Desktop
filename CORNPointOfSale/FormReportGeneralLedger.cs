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
    public partial class FormReportGeneralLedger : Form
    {
        public FormReportGeneralLedger()
        {
            InitializeComponent();
        }

        private void FormReportGeneralLedger_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
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
        /// Loads Accont Heads To Account ListBox
        /// </summary>
        private void LoadAccountDetail()
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
            //clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
            DrpAccountHead.DataSource = dtHead;
            DrpAccountHead.DisplayMember = "ACCOUNT_HEAD";
            DrpAccountHead.ValueMember = "ACCOUNT_HEAD";
            SessionClass.dt = dtHead;
        }

        /// <summary>
        /// Shows General Ledger in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            int _rbtnValue = 0;
            if (rbtnPostedLedger.Checked)
            {
                _rbtnValue = 1;
            }
            DataTable dtHead = (DataTable)SessionClass.dt;
            DataRow[] foundRows = dtHead.Select("ACCOUNT_HEAD  = '" + DrpAccountHead.Text + "'");
            DocumentPrintController DPrint = new DocumentPrintController();
            RptAccountController RptAccountCtl = new RptAccountController();

            DataSet ds = null;

            if (foundRows.Length > 0)
            {
                long AccountHeadID = long.Parse(foundRows[0]["ACCOUNT_HEAD_ID"].ToString());

                DataControl dc = new DataControl();

                ds = RptAccountCtl.GeneralLedger_View(Constants.IntNullValue, AccountHeadID, int.Parse(drpDistributor.SelectedValue.ToString()),
                          DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), _rbtnValue);

                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                decimal OpeningValue = RptAccountCtl.GeneralLedgerOpening(Constants.IntNullValue, AccountHeadID, int.Parse(drpDistributor.SelectedValue.ToString()),
                          DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), _rbtnValue);

                CORNBusinessLayer.Reports.CrpLedgerView CrpReport = new CORNBusinessLayer.Reports.CrpLedgerView();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
                CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
                CrpReport.SetParameterValue("Location", drpDistributor.Text);
                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("OpeningValue", OpeningValue.ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
        }

        private void FormReportGeneralLedger_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 246, 120);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
