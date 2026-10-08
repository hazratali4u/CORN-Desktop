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
    public partial class FormReportItemWiseBranchSale : Form
    {
        public FormReportItemWiseBranchSale()
        {
            InitializeComponent();
        }

        private void FormReportItemWiseBranchSale_Load(object sender, EventArgs e)
        {
            this.DistributorType();
            this.LoadAssingned();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }

        /// <summary>
        /// Loads Location Types
        /// </summary>
        private void DistributorType()
        {
            DistributorController dController = new DistributorController();
            DataTable dt = dController.SelectDistributorTypeInfo(Constants.IntNullValue);
            ddDistributorType.DataSource = dt;
            ddDistributorType.ValueMember = "DISTRIBUTOR_TYPE_ID";
            ddDistributorType.DisplayMember = "TYPENAME";
            if (ddDistributorType.Items.Count > 0)
            {
                ddDistributorType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Loads User Assigned Locations To Location Combo
        /// </summary>
        private void LoadAssingned()
        {
            if (ddDistributorType.DisplayMember == "TYPENAME" && ddDistributorType.ValueMember == "DISTRIBUTOR_TYPE_ID")
            {
                drpDistributor.DataSource = null;
                drpDistributor.Items.Clear();
                UserController mUserController = new UserController();
                DataTable dt = mUserController.SelectUserAssignment(int.Parse(SessionClass.UserID.ToString()), int.Parse(ddDistributorType.SelectedValue.ToString()), 1, int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
                drpDistributor.DisplayMember = "distributor_name";
                drpDistributor.ValueMember = "distributor_id";
                if (drpDistributor.Items.Count > 0)
                {
                    drpDistributor.SelectedIndex = 0;
                }
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
        /// <summary>
        /// Shows SKU Wise Branch Sales in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataSet ds = RptSaleCtl.GetDistributorReconcilation(int.Parse(this.ddDistributorType.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(SessionClass.UserID.ToString()));
            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            CORNBusinessLayer.Reports.CrpDistributorReconcilation1 CrpReport = new CORNBusinessLayer.Reports.CrpDistributorReconcilation1();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();
            CrpReport.SetParameterValue("FromDate", txtStartDate.Text);
            CrpReport.SetParameterValue("ToDate", txtEndDate.Text);
            CrpReport.SetParameterValue("Principal", "All");
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnView.Text = "View";
            btnView.Enabled = true;
        }
        protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAssingned();
        }

        private void FormReportItemWiseBranchSale_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 235, 105);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
