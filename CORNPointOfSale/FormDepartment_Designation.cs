using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormDepartment_Designation : Form
    {
        private static int _refId;
        readonly SLASHCodesController _mController = new SLASHCodesController();
        public FormDepartment_Designation()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormDepartment_Designation_Load(object sender, EventArgs e)
        {
            GridViewDepartment.BackgroundColor = Color.White;
            ResetFiledsDesignation();
            ResetFiledsDepartment();
            // Department
            LoadBusinessType();
            // Designation
            LoadChannelType();
        }
        private void LoadChannelType()
        {
            GridViewDesignation.DataSource = null;
            GridViewDesignation.Rows.Clear();
            DataTable dt = _mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Designation_Id, null, Constants.IntNullValue, bool.Parse("True"));
            GridViewDesignation.DataSource = dt;
            ArrangeGridView(GridViewDesignation);
        }
        private void LoadBusinessType()
        {
            GridViewDepartment.DataSource = null;
            GridViewDepartment.Rows.Clear();
            DataTable dt = _mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Depoartment_Id, null, Constants.IntNullValue, bool.Parse("True"));
            GridViewDepartment.DataSource = dt.DefaultView;
            ArrangeGridView(GridViewDepartment);
        }
        #endregion

        #region Grid Arrangement
        public void ArrangeGridView(DataGridView _grid)
        {
            try
            {
                _grid.Columns.Remove("Edit");
                _grid.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            _grid.Columns["REF_ID"].Visible = false;
            _grid.Columns["PARENT_REF_ID"].Visible = false;
            _grid.Columns["IS_ACTIVE"].Visible = false;
            _grid.Columns["TIME_STAMP"].Visible = false;
            _grid.Columns["STATUS"].Visible = false;
            _grid.Columns["SLASH_CODE"].HeaderText = "Code";
            _grid.Columns["SLASH_DESC"].HeaderText = "Name";
            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            _grid.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            _grid.Columns.Add(btnDelete);

            // Set Columns width
            _grid.Columns["SLASH_CODE"].Width = 100;
            _grid.Columns["SLASH_DESC"].Width = 220;
            _grid.Columns["Edit"].Width = 50;
            _grid.Columns["Delete"].Width = 50;
        }
        #endregion

        #region Form Different Controles
        // Department
        public void ResetFiledsDepartment()
        {
            txtNameDepartment.Text = "";
            txtCodeDepartment.Text = "";
        }
        private void btnCancleDepartment_Click(object sender, EventArgs e)
        {

            txtCodeDepartment.Text = "";
            txtNameDepartment.Text = "";
            btnNewDepartment.Text = "New";
            txtNameDepartment.Enabled = false;
        }
        // Designation
        public void ResetFiledsDesignation()
        {
            txtNameDesignation.Text = "";
            txtCodeDesignation.Text = "";
        }
        private void btnCancleDesignation_Click(object sender, EventArgs e)
        {

            txtCodeDesignation.Text = "";
            txtNameDesignation.Text = "";
            btnNewDesignation.Text = "New";
            txtNameDesignation.Enabled = false;
        }

        #endregion

        #region Update Function
        private void GridViewDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridViewDepartment.Columns["Edit"].Index)
            {
                int _rowIndex = GridViewDepartment.CurrentCell.RowIndex;
                _refId = int.Parse(GridViewDepartment.Rows[_rowIndex].Cells["Ref_ID"].Value.ToString());
                txtCodeDepartment.Text = GridViewDepartment.Rows[_rowIndex].Cells["SLASH_CODE"].Value.ToString();
                txtNameDepartment.Text = GridViewDepartment.Rows[_rowIndex].Cells["SLASH_DESC"].Value.ToString();
                btnNewDepartment.Text = "Update";
                txtNameDepartment.Enabled = true;
            }
            else if (e.ColumnIndex == GridViewDepartment.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    int _rowIndex = GridViewDepartment.CurrentCell.RowIndex;
                    _refId = int.Parse(GridViewDepartment.Rows[_rowIndex].Cells["Ref_ID"].Value.ToString());
                    _mController.UpdateSlashCodes(_refId, null, Constants.Employee_Depoartment_Id, null, 1, false, Constants.DateNullValue);
                    this.LoadBusinessType();

                }
            }
        }
        //////
        private void GridViewDesignation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridViewDesignation.Columns["Edit"].Index)
            {
                int _rowIndex = GridViewDesignation.CurrentCell.RowIndex;
                _refId = int.Parse(GridViewDesignation.Rows[_rowIndex].Cells["Ref_ID"].Value.ToString());
                txtCodeDesignation.Text = GridViewDesignation.Rows[_rowIndex].Cells["SLASH_CODE"].Value.ToString();
                txtNameDesignation.Text = GridViewDesignation.Rows[_rowIndex].Cells["SLASH_DESC"].Value.ToString();
                btnNewDesignation.Text = "Update";
                txtNameDesignation.Enabled = true;
            }
            else if (e.ColumnIndex == GridViewDesignation.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    int _rowIndex = GridViewDesignation.CurrentCell.RowIndex;
                    _refId = int.Parse(GridViewDesignation.Rows[_rowIndex].Cells["Ref_ID"].Value.ToString());
                    if (_refId == 36 || _refId == 681)
                    {
                        MessageBox.Show(this, "You Can't Delete this", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _mController.UpdateSlashCodes(_refId, null, Constants.Employee_Designation_Id, null, 1, false, Constants.DateNullValue);
                    this.LoadChannelType();
                }
            }
        }
        #endregion

        #region Button New Functions Events
        private void btnNewDepartment_Click(object sender, EventArgs e)
        {
            txtNameDepartment.Enabled = true;
            Save_Update_Department();
        }
        public void Save_Update_Department()
        {
            if (btnNewDepartment.Text == "New")
            {
                txtCodeDepartment.Text = this.GetAutoCode("DPT", 0, Constants.LongNullValue);
                txtNameDepartment.Enabled = true;
                txtNameDepartment.Focus();
                btnNewDepartment.Text = "Save";
            }
            else if (btnNewDepartment.Text == "Save")
            {
                if (txtNameDepartment.TextLength == 0)
                {
                    ToastNotification.Show(this, "Please Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.InsertSlashCodes(txtCodeDepartment.Text, Constants.Employee_Depoartment_Id, txtNameDepartment.Text, 1, true);
                this.GetAutoCode("DPT", 1, long.Parse(txtCodeDepartment.Text.Substring(3)));
                this.LoadBusinessType();
                ResetFiledsDepartment();
                txtNameDepartment.Enabled = false;
                btnNewDepartment.Text = "New";
            }
            else if (btnNewDepartment.Text == "Update")
            {
                _mController.UpdateSlashCodes(_refId, null, Constants.Employee_Depoartment_Id, txtNameDepartment.Text, 1, true, Constants.DateNullValue);
                this.LoadBusinessType();
                ResetFiledsDepartment();
                txtNameDepartment.Enabled = false;
                btnNewDepartment.Text = "New";
            }
        }
        public void Save_Update_Designation()
        {
            if (btnNewDesignation.Text == "New")
            {
                txtCodeDesignation.Text = this.GetAutoCode("DSG", 0, Constants.LongNullValue);
                txtNameDesignation.Enabled = true;
                txtNameDesignation.Focus();
                btnNewDesignation.Text = "Save";

            }
            else if (btnNewDesignation.Text == "Save")
            {
                if (txtNameDesignation.TextLength == 0)
                {
                    ToastNotification.Show(this, "Please Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.InsertSlashCodes(txtCodeDesignation.Text, Constants.Employee_Designation_Id, txtNameDesignation.Text, 1, true);
                this.GetAutoCode("DSG", 1, long.Parse(txtCodeDesignation.Text.Substring(3)));
                this.LoadChannelType();
                ResetFiledsDesignation();
                txtNameDesignation.Enabled = false;
                btnNewDesignation.Text = "New";
            }
            else if (btnNewDesignation.Text == "Update")
            {
                if (txtNameDesignation.TextLength == 0)
                {
                    ToastNotification.Show(this, "Please Enter Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                _mController.UpdateSlashCodes(_refId, null, Constants.Employee_Designation_Id, txtNameDesignation.Text, 1, true, Constants.DateNullValue);
                this.LoadChannelType();
                ResetFiledsDesignation();
                txtNameDesignation.Enabled = false;
                btnNewDesignation.Text = "New";
            }
        }
        private string GetAutoCode(string preeFix, int codeType, long cValue)
        {
            var autoCode = new SETTINGS_TABLE_Controller();
            return autoCode.GetAutoCode(preeFix, codeType, cValue);
        }
        #endregion

        private void btnNewDesignation_Click(object sender, EventArgs e)
        {
            txtNameDesignation.Enabled = true;
            Save_Update_Designation();
        }

        private void FormDepartment_Designation_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 510, 195);
            groupPanel3.Location = new Point(points[0], points[1]);
        }
    }
}
