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
    public partial class FormReportCustomerSaleReport : Form
    {
        public FormReportCustomerSaleReport()
        {
            InitializeComponent();
        }

        private void FormReportCustomerSaleReport_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            //this.LoadPrincipal();
            //  this.LoadChannelType();
            // this.LoadDeliveryman();
            //  this.LoadSaleForce();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }

        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void LoadPrincipal()
        {
            //SKUPriceDetailController PController = new SKUPriceDetailController();
            //DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
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
        /// Loads Deliverymen To Sale Force Combo
        /// </summary>
        //private void LoadSaleForce()
        //{
        //    if (drpDistributor.Items.Count > 0)
        //    {
        //        ddlSaleForce.Items.Clear();
        //        SaleForceController mDController = new SaleForceController();
        //        DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        //        ddlSaleForce.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        //        clsWebFormUtil.FillDropDownList(this.ddlSaleForce, m_dt, 0, 3);
        //    }
        //}

        /// <summary>
        /// Loads Deliverymen To Deliveryman Combo
        /// </summary>
        //private void LoadDeliveryman()
        //{
        //    if (drpDistributor.Items.Count > 0)
        //    {
        //        DrpSaleForce.Items.Clear();
        //        SaleForceController mDController = new SaleForceController();
        //        DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue  , int.Parse(this.Session["CompanyId"].ToString()));
        //        DrpSaleForce.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        //        clsWebFormUtil.FillDropDownList(this.DrpSaleForce, m_dt, 0, 3);
        //    }
        //    else
        //    {
        //        DrpSaleForce.Items.Clear();
        //    }
        //}

        /// <summary>
        /// Loads Routes To Route Combo
        /// </summary>
        private void LoadArea()
        {
            //if (drpDistributor.Items.Count > 0)
            //{
            //    DrpRoute.Items.Clear();
            //    DistributorAreaController mController = new DistributorAreaController();
            //    DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            //    DrpRoute.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            //    clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6);
            //}
            //else
            //{
            //    DrpRoute.Items.Clear();
            //}
        }

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
        /// Loads Delivermen
        /// </summary>
        protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  this.LoadDeliveryman();
            //   this.LoadSaleForce();
        }

        /// <summary>
        /// Shows Customer Sale Report in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            btnViewPDF.Text = "Wait...";
            btnViewPDF.Enabled = false;
            DocumentPrintController DPrint = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataSet ds = null;
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            DataControl dc = new DataControl();
            ds = RptSaleCtl.GetItemWiseProfitLoss(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

            CORNBusinessLayer.Reports.CrpItemWiseProftLoss CrpReport = new CORNBusinessLayer.Reports.CrpItemWiseProftLoss();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("FromDate", txtStartDate.Text);
            CrpReport.SetParameterValue("ToDate", txtEndDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Location", drpDistributor.Text);
                        
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            btnViewPDF.Text = "View";
            btnViewPDF.Enabled = true;
        }

        private void FormReportCustomerSaleReport_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 105);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
