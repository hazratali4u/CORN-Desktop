using System;
using System.Data;
using CORNCommon.Classes;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormBranchExpense : Form
    {
        LedgerController mLController = new LedgerController();
        public FormBranchExpense()
        {
            InitializeComponent();
        }

        private void txtAccountDes_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        #region Load Functions

        private void FormBranchExpense_Load(object sender, EventArgs e)
        {
            lblRowId.Text = "-1";
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadAccountHead();
            this.CreatTable();
            this.LoadVoucherNo();            
        }
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            cboxDistributor.DataSource = dt;
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
        }
        private void LoadPrincipal()
        {
            cboxPrincipal.Enabled = true;
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.UserID, Constants.IntNullValue, 0, System.DateTime.Now);
            cboxPrincipal.Items.Clear();
            cboxPrincipal.Items.Add(new clsListItems("General Entry", "0"));
            cboxPrincipal.DataSource = m_dt;
            cboxPrincipal.DisplayMember = "Company_Name";
            cboxPrincipal.ValueMember = "Company_Id";
            this.LoadAccountHead();
        }
        private void LoadAccountHead()
        {

            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.GetAssignAccountHead("55,56", Constants.IntNullValue, 2);
            cboxExpenseHead.DataSource = dt;
            cboxExpenseHead.DisplayMember = "ACCOUNT_NAME";
            cboxExpenseHead.ValueMember = "ACCOUNT_HEAD_ID";

        }
        private void CreatTable()
        {
            DataTable dtVoucher = new DataTable();
            dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
            dtVoucher.Columns.Add("Account_Code", typeof(string));
            dtVoucher.Columns.Add("Account_Name", typeof(string));
            dtVoucher.Columns.Add("Debit", typeof(decimal));
            dtVoucher.Columns.Add("Credit", typeof(decimal));
            dtVoucher.Columns.Add("Remarks", typeof(string));
            dtVoucher.Columns.Add("Principal_Id", typeof(string));
            dtVoucher.Columns.Add("Principal", typeof(string));
            dtVoucher.Columns.Add("ACCOUNT_PARENT_ID", typeof(string));
            ClassSession.dtVoucher = dtVoucher;
        }
        private void LoadVoucherNo()
        {
            if (cboxDistributor.Items.Count > 0 && cboxDistributor.SelectedIndex >= 0)
            {
                try
                {
                    int.Parse(cboxDistributor.SelectedValue.ToString());
                }
                catch (Exception)
                {
                    return;
                }
                cboxVoucherNo.DataSource = null;
                cboxVoucherNo.Items.Clear();
                LedgerController LController = new LedgerController();
                DataTable dt = LController.SelectVoucherNo(SessionClass.CurrentWorkDate, int.Parse(cboxDistributor.SelectedValue.ToString()), Constants.Journal_Voucher, SessionClass.UserID, null);

                DataRow _dr;
                _dr = dt.NewRow();
                _dr["VOUCHER_NO"] = "0";
                _dr["VOUCHER_NO2"] = "New";
                dt.Rows.InsertAt(_dr, 0);
                cboxVoucherNo.DataSource = dt;
                cboxVoucherNo.DisplayMember = "VOUCHER_NO2";
                cboxVoucherNo.ValueMember = "VOUCHER_NO"; 
            }
        } 

        #endregion

        #region Common Function
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToGrid();
            ArrangeGrid();
        } 
        #endregion

        #region Add Expense To Grid

        public void AddToGrid()
        {
            DataControl dc = new DataControl();
            DataTable dtVoucher = ClassSession.dtVoucher;
            if (lblRowId.Text == "-1")
            {
                DataRow dr = dtVoucher.NewRow();
                dr["ACCOUNT_HEAD_ID"] = cboxExpenseHead.SelectedValue.ToString();
                dr["ACCOUNT_NAME"] = cboxExpenseHead.Text;
                dr["REMARKS"] = txtRemarks.Text;
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtAmount.Text));
                dr["Credit"] = "0";
                dr["Principal"] = cboxPrincipal.Text;
                dr["Principal_id"] = Convert.ToInt32(cboxPrincipal.SelectedValue.ToString());
                dr["ACCOUNT_PARENT_ID"] = 61;//Branch Expenses  (FDM EXP)
                dtVoucher.Rows.Add(dr);

            }
            else
            {
                DataRow dr = dtVoucher.Rows[int.Parse(lblRowId.Text)];
                dr["ACCOUNT_HEAD_ID"] = cboxExpenseHead.SelectedValue.ToString();
                dr["ACCOUNT_NAME"] = cboxExpenseHead.Text;
                dr["REMARKS"] = txtRemarks.Text;
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtAmount.Text));
                dr["Credit"] = "0";
                dr["Principal"] = cboxPrincipal.Text;
                dr["Principal_id"] = Convert.ToInt32(cboxPrincipal.SelectedValue.ToString());
                dr["ACCOUNT_PARENT_ID"] = 61; //Branch Expenses  (FDM EXP)
            }

            GridExpense.DataSource = dtVoucher;
            txtAmount.Text = "";
            txtRemarks.Text = "";
            lblRowId.Text = "-1";

            decimal TotalDebit = 0;

            foreach (DataRow dr in dtVoucher.Rows)
            {
                TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            }
            txtNetAmount.Text = TotalDebit.ToString();
        } 

        #endregion

        #region Arrange DataGridView

        public void ArrangeGrid()
        {
            try
            {
                GridExpense.Columns.Remove("Edit");
                GridExpense.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            GridExpense.Columns["ACCOUNT_HEAD_ID"].Visible = false;
            GridExpense.Columns["ACCOUNT_CODE"].Visible = false;
            GridExpense.Columns["Credit"].Visible = false;
            GridExpense.Columns["Principal_id"].Visible = false;
            GridExpense.Columns["Principal"].Visible = false;
            GridExpense.Columns["ACCOUNT_PARENT_ID"].Visible = false;

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GridExpense.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GridExpense.Columns.Add(btnDelete);
            
            // Header Text
            GridExpense.Columns["Account_Name"].HeaderText = "Account Head";

            // Set Columns width
            GridExpense.Columns["Edit"].Width = 50;
            GridExpense.Columns["Delete"].Width = 70;
            GridExpense.Columns["Account_Name"].Width = 320;
            GridExpense.Columns["Remarks"].Width = 200;
            // index
            GridExpense.Columns["Remarks"].DisplayIndex = GridExpense.Columns["Debit"].DisplayIndex - 1;
            GridExpense.Columns["Account_Name"].DisplayIndex = 0;
        } 

        #endregion

        #region Update Or Delete Expense
        
        private void GridExpense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridExpense.Columns["Edit"].Index)
            {
                int _rowIndex = GridExpense.CurrentCell.RowIndex;
                lblRowId.Text = _rowIndex.ToString();
                this.LoadAccountHead();
                cboxExpenseHead.Text = GridExpense.Rows[_rowIndex].Cells["Account_Name"].Value.ToString();
                txtRemarks.Text = GridExpense.Rows[_rowIndex].Cells["Remarks"].Value.ToString();
                txtAmount.Text = GridExpense.Rows[_rowIndex].Cells["Debit"].Value.ToString();
            }
            else if (e.ColumnIndex == GridExpense.Columns["Delete"].Index)
            {
                int _rowIndex = GridExpense.CurrentCell.RowIndex;
                DataTable dtVoucher = ClassSession.dtVoucher;
                dtVoucher.Rows.RemoveAt(e.RowIndex);
                GridExpense.DataSource = dtVoucher;
                lblRowId.Text = "-1";

                decimal TotalDebit = 0;

                foreach (DataRow dr in dtVoucher.Rows)
                {
                    TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                }
                txtNetAmount.Text = TotalDebit.ToString();
            }
        } 
        #endregion

        #region Save Expense

        //  Save Click_Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GridExpense.Rows.Count > 0)    // Check if Grid Has DataRows
            {
                SaveExpense();
            }
        }
        //  Save Function
        public void SaveExpense()
        {
            if (cboxVoucherNo.Items.Count == 0)
            {
                MessageBox.Show(this, "Select Voucher Number", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CORNCommon.Classes.Configuration.GetAccountHead();
            DataControl dc = new DataControl();
            DataTable dtVoucher = ClassSession.dtVoucher;
            bool IsSaveVoucher;

            string MaxDocumentId;

            if (dtVoucher.Rows.Count > 0)
            {
                DataRow dr = dtVoucher.NewRow();
                dr["ACCOUNT_HEAD_ID"] = CORNCommon.Classes.Configuration.PeatyCash;
                dr["ACCOUNT_NAME"] = "Peatty Cash";
                dr["REMARKS"] = "Patty Cash Credit";
                dr["DEBIT"] = 0;
                dr["Credit"] = decimal.Parse(dc.chkNull_0(txtNetAmount.Text));
                dr["Principal"] = cboxPrincipal.Text;
                dr["Principal_id"] = Convert.ToInt32(cboxPrincipal.SelectedValue.ToString());

                dtVoucher.Rows.Add(dr);

                if (cboxVoucherNo.SelectedValue.ToString() == "0")
                {
                    MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, int.Parse(cboxDistributor.SelectedValue.ToString()), SessionClass.CurrentWorkDate);

                    IsSaveVoucher = mLController.Add_Voucher(int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), MaxDocumentId, Constants.Journal_Voucher,
                           SessionClass.CurrentWorkDate, Constants.Document_Petty_Cash, null, "Petty Voucher", Constants.DateNullValue, null, dtVoucher, SessionClass.UserID, txtSlipNo.Text);
                }
                else
                {
                    MaxDocumentId = cboxVoucherNo.SelectedValue.ToString();

                    IsSaveVoucher = mLController.Add_Voucher(int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), MaxDocumentId, Constants.Journal_Voucher,
                           SessionClass.CurrentWorkDate, Constants.Document_Petty_Cash, null, "Petty Voucher", Constants.DateNullValue, null, dtVoucher, SessionClass.UserID, txtSlipNo.Text);
                }

                if (IsSaveVoucher == true)
                {
                    dtVoucher.Rows.Clear();
                    GridExpense.DataSource = null;
                    txtAmount.Text = "";
                    txtSlipNo.Text = "";
                    txtRemarks.Text = "";
                    lblRowId.Text = "-1";
                    MessageBox.Show(this, "Expense Saved Successfully", "CORN: POS");
                    decimal TotalDebit = 0;

                    foreach (DataRow dr1 in dtVoucher.Rows)
                    {
                        TotalDebit += decimal.Parse(dr1["DEBIT"].ToString());
                    }
                    txtNetAmount.Text = TotalDebit.ToString();
                    this.LoadVoucherNo();

                }
                else
                {
                    MessageBox.Show(this, "Error: \n Somthing going wrong in Voucher", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (lblRowId.Text == "-1")
            {
                MaxDocumentId = cboxVoucherNo.SelectedValue.ToString();

                IsSaveVoucher = mLController.Delete_Voucher(int.Parse(cboxDistributor.SelectedValue.ToString()), MaxDocumentId, Constants.Journal_Voucher);
                ClassSession.dtVoucher = null;
                LoadVoucherNo();
            }
        }

        #endregion
        
        private void cboxDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVoucherNo();
        }

        private void FormBranchExpense_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 420, 195);
            groupPanel2.Location = new Point(points[0], points[1]);
        }

        private void cboxVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxVoucherNo.DisplayMember == "VOUCHER_NO2" && cboxVoucherNo.ValueMember == "VOUCHER_NO")
            {
                try
                {
                    if(cboxVoucherNo.SelectedValue.ToString() == "0")
                    {

                    }
                }
                catch (Exception)
                {
                    return;
                }
                if (cboxVoucherNo.SelectedValue.ToString() == "0")
                {
                    GridExpense.DataSource = null;
                }
                else
                {
                    ClassSession.dtVoucher.Rows.Clear();
                    ClassSession.dtVoucher = mLController.SelectVoucherDetail(Convert.ToInt32(cboxDistributor.SelectedValue), cboxVoucherNo.SelectedValue.ToString(), Constants.IntNullValue);
                    for (int i = 0; i < ClassSession.dtVoucher.Rows.Count; i++)
                    {
                        if (Decimal.Parse(ClassSession.dtVoucher.Rows[i]["CREDIT"].ToString()) > 0)
                        {
                            ClassSession.dtVoucher.Rows.RemoveAt(i);
                        }
                    }
                    GridExpense.DataSource = ClassSession.dtVoucher;
                    decimal TotalDebit = 0;

                    foreach (DataRow dr in ClassSession.dtVoucher.Rows)
                    {
                        TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                    }
                    txtNetAmount.Text = TotalDebit.ToString();
                    ArrangeGrid();
                }
            }
        }
    }
}