using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using CORNDataAccessLayer.Classes;

namespace CORNPointOfSale
{
    public partial class PopUpSkuGroup : Form
    {
        SKUGroupController gController = new SKUGroupController();
        DataTable dtSKUS_unassigned;
        public DataTable dtSKUS_assigned;
        public PopUpSkuGroup()
        {
            InitializeComponent();
        }

        #region Common Function
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Assign & UnAssign Functions

        //
        //  Assign Single SKU
        //
        #region Assign Single SKU
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lstUnAssignSkus.Items.Count > 0)
            {
                bool _Exists = false;
                int _value = Convert.ToInt32(lstUnAssignSkus.SelectedValue.ToString());
                DataRow[] dr = dtSKUS_unassigned.Select("SKU_ID = '" + _value + "'");
                DataRow[] drAssign = dtSKUS_assigned.Select("SKU_ID = '" + _value + "'");
                int _items = dtSKUS_assigned.Rows.Count;
                for (int i = 0; i < _items; i++)
                {
                    if (_value == Convert.ToInt32(dtSKUS_assigned.Rows[i].Field<int>("SKU_ID").ToString()))
                    {
                        dtSKUS_unassigned.Rows.Remove(dr[0]);
                        _Exists = true;
                        return;
                    }
                }
                if (_Exists == false)
                {
                    dtSKUS_assigned.ImportRow(dr[0]);
                    lstAssignSkus.DataSource = dtSKUS_assigned;
                    lstAssignSkus.DisplayMember = "SKUDETAIL";
                    lstAssignSkus.ValueMember = "SKU_ID";
                    dtSKUS_unassigned.Rows.Remove(dr[0]);
                    lstUnAssignSkus.DataSource = null;
                    lstUnAssignSkus.DataSource = dtSKUS_unassigned;
                    lstUnAssignSkus.DisplayMember = "SKUDETAIL";
                    lstUnAssignSkus.ValueMember = "SKU_ID";
                }
            }
        } 
        #endregion
        //
        //  Assign All SKU
        //
        #region Assign All SKUS
        private void btnAssignAll_Click(object sender, EventArgs e)
        {
            dtSKUS_assigned.Rows.Clear();
            dtSKUS_unassigned.Rows.Clear();
            lstAssignSkus.DataSource = null;
            lstUnAssignSkus.DataSource = null;
            //
            //
            SkuController mContoller = new SkuController();
            dtSKUS_assigned = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
            lstAssignSkus.DataSource = dtSKUS_assigned;
            lstAssignSkus.DisplayMember = "SKUDETAIL";
            lstAssignSkus.ValueMember = "SKU_ID";
        } 
        #endregion
        //
        //  UnAssign Single SKU
        //
        #region UnAssign Single SKU
        private void btnUnAssign_Click(object sender, EventArgs e)
        {
            if (lstAssignSkus.Items.Count > 0)
            {
                bool _Exists = false;
                int _value = Convert.ToInt32(lstAssignSkus.SelectedValue.ToString());
                DataRow[] dr = dtSKUS_assigned.Select("SKU_ID = '" + _value + "'");
                DataRow[] drAssign = dtSKUS_unassigned.Select("SKU_ID = '" + _value + "'");
                int _items = dtSKUS_unassigned.Rows.Count;
                for (int i = 0; i < _items; i++)
                {
                    if (_value == Convert.ToInt32(dtSKUS_unassigned.Rows[i].Field<int>("SKU_ID").ToString()))
                    {
                        dtSKUS_assigned.Rows.Remove(dr[0]);
                        _Exists = true;
                        return;
                    }
                }
                if (_Exists == false)
                {
                    dtSKUS_unassigned.ImportRow(dr[0]);
                    lstUnAssignSkus.DataSource = dtSKUS_unassigned;
                    lstUnAssignSkus.DisplayMember = "SKUDETAIL";
                    lstUnAssignSkus.ValueMember = "SKU_ID";
                    dtSKUS_assigned.Rows.Remove(dr[0]);
                    lstAssignSkus.DataSource = null;
                    lstAssignSkus.DataSource = dtSKUS_assigned;
                    lstAssignSkus.DisplayMember = "SKUDETAIL";
                    lstAssignSkus.ValueMember = "SKU_ID";
                }
            }
        } 
        #endregion
        //
        //  UAssign All SKU
        //
        #region Assign All SKU
        private void btnUnAssignAll_Click(object sender, EventArgs e)
        {
            dtSKUS_assigned.Rows.Clear();
            dtSKUS_unassigned.Rows.Clear();
            lstAssignSkus.DataSource = null;
            lstUnAssignSkus.DataSource = null;
            //
            //
            SkuController mContoller = new SkuController();
            dtSKUS_unassigned = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
            lstUnAssignSkus.DataSource = dtSKUS_unassigned;
            lstUnAssignSkus.DisplayMember = "SKUDETAIL";
            lstUnAssignSkus.ValueMember = "SKU_ID";
        }  
        #endregion
        #endregion

        #region Load 
        //
        // PopUp Load Function
        //
        #region PopUp Load
        private void PopUpSkuGroup_Load(object sender, EventArgs e)
        {
            LoadPrincipal();
            LoadCategory();
            if (SKU_GroupProperties._newOrUpdate == "New")
            {
                GetSKUName();
            }
        } 
        #endregion
        //
        //  Load Pricipal
        //
        #region Load Pricipal
        private void LoadPrincipal()
        {
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSkuHierarchy(Constants.SKUPrincipal, Constants.IntNullValue);
            cboxPrincipal.DataSource = dt;
            cboxPrincipal.DisplayMember = "SKU_HIE_NAME";
            cboxPrincipal.ValueMember = "SKU_HIE_ID";
        } 
        #endregion
        //
        //  Load Catagory
        //
        #region Load Catagory
        private void LoadCategory()
        {
            //if (ddDivision.Items.Count > 0)
            //  {
            cboxCatagory.SelectedIndexChanged -= new EventHandler(cboxCatagory_SelectedIndexChanged);
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            cboxCatagory.DataSource = dt;
            cboxCatagory.DisplayMember = "SKU_HIE_NAME";
            cboxCatagory.ValueMember = "SKU_HIE_ID";
            cboxCatagory.SelectedIndexChanged += new EventHandler(cboxCatagory_SelectedIndexChanged);
            //  }
        } 
        #endregion
        //
        //  Load Skus
        #region Load SKUS
        protected void GetSKUName()
        {
            //if (ddBrand.Items.Count > 0)
            // {
            SkuController mContoller = new SkuController();
            if (SKU_GroupProperties._newOrUpdate == "New")
            {
                dtSKUS_assigned = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxCatagory.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
                dtSKUS_assigned.Rows.Clear();
                lstAssignSkus.DisplayMember = "SKUDETAIL";
                lstAssignSkus.ValueMember = "SKU_ID";
            }
            dtSKUS_unassigned = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxCatagory.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            lstUnAssignSkus.DataSource = dtSKUS_unassigned;
            lstUnAssignSkus.DisplayMember = "SKUDETAIL";
            lstUnAssignSkus.ValueMember = "SKU_ID";
            
            //  }
        } 
        #endregion
        //
        //  Common Functions
        //
        #region Common Functions
        private void cboxPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadCategory();
            //GetSKUName();
        }

        private void cboxCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSKUName();
        } 
        #endregion 
        #endregion

        #region Save or Update Group
        //
        //     Save New Group
        //
        #region Save New Group
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text.Length == 0)
            {
                ToastNotification.Show(this, "Please Enter Group Name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (btnSave.Text == "Save")
            {
                DataTable dt_uniqueGroupName = GetUnique_GroupName();
                if (dt_uniqueGroupName.Rows.Count > 0)
                {
                    ToastNotification.Show(this, "Group Name Already Exists", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    return;
                }
                string ID = gController.Insert_SKUGroup(txtGroupName.Text, System.DateTime.Today, true, int.Parse(SessionClass.UserID.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                int _AssignRows = lstAssignSkus.Items.Count;
                for (int i = 0; i < _AssignRows; i++)
                {
                    lstAssignSkus.SelectedIndex = i;
                    int SKU_ID = Convert.ToInt32(lstAssignSkus.SelectedValue.ToString());
                    gController.Insert_SKU_GroupDetail(int.Parse(ID), SKU_ID);
                }
            }
            if (btnSave.Text == "Update")
            {
                UpdateGroup();
            }
            //FormSKU_Group _formSKUgroup = Application.OpenForms["FormSKU_Group"] as FormSKU_Group;
            //_formSKUgroup.LoadGroup();
            lstUnAssignSkus.DataSource = null;
            lstAssignSkus.DataSource = null;
            lstAssignSkus.Items.Clear();
            lstUnAssignSkus.Items.Clear();
            txtGroupName.Text = "";
            btnSave.Text = "Save";
            FormSKU_Group _formSkuGroup = Application.OpenForms["FormSKU_Group"] as FormSKU_Group;
            _formSkuGroup.LoadGroup();
            this.Close();
        } 
        #endregion
        //
        //  Update Group
        //
        #region Update Group
        protected void UpdateGroup()
        {

            if (lstAssignSkus.Items.Count == 0)
            {
                gController.UpdateSKUinGroup(Convert.ToInt32(lblGroupIDPopUp.Text), 0, txtGroupName.Text, true, int.Parse(cboxPrincipal.SelectedValue.ToString()));
            }
            else
            {
                gController.UpdateSKUinGroup(Convert.ToInt32(lblGroupIDPopUp.Text), 0, txtGroupName.Text, true, int.Parse(cboxPrincipal.SelectedValue.ToString()));
                for (int i = 0; i < lstAssignSkus.Items.Count; i++)
                {
                    lstAssignSkus.SelectedIndex = i;
                    gController.UpdateSKUinGroup(Convert.ToInt32(lblGroupIDPopUp.Text), Convert.ToInt32(lstAssignSkus.SelectedValue.ToString()), txtGroupName.Text, true, int.Parse(cboxPrincipal.SelectedValue.ToString()));
                }
            }
        } 
        #endregion
        #endregion

        #region Check Group Name Existance
        //
        // Get Unique Group Name
        //
        protected DataTable GetUnique_GroupName()
        {
            DataTable dt = gController.GET_UniqueGroupName(Constants.IntNullValue, txtGroupName.Text, Constants.DateNullValue, true, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            return dt;
        } 
        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
