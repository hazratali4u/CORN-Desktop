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
    public partial class FormReportStockReconciliation : Form
    {
        DataTable _dtCatagory;
        public FormReportStockReconciliation()
        {
            InitializeComponent();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void FormReportStockReconciliation_Load(object sender, EventArgs e)
        {
            CreateTable();
            LoadDistributor();
            //LoadPrincipal();
            LoadSections();
            LoadCategories();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = SessionClass.CurrentWorkDate;
            txtEndDate.Value = SessionClass.CurrentWorkDate;
        }
        public void CreateTable()
        {
            _dtCatagory = new DataTable();
            _dtCatagory.Columns.Add("Catagory_Name", typeof(string));
            _dtCatagory.Columns.Add("Catagory_Id", typeof(int));
        }
        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void LoadPrincipal()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            //DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            DrpPrincipal.DataSource = m_dt;
            DrpPrincipal.DisplayMember = "Company_Name";
            DrpPrincipal.ValueMember = "Company_Id";
        }

        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            drpDistributor.DataSource = null;
            drpDistributor.Items.Clear();
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
            ChkListSection.DisplayMember = "SKU_HIE_NAME";
            ChkListSection.ValueMember = "SKU_HIE_ID";
        }
        /// <summary>
        /// Shows Stock Reconciliation in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnViewPDF_Click(object sender, EventArgs e)
        {
            string Catagories_IDs = null;
            DocumentPrintController mController = new DocumentPrintController();
            RptInventoryController RptInventoryCtl = new RptInventoryController();
            CORNBusinessLayer.Reports.CrpStockReconciliation CrpReport = new CORNBusinessLayer.Reports.CrpStockReconciliation();
            DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            for (int i = 0; i < ChkListCatagory.Items.Count; i++)
            {
                DataRowView drV = (DataRowView)ChkListCatagory.Items[i];
                DataRow dr = drV.Row;
                int _value = Convert.ToInt32(dr["Catagory_Id"].ToString());
                if (ChkListCatagory.GetItemChecked(i) == true)
                {
                    Catagories_IDs += _value + ",";
                }
            }
            if (Catagories_IDs == null)
            {
                MessageBox.Show(this, "Please Select AtLeast One Category", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ///////
            string _priceText;
            int _priceValue = 1;
            if (rbtnTrade.Checked)
            {
                _priceText = "Sale Price";
                _priceValue = 0;
            }
            else
            {
                _priceText = "Purchase Price";
            }
            DataSet ds = null;
            btnView.Text = "Wait...";
            btnView.Enabled = false;
            if (chkZeroElimination.Checked)
            {
                ds = RptInventoryCtl.SelectPrincipalStockReconcilation(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(SessionClass.UserID.ToString()), 0, 1, Catagories_IDs);
            }
            else
            {
                ds = RptInventoryCtl.SelectPrincipalStockReconcilation(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(SessionClass.UserID.ToString()), 1, 1, Catagories_IDs);
            }
            btnView.Text = "View";
            btnView.Enabled = true;
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();
            CrpReport.SetParameterValue("division", drpDistributor.Text);
            CrpReport.SetParameterValue("fromdate", txtStartDate.Text);
            CrpReport.SetParameterValue("todate", txtEndDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("Price", _priceText);
            //CrpReport.SetParameterValue("ReportType", "Stock Reconciliation Report ( " + ddlType.Text + " )");
            CrpReport.SetParameterValue("ReportType", "Stock Reconciliation Report");

            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
        }



        #region Check Boxes (Check All)

        private void ChbAllCategory_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListCatagory.Items.Count;
            if (ChkAllCategory.Checked)
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

        private void ChkAllSection_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListSection.Items.Count;
            if (ChkAllSection.Checked)
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

        #endregion

        private void ChkListSection_SelectedIndexChanged(object sender, EventArgs e)
        {

            ChkListCatagory.DataSource = null;
            //try { _dtCatagory.Rows.Clear(); }
            //catch (Exception) { }
            _dtCatagory.Rows.Clear();
            ChkListCatagory.Items.Clear();
            LoadCategories();
        }

        private void ChkListCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChkListSection_Click(object sender, EventArgs e)
        {
            ChkListSection.CheckOnClick = true;
        }

        private void ChkListCatagory_Click(object sender, EventArgs e)
        {

        }

        private void ChkListCatagory_MouseClick(object sender, MouseEventArgs e)
        {
            ChkListCatagory.CheckOnClick = true;
        }

        private void FormReportStockReconciliation_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 590, 220);
            groupPanel1.Location = new Point(points[0], points[1]);
        }
    }
}
