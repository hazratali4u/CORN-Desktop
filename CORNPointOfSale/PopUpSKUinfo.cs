using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.IO;

namespace CORNPointOfSale
{
    public partial class PopUpSKUinfo : Form
    {
        public static int _Catagoryvalue { get; set; }
        public static int _Sectionvalue { get; set; }
        public static int _Brandvalue { get; set; }
        public static int _Uomvalue { get; set; }
        public static int _GSTvalue { get; set; }
        //public static int _UIMvalue { get; set; }
        public static int _SKUid { get; set; }
        public static int _MinLevel { get; set; }
        public static int _MaxLevel { get; set; }
        readonly SkuController _mSkuController = new SkuController();
        readonly SkuHierarchyController _mHerController = new SkuHierarchyController();

        readonly DataControl _dc = new DataControl();
        private DataTable _mDt, _mSkuDt, _mSkuDt2;
        private static int _mSkuId;
        public static char _GstOn { get; set; }

        public static string _bar_code { get; set; }

        public PopUpSKUinfo()
        {
            InitializeComponent();
        }

        #region Common Functions
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Load Functions

        private void PopUpSKUinfo_Load(object sender, EventArgs e)
        {
            btnImportData.Visible = false;
            LoadSKUSection();
            LoadSKUBrand();
            LoadSKUCategory();
            LoadUom();
            GetGstOn();
            if (txtMaxLevel.TextLength == 0)
            {
                txtMaxLevel.Text = "0";
            }
            if (txtMinLevel.TextLength == 0)
            {
                txtMinLevel.Text = "0";
            }
            if (txtReorderLevel.TextLength == 0)
            {
                txtReorderLevel.Text = "0";
            }
            if (btnSave.Text == "Save")
            {
                txtBarcode.Enabled = true;
                chkAuto.Enabled = true;
                txtEffectedDate.Text = SessionClass.CurrentWorkDate.ToString();
            }
            else if (btnSave.Text == "Update")
            {
                //txtBarcode.Enabled = false;
                //chkAuto.Enabled = false;
                if(_bar_code == "Auto")
                {
                    chkAuto.Enabled = false;
                    chkAuto.Checked = true;
                }
            }
        }
        public void GetGstOn()
        {
            if (_GstOn == 'E')
            {
                cboxGSTon.SelectedIndex = 2;
            }
            if (_GstOn == 'R')
            {
                cboxGSTon.SelectedIndex = 1;
            }
            if (_GstOn == 'T')
            {
                cboxGSTon.SelectedIndex = 0;
            }
            else
            {
                cboxGSTon.SelectedIndex = 2;
            }
        }

        private void LoadSKUCategory()
        {
            try
            {
                _mDt = _mHerController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Convert.ToInt32(cboxItemSection.SelectedValue.ToString()), null, null, true, SessionClass.CompanyID);
                cboxItemCatagory.DataSource = _mDt;
                cboxItemCatagory.ValueMember = "SKU_HIE_ID";
                cboxItemCatagory.DisplayMember = "SKU_HIE_NAME";
                if (_Catagoryvalue > 0)
                {
                    cboxItemCatagory.SelectedValue = _Catagoryvalue;
                }
            }
            catch (Exception exc) 
            {
            }
        }
        private void LoadSKUSection()
        {
            _mDt = _mHerController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            cboxItemSection.DataSource = _mDt;
            cboxItemSection.ValueMember = "SKU_HIE_ID";
            cboxItemSection.DisplayMember = "SKU_HIE_NAME";
            if (_Sectionvalue > 0)
            {
                cboxItemSection.SelectedValue = _Sectionvalue;
            }
        }
        private void LoadSKUBrand()
        {
            _mDt = _mHerController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            cboxItemBrand.DataSource = _mDt;
            cboxItemBrand.ValueMember = "SKU_HIE_ID";
            cboxItemBrand.DisplayMember = "SKU_HIE_NAME";
            if (_Brandvalue > 0)
            {
                cboxItemBrand.SelectedValue = _Brandvalue;
            }
        }
        private void LoadUom()
        {
            DataTable dtUoMs = _mSkuController.SelectUOMs(Constants.IntNullValue, null);
            cboxUnitMeasure.DataSource = dtUoMs;
            cboxUnitMeasure.ValueMember = "UOM_ID";
            cboxUnitMeasure.DisplayMember = "UOM_DESC";
            if (_Uomvalue > 0)
            {
                cboxUnitMeasure.SelectedValue = _Uomvalue;
            }
        }
        #endregion

