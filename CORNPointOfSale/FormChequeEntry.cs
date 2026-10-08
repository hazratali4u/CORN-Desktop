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

namespace CORNPointOfSale
{
    public partial class FormChequeEntry : Form
    {
        public FormChequeEntry()
        {
            InitializeComponent();
        }

        private void FormChequeEntry_Load(object sender, EventArgs e)
        {
            lblTotalAmount.Visible = false;
            LoadStatus();
            LoadAccountHead();
            LoadDistributor();
            LoadData();
            SelectCreditInvoice();
            LoadReceviedCheque();
            DrpStatus.SelectedIndex = 1;
        }
        public void LoadStatus()
        {
            DrpStatus.SelectedIndexChanged -= new EventHandler(DrpStatus_SelectedIndexChanged);
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            //dt.Rows.Add("Cheque Received", 527);
            //dt.Rows.Add("Cheque Deposit", 528);
            dt.Rows.Add("Cheque", 529);
            dt.Rows.Add("Cash", 561);
            dt.Rows.Add("Online Transaction", 562);
            //dt.Rows.Add("Cheque Bounce", 530);
            //dt.Rows.Add("Cheque Cancel", 560);
            DrpStatus.DataSource = dt;
            DrpStatus.DisplayMember = "Display";
            DrpStatus.ValueMember = "Value";
            DrpStatus.SelectedIndexChanged += new EventHandler(DrpStatus_SelectedIndexChanged);
        }
        private void LoadDistributor()
        {
            try
            {
                drpDistributor.SelectedIndexChanged -= new EventHandler(drpDistributor_SelectedIndexChanged);
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
                drpDistributor.DataSource = dt;
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
                drpDistributor.SelectedIndexChanged += new EventHandler(drpDistributor_SelectedIndexChanged);
            }
            catch (Exception)
            {
            }
        }

        private void LoadData()
        {
            try
            {
                GrdCredit.DataSource = null;
                CustomerDataController mController = new CustomerDataController();
                if (drpDistributor.Items.Count > 0)
                {
                    DrpCustomer.SelectedIndexChanged -= new EventHandler(DrpCustomer_SelectedIndexChanged);
                    LedgerController LedgerCtl = new LedgerController();
                    DataTable dtCredit = LedgerCtl.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.LongNullValue, Constants.IntNullValue);
                    DrpCustomer.DataSource = dtCredit;
                    DrpCustomer.DisplayMember = "Customer_name";
                    DrpCustomer.ValueMember = "CUSTOMER_ID";
                    DrpCustomer.SelectedIndexChanged += new EventHandler(DrpCustomer_SelectedIndexChanged);
                }
            }
            catch (Exception)
            {
            }
        }


        private void ClearAll()
        {
            txtChequeNo.Text = "";
            txtAmount.Text = "";
            //  txtBankName.Text = "";
            txtStartDate.Text = "";
            btnSave.Text = "Save";
            // txtReceivedDate.Text = "";
            txtSlipNo.Text = "";
            txtRemarks.Text = "";
        }

