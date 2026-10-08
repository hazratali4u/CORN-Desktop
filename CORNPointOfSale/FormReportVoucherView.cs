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
    public partial class FormReportVoucherView : Form
    {
        public FormReportVoucherView()
        {
            InitializeComponent();
        }

        private void FormReportVoucherView_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.VoucherType();
            CORNCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)SessionClass.CurrentWorkDate;
            txtStartDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
            txtEndDate.Value = CORNCommon.Classes.Configuration.SystemCurrentDateTime;
        }
        public void ArrangeGrid()
        {
            try
            {
                GrdLedger.Columns.Remove("Edit");
            }
            catch (Exception)
            {
            }
            GrdLedger.Columns["VOUCHER_NO"].HeaderText = "Voucher Number";
            GrdLedger.Columns["LEDGER_DATE"].HeaderText = "Ledger Date";
            GrdLedger.Columns["REMARKS"].HeaderText = "Remarks";
            GrdLedger.Columns["VOUCHER_TYPE_ID"].Visible = false;
            GrdLedger.Columns["VOUCHER_DATE"].HeaderText = "Voucher Date";

            GrdLedger.Columns["VOUCHER_NO"].Width = 150;
            GrdLedger.Columns["LEDGER_DATE"].Width = 150;
            GrdLedger.Columns["REMARKS"].Width = 310;
            GrdLedger.Columns["VOUCHER_DATE"].Width = 150;

            GrdLedger.Columns["VOUCHER_DATE"].DisplayIndex = GrdLedger.Columns["REMARKS"].DisplayIndex - 1;

            // Add Edit Button
            DataGridViewLinkColumn btnEdit = new DataGridViewLinkColumn();
            btnEdit.HeaderText = "Print";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Text = "Print";
            btnEdit.UseColumnTextForLinkValue = true;
            btnEdit.LinkBehavior = LinkBehavior.HoverUnderline;
            btnEdit.LinkColor = Color.Blue;
            GrdLedger.Columns.Add(btnEdit);
            GrdLedger.Columns["Edit"].Width = 70;
            GrdLedger.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GrdLedger.Columns["Edit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            drpDistributor.DataSource = DISTRIBUTOR_ALL(dt);
            drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            drpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }
        public DataTable DISTRIBUTOR_ALL(DataTable dt)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["DISTRIBUTOR_ID"] = Constants.IntNullValue;
            dr["DISTRIBUTOR_NAME"] = "All";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        /// <summary>
        /// Loads Voucher Types To VoucherType Combo
        /// </summary>
        private void VoucherType()
        {
            LedgerController LController = new LedgerController();
            DataTable dt = LController.SelectVoucherType(int.Parse(SessionClass.UserID.ToString()));
            DrpVoucherType.DataSource = dt;
            DrpVoucherType.DisplayMember = "slash_desc";
            DrpVoucherType.ValueMember = "voucher_type_id";
        }

        /// <summary>
        /// Loads Vouchers To Grid
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnView_Click(object sender, EventArgs e)
        {
            bool _rbtnValue = false;
            if (rbtnPost.Checked)
            {
                _rbtnValue = true;
            }
            LedgerController mController = new LedgerController();
            int mUserID = Constants.IntNullValue;
            if (SessionClass.RoleID.ToString() == "3")
            {
                mUserID = Convert.ToInt32(SessionClass.UserID);
            }
            DataTable dt = mController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), mUserID, _rbtnValue, DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 0);
            GrdLedger.DataSource = dt;
            ArrangeGrid();
        }

        /// <summary>
        /// Shows Voucher in PDF
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">GridViewEditEventArgs</param>
        private void GrdLedger_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GrdLedger.Columns["Edit"].Index)
            {
                DocumentPrintController DPrint = new DocumentPrintController();
                RptAccountController RptAccountCtl = new RptAccountController();
                CORNBusinessLayer.Reports.crpVoucherView CrpReport = new CORNBusinessLayer.Reports.crpVoucherView();

                DataSet ds = null;
                DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
                ds = RptAccountCtl.SelectUnpostVoucherForPrint(int.Parse(drpDistributor.SelectedValue.ToString()), GrdLedger.Rows[e.RowIndex].Cells[0].Value.ToString(), int.Parse(DrpVoucherType.SelectedValue.ToString()));
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
        }

        private void FormReportVoucherView_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 450, 175);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
