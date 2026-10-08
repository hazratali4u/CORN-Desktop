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
    public partial class FormReportUserLoginHistory : Form
    {
        public FormReportUserLoginHistory()
        {
            InitializeComponent();
        }

        private void FormReportUserLoginHistory_Load(object sender, EventArgs e)
        {
            txtStartDate.Value = System.DateTime.Now;
            txtEndDate.Value = System.DateTime.Now;
            LoadUsers();
        }

        /// <summary>
        /// Loads Users To User Combo
        /// </summary>
        private void LoadUsers()
        {
            UserController UserController = new UserController();
            DataTable m_dt = UserController.SelectAllUser();
            ddlUser.DataSource = USER_ALL(m_dt);
            ddlUser.DisplayMember = "USER_NAME";
            ddlUser.ValueMember = "USER_ID";
        }
         public DataTable USER_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["USER_ID"] = Constants.IntNullValue;
            dr["USER_NAME"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }

        /// <summary>
        /// Shows User Login History in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnPDF_Click(object sender, EventArgs e)
        {
            DocumentPrintController mController = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();

            CORNBusinessLayer.Reports.CrpUserLoginDetail CrpReport = new CORNBusinessLayer.Reports.CrpUserLoginDetail();

            DataTable dt = mController.SelectReportTitle(Constants.IntNullValue);

            DataSet ds = RptSaleCtl.GetUserLoginDetail(DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), Convert.ToInt32(ddlUser.SelectedValue), Convert.ToInt64(SessionClass.User_Log_ID));

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();


            CrpReport.SetParameterValue("FromDate", txtStartDate.Text);
            CrpReport.SetParameterValue("ToDate", txtEndDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("ReportFor", ddlUser.Text);
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
        }

        private void FormReportUserLoginHistory_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 85);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
