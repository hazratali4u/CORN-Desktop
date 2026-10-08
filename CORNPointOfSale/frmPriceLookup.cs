using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;

namespace CORNPointOfSale
{
    public partial class frmPriceLookup : Form
    {
        //private frmPOS objfrmPOS;
        frmPOS objfrmPOS = Application.OpenForms["frmPOS"] as frmPOS;
        bool _IsNumeric = true;
        public frmPriceLookup()
        {
            InitializeComponent();
        }

        public frmPriceLookup(frmPOS objfrmPOS) : this()
        {
            this.objfrmPOS = objfrmPOS;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void frmPriceLookup_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void GrdPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int SKUID = Convert.ToInt32(GrdPriceLookup.Rows[GrdPriceLookup.CurrentCell.RowIndex].Cells[0].Value);
                objfrmPOS.DataFromPriceLookup(SKUID);
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //SearchPrice();
        }
        public void LoadProducts()
        {
            //SKUPriceDetailController PController = new SKUPriceDetailController();
            //DataTable Dtsku_Price = PController.SelectDataPrice(Convert.ToString(txtSearch.Text), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 1, SessionClass.CurrentWorkDate);
            FormWaiting._Type = 6;
            FormWaiting _frmWting = new FormWaiting();
            _frmWting.ShowDialog();
        }
        public void SearchPrice(int _TypeID)
        {
            GrdPriceLookup.AutoGenerateColumns = false;
            GrdPriceLookup.Rows.Clear();
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable Dtsku_Price = PController.SelectDataPrice(Convert.ToString(txtSearch.Text), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, _TypeID, SessionClass.CurrentWorkDate);
            if (Dtsku_Price.Rows.Count > 0)
            {
                 foreach (DataRow dr in Dtsku_Price.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(GrdPriceLookup);
                    row.Cells[0].Value = dr["SKU_ID"];
                    row.Cells[1].Value = dr["SKU_CODE"];
                    row.Cells[2].Value = dr["SKU_NAME"];
                    row.Cells[3].Value = dr["TRADE_PRICE"];
                    row.Cells[4].Value = dr["CLOSING_STOCK"];
                    GrdPriceLookup.Rows.Add(row);
                }
                GrdPriceLookup.Focus();
            }
            else
            {
                ToastNotification.Show(this, "Item not found", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (Regex.IsMatch(txtSearch.Text.Trim(), @"^[a-zA-Z]+$")) for checking is only characters
                if (Regex.IsMatch(txtSearch.Text.Trim(), @"^\d+$"))     // for checking is only digits
                {
                    SearchPrice(1);
                }
                else
                {
                    SearchPrice(111);
                }

            }
        }

        private void GrdPriceLookup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          int SKUID = Convert.ToInt32(GrdPriceLookup.Rows[GrdPriceLookup.CurrentCell.RowIndex].Cells[0].Value);
          objfrmPOS.DataFromPriceLookup(SKUID);
          this.Close();
          objfrmPOS.GetFocuss();
        }

        private void frmPriceLookup_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
    }
}
