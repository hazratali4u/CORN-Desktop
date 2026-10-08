using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using DevComponents.DotNetBar;
using CORNDataAccessLayer.Classes;

namespace CORNPointOfSale
{
    public partial class FormSKU_Group : Form
    {
        SKUGroupController gController = new SKUGroupController();
        DataView dv;
        private static int SKUGroupID = 0;

        public FormSKU_Group()
        {
            InitializeComponent();
        }

        #region Load Functions
        //
        //  Load Form
        //
        #region Load Form
        private void FormSKU_Group_Load(object sender, EventArgs e)
        {
            LoadGroup();

            //  Set Selected Row
            if (GridSKUgroupDetail.Rows.Count > 0)
            {
                GridSKUgroupDetail.Rows[0].Selected = true;
            }
        } 
        #endregion
        //
        //  Load Group
        //
        #region Load Group
        public void LoadGroup()
        {
            DataTable dt1 = gController.GET_Group_ID(int.Parse(SessionClass.CompanyID.ToString()));
            GridSKUgroup.DataSource = dt1;
            ArrangeGridGroup();

            int _rows = GridSKUgroup.Rows.Count;
            if (_rows > 0)
            {
                //lblGroupID.Text = GridSKUgroup.Rows[GridSKUgroup.CurrentCell.RowIndex].Cells[0].Value.ToString();
                lblGroupID.Text = "1";
                LoadGroupDetail();
            }
        } 
        #endregion
        //
        //  Load Group Detail
        //
        #region Load Group Detail
        protected void LoadGroupDetail()
        {
            DataTable dt = gController.GET_SKUGroupDetail(int.Parse(SessionClass.CompanyID.ToString()), 2, Convert.ToInt32(lblGroupID.Text));
            GridSKUgroupDetail.DataSource = dt;
            ArrangeGridDetial();
        }  
        #endregion
        #endregion

        #region Arrange Grid
        
        //
        public void ArrangeGridGroup()
        {
            try
            {
                GridSKUgroupDetail.Columns.Remove("Edit");
            }
            catch (Exception)
            { }

            GridSKUgroup.Columns["SKU_GROUP_ID"].HeaderText = "Group ID";
            GridSKUgroup.Columns["GROUP_NAME"].HeaderText = "Group Name";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridSKUgroup.Columns.Add(btnEdit);

            // Width
            GridSKUgroup.Columns["SKU_GROUP_ID"].Width = 100;
            GridSKUgroup.Columns["GROUP_NAME"].Width = 230;
            GridSKUgroup.Columns["Edit"].Width = 50;
        }
        
        //
        public void ArrangeGridDetial()
        {
            GridSKUgroupDetail.Columns["SKU_GROUP_ID"].Visible = false;
            GridSKUgroupDetail.Columns["SKU_ID"].Visible = false;
            GridSKUgroupDetail.Columns["SKU_GROUP_DETAIL_ID"].Visible = false;
            GridSKUgroupDetail.Columns["GROUP_NAME"].HeaderText = "Group Name";
            GridSKUgroupDetail.Columns["SKU_NAME"].HeaderText = "Item Name";
            GridSKUgroupDetail.Columns["SKUDETAIL"].HeaderText = "Item Detail";

            // Width
            GridSKUgroupDetail.Columns["GROUP_NAME"].Width = 150;
            GridSKUgroupDetail.Columns["SKU_NAME"].Width = 250;
            GridSKUgroupDetail.Columns["SKUDETAIL"].Width = 520;
        }
        #endregion

        #region Common Functions
        private void GridSKUgroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void GridSKUgroup_MouseHover(object sender, EventArgs e)
        {

            ToastNotification.Show(this, "Select Group Row To Show Group Detail", 1500, eToastPosition.BottomLeft);
        }
        #endregion

        #region Update Function
        private void GridSKUgroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridSKUgroup.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridSKUgroup.Columns["Edit"].Index)
            {
                SKU_GroupProperties._newOrUpdate = "Update";
                PopUpSkuGroup _PopUp = new PopUpSkuGroup();
                _PopUp.lstAssignSkus.DataSource = null;
                SKUGroupID = Convert.ToInt32(GridSKUgroup.Rows[_rowIndex].Cells["SKU_GROUP_ID"].Value.ToString());
                _PopUp.lblGroupIDPopUp.Text = SKUGroupID.ToString();
                _PopUp.txtGroupName.Text = GridSKUgroup.Rows[_rowIndex].Cells["GROUP_NAME"].Value.ToString();
                DataTable dt = gController.GET_SKUGroupDetail(int.Parse(SessionClass.CompanyID.ToString()), 2, SKUGroupID);
                _PopUp.dtSKUS_assigned = dt;
                _PopUp.lstAssignSkus.DataSource = _PopUp.dtSKUS_assigned;
                _PopUp.lstAssignSkus.DisplayMember = "SKUDETAIL";
                _PopUp.lstAssignSkus.ValueMember = "SKU_ID";
                _PopUp.btnSave.Text = "Update";
                _PopUp.ShowDialog();
            }
            else
            {
                lblGroupID.Text = GridSKUgroup.Rows[GridSKUgroup.CurrentCell.RowIndex].Cells[1].Value.ToString();
                GridSKUgroupDetail.DataSource = null;
                GridSKUgroupDetail.Rows.Clear();
                LoadGroupDetail();
            }
        } 
        #endregion

        private void btnAddNewGroup_Click(object sender, EventArgs e)
        {
            SKU_GroupProperties._newOrUpdate = "New";
            PopUpSkuGroup _popFormSkuGroup = new PopUpSkuGroup();
            _popFormSkuGroup.ShowDialog();
        }

        private void txtSearchGroupDetail_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridSKUgroupDetail.DataSource).DefaultView.RowFilter = "GROUP_NAME LIKE '%" + txtSearchGroupDetail.Text + "%' OR SKU_NAME LIKE '%" + txtSearchGroupDetail.Text + "%' OR SKUDETAIL LIKE '%" + txtSearchGroupDetail.Text + "%' ";
        }

        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)GridSKUgroup.DataSource).DefaultView.RowFilter = "GROUP_NAME LIKE '%" + txtSearchGroup.Text + "%'  ";
        }
    }
}
