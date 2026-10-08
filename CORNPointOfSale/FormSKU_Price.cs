using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;
using OfficeOpenXml;
using System.IO;

namespace CORNPointOfSale
{
    public partial class FormSKU_Price : Form
    {
        DataTable Dtsku_Price;
        readonly SkuController _mSkuController = new SkuController();
        SKUPriceDetailController mPriceController = new SKUPriceDetailController();
        public FormSKU_Price()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormSKU_Price_Load(object sender, EventArgs e)
        {
            txtEffectedDate.Text = SessionClass.CurrentWorkDate.ToString();
            LoadDistributor();
            txtFromdate.Text = Convert.ToDateTime(SessionClass.CurrentWorkDate).ToString("dd-MMM-yyyy");
            try
            {
                ChkDistributorList.SetItemChecked(0, true);
            }
            catch (Exception)
            {
            }
        }
        private void LoadSKUS()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable dt = PController.SelectDataPrice(txtCode.Text, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, 8, Constants.DateNullValue);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "This item may be In Active", "CORN: POS");
                return;
            }
            lblSkuId.Text = dt.Rows[0].Field<int>("SKU_ID").ToString();
            txtSKUName.Text = dt.Rows[0].Field<string>("SKU_NAME").ToString();
            LoadGrid(Convert.ToInt32(lblSkuId.Text));
        }
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            //DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, 2, 1);
            //clsWebFormUtil.FillListBox(ChkDistributorList, dt, 0, 2, true);
            ChkDistributorList.DataSource = dt;
            ChkDistributorList.DisplayMember = "DISTRIBUTOR_NAME";
            ChkDistributorList.ValueMember = "DISTRIBUTOR_ID";
        }
        private void LoadGrid(int SKUID)
        {
            SKUPriceDetailController mSKUController = new SKUPriceDetailController();
            DataTable dtsku = mSKUController.SelectSKuCurrentPrice(Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SKUID);
            Grid_pricedetails.DataSource = dtsku;
            ArrangeGrid();
        }
        #endregion

        #region Arrang Grid
        public void ArrangeGrid()
        {
            foreach (DataGridViewColumn _clm in Grid_pricedetails.Columns)
            {
                _clm.Visible = false;
            }
            Grid_pricedetails.Columns["distributor_name"].Visible = true;
            Grid_pricedetails.Columns["SKU_CODE"].Visible = true;
            Grid_pricedetails.Columns["sku_name"].Visible = true;
            Grid_pricedetails.Columns["GST_ON"].Visible = true;
            Grid_pricedetails.Columns["DISTRIBUTOR_PRICE"].Visible = true;
            Grid_pricedetails.Columns["TRADE_PRICE"].Visible = true;
            Grid_pricedetails.Columns["DATE_EFFECTED"].Visible = true;

            // Names
            Grid_pricedetails.Columns["distributor_name"].HeaderText = "Location";
            Grid_pricedetails.Columns["SKU_CODE"].HeaderText = "Item Code";
            Grid_pricedetails.Columns["sku_name"].HeaderText = "Item Name";
            Grid_pricedetails.Columns["GST_ON"].HeaderText = "GST On";
            Grid_pricedetails.Columns["DISTRIBUTOR_PRICE"].HeaderText = "Purchase Price";
            Grid_pricedetails.Columns["TRADE_PRICE"].HeaderText = "Trade Price";
            Grid_pricedetails.Columns["DATE_EFFECTED"].HeaderText = "Effected Date";

            // Width
            Grid_pricedetails.Columns["distributor_name"].Width = 120;
            Grid_pricedetails.Columns["SKU_CODE"].Width = 100;
            //Grid_pricedetails.Columns["sku_name"].Width = 550;
            Grid_pricedetails.Columns["GST_ON"].Width = 50;
            Grid_pricedetails.Columns["DISTRIBUTOR_PRICE"].Width = 100;
            Grid_pricedetails.Columns["TRADE_PRICE"].Width = 100;
            Grid_pricedetails.Columns["DATE_EFFECTED"].Width = 100;
            Grid_pricedetails.Columns["sku_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.TextLength == 0)
            {
                txtCode.Focus();
                return;
            }
            try
            {
                int SKUID = Convert.ToInt32(lblSkuId.Text);
            }
            catch (Exception)
            {
                return;
            }
            if (btnSave.Text == "Save")
            {
                DataControl dc = new DataControl();
                int count = 0;
                int SKUID = Convert.ToInt32(lblSkuId.Text);
                string result = null;
                DateTime effectedDate = SessionClass.CurrentWorkDate;
                try
                {
                    effectedDate = Convert.ToDateTime(txtEffectedDate.Text);
                }
                catch (Exception)
                {}
                for (int i = 0; i < ChkDistributorList.Items.Count; i++)
                {
                    if (ChkDistributorList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        count++;
                        DataRowView drv = (DataRowView)ChkDistributorList.Items[i];
                        int _DistributorID = Convert.ToInt32(drv["DISTRIBUTOR_ID"]);
                        result = mPriceController.InsertSKU_PRICES(_DistributorID, SKUID, 1, decimal.Parse(dc.chkNull_0(txtDistributorPrice.Text)), decimal.Parse(dc.chkNull_0(txtTaxPrices.Text)), decimal.Parse(dc.chkNull_0(txtDistributorPrice.Text)), decimal.Parse(dc.chkNull_0(txtTradePrice.Text)), 0, effectedDate, 0, Constants.DecimalNullValue);
                        LoadGrid(SKUID);
                    }
                }

                if (count == 0)
                {
                    ToastNotification.Show(this, "Select Location Please", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
                if (result != null)
                {
                    ClearAll();
                }
            }
            lblSkuId.Text = "null";
        }
        #endregion

        #region Common Functions

        #region Clear All
        private void ClearAll()
        {
            txtCode.Text = "";
            txtSKUName.Text = "";
            //txtRetailPrice.Text = "";
            txtTradePrice.Text = "";
            txtDistributorPrice.Text = "";
            txtTaxPrices.Text = "";
        }
        #endregion

        #region Checked List Box Check All Items
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkDistributorList.Items.Count;
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkDistributorList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkDistributorList.SetItemChecked(i, false);
                }
            }
        }
        #endregion

        private void txtDistributorPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }
        #endregion

        
        #region EXCEL SHEET METHODS - IMPORT AND SAMPLE SHEET DOWNLOAD
        private void btnImport_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < ChkDistributorList.Items.Count; i++)
            {
                if (ChkDistributorList.GetItemCheckState(i) == CheckState.Checked)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                ToastNotification.Show(this, "Select Location Please", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }

            string filePath = "";
            
            OpenFileDialog selectedFile = new OpenFileDialog();
            selectedFile.Title = "Browse Excel Sheet file";
            //selectedFile.Filter = "Excel Files (*.xlsx) | *.xlsx | Excel Files (*.xls) | *.xls";

            selectedFile.Filter = "Excel Files (*.xlsx)|*.xlsx|Old Excel Files Format(*.xls)|*.xls";
            selectedFile.CheckFileExists = true;
            selectedFile.CheckPathExists = true;
            if (selectedFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = selectedFile.FileName;
                if (filePath != null && filePath.Length > 0)
                {
                    try
                    {

                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        FileInfo file = new FileInfo(filePath);

                        var package = new ExcelPackage(file);

                        ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                        var startRow = workSheet.Dimension.Start.Row;
                        var rowEnd = workSheet.Dimension.End.Row;

                        var colStart = workSheet.Dimension.Start.Column;
                        var colEnd = 7;// workSheet.Dimension.End.Column;

                        int totalCols = workSheet.Dimension.End.Column;


                        string log = "";
                        string reason = "";

                        string Id = "";
                        string itemName = "";
                        string itemBarcode = "";
                        DateTime dateEffected = DateTime.Now;
                        string purchPrice = "";
                        string retailPrice = "";
                        string wholesalePrice = "";

                        for (int row = startRow; row < rowEnd; row++)
                        { // Row by row...

                            reason = "";
                            Id = "";
                            itemName = "";
                            itemBarcode = "";
                            dateEffected = DateTime.Now;
                            purchPrice = "";
                            retailPrice = "";
                            wholesalePrice = "";

                            for (int col = colStart; col <= colEnd; col++)
                            { // ... Cell by cell...
                                var cellValue = workSheet.Cells[row + 1, col].Text; // This got me the actual value I needed.

                                if (col == 1)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        Id = cellValue.Trim();
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Id ";
                                        break;
                                    }
                                }
                                else if (col == 4)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        dateEffected = Convert.ToDateTime(cellValue.Trim());
                                    }
                                    else
                                    {
                                        dateEffected = DateTime.Now;
                                    }
                                }
                                else if (col == 5)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        purchPrice = cellValue.Trim();
                                    }
                                    else
                                    {
                                        purchPrice = "0";
                                    }
                                }
                                else if (col == 6)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        retailPrice = cellValue.Trim();
                                    }
                                    else
                                    {
                                        retailPrice = "0";
                                    }
                                }
                                else if (col == 7)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        wholesalePrice = cellValue.Trim();
                                    }
                                    else
                                    {
                                        wholesalePrice = "0";
                                    }
                                }
                            }

                            // update item price
                            if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(purchPrice))
                            {
                                for (int i = 0; i < ChkDistributorList.Items.Count; i++)
                                {
                                    if (ChkDistributorList.GetItemCheckState(i) == CheckState.Checked)
                                    {
                                        DataRowView drv = (DataRowView)ChkDistributorList.Items[i];
                                        int _DistributorID = Convert.ToInt32(drv["DISTRIBUTOR_ID"]);
                                        var result = mPriceController.InsertSKU_PRICES(_DistributorID, Convert.ToInt32(Id), Constants.IntNullValue,
                                            decimal.Parse(purchPrice), 
                                            Constants.DecimalNullValue,
                                            decimal.Parse(purchPrice), 
                                            decimal.Parse(retailPrice), 0, dateEffected, 0, decimal.Parse(wholesalePrice));
                                        
                                    }
                                }
                            }
                        }

                        MessageBox.Show("File uploaded successfully");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong!!!\nError is: " + ex.Message);
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    folderPath = diag.SelectedPath;  //selected folder path
                }
                if (folderPath != null && folderPath.Length > 0)
                {
                    var dataTable = new SKUPriceExcelTemplate();

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage p = new ExcelPackage())
                    {
                        ExcelWorksheet ws = p.Workbook.Worksheets.Add("Items_Price_List");
                        //Rogh sheet to add values from database to this sheet and then using rage add values in
                        //'Items_List' sheet.
                        //ExcelWorksheet roughSheet = p.Workbook.Worksheets.Add("Dummy_List");

                        int index = 1;
                        foreach (var item in dataTable.GetType().GetProperties())
                        {
                            ws.Cells[1, index++].Value = item.Name.Replace('_', ' ').Replace("  ", "_");
                        }
                        var headerCells = ws.Cells[1, 1, 1, ExcelPackage.MaxColumns];
                        var headerFont = headerCells.Style.Font;
                        headerFont.Bold = true;

                        //FILL SHEET FOR all items price
                        var skuPriceList = GetSKUWithPrices();

                        if (skuPriceList != null && skuPriceList.Rows.Count > 0)
                        {
                            int row = 2;
                            foreach (DataRow skup in skuPriceList.Rows)
                            {
                                ws.Cells[row, 1].Value = skup["SKU_ID"];
                                ws.Cells[row, 2].Value = skup["SKU_NAME"];
                                ws.Cells[row, 3].Value = skup["SKU_CODE"];
                                ws.Cells[row, 4].Value = skup["DATE_EFFECTED"];
                                ws.Cells[row, 5].Value = skup["PURCHASE_PRICE"];
                                ws.Cells[row, 6].Value = skup["RETAIL_PRICE"];
                                ws.Cells[row, 7].Value = skup["WHOLESALE_PRICE"];
                                ws.Cells[row, 8].Value = skup["SECTION"];
                                ws.Cells[row, 9].Value = skup["CATEGORY"];
                                ws.Cells[row, 10].Value = skup["BRAND"];

                                row++;
                            }
                        }

                        Byte[] fileBytes = p.GetAsByteArray();

                        if (SaveDataToFile(folderPath, fileBytes))
                        {
                            MessageBox.Show("File is saved successfully on the selected folder path");
                        }
                        else
                        {
                            MessageBox.Show("File cannot be saved");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!!");
            }
        }

        protected bool SaveDataToFile(string folderPath, byte[] Data)
        {
            BinaryWriter Writer = null;
            string fileNameAndPath = @"" + folderPath + "\\items_price_list_" + DateTime.Now.ToString("dd_mm_yyyy_HH_mm") + ".xlsx";

            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(fileNameAndPath));
                // Writer raw data                
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public DataTable GetSKUWithPrices()
        {
            return _mSkuController.SelectSkuPriceExcel(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.CompanyID);
        }

        //public void GenerateExportPreFilledDropDown(ExcelWorksheet ws, ExcelWorksheet roughSheet, ExcelPackage p)
        //{
        //    string startFrom = "";
        //    string startTo = "";

        //    roughSheet.Cells["A1"].Value = "Section";

        //    var headerCells = roughSheet.Cells[1, 1, 1, ExcelPackage.MaxColumns];
        //    var headerFont = headerCells.Style.Font;
        //    headerFont.Bold = true;

        //    //SECTIONS DROPDOWN
        //    DataTable sectionsData = null;//_mHerController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

        //    if (sectionsData != null && sectionsData.Rows.Count > 0)
        //    {
        //        var count = 1;
        //        foreach (DataRow row in sectionsData.Rows)
        //        {
        //            roughSheet.Cells[count + 1, 1].Value = row["SKU_HIE_NAME"].ToString();
        //            count++;
        //        }

        //        //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
        //        //First sheet catgories into drop down.
        //        var range = ExcelRange.GetAddress(2, 1, ExcelPackage.MaxRows, 1);
        //        var sectionListInExcelDropDown = ws.DataValidations.AddListValidation(range);

        //        //Get range of values in category from dummy list sheet.
        //        startFrom = roughSheet.Cells[2, 1].ToString();
        //        startTo = roughSheet.Cells[count, 1].ToString();

        //        startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
        //        startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

        //        //Get range of values in category from dummy list sheet.
        //        var roughSheetSectionRange = startFrom + ":" + startTo;
        //        sectionListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetSectionRange.ToString();
        //    }

        //    //CATEGORY DROPDOWN
        //    DataTable categoryData = null;//_mHerController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

        //    roughSheet.Cells["B1"].Value = "Category";

        //    if (categoryData != null && categoryData.Rows.Count > 0)
        //    {
        //        var count = 1;
        //        foreach (DataRow row in categoryData.Rows)
        //        {
        //            roughSheet.Cells[count + 1, 2].Value = row["SKU_HIE_NAME"].ToString();
        //            count++;
        //        }
        //        //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
        //        //First sheet catgories into drop down.
        //        var range = ExcelRange.GetAddress(2, 2, ExcelPackage.MaxRows, 2);
        //        var catListInExcelDropDown = ws.DataValidations.AddListValidation(range);

        //        //Get range of values in category from dummy list sheet.
        //        startFrom = roughSheet.Cells[2, 2].ToString();
        //        startTo = roughSheet.Cells[count, 2].ToString();

        //        startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
        //        startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

        //        var roughSheetCatRange = startFrom + ":" + startTo;
        //        catListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetCatRange.ToString();
        //    }

        //    //BRAND DROPDOWN
        //    DataTable brandData = null;//_mHerController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

        //    roughSheet.Cells["C1"].Value = "Brand";

        //    if (brandData != null && brandData.Rows.Count > 0)
        //    {
        //        var count = 1;
        //        foreach (DataRow row in brandData.Rows)
        //        {
        //            roughSheet.Cells[count + 1, 3].Value = row["SKU_HIE_NAME"].ToString();
        //            count++;
        //        }
        //        //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
        //        //First sheet catgories into drop down.
        //        var range = ExcelRange.GetAddress(2, 3, ExcelPackage.MaxRows, 3);
        //        var brandListInExcelDropDown = ws.DataValidations.AddListValidation(range);

        //        //Get range of values in category from dummy list sheet.
        //        startFrom = roughSheet.Cells[2, 3].ToString();
        //        startTo = roughSheet.Cells[count, 3].ToString();

        //        startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
        //        startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

        //        var roughSheetBrandRange = startFrom + ":" + startTo;
        //        brandListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetBrandRange.ToString();
        //    }

        //    roughSheet.Cells["D1"].Value = "GST_ON";

        //    string[] arrGST = { "Taxable", "Retail (Third Schedule)", "Exempted" };

        //    if (arrGST != null && arrGST.Length > 0)
        //    {
        //        var count = 1;
        //        for (int i = 0; i < arrGST.Length; i++)
        //        {
        //            roughSheet.Cells[count + 1, 4].Value = arrGST[i];
        //            count++;
        //        }
        //        //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
        //        //First sheet catgories into drop down.
        //        var range = ExcelRange.GetAddress(2, 8, ExcelPackage.MaxRows, 8);
        //        var gstListInExcelDropDown = ws.DataValidations.AddListValidation(range);

        //        //Get range of values in category from dummy list sheet.
        //        startFrom = roughSheet.Cells[2, 4].ToString();
        //        startTo = roughSheet.Cells[count, 4].ToString();

        //        startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
        //        startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

        //        var roughSheetGstRange = startFrom + ":" + startTo;
        //        gstListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetGstRange.ToString();
        //    }

        //    //UOM DROPDOWN
        //    DataTable uomData = null;//_mSkuController.SelectUOMs(Constants.IntNullValue, null);
        //    roughSheet.Cells["E1"].Value = "Brand";

        //    if (uomData != null && uomData.Rows.Count > 0)
        //    {
        //        var count = 1;
        //        foreach (DataRow row in uomData.Rows)
        //        {
        //            roughSheet.Cells[count + 1, 5].Value = row["UOM_DESC"].ToString();
        //            count++;
        //        }
        //        //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
        //        //First sheet catgories into drop down.
        //        var range = ExcelRange.GetAddress(2, 6, ExcelPackage.MaxRows, 6);
        //        var uomListInExcelDropDown = ws.DataValidations.AddListValidation(range);

        //        //Get range of values in category from dummy list sheet.
        //        startFrom = roughSheet.Cells[2, 5].ToString();
        //        startTo = roughSheet.Cells[count, 5].ToString();

        //        startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
        //        startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

        //        var roughSheetUomRange = startFrom + ":" + startTo;
        //        uomListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetUomRange.ToString();
        //    }

        //    //Hide Dummy Sheet
        //    roughSheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;

        //}

        #endregion

        private void FormSKU_Price_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 535, 190);
            groupPanel3.Location = new Point(points[0], points[1]);
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                lblSkuId.Text = "null";
                DataControl dc = new DataControl();
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCode.Text.Trim().Length > 0)
                    {
                        string SelectedText = txtCode.Text.Trim();
                        if (SelectedText.Contains("-"))
                        {
                            txtCode.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
                            if (SelectedText.Contains(":"))
                            {
                                txtSKUName.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in Dtsku_Price.Rows)
                            {
                                if (dr["SKU_CODE"].ToString() == txtCode.Text.Trim())
                                {
                                    txtSKUName.Text = dr["SKU_NAME"].ToString();
                                    txtDistributorPrice.Focus();
                                    break;
                                }
                            }
                        }
                        if (chkByName.Checked)
                        {
                            txtCode.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                            txtSKUName.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
                        }
                        DataRow[] drs = Dtsku_Price.Select("SKU_CODE = '" + txtCode.Text.Trim() + "'    ");
                        try
                        {
                            lblSkuId.Text = drs[0]["SKU_ID"].ToString();
                            LoadGrid(Convert.ToInt32(lblSkuId.Text));
                        }
                        catch (Exception ex)
                        {
                            ExceptionPublisher.PublishException(ex);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void LoadProducts()
        {
            try
            {
                FormWaiting._Type = 0;
                FormWaiting _frmW8 = new FormWaiting();
                _frmW8.ShowDialog();
                //SkuController SKUCtl = new SkuController();
                //Dtsku_Price = SKUCtl.SearchProduct(null, 4, SessionClass.DISTRIBUTOR_ID);
                Dtsku_Price = SessionClass.dtLoadPOSItems;
                BindProducts(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Error in LoadProducts");
            }
        }
        public void BindProducts(int typeId)
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            if (typeId == 0)
            {
                foreach (DataRow dr in Dtsku_Price.Rows)
                {
                    acsc.Add(dr["SkuDetail"].ToString());
                }
            }
            else
            {
                foreach (DataRow dr in Dtsku_Price.Rows)
                {
                    acsc.Add(dr["SkuDetail1"].ToString());
                }
            }
            txtCode.AutoCompleteCustomSource = acsc;
            txtCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void FormSKU_Price_Shown(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSKUName_MouseDown(object sender, MouseEventArgs e)
        {
            txtCode.Focus();
        }

        private void chkByName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByName.Checked == false)
            {
                BindProducts(0);
            }
            else
            {
                BindProducts(1);
            }
            txtCode.Focus();
        }
    }
}
