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
    public partial class FormReportChartOfAccount : Form
    {
        public FormReportChartOfAccount()
        {
            InitializeComponent();
        }

        private void FormReportChartOfAccount_Load(object sender, EventArgs e)
        {
            DrpAccountCategory.Items.Add("Balance Sheet Account");
            DrpAccountCategory.Items.Add("Income Statment Account");
            DrpAccountCategory.SelectedIndex = 0;
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetDetailAccountType();
            
        }

        /// <summary>
        /// Loads Account Types To AccountType Combo
        /// </summary>
        private void GetAccountType()
        {
            DrpMainType.DataSource = null;
            DrpMainType.Items.Clear();
            AccountHeadController MController = new AccountHeadController();
            DataTable dt = MController.GetAccountHead(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_MainTypeId);
            DrpMainType.DataSource = DrpMainType_ALL(dt);
            DrpMainType.DisplayMember = "Detail";
            DrpMainType.ValueMember = "Account_TypeId";
        }
        public DataTable DrpMainType_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Account_typeid"] = Constants.IntNullValue;
            dr["Detail"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads Account Sub Types To SubType Combo
        /// </summary>
        private void GetSubAccountType()
        {
            if (DrpMainType.DisplayMember == "Detail" && DrpMainType.ValueMember == "Account_TypeId")
            {

                DrpSubType.DataSource = null;
                DrpSubType.Items.Clear();
                AccountHeadController MController = new AccountHeadController();
                if (DrpMainType.Items.Count > 0)
                {
                    DataTable dt = MController.GetAccountHead(int.Parse(DrpMainType.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_SubTypeId);
                    DrpSubType.DataSource = SubAccountType(dt);
                    DrpSubType.DisplayMember = "Detail";
                    DrpSubType.ValueMember = "AccountSub_TypeId";
                }
            }
        }
         public DataTable SubAccountType(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["AccountSub_TypeId"] = Constants.IntNullValue;
            dr["Detail"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads Account Detail Types To Detail Type Combo
        /// </summary>
        private void GetDetailAccountType()
        {
            if (DrpSubType.DisplayMember == "Detail" && DrpSubType.ValueMember == "AccountSub_TypeId" && DrpSubType.SelectedIndex >= 0)
            {
                DrpDetailType.DataSource = null;
                DrpDetailType.Items.Clear();

                AccountHeadController MController = new AccountHeadController();
                if (DrpSubType.Items.Count > 0)
                {
                    DataTable dt = MController.GetAccountHead(int.Parse(DrpMainType.SelectedValue.ToString()), int.Parse(DrpSubType.SelectedValue.ToString()), Constants.IntNullValue, DrpAccountCategory.SelectedIndex, Constants.AC_DetailTypeId);
                    DrpDetailType.DataSource = AccountDetail_All(dt);
                    DrpDetailType.DisplayMember = "Detail";
                    DrpDetailType.ValueMember = "AccountDetail_TypeId";
                } 
            }
        }
         public DataTable AccountDetail_All(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["AccountDetail_TypeID"] = Constants.IntNullValue;
            dr["Detail"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }

        /// <summary>
        /// Shows Chart of Account in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            DocumentPrintController DPrint = new DocumentPrintController();
            RptAccountController RptAccountCtl = new RptAccountController();

            DataSet ds = RptAccountCtl.SelectRptChartofAccount(DrpAccountCategory.SelectedIndex, int.Parse(DrpMainType.SelectedValue.ToString()), int.Parse(DrpSubType.SelectedValue.ToString()), int.Parse(DrpDetailType.SelectedValue.ToString()));
            DataTable dt = DPrint.SelectReportTitle(Constants.IntNullValue);

            CORNBusinessLayer.Reports.CrpchartOfAccunt CrpReport = new CORNBusinessLayer.Reports.CrpchartOfAccunt();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());

            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
        }

        /// <summary>
        /// Loads Account Detail Types
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetDetailAccountType();
        }

        /// <summary>
        /// Loads Account Types, Sub Types And Detail Types
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpAccountCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetDetailAccountType();
        }

        private void FormReportChartOfAccount_Resize(object sender, EventArgs e)
        {
            int _width = this.Width;
            int a = _width / 2;
            int b = a - 238;
            Panel1.Location = new Point(b, 208);
        }
    }
}
