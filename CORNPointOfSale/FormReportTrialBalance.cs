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
    public partial class FormReportTrialBalance : Form
    {
        public FormReportTrialBalance()
        {
            InitializeComponent();
        }

        private void FormReportTrialBalance_Load(object sender, EventArgs e)
        {
            this.LoadLevel();
            this.LoadDistributor();
            this.LoadAccount();
            this.LoadAccountDetail();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        public void LoadLevel()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("value", typeof(int));
            dt.Rows.Add("Level 1", 1);
            dt.Rows.Add("Level 2", 2);
            dt.Rows.Add("Level 3", 3);
            dt.Rows.Add("Level 4", 4);
            DrpLevel.DataSource = dt;
            DrpLevel.DisplayMember = "name";
            DrpLevel.ValueMember = "value";
        }
       
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
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
        /// Loads Main Account Heads To Main Account Combo
        /// </summary>
        private void LoadAccount()
        {
            AccountHeadController MController = new AccountHeadController();
            DataTable dt = MController.SelectAccountHead(Constants.AC_MainTypeId, Constants.LongNullValue);
            DrpMainAccount.DataSource = MainAccount_ALL(dt);
            DrpMainAccount.DisplayMember = "ACCOUNT_DETAIL";
            DrpMainAccount.ValueMember = "ACCOUNT_HEAD_ID";
        }
        public DataTable MainAccount_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["ACCOUNT_HEAD_ID"] = Constants.IntNullValue;
            dr["ACCOUNT_DETAIL"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Loads Account Heads To Account ListBox
        /// </summary>
        private void LoadAccountDetail()
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
            DataView dv = new DataView(dtHead);
            dv.Sort = "ACCOUNT_DETAIL";
            dtHead = dv.ToTable();
            //clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_DETAIL", "ACCOUNT_DETAIL", true);
            txttoAccount.DataSource = dtHead;
            txttoAccount.DisplayMember = "ACCOUNT_DETAIL";
            txttoAccount.ValueMember = "ACCOUNT_DETAIL";
            SessionClass.dt = dtHead;
            LoadAccountDetail2();
        }
        public void LoadAccountDetail2()
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
            DataView dv = new DataView(dtHead);
            dv.Sort = "ACCOUNT_DETAIL";
            dtHead = dv.ToTable();
            //clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_DETAIL", "ACCOUNT_DETAIL", true);
            txtFromAccount.DataSource = dtHead;
            txtFromAccount.DisplayMember = "ACCOUNT_DETAIL";
            txtFromAccount.ValueMember = "ACCOUNT_DETAIL";
        }

        /// <summary>
        /// Shows Trial Balance in PDF
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
            DocumentPrintController DPrint = new DocumentPrintController();
            RptAccountController RptAccountCtl = new RptAccountController();

            DataControl dc = new DataControl();

            DataSet ds = RptAccountCtl.TrialBalance(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpMainAccount.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpLevel.SelectedValue.ToString()), txtFromAccount.Text.Substring(0, 10), txttoAccount.Text.Substring(0, 10), _rbtnValue);

            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.CrpTrialBalance CrpReport = new CORNBusinessLayer.Reports.CrpTrialBalance();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("From_Date", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("Location", drpDistributor.Text);
            CrpReport.SetParameterValue("Principal", "All");

            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();

        }


        /// <summary>
        /// Checks All Account Heads In Account Head ListBox
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ChbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllAccounts.Checked == true)
            {
                txtFromAccount.DataSource = null;
                txttoAccount.DataSource = null;
                txtFromAccount.Items.Clear();
                txttoAccount.Items.Clear();
                txtFromAccount.Items.Add("0000000000");
                txttoAccount.Items.Add("9999999999");
                txtFromAccount.SelectedIndex = 0;
                txttoAccount.SelectedIndex = 0;
                txtFromAccount.Enabled = false;
                txttoAccount.Enabled = false;
            }
            else
            {
                LoadAccountDetail();
                txtFromAccount.Enabled = true;
                txttoAccount.Enabled = true;
            }
        }

        private void FormReportTrialBalance_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 250, 160);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
