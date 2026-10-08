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
    public partial class FormReportDateWiseStockReport : Form
    {
        public FormReportDateWiseStockReport()
        {
            InitializeComponent();
        }

        private void FormReportDateWiseStockReport_Load(object sender, EventArgs e)
        {
            this.LoadTransactionType();
            this.LoadDistributor();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }

        private void LoadTransactionType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("value", typeof(int));
            dt.Rows.Add("Purchase", 2);
            dt.Rows.Add("Transfer Out", 5);
            dt.Rows.Add("Purchase Return", 3);
            dt.Rows.Add("Transfer In", 4);
            dt.Rows.Add("Damage", 6);
            //dt.Rows.Add("Opening Stock", 7);
            dt.Rows.Add("Short", 8);
            dt.Rows.Add("Excess", 9);
            DrpDocumentType.DataSource = dt;
            DrpDocumentType.DisplayMember = "name";
            DrpDocumentType.ValueMember = "value";
        }
        
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = dt;
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            btnViewPDF.Text = "Wait...";
            btnViewPDF.Enabled = false;
            DocumentPrintController DPrint = new DocumentPrintController();
            RptInventoryController RptInventoryCtl = new RptInventoryController();

            DataSet ds = null;
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            DataControl dc = new DataControl();
            int rbtnRateValue = 0;
            string rbtnRateText = "Trade Price";
            if (rbtnPurchase.Checked)
            {
                rbtnRateValue = 1;
                rbtnRateText = "Purchase Price";
            }
            ds = RptInventoryCtl.SelectPurchaseTransferStock(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpDocumentType.SelectedValue.ToString()), rbtnRateValue);

            CORNBusinessLayer.Reports.CrpDailyPurchaseTransfer CrpReport = new CORNBusinessLayer.Reports.CrpDailyPurchaseTransfer();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("PRINCIPAL", "All");
            CrpReport.SetParameterValue("LOCATION", drpDistributor.Text);
            CrpReport.SetParameterValue("ReportTitle", "Date Wise  " + DrpDocumentType.Text + " Report");
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Price", rbtnRateText);

           FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnViewPDF.Text = "View";
            btnViewPDF.Enabled = true;
        }

        private void FormReportDateWiseStockReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 245, 120);
            groupPanel1.Location = new Point(points[0],points[1]);
        }

    }
}
