using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormSupplierPayment : Form
    {
        readonly LedgerController LedgerCtl = new LedgerController();
        readonly SupplierController VendorCtl = new SupplierController();
        public FormSupplierPayment()
        {
            InitializeComponent();
        }

        private void FormSupplierPayment_Load(object sender, EventArgs e)
        {
            LoadPymentType();
            this.LoadDistributor();
            LoadPrincipal();
            LoadCredit();
            LoadAccountHead();
            LoadVendorPayment();
            txtChequeDate.Value = Convert.ToDateTime(SessionClass.CurrentWorkDate);
            ArrangeGrid();
        }
        private void LoadPymentType()
        {
            ddlPaymentMode.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("mValue", typeof(int));
            dt.Rows.Add("Cheque", 18);
            dt.Rows.Add("Cash", 19);
            dt.Rows.Add("Online Transfer", 20);
            dt.Rows.Add("Pay Order", 21);
            ddlPaymentMode.DataSource = dt;
            ddlPaymentMode.DisplayMember = "Display";
            ddlPaymentMode.ValueMember = "mValue";
            ddlPaymentMode.SelectedIndex = 1; 
        }
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            ddlDistributor.DataSource = null;
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            ddlDistributor.DataSource = dt;
            ddlDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            ddlDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        protected void ddlDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistributor.DisplayMember == "DISTRIBUTOR_NAME" && ddlDistributor.ValueMember == "DISTRIBUTOR_ID")
            {
                LoadAccountHead();
                LoadVendorPayment();
            }
        }
        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSupplier.DisplayMember == "SKU_HIE_NAME" && ddlSupplier.ValueMember == "SKU_HIE_ID")
            {
                LoadCredit();
                LoadVendorPayment();
            }
        }

        private void LoadPrincipal()
        {
            SkuHierarchyController _mController = new SkuHierarchyController();
            DataTable m_dt = _mController.SelectPrincipal(Constants.SKUPrincipal, SessionClass.CompanyID);
            ddlSupplier.DataSource = m_dt;
            ddlSupplier.DisplayMember = "SKU_HIE_NAME";
            ddlSupplier.ValueMember = "SKU_HIE_ID";
        }

        protected void LoadAccountHead()
        {
            ddlBank.DataSource = null;
            ddlBank.Items.Clear();
            CORNCommon.Classes.Configuration.GetAccountHead();
            AccountHeadController mAccountController = new AccountHeadController();
            if (ddlPaymentMode.SelectedValue.ToString() != "19")
            {

                DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.BankDefaultType));
                ddlBank.DataSource = dt;
                ddlBank.DisplayMember = "ACCOUNT_NAME";
                ddlBank.ValueMember = "ACCOUNT_HEAD_ID";
            }
            else
            {
                DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(CORNCommon.Classes.Configuration.CashDefaultType));
                ddlBank.DataSource = dt;
                ddlBank.DisplayMember = "ACCOUNT_NAME";
                ddlBank.ValueMember = "ACCOUNT_HEAD_ID";

            }
        }

        private void LoadCredit()
        {
            lblPayable.Text = "0.00";

            if (ddlSupplier.Items.Count > 0)
            {
                DataTable dtCredit = LedgerCtl.SelectPendingVendorCredit(int.Parse(ddlDistributor.SelectedValue.ToString()), int.Parse(ddlSupplier.SelectedValue.ToString()));
                if (dtCredit.Rows.Count > 0)
                {
                    lblPayable.Text = string.Format("{0:0.00}", dtCredit.Rows[0]["CURRENT_CREDIT_AMOUNT"]);
                }
            }
        }

        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMode.DisplayMember != "Display" || ddlPaymentMode.ValueMember != "mValue")
            {
                return;
            }
            if (ddlPaymentMode.SelectedValue.ToString() == "18")// check
            {
                txtCheque.Enabled = true;
                //txtSlip.Enabled = false;
                txtChequeDate.Enabled = true;
                txtNarration.Enabled = true;
                ddlBank.Enabled = true;
                lblChequeDate.Text = "Cheque Date";
            }
            else if (ddlPaymentMode.SelectedValue.ToString() == "19")// cash
            {
                txtCheque.Enabled = false;
                // txtSlip.Enabled = false;
                txtChequeDate.Enabled = false;

                lblChequeDate.Text = "Cheque Date";
            }
            else
            {
                lblChequeDate.Text = "Transfer Date";
                txtCheque.Enabled = false;
                //  txtSlip.Enabled = true;
                txtChequeDate.Enabled = true;
                txtNarration.Enabled = true;
                ddlBank.Enabled = true;
            }

            LoadAccountHead();
            LoadVendorPayment();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal Amount = 0;
            //decimal Discount = 0;
            //decimal IncomeTax = 0;

            try
            {
                Amount = Convert.ToDecimal(txtAmount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Please enter amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Amount <= 0)
            {
                MessageBox.Show(this, "Please enter amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ChequeDate = Constants.DateNullValue;

            if (ddlPaymentMode.SelectedValue.ToString() == "18" || ddlPaymentMode.SelectedValue.ToString() == "33")
            {

                ChequeDate = DateTime.Parse(txtChequeDate.Text);
            }

            string VoucherNo = LedgerCtl.SelectLedgerMaxDocumentId(Constants.Expanse_Voucher, Convert.ToInt32(ddlDistributor.SelectedValue.ToString()), 1);


            LedgerCtl.InsertVendorLedger(Convert.ToInt32(Constants.Expanse_Voucher), long.Parse(VoucherNo), Convert.ToInt32(CORNCommon.Classes.Configuration.PayableAccount), Convert.ToInt32(ddlDistributor.SelectedValue.ToString()), 0, Amount, Convert.ToDateTime(SessionClass.CurrentWorkDate), txtNarration.Text, Convert.ToInt32(ddlSupplier.SelectedValue.ToString()), Constants.LongNullValue, Constants.Document_Purchase, Convert.ToInt32(SessionClass.UserID), Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString()), ChequeDate, txtCheque.Text, null);
            LedgerCtl.InsertVendorLedger(Convert.ToInt32(Constants.Expanse_Voucher), long.Parse(VoucherNo), Convert.ToInt32(ddlBank.SelectedValue.ToString()), Convert.ToInt32(ddlDistributor.SelectedValue.ToString()), Amount, 0, Convert.ToDateTime(SessionClass.CurrentWorkDate), txtNarration.Text, Convert.ToInt32(ddlSupplier.SelectedValue.ToString()), Constants.LongNullValue, Constants.Document_Purchase, Convert.ToInt32(SessionClass.UserID), Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString()), ChequeDate, txtCheque.Text, null);

            //if (Discount > 0)
            //{
            //    LedgCtl.InsertVendorLedger(476, Convert.ToInt32(ddlDistributor.SelectedValue), 0, Discount, Convert.ToDateTime(Session["CurrentWorkDate"]), txtNarration.Text, Convert.ToInt32(ddlSupplier.SelectedValue), Constants.LongNullValue, Constants.Document_Purchase, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text);
            //}

            //if (IncomeTax > 0)
            //{
            //    LedgCtl.InsertVendorLedger(478, Convert.ToInt32(ddlDistributor.SelectedValue), 0, IncomeTax, Convert.ToDateTime(Session["CurrentWorkDate"]), txtNarration.Text, Convert.ToInt32(ddlSupplier.SelectedValue), Constants.LongNullValue, Constants.Document_Purchase, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text);
            //}

            ClearForm();
            LoadCredit();
            LoadVendorPayment();

        }

        private void ClearForm()
        {
            txtCheque.Text = "";
            // txtSlip.Text = "";
            txtAmount.Text = "";
            txtNarration.Text = "";
        }
        /// <summary>
        /// Loads Opening Credits Detail To Grid
        /// </summary>
        private void LoadVendorPayment()
        {
            if (ddlSupplier.DisplayMember != "SKU_HIE_NAME" || ddlSupplier.ValueMember != "SKU_HIE_ID")
            {
                return;
            }
            if (ddlPaymentMode.SelectedValue.ToString() == "18")
            {
                lblGChequeDate.Text = "Cheque Date";
            }
            else
            {
                lblGChequeDate.Text = "Transfer Date";
            }
            CustomerDataController cdc = new CustomerDataController();
            DataTable dt = cdc.GetVendorPayment(int.Parse(ddlDistributor.SelectedValue.ToString()), Convert.ToInt32(ddlSupplier.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToString()), Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString()));
            GrdCredit.DataSource = dt;
        }
        public void ArrangeGrid()
        {
            try
            {
                GrdCredit.Columns.Remove("Delete");
            }
            catch (Exception)
            { }

            GrdCredit.Columns["VOUCHER_NO"].Visible = false;
            //GrdCredit.Columns["ACCOUNT_NAME"].DisplayIndex = GrdCredit.Columns["CHQUE_DATE"].DisplayIndex + 1;


            GrdCredit.Columns["Cheque_NO"].Width = 110;
            GrdCredit.Columns["Chque_DATE"].Width = 150;
            GrdCredit.Columns["ACCOUNT_NAME"].Width = 320;
            GrdCredit.Columns["Amount"].Width = 110;
            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            GrdCredit.Columns.Add(btnDelete);
           // GrdCredit.Columns["DELETE"].DisplayIndex = GrdCredit.Columns["ACCOUNT_NAME"].Index + 1;
            GrdCredit.Columns["DELETE"].Width = 60;
        }

        private void GrdCredit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != GrdCredit.Columns["Delete"].Index)
            {
                return;
            }
            if (clsWindowsFormUtil.DeleteConfirmation("Are you sure ?"))
            {
                if (LedgerCtl.DeleteVendorPayment(Convert.ToInt32(ddlDistributor.SelectedValue.ToString()), Convert.ToInt32(ddlSupplier.SelectedValue.ToString()), Convert.ToDateTime(SessionClass.CurrentWorkDate), Convert.ToInt32(ddlPaymentMode.SelectedValue.ToString()), long.Parse(GrdCredit.Rows[e.RowIndex].Cells[5].Value.ToString().Replace("&nbsp;", ""))))
                {
                    ClearForm();
                    LoadCredit();
                    LoadVendorPayment();
                }
                else
                {
                    MessageBox.Show(this, "Some error occured", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormSupplierPayment_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 420, 210);
            groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
