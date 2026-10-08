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
    public partial class FormReportCustomerMonthlyReport : Form
    {
        public FormReportCustomerMonthlyReport()
        {
            InitializeComponent();
        }

        private void FormReportCustomerMonthlyReport_Load(object sender, EventArgs e)
        {
            this.ReportType();
            this.LoadDistributor();
            this.LoadPrincipal();
            //  this.LoadArea();
            // this.LoadSalesForce();
            //  this.LoadChannelType();
            this.LoadCategory();
            this.LoadSKU();

            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartdate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        public void ReportType()
        {
            DrpReportType.Items.Add("Sale");
            DrpReportType.Items.Add("Sale Return");
            DrpReportType.Items.Add("Scheme");
            DrpReportType.SelectedIndex = 0;
        }
        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void LoadPrincipal()
        {
            //SKUPriceDetailController PController = new SKUPriceDetailController();
            //DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            //clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
        }

        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = dt;
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        /// <summary>
        /// Loads Routes To Route Combo
        /// </summary>
        //private void LoadArea()
        //{
        //    if (drpDistributor.Items.Count > 0)
        //    {
        //        DrpRoute.Items.Clear();
        //        DistributorAreaController mController = new DistributorAreaController();
        //        DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
        //        DrpRoute.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        //        clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6);
        //    }
        //    else
        //    {
        //        DrpRoute.Items.Clear();
        //    }
        //}

        /// <summary>
        /// Loads Channel Types To ChannelType Combo
        /// </summary>
        //private void LoadChannelType()
        //{
        //    SLASHCodesController mController = new SLASHCodesController();
        //    DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        //    drpChannelType.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        //    clsWebFormUtil.FillDropDownList(drpChannelType, dt, 0, 2);

        //}

        /// <summary>
        /// Loads Categoreis To Category Combo
        /// </summary>
        private void LoadCategory()
        {
            DrpCategory.DataSource = null;
            DrpCategory.Items.Clear();

            SkuHierarchyController mSkuHieController = new SkuHierarchyController();
            DataTable dtDist = mSkuHieController.SelectDTSkuHierarchy01(2, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            DrpCategory.DataSource = Category_ALL(dtDist);
            DrpCategory.DisplayMember = "SKU_HIE_NAME";
            DrpCategory.ValueMember = "SKU_HIE_ID";
        }
         public DataTable Category_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["SKU_HIE_ID"] = Constants.IntNullValue;
            dr["SKU_HIE_NAME"] = "All";
            dt.Rows.InsertAt(dr,0);
            return dt;
        }
        /// <summary>
        /// Loads Routes And Sale Forces
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  this.LoadArea();
            //  this.LoadSalesForce();
        }

        /// <summary>
        /// Loads Sale Forces, Categories And SKUS
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  this.LoadSalesForce();
            this.LoadCategory();
            this.LoadSKU();
        }

        ///// <summary>
        ///// Loads Sale Forces To SaleForce Combo
        ///// </summary>
        //protected void LoadSalesForce()
        //{
        //    SaleForceController ds = new SaleForceController();
        //    DataTable dt = ds.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), Convert.ToInt32(DrpRoute.SelectedValue), int.Parse(this.Session["CompanyId"].ToString()), Convert.ToInt32(DrpPrincipal.SelectedValue));
        //    if (dt.Rows.Count > 0)
        //    {
        //        this.drpSaleForce.Items.Clear();
        //        this.drpSaleForce.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        //        clsWebFormUtil.FillDropDownList(this.drpSaleForce, dt, "USER_ID", "USER_NAME");
        //    }
        //    else
        //    {
        //        this.drpSaleForce.Items.Clear();
        //    }
        //}

        /// <summary>
        /// Loads SKUS To SKU Combo
        /// </summary>
        private void LoadSKU()
        {
            int _catagorySelectedValue = Constants.IntNullValue;
            if (DrpCategory.DisplayMember != "SKU_HIE_NAME" || DrpCategory.ValueMember != "SKU_HIE_ID")
            {
                return;
            }
            try
            {
                _catagorySelectedValue = Convert.ToInt32(DrpCategory.SelectedValue.ToString());
            }
            catch (Exception)
            {
            }

            DrpSKU.DataSource = null;
            SkuController mSKUController = new SkuController();
            DataTable m_SKUDt = mSKUController.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, _catagorySelectedValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));

            DrpSKU.DataSource = SKUS_ALL(m_SKUDt);
            DrpSKU.DisplayMember = "SKUDETAIL";
            DrpSKU.ValueMember = "SKU_ID";
        }
        public DataTable SKUS_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["SKU_ID"] = Constants.IntNullValue;
            dr["SKUDETAIL"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Loads SKUS
        /// </summary>
        protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSKU();
        }

        /// <summary>
        /// Loads Sale Forces
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  this.LoadSalesForce();
        }

        /// <summary>
        /// Shows  Customer Monthly Reports Either in PDF Or in Excel
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
        {
            btnViewPDF.Text = "Wait...";
            btnViewPDF.Enabled = false;
            DocumentPrintController DPrint = new DocumentPrintController();
            RptCustomerController RptCustomerCtl = new RptCustomerController();

            DataControl dc = new DataControl();
            DataSet ds = RptCustomerCtl.SelectCustomerMonthlySales(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, DateTime.Parse(txtStartdate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpCategory.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, DrpReportType.SelectedIndex, Convert.ToInt32(DrpSKU.SelectedValue), Constants.IntNullValue);

            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.CrpCustomerMonthlySales CrpReport = new CORNBusinessLayer.Reports.CrpCustomerMonthlySales();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Distributor_Name", drpDistributor.Text);
            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartdate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            CrpReport.SetParameterValue("Principal", "All");
            //   CrpReport.SetParameterValue("Area", DrpRoute.SelectedItem.Text);
            // CrpReport.SetParameterValue("ChannelType", drpChannelType.SelectedItem.Text);
            CrpReport.SetParameterValue("ReportType", "Customer Monthly " + DrpReportType.Text + " Report");
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            //CrpReport.SetParameterValue("OrderBooker","");
            CrpReport.SetParameterValue("SKU", DrpSKU.Text);
            CrpReport.SetParameterValue("Category", DrpCategory.Text);

            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnViewPDF.Text = "View";
            btnViewPDF.Enabled = true;
        }

        /// <summary>
        /// Shows  Customer Monthly Reports in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
        }

        private void FormReportCustomerMonthlyReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 240, 130);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
