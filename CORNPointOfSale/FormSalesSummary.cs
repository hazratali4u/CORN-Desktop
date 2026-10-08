using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormSalesSummary : Form
    {
        public static string _location { get; set; }
        public FormSalesSummary()
        {
            InitializeComponent();
        }

        private void FormSalesSummary_Load(object sender, EventArgs e)
        {
            LoadSummaryData();
            txtDate.Text = "As of " + SessionClass.CurrentWorkDate.ToShortDateString() + "   " + System.DateTime.Now.ToShortTimeString() + "    (User: " + SessionClass.UserName + ")";
        }
        public void LoadSummaryData()
        {
            try
            {
                DataTable dt = new DataTable();
                RptSaleController rptSaleCtl = new RptSaleController();
                if (SessionClass.RoleID == 1)
                {
                    dt = rptSaleCtl.SelectSaleSummary(SessionClass.DISTRIBUTOR_ID, Constants.IntNullValue, DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:0"), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59"), 6, 3);
                }
                else
                {
                    dt = rptSaleCtl.SelectSaleSummary(SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 00:00:0"), DateTime.Parse(SessionClass.CurrentWorkDate.ToShortDateString() + " 23:59:59"), 6, 3);
                }
                lblNoofInvoices.Text = dt.Rows[0].ItemArray[1].ToString();
                lblQuantitysold.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[2]).ToString();
                lblAmountSold.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[3]), 2).ToString();
                lblDiscountAmount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[4]), 2).ToString();
                lblCreditCardAmount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[0]), 2).ToString();
                lblCashRealizationAmount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[7]), 2).ToString();
                lblTax.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[6]), 2).ToString();
                lblAmountInclusiveofTax.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[3]), 2).ToString();
                lblAverageAmountPerInvoice.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[3]) / Convert.ToDecimal(lblNoofInvoices.Text), 2));
                lblCash.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[3]) - Convert.ToDecimal(dt.Rows[0].ItemArray[0]) - Convert.ToDecimal(dt.Rows[0].ItemArray[5]), 2));
                lblCreditAmount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0].ItemArray[5]), 2).ToString();
                lblTotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(lblCash.Text) + Convert.ToDecimal(dt.Rows[0].ItemArray[7]),2));
            }
            catch (Exception)
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int _height = 0;
            string _stringValue;
            //-----------------------Basic Statistics------------------------
            e.Graphics.DrawString(lblHeading.Text, new System.Drawing.Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, 5, _height);
            e.Graphics.DrawString(txtDate.Text, new System.Drawing.Font("Times new roman", 10, FontStyle.Regular), Brushes.Black, 5, _height + 20);
            e.Graphics.DrawString("Location:   " + _location, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 35);
            _height = _height - 20;
            e.Graphics.DrawString(lblBasicStatistics.Text, new System.Drawing.Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, 5, _height + 85);
            e.Graphics.DrawRectangle(Pens.Black, 5, _height + 110, 245, 175);
            e.Graphics.DrawString(" No of Invoices", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 115);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 135, 250, _height + 135);
            e.Graphics.DrawString(" Quantity Sold", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 140);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 160, 250, _height + 160);
            e.Graphics.DrawString(" Net Sale", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 165);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 185, 250, _height + 185);
            e.Graphics.DrawString(" Discount", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 190);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 210, 250, _height + 210);
            e.Graphics.DrawString(" Tax", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 215);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 235, 250, _height + 235);
            e.Graphics.DrawString(" Inclusive of Tax", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 240);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 260, 250, _height + 260);
            e.Graphics.DrawString(" Avg Amount per Inv", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 265);
            //--------------------- Basic statistics Values-------------------
            e.Graphics.DrawLine(Pens.Black, 150, _height + 110, 150, _height + 285);
            _stringValue = lblNoofInvoices.Text;
            e.Graphics.DrawString(lblNoofInvoices.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 115);
            _stringValue = lblQuantitysold.Text;
            e.Graphics.DrawString(lblQuantitysold.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 140);
            _stringValue = lblAmountSold.Text;
            e.Graphics.DrawString(lblAmountSold.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 165);
            _stringValue = lblDiscountAmount.Text;
            e.Graphics.DrawString(lblDiscountAmount.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 190);
            _stringValue = lblTax.Text;
            e.Graphics.DrawString(lblTax.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 215);
            _stringValue = lblAmountInclusiveofTax.Text;
            e.Graphics.DrawString(lblAmountInclusiveofTax.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 240);
            _stringValue = lblAverageAmountPerInvoice.Text;
            e.Graphics.DrawString(lblAverageAmountPerInvoice.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 265);
            //------------------- Calculations---------------------------------
            _height = _height + 20;
            e.Graphics.DrawString(lblCollections.Text, new System.Drawing.Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, 5, _height + 285);
            e.Graphics.DrawRectangle(Pens.Black, 5, _height + 310, 245, 125);
            e.Graphics.DrawString(" Cash", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 315);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 335, 250, _height + 335);
            e.Graphics.DrawString(" Credit Card", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 340);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 360, 250, _height + 360);
            e.Graphics.DrawString(" Credit", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 365);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 385, 250, _height + 385);

            e.Graphics.DrawString(" Cash Realization", new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, 5, _height + 390);
            e.Graphics.DrawLine(Pens.Black, 5, _height + 410, 250, _height + 410);

            e.Graphics.DrawString(" Total Cash In Hand", new System.Drawing.Font("Times new roman", 12, FontStyle.Regular), Brushes.Black, 5, _height + 415);
            e.Graphics.DrawString(".", new System.Drawing.Font("Times new roman", 12, FontStyle.Regular), Brushes.Black, 5, _height + 445);
            //--------------------- Calculations Values-------------------
            e.Graphics.DrawLine(Pens.Black, 150, _height + 310, 150, _height + 410);
            _stringValue = lblCash.Text;
            e.Graphics.DrawString(lblCash.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 315);
            _stringValue = lblCreditCardAmount.Text;
            e.Graphics.DrawString(lblCreditCardAmount.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 340);
            _stringValue = lblCreditAmount.Text;
            e.Graphics.DrawString(lblCreditAmount.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 365);

            _stringValue = lblCashRealizationAmount.Text;
            e.Graphics.DrawString(lblCashRealizationAmount.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 390);

            _stringValue = lblTotal.Text;
            e.Graphics.DrawString(lblTotal.Text, new System.Drawing.Font("Times new roman", 11, FontStyle.Regular), Brushes.Black, PointOfValue(e, _stringValue), _height + 415);
        }


        public int PointOfValue(System.Drawing.Printing.PrintPageEventArgs e, string _string)
        {
            SizeF _stringSize = new System.Drawing.SizeF();
            _stringSize = e.Graphics.MeasureString(_string, new System.Drawing.Font("Times new roman", 12, FontStyle.Regular));
            return 245 - (int)_stringSize.Width;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
