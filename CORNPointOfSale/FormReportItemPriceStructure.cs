using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;

namespace CORNPointOfSale
{
    public partial class FormReportItemPriceStructure : Form
    {
        DataTable _dtCatagory;
        public FormReportItemPriceStructure()
        {
            InitializeComponent();
        }

        private void FormReportItemPriceStructure_Load(object sender, EventArgs e)
        {
            CreateTable();
            LoadDistributor();
            LoadSections();
            LoadCategories();
        }
        public void CreateTable()
        {
            _dtCatagory = new DataTable();
            _dtCatagory.Columns.Add("Catagory_Name", typeof(string));
            _dtCatagory.Columns.Add("Catagory_Id", typeof(int));
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
        private void LoadCategories()
        {
            ChkListCatagory.DataSource = null;
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
        /// Shows Report in Excel Or PDF
        /// </summary>
        /// <param name="p_Report_Type">ReportType</param>
        private void ShowReport(int p_Report_Type)
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
                MessageBox.Show(this, "Select Distributor", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                CORNBusinessLayer.Classes.DocumentPrintController DPrint = new CORNBusinessLayer.Classes.DocumentPrintController();
                RptSaleController RptSaleCtl = new RptSaleController();
                btnView.Text = "Wait...";
                btnView.Enabled = false;
                
                // old formatted report
                //CORNBusinessLayer.Reports.CrpPriceListmgd CrpReport = new CORNBusinessLayer.Reports.CrpPriceListmgd();

                // new formatted report for excel to avoid/remove cell merging in excel export
                CORNBusinessLayer.Reports.CrpPriceListmgdExcel CrpReport = new CORNBusinessLayer.Reports.CrpPriceListmgdExcel();

                DataSet ds = null;
                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
                ds = RptSaleCtl.PriceList(Constants.IntNullValue, Catagories_IDs, int.Parse(drpDistributor.SelectedValue.ToString()));

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                //CrpReport.SetParameterValue("Principal", "All");
                //CrpReport.SetParameterValue("Branch", this.drpDistributor.Text);
                //CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
                btnView.Text = "View";
                btnView.Enabled = true;
            }
            catch (Exception ex)
            {
                btnView.Text = "View";
                btnView.Enabled = true;
                ex.ToString();
            }
        }

        /// <summary>
        /// Shows SKU Price Structure in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            ShowReport(0);
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

        private void ChkListSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkListCatagory.DataSource = null;
            _dtCatagory.Rows.Clear();
            ChkListCatagory.Items.Clear();
            LoadCategories();
        }

        private void FormReportItemPriceStructure_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 325, 210);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
