using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormNewLocation2 : Form
    {
        DistributorController mController = new DistributorController();
        
        //private static int CompanyId;

        public FormNewLocation2()
        {
            InitializeComponent();
        }

        #region Add NEw Location Button Click Event
        private void btnAddNewLocation_Click(object sender, EventArgs e)
        {
            NewLocationProperties._newOrEdit = "New";
            PopUpNewLocation _formNewLocationPpUp = new PopUpNewLocation();
            _formNewLocationPpUp.ShowDialog();
        } 
        #endregion

        #region Load Functions

        private void FormNewLocation2_Load(object sender, EventArgs e)
        {
            //try
            //{
                //clsStatusBar.SetStatusBar("Loading...");
                this.LoadGird();
                btnActiveNewLocation.Focus();
                GridDistributor.ColumnHeadersDefaultCellStyle.BackColor = Color.Snow;
                GridDistributor.EnableHeadersVisualStyles = false;
            //}
            //catch (Exception)
            //{ }
        } 

        private void LoadGird()
        {
            GridDistributor.DataSource = null;
            GridDistributor.Rows.Clear();
            DataTable dtDistributor = new DataTable();
            dtDistributor.Rows.Clear();
            dtDistributor = mController.SelectAllDistributors(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);

            // load Grid
           
            GridDistributor.DataSource = dtDistributor;
           
            // Change Columns Names

            GridDistributor.Columns["DISTRIBUTOR_CODE"].HeaderText = "Label Name";
            GridDistributor.Columns["DISTRIBUTOR_NAME"].HeaderText = "Name";
            GridDistributor.Columns["ADDRESS1"].HeaderText = "Address";
            GridDistributor.Columns["CONTACT_PERSON"].HeaderText = "Contact Person";
            GridDistributor.Columns["CONTACT_NUMBER"].HeaderText = "Contact Number";
            GridDistributor.Columns["TYPENAME"].HeaderText = "Type";
            GridDistributor.Columns["ISDELETED"].HeaderText = "Status";

            


            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GridDistributor.Columns.Add(checkColumn);
            GridDistributor.Columns["SELECT"].HeaderText = "";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridDistributor.Columns.Add(btnEdit);

            // Set Width Of Columns
            GridDistributor.Columns["Select"].Width = 20;
            GridDistributor.Columns["Edit"].Width = 50;
            GridDistributor.Columns["DISTRIBUTOR_CODE"].Width = 140;
            GridDistributor.Columns["DISTRIBUTOR_NAME"].Width = 140;
            //GridDistributor.Columns["ADDRESS1"].Width = 510;
            GridDistributor.Columns["CONTACT_PERSON"].Width = 150;
            GridDistributor.Columns["CONTACT_NUMBER"].Width = 150;
            GridDistributor.Columns["TYPENAME"].Width = 100;
            GridDistributor.Columns["ISDELETED"].Width = 70;
            GridDistributor.Columns["ADDRESS1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridDistributor.Columns["CONTACT_NUMBER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridDistributor.Columns["TYPENAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridDistributor.Columns["ISDELETED"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridDistributor.Columns["DISTRIBUTOR_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridDistributor.Columns["DISTRIBUTOR_CODE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GridDistributor.Columns["CONTACT_PERSON"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            
            GridDistributor.Columns["Edit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridDistributor.Columns["Select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridDistributor.Columns["ISDELETED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridDistributor.Columns["ISDELETED"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


           
            ////// Sequence (Visibel)
            //GridDistributor.Columns["Edit"].DisplayIndex = 8;

            //GridDistributor.Columns["DISTRIBUTOR_CODE"].DisplayIndex = GridDistributor.Columns["DISTRIBUTOR_NAME"].DisplayIndex + 1;
            //GridDistributor.Columns["DISTRIBUTOR_NAME"].DisplayIndex = 1;


            GridDistributor.Columns["Select"].DisplayIndex = 0;
            GridDistributor.Columns["COMPANY_ID"].Visible = false;
            GridDistributor.Columns["DISTRIBUTOR_ID"].Visible = false;
            GridDistributor.Columns["PASSWORD"].Visible = false;
            GridDistributor.Columns["ADDRESS2"].Visible = false;
            GridDistributor.Columns["SUBZONE_ID"].Visible = false;
            GridDistributor.Columns["GST_NUMBER"].Visible = false;
            GridDistributor.Columns["IS_REGISTERED"].Visible = false;
            GridDistributor.Columns["ISMANUALDISCOUNT"].Visible = false;
            GridDistributor.Columns["Logo"].Visible = false;
            GridDistributor.Columns["DIST_CLASS_ID"].Visible = false;
            GridDistributor.Columns["ShowLogo"].Visible = false;

            foreach (DataGridViewColumn clms in GridDistributor.Columns)
            {
                clms.ReadOnly = true;
            }
            GridDistributor.Columns["Select"].ReadOnly = false;
        }

        public void RefreshGridView()
        {
            GridDistributor.Columns.Remove("Edit");
            GridDistributor.Columns.Remove("Select");
            this.LoadGird();
        }
       
        #endregion

        #region Edit Distributor
        private void GridDistributor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridDistributor.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridDistributor.Columns["Edit"].Index)
            {
                NewLocationProperties._distributorId = int.Parse(GridDistributor.Rows[_rowIndex].Cells["DISTRIBUTOR_ID"].Value.ToString());
                if (GridDistributor.Rows[_rowIndex].Cells["IS_REGISTERED"].Value.ToString() == "True")
                {

                }
                NewLocationProperties._isRegistered = bool.Parse(GridDistributor.Rows[_rowIndex].Cells["IS_REGISTERED"].Value.ToString());
                NewLocationProperties._distributorType = GridDistributor.Rows[_rowIndex].Cells["TYPENAME"].Value.ToString();
                NewLocationProperties._distributorCode = GridDistributor.Rows[_rowIndex].Cells["DISTRIBUTOR_CODE"].Value.ToString();
                NewLocationProperties._distributorName = GridDistributor.Rows[_rowIndex].Cells["DISTRIBUTOR_NAME"].Value.ToString();
                NewLocationProperties._address = GridDistributor.Rows[_rowIndex].Cells["ADDRESS1"].Value.ToString();
                NewLocationProperties._emailAddress = GridDistributor.Rows[_rowIndex].Cells["ADDRESS2"].Value.ToString();
                NewLocationProperties._phoneNo = GridDistributor.Rows[_rowIndex].Cells["CONTACT_NUMBER"].Value.ToString();
                NewLocationProperties._gstNo = GridDistributor.Rows[_rowIndex].Cells["GST_NUMBER"].Value.ToString().Replace("&nbsp;", "");
                NewLocationProperties._companyName = Convert.ToInt32(GridDistributor.Rows[_rowIndex].Cells["COMPANY_ID"].Value);
                NewLocationProperties._isActive = GridDistributor.Rows[_rowIndex].Cells["ISDELETED"].Value.ToString();
                NewLocationProperties._contactPerson = GridDistributor.Rows[_rowIndex].Cells["CONTACT_PERSON"].Value.ToString();
                NewLocationProperties._Deliveryman = false;
                NewLocationProperties._ShowLogo = bool.Parse(GridDistributor.Rows[_rowIndex].Cells["ShowLogo"].Value.ToString());
                if (Convert.ToInt32(GridDistributor.Rows[_rowIndex].Cells["DIST_CLASS_ID"].Value) == 1)
                {
                    NewLocationProperties._Deliveryman = true;
                }
                try
                {
                    NewLocationProperties._Logo = null;
                    NewLocationProperties._Logo = (byte[])GridDistributor.Rows[_rowIndex].Cells["Logo"].Value;
                }
                catch (Exception)
                {
                }
                NewLocationProperties._newOrEdit = "Edit";
                PopUpNewLocation _popUpNewLocation = new PopUpNewLocation();
                _popUpNewLocation.ShowDialog();
            }
        } 
        #endregion

        #region Filter Grid Function
        private void txtFilterDistributors_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridDistributor.DataSource).DefaultView.RowFilter = "DISTRIBUTOR_CODE LIKE '%" + txtSearchDistributors.Text + "%' OR DISTRIBUTOR_NAME LIKE '%" + txtSearchDistributors.Text + "%' OR ADDRESS1 LIKE '%" + txtSearchDistributors.Text + "%' OR CONTACT_PERSON LIKE '%" + txtSearchDistributors.Text + "%' OR CONTACT_NUMBER LIKE '%" + txtSearchDistributors.Text + "%'  OR TYPENAME LIKE '%" + txtSearchDistributors.Text + "%'";
        } 
        #endregion

        #region Active Button Click Function
        private void btnActiveNewLocation_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in GridDistributor.Rows)
                {
                    bool chRelized = Convert.ToBoolean(dr.Cells["Select"].Value);
                    int DistributorId = Convert.ToInt32(dr.Cells["DISTRIBUTOR_ID"].Value);
                    int CompanyId = Convert.ToInt32(dr.Cells["COMPANY_ID"].Value);
                    if (chRelized)
                    {
                        if (dr.Cells["ISDELETED"].Value.ToString() == "In Active")
                        {
                            mController.UpdateDistributor(CompanyId, Constants.IntNullValue, false, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                                    , Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, null, null, null, null, DistributorId, null,
                                    null, null, true, 1, Constants.IntNullValue,null, 0,true);
                        }
                        else
                        {
                            mController.UpdateDistributor(CompanyId, Constants.IntNullValue, true, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                                    , Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, null, null, null, null, DistributorId, null,
                                    null, null, true, 1, Constants.IntNullValue, null, 0, true);
                        }
                    }
                }
                ToastNotification.Show(this, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                RefreshGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        private void ChkAllGrid_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridDistributor.Rows.Count;
            if (ChkAllGrid.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridDistributor.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridDistributor.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
    }
}
