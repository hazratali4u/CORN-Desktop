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
    public partial class FormReportCustomerInvoiceWiseSale : Form
    {
        public FormReportCustomerInvoiceWiseSale()
        {
            InitializeComponent();
        }

        private void FormReportCustomerInvoiceWiseSale_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadSearchType();
            this.txtStartDate.Value = System.DateTime.Today;
            this.txtEndDate.Value = System.DateTime.Today;
        }
        private void LoadSearchType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Rows.Add("Customer Name", "CUSTOMER_NAME");
            dt.Rows.Add("Address", "ADDRESS");
            dt.Rows.Add("Location", "Distributor_NAME");
            dt.Rows.Add("Route Name", "AREA_NAME");
            dt.Rows.Add("Channel Type", "SLASH_DESC");
            dt.Rows.Add("Customer Code", "CUSTOMER_CODE");
            ddSearchType.DataSource = dt;
            ddSearchType.DisplayMember = "Display";
            ddSearchType.ValueMember = "value";
        }
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            drpDistributor.DataSource = null;
            drpDistributor.Items.Clear();
            if (rbtnIndivisual.Checked)
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
            }
            else
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = dt;
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
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

        private void ShowReport(int p_Report_Type)
        {
            string CustomerId = "0";
            string DistributorId = "0";

            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            RptCustomerController RptCustomerCtl = new RptCustomerController();

            if (rbtnAll.Checked)
            {
                btnViewPDF.Text = "Wait...";
                btnViewPDF.Enabled = false;
                DataSet ds = RptCustomerCtl.SelectInvoiceDetail(SessionClass.UserID, "", int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 3);

                DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

                //CORNBusinessLayer.Reports.CrpBillCustomerWiseReport CrpReport = new CORNBusinessLayer.Reports.CrpBillCustomerWiseReport();
                CORNBusinessLayer.Reports.CrpBillInvoiceWiseReport CrpReport = new CORNBusinessLayer.Reports.CrpBillInvoiceWiseReport();

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                // CrpReport.SetParameterValue("PRINCIPAL", "All");
                CrpReport.SetParameterValue("FROM_DATE", txtStartDate.Text);
                CrpReport.SetParameterValue("TO_DATE", txtEndDate.Text);
                CrpReport.SetParameterValue("CompanyName", drpDistributor.SelectedText);

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
                btnViewPDF.Text = "View";
                btnViewPDF.Enabled = true;
            }
            else
            {
                int _rows = Grid_users.Rows.Count;
                for (int i = 0; i < _rows; i++)
                {
                    // CheckBox chbSelect = (CheckBox)(dr.Cells[0].FindControl("ChbCustomer"));
                    if (Convert.ToBoolean(Grid_users.Rows[i].Cells["Select"].Value))
                    {
                        CustomerId = CustomerId + "," + Grid_users.Rows[i].Cells["CUSTOMER_ID"].Value.ToString();
                        // DistributorId = DistributorId + "," + Grid_users.Rows[i].Cells["DISTRIBUTOR_ID"].Value.ToString();
                    }
                }
                btnViewPDF.Text = "Wait...";
                btnViewPDF.Enabled = false;
                // DataSet ds = RptCustomerCtl.SelectBillCustomerDetail(Constants.IntNullValue, CustomerId, DistributorId, DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1);
                DataSet ds = RptCustomerCtl.SelectInvoiceDetail(SessionClass.UserID, CustomerId, int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1);

                DataTable dt = mDocumentPrntControl.SelectReportTitle(Constants.IntNullValue);

                //  CORNBusinessLayer.Reports.CrpBillCustomerWiseReport CrpReport = new CORNBusinessLayer.Reports.CrpBillCustomerWiseReport();
                CORNBusinessLayer.Reports.CrpBillInvoiceWiseReport CrpReport = new CORNBusinessLayer.Reports.CrpBillInvoiceWiseReport();

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                // CrpReport.SetParameterValue("PRINCIPAL", "All");
                // CrpReport.SetParameterValue("FROM_DATE", txtStartDate.Text);
                // CrpReport.SetParameterValue("TO_DATE", txtEndDate.Text);
                // CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

                CrpReport.SetParameterValue("FROM_DATE", txtStartDate.Text);
                CrpReport.SetParameterValue("TO_DATE", txtEndDate.Text);
                CrpReport.SetParameterValue("CompanyName", drpDistributor.SelectedText);

                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
                btnViewPDF.Text = "Viwe";
                btnViewPDF.Enabled = true;
            }
        }


        protected void BtnViewPdf_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }


        protected void RblCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDistributor();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            ChkAll.Visible = true;
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.UspSelectCustomer(int.Parse(SessionClass.UserID.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), ddSearchType.SelectedValue.ToString(), txtSeach.Text);
            this.Grid_users.DataSource = dt;
            ArrangeGrid();
        }
        private void ArrangeGrid()
        {
            try
            {
                Grid_users.Columns.Remove("Select");
            }
            catch (Exception)
            { }
            Grid_users.Columns["Customer_id"].Visible = false;
            Grid_users.Columns["dISTRIBUTOR_id"].Visible = false;
            Grid_users.Columns["Area_Name"].Visible = false;

            Grid_users.Columns["CUSTOMER_CODE"].HeaderText = "Customer Code";
            Grid_users.Columns["CUSTOMER_NAME"].HeaderText = "Customer Name";
            Grid_users.Columns["DISTRIBUTOR_NAME"].HeaderText = "Distributor Name";
            Grid_users.Columns["ADDRESS"].HeaderText = "Address";

            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            Grid_users.Columns.Add(checkColumn);
            Grid_users.Columns["Select"].DisplayIndex = 0;
            Grid_users.Columns["SELECT"].HeaderText = "";

            Grid_users.Columns["ADDRESS"].Width = 480;
            Grid_users.Columns["Select"].Width = 50;
            Grid_users.Columns["CUSTOMER_CODE"].Width = 150;
            Grid_users.Columns["CUSTOMER_NAME"].Width = 150;
            Grid_users.Columns["DISTRIBUTOR_NAME"].Width = 150;

            foreach (DataGridViewColumn clms in Grid_users.Columns)
            {
                clms.ReadOnly = true;
            }
            Grid_users.Columns["Select"].ReadOnly = false;

        }
        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            RblCustomer_SelectedIndexChanged(null, null);
        }

        private void rbtnIndivisual_CheckedChanged(object sender, EventArgs e)
        {
            RblCustomer_SelectedIndexChanged(null, null);
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = Grid_users.Rows.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    Grid_users.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    Grid_users.Rows[i].Cells["Select"].Value = false;
                }
            }
        }

        private void FormReportCustomerInvoiceWiseSale_Resize(object sender, EventArgs e)
        {
            int _width = this.Width;
            int a = _width / 2;
            int b = a - 518;

            int _height = this.Height;
            int x = _height / 2;
            int y = x - 180;

            groupPanel1.Location = new Point(b, y);
        }
    }
}
