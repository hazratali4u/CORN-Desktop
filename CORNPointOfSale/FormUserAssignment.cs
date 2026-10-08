using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormUserAssignment : Form
    {
        readonly UserController _mUserController = new UserController();
        readonly SkuHierarchyController _sController = new SkuHierarchyController();
        public FormUserAssignment()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormUserAssignment_Load(object sender, EventArgs e)
        {
            LoadUser();
            DistributorType();
            LoadUnAssingned();
            LoadAssingned();
            //AssignBrand();
            //UnAssignBrand();
        }

        private void LoadUser()
        {
            DataTable dt = _mUserController.SelectSlashUser(null, null);
            cboxUser.DataSource = dt;
            cboxUser.ValueMember = "USER_ID";
            cboxUser.DisplayMember = "USER_NAME";
        }
        private void DistributorType()
        {
            DistributorController dController = new DistributorController();
            DataTable dt = dController.SelectDistributorTypeInfo(Constants.IntNullValue);
            cboxDistributor.DataSource = dt;
            cboxDistributor.DisplayMember = "TYPENAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_TYPE_ID";
        }
        private void LoadUnAssingned()
        {
            try
            {
                if (cboxUser.Items.Count > 0 && cboxDistributor.Items.Count > 0)
                {

                    DataTable dt = _mUserController.SelectUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), 0, SessionClass.CompanyID);
                    lstUnAssignLocation.DataSource = dt;
                    lstUnAssignLocation.DisplayMember = "distributor_name";
                    lstUnAssignLocation.ValueMember = "distributor_id";
                }
            }
            catch (Exception)
            { }
        }
        private void LoadAssingned()
        {
            try
            {
                if (cboxUser.Items.Count > 0 && cboxDistributor.Items.Count > 0)
                {

                    DataTable dt = _mUserController.SelectUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), 1, SessionClass.CompanyID);
                    lstAssignLocation.DataSource = dt;
                    lstAssignLocation.DisplayMember = "distributor_name";
                    lstAssignLocation.ValueMember = "distributor_id";
                    
                }
            }
            catch (Exception)
            { }
        } 
        #endregion

        #region Cboxes Selected Index Changed
        private void cboxDistributor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadUnAssingned();
            LoadAssingned();
        }
        private void cboxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxUser.Items.Count > 0)
            {
                LoadUnAssingned();
                LoadAssingned();
                //UnAssignBrand();
                //AssignBrand(); 
            }
        } 
        #endregion

        #region Assign / Un Assign Location
        private void btnAssignLocation_Click_1(object sender, EventArgs e)
        {
            if (lstUnAssignLocation.Items.Count > 0)
            {
                if (cboxUser.Items.Count > 0)
                {
                    _mUserController.InsertUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(lstUnAssignLocation.SelectedValue.ToString()), SessionClass.CompanyID);
                }
                LoadUnAssingned();
                LoadAssingned();
            }
        }
        private void btnUnAssignLocation_Click_1(object sender, EventArgs e)
        {
            if (lstAssignLocation.Items.Count > 0)
            {
                if (cboxUser.Items.Count > 0)
                {
                    _mUserController.DeleteUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(lstAssignLocation.SelectedValue.ToString()), SessionClass.CompanyID);
                }
                LoadUnAssingned();
                LoadAssingned();
            }
        }
        private void btnAssignAllLocation_Click(object sender, EventArgs e)
        {
            int _rows = lstUnAssignLocation.Items.Count;
            if (_rows > 0)
            {
                if (cboxUser.Items.Count > 0)
                {
                    for (int i = 0; i < _rows; i++)
                    {
                        //lstUnAssignLocation.SelectedIndex = i;
                        _mUserController.InsertUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(lstUnAssignLocation.SelectedValue.ToString()), SessionClass.CompanyID);
                        LoadUnAssingned();
                        LoadAssingned();
                    }
                }
            }
        }
        private void btnUnAssignAllLocation_Click(object sender, EventArgs e)
        {
            int _rows = lstAssignLocation.Items.Count;
            if (_rows > 0)
            {
                if (cboxUser.Items.Count > 0)
                {
                    for (int i = 0; i < _rows; i++)
                    {
                        _mUserController.DeleteUserAssignment(int.Parse(cboxUser.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(lstAssignLocation.SelectedValue.ToString()), SessionClass.CompanyID);
                        LoadUnAssingned();
                        LoadAssingned();
                    }
                }
            }
        } 
        #endregion

        #region Principal Tab
        private void AssignBrand()
        {
            try
            {
                if (cboxUser.Items.Count > 0 && cboxDistributor.Items.Count > 0)
                {
                    DataTable dt = _sController.SelectBrandAssignment(1, int.Parse(cboxUser.SelectedValue.ToString()));
                    lstAssignPrinciple.DataSource = dt;
                    lstAssignPrinciple.DisplayMember = "Company_name";
                    lstAssignPrinciple.ValueMember = "Company_id";

                    DataTable dtAssignBrand = _sController.GetBrandAssignment(int.Parse(cboxUser.SelectedValue.ToString()));
                    if (dtAssignBrand.Rows.Count > 0)
                    {
                        for (int i = 0; i < lstAssignPrinciple.Items.Count; i++)
                        {
                            for (int j = 0; j < dtAssignBrand.Rows.Count; j++)
                            {
                                lstAssignPrinciple.SelectedIndex = i;
                                if (lstAssignPrinciple.SelectedValue.ToString() == dtAssignBrand.Rows[j]["PRINCIPAL_ID"].ToString() && Convert.ToBoolean(dtAssignBrand.Rows[j]["Is_ManualDiscount"]) == true)
                                {
                                    lstAssignPrinciple.SetItemChecked(i, true);
                                    break;
                                }
                            }
                        }
                    } 
                }
            }
            catch (Exception)
            { }
        }
        private void UnAssignBrand()
        {
            try
            {
                if (cboxUser.Items.Count > 0 && cboxDistributor.Items.Count > 0)
                {
                    DataTable dt = _sController.SelectBrandAssignment(0, int.Parse(cboxUser.SelectedValue.ToString()));
                    lstUnAssignPrinciple.DataSource = dt;
                    lstUnAssignPrinciple.DisplayMember = "Company_name";
                    lstUnAssignPrinciple.ValueMember = "Company_id"; 
                }
            }
            catch (Exception e)
            {
            }
        }
        private void btnAssignPrinciple_Click(object sender, EventArgs e)
        {
            int _items = lstUnAssignPrinciple.Items.Count;
            // for (int i = 0; i < _items; i++)
            //{
            if (cboxUser.Items.Count > 0 && _items > 0)
            {
                _sController.InsertAssignBrand(int.Parse(lstUnAssignPrinciple.SelectedValue.ToString()), int.Parse(cboxUser.SelectedValue.ToString()));
                UnAssignBrand();
                AssignBrand();
            }
            // }
        }
        private void btnUnAssignPrinciple_Click(object sender, EventArgs e)
        {
            // for (int i = 0; i < lstAssignPrinciple.Items.Count; i++)
            //  {
            if (cboxUser.Items.Count > 0 && lstAssignPrinciple.Items.Count > 0)
            {
                _sController.DeleteAssignBrand(int.Parse(lstAssignPrinciple.SelectedValue.ToString()), int.Parse(cboxUser.SelectedValue.ToString()));
                UnAssignBrand();
                AssignBrand();
            }
            //  }
        }
        private void btnAssignAllPrinciple_Click(object sender, EventArgs e)
        {
            if (cboxUser.Items.Count > 0)
            {
                int _items = lstUnAssignPrinciple.Items.Count;
                for (int i = 0; i < _items; i++)
                {
                    lstUnAssignPrinciple.SelectedIndex = i;
                    _sController.InsertAssignBrand(Convert.ToInt32(lstUnAssignPrinciple.SelectedValue.ToString()), int.Parse(cboxUser.SelectedValue.ToString()));
                }
                UnAssignBrand();
                AssignBrand();
            }
        }

        private void btnUnAssignAllPrinciple_Click(object sender, EventArgs e)
        {
            if (cboxUser.Items.Count > 0)
            {
                int _rows = lstAssignPrinciple.Items.Count;
                for (int i = 0; i < _rows; i++)
                {
                    lstAssignPrinciple.SelectedIndex = i;
                    _sController.DeleteAssignBrand(int.Parse(lstAssignPrinciple.SelectedValue.ToString()), int.Parse(cboxUser.SelectedValue.ToString()));
                }
                UnAssignBrand();
                AssignBrand();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboxUser.Items.Count > 0)
            {
                for (int i = 0; i < lstAssignPrinciple.Items.Count; i++)
                {
                    lstAssignPrinciple.SelectedIndex = i;
                    _sController.UpdateBrandAssignment(Convert.ToInt32(cboxUser.SelectedValue.ToString()), Convert.ToInt32(lstAssignPrinciple.SelectedValue.ToString()), Convert.ToBoolean(lstAssignPrinciple.GetItemCheckState(i)));
                }
            }
        }

        #endregion

        private void FormUserAssignment_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 260, 210);
            groupPanel4.Location = new Point(points[0],points[1]);
        }
    }
}
