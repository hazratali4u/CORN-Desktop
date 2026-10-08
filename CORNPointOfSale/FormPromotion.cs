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
    public partial class FormPromotion : Form
    {
        string[] cols = { "SCHEME_ID", "PROMOTION_ID", "SCHEME_DESC", "DISTRIBUTOR_NAME", "DISTRIBUTOR_ID", "PROMOTION_CODE", "PROMOTION_DESCRIPTION", "Principal", "START_DATE", "END_DATE", "IS_ACTIVE" };

        public FormPromotion()
        {
            InitializeComponent();
        }

        private void FormPromotion_Load(object sender, EventArgs e)
        {
            txtFromdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
            txttoDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
            CboxSearchType.DataSource = cols;
            LoadPrincipal();
            FillScheme();
        }
        /// <summary>
        /// Loads Schemes To Scheme Combo
        /// </summary>
        public void FillScheme()
        {
            SchemeController mSchemController = new SchemeController();
            DataTable dtScheme = mSchemController.SelectScheme(Constants.IntNullValue, CORNCommon.Classes.Configuration.DistributorId, null, null, Constants.DateNullValue);
            cboxSchem.Items.Clear();
            cboxSchem.Items.Add(new clsListItems("ALL", "0"));
            cboxSchem.DataSource = dtScheme;
            cboxSchem.DisplayMember = "SCHEME_CODE";
            cboxSchem.ValueMember = "SCHEME_ID";
        }
        ///// <summary>
        ///// Loads Principals To Principal Combo
        ///// </summary>
        private void LoadPrincipal()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            cboxPrincipal.DataSource = m_dt;
            cboxPrincipal.DisplayMember = "Company_Name";
            cboxPrincipal.ValueMember = "Company_Id";
        }
        /// <summary>
        /// Loads Promotions To Promotion Grid
        /// </summary>
        private void LoadGrid()
        {
            DataTable dt = new DataTable();

            if (CboxSearchType.SelectedIndex == 2)
            {
                dt.DefaultView.RowFilter = CboxSearchType.SelectedValue.ToString() + " =" + txtSeach.Text;
            }
            else
            {
                dt.DefaultView.RowFilter = CboxSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
            }

            DataView dw = dt.DefaultView;
            DataTable dt2 = dw.ToTable(true, cols);
            GridPromotions.DataSource = dt2;
            ArrangeGrid();
        }

        #region Arrange Grid View
        public void ArrangeGrid()
        {
            try
            {
                GridPromotions.Columns.Remove("Edit");
                GridPromotions.Columns.Remove("Select");
                GridPromotions.Columns.Remove("activeClm");
            }
            catch (Exception)
            { }
            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridPromotions.Columns.Add(btnEdit);

            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GridPromotions.Columns.Add(checkColumn);
            GridPromotions.Columns["Select"].DisplayIndex = 0;
            GridPromotions.Columns["SELECT"].HeaderText = "";

            // Hide Columns
            GridPromotions.Columns["Principal"].Visible = false;
            GridPromotions.Columns["Promotion_id"].Visible = false;
            GridPromotions.Columns["Distributor_id"].Visible = false;
            GridPromotions.Columns["is_active"].Visible = false;

            

            // Set Is_Active Text
            DataGridViewTextBoxColumn activeClm = new DataGridViewTextBoxColumn();
            activeClm.Name = "activeClm";
            activeClm.HeaderText = "   Status";
            GridPromotions.Columns.Add(activeClm);
            GridPromotions.Columns["activeClm"].DisplayIndex = GridPromotions.Columns["Edit"].Index - 1;
            GridPromotions.Columns["activeClm"].Width = 90;



            // Set Active and In Active Text
            GridPromotions.Columns["activeClm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridPromotions.Columns["activeClm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridPromotions.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Header Text
            GridPromotions.Columns["SCHEME_ID"].HeaderText = "Scheme Id";
            GridPromotions.Columns["SCHEME_DESC"].HeaderText = "Scheme Description";
            GridPromotions.Columns["DISTRIBUTOR_NAME"].HeaderText = "Base Location";
            GridPromotions.Columns["PROMOTION_CODE"].HeaderText = "Promotion Code";
            GridPromotions.Columns["PROMOTION_DESCRIPTION"].HeaderText = "Promotion Description";
            GridPromotions.Columns["START_DATE"].HeaderText = "Start Date";
            GridPromotions.Columns["END_DATE"].HeaderText = "End Date";
            // Width
            GridPromotions.Columns["Edit"].Width = 70;
            GridPromotions.Columns["Select"].Width = 50;
            GridPromotions.Columns["SCHEME_ID"].Width = 80;
            GridPromotions.Columns["SCHEME_DESC"].Width = 300;
            GridPromotions.Columns["DISTRIBUTOR_NAME"].Width = 150;
            GridPromotions.Columns["PROMOTION_CODE"].Width = 100;
            GridPromotions.Columns["PROMOTION_DESCRIPTION"].Width = 300;
            GridPromotions.Columns["START_DATE"].Width = 100;
            GridPromotions.Columns["END_DATE"].Width = 100;

            foreach (DataGridViewColumn clms in GridPromotions.Columns)
            {
                clms.ReadOnly = true;
            }
            GridPromotions.Columns["Select"].ReadOnly = false;
        } 
        #endregion

        #region Common Functions / Events
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                cboxPrincipal.DataSource = null;
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Display", typeof(string));
                dt1.Columns.Add("Value", typeof(Int64));
                dt1.Rows.Add("All", Constants.LongNullValue);
                cboxPrincipal.DataSource = dt1;
                cboxPrincipal.DisplayMember = "Display";
                cboxPrincipal.ValueMember = "Value";
                cboxPrincipal.SelectedIndex = 0;
            }
            else
            {
                LoadPrincipal();
            }
        }
        private void btnPromotion_Click(object sender, EventArgs e)
        {
            PromotionController mController = new PromotionController();
            if (btnPromotion.Text == "Get Promotion")
            {
                string FromDate = txtFromdate.Text + " 00:00:00";
                string ToDate = txttoDate.Text + " 23:59:59";

                DataTable dt = mController.SelectPromotion(FromDate, ToDate, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), ChbActive.Checked);
                //this.Session.Add("dt", dt);
                DataView dw = dt.DefaultView;
                DataTable dt2 = dw.ToTable(true, cols);
                GridPromotions.DataSource = dt2;
                ArrangeGrid();
            }
            ActiveInactiveText();
            if (GridPromotions.Rows.Count > 0)
            {
                ChkAllGrid.Visible = true;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormPromotionWizard _formPromotionWizard = new FormPromotionWizard();
            _formPromotionWizard.ShowDialog();
        }
        private void GridPromotions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridPromotions.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridPromotions.Columns["Edit"].Index)
            {
                EditPromotion(_rowIndex);
            }
        } 
        #endregion

        #region Edit Delete Promotions
        public void EditPromotion(int _rowIndex)
        {
            bool IsEditing = true;
            string flow = "f";
            string PromotionId = GridPromotions.Rows[_rowIndex].Cells[1].Value.ToString();
            SessionClass.PromotionId = PromotionId;
            SessionClass.IsEditing = IsEditing;
            SessionClass.flow = flow;
            FormPromotionWizard _formPromotionWizard = new FormPromotionWizard();
            _formPromotionWizard.Show();
        }
        public void DeletePromotion(int _rowIndex)
        {
            PromotionController mController = new PromotionController();

            int PromotionId = int.Parse(GridPromotions.Rows[_rowIndex].Cells[1].Value.ToString());
            int SchemeId = int.Parse(GridPromotions.Rows[_rowIndex].Cells[0].Value.ToString());

            mController.UpdatePromotion(PromotionId, SchemeId, int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()), null, null, Constants.DateNullValue, false, Constants.DateNullValue, Constants.DateNullValue, false, Constants.IntNullValue, Constants.IntNullValue);

            string FromDate = txtFromdate.Text + " 00:00:00";
            string ToDate = txttoDate.Text + " 23:59:59";

            DataTable dt = mController.SelectPromotion(FromDate, ToDate, Convert.ToInt32(this.cboxPrincipal.SelectedValue), int.Parse(SessionClass.UserID.ToString()), ChbActive.Checked);
            //this.Session.Add("dt", dt);

            DataView dw = dt.DefaultView;
            DataTable dt2 = dw.ToTable(true, cols);

            GridPromotions.DataSource = dt2;
        } 
        #endregion

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
        #region ActiveInactiveText Function
        public void ActiveInactiveText()
        {
            int _rows = GridPromotions.Rows.Count;
            for (int i = 0; i < _rows; i++)
            {
                if (Convert.ToBoolean(GridPromotions.Rows[i].Cells["IS_ACTIVE"].Value) == true)
                {
                    GridPromotions.Rows[i].Cells["activeClm"].Value = "Active";
                }
                else
                {
                    GridPromotions.Rows[i].Cells["activeClm"].Value = "In Active";
                }
            }
        }
        #endregion
        private void FormPromotion_Shown(object sender, EventArgs e)
        {
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (clsWindowsFormUtil.Are_Rows_Selected(GridPromotions, "Are you sure ?"))
            {
                try
                {
                    foreach (DataGridViewRow dr in GridPromotions.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value))
                        {
                            DeletePromotion(dr.Index);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: \n" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChkAllGrid_CheckedChanged(object sender, EventArgs e)
        {
            int _rows = GridPromotions.Rows.Count;
            if (ChkAllGrid.Checked)
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridPromotions.Rows[i].Cells["Select"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    GridPromotions.Rows[i].Cells["Select"].Value = false;
                }
            }
        }
    }
}
