using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormTil : Form
    {
        int _tilID;
        public FormTil()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserController m_controller = new UserController();
            if (btnSave.Text == "New")
            {
                txtDescription.Enabled = true;
                txtDescription.Focus();
                btnSave.Text = "Save";
            }
            else if (btnSave.Text == "Save")
            {
                if (txtDescription.TextLength == 0)
                {
                    return;
                }
                bool _result = m_controller.InsertTil(Convert.ToInt32(ddLocation.SelectedValue.ToString()), txtDescription.Text, 0);
                if (_result == true)
                {
                    ToastNotification.Show(this, "Added Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    txtDescription.Text = "";
                    txtDescription.Enabled = false;
                    btnSave.Text = "New";
                    LoadTil();
                }
                else
                {
                    ToastNotification.Show(this, "Some error occured", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
            }
            else if (btnSave.Text == "Update")
            {
                m_controller.UpdateTil(_tilID, Convert.ToInt32(ddLocation.SelectedValue.ToString()),txtDescription.Text, true);
                this.LoadTil();
                txtDescription.Enabled = false;
                btnSave.Text = "New";
                txtDescription.Text = "";
            }
        }

        private void FormTil_Load(object sender, EventArgs e)
        {
            LoadDistributor();
            LoadTil();
        }
        public void LoadTil()
        {
            if (ddLocation.DisplayMember == "DISTRIBUTOR_NAME" && ddLocation.ValueMember == "DISTRIBUTOR_ID" && ddLocation.Items.Count > 0)
            {
                UserController _mController = new UserController();
                DataTable dt = _mController.SelectTil(Convert.ToInt32(ddLocation.SelectedValue.ToString()), 1);
                GridTill.DataSource = dt;
                ArrangeGrid();
            }
        }
        public void LoadDistributor()
        {
            ddLocation.DataSource = null;
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            ddLocation.DataSource = dt;
            ddLocation.DisplayMember = "DISTRIBUTOR_NAME";
            ddLocation.ValueMember = "DISTRIBUTOR_ID";
            if (ddLocation.Items.Count > 0)
            {
                ddLocation.SelectedIndex = 0;
            }
        }
        public void ArrangeGrid()
        {
            try
            {
                GridTill.Columns.Remove("Edit");
                GridTill.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            foreach (DataGridViewColumn clm in GridTill.Columns)
            {
                clm.Visible = false;
            }
            GridTill.Columns["TIL_DESCRIPTION"].Visible = true;
            GridTill.Columns["TIL_DESCRIPTION"].HeaderText = "Til Description";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridTill.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GridTill.Columns.Add(btnDelete);

            // Set Columns width
            GridTill.Columns["TIL_DESCRIPTION"].Width = 370;
            GridTill.Columns["Edit"].Width = 50;
            GridTill.Columns["Delete"].Width = 70;
        }

        private void ddLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTil();
        }

        private void GridTill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridTill.Columns["Edit"].Index)
            {
                _tilID = int.Parse(GridTill.Rows[e.RowIndex].Cells["TIL_ID"].Value.ToString());
                txtDescription.Text = GridTill.Rows[e.RowIndex].Cells["TIL_DESCRIPTION"].Value.ToString();
                ddLocation.SelectedValue =Convert.ToInt32(GridTill.Rows[e.RowIndex].Cells["LOCATION_ID"].Value.ToString());
                btnSave.Text = "Update";
                txtDescription.Enabled = true;
            }
            else if (e.ColumnIndex == GridTill.Columns["Delete"].Index)
            {
                if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure ?"))
                {
                    UserController m_controller = new UserController();
                    _tilID = Convert.ToInt32(GridTill.Rows[e.RowIndex].Cells["TIL_ID"].Value.ToString());
                    m_controller.UpdateTil(_tilID,Constants.IntNullValue,null,false);
                    this.LoadTil();
                }
            }
        }

        private void FormTil_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 280, 160);
            groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
