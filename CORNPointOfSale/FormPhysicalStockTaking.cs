using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormPhysicalStockTaking : Form
    {
        DataTable PurchaseSKU;
        DataControl dc = new DataControl();
        private static int RowNo;
        public FormPhysicalStockTaking()
        {
            InitializeComponent();
        }


        #region Load Events
        //  Form Loading
        private void FormPhysicalStockTaking_Load(object sender, EventArgs e)
        {
            LoadDistributor();
        }
        /// Loads SKU Detail To ListBox
        private void LoadSKUDetail()
        {
            if (cboxDistributor.Items.Count > 0)
            {
                cboxSkuCode.SelectedIndexChanged -= new EventHandler(cboxSkuCode_SelectedIndexChanged);

                FormWaiting._Type = 5;
                FormWaiting _frm = new FormWaiting();
                _frm.ShowDialog();
                //SKUPriceDetailController PController = new SKUPriceDetailController();
                //DataTable Dtsku_Price = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()), int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 1, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
                DataTable Dtsku_Price = SessionClass.dtItemDetail;
                cboxSkuCode.DataSource = Dtsku_Price;
                cboxSkuCode.DisplayMember = "SkuPriceDetail";
                cboxSkuCode.ValueMember = "SKU_ID";
                ClassSession.Dtsku_Price = Dtsku_Price;
                cboxSkuCode.SelectedIndexChanged += new EventHandler(cboxSkuCode_SelectedIndexChanged);
            }
        }
        /// Loads Locations To Location Combo
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            cboxDistributor.DataSource = dt;
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        #endregion


        #region Common Functions

        /// Checks Duplicate SKU in Document Detail Grid
        private bool CheckDublicateSKU()
        {
            DataControl dc = new DataControl();
            DataTable Dtsku_Price = (DataTable)ClassSession.Dtsku_Price;
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            DataRow[] foundRows = PurchaseSKU.Select("SKU_CODE  = '" + txtSkuCode.Text + "'");
            if (foundRows.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Saves/Updates Document
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUnitRate.TextLength ==0 || txtusaleableqty.TextLength == 0 || txtQuantity.TextLength == 0)
            {
                MessageBox.Show(this, "Please Fill All Fields" , "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable Dtsku_Price = (DataTable)ClassSession.Dtsku_Price;
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            DataRow[] foundRows;
            if (chkByScan.Checked)
            {
                foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtSkuCode.Text + "'");
            }
            else
            {
                foundRows = Dtsku_Price.Select("SKU_ID  = '" + Convert.ToInt32(cboxSkuCode.SelectedValue.ToString()) + "'");
            }
            DataControl dc = new DataControl();

            if (foundRows.Length > 0)
            {
                PhaysicalStockController MController = new PhaysicalStockController();
                if (btnSave.Text == "Save")
                {
                    MController.InsertPysicalStock(int.Parse(cboxDistributor.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToString()), int.Parse(foundRows[0]["SKU_ID"].ToString()), decimal.Parse(dc.chkNull_0(txtQuantity.Text)), decimal.Parse(dc.chkNull_0(txtusaleableqty.Text)), decimal.Parse(txtUnitRate.Text), 0, 0);
                }

                else
                {
                    MController.UpdatePysicalStock(int.Parse(cboxDistributor.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToString()), int.Parse(foundRows[0]["SKU_ID"].ToString()), decimal.Parse(dc.chkNull_0(txtQuantity.Text)), decimal.Parse(dc.chkNull_0(txtusaleableqty.Text)), decimal.Parse(txtUnitRate.Text), 0, 0);
                }
                ClearAll();
            }
            if (chkByScan.Checked)
            {
                txtSkuCode.Focus();
            }
            else
            {
                cboxSkuCode.Focus();
            }
        }

        /// Clears Form Controls
        private void ClearAll()
        {
            txtSkuCode.Text = "";
            txtSkuName.Text = "";
            txtQuantity.Text = "";
            txtusaleableqty.Text = "";
            txtUnitRate.Text = "0";
            txtSkuCode.Enabled = true;
            btnSave.Text = "Save";
        }

        // By Scan Chekbox Changed Event
        private void chkByScan_CheckedChanged(object sender, EventArgs e)
        {
            txtSkuName.Text = "";
            txtSkuCode.Text = "";
            txtUnitRate.Text = "";
            txtusaleableqty.Text = "";
            txtQuantity.Text = "";

            if (chkByScan.Checked)
            {
                txtSkuCode.Visible = true;
                txtSkuName.Visible = true;
                cboxSkuCode.Visible = false;
                txtSkuCode.Focus();
            }
            else
            {
                txtSkuCode.Visible = false;
                txtSkuName.Visible = false;
                cboxSkuCode.Visible = true;
                cboxSkuCode.Focus();
            }
        }

        //  Txt SKU Code Key Up Event
        private void txtSkuCode_KeyUp(object sender, KeyEventArgs e)
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string SkuCode = txtSkuCode.Text;
                DataTable Dtsku_Price = PController.SelectDataPrice(SkuCode, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 6, SessionClass.CurrentWorkDate);
                if (Dtsku_Price.Rows.Count > 0)
                {
                    DataRow[] _foundedRow = Dtsku_Price.Select("SKU_CODE =" + SkuCode, "SKU_ID ASC", DataViewRowState.Unchanged);
                    if (_foundedRow.Length > 0)
                    {
                        txtSkuName.Text = _foundedRow[0].ItemArray[3].ToString();
                    }
                }
                txtUnitRate.Focus();
            }
        }
        #endregion

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void FormPhysicalStockTaking_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 410, 80);
            groupPanel3.Location = new Point(points[0], points[1]);
        }
        private void FormPhysicalStockTaking_Shown(object sender, EventArgs e)
        {
            LoadSKUDetail();
        }

        private void cboxSkuCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string code = cboxSkuCode.Text.Trim();
            //txtSkuCode.Text = code.Substring(0, code.IndexOf('-'));
        }
    }
}
