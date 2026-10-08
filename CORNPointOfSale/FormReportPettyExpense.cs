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
    public partial class FormReportPettyExpense : Form
    {
        public FormReportPettyExpense()
        {
            InitializeComponent();
        }

        private void FormReportPettyExpense_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadAccountParent();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }

        /// <summary>
        /// Loads Parent Accounts To Account Combo
        /// </summary>
        private void LoadAccountParent()
        {
            DrpMasterHead.DataSource = null;
            CORNCommon.Classes.Configuration.GetAccountHead();
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_DetailTypeId, long.Parse(CORNCommon.Classes.Configuration.ExpensDefaultType));
            DrpMasterHead.DataSource = ACCOUNTPARENT_ALL(dt);
            DrpMasterHead.DisplayMember = "ACCOUNT_NAME";
            DrpMasterHead.ValueMember = "ACCOUNT_HEAD_ID";
        }
        public DataTable ACCOUNTPARENT_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["ACCOUNT_HEAD_ID"] = Constants.IntNullValue;
            dr["ACCOUNT_NAME"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            drpDistributor.DataSource = null;
            drpDistributor.Items.Clear();
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            if (rbtnCash.Checked)
            {
                drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
            }
            else
            {
                drpDistributor.DataSource = dt; 
            }
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
        /// Shows Petty Expense Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            DocumentPrintController mController = new DocumentPrintController();
            RptAccountController RptAccountCtl = new RptAccountController();

            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            if (rbtnExpense.Checked)
            {
                CORNBusinessLayer.Reports.CrpPetyCashSummary CrpReport = new CORNBusinessLayer.Reports.CrpPetyCashSummary();
                DataSet ds = RptAccountCtl.SelectPetyCashStatment(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(SessionClass.UserID.ToString()), int.Parse(DrpMasterHead.SelectedValue.ToString()));
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("Distributor", drpDistributor.Text);
                CrpReport.SetParameterValue("FROM_DATE", txtStartDate.Text);
                CrpReport.SetParameterValue("TO_DATE", txtEndDate.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            else
            {
                CORNBusinessLayer.Reports.CrpPettyCaahSummery CrpReport = new CORNBusinessLayer.Reports.CrpPettyCaahSummery();

                DataSet ds = RptAccountCtl.SelectPetyCashSummary(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(SessionClass.UserID.ToString()));
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("FROM_DATE", txtStartDate.Text);
                CrpReport.SetParameterValue("TO_DATE", txtEndDate.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
        }
        private void rbtnExpense_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDistributor();
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDistributor();
        }

        private void FormReportPettyExpense_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 235, 130);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
