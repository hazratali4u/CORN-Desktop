using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormShift : Form
    {
        Distributor_UserController mCtrl = new Distributor_UserController();
        int _shiftID;
             
        public FormShift()
        {
            InitializeComponent();
        }
        private void FormShift_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            LoadShift();
        }
        public void LoadShift()
        {
            if (ddLocation.DisplayMember == "DISTRIBUTOR_NAME" && ddLocation.ValueMember == "DISTRIBUTOR_ID" && ddLocation.Items.Count > 0)
            {
                UserController _mCtrl = new UserController();
                DataTable dt = new DataTable();
                dt = _mCtrl.SelectShift(Convert.ToInt32(ddLocation.SelectedValue.ToString()), 2);
                GridShift.DataSource = dt;
                ArrangeGrid();
            }
        }
        public void ArrangeGrid()
        {
            try
            {
                GridShift.Columns.Remove("Edit");
                GridShift.Columns.Remove("Delete");
            }
            catch (Exception)
            { }

            GridShift.Columns["SHIFT_ID"].Visible = false;
            GridShift.Columns["LOCATIOn_ID"].Visible = false;

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridShift.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GridShift.Columns.Add(btnDelete);

            // Set Columns width
            GridShift.Columns["Start Time"].Width = 235;
            GridShift.Columns["End Time"].Width = 235;
            GridShift.Columns["Edit"].Width = 50;
            GridShift.Columns["Delete"].Width = 60;
        }
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, 1);
            ddLocation.DataSource = dtDistributor;
            ddLocation.DisplayMember = "DISTRIBUTOR_NAME";
            ddLocation.ValueMember = "DISTRIBUTOR_ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddLocation.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Please Select a Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (btnSave.Text == "New")
            {
                ddLocation.Focus();
                txtShiftFrom.Value = System.DateTime.Now;
                txtShiftTo.Value = System.DateTime.Now;
                txtShiftFrom.Enabled = true;
                txtShiftTo.Enabled = true;
                btnSave.Text = "Save";
            }
            else if (btnSave.Text == "Save")
            {
                bool _result = mCtrl.InsertShift(Convert.ToInt32(ddLocation.SelectedValue.ToString()), 
                                                    txtShiftFrom.Value.ToString("HH:mm"), 
                                                    txtShiftTo.Value.ToString("HH:mm"));
                if (_result)
                {
                    LoadShift();
                    ToastNotification.Show(this, "Added Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    txtShiftFrom.Value = System.DateTime.Now;
                    txtShiftTo.Value = System.DateTime.Now;
                    txtShiftFrom.Enabled = false;
                    txtShiftTo.Enabled = false;
                    btnSave.Text = "New";
                }
                else
                {
                    ToastNotification.Show(this, "Some error occured", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                } 
            }
            else if (btnSave.Text == "Update")
            {
                bool _result = mCtrl.UpdateShift(_shiftID, Convert.ToInt32(ddLocation.SelectedValue.ToString()), Convert.ToDateTime(txtShiftFrom.Value), Convert.ToDateTime(txtShiftTo.Value), true,2);
                if (_result)
                {
                    LoadShift();
                    ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    txtShiftFrom.Value = System.DateTime.Now;
                    txtShiftTo.Value = System.DateTime.Now;
                    txtShiftFrom.Enabled = false;
                    txtShiftTo.Enabled = false;
                    btnSave.Text = "New";
                }
                else
                {
                    ToastNotification.Show(this, "Some error occured", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                } 
            }
        }

        private void ddLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShift();
        }

        private void GridShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridShift.Columns["Edit"].Index)
            {
                _shiftID = int.Parse(GridShift.Rows[e.RowIndex].Cells["SHIFT_ID"].Value.ToString());
                txtShiftFrom.Text = GridShift.Rows[e.RowIndex].Cells["Start Time"].Value.ToString();
                txtShiftTo.Text = GridShift.Rows[e.RowIndex].Cells["End Time"].Value.ToString();
                ddLocation.SelectedValue = Convert.ToInt32(GridShift.Rows[e.RowIndex].Cells["LOCATION_ID"].Value.ToString());
                btnSave.Text = "Update";
                txtShiftFrom.Enabled = true;
                txtShiftTo.Enabled = true;
            }
            else if (e.ColumnIndex == GridShift.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    Distributor_UserController m_controller = new Distributor_UserController();
                    _shiftID = Convert.ToInt32(GridShift.Rows[e.RowIndex].Cells["SHIFT_ID"].Value.ToString());
                    m_controller.UpdateShift(_shiftID, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, false,1);
                    this.LoadShift();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "New";
            txtShiftFrom.Enabled = false;
            txtShiftTo.Enabled = false;
        }

        private void FormShift_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 360, 190);
            groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
