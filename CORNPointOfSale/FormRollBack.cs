using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using DevComponents.DotNetBar;

namespace CORNPointOfSale
{
    public partial class FormRollBack : Form
    {
        public FormRollBack()
        {
            InitializeComponent();
        }

        private void FormRollBack_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 530, 180);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

        private void FormRollBack_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadSupplier();
            this.LoadLegend();
            this.LoadDocumentType();
            this.LoadSaleForce();
        }
        private void LoadDistributor()
        {
            cboxLocation.SelectedIndexChanged -= new EventHandler(drpDistributor_SelectedIndexChanged);
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, SessionClass.UserID, SessionClass.CompanyID);
            cboxLocation.DataSource = dt;
            cboxLocation.DisplayMember = "DISTRIBUTOR_NAME";
            cboxLocation.ValueMember = "DISTRIBUTOR_ID";
            cboxLocation.SelectedIndexChanged += new EventHandler(drpDistributor_SelectedIndexChanged);
        }

        private void LoadDocumentType()
        {
            DrpDocumentType.SelectedIndexChanged -= new EventHandler(DrpDocumentType_SelectedIndexChanged);
            DataTable dt = new DataTable();
            dt.Columns.Add("display", typeof(string));
            dt.Columns.Add("value", typeof(int));
            dt.Rows.Add("Sale Invoice", 1);
            dt.Rows.Add("Sale Return", 2);
            DrpDocumentType.DataSource = dt;
            DrpDocumentType.DisplayMember = "display";
            DrpDocumentType.ValueMember = "value";
            DrpDocumentType.SelectedIndexChanged += new EventHandler(DrpDocumentType_SelectedIndexChanged);
        }

        private void LoadSupplier()
        {
            cboxSupplier.SelectedIndexChanged -= new EventHandler(DrpPrincipal_SelectedIndexChanged);
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, SessionClass.UserID, Constants.IntNullValue, 0, SessionClass.CurrentWorkDate);
            cboxSupplier.DataSource = m_dt;
            cboxSupplier.DisplayMember = "Company_Name";
            cboxSupplier.ValueMember = "Company_Id";
            cboxSupplier.SelectedIndexChanged += new EventHandler(DrpPrincipal_SelectedIndexChanged);
        }

        private void LoadLegend()
        {
            OrderEntryController or = new OrderEntryController();
            DataTable m_dt = or.SelectLegend();
            cboxLegend.DataSource = m_dt;
            cboxLegend.DisplayMember = "LEGEND_NAME";
            cboxLegend.ValueMember = "LEGEND_ID";
        }

        private void LoadSaleForce()
        {
            if (cboxLocation.Items.Count > 0 && DrpDocumentType.Items.Count > 0)
            {
                SaleForceController mDController = new SaleForceController();
                DataTable m_dt = mDController.SelectRollBackInvoiceSaleForce(Convert.ToInt32(DrpDocumentType.SelectedValue.ToString()), Convert.ToInt32(cboxSupplier.SelectedValue.ToString()), Convert.ToInt32(cboxLocation.SelectedValue.ToString()));
                cboxSalesForce.DataSource = m_dt;
                cboxSalesForce.DisplayMember = "USER_NAME";
                cboxSalesForce.ValueMember = "USER_ID";
            }
            else
            {
                cboxSalesForce.Items.Clear();
            }
        }

        private void LoadRollbackDocument()
        {
            OrderEntryController or = new OrderEntryController();
            DataTable dtOrder = or.SelectRollBackDocument(int.Parse(cboxLocation.SelectedValue.ToString()), int.Parse(cboxSupplier.SelectedValue.ToString()),
                int.Parse(cboxSalesForce.SelectedValue.ToString()), int.Parse(DrpDocumentType.SelectedValue.ToString()), SessionClass.CurrentWorkDate);
            GrdOrder.DataSource = dtOrder;
            ArrangeGrid();
        }

        public void ArrangeGrid()
        {
            try
            {
                GrdOrder.Columns.Remove("Select");
            }
            catch (Exception)
            { }
            foreach (DataGridViewColumn clm in GrdOrder.Columns)
            {
                clm.Visible = false;
            }
            GrdOrder.Columns["CUSTOMER_CODE"].Visible = true;
            GrdOrder.Columns["CUSTOMER_NAME"].Visible = true;
            GrdOrder.Columns["Document_Id"].Visible = true;
            GrdOrder.Columns["DOCUMENT_DATE"].Visible = true;
            GrdOrder.Columns["TOTAL_AMOUNT"].Visible = true;
            GrdOrder.Columns["DISCOUNT_AMOUNT"].Visible = true;
            GrdOrder.Columns["SCHEME_AMOUNT"].Visible = true;
            GrdOrder.Columns["GST_AMOUNT"].Visible = true;
            GrdOrder.Columns["TOTAL_NET_AMOUNT"].Visible = true;
            //--------------Header Text------------------------
            GrdOrder.Columns["CUSTOMER_CODE"].HeaderText = "Code";
            GrdOrder.Columns["CUSTOMER_NAME"].HeaderText = "Name";
            GrdOrder.Columns["Document_Id"].HeaderText = "Document Id";
            GrdOrder.Columns["DOCUMENT_DATE"].HeaderText = "Document Date";
            GrdOrder.Columns["TOTAL_AMOUNT"].HeaderText = "Gross Amount";
            GrdOrder.Columns["DISCOUNT_AMOUNT"].HeaderText = "Discount";
            GrdOrder.Columns["SCHEME_AMOUNT"].HeaderText = "Scheme";
            GrdOrder.Columns["GST_AMOUNT"].HeaderText = "GST Amount";
            GrdOrder.Columns["TOTAL_NET_AMOUNT"].HeaderText = "Net Amount";
            //--------------Column Index------------------------
            GrdOrder.Columns["CUSTOMER_CODE"].DisplayIndex = 1;
            GrdOrder.Columns["CUSTOMER_NAME"].DisplayIndex = 2;
            GrdOrder.Columns["Document_Id"].DisplayIndex = 3;
            GrdOrder.Columns["DOCUMENT_DATE"].DisplayIndex = 4;
            GrdOrder.Columns["TOTAL_AMOUNT"].DisplayIndex = 5;
            GrdOrder.Columns["DISCOUNT_AMOUNT"].DisplayIndex = 6;
            GrdOrder.Columns["SCHEME_AMOUNT"].DisplayIndex = 7;
            GrdOrder.Columns["GST_AMOUNT"].DisplayIndex = 8;
            GrdOrder.Columns["TOTAL_NET_AMOUNT"].DisplayIndex = 9;
            //---------------------------------------------------------
            // Add Check Button
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.ReadOnly = false;
            GrdOrder.Columns.Add(checkColumn);
            GrdOrder.Columns["Select"].DisplayIndex = 0;
            GrdOrder.Columns["SELECT"].HeaderText = "";
        }

        private void LoadRollbackCheque()
        {
            ChequeEntryController CController = new ChequeEntryController();
            DataTable dt = CController.SelectChequeEntry(Constants.Cheque_Clear, SessionClass.CurrentWorkDate, Convert.ToInt32(cboxLocation.SelectedValue.ToString()), Convert.ToInt32(cboxSupplier.SelectedValue.ToString()), 0);
            GrdCheque.DataSource = dt;
        }

        protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSaleForce();
        }

        protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSupplier();
            this.LoadSaleForce();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (DrpDocumentType.SelectedIndex == 3)
            {
                //foreach (DataGridViewRow dr in GrdCheque.Rows)
                //{
                //    CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
                //    if (ChbInvoice.Checked == true)
                //    {
                //        ChequeEntryController CController = new ChequeEntryController();
                //        DataControl dc = new DataControl();
                //        CController.RollbackChequeEntry(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), dr.Cells[6].Text, long.Parse(dr.Cells[0].Text), Constants.LongNullValue);
                //    }
                //}
                //LoadRollbackCheque();
            }
            else
            {
                foreach (DataGridViewRow dr in GrdOrder.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Select"].Value) == true)
                    {
                        int _rowIndex = dr.Index;
                        OrderEntryController ORD = new OrderEntryController();
                        DataControl dc = new DataControl();
                        ORD.UpdateRollBackDocument(Convert.ToInt64(GrdOrder.Rows[_rowIndex].Cells["Document_Id"].Value.ToString()), Convert.ToInt32(DrpDocumentType.SelectedValue.ToString()), Convert.ToInt32(cboxLegend.SelectedValue.ToString()));
                    }
                }
                this.LoadRollbackDocument();
            }
        }

        protected void btnGetOrder_Click(object sender, EventArgs e)
        {
            if (DrpDocumentType.SelectedIndex == 3)
            {
                this.LoadRollbackCheque();
                GrdOrder.Visible = false;
                GrdCheque.Visible = true;
                GrdCheque.BringToFront();
            }
            else
            {
                GrdOrder.Visible = true;
                GrdOrder.BringToFront();
                GrdCheque.Visible = false;
                this.LoadRollbackDocument();
            }
        }

        protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSaleForce();
        }
    }
}
