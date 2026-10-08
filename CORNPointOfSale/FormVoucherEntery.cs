using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormVoucherEntery : Form
    {
        DataTable dtVoucher;
        private static int RowId = -1;

        public FormVoucherEntery()
        {
            InitializeComponent();
        }

        #region Common

        private void CreatTable()
        {
            dtVoucher = new DataTable();
            dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
            dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
            dtVoucher.Columns.Add("Account_Code", typeof(string));
            dtVoucher.Columns.Add("Account_Name", typeof(string));
            dtVoucher.Columns.Add("Debit", typeof(decimal));
            dtVoucher.Columns.Add("Credit", typeof(decimal));
            dtVoucher.Columns.Add("Remarks", typeof(string));
            dtVoucher.Columns.Add("InvoiceNo", typeof(string));
            dtVoucher.Columns.Add("Principal_Id", typeof(string));
            dtVoucher.Columns.Add("Principal", typeof(string));
            ClassSession.dtVoucher = dtVoucher;
        }
        private void ClearAll()
        {
            txtCreditAmount.Text = "0";
            txtDebitAmount.Text = "0";
            cboxAccountName.Text = "";
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            txtDebitAmount.Text = "";
            txtCreditAmount.Text = "";
            txtAccountDes.Text = "";
            txtpayeesName.Text = "";
            GrdOrder.DataSource = null;
            ClassSession.dtVoucher = null;
            this.CreatTable();
            txtpayeesName.Text = "";
            cboxDistributor.Enabled = true;
            cboxVoucherType.Enabled = true;
            txtTotalDebit.Text = "";
            txtTotalCredit.Text = "";
        }
        private void txtVoucherDate_Leave_1(object sender, EventArgs e)
        {
            DateValidation();
        }
        public bool DateValidation()
        {
            bool _worked = true;
            if (Convert.ToDateTime(txtVoucherDate.Value.ToString("dd/MMM/yyyy")) < Convert.ToDateTime(CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd/MMM/yyyy")))
            {
                ToastNotification.Show(this, "Voucher Date Must be Greater Than Current Date", CORNPointOfSale.Properties.Resources.cross, 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                _worked = false;
            }
            if (lblChequeDate.Text == "Cheque Date")
            {
                if (Convert.ToDateTime(txtVoucherDate.Value.ToString("dd/MMM/yyyy")) > Convert.ToDateTime(txtChequeDate.Value.ToString("dd/MMM/yyyy")))
                {
                    ToastNotification.Show(this, "Voucher Date Must be Less Then Cheque Date", CORNPointOfSale.Properties.Resources.cross, 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                    _worked = false;
                }
            }
            return _worked;
        }
        private void cboxVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxVoucherType.SelectedIndex == 2)
            {
                lblChequeNo.Text = "Invoice No";
                lblChequeDate.Text = "Invoice Date";
            }
            else
            {
                lblChequeNo.Text = "Cheque No";
                lblChequeDate.Text = "Cheque Date";
            }
            this.ClearAll();
            try
            {
                this.LoadAccountHead();
            }
            catch (Exception)
            { }
        }
        public void ArrangeGrid()
        {
            try
            {
                GrdOrder.Columns.Remove("Edit");
                GrdOrder.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            GrdOrder.Columns["LEDGER_ID"].Visible = false;
            GrdOrder.Columns["Account_head_id"].Visible = false;
            GrdOrder.Columns["InvoiceNo"].Visible = false;
            GrdOrder.Columns["Principal_ID"].Visible = false;
            GrdOrder.Columns["Credit"].DisplayIndex = 9;
            GrdOrder.Columns["Debit"].DisplayIndex = 8;
            GrdOrder.Columns["Remarks"].DisplayIndex = 7;

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            GrdOrder.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GrdOrder.Columns.Add(btnDelete);

            //// Set Columns Width 
            GrdOrder.Columns["Edit"].Width = 50;
            GrdOrder.Columns["Delete"].Width = 70;
            GrdOrder.Columns["Credit"].Width = 80;
            GrdOrder.Columns["Debit"].Width = 80;
            GrdOrder.Columns["Account_Code"].Width = 100;
            GrdOrder.Columns["Account_Name"].Width = 320;
            GrdOrder.Columns["Remarks"].Width = 200;
            GrdOrder.Columns["Principal"].Width = 80;

            //// Set Columns HEader Text
            GrdOrder.Columns["Account_Code"].HeaderText = "Account Code";
            GrdOrder.Columns["Account_Name"].HeaderText = "Account Name";
            // Text Alignment
            GrdOrder.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GrdOrder.Columns["Delete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GrdOrder.Columns["Edit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GrdOrder.Columns["Delete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        } 

        #endregion

        #region Load Functions

        private void FormVoucherEntery_Load(object sender, EventArgs e)
        {
            GrdOrder.BackgroundColor = Color.White;
            this.LoadPaymentMode();
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadAccountHead();
            txtVoucherDate.Text = DateTime.Now.ToShortDateString();
            RowId = -1;
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = System.DateTime.Now; ;
            txtChequeDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd/MMM/yyyy");
            txtDueDate.Text = CORNCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd/MMM/yyyy");
        }
        public enum ModeList
        {
            Cash = 09,
            Cheque = 18,
            PayOrder = 21,
        }
        private void LoadPaymentMode()
        {
            cboxPaymentMode.DataSource = Enum.GetValues(typeof(ModeList));
            cboxPaymentMode.SelectedItem = ModeList.Cash;
        }
        
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            //clsWebFormUtil.FillDropDownList(this.cboxDistributor, dt, 0, 2, true);
            cboxDistributor.DataSource = dt;
            cboxDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            cboxDistributor.ValueMember = "DISTRIBUTOR_ID";
        }
        private void LoadAccountDetail()
        {
            //Load Voucher Type by User Rights 

            LedgerController mLedgerController = new LedgerController();
            DataTable dt = mLedgerController.SelectVoucherType(SessionClass.UserID);
            cboxVoucherType.DataSource = dt;
            cboxVoucherType.DisplayMember = "slash_desc";
            cboxVoucherType.ValueMember = "voucher_type_id";

            // Load Account Head 
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
            //clsWebFormUtil.FillListBox(this.cboxAccountCode, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
            cboxAccountName.DataSource = dtHead;
            cboxAccountName.DisplayMember = "ACCOUNT_NAME";
            cboxAccountName.ValueMember = "ACCOUNT_HEAD_ID";
            ClassSession.dtHead = dtHead;

        }
        private void LoadPrincipal()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.UserID, Constants.IntNullValue, 0, System.DateTime.Now);
            clsWindowsFormUtil.SetComboboxItem _item = new clsWindowsFormUtil.SetComboboxItem();
            _item.Text = "General Entry";
            _item.Value = "0";
            this.cboxPrincipal.Items.Add(_item);
            //clsWebFormUtil.FillDropDownList(this.cboxPrincipal, m_dt, 0, 1);
            cboxPrincipal.DataSource = m_dt;
            cboxPrincipal.DisplayMember = "Company_Name";
            cboxPrincipal.ValueMember = "Company_Id";
        }
        private void LoadAccountHead()
        {
            if (cboxVoucherType.Items.Count > 0)
            {
                CORNCommon.Classes.Configuration.GetAccountHead();

                if (int.Parse(cboxVoucherType.SelectedValue.ToString()) == 14)
                {
                    AccountHeadController mAccountController = new AccountHeadController();
                    DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.CashDefaultType));
                    cboxBanks.DataSource = dt;
                    cboxBanks.DisplayMember = "ACCOUNT_NAME";
                    cboxBanks.ValueMember = "ACCOUNT_HEAD_ID";
                }
                else if (int.Parse(cboxVoucherType.SelectedValue.ToString()) == 15)
                {
                    AccountHeadController mAccountController = new AccountHeadController();
                    DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.BankDefaultType));
                    cboxBanks.DataSource = dt;
                    cboxBanks.DisplayMember = "ACCOUNT_NAME";
                    cboxBanks.ValueMember = "ACCOUNT_HEAD_ID";
                    cboxBanks.SelectedValue = "599";
                }
                else
                {
                    cboxBanks.DataSource = null;
                    cboxBanks.Items.Clear();
                    clsWindowsFormUtil.SetComboboxItem _item = new clsWindowsFormUtil.SetComboboxItem();
                    _item.Text = "N/A";
                    _item.Value = Constants.IntNullValue.ToString();
                    cboxBanks.Items.Add(_item);
                    cboxBanks.SelectedIndex = 0;
                }
            }
        } 

        #endregion

        #region Add New Voucher  (Click_EVENT)

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            if (txtCreditAmount.Text != string.Empty && txtDebitAmount.Text != string.Empty)
            {
                if (Convert.ToInt32(txtCreditAmount.Text) == 0)
                {
                    txtCreditAmount.Text = "";
                }
                if (Convert.ToInt32(txtDebitAmount.Text) == 0)
                {
                    txtDebitAmount.Text = "";
                }
            }
            if (txtDebitAmount.Text == "" && txtCreditAmount.Text == "")
            {
                ToastNotification.Show(this, "Enter Debit or Credit Amount", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
            else if (txtCreditAmount.Text != string.Empty && txtDebitAmount.Text != string.Empty)
            {
                ToastNotification.Show(this, "Enter Only Debit or Only Credit", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
            else if (DateValidation())
            {
                AddNEw();
                ArrangeGrid();
            }
        } 

        #endregion

        #region Add New Voucher (Function)
        public void AddNEw()
        {
            decimal TotalDebit = 0;
            decimal TotalCredit = 0;

            DataControl dc = new DataControl();
            DataTable dtHead = ClassSession.dtHead;
            dtVoucher = ClassSession.dtVoucher;
            DataRow[] foundRows = dtHead.Select("ACCOUNT_HEAD_ID  = '" + cboxAccountName.SelectedValue + "'");
            if (foundRows.Length > 0)
            {
                if (RowId >= 0)
                {
                    DataRow dr = dtVoucher.Rows[RowId];
                    dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                    dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                    dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                    dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                    dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                    dr["Principal"] = cboxPrincipal.Text;
                    dr["Principal_id"] = cboxPrincipal.SelectedValue;
                    dr["REMARKS"] = txtAccountDes.Text;
                }
                else
                {
                    DataRow dr = dtVoucher.NewRow();
                    dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                    dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                    dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                    dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                    dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                    dr["REMARKS"] = txtAccountDes.Text;
                    dr["Principal"] = cboxPrincipal.Text;
                    dr["Principal_id"] = cboxPrincipal.SelectedValue;
                    dtVoucher.Rows.Add(dr);
                }
            }

            #region Set Total

            foreach (DataRow dr in dtVoucher.Rows)
            {
                TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
            }
            txtTotalDebit.Text = decimal.Round(TotalDebit, 2).ToString();
            txtTotalCredit.Text = decimal.Round(TotalCredit, 2).ToString();

            #endregion

            #region Clear Txtbox

            cboxAccountName.SelectedItem = "";
            txtDebitAmount.Text = "";
            txtCreditAmount.Text = "";
            RowId = -1;

            #endregion

            GrdOrder.DataSource = dtVoucher;
            ClassSession.dtVoucher = dtVoucher;
        } 
        #endregion

        #region Update OR Delete VoucherEntry

        private void GrdOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GrdOrder.Columns["Edit"].Index)
            {
                int _rowIndex = GrdOrder.CurrentCell.RowIndex;
                RowId = GrdOrder.CurrentCell.RowIndex;
                cboxAccountName.SelectedValue = Convert.ToInt32(GrdOrder.Rows[_rowIndex].Cells["Account_Head_ID"].Value);
                cboxPrincipal.SelectedValue = Convert.ToInt32(GrdOrder.Rows[_rowIndex].Cells["Principal_Id"].Value);
                txtAccountDes.Text = GrdOrder.Rows[_rowIndex].Cells["Remarks"].Value.ToString();
                txtDebitAmount.Text = GrdOrder.Rows[_rowIndex].Cells["Debit"].Value.ToString();
                txtCreditAmount.Text = GrdOrder.Rows[_rowIndex].Cells["Credit"].Value.ToString();
            }
            else if (e.ColumnIndex == GrdOrder.Columns["Delete"].Index)
            {
                decimal TotalDebit = 0;
                decimal TotalCredit = 0;
                dtVoucher = ClassSession.dtVoucher;
                dtVoucher.Rows.RemoveAt(e.RowIndex);

                #region Set Total

                foreach (DataRow dr in dtVoucher.Rows)
                {
                    TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                    TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
                }
                txtTotalDebit.Text = TotalDebit.ToString();
                txtTotalCredit.Text = TotalCredit.ToString();

                #endregion

                GrdOrder.DataSource = dtVoucher;
                RowId = -1;
            }
        } 

        #endregion

        #region Save Voucher Entry

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GrdOrder.Rows.Count > 0)
            {
                Save_Voucher_Entry();
            }
        }
        public void Save_Voucher_Entry()
        {
            string _selectedPaymentModeName = cboxPaymentMode.SelectedItem.ToString();
            int _selectedPaymentModeValue = (int)((ModeList)Enum.Parse(typeof(ModeList), _selectedPaymentModeName));
            LedgerController mLController = new LedgerController();
            DataControl dc = new DataControl();
            dtVoucher = ClassSession.dtVoucher;
            DataTable dtHead = ClassSession.dtHead;

            decimal TotalDebit = 0;
            decimal TotalCredit = 0;

            #region Set Total

            foreach (DataRow dr in dtVoucher.Rows)
            {
                TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
            }
            #endregion

            #region In Case of Bank & Cash Voucher

            if (cboxBanks.Text != "N/A")
            {
                decimal differnceAmt = TotalDebit - TotalCredit;

                if (differnceAmt > 0)
                {
                    DataRow dr1 = dtVoucher.NewRow();
                    DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + cboxBanks.SelectedValue.ToString());
                    dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                    dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                    dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                    dr1["REMARKS"] = txtAccountDes.Text;
                    dr1["CREDIT"] = differnceAmt;
                    dr1["DEBIT"] = 0;
                    dr1["Principal"] = "";
                    dr1["Principal_id"] = dtVoucher.Rows[0]["Principal_id"].ToString();
                    dtVoucher.Rows.Add(dr1);

                }
                else if (differnceAmt < 0)
                {
                    DataRow dr1 = dtVoucher.NewRow();
                    DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + cboxBanks.SelectedValue.ToString());
                    dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                    dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                    dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                    dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                    dr1["REMARKS"] = txtAccountDes.Text;
                    dr1["CREDIT"] = 0;
                    dr1["DEBIT"] = -(differnceAmt);
                    dr1["Principal"] = "";
                    dr1["Principal_id"] = dtVoucher.Rows[0]["Principal_id"].ToString();
                    dtVoucher.Rows.Add(dr1);
                }
            }
            #endregion

            DateTime chequeDate = Convert.ToDateTime(txtChequeDate.Value);
            DateTime voucherdate = Convert.ToDateTime(txtVoucherDate.Value);
            DateTime dueDate = Convert.ToDateTime(txtDueDate.Value);


            dtVoucher = ClassSession.dtVoucher;
            string maxDocumentId = mLController.SelectMaxVoucherId(int.Parse(cboxVoucherType.SelectedValue.ToString()), int.Parse(cboxDistributor.SelectedValue.ToString()), voucherdate);

            bool isSaveVoucher = mLController.Add_Voucher(int.Parse(cboxDistributor.SelectedValue.ToString()), int.Parse(cboxPrincipal.SelectedValue.ToString()), maxDocumentId, int.Parse(cboxVoucherType.SelectedValue.ToString()), voucherdate, _selectedPaymentModeValue, Convert.ToString(txtpayeesName.Text), txtAccountDes.Text, chequeDate, txtChequeNo.Text, dtVoucher, SessionClass.UserID, txtSlipNo.Text, dueDate);

            if (isSaveVoucher == true)
            {
                MessageBox.Show(this, "Voucher No : " + maxDocumentId + " has been Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.ClearAll();
                // this.PrintVoucher(maxDocumentId); 

            }
            else
            {
                MessageBox.Show(this, "Error: \n" + "Some Wrong Entries", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void FormVoucherEntery_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 560, 220);
            groupBox1.Location = new Point(points[0],points[1]);
        }
    }
}
