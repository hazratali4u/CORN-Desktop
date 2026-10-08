using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;
using System.IO;

namespace CORNPointOfSale
{
    public partial class FormPurchase : Form
    {
        bool _SkusLoaded = false;
        byte[] imageData = null;
        decimal TotalAmountValue;
        DataTable dt_new = new DataTable();
        DataTable dtDocumentNo = new DataTable();
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataControl dc = new DataControl();
        private int RowNo;
        private static decimal PrivouseQty, FreePrivousQty;
        DataTable PurchaseSKU;

        public FormPurchase()
        {
            InitializeComponent();
        }
        //
        //  Load Functions
        //
        #region Load Function

        // Load Main Form
        #region Load Form
        private void FormStockRegister_Load(object sender, EventArgs e)
        {
            CreateTableForDocumentNo();
            loadDocumentType();
            LoadPrincipal();
            LoadDistributor();
            LoadSKUDetail();
            CreatTable();
            GetDocumentNo();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            cboxDocumentType.SelectedIndex = 0;
            textBoxX1.Text = SessionClass.CurrentWorkDate.ToShortDateString();
        }
        #endregion

        // Loads Principals
        #region Load Principal
        private void LoadPrincipal()
        {
            SkuHierarchyController _mController = new SkuHierarchyController();
            DataTable m_dt = _mController.SelectPrincipal(Constants.SKUPrincipal, SessionClass.CompanyID);
            cboxPrincipal.DataSource = m_dt;
            cboxPrincipal.DisplayMember = "SKU_HIE_NAME";
            cboxPrincipal.ValueMember = "SKU_HIE_ID";
        }
        #endregion

        // Load Documents Number 
        #region Load Document Number
        private void GetDocumentNo()
        {
            if (cboxDocumentType.DisplayMember == "Display" && cboxDocumentType.ValueMember == "Value")
            {
                this.cboxDocumentNo.SelectedIndexChanged -= new EventHandler(cboxDocumentNo_SelectedIndexChanged);
                cboxDocumentNo.DataSource = null;
                dt_new.Rows.Clear();
                cboxDocumentNo.Items.Clear();
                DateTime MWorkDate = System.DateTime.Now;
                PurchaseController mPurchase = new PurchaseController();
                DataTable dt = mPurchase.SelectPurchaseDocumentNo(Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()), SessionClass.DISTRIBUTOR_ID, Constants.LongNullValue, SessionClass.UserID, 0);
                dtDocumentNo = dt;
                int _rows = dt.Rows.Count;
                for (int i = 0; i < _rows; i++)
                {
                    var _value = dt.Rows[i].ItemArray[0].ToString();
                    dt_new.Rows.Add(_value.ToString() + " - " + dt.Rows[i].ItemArray[2].ToString() + " - " + dt.Rows[i]["SKU_HIE_NAME"].ToString(), Convert.ToInt64(_value));
                }
                DataRow _dr;
                _dr = dt_new.NewRow();
                _dr["Display"] = "New";
                _dr["value"] = Constants.LongNullValue;
                dt_new.Rows.InsertAt(_dr, 0);
                cboxDocumentNo.DataSource = dt_new;
                cboxDocumentNo.DisplayMember = "Display";
                cboxDocumentNo.ValueMember = "value";
                this.cboxDocumentNo.SelectedIndexChanged += new EventHandler(cboxDocumentNo_SelectedIndexChanged);
            }
        }
        public void CreateTableForDocumentNo()
        {
            dt_new.Columns.Add("Display", typeof(string));
            dt_new.Columns.Add("value", typeof(Int64));
        }
        #endregion

