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
    public partial class FormReportSalesAndClosingStock : Form
    {
        DataTable _dtCatagory;
        public FormReportSalesAndClosingStock()
        {
            InitializeComponent();
        }

        private void FormReportSalesAndClosingStock_Load(object sender, EventArgs e)
        {
            CreateTable();
            LoadSections();
            LoadCategories();
            this.DistributorType();
            this.LoadAssingned();
            this.LoadPrincipal();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            DrpReportType.SelectedIndex = 0;
            DrpUnitType.SelectedIndex = 0;
            DrpReportType_SelectedIndexChanged(null, null);
        }
        public void CreateTable()
        {
            _dtCatagory = new DataTable();
            _dtCatagory.Columns.Add("Catagory_Name", typeof(string));
            _dtCatagory.Columns.Add("Catagory_Id", typeof(int));
        }
        private void LoadCategories()
        {
            int _SectionItems = ChkListSection.Items.Count;
            for (int i = 0; i < _SectionItems; i++)
            {
                DataRowView drV = (DataRowView)ChkListSection.Items[i];
                DataRow dr = drV.Row;
                int _value = Convert.ToInt32(dr["SKU_HIE_ID"].ToString());
                if (ChkListSection.GetItemChecked(i))
                {
                    SkuHierarchyController sController = new SkuHierarchyController();
                    DataTable dt = sController.SelectSKUCategories(Constants.SKUCategory, _value, true);
                    int _rows = dt.Rows.Count;
                    for (int j = 0; j < _rows; j++)
                    {
                        AddCatagoryToDataTable(dt.Rows[j].ItemArray[3].ToString(), Convert.ToInt32(dt.Rows[j].ItemArray[0].ToString()));
                    }
                }
            }
            ChkListCatagory.DataSource = _dtCatagory;
            ChkListCatagory.DisplayMember = "Catagory_Name";
            ChkListCatagory.ValueMember = "Catagory_Id";
        }
        public void AddCatagoryToDataTable(string name, int id)
        {
            _dtCatagory.Rows.Add(name, id);
        }
        private void LoadSections()
        {
            ChkListSection.Items.Clear();
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSKUCategories(Constants.SKUSection, Constants.IntNullValue, true);
            ChkListSection.DataSource = dt;
            ChkListSection.TopIndex = ChkListSection.FindString("All");
            ChkListSection.DisplayMember = "SKU_HIE_NAME";
            ChkListSection.ValueMember = "SKU_HIE_ID";

        }
        /// <summary>
        /// Loads Location Types
        /// </summary>
        private void DistributorType()
        {
            DistributorController dController = new DistributorController();
            DataTable dt = dController.SelectDistributorTypeInfo(1);
            ddDistributorType.DataSource = dt;
            ddDistributorType.ValueMember = "DISTRIBUTOR_TYPE_ID";
            ddDistributorType.DisplayMember = "TYPENAME";
            if (ddDistributorType.Items.Count > 0)
            {
                ddDistributorType.SelectedIndex = 0;
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

        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void LoadPrincipal()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            DrpPrincipal.DisplayMember = "Company_Name";
            DrpPrincipal.ValueMember = "Company_Id";
            if (DrpPrincipal.Items.Count > 0)
            {
                DrpPrincipal.SelectedIndex = 0;
            }
        }

        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            string Catagories_IDs = null;

            for (int i = 0; i < ChkListCatagory.Items.Count; i++)
            {
                if (ChkListCatagory.GetItemChecked(i) == true)
                {
                    DataRowView drV = (DataRowView)ChkListCatagory.Items[i];
                    DataRow dr = drV.Row;
                    int _value = Convert.ToInt32(dr["Catagory_Id"].ToString());
                    Catagories_IDs += _value + ",";
                }
            }
            if (Catagories_IDs == null)
            {
                MessageBox.Show(this, "Select atleast one category", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (drpDistributor.SelectedIndex < 0)
            {
                MessageBox.Show(this, "CORN: POS", "Location is not selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataSet ds = RptSaleCtl.GetRegionSaleDetail(int.Parse(this.ddDistributorType.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), Catagories_IDs, DrpReportType.SelectedIndex, DrpUnitType.SelectedIndex, int.Parse(SessionClass.UserID.ToString()));
            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            CORNBusinessLayer.Reports.RegionWiseSaleReport CrpReport = new CORNBusinessLayer.Reports.RegionWiseSaleReport();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();
            CrpReport.SetParameterValue("fromDate", txtStartDate.Text);
            CrpReport.SetParameterValue("todate", txtEndDate.Text);
            CrpReport.SetParameterValue("ReportTitle", "Daily " + DrpReportType.Text + " In " + DrpUnitType.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            SessionClass.CrpReport = CrpReport;
            SessionClass.ReportType = 0;
            _formReport.ShowDialog();
            btnView.Text = "View";
            btnView.Enabled = true;
        }

        /// <summary>
        /// Loads Locations
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAssingned();
        }

        private void ChkListSection_Click(object sender, EventArgs e)
        {
        }

        private void ChkAllSections_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListSection.Items.Count;
            if (ChkAllSections.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListSection.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListSection.SetItemChecked(i, false);
                }
            }
            ChkListSection_SelectedIndexChanged(null, null);
        }

        private void ChkListSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkListCatagory.DataSource = null;
            _dtCatagory.Rows.Clear();
            ChkListCatagory.Items.Clear();
            LoadCategories();
        }

        private void ChkAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListCatagory.Items.Count;
            if (ChkAllCategories.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListCatagory.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListCatagory.SetItemChecked(i, false);
                }
            }
        }

        private void FormReportSalesAndClosingStock_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 400, 220);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

        private void DrpReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpReportType.SelectedIndex == 0)
            {
                lblDate.Text = "Date";
                label1.Visible = false;
                txtEndDate.Visible = false;
            }
            else
            {
                lblDate.Text = "From Date";
                label1.Visible = true;
                txtEndDate.Visible = true;
            }
        }
    }
}
