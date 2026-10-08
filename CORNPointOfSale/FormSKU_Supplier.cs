using System;
using System.Data;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using CORNDataAccessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormSKU_Supplier : Form
    {
        readonly SkuHierarchyController _mController = new SkuHierarchyController();
        static int _principalId;
        public FormSKU_Supplier()
        {
            InitializeComponent();
        }
        #region Load Functions
        public void LoadPrincipal()
        {
            GridSupplier.DataSource = null;
            GridSupplier.Rows.Clear();
            DataTable dt = _mController.SelectPrincipal(Constants.SKUPrincipal, SessionClass.CompanyID);
            GridSupplier.DataSource = dt;
            ArrangeGrid();
        }
      
        private void FormSKU_Supplier_Load(object sender, EventArgs e)
        {
            this.LoadPrincipal();
        } 
        #endregion
     

        #region Arrange DataGrid
        private void ArrangeGrid()
        {
            try
            {
                GridSupplier.Columns.Remove("Edit");
                GridSupplier.Columns.Remove("Select");
                GridSupplier.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }
            GridSupplier.Columns["SKU_HIE_ID"].Visible = false;
            GridSupplier.Columns["COMPANY_ID"].Visible = false;
            GridSupplier.Columns["PARENT_SKU_HIE_ID"].Visible = false;
            GridSupplier.Columns["SKU_HIE_TYPE_ID"].Visible = false;
            GridSupplier.Columns["TIME_STAMP"].Visible = false;
            GridSupplier.Columns["LASTUPDATE_DATE"].Visible = false;
            GridSupplier.Columns["IS_ACTIVE"].Visible = false;
            GridSupplier.Columns["IP_ADDRESS"].Visible = false;
            GridSupplier.Columns["SKU_HIE_CODE"].Visible = false;
            GridSupplier.Columns["IS_MANUALDISCOUNT"].Visible = false;
            GridSupplier.Columns["FaxNumber"].Visible = false;
            GridSupplier.Columns["Opening_Amount"].Visible = false;
            GridSupplier.Columns["Opening_Type"].Visible = false;
            GridSupplier.Columns["PRINCIPAL_ADDRESS_ID"].Visible = false;

            //
            //
            // Add Edit Button
            //
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridSupplier.Columns.Add(btnEdit);
            //
            //
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GridSupplier.Columns.Add(checkColumn);
            GridSupplier.Columns["Select"].DisplayIndex = 0;
            GridSupplier.Columns["SELECT"].HeaderText = "";
            //
            // Set Columns width and Header Names
            //
            //
            GridSupplier.Columns["Edit"].Width = 70;
            GridSupplier.Columns["NTN"].Width = 150;
            GridSupplier.Columns["CONTACT_PERSON"].Width = 150;
            GridSupplier.Columns["SKU_HIE_NAME"].Width = 150;
            GridSupplier.Columns["NTN"].HeaderText = "Phone Number";
            GridSupplier.Columns["CONTACT_PERSON"].HeaderText = "Contact Person";
            GridSupplier.Columns["SKU_HIE_NAME"].HeaderText = "Supplier";
            GridSupplier.Columns["STRN"].HeaderText = "Email";
            GridSupplier.Columns["ADDRESS"].HeaderText = "Address";
            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "   Status";
            GridSupplier.Columns.Add(activeClm);
            GridSupplier.Columns["activeClm"].DisplayIndex = GridSupplier.Columns["Edit"].Index - 1;
            GridSupplier.Columns["activeClm"].Width = 90;

            // Set Active and In Active Text

            GridSupplier.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridSupplier.Columns["activeClm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridSupplier.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ActiveInactiveText();
            //
            //  Width
            GridSupplier.Columns["Select"].Width = 50;
            GridSupplier.Columns["SKU_HIE_NAME"].Width = 150;
            GridSupplier.Columns["CONTACT_PERSON"].Width = 150;
            GridSupplier.Columns["NTN"].Width = 120;
            GridSupplier.Columns["ADDRESS"].Width = 370;
            GridSupplier.Columns["STRN"].Width = 150;

            foreach (DataGridViewColumn clms in GridSupplier.Columns)
            {
                clms.ReadOnly = true;
            }
            GridSupplier.Columns["Select"].ReadOnly = false;
        } 
        #endregion

        #region Edit Delete Cell Click Event
        private void GridSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridSupplier.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridSupplier.Columns["Edit"].Index)
            {
                _principalId = int.Parse(GridSupplier.Rows[_rowIndex].Cells["SKU_HIE_ID"].Value.ToString());
                SupplierProperties._principalId = _principalId;
                SupplierProperties._name = GridSupplier.Rows[_rowIndex].Cells["SKU_HIE_NAME"].Value.ToString();
                SupplierProperties._address = GridSupplier.Rows[_rowIndex].Cells["ADDRESS"].Value.ToString();
                SupplierProperties._faxNumber = GridSupplier.Rows[_rowIndex].Cells["FaxNumber"].Value.ToString();
                if (GridSupplier.Rows[_rowIndex].Cells["IS_MANUALDISCOUNT"].Value.ToString() == "True")
                {
                    SupplierProperties._ISManualDiscount = true;
                }
                else
                {
                    SupplierProperties._ISManualDiscount = false;
                }
                SupplierProperties._contactPerson = GridSupplier.Rows[_rowIndex].Cells["CONTACT_PERSON"].Value.ToString().Replace("&nbsp;", "");
                SupplierProperties._emailAddres = GridSupplier.Rows[_rowIndex].Cells["STRN"].Value.ToString().Replace("&nbsp;", "");
                SupplierProperties._phoneNumber = GridSupplier.Rows[_rowIndex].Cells["NTN"].Value.ToString().Replace("&nbsp;", "");
                try
                {
                    SupplierProperties._amount = Convert.ToDecimal(GridSupplier.Rows[_rowIndex].Cells["Opening_Amount"].Value.ToString());
                    SupplierProperties._type = Convert.ToInt32(GridSupplier.Rows[_rowIndex].Cells["Opening_Type"].Value.ToString());
                }
                catch (Exception){}
                SupplierProperties._NewOrUpdate = "Update";
                PopUpSKU_Supplier _formSupplierPoPUp = new PopUpSKU_Supplier();
                _formSupplierPoPUp.ShowDialog();
            }
        } 
        #endregion

        #region Button Click Event (Add New)
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            PopUpSKU_Supplier _formSupplier = new PopUpSKU_Supplier();
            SupplierProperties._NewOrUpdate = "New";
            _formSupplier.ShowDialog();
        } 
        #endregion

        #region Search Text Changed Box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridSupplier.DataSource).DefaultView.RowFilter = "SKU_HIE_NAME LIKE '%" + txtSearch.Text + "%' OR CONTACT_PERSON LIKE '%" + txtSearch.Text + "%' OR NTN LIKE '%" + txtSearch.Text + "%' OR ADDRESS LIKE '%" + txtSearch.Text + "%' OR STRN LIKE '%" + txtSearch.Text + "%'";
            ActiveInactiveText();
        } 
        #endregion
        #region ActiveInactiveText Function
        private void FormItemSupplier_Shown(object sender, EventArgs e)
        {
            ActiveInactiveText();
        }
        public void ActiveInactiveText()
        {
            int _rows = GridSupplier.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridSupplier.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    GridSupplier.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridSupplier.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridSupplier.Rows.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSupplier.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridSupplier.Rows[i].Cells["Select"].Value = false;
                }
            }
        }

        private void btnActiveSupplier_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridSupplier, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridSupplier.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            if (Convert.ToBoolean(dr.Cells["IS_ACTIVE"].Value))
                            {
                                _principalId = int.Parse(GridSupplier.Rows[dr.Index].Cells["SKU_HIE_ID"].Value.ToString());
                                DataTable dt = _mController.SelectSkuHierarchy(Constants.SKUSection, _principalId);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Wrong Command: first delete associated division of Supplier : " + _principalId);
                                }
                                else
                                {
                                    _mController.UpdateHierarchy(Constants.SKUPrincipal, _principalId, Constants.IntNullValue, null, null, null, false, SessionClass.CompanyID);
                                }
                            }
                            else
                            {
                                _mController.UpdateHierarchy(Constants.SKUPrincipal, _principalId, Constants.IntNullValue, null, null, null, true, SessionClass.CompanyID);
                            }
                        }
                    }
                    this.LoadPrincipal();
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
