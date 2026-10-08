using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Diagnostics;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormStockRegisterr : Form
    {
        public static int _LoadedFrom { get; set; }
        public static string _TitalText { get; set; }
        bool _SkusLoaded = false;
        DataTable dt_new = new DataTable();
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataControl dc = new DataControl();
        private static int RowNo;
        private static decimal PrivouseQty, FreePrivousQty;
        DataTable PurchaseSKU;

        public FormStockRegisterr()
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
            lblTital.Text = _TitalText;
            CreateTableForDocumentNo();
            loadDocumentType();
            LoadPrincipal();
            LoadDistributor();
            CreatTable();
            GetDocumentNo();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            cboxDocumentType.SelectedValue = _LoadedFrom;
            cboxDocumentType_SelectedIndexChanged(null, null);
        }

        private void FormStockRegisterr_Shown(object sender, EventArgs e)
        {
            LoadSKUDetail();
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
                dt_new.Rows.Clear();
                cboxDocumentNo.DataSource = null;
                cboxDocumentNo.Items.Clear();
                DateTime MWorkDate = System.DateTime.Now;
                PurchaseController mPurchase = new PurchaseController();
                DataTable dt = mPurchase.SelectPurchaseDocumentNo(Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()), SessionClass.DISTRIBUTOR_ID, Constants.LongNullValue, SessionClass.UserID, 0);
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
            if (cboxDocumentNo.Text == "New" || cboxDocumentNo.DisplayMember != "Display" || cboxDocumentNo.ValueMember != "value")
            {
                return;
            }
            DateTime MWorkDate = System.DateTime.Now;
            PurchaseController mPurchase = new PurchaseController();
            DataTable dt = mPurchase.SelectPurchaseDocumentNo(Constants.IntNullValue, Constants.IntNullValue, long.Parse(cboxDocumentNo.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            if (dt.Rows.Count > 0)
            {
                if (cboxDocumentType.SelectedIndex == 0)
                {
                    cboxTransferFor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                    txtBuiltyno.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                    txtDiscountTotal.Text = dt.Rows[0]["DISCOUNT"].ToString().Replace("&nbsp;", "0");
                }
                else if (cboxDocumentType.SelectedIndex == 1)
                {
                    cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    cboxTransferFor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    cboxPrincipal.SelectedValue = dt.Rows[0]["PRINCIPAL_ID"].ToString();
                    txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                    txtBuiltyno.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                else if (cboxDocumentType.SelectedIndex == 2)
                {
                    cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    cboxTransferFor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                    txtBuiltyno.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                else
                {
                    cboxTransferFor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    cboxDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    txtDocumentNumber.Text = dt.Rows[0][2].ToString();
                    txtBuiltyno.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                PurchaseSKU = mPurchase.SelectPurchaseDetail(Constants.IntNullValue, long.Parse(dt.Rows[0][0].ToString()));
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                LoadGird();
            }
        }
        #endregion

        // Loads Document Detail Data To Document Detail Grid (Load Grid)
        #region Load Grid
        private void LoadGird()
        {
            decimal TotalQty = 0;
            decimal TotalValue = 0;
            PurchaseSKU = (DataTable)ClassSession.dtPurchaseSKU;
            GridPurchase.DataSource = PurchaseSKU;
            foreach (DataRow dr in PurchaseSKU.Rows)
            {
                TotalQty += decimal.Parse(dr["Quantity"].ToString());
                TotalValue += decimal.Parse(dr["Amount"].ToString());
            }
            txtQuantityTotal.Text = TotalQty.ToString();
            txtAmountTotal.Text = TotalValue.ToString();
            ArrangeGrid();
        }
        #endregion

        // Loads SKU Prices
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
        //            {

        //            }
        //            ClassSession.DtSkusDetail = Dtsku_Price;
        //            cboxSkuCode.DataSource = Dtsku_Price;
        //            cboxSkuCode.DisplayMember = "SkuPriceDetail2";
        //            cboxSkuCode.ValueMember = "SKU_ID";
        //        }
        //    }
        //}
        public void LoadSKUDetail()
        {
            if (cboxPrincipal.Items.Count > 0)
            {
                FormWaiting._Type = 2;
                FormWaiting _frmw8 = new FormWaiting();
                _frmw8.ShowDialog();
                DataTable Dtsku_Price = SessionClass.dtLoadItemsForStockRegister;
                ClassSession.Dtsku_Price = Dtsku_Price;
                cboxSkuCode.DataSource = Dtsku_Price;
                cboxSkuCode.DisplayMember = "SkuPriceDetail2";
                cboxSkuCode.ValueMember = "SKU_ID";
            }
        }
        #endregion

        //  Load Document Type
        #region Load Document Type
        public void loadDocumentType()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Display", typeof(string));
            dt2.Columns.Add("Value", typeof(int));

            dt2.Rows.Add("Transfer Out", 5);
            dt2.Rows.Add("Purchase Return", 3);
            dt2.Rows.Add("Transfer In", 4);
            dt2.Rows.Add("Damage", 6);
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
            PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
            PurchaseSKU.Columns.Add("Discount", typeof(decimal));
            PurchaseSKU.Columns.Add("DiscountType", typeof(decimal));
            PurchaseSKU.Columns.Add("FreeSku", typeof(decimal));

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
            if (cboxDocumentType.DisplayMember == "Display" && cboxDocumentType.ValueMember == "Value")
            {
                if (Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()) == 2)
                {
                    lblToLocation.Text = "Supplier";
                    lblFromLocation.Text = "Purchase For";
                    cboxDistributor.Enabled = true;
                    cboxPrincipal.Enabled = true;
                    cboxTransferFor.Visible = false;
                    lblTransferFor.Visible = false;
                    GetDocumentNo();
                    lblToLocation.Visible = false;
                    cboxPrincipal.Visible = false;
                }
                else if (Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()) == 5)
                {
                    lblFromLocation.Text = "Transfer From";
                    cboxDistributor.Enabled = true;
                    cboxPrincipal.Enabled = true;
                    LoadToDistributor();
                    cboxTransferFor.Visible = true;
                    lblTransferFor.Visible = true;
                    lblTransferFor.Text = "Transfer To";
                    GetDocumentNo();
                    lblToLocation.Visible = false;
                    cboxPrincipal.Visible = false;
                }
                else if (Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()) == 3)
                {
                    lblToLocation.Text = "Supplier";
                    lblFromLocation.Text = "Return From";
                    cboxDistributor.Enabled = true;
                    cboxPrincipal.Enabled = true;
                    cboxTransferFor.Visible = false;
                    lblTransferFor.Visible = false;
                    GetDocumentNo();
                    lblToLocation.Visible = true;
                    cboxPrincipal.Visible = true;
                }
                else if (Convert.ToInt32(cboxDocumentType.SelectedValue.ToString()) == 4)
                {
                    lblFromLocation.Text = "Transfer to";
                    cboxDistributor.Enabled = true;
                    cboxPrincipal.Enabled = true;
                    LoadToDistributor();
                    cboxTransferFor.Visible = true;
                    lblTransferFor.Visible = true;
                    lblTransferFor.Text = "Transfer From";
                    GetDocumentNo();
                    lblToLocation.Visible = false;
                    cboxPrincipal.Visible = false;
                }
                else
                {
                    lblToLocation.Text = "Supplier";
                    lblFromLocation.Text = "Location";
                    cboxDistributor.Enabled = true;
                    cboxPrincipal.Enabled = true;
                    cboxTransferFor.Visible = false;
                    lblTransferFor.Visible = false;
                    GetDocumentNo();
                    lblToLocation.Visible = false;
                    cboxPrincipal.Visible = false;
                }
            }
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
            if (cboxDocumentNo.Items.Count == 0 || cboxDocumentNo.DisplayMember != "Display" || cboxDocumentNo.ValueMember != "value")
            {
                return;
            }
            if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                CreatTable();
                ClassSession.dtPurchaseSKU = PurchaseSKU;
                LoadGird();
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
            CreatTable();
            GridPurchase.DataSource = null;
            //LoadGird();
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
            txtAmount.Text = "";
            txtTradePrice.Text = "";
            txtPrice.Text = "";
            cboxSkuCode.Enabled = true;
            btnSave.Text = "Add Item";
            PrivouseQty = 0;
            FreePrivousQty = 0;
            txtDiscountTotal.Text = "0";
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
            GridPurchase.Columns["SKU_NAME"].Visible = true;
            GridPurchase.Columns["TRADE_PRICE"].Visible = true;
            GridPurchase.Columns["Quantity"].Visible = true;
            GridPurchase.Columns["PRICE"].Visible = true;
            GridPurchase.Columns["AMOUNT"].Visible = true;

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
            GridPurchase.Columns["SKU_NAME"].Width = 345;
            GridPurchase.Columns["Price"].Width = 99;
            GridPurchase.Columns["TRADE_PRICE"].Width = 99;
            GridPurchase.Columns["QUANTITY"].Width = 99;
            GridPurchase.Columns["AMOUNT"].Width = 99;
            GridPurchase.Columns["EDIT"].Width = 45;
            GridPurchase.Columns["DELETE"].Width = 47;

            //Set COlumns Index
            GridPurchase.Columns["SKU_NAME"].DisplayIndex = 0;
            GridPurchase.Columns["QUANTITY"].DisplayIndex = 1;
            GridPurchase.Columns["Price"].DisplayIndex = 2;
            GridPurchase.Columns["TRADE_PRICE"].DisplayIndex = 3;
            GridPurchase.Columns["AMOUNT"].DisplayIndex = 4;
            GridPurchase.Columns["EDIT"].DisplayIndex = 5;
            GridPurchase.Columns["DELETE"].DisplayIndex = 6;

            // Set Text Alignment
            GridPurchase.Columns["SKU_NAME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion

        #region Add Button Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtQuantity.TextLength == 0 || txtQuantity.Text == "0") && cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                ToastNotification.Show(this, "Enter Quantity", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if ((txtTradePrice.TextLength == 0 || txtPrice.Text == "0") && cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                ToastNotification.Show(this, "Please Enter Price/TradePrice", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            txtAmount.Text = (Convert.ToDecimal(dc.chkNull_0(txtQuantity.Text)) * Convert.ToDecimal(txtPrice.Text)).ToString();
            /////////////////////////////////////////////////////////////////////////////////////////////////////
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
                decimal mStdDiscount = Math.Round(decimal.Parse(dc.chkNull_0(foundRows[0]["DISTRIBUTOR_DISCOUNT"].ToString())), 2);
                decimal mGSTRate = Math.Round(decimal.Parse(dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString())), 2);
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
                            dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtPrice.Text));//foundRows[0]["TRADE_PRICE"];
                            dr["TRADE_PRICE"] = decimal.Parse(dc.chkNull_0(txtTradePrice.Text));
                            dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            dr["AMOUNT"] = decimal.Parse(dc.chkNull_0(txtPrice.Text)) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            dr["Discount"] = Convert.ToDecimal(dc.chkNull_0(txtDiscountTotal.Text));
                            dr["DiscountType"] = 1;
                            dr["FreeSku"] = 0;

                            PurchaseSKU.Rows.Add(dr);
                        }
                        else
                        {
                            ToastNotification.Show(this, cboxSkuCode.SelectedText + " Current closing Stock is " + CurrentStock.ToString(), CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                            //  txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
                            return;
                        }
                    }
                    else
                    {
                        ToastNotification.Show(this, cboxSkuCode.SelectedText + " Already Exists", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        // txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
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
                        dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtPrice.Text)); // foundRows[0]["TRADE_PRICE"];
                        dr["TRADE_PRICE"] = decimal.Parse(dc.chkNull_0(txtTradePrice.Text));
                        dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                        dr["AMOUNT"] = decimal.Parse(dr["PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                        dr["Discount"] = Convert.ToDecimal(dc.chkNull_0(txtDiscountTotal.Text));
                        dr["DiscountType"] = 1;
                        dr["FreeSku"] = 0;
                    }
                    else
                    {
                        ToastNotification.Show(this, cboxSkuCode.SelectedText + "Current closing Stock is " + CurrentStock.ToString(), CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        // txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
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


        #region Check SKU Stock
        private int CheckStockStatus(int SKU_ID)
        {
            if (cboxDocumentType.SelectedIndex == 2)
            {
                return -1;
            }
            else
            {
                PhaysicalStockController mController = new PhaysicalStockController();
                DataTable dt = mController.SelectSKUClosingStock(int.Parse(cboxDistributor.SelectedValue.ToString()), SKU_ID, "N/A", DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString()) + PrivouseQty + FreePrivousQty >= decimal.Parse(dc.chkNull_0(txtQuantity.Text)))
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
            if (e.KeyCode == Keys.Enter)
            {
                int _SkuID = Convert.ToInt32(cboxSkuCode.SelectedValue.ToString());
                DataTable Dtsku_Price = PController.SelectDataPrice(null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, _SkuID, 6, SessionClass.CurrentWorkDate);
                if (Dtsku_Price.Rows.Count > 0)
                {
                    DataRow[] _foundedRow = Dtsku_Price.Select("SKU_ID =" + _SkuID, "SKU_ID ASC", DataViewRowState.Unchanged);
                    if (_foundedRow.Length > 0)
                    {
                        txtPrice.Text = Math.Round(Convert.ToDecimal(_foundedRow[0].ItemArray[1]), 2).ToString();
                        txtTradePrice.Text = Math.Round(Convert.ToDecimal(_foundedRow[0].ItemArray[2]), 2).ToString();
                    }
                }
            }
        }
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
                        txtPrice.Text = _foundedRow[0].ItemArray[1].ToString();
                        txtTradePrice.Text = _foundedRow[0].ItemArray[2].ToString();
                        txtSkuName.Text = _foundedRow[0].ItemArray[3].ToString();
                        txtQuantity.Focus();
                    }
                }
            }
        }
        #endregion

        #region Common Events
        private void cboxSkuCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = string.Empty;
            txtTradePrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

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
        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            if (cboxDocumentType.SelectedIndex == 0 || cboxDocumentType.SelectedIndex == 2)
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
            foreach (DataRow dr in dtPurchaseDetail.Rows)
            {
                mTotalAmount += decimal.Parse(dr["AMOUNT"].ToString());
            }
            if (cboxDocumentType.SelectedIndex == 0)    //Transfer Out
            {
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxTransferFor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), Math.Round(decimal.Parse(txtDiscountTotal.Text), 2), 0, null, 0, Constants.IntNullValue);
                    return mResult;
                }
                else
                {
                    bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxTransferFor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), Math.Round(decimal.Parse(txtDiscountTotal.Text), 2), null, Constants.DecimalNullValue, 0, Constants.DecimalNullValue);
                    return mResult;
                }
            }
            else if (cboxDocumentType.SelectedIndex == 1)   // Purchase Return
            {
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, Constants.Document_Purchase_Return, null, 0, Constants.IntNullValue);
                    return mResult;
                }
                else
                {
                    bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, null, Constants.DecimalNullValue, Constants.Document_Purchase_Return, Constants.DecimalNullValue);
                    return mResult;
                }
            }
            else if (cboxDocumentType.SelectedIndex == 2)   // Transfer In
            {
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxTransferFor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, 0, null, 0, Constants.IntNullValue);
                    return mResult;
                }
                else
                {
                    bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxTransferFor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, null, Constants.DecimalNullValue, 0, Constants.DecimalNullValue);
                    return mResult;
                }
            }
            else if (cboxDocumentType.SelectedIndex == 3)   // Damage
            {
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, 0, null, 0, Constants.IntNullValue);
                    return mResult;
                }
                else
                {
                    bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, null, Constants.DecimalNullValue, 0, Constants.DecimalNullValue);
                    return mResult;
                }
            }
            else
            {
                if (cboxDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
                {
                    bool mResult = mController.InsertPurchaseDocument(int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, 0, null, 0, Constants.IntNullValue);
                    return mResult;
                }
                else
                {
                    bool mResult = mController.UpdatePurchaseDocument(int.Parse(cboxDocumentNo.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), txtDocumentNumber.Text, Convert.ToInt32(cboxDocumentType.SelectedValue.ToString())
                    , MWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString())
                    , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyno.Text, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), 0, null, Constants.DecimalNullValue, 0, Constants.DecimalNullValue);
                    return mResult;
                }
            }
        }
        #endregion
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormStockRegisterr_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 450, 210);
            groupPanel4.Location = new Point(points[0], points[1]);
        }
    }
}