        // Loads Locations (Distributor)
        #region Load Distributor
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            cboxDistributor.DataSource = dt;
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
        }
        #endregion

        // Loads Locations To Location To Combo
        #region Load To Distributor
        private void LoadToDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            cboxTransferFor.DataSource = dt;
            cboxTransferFor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxTransferFor.ValueMember = "DISTRIBUTOR_ID";
        }
        #endregion

        // Load Document Detail
        #region Load Document Detail
        private void LoadDocumentDetail()
        {
            try
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
                    if (cboxDocumentType.SelectedIndex == 0 || cboxDocumentType.SelectedIndex == 4) //Purchase
                    {
                        cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                        cboxPrincipal.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                        txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                        txtBuiltyno.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                        DateTime date = Convert.ToDateTime(dt.Rows[0]["DOCUMENT_DATE"]);
                        textBoxX1.Text = date.ToShortDateString();
                        txtDiscountTotal.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["DISCOUNT"]), 2).ToString().Replace("&nbsp;", "0");
                        txtGST.Text = dt.Rows[0]["GST"].ToString();
                    }
                    PurchaseSKU = mPurchase.SelectPurchaseDetail(Constants.IntNullValue, long.Parse(dt.Rows[0][0].ToString()));
                    int SNo = 1;
                    foreach (DataRow dr in PurchaseSKU.Rows)
                    {
                        dr.BeginEdit();
                        dr["PURCHASE_DETAIL_ID"] = SNo;
                        dr.EndEdit();
                        SNo += 1;
                    }
                    ClassSession.dtPurchaseSKU = PurchaseSKU;
                    LoadGird();
                }
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
            }
        }
        #endregion

        // Loads Document Detail Data To Document Detail Grid (Load Grid)
        #region Load Grid
        private void LoadGird()
        {
            try
            {
                decimal TotalQty = 0;
                decimal TotalValue = 0;
                decimal PDiscount = 0;
                PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
                GridPurchase.DataSource = PurchaseSKU;
                foreach (DataRow dr in PurchaseSKU.Rows)
                {
                    TotalQty += decimal.Parse(dr["Quantity"].ToString());
                    TotalValue += decimal.Parse(dr["Amount"].ToString());
                    PDiscount += decimal.Parse(dr["Discount"].ToString());
                }
                TotalAmountValue = TotalValue;
                txtQuantityTotal.Text = TotalQty.ToString();
                TotalValue = TotalValue - Convert.ToDecimal(dc.chkNull_0(txtDiscountTotal.Text)) + Convert.ToDecimal(dc.chkNull_0(txtGST.Text));
                txtPDiscountTotal.Text = PDiscount.ToString();
                txtAmountTotal.Text = TotalValue.ToString();
                ArrangeGrid();
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
            }
        }
        #endregion

        // Loads SKU Prices
        #region Load SKU Detail
        public void LoadSKUDetail()
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, 2, SessionClass.CurrentWorkDate);
            ClassSession.Dtsku_Price = Dtsku_Price;
            cboxSkuCode.DataSource = Dtsku_Price;
            cboxSkuCode.DisplayMember = "SkuDetail";
            cboxSkuCode.ValueMember = "SKU_ID";
        }
        #endregion

        //  Load Document Type
        #region Load Document Type
        public void loadDocumentType()
        {
            cboxDocumentType.DataSource = null;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Display", typeof(string));
            dt2.Columns.Add("Value", typeof(int));

            dt2.Rows.Add("Purchase", 2);
            //dt2.Rows.Add("Transfer Out", 5);
            //dt2.Rows.Add("Purchase Return", 3);
            //dt2.Rows.Add("Transfer In", 4);
            //dt2.Rows.Add("Damage", 6);
            cboxDocumentType.DataSource = dt2;
            cboxDocumentType.DisplayMember = "Display";
            cboxDocumentType.ValueMember = "Value";
        }
        #endregion
        #endregion

        //
        // Creats Datatable For Document
        //
        #region Create DataTable
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
            PurchaseSKU.Columns.Add("Discount", typeof(decimal));
            PurchaseSKU.Columns.Add("DiscountType", typeof(decimal));
            PurchaseSKU.Columns.Add("FreeSku", typeof(decimal));
            PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));

            ClassSession.dtPurchaseSKU = PurchaseSKU;

        }
        #endregion

        //
        //  Combobox Selected Changed Events
        //
        #region Selected Changed Events

        //  Document 
        #region  Document
        private void cboxDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblToLocation.Text = "Supplier";
            lblFromLocation.Text = "Purchase For";
            cboxDistributor.Enabled = true;
            cboxPrincipal.Enabled = true;
            cboxTransferFor.Visible = false;
            lblTransferFor.Visible = false;
            GetDocumentNo();
        }
        #endregion

        // Pricipal 
        #region Pricipal
        protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSKUDetail();
        }
        #endregion

        //  Documnet Number
        #region Document Number
        private void cboxDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboxDocumentNo.Items.Count == 0 || cboxDocumentNo.DisplayMember != "Display" || cboxDocumentNo.ValueMember != "value")
                {
                    return;
                }
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    CreatTable();
                    ClassSession.dtPurchaseSKU = PurchaseSKU;
                    LoadGird();
                    ArrangeGrid();
                    ClearAll();
                    cboxPrincipal.Enabled = true;
                    cboxDistributor.Enabled = true;
                    cboxDocumentType.Enabled = true;
                }
                else
                {
                    txtBuiltyno.Text = "";
                    txtDocumentNumber.Text = "";
                    cboxPrincipal.Enabled = false;
                    cboxDistributor.Enabled = false;
                    cboxDocumentType.Enabled = false;
                    LoadDocumentDetail();
                    LoadSKUDetail();
                }
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
            }
        }
        #endregion

        private void cboxDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        //
        //  Common Functions
        //
        #region Common Functions
        // Cancel Purchase
        #region Cancel Purchase
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisAbaleOption(false);
            GridPurchase.DataSource = null;
            CreatTable();
            ClearAll();
            txtDocumentNumber.Text = "";
            txtBuiltyno.Text = "";
            txtDocumentNumber.Text = "";
        }
        #endregion

        // Enables/Disables Controls
        #region Enable / Disable Controles
        private void DisAbaleOption(bool IsDisable)
        {
            if (IsDisable == true)
            {
                cboxDocumentType.Enabled = false;
                cboxPrincipal.Enabled = false;
                cboxDistributor.Enabled = false;
                cboxDocumentNo.Enabled = false;
            }
            else
            {
                cboxDocumentType.Enabled = true;
                cboxPrincipal.Enabled = true;
                cboxDistributor.Enabled = true;
                cboxDocumentNo.Enabled = true;
                cboxDocumentNo.SelectedIndex = 0;
            }
        }
        #endregion

        // Clears Form Controls
        #region Clear All
        private void ClearAll()
        {
            txtSkuCode.Text = "";
            txtSkuName.Text = "";
            txtQuantity.Text = "1";
            txtFreeSku.Text = "0";
            txtItemDiscount.Text = "0";
            ItemDiscountType.Value = true;
            txtAmount.Text = "";
            txtTradePrice.Text = "";
            txtPrice.Text = "";
            lblPriceDate.Text = "";
            cboxSkuCode.Enabled = true;
            btnSave.Text = "Add Item";
            PrivouseQty = 0;
            FreePrivousQty = 0;
            textBoxX1.Text = SessionClass.CurrentWorkDate.ToShortDateString();
            //LoadSKUDetail();
        }
        #endregion

        // By Scan Chekbox Changed Event
        #region By Scan Chekbox Changed Event
        private void chkByScan_CheckedChanged(object sender, EventArgs e)
        {
            txtSkuName.Text = "";
            txtSkuCode.Text = "";
            txtPrice.Text = "";
            lblPriceDate.Text = "";
            txtTradePrice.Text = "";
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
            GridPurchase.Columns["PURCHASE_DETAIL_ID"].Visible = true;
            GridPurchase.Columns["SKU_NAME"].Visible = true;
            GridPurchase.Columns["TRADE_PRICE"].Visible = true;
            GridPurchase.Columns["Quantity"].Visible = true;
            GridPurchase.Columns["PRICE"].Visible = true;
            GridPurchase.Columns["AMOUNT"].Visible = true;
            GridPurchase.Columns["Discount"].Visible = true;
            GridPurchase.Columns["FreeSku"].Visible = true;
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
            GridPurchase.Columns["PURCHASE_DETAIL_ID"].Width = 30;
            GridPurchase.Columns["SKU_NAME"].Width = 325;
            GridPurchase.Columns["Price"].Width = 99;
            GridPurchase.Columns["TRADE_PRICE"].Width = 99;
            GridPurchase.Columns["QUANTITY"].Width = 99;
            GridPurchase.Columns["AMOUNT"].Width = 99;
            GridPurchase.Columns["EDIT"].Width = 47;
            GridPurchase.Columns["DELETE"].Width = 49;

            //Set COlumns Index
            GridPurchase.Columns["PURCHASE_DETAIL_ID"].DisplayIndex = 0;
            GridPurchase.Columns["SKU_NAME"].DisplayIndex = 1;
            GridPurchase.Columns["QUANTITY"].DisplayIndex = 2;
            GridPurchase.Columns["FreeSku"].DisplayIndex = 3;
            GridPurchase.Columns["Discount"].DisplayIndex = 4;
            GridPurchase.Columns["Price"].DisplayIndex = 5;
            GridPurchase.Columns["TRADE_PRICE"].DisplayIndex = 6;
            GridPurchase.Columns["AMOUNT"].DisplayIndex = 7;
            GridPurchase.Columns["EDIT"].DisplayIndex = 8;
            GridPurchase.Columns["DELETE"].DisplayIndex = 9;
            // Set Text Alignment
            GridPurchase.Columns["SKU_NAME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
        public decimal ItemDiscountCounter()
        {
            decimal Pdiscount = 0;
            if (ItemDiscountType.Value)
            {
                Pdiscount = Convert.ToDecimal(dc.chkNull_0(txtItemDiscount.Text));
            }
            else
            {
                Pdiscount = (Convert.ToDecimal(dc.chkNull_0(txtItemDiscount.Text)) / 100) * (Convert.ToDecimal(dc.chkNull_0(txtPrice.Text)) * Convert.ToDecimal(dc.chkNull_0(txtQuantity.Text)));
            }
            return Pdiscount;
        }
        #region Add Button Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtQuantity.TextLength == 0 || txtQuantity.Text == "0") && cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                ToastNotification.Show(this, "Enter Quantity", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if ((txtTradePrice.TextLength == 0 || txtPrice.TextLength == 0 || txtTradePrice.Text == "0" || txtPrice.Text == "0") && cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                ToastNotification.Show(this, "Please Enter Price/TradePrice", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }

            //================================================================================================
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
                int CurrentStock = CheckStockStatus(int.Parse(dc.chkNull_0(foundRows[0]["SKU_ID"].ToString())));

                if (btnSave.Text == "Add Item")
                {
                    if (CheckDublicateSKU())
                    {
                        if (CurrentStock == -1)
                        {
                            DataRow dr = PurchaseSKU.NewRow();
                            dr["PURCHASE_DETAIL_ID"] = GridPurchase.Rows.Count + 1;
                            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                            dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                            dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtPrice.Text));//foundRows[0]["TRADE_PRICE"];
                            dr["TRADE_PRICE"] = decimal.Parse(dc.chkNull_0(txtTradePrice.Text));
                            dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            dr["Discount"] = ItemDiscountCounter();
                            dr["DiscountType"] = Convert.ToInt32(ItemDiscountType.Value);
                            dr["FreeSku"] = decimal.Parse(dc.chkNull_0(txtFreeSku.Text));
                            dr["AMOUNT"] = decimal.Parse(dc.chkNull_0(txtPrice.Text)) * decimal.Parse(dc.chkNull_0(txtQuantity.Text)) - ItemDiscountCounter();
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
                        ToastNotification.Show(this, cboxSkuCode.SelectedText + " Already Exists", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
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
                        dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtPrice.Text));
                        dr["TRADE_PRICE"] = decimal.Parse(dc.chkNull_0(txtTradePrice.Text));
                        dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                        dr["Discount"] = ItemDiscountCounter();
                        dr["DiscountType"] = Convert.ToInt32(ItemDiscountType.Value);
                        dr["FreeSku"] = decimal.Parse(dc.chkNull_0(txtFreeSku.Text));
                        dr["AMOUNT"] = decimal.Parse(dc.chkNull_0(dr["PRICE"].ToString())) * decimal.Parse(dc.chkNull_0(txtQuantity.Text)) - ItemDiscountCounter();
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
            }
            else
            {
                ToastNotification.Show(this, "Wrong Item Select", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);

            }
            ArrangeGrid();
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

        /// <summary>
        /// Checkes Duplicate SKUS in Document Detail Grid
        /// </summary>
        /// <returns>bool</returns>
        #region Check Duplicate SKU
        private bool CheckDublicateSKU()
        {
            DataControl dc = new DataControl();
            DataTable Dtsku_Price = (DataTable)ClassSession.Dtsku_Price;
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
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Checks SKU Stock
        /// </summary>
        /// <param name="SKU_ID">SKU</param>
        /// <returns>SKU Stock as Integer</returns>
        #region Check SKU Stock
        private int CheckStockStatus(int SKU_ID)
        {
            if (cboxDocumentType.SelectedIndex == 0 || cboxDocumentType.SelectedIndex == 3)
            {
                return -1;
            }
            else
            {
                PhaysicalStockController mController = new PhaysicalStockController();
                DataTable dt = mController.SelectSKUClosingStock(int.Parse(cboxDistributor.SelectedValue.ToString()), SKU_ID, "N/A", DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()) + PrivouseQty + FreePrivousQty >= decimal.Parse(txtQuantity.Text))
                    {
                        return -1;
                    }
                    else
                    {
                        return Convert.ToInt32(Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()) + PrivouseQty + FreePrivousQty);
                    }
                }
            }

            return 0;
        }
        #endregion

        #region Key Up Event
        private void cboxSkuCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int _SkuID = Convert.ToInt32(cboxSkuCode.SelectedValue.ToString());
                    DataTable Dtsku_Price = PController.SelectDataPrice(null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, _SkuID, 13, SessionClass.CurrentWorkDate);
                    if (Dtsku_Price.Rows.Count > 0)
                    {
                        DataRow[] _foundedRow = Dtsku_Price.Select("SKU_ID =" + _SkuID, "SKU_ID ASC", DataViewRowState.Unchanged);
                        if (_foundedRow.Length > 0)
                        {
                            txtTradePrice.Text = Math.Round(Convert.ToDecimal(_foundedRow[0].ItemArray[1]), 2).ToString();
                            txtPrice.Text = Math.Round(Convert.ToDecimal(_foundedRow[0].ItemArray[2]), 2).ToString();
                            lblPriceDate.Text = "Price Change Date: " + Convert.ToDateTime(_foundedRow[0].ItemArray[3]).ToString("dd-MMM-yyyy");
                            txtQuantity.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void txtSkuCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    string SkuCode = txtSkuCode.Text;
                    if (ClassSession.Dtsku_Price.Rows.Count > 0)
                    {
                        DataRow[] _foundedRow = ClassSession.Dtsku_Price.Select("SKU_CODE  = '" + SkuCode + "'");

                        if (_foundedRow.Length > 0)
                        {
                            int SKUID = Convert.ToInt32(_foundedRow[0].ItemArray[0]);
                            DataTable Dtsku_Price = PController.SelectDataPrice(null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, SKUID, 13, SessionClass.CurrentWorkDate);
                            txtSkuName.Text = _foundedRow[0].ItemArray[3].ToString();
                            txtQuantity.Focus();
                            txtTradePrice.Text = Math.Round(Convert.ToDecimal(Dtsku_Price.Rows[0].ItemArray[1]), 2).ToString();
                            txtPrice.Text = Math.Round(Convert.ToDecimal(Dtsku_Price.Rows[0].ItemArray[2]), 2).ToString();
                            lblPriceDate.Text = "Price Change Date: " + Convert.ToDateTime(_foundedRow[0].ItemArray[3]).ToString("dd-MMM-yyyy");
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Common Events
        private void cboxSkuCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = string.Empty;
            lblPriceDate.Text = string.Empty;
            txtTradePrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        private void GridPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridPurchase.CurrentCell.RowIndex;
            RowNo = _rowIndex;
            if (e.ColumnIndex == GridPurchase.Columns["Edit"].Index)
            {
                RowEditing(_rowIndex);
            }
            else if (e.ColumnIndex == GridPurchase.Columns["Delete"].Index)
            {
                RowDeleting(e);
            }
        }
        #endregion

        #region Row Editing
        public void RowEditing(int _rowIndex)
        {
            txtSkuCode.Text = GridPurchase.Rows[_rowIndex].Cells["SKU_CODE"].Value.ToString();
            txtSkuName.Text = GridPurchase.Rows[_rowIndex].Cells["SKU_NAME"].Value.ToString();
            cboxSkuCode.SelectedValue = Convert.ToInt32(GridPurchase.Rows[_rowIndex].Cells["SKU_ID"].Value);
            txtQuantity.Text = GridPurchase.Rows[_rowIndex].Cells["QUANTITY"].Value.ToString();
            PrivouseQty = decimal.Parse(GridPurchase.Rows[_rowIndex].Cells["QUANTITY"].Value.ToString());
            txtPrice.Text = Convert.ToString(GridPurchase.Rows[_rowIndex].Cells["PRICE"].Value);
            txtTradePrice.Text = Convert.ToString(GridPurchase.Rows[_rowIndex].Cells["TRADE_PRICE"].Value);
            txtAmount.Text = Convert.ToString(GridPurchase.Rows[_rowIndex].Cells["AMOUNT"].Value);

            if (Convert.ToBoolean(GridPurchase.Rows[_rowIndex].Cells["DiscountType"].Value))
            {
                txtItemDiscount.Text = GridPurchase.Rows[_rowIndex].Cells["Discount"].Value.ToString();
            }
            else
            {
                txtItemDiscount.Text = ((Convert.ToDecimal(GridPurchase.Rows[_rowIndex].Cells["Discount"].Value.ToString()) * 100) / (decimal.Parse(GridPurchase.Rows[_rowIndex].Cells["QUANTITY"].Value.ToString()) * decimal.Parse(GridPurchase.Rows[_rowIndex].Cells["PRICE"].Value.ToString()))).ToString();
            }
            ItemDiscountType.Value = Convert.ToBoolean(GridPurchase.Rows[_rowIndex].Cells["DiscountType"].Value);
            txtFreeSku.Text = GridPurchase.Rows[_rowIndex].Cells["FreeSku"].Value.ToString();

            FreePrivousQty = 0;
            cboxSkuCode.Enabled = false;
            txtQuantity.Focus();
            btnSave.Text = "Update Item";
        }
        #endregion

        #region Row Deleting
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

        #region Save Document Button Click Event

        public bool CheckDuplicate()
        {
            DataRow[] dr;
            if (cboxDocumentNo.SelectedIndex == 0)
            {
                dr = dtDocumentNo.Select("ORDER_NUMBER = '" + txtDocumentNumber.Text + "' ");
            }
            else
            {
                dr = dtDocumentNo.Select("ORDER_NUMBER = '" + txtDocumentNumber.Text + "' AND PURCHASE_MASTER_ID <> '" + Convert.ToInt32(cboxDocumentNo.SelectedValue.ToString()) + "' ");
            }
            if (dr.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            if (cboxPrincipal.SelectedValue == null)
            {
                MessageBox.Show("Principal Not Exists", "CORN: POS");
                return;
            }
            if (txtDocumentNumber.Text == "")
            {
                MessageBox.Show("Please Enter Invoice Number", "CONR-POS");
                return;
            }
            if (CheckDuplicate())
            {
                MessageBox.Show("Invoice Number Already Exists", "CONR-POS");
                return;
            }
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            if (cboxDocumentType.SelectedIndex == 2 || cboxDocumentType.SelectedIndex == 3)
            {
                if (cboxDistributor.SelectedValue.ToString() == cboxTransferFor.SelectedValue.ToString())
                {
                    ToastNotification.Show(this, "Transfer to Location must be different", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
            }
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            if (PurchaseSKU.Rows.Count > 0)
            {
                DistributorController mDayClose = new DistributorController();
                DataTable dt = mDayClose.SelectMaxDayClose(Constants.IntNullValue, int.Parse(cboxDistributor.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (CalculatePurchase(DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString())))
                    {
                        PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
                        PurchaseSKU.Rows.Clear();
                        ClassSession.dtPurchaseSKU = PurchaseSKU;
                        LoadGird();
                        GetDocumentNo();
                        cboxDistributor.Enabled = true;
                        cboxPrincipal.Enabled = true;
                        cboxDocumentType.Enabled = true;
                        ClearAll();
                        txtBuiltyno.Text = "";
                        txtDocumentNumber.Text = "";
                        txtDiscountTotal.Text = "";
                        txtGST.Text = "";
                        DisAbaleOption(false);
                    }
                }
                else
                {
                    ToastNotification.Show(this, "Wrong Location", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
            }
            else
            {
                ToastNotification.Show(this, "At least one Item must enter", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        #endregion

        /// <summary>
        /// Save Document Detail Grid Data
        /// </summary>
        /// <param name="MWorkDate">Date</param>
        /// <returns>bool</returns>
        #region Calculate Purchase
        private bool CalculatePurchase(DateTime MWorkDate)
        {
            if (cboxDocumentType.DisplayMember != "Display" || cboxDocumentType.ValueMember != "Value")
            {
                MessageBox.Show(this, "Please Select Document Type");
                return false;
            }
            decimal mTotalAmount = 0;

            PurchaseController mController = new PurchaseController();
            DataTable dtPurchaseDetail = (DataTable)ClassSession.dtPurchaseSKU;
            mTotalAmount = Convert.ToDecimal(dc.chkNull_0(txtAmountTotal.Text));
            if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), Math.Round(decimal.Parse(dc.chkNull_0(txtDiscountTotal.Text)), 2), Constants.Document_PrincipalInvoice, imageData,Convert.ToDecimal(dc.chkNull_0(txtPDiscountTotal.Text)), Convert.ToDecimal(dc.chkNull_0(txtGST.Text)));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), Math.Round(decimal.Parse(dc.chkNull_0(txtDiscountTotal.Text)), 2), imageData, Convert.ToDecimal(dc.chkNull_0(txtPDiscountTotal.Text)), Constants.Document_PrincipalInvoice, Convert.ToDecimal(dc.chkNull_0(txtGST.Text)));
                return mResult;
            }
        }
        #endregion
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void FormPurchase_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 570, 210);
            groupPanel4.Location = new Point(points[0], points[1]);
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtAmount.Text = Convert.ToString(decimal.Parse(dc.chkNull_0(txtPrice.Text)) * decimal.Parse(dc.chkNull_0(txtQuantity.Text)) - ItemDiscountCounter());
            }
            catch (Exception)
            {
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Logo";
                dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap img = new Bitmap(dlg.FileName);
                    int imageHeight = Convert.ToInt32(img.Height);
                    int imageWidth = Convert.ToInt32(img.Width);
                    var fileName = dlg.FileName;
                    imageData = ReadFile(fileName);
                }
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
                throw;
            }
        }

        private void ItemDiscountType_ValueChanged(object sender, EventArgs e)
        {
            txtItemDiscount.Focus();
        }

        private void txtDiscountTotal_TextChanged(object sender, EventArgs e)
        {
            txtAmountTotal.Text = Convert.ToString(TotalAmountValue - Convert.ToDecimal(dc.chkNull_0(txtDiscountTotal.Text)) + Convert.ToDecimal(dc.chkNull_0(txtGST.Text)));
        }

        public byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
