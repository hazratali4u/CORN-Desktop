using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using System.IO;

namespace CORNPointOfSale
{
    public partial class FormSKU_Information : Form
    {
        readonly SkuController _mSkuController = new SkuController();
        readonly SkuHierarchyController _mHerController = new SkuHierarchyController();
        readonly DataControl _dc = new DataControl();
        private DataTable _mDt, _mSkuDt, _mSkuDt2;
        private static int _mSkuId;
        public FormSKU_Information()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormSKU_Information_Load(object sender, EventArgs e)
        {
            LoadData();
            //LoadGrid();
        }
        private void LoadGrid()
        {
            var dt = _mSkuController.SelectSkuInfo3(Constants.IntNullValue, null, null);
            GridSKUinfo.DataSource = dt;
        }


        public void LoadData()
        {
            _mSkuDt = _mSkuController.SelectSkuInfo2(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.CompanyID, 0);
            if (_mSkuDt != null)
            {
                ClassSession.dtSKUdata = _mSkuDt;
                GridSKUinfo.DataSource = null;
                GridSKUinfo.Rows.Clear();
                GridSKUinfo.DataSource = _mSkuDt;
                ArrangeGrid();
            }
        }
        #endregion

        #region Arrange Data Grid View
        protected void ArrangeGrid()
        {
            try
            {
                GridSKUinfo.Columns.Remove("Edit");
                GridSKUinfo.Columns.Remove("Select");
                GridSKUinfo.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }
            foreach (DataGridViewColumn clms in GridSKUinfo.Columns)
            {
                clms.Visible = false;
            }

            // set Visible Columns
            //GridSKUinfo.Columns["SKU_ID"].Visible = true;
            GridSKUinfo.Columns["SKU_NAME"].Visible = true;
            GridSKUinfo.Columns["Principal"].Visible = true;
            GridSKUinfo.Columns["Category"].Visible = true;
            GridSKUinfo.Columns["Brand"].Visible = true;
            GridSKUinfo.Columns["UOM_DESC"].Visible = true;
            //GridSKUinfo.Columns["SKU_HIE_NAME"].Visible = true;
            // GridSKUinfo.Columns["BAR_CODE"].Visible = true;
            GridSKUinfo.Columns["SKU_CODE"].Visible = true;
            GridSKUinfo.Columns["UNITS_IN_CASE"].Visible = true;

            // Set Columns Header Text
            GridSKUinfo.Columns["SKU_NAME"].HeaderText = "Item Name";
            GridSKUinfo.Columns["Principal"].HeaderText = "Section";
            GridSKUinfo.Columns["Category"].HeaderText = "Category";
            GridSKUinfo.Columns["Brand"].HeaderText = "Brand";
            GridSKUinfo.Columns["UNITS_IN_CASE"].HeaderText = "Units in Case";
            GridSKUinfo.Columns["UOM_DESC"].HeaderText = "UOM";
            GridSKUinfo.Columns["SKU_CODE"].HeaderText = "Barcode";

            //
            //
            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridSKUinfo.Columns.Add(btnEdit);
            //
            //
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.ReadOnly = false;
            GridSKUinfo.Columns.Add(checkColumn);
            GridSKUinfo.Columns["Select"].DisplayIndex = 0;
            GridSKUinfo.Columns["Select"].HeaderText = "";
            //
            //
            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "Status";
            GridSKUinfo.Columns.Add(activeClm);
            GridSKUinfo.Columns["activeClm"].DisplayIndex = GridSKUinfo.Columns["Edit"].Index - 1;
            GridSKUinfo.Columns["activeClm"].Width = 90;

            // Set Active and In Active Text
            int _rows = GridSKUinfo.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridSKUinfo.Rows[i].Cells["ISACTIVE"].Value) == true)
                {
                    GridSKUinfo.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridSKUinfo.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }

            // Width
            GridSKUinfo.Columns["Select"].Width = 50;
            GridSKUinfo.Columns["SKU_NAME"].Width = 650;
            GridSKUinfo.Columns["PACKSIZE"].Width = 120;
            GridSKUinfo.Columns["UNITS_IN_CASE"].Width = 120;
            GridSKUinfo.Columns["SKU_CODE"].Width = 120;
            GridSKUinfo.Columns["activeClm"].Width = 90;
            GridSKUinfo.Columns["Edit"].Width = 70;

