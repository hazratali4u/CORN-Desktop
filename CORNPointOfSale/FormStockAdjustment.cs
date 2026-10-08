using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormStockAdjustment : Form
    {
        bool _SkusLoaded = false;
        DataTable dt_new = new DataTable();
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataControl dc = new DataControl();
        private static int RowNo;
        private static decimal PrivouseQty;
        DataTable PurchaseSKU;

        public FormStockAdjustment()
        {
            InitializeComponent();
        }

        private void FormStockAdjustment_Load(object sender, EventArgs e)
        {
            CreateTableForDocumentNo();
            loadDocumentType();
            CreatTable();
            GetDocumentNo();
            LoadDistributor();
        }
        private void FormStockAdjustment_Shown(object sender, EventArgs e)
        {
            LoadSKUDetail();
        }
        #region Load Document Type
        private void loadDocumentType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("value", typeof(int));
            dt.Rows.Add("Opening Stock", 7);
            dt.Rows.Add("Short", 8);
            dt.Rows.Add("Excess", 9);

            cboxDocumentType.DataSource = dt;
            cboxDocumentType.DisplayMember = "Display";
            cboxDocumentType.ValueMember = "value";
            cboxDocumentType.SelectedIndex = 0;
        }
        #endregion

        private void CreatTable()
        {
            PurchaseSKU = new DataTable();
            PurchaseSKU.Columns.Add("PURCHASE_DETAIL_ID", typeof(long));
            PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
            PurchaseSKU.Columns.Add("SKU_Code", typeof(string));
            PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
            PurchaseSKU.Columns.Add("PRICE", typeof(decimal));
            PurchaseSKU.Columns.Add("TRADE_PRICE", typeof(decimal));
            PurchaseSKU.Columns.Add("Quantity", typeof(decimal));
            PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
            ClassSession.dtPurchaseSKU = PurchaseSKU;
        }

        private void cboxDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDocumentNo();
            btnCancel_Click(null, null);
        }
        private void GetDocumentNo()
        {
            if (cboxDocumentType.DisplayMember == "Display" && cboxDocumentType.ValueMember == "value")
            {
                cboxDocumentNo.SelectedIndexChanged -= new EventHandler(cboxDocumentNo_SelectedIndexChanged);
                dt_new.Rows.Clear();
                cboxDocumentNo.DataSource = null;
                cboxDocumentNo.Items.Clear();
                DateTime MWorkDate = System.DateTime.Now;
                PurchaseController mPurchase = new PurchaseController();
                DataTable dt = mPurchase.SelectPurchaseDocumentNo(int.Parse(cboxDocumentType.SelectedValue.ToString()), Constants.IntNullValue, Constants.LongNullValue, int.Parse(SessionClass.UserID.ToString()), 0);
                int _rows = dt.Rows.Count;
                for (int i = 0; i < _rows; i++)
                {
                    var _value = dt.Rows[i].ItemArray[0].ToString();
                    dt_new.Rows.Add(_value.ToString(), Convert.ToInt64(_value));
                }
                DataRow _dr;
                _dr = dt_new.NewRow();
                _dr["Display"] = "New";
                _dr["value"] = Constants.LongNullValue;
                dt_new.Rows.InsertAt(_dr, 0);
                cboxDocumentNo.DataSource = dt_new;
                cboxDocumentNo.DisplayMember = "Display";
                cboxDocumentNo.ValueMember = "value";
                cboxDocumentNo.SelectedIndex = 0;
                cboxDocumentNo.SelectedIndexChanged += new EventHandler(cboxDocumentNo_SelectedIndexChanged);
            }
        }
        public void CreateTableForDocumentNo()
        {
            dt_new.Columns.Add("Display", typeof(string));
            dt_new.Columns.Add("value", typeof(Int64));
        }
        private void LoadDocumentDetail()
        {
            if (cboxDocumentNo.Text == "New" || cboxDocumentNo.DisplayMember != "Display" || cboxDocumentNo.ValueMember != "value")
            {
                return;
            }

            DateTime MWorkDate = System.DateTime.Now;
            PurchaseController mPurchase = new PurchaseController();
            DataTable dt = mPurchase.SelectPurchaseDocumentNo(Constants.IntNullValue, Constants.IntNullValue, long.Parse(cboxDocumentNo.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            if (dt.Rows.Count > 0)
            {
                cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                PurchaseSKU = mPurchase.SelectPurchaseDetail(Constants.IntNullValue, long.Parse(dt.Rows[0][0].ToString()));
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                LoadGird();
            }
        }

        private void cboxDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxDocumentNo.Items.Count == 0 || cboxDocumentNo.DisplayMember != "Display" || cboxDocumentNo.ValueMember != "value")
            {
                return;
            }
            if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                CreatTable();
                LoadGird();
                cboxDistributor.Enabled = true;
                cboxDocumentType.Enabled = true;
                ClearAll();
                txtDocumentNumber.Text = "";
                DisAbaleOption(false);
            }
            else
            {
                LoadDocumentDetail();
                LoadSKUDetail();
            }
        }
        private void LoadGird()
        {
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            GridPurchase.DataSource = PurchaseSKU;
            ArrangeGrid();
        }

        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            cboxDistributor.DataSource = dt;
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        #region Load SKU Detail
        //private void LoadSKUDetail()
        //{
        //    if (cboxPrincipal.Items.Count > 0 && cboxDistributor.Items.Count > 0)
        //    {
        //        if (_SkusLoaded)
        //        {
        //            cboxSkuCode.DataSource = ClassSession.DtSkusDetail;
        //            cboxSkuCode.DisplayMember = "SkuPriceDetail2";
        //            cboxSkuCode.ValueMember = "SKU_ID";
        //        }
        //        else
        //        {
        //            DataTable Dtsku_Price = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 1, SessionClass.CurrentWorkDate);
        //            ClassSession.Dtsku_Price = Dtsku_Price;
        //            try
        //            {
        //                ClassSession.DtSkusDetail.Rows.Clear();
        //            }
        //            catch (Exception)
        //            {                    }
        //            ClassSession.DtSkusDetail = Dtsku_Price;
        //            cboxSkuCode.DataSource = Dtsku_Price;
        //            cboxSkuCode.DisplayMember = "SkuPriceDetail2";
        //            cboxSkuCode.ValueMember = "SKU_ID";
        //        }
        //    }
        //}
        private void LoadSKUDetail()
        {
            FormWaiting._Type = 3;
            FormWaiting _frmw8 = new FormWaiting();
            _frmw8.ShowDialog();
            DataTable Dtsku_Price = SessionClass.dtLoadItemsForStockRegister;
            ClassSession.Dtsku_Price = Dtsku_Price;
            cboxSkuCode.DataSource = Dtsku_Price;
            cboxSkuCode.DisplayMember = "SkuPriceDetail2";
            cboxSkuCode.ValueMember = "SKU_ID";
        }
        #endregion
        
        #region Arrange Grid
        public void ArrangeGrid()
        {
            try
            {
                GridPurchase.Columns.Remove("Edit");
                GridPurchase.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            //  Hide Extra Columns
            foreach (DataGridViewColumn clms in GridPurchase.Columns)
            {
                clms.Visible = false;
            }
            GridPurchase.Columns["SKU_NAME"].Visible = true;
            GridPurchase.Columns["Quantity"].Visible = true;

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridPurchase.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GridPurchase.Columns.Add(btnDelete);

            //Arrange Columns Width
            GridPurchase.Columns["SKU_NAME"].Width = 334;
            GridPurchase.Columns["QUANTITY"].Width = 99;
            GridPurchase.Columns["EDIT"].Width = 52;
            GridPurchase.Columns["DELETE"].Width = 52;

            //Set COlumns Index
            GridPurchase.Columns["SKU_NAME"].DisplayIndex = 0;
            GridPurchase.Columns["QUANTITY"].DisplayIndex = 1;
            GridPurchase.Columns["EDIT"].DisplayIndex = 2;
            GridPurchase.Columns["DELETE"].DisplayIndex = 3;

            // Set Text Alignment
            GridPurchase.Columns["SKU_NAME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
        
        #region Common Events
        private void cboxSkuCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = string.Empty;
        }
        #endregion

        #region By Scan Chekbox Changed Event
        private void chkByScan_CheckedChanged(object sender, EventArgs e)
        {
            txtSkuName.Text = "";
            txtSkuCode.Text = "";
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
                //LoadSKUDetail();
                cboxSkuCode.Focus();
                //_SkusLoaded = true;
            }
        }
        #endregion

        #region Check Double Entry
        private bool CheckDublicateSKU()
        {

            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            DataRow[] foundRows;
            if (chkByScan.Checked)
            {
                foundRows = PurchaseSKU.Select("SKU_CODE  = '" + txtSkuCode.Text + "'");
            }
            else
            {
                foundRows = PurchaseSKU.Select("SKU_ID  = '" + Convert.ToInt32(cboxSkuCode.SelectedValue.ToString()) + "'");
            }
            if (foundRows.Length == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Check SKU Stock
        private int CheckStockStatus(int SKU_ID)
        {
            if (cboxDocumentType.SelectedValue.ToString() != "8")
            {
                return -1;
            }
            else
            {
                PhaysicalStockController mController = new PhaysicalStockController();
                DataTable dt = mController.SelectSKUClosingStock(int.Parse(cboxDistributor.SelectedValue.ToString()), SKU_ID, "N/A", DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()) + PrivouseQty >= decimal.Parse(dc.chkNull_0(txtQuantity.Text)))
                    {
                        return -1;
                    }
                    else
                    {
                        return Convert.ToInt32(Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()) + PrivouseQty);
                    }
                }
            }

            return 0;
        }
        #endregion

        #region Add SKU to Grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable Dtsku_Price = (DataTable)ClassSession.Dtsku_Price;
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            DataRow[] foundRows;
            if (chkByScan.Checked)
            {
                foundRows = Dtsku_Price.Select("SKU_CODE = '" + txtSkuCode.Text + "'");
            }
            else
            {
                foundRows = Dtsku_Price.Select("SKU_ID = '" + cboxSkuCode.SelectedValue + "'");
            }

            if (foundRows.Length > 0)
            {
                decimal mStdDiscount = decimal.Parse(dc.chkNull_0(foundRows[0]["DISTRIBUTOR_DISCOUNT"].ToString()));
                int CurrentStock = CheckStockStatus(int.Parse(dc.chkNull_0(foundRows[0]["SKU_ID"].ToString())));
                if (btnSave.Text == "Add Item")
                {
                    if (CheckDublicateSKU())
                    {
                        if (CurrentStock == -1)
                        {
                            DataRow dr = PurchaseSKU.NewRow();
                            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                            dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                            dr["TRADE_PRICE"] = foundRows[0]["TRADE_PRICE"];
                            dr["PRICE"] = foundRows[0]["DISTRIBUTOR_PRICE"];
                            dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            dr["AMOUNT"] = decimal.Parse(foundRows[0]["DISTRIBUTOR_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            PurchaseSKU.Rows.Add(dr);
                        }
                        else
                        {
                            ToastNotification.Show(this, cboxSkuCode.SelectedText + " Current closing Stock is " + CurrentStock.ToString(), CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                            return;
                        }
                    }
                    else
                    {
                        ToastNotification.Show(this, txtSkuCode.Text + " Already Exists ", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        return;
                    }
                }
                else if (btnSave.Text == "Update Item")
                {
                    if (CurrentStock == -1)
                    {
                        DataRow dr = PurchaseSKU.Rows[RowNo];
                        dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                        dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                        dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                        dr["TRADE_PRICE"] = foundRows[0]["TRADE_PRICE"];
                        dr["PRICE"] = foundRows[0]["DISTRIBUTOR_PRICE"];
                        dr["Quantity"] = decimal.Parse(txtQuantity.Text);
                        dr["AMOUNT"] = decimal.Parse(foundRows[0]["DISTRIBUTOR_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                    }
                    else
                    {
                        ToastNotification.Show(this, cboxSkuCode.SelectedText + "Current closing Stock is " + CurrentStock.ToString(), CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        return;
                    }
                }
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                ClearAll();
                LoadGird();
                DisAbaleOption(true);
                ArrangeGrid();
            }
            else
            {
                ToastNotification.Show(this, "Wrong SKU please check in list", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
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
        #endregion

        #region Save Docment
        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            DistributorController mDayClose = new DistributorController();
            DataTable dt = mDayClose.SelectMaxDayClose(Constants.IntNullValue, int.Parse(cboxDistributor.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                DateTime MWorkDate = DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString());

                PurchaseController mController = new PurchaseController();
                DataTable dtPurchaseDetail = (DataTable)ClassSession.dtPurchaseSKU;
                decimal mTotalAmount = 0;
                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mTotalAmount += decimal.Parse(dr["AMOUNT"].ToString());

                }
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertStockAdjustment(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                          , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), 0, mTotalAmount, false, dtPurchaseDetail, 0, null, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, 0, null, 0, Constants.IntNullValue);
                }
                else
                {
                    bool mResult = mController.UpdateStockAdjustment(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                       , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), 0, mTotalAmount, false, dtPurchaseDetail, 0, null, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, null, Constants.DecimalNullValue,0, Constants.DecimalNullValue);
                }

                ToastNotification.Show(this, "Record Updated", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
                PurchaseSKU.Rows.Clear();
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                LoadGird();
                GetDocumentNo();
                cboxDistributor.Enabled = true;
                cboxDocumentType.Enabled = true;
                ClearAll();
                txtDocumentNumber.Text = "";
                DisAbaleOption(false);
            }
            else
            {
                ToastNotification.Show(this, "Wrong Location or Unassigne", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        #endregion

        #region Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CreatTable();
            LoadGird();
            cboxDistributor.Enabled = true;
            cboxDocumentType.Enabled = true;
            ClearAll();
            txtDocumentNumber.Text = "";
            DisAbaleOption(false);
        }
        #endregion

        #region Disable Controles
        private void DisAbaleOption(bool IsDisable)
        {
            if (IsDisable == true)
            {
                cboxDocumentType.Enabled = false;
                cboxDistributor.Enabled = false;
                cboxDocumentNo.Enabled = false;

            }
            else
            {

                cboxDocumentType.Enabled = true;
                cboxDistributor.Enabled = true;
                cboxDocumentNo.Enabled = true;
                //cboxDocumentNo.SelectedIndex = 0;
            }
        }
        #endregion

        #region Clear All Controles
        private void ClearAll()
        {
            txtSkuCode.Text = "";
            txtSkuName.Text = "";
            txtQuantity.Text = "1";
            PrivouseQty = 0;
            txtSkuCode.Enabled = true;
            cboxSkuCode.Enabled = true;
            btnSave.Text = "Add Item";
        }
        #endregion

        #region Edit / Delete SKUS

        private void GridPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridPurchase.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridPurchase.Columns["Edit"].Index)
            {
                RowEditing(_rowIndex);
            }
            else if (e.ColumnIndex == GridPurchase.Columns["Delete"].Index)
            {
                RowDeleting(e);
            }
        }
        public void RowEditing(int _rowIndex)
        {
            txtSkuCode.Text = GridPurchase.Rows[_rowIndex].Cells["SKU_CODE"].Value.ToString();
            txtSkuName.Text = GridPurchase.Rows[_rowIndex].Cells["SKU_NAME"].Value.ToString();
            cboxSkuCode.SelectedValue = GridPurchase.Rows[_rowIndex].Cells["SKU_ID"].Value.ToString();
            txtQuantity.Text = GridPurchase.Rows[_rowIndex].Cells["Quantity"].Value.ToString();
            PrivouseQty = decimal.Parse(GridPurchase.Rows[_rowIndex].Cells["Quantity"].Value.ToString());
            txtSkuCode.Enabled = false;
            cboxSkuCode.Enabled = false;
            txtQuantity.Focus();
            btnSave.Text = "Update Item";
        }
        public void RowDeleting(DataGridViewCellEventArgs e)
        {
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            if (PurchaseSKU.Rows.Count > 0)
            {
                PurchaseSKU.Rows.RemoveAt(e.RowIndex);
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                LoadGird();
            }
        }

        #endregion

        #region Load SKU NAME FROM CODE
        private void txtSkuCode_KeyUp(object sender, KeyEventArgs e)
        {
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
                        txtQuantity.Focus();
                    }
                }
            }
        }
        #endregion

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void FormStockAdjustment_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 320, 210);
            groupPanel4.Location = new Point(points[0], points[1]);
        }
    }
}