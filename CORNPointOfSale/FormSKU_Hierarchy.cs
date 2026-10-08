using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormSKU_Hierarchy : Form
    {
        readonly SkuHierarchyController _mController = new SkuHierarchyController();
        readonly SkuController _sController = new SkuController();
        static int _brandId;
        static int _categoryId;
        static int _sectionId;

        public FormSKU_Hierarchy()
        {
            InitializeComponent();
        }

        private void FormSKU_Hierarchy_Load(object sender, EventArgs e)
        {
            this.LoadSection();
            this.LoadCategroy();
            this.LoadBrand();
            this.CboxLoadSection();
        }


        #region Load Functions
        private void LoadCategroy()
        {
            DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            GridCatagory.DataSource = dt;
            ArrangeGrid(GridCatagory, true);
        }
        public void LoadBrand()
        {
            DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            GridBrand.DataSource = dt;
            ArrangeGrid(GridBrand);
        }
        public void LoadSection()
        {
            DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            GridSection.DataSource = dt;
            ArrangeGrid(GridSection);
            CboxLoadSection();
        }
        public void CboxLoadSection()
        {
            cboxSection.DataSource = null;
            DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, Constants.IntNullValue, Constants.IntNullValue, null, null, true, SessionClass.CompanyID);
            cboxSection.DataSource = dt;
            cboxSection.ValueMember = "SKU_HIE_ID";
            cboxSection.DisplayMember = "SKU_HIE_NAME";
            if (cboxSection.Items.Count > 0)
            {
                cboxSection.SelectedIndex = 0; 
            }
        }
        #endregion

        #region Arrange Grid View
        public void ArrangeGrid(DataGridView dGrid, bool isCat = false)
        {
            try
            {
                dGrid.Columns.Remove("Edit");
                dGrid.Columns.Remove("Select");
                dGrid.Columns.Remove("activeClm");
                dGrid.Columns.Remove("Delete");
            }
            catch (Exception)
            {
            }

            foreach (DataGridViewColumn clm in dGrid.Columns)
            {
                clm.Visible = false;
            }

            dGrid.Columns["SKU_HIE_ID"].Visible = false;
            dGrid.Columns["SKU_HIE_NAME"].Visible = true;
            if (isCat)
            {
                dGrid.Columns["Section"].Visible = true;
                //dGrid.Columns["Section"].DisplayIndex = 1;
            }
            //// Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            //btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            dGrid.Columns.Add(btnEdit);
            //
            //
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            dGrid.Columns.Add(checkColumn);
            dGrid.Columns["Select"].DisplayIndex = 0;
            dGrid.Columns["SELECT"].HeaderText = "";
            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
           // btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            dGrid.Columns.Add(btnDelete);
           
            //
            // Set Header Names
            //
            dGrid.Columns["SKU_HIE_ID"].HeaderText = " ID";
            dGrid.Columns["SKU_HIE_NAME"].HeaderText = "Name";
            dGrid.Columns["Edit"].HeaderText = "";
            dGrid.Columns["Delete"].HeaderText = "";
            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "   Status";
            dGrid.Columns.Add(activeClm);
            if (isCat)
            {
                dGrid.Columns["activeClm"].DisplayIndex = dGrid.Columns["Section"].DisplayIndex + 1;
                //dGrid.Columns["activeClm"].DisplayIndex = dGrid.Columns["activeClm"].DisplayIndex + 1;
            }
            else
            {
                dGrid.Columns["activeClm"].DisplayIndex = dGrid.Columns["Edit"].Index - 1;
            }
            dGrid.Columns["activeClm"].Width = 90;
            // Set Active and In Active Text

            dGrid.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGrid.Columns["activeClm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGrid.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGrid.Columns["Delete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ActiveInactiveText(dGrid);
            //
            // Set Width of Columns
            //
            //dGrid.Columns["SKU_HIE_NAME"].Width = 315;
            dGrid.Columns["Select"].Width = 50;
            dGrid.Columns["Edit"].Width = 30;
            dGrid.Columns["Delete"].Width = 40;
            //dGrid.Columns["SKU_HIE_ID"].Width = 80;

            //dGrid.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dGrid.Columns["Delete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn clms in dGrid.Columns)
            {
                clms.ReadOnly = true;
            }
            dGrid.Columns["Select"].ReadOnly = false;
        }
        #endregion

        #region Search Text Changed Box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridCatagory.DataSource).DefaultView.RowFilter = "SKU_HIE_NAME LIKE '%" + txtSearch.Text + "%' OR SECTION LIKE '%" + txtSearch.Text + "%'";
            ActiveInactiveText(GridCatagory);
        }
        private void txtSearchSection_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridSection.DataSource).DefaultView.RowFilter = "SKU_HIE_NAME LIKE '%" + txtSearchSection.Text + "%' ";
            ActiveInactiveText(GridSection);
        }
        private void txtSearchBrand_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridBrand.DataSource).DefaultView.RowFilter = "SKU_HIE_NAME LIKE '%" + txtSearchBrand.Text + "%' ";
            ActiveInactiveText(GridBrand);
        }
        #endregion

        #region ActiveInactiveText Function
        private void FormSKU_Hierarchy_Shown(object sender, EventArgs e)
        {
            ActiveInactiveText(GridSection);
            ActiveInactiveText(GridCatagory);
            ActiveInactiveText(GridBrand);
        }
        
        public void ActiveInactiveText(DataGridView dGrid)
        {
            int _rows = dGrid.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(dGrid.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    dGrid.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    dGrid.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        }

        private void btnActiveCateg_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridCatagory, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridCatagory.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            _categoryId = int.Parse(GridCatagory.Rows[dr.Index].Cells["SKU_HIE_ID"].Value.ToString());
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                //DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, _categoryId);
                                //if (dt.Rows.Count > 0)
                                //{
                                //    MessageBox.Show("Wrong Command: first delete associated division of Supplier : " + _categoryId);
                                //}
                                //else
                                //{
                                    _mController.UpdateHierarchy(Constants.SKUCategory, _categoryId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                                //}
                            }
                            else
                            {
                                _mController.UpdateHierarchy(Constants.SKUCategory, _categoryId, Constants.IntNullValue, null, null, null, true, SessionClass.CompanyID);                                
                            }
                        }
                    }
                    GridCatagory.DataSource = null;
                    this.LoadCategroy();
                    chkAllCat.Checked = false;
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActiveSection_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridSection, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridSection.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            _sectionId = int.Parse(GridSection.Rows[dr.Index].Cells["SKU_HIE_ID"].Value.ToString());
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                //DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, _categoryId);
                                //if (dt.Rows.Count > 0)
                                //{
                                //    MessageBox.Show("Wrong Command: first delete associated division of Supplier : " + _categoryId);
                                //}
                                //else
                                //{
                                _mController.UpdateHierarchy(Constants.SKUSection, _sectionId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                                //}
                            }
                            else
                            {
                                _mController.UpdateHierarchy(Constants.SKUSection, _sectionId, Constants.IntNullValue, null, null, null, true, SessionClass.CompanyID);
                            }
                        }
                    }
                    GridSection.DataSource = null;
                    this.LoadSection();
                    chkAllSect.Checked = false;
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Common Functions
        private void btnNewSection_Click(object sender, EventArgs e)
        {
            SAVEorUPDATE();
        }

        #endregion


        #region Brand Place

        private void btnActiveBrand_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridBrand, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridBrand.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            _brandId = int.Parse(GridBrand.Rows[dr.Index].Cells["SKU_HIE_ID"].Value.ToString());
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                //DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, _categoryId);
                                //if (dt.Rows.Count > 0)
                                //{
                                //    MessageBox.Show("Wrong Command: first delete associated division of Supplier : " + _categoryId);
                                //}
                                //else
                                //{
                                _mController.UpdateHierarchy(Constants.SKUBrand, _brandId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                                //}
                            }
                            else
                            {
                                _mController.UpdateHierarchy(Constants.SKUBrand, _brandId, Constants.IntNullValue, null, null, null, true, SessionClass.CompanyID);
                            }
                        }
                    }
                    GridBrand.DataSource = null;
                    this.LoadBrand();
                    chkAllBrand.Checked = false;
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            SAVEorUPDATEBrand();
        }

        #region Save or Update Function

        public void SAVEorUPDATEBrand()
        {
            if (btnNewBrand.Text == "New")
            {
                txtBrandName.Enabled = true;
                txtBrandName.Focus();
                btnNewBrand.Text = "Save";
            }
            else if (btnNewBrand.Text == "Save")
            {
                if (txtBrandName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.InsertHierarchy(Constants.SKUBrand, 0, null, txtBrandName.Text, null, true, SessionClass.CompanyID);
                btnNewBrand.Text = "New";
                txtBrandName.Text = "";
                txtBrandName.Enabled = false;
                GridBrand.DataSource = null;
                this.LoadBrand();
                //this.ArrangeGrid(GridBrand);
            }
            else if (btnNewBrand.Text == "Update")
            {
                if (txtBrandName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.UpdateHierarchy(Constants.SKUBrand, _brandId, 0, null, txtBrandName.Text, null, true, SessionClass.CompanyID);
                btnNewBrand.Text = "New";
                txtBrandName.Text = "";
                txtBrandName.Enabled = false;
                GridBrand.DataSource = null;
                this.LoadBrand();
                //this.ArrangeGrid(GridBrand);
            }
        }

        #endregion

        #region Grid Cell Click Event

        private void GridBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _index = GridBrand.CurrentCell.ColumnIndex;
            if (_index == GridBrand.Columns["Edit"].Index)
            {
                _brandId = int.Parse(GridBrand.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                txtBrandName.Text = GridBrand.Rows[e.RowIndex].Cells["SKU_HIE_NAME"].Value.ToString();
                txtBrandName.Enabled = true;
                //txtBrandCode.Enabled = true;
                btnNewBrand.Text = "Update";
            }
            if (_index == GridBrand.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    _brandId = int.Parse(GridBrand.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                    DataTable dt = _mController.SelectSkuHierarchy(Constants.IntNullValue, _brandId, Constants.IntNullValue);
                    if (dt.Rows.Count > 0)
                    {
                        ToastNotification.Show(this, "Wrong Command: First Delete associated Catagory", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    }
                    else
                    {
                        _mController.UpdateHierarchy(Constants.SKUBrand, _brandId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                        GridBrand.DataSource = null;
                        this.LoadBrand();
                        //ArrangeGrid(GridBrand);
                    }
                }
            }
        }
        
        #endregion 
        
        #endregion


        #region Section Place


        #region Save or Update Function
        public void SAVEorUPDATE()
        {
            if (btnNewSection.Text == "New")
            {
                txtSectionName.Enabled = true;
                txtSectionName.Focus();
                btnNewSection.Text = "Save";
            }
            else if (btnNewSection.Text == "Save")
            {
                if (txtSectionName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.InsertHierarchy(Constants.SKUSection, 0, null, txtSectionName.Text, null, true, SessionClass.CompanyID);
                btnNewSection.Text = "New";
                txtSectionName.Text = "";
                txtSectionName.Enabled = false;
                GridSection.DataSource = null;
                this.LoadSection();
                //this.ArrangeGrid(GridSection);
            }
            else if (btnNewSection.Text == "Update")
            {
                if (txtSectionName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.UpdateHierarchy(Constants.SKUSection, _sectionId, 0, null, txtSectionName.Text, null, true, SessionClass.CompanyID);
                btnNewSection.Text = "New";
                txtSectionName.Text = "";
                txtSectionName.Enabled = false;
                GridSection.DataSource = null;
                this.LoadSection();
                //this.ArrangeGrid(GridSection);
            }
        }
        #endregion

        #region Grid Cell Click Event
        private void GridSection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _index = GridSection.CurrentCell.ColumnIndex;
            if (_index == GridSection.Columns["Edit"].Index)
            {
                _sectionId = int.Parse(GridSection.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                txtSectionName.Text = GridSection.Rows[e.RowIndex].Cells["SKU_HIE_NAME"].Value.ToString();
                txtSectionName.Enabled = true;
                //txtSectionCode.Enabled = true;
                btnNewSection.Text = "Update";
            }
            if (_index == GridSection.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    _sectionId = int.Parse(GridSection.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                    DataTable dt = _mController.SelectSkuHierarchy(Constants.IntNullValue, _sectionId, Constants.IntNullValue);
                    if (dt.Rows.Count > 0)
                    {
                        ToastNotification.Show(this, "Wrong Command: First Delete associated Catagory", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    }
                    else
                    {
                        _mController.UpdateHierarchy(Constants.SKUSection, _sectionId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                        GridSection.DataSource = null;
                        this.LoadSection();
                        //ArrangeGrid(GridSection);
                    }
                }
            }
        }
        #endregion 


        #endregion

        #region Catagory Place

        #region Grid Cell Click Event
        private void GridCatagory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _index = GridCatagory.CurrentCell.ColumnIndex;
            if (_index == GridCatagory.Columns["Edit"].Index)
            {
                _categoryId = int.Parse(GridCatagory.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                txtCatagoryName.Text = GridCatagory.Rows[e.RowIndex].Cells["SKU_HIE_NAME"].Value.ToString();
                cboxSection.SelectedValue = Convert.ToInt32(GridCatagory.Rows[e.RowIndex].Cells["PARENT_SKU_HIE_ID"].Value.ToString());
                txtCatagoryName.Enabled = true;
                btnNewCatagory.Text = "Update";
            }
            if (_index == GridCatagory.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    _categoryId = int.Parse(GridCatagory.Rows[e.RowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                    DataTable dt = _sController.SelectSkuInfo2(Constants.IntNullValue, Constants.IntNullValue, _categoryId, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
                    if (dt.Rows.Count > 0)
                    {
                        ToastNotification.Show(this, "Wrong Command: First Delete associated Items", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    }
                    else
                    {
                        _mController.UpdateHierarchy(Constants.SKUCategory, _categoryId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                        GridCatagory.DataSource = null;
                        this.LoadCategroy();
                        //ArrangeGrid(GridCatagory, true);
                    }
                }
            }
        } 
        #endregion

        #region Save New Or Update
        private void btnNewCatagory_Click(object sender, EventArgs e)
        {
            SAVEorUPDATECatagory();
        }
        public void SAVEorUPDATECatagory()
        {
            if (btnNewCatagory.Text == "New")
            {
                txtCatagoryName.Enabled = true;
                txtCatagoryName.Focus();
                btnNewCatagory.Text = "Save";
            }
            else if (btnNewCatagory.Text == "Save")
            {
                if (txtCatagoryName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Catagory Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.InsertHierarchy(Constants.SKUCategory, Convert.ToInt32(cboxSection.SelectedValue.ToString()), null, txtCatagoryName.Text, null, true, SessionClass.CompanyID);
                btnNewCatagory.Text = "New";
                txtCatagoryName.Text = "";
                txtCatagoryName.Enabled = false;
                GridCatagory.DataSource = null;
                this.LoadCategroy();
                //this.ArrangeGrid(GridCatagory, true);
            }
            else if (btnNewCatagory.Text == "Update")
            {
                if (txtCatagoryName.Text.Length <= 0)
                {
                    ToastNotification.Show(this, "Must Enter Catagory Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.UpdateHierarchy(Constants.SKUCategory, _categoryId, Convert.ToInt32(cboxSection.SelectedValue.ToString()), null, txtCatagoryName.Text, null, true, SessionClass.CompanyID);
                btnNewCatagory.Text = "New";
                txtCatagoryName.Text = "";
                txtCatagoryName.Enabled = false;
                GridCatagory.DataSource = null;
                this.LoadCategroy();
                //this.ArrangeGrid(GridCatagory, true);
            }
        }  
        #endregion

        private void FormSKU_Hierarchy_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 600, 210);
            tabControl1.Location = new Point(points[0],points[1]);
        }


        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                ActiveInactiveText(GridCatagory);
            }
        }

        private void chkAllSect_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridSection.Rows.Count;
            if (chkAllSect.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSection.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSection.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
        private void chkAllCat_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridCatagory.Rows.Count;
            if (chkAllCat.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridCatagory.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridCatagory.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
        private void chkAllBrand_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridBrand.Rows.Count;
            if (chkAllBrand.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridBrand.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridBrand.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
    }
}
