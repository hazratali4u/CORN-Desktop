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
    public partial class FormReportGLlogDetail : Form
    {
        public FormReportGLlogDetail()
        {
            InitializeComponent();
        }

        private void FormReportGLlogDetail_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadUser();
            this.VoucherType();
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
        /// Loads Users To User Combo
        /// </summary>
        private void LoadUser()
        {
            DrpUser.DataSource = null;
            if (SessionClass.RoleID.ToString() == "3")
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("value", typeof(string));
                dt.Rows.Add(Convert.ToString(SessionClass.UserName),Convert.ToString(SessionClass.UserID));
                DrpUser.DataSource = dt;
                DrpUser.DisplayMember = "name";
                DrpUser.ValueMember = "value";
            }
            else
            {
                Distributor_UserController mController = new Distributor_UserController();
                DataTable dt = mController.SelectGLUser();
                DrpUser.DataSource = USER_ALL(dt);
                DrpUser.DisplayMember = "user_name";
                DrpUser.ValueMember = "user_id";
            }
        }
        public DataTable USER_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["user_id"] = Constants.IntNullValue;
            dr["user_name"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Loads Voucher Types To VoucherType Combo
        /// </summary>
        private void VoucherType()
        {
            LedgerController LController = new LedgerController();
            DataTable dt = LController.SelectVoucherType(int.Parse(SessionClass.UserID.ToString()));
            DrpVoucherType.DataSource = dt;
            DrpVoucherType.DisplayMember = "slash_desc";
            DrpVoucherType.ValueMember = "voucher_type_id";
        }

        /// <summary>
        /// Shows GL Log Detail in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        /// <summary>
        /// Shows GL Log Detail Either in PDF or In Excel
        /// </summary>
        /// <param name="p_Report_Type">Type</param>
        private void ShowReport(int p_Report_Type)
        {
            int _rbtnValue = 0;
            if (rbtnVoucherDate.Checked)
            {
                _rbtnValue = 1;
            }
            DocumentPrintController DPrint = new DocumentPrintController();
            RptAccountController RptAccountCtl = new RptAccountController();

            DataSet ds = null;
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            DataControl dc = new DataControl();
            ds = RptAccountCtl.SelectGLLog_VoucherDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(DrpUser.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), _rbtnValue);

            CORNBusinessLayer.Reports.CrpPrintGLLogVoucherDetail CrpReport = new CORNBusinessLayer.Reports.CrpPrintGLLogVoucherDetail();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Location", drpDistributor.Text);
            CrpReport.SetParameterValue("VoucherType", DrpVoucherType.Text);
            CrpReport.SetParameterValue("User", DrpUser.Text);


            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
        }

        private void FormReportGLlogDetail_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 240, 140);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