        private void LoadReceviedCheque()
        {
            if (DrpStatus.SelectedValue.ToString() != Constants.Cheque_Clear.ToString())
            {
                ChequeEntryController CController = new ChequeEntryController();
                DataTable dt = CController.SelectChequeEntry(int.Parse(DrpStatus.SelectedValue.ToString()), Convert.ToDateTime(SessionClass.CurrentWorkDate), Convert.ToInt32(drpDistributor.SelectedValue.ToString()), 0, 0);
                SessionClass.dt = dt;
                GrdOrder.DataSource = dt;
                ArrangeGrdOrder();
            }
            else
            {
                GrdOrder.DataSource = null;
            }
        }
        public void ArrangeGrdOrder()
        {
            try
            {
                GrdOrder.Columns.Remove("Edit");
            }
            catch (Exception)
            { }

            foreach (DataGridViewColumn clm in GrdOrder.Columns)
            {
                clm.Visible = false;
            }
            try
            {
                GrdOrder.Columns["CUSTOMER_NAME"].Visible = true;
                GrdOrder.Columns["CHEQUE_NO"].Visible = true;
                GrdOrder.Columns["BANK_NAME"].Visible = true;
                GrdOrder.Columns["CHEQUE_DATE"].Visible = true;
                GrdOrder.Columns["RECEIVED_DATE"].Visible = true;
                GrdOrder.Columns["DEPOSIT_DATE"].Visible = true;
                GrdOrder.Columns["CHEQUE_AMOUNT"].Visible = true;
                GrdOrder.Columns["SlipNo"].Visible = true;
                // Add Edit Button
                DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
                btnEdit.HeaderText = "Edit";
                btnEdit.Name = "Edit";
                btnEdit.DataPropertyName = "lnkColumn";
                btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
                //GrdOrder.Columns.Add(btnEdit);
                GrdOrder.Columns.Insert(0, btnEdit);
                GrdOrder.Columns["Edit"].DisplayIndex = 18;
                // Rename
                GrdOrder.Columns["CUSTOMER_NAME"].HeaderText = "Customer";
                GrdOrder.Columns["CHEQUE_NO"].HeaderText = "Cehque No";
                GrdOrder.Columns["BANK_NAME"].HeaderText = "Bank";
                GrdOrder.Columns["CHEQUE_DATE"].HeaderText = "Cehque Date";
                GrdOrder.Columns["RECEIVED_DATE"].HeaderText = "Recieved Date";
                GrdOrder.Columns["DEPOSIT_DATE"].HeaderText = "Deposit Date";
                GrdOrder.Columns["CHEQUE_AMOUNT"].HeaderText = "Amount";
                GrdOrder.Columns["SlipNo"].HeaderText = "Slip No";
            }
            catch (Exception)
            {
            }
        }
        private void SelectCreditInvoice()
        {
            LedgerController CDC = new LedgerController();
            GrdCredit.DataSource = null;
            if (DrpCustomer.Items.Count > 0)
            {
                DataTable dtCredit = CDC.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, long.Parse(DrpCustomer.SelectedValue.ToString()), 0);
                GrdCredit.DataSource = dtCredit;
                ArrangeGridCredit();
            }
        }
        public void ArrangeGridCredit()
        {
            try
            {
                GrdCredit.Columns.Remove("Select");
            }
            catch (Exception)
            { }
            GrdCredit.Columns["DELIVERYMAN_ID"].Visible = false;
            GrdCredit.Columns["customer_id"].Visible = false;
            GrdCredit.Columns["MANUAL_INVOICE_ID"].Visible = false;
            GrdCredit.Columns["INVOICE ID"].Visible = false;
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GrdCredit.Columns.Add(checkColumn);
            GrdCredit.Columns["Select"].DisplayIndex = 0;
            GrdCredit.Columns["Select"].Width = 50;
            GrdCredit.Columns["SELECT"].HeaderText = "";

            decimal sum = 0;
            foreach (DataGridViewRow row in GrdCredit.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Current Credit"].Value);
            }

            if (sum > 0)
            {
                lblTotalAmount.Visible = true;
                lblTotalAmount.Text = "Total Current Credit: " + sum.ToString("N");
            }
            else
            {
                lblTotalAmount.Visible = false;
            }
        }
        private void ChequeRealization()
        {
            LedgerController LController = new LedgerController();
            string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue);
            decimal OfferAmount = decimal.Parse(txtAmount.Text);
            foreach (DataGridViewRow dr in GrdCredit.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                {
                    if (Convert.ToDecimal(dr.Cells["Current Credit"].Value.ToString()) >= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        txtChequeNo.Text, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), Convert.ToInt32(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        txtChequeNo.Text, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        OfferAmount = decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) - OfferAmount;
                        LController.UpdateSaleInvoice(Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                        break;
                    }
                    else if (decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) <= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells["Current Credit"].Value.ToString()),
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        txtChequeNo.Text, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[5].Value.ToString()), 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        txtChequeNo.Text, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        OfferAmount = OfferAmount - decimal.Parse(dr.Cells["Current Credit"].Value.ToString());
                        LController.UpdateSaleInvoice(long.Parse(dr.Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                    }
                }
            }
        }
        private void CashRealization()
        {
            LedgerController LController = new LedgerController();
            string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Cash_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue);
            decimal OfferAmount = decimal.Parse(txtAmount.Text);
            foreach (DataGridViewRow dr in GrdCredit.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                {
                    if (Convert.ToDecimal(dr.Cells["Current Credit"].Value.ToString()) >= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cash Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 19, "");

                        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), Convert.ToInt32(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cash Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                       null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 19, "");

                        OfferAmount = decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) - OfferAmount;
                        LController.UpdateSaleInvoice(Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                        break;
                    }
                    else if (decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) <= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells["Current Credit"].Value.ToString()),
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cash Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 19, "");

                        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells["Current Credit"].Value.ToString()), 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Cash Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 19, "");

                        OfferAmount = OfferAmount - decimal.Parse(dr.Cells["Current Credit"].Value.ToString());
                        LController.UpdateSaleInvoice(long.Parse(dr.Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                    }
                }
            }
        }
        private void OnlineRealization()
        {
            LedgerController LController = new LedgerController();
            string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue);
            decimal OfferAmount = decimal.Parse(txtAmount.Text);
            foreach (DataGridViewRow dr in GrdCredit.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                {
                    if (Convert.ToDecimal(dr.Cells["Current Credit"].Value.ToString()) >= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Cash_Relization, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Online Transaction", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, "");

                        LController.PostingCash_Bank_Account(Constants.Cash_Relization, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), Convert.ToInt32(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Online Transaction", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                       null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, "");

                        OfferAmount = decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) - OfferAmount;
                        LController.UpdateSaleInvoice(Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                        break;
                    }
                    else if (decimal.Parse(dr.Cells["Current Credit"].Value.ToString()) <= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Cash_Relization, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells["Current Credit"].Value.ToString()),
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Online Transaction", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        LController.PostingCash_Bank_Account(Constants.Cash_Relization, long.Parse(MaxDocumentId), Convert.ToInt64(DrpBankAccount.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[5].Value.ToString()), 0,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), "Online Transaction", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), Constants.IntNullValue,
                        null, Convert.ToInt32(SessionClass.UserID), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()), dr.Cells[5].Value.ToString(), Constants.Document_Invoice, null, Constants.DateNullValue, 18, "");

                        OfferAmount = OfferAmount - decimal.Parse(dr.Cells["Current Credit"].Value.ToString());
                        LController.UpdateSaleInvoice(long.Parse(dr.Cells["Invoice ID"].Value.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                    }
                }
            }
        }
        private void LoadAccountHead()
        {
            CORNCommon.Classes.Configuration.GetAccountHead();
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.BankDefaultType));
            DrpBankAccount.DataSource = dt;
            DrpBankAccount.DisplayMember = "ACCOUNT_NAME";
            DrpBankAccount.ValueMember = "ACCOUNT_HEAD_ID";
            //
            if (int.Parse(DrpStatus.SelectedValue.ToString()) == 561)
            {
                AccountHeadController _mAccountController = new AccountHeadController();
                DataTable dt1 = _mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.CashDefaultType));
                DrpBankAccount.DataSource = dt1;
                DrpBankAccount.DisplayMember = "ACCOUNT_NAME";
                DrpBankAccount.ValueMember = "ACCOUNT_HEAD_ID";
            }
            else if (int.Parse(DrpStatus.SelectedValue.ToString()) == 529)
            {
                AccountHeadController _mAccountController = new AccountHeadController();
                DataTable dt2 = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.BankDefaultType));
                DrpBankAccount.DataSource = dt2;
                DrpBankAccount.DisplayMember = "ACCOUNT_NAME";
                DrpBankAccount.ValueMember = "ACCOUNT_HEAD_ID";
                //  DrpBankAccount.SelectedValue = "599";
            }
            else
            {
                AccountHeadController _mAccountController = new AccountHeadController();
                DataTable dt2 = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.BankDefaultType));
                DrpBankAccount.DataSource = dt2;
                DrpBankAccount.DisplayMember = "ACCOUNT_NAME";
                DrpBankAccount.ValueMember = "ACCOUNT_HEAD_ID";
                //  DrpBankAccount.SelectedValue = "599";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DrpCustomer.Items.Count == 0)
            {
                MessageBox.Show(this, "Select Customer", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (DrpBankAccount.Items.Count == 0)
            //{
            //    MessageBox.Show(this, "Select Bank Account", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DrpStatus.SelectedIndex == 0 && txtChequeNo.TextLength == 0)
            {
                MessageBox.Show(this, "Enter Cheque No", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txtBankName.TextLength == 0)
            //{
            //    MessageBox.Show(this, "Enter Bank Name", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (txtAmount.TextLength == 0)
            {
                MessageBox.Show(this, "Enter Amount", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DrpStatus.SelectedIndex == 2 && txtSlipNo.TextLength == 0)
            {
                MessageBox.Show(this, "Enter Slip No", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtStartDate.Value.ToString().Length == 0)
            {
                MessageBox.Show(this, "Enter Date", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChequeEntryController CController = new ChequeEntryController();

            DateTime ChequeDate;

            if (txtStartDate.Text.Length == 10)
            {
                ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtStartDate.Text));
            }
            else
            {
                ChequeDate = DateTime.Now;
            }

            int InvoiceCount = Constants.IntNullValue;
            foreach (DataGridViewRow dr in GrdCredit.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                {
                    InvoiceCount++;
                    break;
                }
            }

            if (InvoiceCount == Constants.IntNullValue)
            {
                MessageBox.Show(this, "Please select invoice", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnSave.Text == "Save")
            {
                if (DrpStatus.SelectedIndex == 0)
                {
                    HFChqueProcessId.Text = CController.InsertChequeEntry(int.Parse(drpDistributor.SelectedValue.ToString()), 0, long.Parse(DrpCustomer.SelectedValue.ToString()), txtChequeNo.Text, null, ChequeDate,
                        Convert.ToDateTime(SessionClass.CurrentWorkDate), Constants.DateNullValue, Constants.DateNullValue, decimal.Parse(txtAmount.Text), int.Parse(DrpStatus.SelectedValue.ToString()), DateTime.Now, 0, txtSlipNo.Text, txtRemarks.Text, Constants.LongNullValue);
                    foreach (DataGridViewRow dr in GrdCredit.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                        {
                            CController.InsertChequeEntryInvoice(long.Parse(HFChqueProcessId.Text.ToString()), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()));
                        }
                    }
                    this.ChequeRealization();
                    this.LoadData();
                    this.SelectCreditInvoice();
                    this.ClearAll();
                    // this.LoadReceviedCheque();
                }
                if (DrpStatus.SelectedIndex == 1)
                {
                    this.CashRealization();
                    this.LoadData();
                    this.SelectCreditInvoice();
                    this.ClearAll();
                    // this.LoadReceviedCheque();
                }
                if (DrpStatus.SelectedIndex == 2)
                {
                    this.OnlineRealization();
                    this.LoadData();
                    this.SelectCreditInvoice();
                    this.ClearAll();
                    // this.LoadReceviedCheque();
                }
            }
            else
            {


                //CController.UpdateChequeEntry(long.Parse(HFChqueProcessId.Text.ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.LongNullValue, null, null, Constants.DateNullValue, Constants.DateNullValue, Constants.DateNullValue, Convert.ToDateTime(SessionClass.CurrentWorkDate),
                //                                 Constants.DecimalNullValue, int.Parse(DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, txtSlipNo.Text, 0, txtRemarks.Text, long.Parse(DrpBankAccount.SelectedValue.ToString()));

                //CController.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Text.ToString()), 1);

                //foreach (DataGridViewRow dr in GrdCredit.Rows)
                //{
                //    if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                //    {
                //        CController.InsertChequeEntryInvoice(long.Parse(HFChqueProcessId.Text.ToString()), Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells["Invoice ID"].Value.ToString()));
                //    }
                //}

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectCreditInvoice();
        }

        protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadData();
            this.SelectCreditInvoice();
            this.LoadReceviedCheque();
        }

        protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpStatus.SelectedIndex == 0)
            {
                txtSlipNo.Enabled = false;
                txtChequeNo.Enabled = true;
                txtSlipNo.Text = string.Empty;
            }
            else if (DrpStatus.SelectedIndex == 1)
            {
                txtSlipNo.Enabled = false;
                txtChequeNo.Enabled = false;
                txtSlipNo.Text = string.Empty;
                txtChequeNo.Text = string.Empty;
            }
            else if (DrpStatus.SelectedIndex == 2)
            {
                txtSlipNo.Enabled = true;
                txtChequeNo.Enabled = false;
                txtChequeNo.Text = string.Empty;
            }
            if (btnSave.Text == "Save")
            {
                this.LoadReceviedCheque();
            }
            LoadAccountHead();
        }

        private void FormChequeEntry_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 565, 200);
            groupBox1.Location = new Point(points[0], points[1]);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void GrdOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GrdOrder.Columns["Edit"].Index)
            {
                try
                {
                    ChequeEntryController Ccontroller = new ChequeEntryController();
                    HFChqueProcessId.Text = GrdOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //  DrpRoute.SelectedValue = GrdOrder.Rows[e.RowIndex].Cells[11].Text;

                    this.LoadData();

                    DrpCustomer.SelectedValue = Convert.ToInt32(GrdOrder.Rows[e.RowIndex].Cells[3].Value.ToString());

                    txtChequeNo.Text = GrdOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
                    // txtBankName.Text = GrdOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtStartDate.Text = GrdOrder.Rows[e.RowIndex].Cells[7].Value.ToString();
                    //txtReceivedDate.Text = GrdOrder.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtAmount.Text = GrdOrder.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtSlipNo.Text = GrdOrder.Rows[e.RowIndex].Cells[14].Value.ToString();
                    txtRemarks.Text = GrdOrder.Rows[e.RowIndex].Cells[15].Value.ToString();
                    //DrpBankAccount.SelectedValue = Convert.ToInt32(GrdOrder.Rows[e.RowIndex].Cells[16].Value.ToString());
                    try
                    {
                        //   DrpDeliveryMan.SelectedValue = GrdOrder.Rows[e.RowIndex].Cells[14].Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Sale Force not found", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    btnSave.Text = "Update";
                    this.SelectCreditInvoice();

                    DataTable dt = Ccontroller.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Text), 0);

                    foreach (DataGridViewRow dr in GrdCredit.Rows)
                    {
                        foreach (DataRow dbr in dt.Rows)
                        {
                            if (Convert.ToInt64(GrdCredit.Rows[dr.Index].Cells[0].Value) == Convert.ToInt64(dbr["SALE_INVOICE_ID"]))
                            {
                                GrdCredit.Rows[dr.Index].Cells[6].Value = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Invoice not found for selected cheque", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