            GridSKUinfo.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridSKUinfo.Columns["activeClm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridSKUinfo.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn clms in GridSKUinfo.Columns)
            {
                clms.ReadOnly = true;
            }
            GridSKUinfo.Columns["Select"].ReadOnly = false;

        }
        #endregion

        #region SActive in Active
        private void btnActive_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridSKUinfo, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridSKUinfo.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            string result = _mSkuController.UpdateSKUS(false, false, Constants.CharNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,
                             Constants.DecimalNullValue, Constants.DecimalNullValue, null, int.Parse(GridSKUinfo.Rows[dr.Index].Cells["SKU_ID"].Value.ToString()), null, null, "B", null, SessionClass.UserID, SessionClass.CompanyID);
                        }
                    }
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    GridSKUinfo.Columns.Remove("Edit");
                    GridSKUinfo.Columns.Remove("Select");
                    GridSKUinfo.Columns.Remove("activeClm");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region EXCEL SHEET METHODS - IMPORT AND SAMPLE SHEET DOWNLOAD
        private void btnImport_Click(object sender, EventArgs e)
        {
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
                        var colEnd = 17;// workSheet.Dimension.End.Column;

                        int totalCols = workSheet.Dimension.End.Column;

                        DataTable sectionsData = _mHerController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                        DataTable categoryData = _mHerController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                        DataTable brandData = _mHerController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
                        string[] arrGST = { "Taxable", "Retail (Third Schedule)", "Exempted" };
                        DataTable uomData = _mSkuController.SelectUOMs(Constants.IntNullValue, null);

                        string log = "";
                        string reason = "";

                        string sectionId = "";
                        string catId = "";
                        string brandId = "";
                        string uomId = "";
                        string gstOn = "";
                        string itemName = "";
                        string itemBarcode = "";
                        string unitInCase = "";
                        string gstPercent = "";
                        DateTime dateEffected = DateTime.Now;
                        string purchPrice = "";
                        string retailPrice = "";
                        string wholesalePrice = "";
                        string qty = "";
                        string minLevel = "";
                        string maxLevel = "";
                        string reorderLevel = "";


                        for (int row = startRow; row < rowEnd; row++)
                        { // Row by row...

                            reason = "";
                            sectionId = "";
                            catId = "";
                            brandId = "";
                            uomId = "";
                            gstOn = "";
                            itemName = "";
                            itemBarcode = "";
                            unitInCase = "";
                            gstPercent = "";
                            dateEffected = DateTime.Now;
                            purchPrice = "";
                            retailPrice = "";
                            wholesalePrice = "";
                            qty = "";
                            minLevel = "";
                            maxLevel = "";
                            reorderLevel = "";

                            for (int col = colStart; col <= colEnd; col++)
                            { // ... Cell by cell...
                                var cellValue = workSheet.Cells[row + 1, col].Text; // This got me the actual value I needed.

                                if (col == 1)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        foreach (DataRow dt in sectionsData.Rows)
                                        {
                                            if (cellValue.Trim().Equals(dt["SKU_HIE_NAME"].ToString()))
                                            {
                                                sectionId = dt["SKU_HIE_ID"].ToString();
                                                break;
                                            }
                                        }

                                        //if (emp != null && emp.Count > 0)
                                        //{
                                        //    obj.DefaultEmpCode = emp[0].ID;
                                        //}
                                        //else
                                        //{
                                        //    errEmp = true;
                                        //    reason = " EmployeeName ";
                                        //}
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Section ";
                                        break;
                                    }
                                }
                                else if (col == 2)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        foreach (DataRow dt in categoryData.Rows)
                                        {
                                            if (cellValue.Trim().Equals(dt["SKU_HIE_NAME"].ToString()))
                                            {
                                                catId = dt["SKU_HIE_ID"].ToString();
                                                break;
                                            }
                                        }

                                        //if (emp != null && emp.Count > 0)
                                        //{
                                        //    obj.DefaultEmpCode = emp[0].ID;
                                        //}
                                        //else
                                        //{
                                        //    errEmp = true;
                                        //    reason = " EmployeeName ";
                                        //}
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Category ";
                                        break;
                                    }
                                }
                                else if (col == 3)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        foreach (DataRow dt in brandData.Rows)
                                        {
                                            if (cellValue.Trim().Equals(dt["SKU_HIE_NAME"].ToString()))
                                            {
                                                brandId = dt["SKU_HIE_ID"].ToString();
                                                break;
                                            }
                                        }

                                        //if (emp != null && emp.Count > 0)
                                        //{
                                        //    obj.DefaultEmpCode = emp[0].ID;
                                        //}
                                        //else
                                        //{
                                        //    errEmp = true;
                                        //    reason = " EmployeeName ";
                                        //}
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Brand ";
                                        break;
                                    }
                                }
                                else if (col == 4)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        itemName = cellValue.Trim();
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Item Name ";
                                        break;
                                    }
                                }
                                else if (col == 5)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        itemBarcode = cellValue.Trim();
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " Item Barcode ";
                                        break;
                                    }
                                }
                                else if (col == 6)
                                {
                                    //errEmp = false;
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        foreach (DataRow dt in uomData.Rows)
                                        {
                                            if (cellValue.Trim().Equals(dt["UOM_DESC"].ToString()))
                                            {
                                                uomId = dt["UOM_ID"].ToString();
                                                break;
                                            }
                                        }

                                        //if (emp != null && emp.Count > 0)
                                        //{
                                        //    obj.DefaultEmpCode = emp[0].ID;
                                        //}
                                        //else
                                        //{
                                        //    errEmp = true;
                                        //    reason = " EmployeeName ";
                                        //}
                                    }
                                    else
                                    {
                                        //errEmp = true;
                                        reason = " UOM ";
                                        break;
                                    }
                                }
                                else if (col == 7)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        unitInCase = cellValue.Trim();
                                    }
                                    else
                                    {
                                        unitInCase = "1";
                                    }
                                }
                                else if (col == 8)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        gstOn = cellValue.Trim().Substring(0,1);
                                    }
                                    else
                                    {
                                        gstOn = "E";
                                    }
                                }
                                else if (col == 9)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        if (!gstOn.Equals("E"))
                                        {
                                            gstPercent = cellValue.Trim();
                                        }
                                    }
                                    else
                                    {
                                        gstPercent = "0";
                                    }
                                }
                                else if (col == 10)
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
                                else if (col == 11)
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
                                else if (col == 12)
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
                                else if (col == 13)
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
                                else if (col == 14)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        qty = cellValue.Trim();
                                    }
                                    else
                                    {
                                        qty = "0";
                                    }
                                }
                                else if (col == 15)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        minLevel = cellValue.Trim();
                                    }
                                    else
                                    {
                                        minLevel = "0";
                                    }
                                }
                                else if (col == 16)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        maxLevel = cellValue.Trim();
                                    }
                                    else
                                    {
                                        maxLevel = "0";
                                    }
                                }
                                else if (col == 17)
                                {
                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        reorderLevel = cellValue.Trim();
                                    }
                                    else
                                    {
                                        reorderLevel = "0";
                                    }
                                }
                            }

                            // insert item
                            DataControl dc = new DataControl();
                            string result = _mSkuController.InsertSKUS2(true, true, char.Parse(gstOn), 
                                DataControl.chkIntNull_0(sectionId), 0, int.Parse(catId), 
                                int.Parse(brandId), Constants.IntNullValue, 0, 0, unitInCase, itemBarcode, itemName, 
                                null, "", SessionClass.UserID, SessionClass.CompanyID, "Manual", null, 0, "", "", 
                                Convert.ToInt32(minLevel), Convert.ToInt32(maxLevel), Convert.ToInt32(reorderLevel), 
                                Convert.ToInt32(SessionClass.DISTRIBUTOR_ID), decimal.Parse(dc.chkNull_0(purchPrice)), 
                                decimal.Parse(dc.chkNull_0(retailPrice)), decimal.Parse(dc.chkNull_0(wholesalePrice)), 
                                decimal.Parse(dc.chkNull_0(gstPercent)), dateEffected, 0, Convert.ToDecimal(qty), int.Parse(uomId));


                        }
                        MessageBox.Show("File uploaded successfully");

                    }
                    catch (Exception ex)
                    {

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
                    var dataTable = new SKUExcelTemplate();

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage p = new ExcelPackage())
                    {
                        ExcelWorksheet ws = p.Workbook.Worksheets.Add("Items_List");
                        //Rogh sheet to add values from database to this sheet and then using rage add values in
                        //'Items_List' sheet.
                        ExcelWorksheet roughSheet = p.Workbook.Worksheets.Add("Dummy_List");

                        int index = 1;
                        foreach (var item in dataTable.GetType().GetProperties())
                        {
                            ws.Cells[1, index++].Value = item.Name.Replace('_', ' ').Replace("  ", "_");
                        }
                        var headerCells = ws.Cells[1, 1, 1, ExcelPackage.MaxColumns];
                        var headerFont = headerCells.Style.Font;
                        headerFont.Bold = true;

                        //FILL EXTRA DUMMY SHEET FOR DROPDOWNS NOW
                        GenerateExportPreFilledDropDown(ws, roughSheet, p);

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
            string fileNameAndPath = @"" + folderPath + "\\items_list_" + DateTime.Now.ToString("dd_mm_yyyy_HH_mm") + ".xlsx";

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
        public void GenerateExportPreFilledDropDown(ExcelWorksheet ws, ExcelWorksheet roughSheet, ExcelPackage p)
        {
            string startFrom = "";
            string startTo = "";

            roughSheet.Cells["A1"].Value = "Section";

            var headerCells = roughSheet.Cells[1, 1, 1, ExcelPackage.MaxColumns];
            var headerFont = headerCells.Style.Font;
            headerFont.Bold = true;

            //SECTIONS DROPDOWN
            DataTable sectionsData = _mHerController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

            if (sectionsData != null && sectionsData.Rows.Count > 0)
            {
                var count = 1;
                foreach (DataRow row in sectionsData.Rows)
                {
                    roughSheet.Cells[count + 1, 1].Value = row["SKU_HIE_NAME"].ToString();
                    count++;
                }

                //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
                //First sheet catgories into drop down.
                var range = ExcelRange.GetAddress(2, 1, ExcelPackage.MaxRows, 1);
                var sectionListInExcelDropDown = ws.DataValidations.AddListValidation(range);

                //Get range of values in category from dummy list sheet.
                startFrom = roughSheet.Cells[2, 1].ToString();
                startTo = roughSheet.Cells[count, 1].ToString();

                startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
                startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

                //Get range of values in category from dummy list sheet.
                var roughSheetSectionRange = startFrom + ":" + startTo;
                sectionListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetSectionRange.ToString();
            }

            //CATEGORY DROPDOWN
            DataTable categoryData = _mHerController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

            roughSheet.Cells["B1"].Value = "Category";

            if (categoryData != null && categoryData.Rows.Count > 0)
            {
                var count = 1;
                foreach (DataRow row in categoryData.Rows)
                {
                    roughSheet.Cells[count + 1, 2].Value = row["SKU_HIE_NAME"].ToString();
                    count++;
                }
                //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
                //First sheet catgories into drop down.
                var range = ExcelRange.GetAddress(2, 2, ExcelPackage.MaxRows, 2);
                var catListInExcelDropDown = ws.DataValidations.AddListValidation(range);

                //Get range of values in category from dummy list sheet.
                startFrom = roughSheet.Cells[2, 2].ToString();
                startTo = roughSheet.Cells[count, 2].ToString();

                startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
                startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

                var roughSheetCatRange = startFrom + ":" + startTo;
                catListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetCatRange.ToString();
            }

            //BRAND DROPDOWN
            DataTable brandData = _mHerController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);

            roughSheet.Cells["C1"].Value = "Brand";

            if (brandData != null && brandData.Rows.Count > 0)
            {
                var count = 1;
                foreach (DataRow row in brandData.Rows)
                {
                    roughSheet.Cells[count + 1, 3].Value = row["SKU_HIE_NAME"].ToString();
                    count++;
                }
                //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
                //First sheet catgories into drop down.
                var range = ExcelRange.GetAddress(2, 3, ExcelPackage.MaxRows, 3);
                var brandListInExcelDropDown = ws.DataValidations.AddListValidation(range);

                //Get range of values in category from dummy list sheet.
                startFrom = roughSheet.Cells[2, 3].ToString();
                startTo = roughSheet.Cells[count, 3].ToString();

                startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
                startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

                var roughSheetBrandRange = startFrom + ":" + startTo;
                brandListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetBrandRange.ToString();
            }

            roughSheet.Cells["D1"].Value = "GST_ON";

            string[] arrGST = { "Taxable", "Retail (Third Schedule)", "Exempted" };

            if (arrGST != null && arrGST.Length > 0)
            {
                var count = 1;
                for (int i = 0; i < arrGST.Length; i++)
                {
                    roughSheet.Cells[count + 1, 4].Value = arrGST[i];
                    count++;
                }
                //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
                //First sheet catgories into drop down.
                var range = ExcelRange.GetAddress(2, 8, ExcelPackage.MaxRows, 8);
                var gstListInExcelDropDown = ws.DataValidations.AddListValidation(range);

                //Get range of values in category from dummy list sheet.
                startFrom = roughSheet.Cells[2, 4].ToString();
                startTo = roughSheet.Cells[count, 4].ToString();

                startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
                startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

                var roughSheetGstRange = startFrom + ":" + startTo;
                gstListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetGstRange.ToString();
            }

            //UOM DROPDOWN
            DataTable uomData = _mSkuController.SelectUOMs(Constants.IntNullValue, null);
            roughSheet.Cells["E1"].Value = "Brand";

            if (uomData != null && uomData.Rows.Count > 0)
            {
                var count = 1;
                foreach (DataRow row in uomData.Rows)
                {
                    roughSheet.Cells[count + 1, 5].Value = row["UOM_DESC"].ToString();
                    count++;
                }
                //specify the range for the dropdown to appear. //Where GetAddress is: GetAddress(int FromRow, int FromColumn, int ToRow, int ToColumn)
                //First sheet catgories into drop down.
                var range = ExcelRange.GetAddress(2, 6, ExcelPackage.MaxRows, 6);
                var uomListInExcelDropDown = ws.DataValidations.AddListValidation(range);

                //Get range of values in category from dummy list sheet.
                startFrom = roughSheet.Cells[2, 5].ToString();
                startTo = roughSheet.Cells[count, 5].ToString();

                startFrom = "$" + startFrom.Substring(0, 1) + "$" + startFrom.Substring(1);
                startTo = "$" + startTo.Substring(0, 1) + "$" + startTo.Substring(1);

                var roughSheetUomRange = startFrom + ":" + startTo;
                uomListInExcelDropDown.Formula.ExcelFormula = "Dummy_List!" + roughSheetUomRange.ToString();
            }

            //Hide Dummy Sheet
            roughSheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;

        }

        #endregion

        #region Grid Cell Click Event
        private void GridSKUinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridSKUinfo.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridSKUinfo.Columns["Edit"].Index)
            {
                PopUpSKUinfo _formPopUpInfo = new PopUpSKUinfo();
                PopUpSKUinfo._Catagoryvalue = Convert.ToInt32(GridSKUinfo.Rows[_rowIndex].Cells["CATEGORY_ID"].Value.ToString());
                PopUpSKUinfo._Sectionvalue = Convert.ToInt32(GridSKUinfo.Rows[_rowIndex].Cells["Principal_Id"].Value.ToString());
                PopUpSKUinfo._Brandvalue = Convert.ToInt32(GridSKUinfo.Rows[_rowIndex].Cells["Brand_Id"].Value.ToString());
                PopUpSKUinfo._GSTvalue = Convert.ToChar(GridSKUinfo.Rows[_rowIndex].Cells["DIVISION_ID"].Value.ToString());
                if(!string.IsNullOrEmpty(GridSKUinfo.Rows[_rowIndex].Cells["UOM_ID"].Value.ToString()))
                {
                    PopUpSKUinfo._Uomvalue = Convert.ToInt32(GridSKUinfo.Rows[_rowIndex].Cells["UOM_ID"].Value.ToString());
                }
                else
                {
                    PopUpSKUinfo._Uomvalue = 0;
                }

                _formPopUpInfo.txtMinLevel.Text = GridSKUinfo.Rows[_rowIndex].Cells["MinLevel"].Value.ToString();
                _formPopUpInfo.txtMaxLevel.Text = GridSKUinfo.Rows[_rowIndex].Cells["MaxLevel"].Value.ToString();
                _formPopUpInfo.txtItemName.Text = GridSKUinfo.Rows[_rowIndex].Cells["SKU_NAME"].Value.ToString().Replace("&nbsp;", "");
                _mSkuId = int.Parse(GridSKUinfo.Rows[_rowIndex].Cells["SKU_ID"].Value.ToString());
                PopUpSKUinfo._SKUid = _mSkuId;
                _formPopUpInfo.txtBarcode.Text = GridSKUinfo.Rows[_rowIndex].Cells["SKU_CODE"].Value.ToString().Replace("&nbsp;", "");
                _formPopUpInfo.txtSize.Text = GridSKUinfo.Rows[_rowIndex].Cells["PACKSIZE"].Value.ToString().Replace("&nbsp;", "");
                _formPopUpInfo.txtUnitinCase.Text = GridSKUinfo.Rows[_rowIndex].Cells["UNITS_IN_CASE"].Value.ToString().Replace("&nbsp;", "");
                PopUpSKUinfo._GstOn = Convert.ToChar(GridSKUinfo.Rows[_rowIndex].Cells["GST_ON"].Value.ToString().Trim());

                PopUpSKUinfo._bar_code = Convert.ToString(GridSKUinfo.Rows[_rowIndex].Cells["BAR_CODE"].Value.ToString().Trim());

                if (int.Parse(GridSKUinfo.Rows[_rowIndex].Cells["Category_Id"].Value.ToString()) > 0)
                {
                    _formPopUpInfo.ChkUnitMeasure.Checked = true;
                    _formPopUpInfo.cboxUnitMeasure.SelectedValue = Convert.ToInt32(GridSKUinfo.Rows[_rowIndex].Cells["Category_Id"].Value.ToString());
                }
                else
                {
                    _formPopUpInfo.ChkUnitMeasure.Checked = false;
                }
                _formPopUpInfo.txtReorderLevel.Text = GridSKUinfo.Rows[_rowIndex].Cells["REORDER_LEVEL"].Value.ToString();
                _formPopUpInfo.txtPurchasePrice.Text = GridSKUinfo.Rows[_rowIndex].Cells["DISTRIBUTOR_PRICE"].Value.ToString().Replace("&nbsp;", "0");
                _formPopUpInfo.txtRetailPrice.Text = GridSKUinfo.Rows[_rowIndex].Cells["TRADE_PRICE"].Value.ToString().Replace("&nbsp;", "0");
                _formPopUpInfo.txtWholesalePrice.Text = GridSKUinfo.Rows[_rowIndex].Cells["WHOLESALE_PRICE"].Value.ToString().Replace("&nbsp;", "0");
                _formPopUpInfo.txtWsQuantity.Text = GridSKUinfo.Rows[_rowIndex].Cells["WS_QUANTITY"].Value.ToString().Replace("&nbsp;", "0");
                _formPopUpInfo.txtEffectedDate.Text = GridSKUinfo.Rows[_rowIndex].Cells["DATE_EFFECTED"].Value.ToString();
                _formPopUpInfo.txtGSTPrice.Text = GridSKUinfo.Rows[_rowIndex].Cells["TAX_PRICE"].Value.ToString().Replace("&nbsp;", "0");
                _formPopUpInfo.btnSave.Text = "Update";
                _formPopUpInfo.ShowDialog();
            }
        }
        #endregion

        #region Button Show PopUp
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SKUInfoProperties._NewOrUpdate = "New";
            PopUpSKUinfo _popupSKUinfo = new PopUpSKUinfo();
            _popupSKUinfo.ShowDialog();
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            return;
            ((DataTable)GridSKUinfo.DataSource).DefaultView.RowFilter = "SKU_NAME LIKE '%" + txtSearch.Text + "%' OR PACKSIZE LIKE '%" + txtSearch.Text + "%' OR SKU_CODE LIKE '%" + txtSearch.Text + "%'";
            ActiveInactiveText();
        }

        private void FormSKU_Information_Shown(object sender, EventArgs e)
        {
            ActiveInactiveText();
        }

        #region ActiveInactiveText Function

        public void ActiveInactiveText()
        {
            int _rows = GridSKUinfo.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridSKUinfo.Rows[i].Cells["ISACTIVE"].Value) == true)
                {
                    GridSKUinfo.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridSKUinfo.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        }
        #endregion

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridSKUinfo.Rows.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSKUinfo.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSKUinfo.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
        public void SearchPrice(int _TypeID)
        {
            GridSKUinfo.AutoGenerateColumns = false;
            try
            {
                GridSKUinfo.Rows.Clear();
            }
            catch (Exception)
            { }
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable Dtsku_Price = PController.SelectDataPrice(Convert.ToString(txtSearch.Text), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, Constants.IntNullValue, _TypeID, SessionClass.CurrentWorkDate);
            if (Dtsku_Price.Rows.Count > 0)
            {
                ClassSession.dtSKUdata = _mSkuDt;
                GridSKUinfo.DataSource = null;
                GridSKUinfo.Rows.Clear();
                GridSKUinfo.DataSource = Dtsku_Price;
                ArrangeGrid();
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
                if (txtSearch.TextLength > 0)
                {
                    //if (Regex.IsMatch(txtSearch.Text.Trim(), @"^[a-zA-Z]+$")) for checking is only characters
                    if (Regex.IsMatch(txtSearch.Text.Trim(), @"^\d+$"))     // for checking is only digits
                    {
                        SearchPrice(9);
                    }
                    else
                    {
                        SearchPrice(10);
                    }
                }
                else
                {
                    LoadData();
                }
            }
        }
    }
}
