using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.Collections.Generic;

namespace CORNPointOfSale
{
    public partial class FormSlipNotes : Form
    {
        DataTable dt;
        DataTable dt_Notes;
        DataTable dTable;
        int _noteID;
        DistributorController m_Controller = new DistributorController();
        public FormSlipNotes()
        {
            InitializeComponent();
        }

        private void FormSlipNotes_Load(object sender, EventArgs e)
        {
            CreateTable();
            LoadLocations();
            //ChkAll_CheckedChanged(null, null);
            LoadSlipNotes();
        }
        public void CreateTable()
        {
            dt_Notes = new DataTable();
            dt_Notes.Columns.Add("SLIP_NOTE", typeof(string));
            dt_Notes.Columns.Add("IS_ACTIVE", typeof(bool));
        }
        public void LoadLocations()
        {
            DataTable dt = m_Controller.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue, SessionClass.CompanyID);
            ChkListLocation.DataSource = dt;
            ChkListLocation.DisplayMember = "DISTRIBUTOR_NAME";
            ChkListLocation.ValueMember = "DISTRIBUTOR_ID";
        }
        public void LoadSlipNotes()
        {
            dt = m_Controller.GetSlipNotes(1,Constants.IntNullValue);
            GridNotes.DataSource = dt;
            ArrangeGrid();
            GetLocations(0);
        }
        public void GetLocations(int _rowIndex)
        {
            int _rows = ChkListLocation.Items.Count;
            for (int i = 0; i < _rows; i++)
            {
                ChkListLocation.SetItemChecked(i, false);
            }
            if (GridNotes.Rows.Count > 0)
            {
                int value;
                _noteID = Convert.ToInt32(GridNotes.Rows[_rowIndex].Cells["NOTE_ID"].Value);
                DataTable dt = m_Controller.GetSlipNotes(2, _noteID);
                List<int> ids = new List<int>(dt.Rows.Count);
                foreach(DataRow row in dt.Rows)
                {
                    ids.Add((int)row["DISTRIBUTOR_ID"]);
                }
                _rows = ChkListLocation.Items.Count;
                for (int i = 0; i < _rows; i++)
                {
                    DataRowView view = ChkListLocation.Items[i] as DataRowView;
                     value = (int)view["DISTRIBUTOR_ID"];
                     if (ids.Contains(value))
                     {
                         ChkListLocation.SetItemChecked(i, true);
                     }
                }
            }
        }
        public void ArrangeGrid()
        {
            try
            {
                GridNotes.Columns.Remove("Edit");
                GridNotes.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            GridNotes.Columns["NOTE_ID"].Visible = false;
            GridNotes.Columns["IS_ACTIVE"].Visible = false;
            //GridNotes.Columns["SLIP_ID"].Visible = false;
            //GridNotes.Columns["Account_Head_ID"].HeaderText = "Code";
            //GridNotes.Columns["Account_Detail"].HeaderText = "Account Name";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridNotes.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GridNotes.Columns.Add(btnDelete);

            // Set Columns width
            GridNotes.Columns["SLIP_NOTE"].Width = 580;
            GridNotes.Columns["Edit"].Width = 50;
            GridNotes.Columns["Delete"].Width = 70;
        }
        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            int _items = ChkListLocation.Items.Count;
            if (ChkAll.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListLocation.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    ChkListLocation.SetItemChecked(i, false);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNotes.TextLength <= 0)
            {
                txtNotes.Focus();
                return;
            }
            int _items = ChkListLocation.Items.Count;
            bool _LocationSelected = false;
            for (int i = 0; i < _items; i++)
            {
                if (ChkListLocation.GetItemChecked(i))
                {
                    _LocationSelected = true;
                }
            }
            if (_LocationSelected == false)
            {
                MessageBox.Show(this, "Please select atleast one location", "CORN:POS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (btnAdd.Text == "Add")
            {
                int _noteID = m_Controller.InsertSlipNote_Master(txtNotes.Text, true);
                if (_noteID != 0)
                {
                    for (int i = 0; i < _items; i++)
                    {
                        if (ChkListLocation.GetItemChecked(i) == true)
                        {
                            DataRowView drV = (DataRowView)ChkListLocation.Items[i];
                            DataRow dr = drV.Row;
                            int _Distributor_id = Convert.ToInt32(dr["DISTRIBUTOR_ID"].ToString());
                            m_Controller.InsertSlipNote_Detail(_noteID, _Distributor_id);
                        }
                    }
                }
                LoadSlipNotes();
                txtNotes.Text = "";
            }
            else if (btnAdd.Text == "Update")
            {
                m_Controller.UpdateSlipNote_Master(_noteID, txtNotes.Text, true, 2);
                for (int i = 0; i < _items; i++)
                {
                    if (ChkListLocation.GetItemChecked(i) == true)
                    {
                        DataRowView drV = (DataRowView)ChkListLocation.Items[i];
                        DataRow dr = drV.Row;
                        int _Distributor_id = Convert.ToInt32(dr["DISTRIBUTOR_ID"].ToString());
                        m_Controller.InsertSlipNote_Detail(_noteID, _Distributor_id);
                    }
                }
                LoadSlipNotes();
                btnAdd.Text = "Add";
                txtNotes.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNotes.Text = "";
            ChkAll.Checked = false;
            GetLocations(0);
        }

        private void GridNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChkAll.Checked = false;
            _noteID = Convert.ToInt32(GridNotes.Rows[e.RowIndex].Cells["NOTE_ID"].Value);
            GetLocations(e.RowIndex);
            if (e.ColumnIndex == GridNotes.Columns["Edit"].Index)
            {
                txtNotes.Text = GridNotes.Rows[e.RowIndex].Cells["SLIP_NOTE"].Value.ToString();
                btnAdd.Text = "Update";
            }
            else if (e.ColumnIndex == GridNotes.Columns["Delete"].Index)
            {
                int _rowIndex = GridNotes.CurrentCell.RowIndex;
                if (clsWindowsFormUtil.DeleteConfirmation("Are you sure to delete?"))
                {
                    m_Controller.UpdateSlipNote_Master(_noteID,"", false, 1);
                    LoadSlipNotes();
                }
            }

        }
        private void ChkListLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkAll.Checked = false;
        }
    }
}
