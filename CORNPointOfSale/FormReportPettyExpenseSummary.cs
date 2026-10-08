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
    public partial class FormReportPettyExpenseSummary : Form
    {
        public FormReportPettyExpenseSummary()
        {
            InitializeComponent();
        }

        private void FormReportPettyExpenseSummary_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadAccountParent();
            this.LoadAccountHead();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtFromDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtToDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
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
        /// Loads Parent Account Heads To Parent Account Combo
        /// </summary>
        private void LoadAccountParent()
        {
            CORNCommon.Classes.Configuration.GetAccountHead();
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_DetailTypeId, long.Parse(CORNCommon.Classes.Configuration.ExpensDefaultType));
            DrpMasterHead.DataSource = dt;
            DrpMasterHead.DisplayMember = "ACCOUNT_NAME";
            DrpMasterHead.ValueMember = "ACCOUNT_HEAD_ID";
        }

        /// <summary>
        /// Loads Account Heaeds To Account Combo
        /// </summary>
        private void LoadAccountHead()
        {
            if (DrpMasterHead.Items.Count > 0)
            {
                AccountHeadController mAccountController = new AccountHeadController();
                DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(DrpMasterHead.SelectedValue.ToString()));
                LstAccountHead.DataSource = dt;
                LstAccountHead.DisplayMember = "ACCOUNT_NAME";
                LstAccountHead.ValueMember = "ACCOUNT_HEAD_ID";
            }
        }

        /// <summary>
        /// Loads Account Heads
        /// </summary>
        protected void DrpMasterHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAccountHead();
        }

        /// <summary>
        /// Shows Petty Expense Summary in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        /// <summary>
        /// Shows Petty Expense Summary Report Either in Excel or PDF
        /// </summary>
        /// <param name="p_ReportType"></param>
        private void ShowReport(int p_ReportType)
        {
            try
            {
                CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                RptAccountController RptAccountCtl = new RptAccountController();

                DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
                DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
                string FromDate = parsed_date_fromdate.ToShortDateString();
                string ToDate = parsed_date_todate.ToShortDateString();
                string Catagories_IDs = null;

                CORNBusinessLayer.Reports.CrpPrincipalWiseExp CrpReport = new CORNBusinessLayer.Reports.CrpPrincipalWiseExp();

                DataSet ds = null;

                for (int i = 0; i < LstAccountHead.Items.Count; i++)
                {
                    if (LstAccountHead.GetItemChecked(i))
                    {
                        DataRowView drV = (DataRowView)LstAccountHead.Items[i];
                        DataRow dr = drV.Row;
                        int _value = Convert.ToInt32(dr["ACCOUNT_HEAD_ID"].ToString());
                        Catagories_IDs += _value + ",";
                    }
                }

                ds = RptAccountCtl.PrincipalWiseSale(Constants.IntNullValue, Convert.ToInt32(this.drpDistributor.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 23:59:59"), Catagories_IDs, Constants.IntNullValue);
                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", "All");
                CrpReport.SetParameterValue("Distributor", this.drpDistributor.Text);
                CrpReport.SetParameterValue("From_date", this.txtFromDate.Text);
                CrpReport.SetParameterValue("To_Date", this.txtToDate.Text);
                CrpReport.SetParameterValue("ReportTitle", "Petty Expense Summary");
                CrpReport.SetParameterValue("AccountHead", DrpMasterHead.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void ChkAllAccountHead_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = LstAccountHead.Items.Count;
            if (ChkAllAccountHead.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    LstAccountHead.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    LstAccountHead.SetItemChecked(i, false);
                }
            }
        }

        private void FormReportPettyExpenseSummary_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 320, 160);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