        #region Button Save or Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboxItemSection.Items.Count == 0)
            {
                MessageBox.Show(this, "Select Section", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboxItemCatagory.Items.Count == 0)
            {
                MessageBox.Show(this, "Select Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboxItemBrand.Items.Count == 0)
            {
                MessageBox.Show(this, "Select Brand", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboxUnitMeasure.Items.Count == 0)
            {
                MessageBox.Show(this, "Select UOM", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMinLevel.TextLength == 0)
            {
                txtMinLevel.Text = "0";
            }
            if (txtMaxLevel.TextLength == 0)
            {
                txtMaxLevel.Text = "0";
            }
            if (txtReorderLevel.TextLength == 0)
            {
                txtReorderLevel.Text = "0";
            }
            string _barcodeType;
            if (chkAuto.Checked)
            {
                _barcodeType = "Auto";
            }
            else
            {
                _barcodeType = "Manual";
            }
            string _gstOn = cboxGSTon.SelectedItem.ToString();
            if (txtBarcode.Text == "")
            {
                ToastNotification.Show(this, "Please Enter Item Barcode", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtItemName.Text == "")
            {
                ToastNotification.Show(this, "Please Enter Item Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtRetailPrice.Text == "" || txtRetailPrice.Text == "0")
            {
                ToastNotification.Show(this, "Please Enter Retail Price", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtPurchasePrice.Text == "" || txtPurchasePrice.Text == "0")
            {
                ToastNotification.Show(this, "Please Enter Purchase Price", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            int UIC = 1;
            try
            {
                if (txtUnitinCase.TextLength == 0 || txtUnitinCase.Text.Trim() == "0")
                {
                    UIC = 1;
                }
                else
                {
                    UIC = int.Parse(txtUnitinCase.Text.Trim());
                }
            }
            catch
            {
                ToastNotification.Show(this, "Only numbers allowed in Unit in Case", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }


            //string _ConCatcode = "";
            //if (_barcodeType == "Auto")
            //{
            //    _ConCatcode = ConcatinateCode(txtBarcode.Text.Trim());
            //}
            //else
            //{
            //    _ConCatcode = txtBarcode.Text.Trim();
            //}
            //string UiC;
            //if (txtUnitinCase.TextLength == 0 || txtUnitinCase.Text == "0")
            //{
            //    UiC = "1";
            //}
            //else
            //{
            //    UiC = txtUnitinCase.Text;
            //}
            DateTime effectedDate = SessionClass.CurrentWorkDate;
            try
            {
                effectedDate = Convert.ToDateTime(txtEffectedDate.Text);
            }
            catch (Exception)
            { }
            decimal ws_quantity = Constants.DecimalNullValue;
            if (DataControl.chkDecimalNull(txtWholesalePrice.Text) != Constants.DecimalNullValue && DataControl.chkDecimalNull(txtWholesalePrice.Text) > 0)
            {
                ws_quantity = DataControl.chkDecimalNull(txtWsQuantity.Text);
            }
            switch (btnSave.Text)
            {
                case "Save":
                    if (CheckDuplicateSkuBarcode())
                    {
                        DataControl dc = new DataControl();
                        string result = _mSkuController.InsertSKUS2(true, true, char.Parse(_gstOn[0].ToString()), DataControl.chkIntNull_0(cboxItemSection.SelectedValue.ToString()), 0, int.Parse(cboxItemCatagory.SelectedValue.ToString()), int.Parse(cboxItemBrand.SelectedValue.ToString()), Constants.IntNullValue, 0, 0, UIC+"", txtBarcode.Text.Trim(), txtItemName.Text, null, txtSize.Text, SessionClass.UserID, SessionClass.CompanyID, _barcodeType, null, 0, "", "", Convert.ToInt32(txtMinLevel.Text), Convert.ToInt32(txtMaxLevel.Text), Convert.ToInt32(txtReorderLevel.Text), Convert.ToInt32(SessionClass.DISTRIBUTOR_ID), decimal.Parse(dc.chkNull_0(txtPurchasePrice.Text)), decimal.Parse(dc.chkNull_0(txtRetailPrice.Text)), decimal.Parse(dc.chkNull_0(txtWholesalePrice.Text)), decimal.Parse(dc.chkNull_0(txtGSTPrice.Text)), effectedDate, 0, ws_quantity, int.Parse(cboxUnitMeasure.SelectedValue.ToString()));
                        if (result != null)
                        {
                            ToastNotification.Show(this, "Added Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Green, eToastPosition.MiddleCenter);
                        }
                        else
                        {
                            ToastNotification.Show(this, "Some Error Occured", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        }
                        ClearAll();
                    }
                    else
                    {
                        ToastNotification.Show(this, "Item already exist of this Barcode", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    }
                    break;
                case "Update":
                    if (CheckDuplicateSkuBarcodeForUpdate())
                    {
                        DataControl dc = new DataControl();
                        string str = _mSkuController.UpdateSKUS2(true, true, char.Parse(_gstOn[0].ToString()), DataControl.chkIntNull_0(cboxItemSection.SelectedValue.ToString()), 0, int.Parse(cboxItemCatagory.SelectedValue.ToString()), int.Parse(cboxItemBrand.SelectedValue.ToString()), Constants.IntNullValue, 0, 0, UIC+"", _SKUid, txtBarcode.Text.Trim(), txtItemName.Text,"A", txtSize.Text, SessionClass.UserID, SessionClass.CompanyID, _barcodeType, null, 0, "", "", Convert.ToInt32(txtMinLevel.Text), Convert.ToInt32(txtMaxLevel.Text), Convert.ToInt32(txtReorderLevel.Text), Convert.ToInt32(SessionClass.DISTRIBUTOR_ID), decimal.Parse(dc.chkNull_0(txtPurchasePrice.Text)), decimal.Parse(dc.chkNull_0(txtRetailPrice.Text)), decimal.Parse(dc.chkNull_0(txtWholesalePrice.Text)), decimal.Parse(dc.chkNull_0(txtGSTPrice.Text)), effectedDate, 0, ws_quantity, int.Parse(cboxUnitMeasure.SelectedValue.ToString()));
                        if (str != null)
                        {
                            ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Green, eToastPosition.MiddleCenter);
                        }
                        else
                        {
                            ToastNotification.Show(this, "Some Error Occured", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                        }
                        ClearAll();
                        this.Hide();
                    }
                    else
                    {
                        ToastNotification.Show(this, "Item already exist of this Barcode and Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    }
                    break;
            }
            txtItemName.Focus();
            chkAuto_CheckedChanged(null, null);
        }
        #endregion

        #region Clear All
        private void ClearAll()
        {
            txtSize.Text = "";
            txtUnitinCase.Text = "";
            txtItemName.Text = "";
            txtBarcode.Text = "";
            btnSave.Text = "Save";
            txtGSTPrice.Text = "";
            txtReorderLevel.Text = "";
            txtPurchasePrice.Text = "";
            txtRetailPrice.Text = "";
            txtWholesalePrice.Text = "";
            FormSKU_Information _formSkuInfo = Application.OpenForms["FormSKU_Information"] as FormSKU_Information;
            _formSkuInfo.LoadData();
            txtBarcode.Focus();            
        }
        #endregion

        #region Check Duplicate SKU
        private bool CheckDuplicateSkuBarcode()
        {
            string _Type = "Auto";
            if (chkAuto.Checked == false)
            {
                _Type = "Manual";
            }
            _mSkuDt2 = _mSkuController.SearchProduct(txtBarcode.Text.Trim(), 7);
            if (_mSkuDt2.Rows.Count > 0)
            {
                DataRow[] foundRows = _mSkuDt2.Select("SKU_CODE ='" + txtBarcode.Text + "' AND BAR_CODE = '" + _Type + "' ");
                if (foundRows.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        private bool CheckDuplicateSkuBarcodeForUpdate()
        {
            _mSkuDt2 = _mSkuController.SearchProduct(txtBarcode.Text.Trim(), 7);
            if (_mSkuDt2.Rows.Count > 0)
            {
                var foundRows = _mSkuDt2.Select("SKU_CODE ='" + txtBarcode.Text + "' AND SKU_ID <> '" + _SKUid + "'");
                if (foundRows.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }            
        }
        #endregion
        private void txtMinLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void txtMaxLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked && chkAuto.Enabled)
            {
                txtBarcode.Enabled = false;
                txtBarcode.Text = GetMaxValueBarcode().ToString();
            }
            else if(chkAuto.Enabled)
            {
                txtBarcode.Enabled = true;
                txtBarcode.Text = "";
            }
        }
        public string AddZerosInManualBarcode(string _code)
        {
            int _length = 13 - (_code.Length);
            for (int i = 0; i < _length; i++)
            {
                _code = "0" + _code;
            }
            return _code;
        }
        public string GetMaxValueBarcode()
        {
            SkuController _controller = new SkuController();
            string _barcode = _controller.SelectMaxBarcode();
            string newBarCode = (Convert.ToDecimal(_barcode) + 1) + "";

            return AddZerosInManualBarcode(newBarCode);
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //clsWindowsFormUtil.InputNum(e);
        }

        private void btnPrintbarcode_Click(object sender, EventArgs e)
        {
            if (txtBarcode.TextLength == 0)
            {
                MessageBox.Show("Please Enter Barcode", "CORN: POS");
                return;
            }
            if (txtItemName.TextLength == 0)
            {
                MessageBox.Show("Please Enter Item Name", "CORN: POS");
                return;
            }
            if (txtRetailPrice.TextLength == 0 || txtRetailPrice.Text == "0")
            {
                MessageBox.Show("Please Enter Retail Price", "CORN: POS");
                return;
            }
            FormPopUp _popUp = new FormPopUp();
            _popUp._itemCode = txtBarcode.Text;
            _popUp._itemName = txtItemName.Text + "_" + txtSize.Text;
            _popUp._itemPrice = Convert.ToDecimal(txtRetailPrice.Text);
            _popUp.ShowDialog();
        }

        private void cboxGSTon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gst = cboxGSTon.SelectedItem.ToString();
            if (gst.Equals("Exempted"))
            {
                txtGSTPrice.ReadOnly = true;
                txtGSTPrice.Text = "0";
            }
            else
            {
                txtGSTPrice.ReadOnly = false;
            }
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            btnImportData.Text = "Wait...";
            btnImportData.Enabled = false;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (.txt)|*.txt";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = dlg.FileName;
                    string path = System.IO.Path.GetFullPath(filename);

                    int count = 0;
                    string modal = null;
                    System.Collections.ArrayList listModal = new System.Collections.ArrayList();
                    FileStream Sourcefile = null;
                    StreamReader ReadSourceFile = null;
                    Sourcefile = new FileStream(path, FileMode.Open);
                    ReadSourceFile = new StreamReader(Sourcefile);

                    string FileContents = "";
                    while ((FileContents = ReadSourceFile.ReadLine()) != null)
                    {
                        string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                        modal = ParametersArr[1];
                        listModal.Add(modal);
                        count++;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        int count_item = 0;
                        for (int j = 0; j < count; j++)
                        {
                            if (listModal[j].ToString() == listModal[i].ToString())
                            {
                                count_item++;
                                if (count_item > 1)
                                {
                                    MessageBox.Show(this, "You have duplicate barcode in file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ReadSourceFile.Close();
                                    Sourcefile.Close();
                                    return;
                                }
                            }
                        }
                    }

                    ReadSourceFile.Close();
                    Sourcefile.Close();
                    SKUPriceDetailController SKUPriceCtl = new SKUPriceDetailController();
                    bool result = SKUPriceCtl.ImportSKUWithPrices(SessionClass.DISTRIBUTOR_ID, SessionClass.CompanyID, SessionClass.UserID, path);
                    if (result)
                    {
                        MessageBox.Show(this, "Items Import Successfuly", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Hide();
                        FormSKU_Information _formSkuInfo = Application.OpenForms["FormSKU_Information"] as FormSKU_Information;
                        _formSkuInfo.LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Some Error Occured", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                catch (Exception excp)
                {
                    ExceptionPublisher.PublishException(excp);
                    MessageBox.Show(this, "Error: \n" + excp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btnImportData.Text = "Import";
            btnImportData.Enabled = true;
        }

        private void cboxItemSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSKUCategory();
        }
    }
}
