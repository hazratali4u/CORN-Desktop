using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class FormShiftClose : Form
    {
        RptSaleController rptSaleCtl = new RptSaleController();
        DataTable dTable;
        int _shiftID = Constants.IntNullValue;
        decimal _diffenrence = 0;
        int Cur5000 = 0;
        int Cur1000 = 0;
        int Cur500 = 0;
        int Cur100 = 0;
        int Cur50 = 0;
        int Cur20 = 0;
        int Cur10 = 0;
        int Cur5 = 0;
        int Cur2 = 0;
        int Cur1 = 0;
        public FormShiftClose()
        {
            InitializeComponent();
        }

        #region Load Functions
        private void FormShiftClose_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadUSER();
            //LoadSales();
        }
        public void ClearFields()
        {
            txtGrossSale.Text = "0";
            txtDiscount.Text = "0";
            txtNetSale.Text = "0";
            txtCreditCardSale.Text = "0";
            txtSalesRefund.Text = "0";
            txtOpeningRecieved.Text = "0";
            txtDifference.Text = "0";
            txtCashRealization.Text = "0";
        }
        public void LoadLocation()
        {
            try
            {
                drpDistributor.DataSource = null;
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
                drpDistributor.DataSource = dt;
                drpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
                drpDistributor.ValueMember = "DISTRIBUTOR_ID";
            }
            catch (Exception)
            {
            }
        }
        private void LoadUSER()
        {
            try
            {
                drpUser.SelectedIndexChanged -= new EventHandler(drpUser_SelectedIndexChanged);
                UserController _mCtrl = new UserController();
                dTable = _mCtrl.SelectShift(Convert.ToInt32(drpDistributor.SelectedValue.ToString()), 12);
                drpUser.DataSource = dTable;
                drpUser.DisplayMember = "USER_NAME";
                drpUser.ValueMember = "USER_ID";
                if (SessionClass.RoleID != 1)
                {
                    drpUser.Enabled = false;
                    drpUser.SelectedValue = SessionClass.UserID;
                }
                else
                {
                    drpUser.Enabled = true;
                }
                drpUser.SelectedIndexChanged += new EventHandler(drpUser_SelectedIndexChanged);
                drpUser_SelectedIndexChanged(null, null);
            }
            catch (Exception)
            {
            }
        }
        private void drpUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGrossSale.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtNetSale.Text = "0.00";
            txtCreditCardSale.Text = "0.00";
            txtCashInHand.Text = "0.00";
            txtCashRealization.Text = "0.00";
            txtDifference.Text = "0";
            if (drpUser.DisplayMember == "USER_NAME" && drpUser.ValueMember == "USER_ID")
            {
                DataRow[] dr;
                dr = dTable.Select("USER_ID = '" + Convert.ToInt32(drpUser.SelectedValue.ToString()) + "'");
                txtShift.Text = dr[0].ItemArray[3].ToString();
                _shiftID = Convert.ToInt32(dr[0].ItemArray[2].ToString());
                txtShiftID.Text = _shiftID.ToString();
                LoadSales();
            }
        }
        private void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistributor.DisplayMember == "DISTRIBUTOR_NAME" && drpDistributor.ValueMember == "DISTRIBUTOR_ID")
            {
                LoadUSER();
            }
        }
        public void LoadSales()
        {
            ClearFields();
            DataTable dt2 = rptSaleCtl.SelectSales(Convert.ToInt32(drpDistributor.SelectedValue.ToString()), Convert.ToInt32(drpUser.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:00"), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59"), 4, Convert.ToInt32(txtShiftID.Text));
            txtSalesRefund.Text = Math.Round(Convert.ToDecimal(dt2.Rows[0].ItemArray[0]), 2).ToString();
            DataTable dt = rptSaleCtl.SelectSales(Convert.ToInt32(drpDistributor.SelectedValue.ToString()), Convert.ToInt32(drpUser.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:00"), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59"), 3, Convert.ToInt32(txtShiftID.Text));
            GetOpeningCash();
            GetShiftOpeningAmount();
            try
            {
                if (dt.Rows[0].ItemArray[2] != DBNull.Value)
                {
                    txtGrossSale.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[2]), 2).ToString();
                    txtDiscount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[1]), 2).ToString();
                    txtNetSale.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[4]), 2).ToString();
                    //txtNetSale.Text = (Math.Round(DataControl.chkDecimalZero(txtOpeningRecieved.Text) + DataControl.chkDecimalZero(txtOpeningCash.Text) + DataControl.chkDecimalZero(txtGrossSale.Text) - DataControl.chkDecimalZero(txtDiscount.Text) - DataControl.chkDecimalZero(txtSalesRefund.Text), 2)).ToString();
                    txtCreditCardSale.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[3]), 2).ToString();
                    txtCreditAmount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[5]), 2).ToString();
                    txtCashRealization.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[6]), 2).ToString();
                    txtCashInHand.Text = (DataControl.chkDecimalZero(txtOpeningRecieved.Text) + DataControl.chkDecimalZero(txtOpeningCash.Text) + DataControl.chkDecimalZero(txtNetSale.Text) - DataControl.chkDecimalZero(txtCreditCardSale.Text) - DataControl.chkDecimalZero(txtCreditAmount.Text) + DataControl.chkDecimalZero(txtCashRealization.Text)).ToString();
                    dt = rptSaleCtl.SelectSales(SessionClass.DISTRIBUTOR_ID, Convert.ToInt32(drpUser.SelectedValue.ToString()), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:00"), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59"), 4, Convert.ToInt32(txtShiftID.Text));
                    txtSalesRefund.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[0]), 2).ToString();
                }

            }
            catch (Exception)
            {
                txtCashInHand.Text = (DataControl.chkDecimalZero(txtOpeningRecieved.Text) + DataControl.chkDecimalZero(txtOpeningCash.Text)).ToString();
            }
        }
        public void GetOpeningCash()
        {
            DateTime _startDate = DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:00");
            DateTime _endDate = DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59");
            DataTable dt2 = rptSaleCtl.SelectSales(Constants.IntNullValue, Convert.ToInt32(drpUser.SelectedValue.ToString()), _startDate.AddDays(-1), _endDate.AddDays(-1), 5, Constants.IntNullValue);
            if (dt2.Rows.Count > 0)
            {
                txtOpeningCash.Text = Math.Round(Convert.ToDecimal(dt2.Rows[0].ItemArray[0]), 2).ToString();
            }
            else
            {
                txtOpeningCash.Text = "0";
            }
        }
        public void GetShiftOpeningAmount()
        {
            DateTime _startDate = DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:00");
            DateTime _endDate = DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59");
            DataTable dt2 = rptSaleCtl.SelectSales(Constants.IntNullValue, Convert.ToInt32(drpUser.SelectedValue.ToString()), _startDate, _endDate, 51, Constants.IntNullValue);
            if (dt2.Rows.Count > 0)
            {
                txtOpeningRecieved.Text = Math.Round(Convert.ToDecimal(dt2.Rows[0].ItemArray[0]), 2).ToString();
            }
            else
            {
                txtOpeningCash.Text = "0";
            }
        }
        #endregion

        #region BUTTON SHIFT CLOSE
        private void btnShiftClose_Click(object sender, EventArgs e)
        {
            if (drpUser.Items.Count == 0)
            {
                MessageBox.Show(this, "Please Select User", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTotal.TextLength == 0)
            {
                MessageBox.Show(this, "Please Enter Denomination", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetCurrencyQuantity();
            ShiftController mController = new ShiftController();
            DataTable dtClosedShifts = rptSaleCtl.SelectSales(Constants.IntNullValue, Convert.ToInt32(drpUser.SelectedValue.ToString()), SessionClass.CurrentWorkDate, Constants.DateNullValue, 7, _shiftID);
            if (dtClosedShifts.Rows.Count > 0)
            {
                MessageBox.Show(this, "Shift Already Closed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool _result = mController.InsertShiftClose(Convert.ToInt32(drpDistributor.SelectedValue.ToString()), _shiftID, Convert.ToInt32(drpUser.SelectedValue.ToString()), System.DateTime.Now, Cur5000, Cur1000, Cur500, Cur100, Cur50, Cur20, Cur10, Cur5, Cur2, Cur1, Convert.ToDecimal(txtTotal.Text), DataControl.chkDecimalNull(txtOpeningCash.Text), Convert.ToDecimal(txtDifference.Text), SessionClass.CurrentWorkDate);
            if (_result)
            {
                ToastNotification.Show(this, "Shift Closed Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                ClearControlles();
                LoadSales();
            }
        }
        #endregion

        #region Common Functions
        private void txt5000_TextChanged(object sender, EventArgs e)
        {
            if (txt5000.TextLength <= 0)
            {
                txt5000.Text = "0";
                return;
            }
            txtCal5000.Text = (5000 * Convert.ToInt32(txt5000.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt1000_TextChanged(object sender, EventArgs e)
        {
            if (txt1000.TextLength <= 0)
            {
                txt1000.Text = "0";
                return;
            }
            txtCal1000.Text = (1000 * Convert.ToInt32(txt1000.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt500_TextChanged(object sender, EventArgs e)
        {
            if (txt500.TextLength <= 0)
            {
                txt500.Text = "0";
                return;
            }
            txtCal500.Text = (500 * Convert.ToInt32(txt500.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt20_TextChanged(object sender, EventArgs e)
        {
            if (txt20.TextLength <= 0)
            {
                txt20.Text = "0";
                return;
            }
            txtCal20.Text = (20 * Convert.ToInt32(txt20.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt50_TextChanged(object sender, EventArgs e)
        {
            if (txt50.TextLength <= 0)
            {
                txt50.Text = "0";
                return;
            }
            txtCal50.Text = (50 * Convert.ToInt32(txt50.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt100_TextChanged(object sender, EventArgs e)
        {
            if (txt100.TextLength <= 0)
            {
                txt100.Text = "0";
                return;
            }
            txtCal100.Text = (100 * Convert.ToInt32(txt100.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt10_TextChanged(object sender, EventArgs e)
        {
            if (txt10.TextLength <= 0)
            {
                txt10.Text = "0";
                return;
            }
            txtCal10.Text = (10 * Convert.ToInt32(txt10.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (txt5.TextLength <= 0)
            {
                txt5.Text = "0";
                return;
            }
            txtCal5.Text = (5 * Convert.ToInt32(txt5.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (txt2.TextLength <= 0)
            {
                txt2.Text = "0";
                return;
            }
            txtCal2.Text = (2 * Convert.ToInt32(txt2.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.TextLength <= 0)
            {
                txt1.Text = "0";
                return;
            }
            txtCal1.Text = (1 * Convert.ToInt32(txt1.Text)).ToString();
            CalculateTotalDenomination();
        }
        private void txt5000_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }
        private void txtCashSubmitted_TextChanged(object sender, EventArgs e)
        {
            CalculateDifference();
        }
        public void ClearControlles()
        {
            txt5000.Text = "0";
            txt1000.Text = "0";
            txt500.Text = "0";
            txt100.Text = "0";
            txt50.Text = "0";
            txt20.Text = "0";
            txt10.Text = "0";
            txt5.Text = "0";
            txt2.Text = "0";
            txt1.Text = "0";
        }
        #endregion

        #region Calculations
        public void CalculateTotalDenomination()
        {
            try
            {
                txtTotal.Text = (Convert.ToInt32(txtCal5000.Text) + Convert.ToInt32(txtCal1000.Text) + Convert.ToInt32(txtCal500.Text) + Convert.ToInt32(txtCal100.Text) + Convert.ToInt32(txtCal50.Text) + Convert.ToInt32(txtCal20.Text) + Convert.ToInt32(txtCal10.Text) + Convert.ToInt32(txtCal5.Text) + Convert.ToInt32(txtCal2.Text) + Convert.ToInt32(txtCal1.Text)).ToString();
                txtCashSubmitted.Text = txtTotal.Text;
                CalculateDifference();
            }
            catch (Exception)
            {
            }
        }
        public void CalculateDifference()
        {
            if (txtCashSubmitted.TextLength > 0)
            {
                //_diffenrence = Convert.ToDecimal(txtNetSale.Text) - Convert.ToDecimal(txtCashInHand.Text);
                //_diffenrence = _diffenrence + (Convert.ToDecimal(txtCashInHand.Text) - Convert.ToDecimal(txtCashSubmitted.Text));
                //txtDifference.Text = _diffenrence.ToString();
                txtDifference.Text = (Convert.ToDecimal(DataControl.chkDecimalNull(txtCashInHand.Text)) - Convert.ToDecimal(DataControl.chkDecimalNull(txtCashSubmitted.Text))).ToString();
            }
        }
        public void GetCurrencyQuantity()
        {
            if (txt5000.TextLength > 0)
            {
                Cur5000 = Convert.ToInt32(txt5000.Text);
            }
            if (txt1000.TextLength > 0)
            {
                Cur1000 = Convert.ToInt32(txt1000.Text);
            }
            if (txt500.TextLength > 0)
            {
                Cur500 = Convert.ToInt32(txt500.Text);
            }
            if (txt100.TextLength > 0)
            {
                Cur100 = Convert.ToInt32(txt100.Text);
            }
            if (txt50.TextLength > 0)
            {
                Cur50 = Convert.ToInt32(txt50.Text);
            }
            if (txt20.TextLength > 0)
            {
                Cur20 = Convert.ToInt32(txt20.Text);
            }
            if (txt10.TextLength > 0)
            {
                Cur10 = Convert.ToInt32(txt10.Text);
            }
            if (txt5.TextLength > 0)
            {
                Cur5 = Convert.ToInt32(txt5.Text);
            }
            if (txt2.TextLength > 0)
            {
                Cur2 = Convert.ToInt32(txt2.Text);
            }
            if (txt1.TextLength > 0)
            {
                Cur1 = Convert.ToInt32(txt1.Text);
            }
        }
        #endregion

        private void FormShiftClose_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 500, 300);
            groupPanel1.Location = new Point(points[0], points[1]);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CORNBusinessLayer.Reports.CrpShiftClose CrpReport = new CORNBusinessLayer.Reports.CrpShiftClose();
            CrpReport.Refresh();

            CrpReport.SetParameterValue("LOCATION", drpDistributor.Text.ToString());
            CrpReport.SetParameterValue("FROM_DATE", SessionClass.CurrentWorkDate.ToShortDateString());
            CrpReport.SetParameterValue("UserName", drpUser.Text.ToString());
            CrpReport.SetParameterValue("Shift", txtShift.Text);
            CrpReport.SetParameterValue("OpeningCashRecieved", txtOpeningRecieved.Text);
            CrpReport.SetParameterValue("OpeningBalance", txtOpeningCash.Text);
            CrpReport.SetParameterValue("GrossSale", txtGrossSale.Text);
            CrpReport.SetParameterValue("Discount", txtDiscount.Text);
            CrpReport.SetParameterValue("SalesRefund", txtSalesRefund.Text);
            CrpReport.SetParameterValue("NetSales", txtNetSale.Text);
            CrpReport.SetParameterValue("CreditCardSale", txtCreditCardSale.Text);
            CrpReport.SetParameterValue("CreditAmount", txtCreditAmount.Text);
            CrpReport.SetParameterValue("CashRealization", txtCashRealization.Text);
            CrpReport.SetParameterValue("CashInHand", txtCashInHand.Text);
            CrpReport.SetParameterValue("CashSubmitted", txtCashSubmitted.Text);
            CrpReport.SetParameterValue("Difference", txtDifference.Text);
            CrpReport.SetParameterValue("5000", Convert.ToInt32(DataControl.chkNull_Zero(txt5000.Text)));
            CrpReport.SetParameterValue("1000", Convert.ToInt32(DataControl.chkNull_Zero(txt1000.Text)));
            CrpReport.SetParameterValue("500", Convert.ToInt32(DataControl.chkNull_Zero(txt500.Text)));
            CrpReport.SetParameterValue("100", Convert.ToInt32(DataControl.chkNull_Zero(txt100.Text)));
            CrpReport.SetParameterValue("50", Convert.ToInt32(DataControl.chkNull_Zero(txt50.Text)));
            CrpReport.SetParameterValue("20", Convert.ToInt32(DataControl.chkNull_Zero(txt20.Text)));
            CrpReport.SetParameterValue("10", Convert.ToInt32(DataControl.chkNull_Zero(txt10.Text)));
            CrpReport.SetParameterValue("5", Convert.ToInt32(DataControl.chkNull_Zero(txt5.Text)));
            CrpReport.SetParameterValue("2", Convert.ToInt32(DataControl.chkNull_Zero(txt2.Text)));
            CrpReport.SetParameterValue("1", Convert.ToInt32(DataControl.chkNull_Zero(txt1.Text)));
            CrpReport.SetParameterValue("Denomination", txtTotal.Text);
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
        }
    }
}
