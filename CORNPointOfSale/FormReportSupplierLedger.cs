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
using CORNBusinessLayer.Reports;

namespace CORNPointOfSale
{
    public partial class FormReportSupplierLedger : Form
    {
        public FormReportSupplierLedger()
        {
            InitializeComponent();
        }

        private void FormReportSupplierLedger_Load(object sender, EventArgs e)
        {
            LoadPrincipal();
            LoadDistributor();

            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        private void LoadPrincipal()
        {
            SkuHierarchyController _mController = new SkuHierarchyController();
            DataTable m_dt = _mController.SelectPrincipal(Constants.SKUPrincipal, SessionClass.CompanyID);
            DrpPrincipal.DataSource = m_dt;
            DrpPrincipal.DisplayMember = "SKU_HIE_NAME";
            DrpPrincipal.ValueMember = "SKU_HIE_ID";
        }

        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();

            DataTable dt3 = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            //DataTable dt2 = dt3.Clone();
            //DataRow[] dr = dt3.Select("SUBZONE_ID = 5");

            //if (dr.Length > 0)
            //{
            //    for (int k = 0; k < dr.Length; k++)
            //    {
            //        dt2.ImportRow(dr[k]);
            //    }
            //}
            //clsWebFormUtil.FillDropDownList(drpDistributor, dt2, 0, 2, true);
            drpDistributor.DataSource = dt3;
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";

           // Session.Add("DistributorId", int.Parse(drpDistributor.SelectedValue.ToString()));
        }
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            DataTable dtHead = (DataTable)ClassSession.dtHead;
            DocumentPrintController DPrint = new DocumentPrintController();
            RptCustomerController RptCustCtl = new RptCustomerController();

            DataSet ds = null;

            {

                //DataControl dc = new DataControl();
                ds = RptCustCtl.GetVendoerLedger(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()),
                          DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));


                CrpVendorLedger CrpReport = new CrpVendorLedger();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
                CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
                CrpReport.SetParameterValue("Location", drpDistributor.Text);
                CrpReport.SetParameterValue("Principal", DrpPrincipal.Text);
                CrpReport.SetParameterValue("Op_Balance", LoadVendoerOpBalance());
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
        }
        private decimal LoadVendoerOpBalance()
        {
            if (drpDistributor.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
            {
                RptCustomerController mController = new RptCustomerController();
                DataTable dt = mController.GetVendoerOpening(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()),
                          DateTime.Parse(txtStartDate.Text + " 00:00:00"));
                return decimal.Parse(dt.Rows[0][0].ToString());
            }
            return 0;
        }

        private void FormReportSupplierLedger_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 240, 110);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
