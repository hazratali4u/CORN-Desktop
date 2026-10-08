using System;
using System.Data;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormItemsLookUp : Form
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        public FormItemsLookUp()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           // LoadGrid();
        }


        //public void LoadGrid()
        //{
        //    string SkuCode = txtSkuCode.Text;
        //    if (txtSkuCode.TextLength > 0)
        //    {
        //        DataTable Dtsku_Price = PController.SelectDataPrice(SkuCode, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 7, SessionClass.CurrentWorkDate);
        //        GridItemsLookup.DataSource = Dtsku_Price;
        //        ArrangeGrid();
        //    }
        //    else
        //    {
        //        DataTable Dtsku_Price = PController.SelectDataPrice(null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 7, SessionClass.CurrentWorkDate);
        //        GridItemsLookup.DataSource = Dtsku_Price;
        //        ArrangeGrid();
        //    }
        //}
        //public void ArrangeGrid()
        //{
        //    // Set Decimal Place
        //    GridItemsLookup.Columns["TRADE_PRICE"].DefaultCellStyle.Format = "0.00##";
        //    // Set Column Hide
        //    GridItemsLookup.Columns["SKU_ID"].Visible = false;
        //    //  Set Text Alignment
        //    GridItemsLookup.Columns["SKU_NAME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    //  Set Columns Herader Text
        //    GridItemsLookup.Columns["SKU_CODE"].HeaderText = "Code";
        //    GridItemsLookup.Columns["SKU_NAME"].HeaderText = "Description";
        //    GridItemsLookup.Columns["PACKSIZE"].HeaderText = "Pack Size";
        //    GridItemsLookup.Columns["TRADE_PRICE"].HeaderText = "Price";
        //    GridItemsLookup.Columns["CLOSING_STOCK"].HeaderText = "Closing Stock";

        //    // Width
        //    GridItemsLookup.Columns["SKU_CODE"].Width = 120;
        //    GridItemsLookup.Columns["SKU_NAME"].Width = 400;
        //    GridItemsLookup.Columns["PACKSIZE"].Width = 120;
        //    GridItemsLookup.Columns["TRADE_PRICE"].Width = 120;
        //    GridItemsLookup.Columns["CLOSING_STOCK"].Width = 120;
        //}

        private void FormItemsLookUp_Load(object sender, EventArgs e)
        {
            LoadDistributor();
        }
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            cboxDistributor.DataSource = dt;
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
        }
        private void txtSkuCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Regex.IsMatch(txtSkuCode.Text.Trim(), @"^[a-zA-Z]+$"))
                {
                    SearchPrice(77);
                }
                else
                {
                    SearchPrice(7);
                }
            }
        }
        public void SearchPrice(int _TypeID)
        {
            try
            {
                GridItemsLookup.AutoGenerateColumns = false;
                GridItemsLookup.Rows.Clear();
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable Dtsku_Price = PController.SelectDataPrice(Convert.ToString(txtSkuCode.Text), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(DataControl.chkNull_Zero(cboxDistributor.SelectedValue.ToString())), SessionClass.UserID, Constants.IntNullValue, _TypeID, SessionClass.CurrentWorkDate);
                if (Dtsku_Price.Rows.Count > 0)
                {
                    foreach (DataRow dr in Dtsku_Price.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(GridItemsLookup);
                        row.Cells[0].Value = dr["SKU_CODE"];
                        row.Cells[1].Value = dr["SKU_NAME"];
                        row.Cells[2].Value = dr["PACKSIZE"];
                        row.Cells[3].Value = dr["TRADE_PRICE"];
                        row.Cells[4].Value = dr["CLOSING_STOCK"];
                        GridItemsLookup.Rows.Add(row);
                    }
                    GridItemsLookup.Focus();
                }
                else
                {
                    ToastNotification.Show(this, "Item not found", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
