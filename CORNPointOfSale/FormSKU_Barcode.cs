using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using CrystalDecisions.Shared;
using BarcodeLib;
using System.IO;

namespace CORNPointOfSale
{
    public partial class FormSKU_Barcode : Form
    {
        DataTable Dtsku_Price;
        int _NameAlign = 1;
        int _PriceAlign = 1;
        int _NameVisible = 1;
        int _PriceVisible = 1;
        BarcodeLib.Barcode _barcode = new BarcodeLib.Barcode();
        public FormSKU_Barcode()
        {
            InitializeComponent();
        }

        private void FormSKU_Barcode_Load(object sender, EventArgs e)
        {
            //LoadProducts();
            txtSKUName.Focus();
            ddlSheetSelection.SelectedIndex = 0;
        }

        public void LoadProducts()
        {
            txtSKUName.Text = "Loading...";
            txtSKUName.Enabled = false;
            SkuController SKUCtl = new SkuController();
            Dtsku_Price = SKUCtl.SearchProduct(null, 4, SessionClass.DISTRIBUTOR_ID);
            BindProducts(0);
            txtSKUName.Text = "";
            txtSKUName.Enabled = true;
        }

        private void BindProducts(int typeid)
        {
            try
            {
                AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
                if (typeid == 0)
                {
                    foreach (DataRow dr in Dtsku_Price.Rows)
                    {
                        acsc.Add(dr["SkuDetail"].ToString());
                    }
                }
                if (typeid == 1)
                {
                    foreach (DataRow dr in Dtsku_Price.Rows)
                    {
                        acsc.Add(dr["SkuDetail1"].ToString());
                    }
                }
                txtSKUName.AutoCompleteCustomSource = acsc;
                txtSKUName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSKUName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LoadProducts");
                ExceptionPublisher.PublishException(ex);
            }
        }

        private void txtskuCode_KeyUp(object sender, KeyEventArgs e)
        {
            DataControl dc = new DataControl();
            if (e.KeyCode == Keys.Enter)
            {
                txtSkuCode.Text = "";
                if (txtSKUName.Text.Trim().Length > 0)
                {
                    string SelectedText = txtSKUName.Text.Trim();
                    if (SelectedText.Contains("-"))
                    {
                        txtSkuCode.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));

                        if (SelectedText.Contains(":"))
                        {
                            txtSKUName.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                            //if (SelectedText.Contains("["))
                            //{
                            //    txtSkuPrice.Text = SelectedText.Substring(SelectedText.IndexOf(":") + 1, SelectedText.IndexOf("[") - SelectedText.IndexOf(":") - 1);
                            //    txtSKUName.Focus();
                            //}
                            if (true)
                            {
                                txtSkuPrice.Text = SelectedText.Substring(SelectedText.IndexOf(":") + 1);
                                txtSKUName.Focus();
                            }
                        }
                        if (chkByName.Checked)
                        {
                            txtSkuCode.Text = SelectedText.Substring(SelectedText.IndexOf("-") + 1, SelectedText.IndexOf(":") - SelectedText.IndexOf("-") - 1);
                            txtSKUName.Text = SelectedText.Substring(0, SelectedText.IndexOf('-'));
                        }
                    }
                    else
                    {
                        DataRow[] dr = Dtsku_Price.Select("SKU_CODE = '" + txtSKUName.Text + "' ");
                        if (dr.Length > 0)
                        {
                            txtSKUName.Text = dr[0][2].ToString() + "_" + dr[0][6].ToString();
                            txtSkuCode.Text = dr[0][1].ToString();
                            txtSkuPrice.Text = Math.Round(Convert.ToDecimal(dr[0][4].ToString()), 2).ToString();
                        }
                        //foreach (DataRow dr in Dtsku_Price.Rows)
                        //{
                        //    if (dr["SKU_CODE"].ToString() == txtSKUName.Text.Trim())
                        //    {
                        //        txtSkuCode.Text = dr["SKU_CODE"].ToString().Trim();
                        //        txtSKUName.Text = dr["SKU_NAME"].ToString();
                        //        txtSkuPrice.Text = dr["TRADE_PRICE"].ToString();
                        //        txtSKUName.Focus();
                        //        break;
                        //    }
                        //}
                    }
                }
                if (txtSkuCode.TextLength > 0)
                {
                    SetBarcodeLabe();
                    GenerateBarcode();
                }
                else
                {
                    txtSkuPrice.Text = "";
                    lblBarcode.Text = "";
                    lblItem.Text = "";
                    lblPrice.Text = "";
                }
            }
        }

        public void SetBarcodeLabe()
        {
            ChkItemName_CheckedChanged(null, null);
            ChkItemPrice_CheckedChanged(null, null);

            if (rbtnLeftName.Checked)
            {
                lblItem.TextAlign = ContentAlignment.MiddleLeft;
                _NameAlign = 1;
            }
            else if (rbtnCenterName.Checked)
            {
                lblItem.TextAlign = ContentAlignment.MiddleCenter;
                _NameAlign = 2;
            }
            else if (rbtnRightName.Checked)
            {
                lblItem.TextAlign = ContentAlignment.MiddleRight;
                _NameAlign = 3;
            }
            ////
            if (rbtnLeftPrice.Checked)
            {
                lblPrice.TextAlign = ContentAlignment.MiddleLeft;
                _PriceAlign = 1;
            }
            else if (rbtnCenterPrice.Checked)
            {
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;
                _PriceAlign = 2;
            }
            else if (rbtnRightPrice.Checked)
            {
                lblPrice.TextAlign = ContentAlignment.MiddleRight;
                _PriceAlign = 3;
            }
            lblBarcode.Text = "*" + txtSkuCode.Text + "*";
            lblItem.Text = txtSKUName.Text;
            lblBarcode.Font = new System.Drawing.Font("IDAutomationHC39M Free Version", 12, FontStyle.Regular);
            lblPrice.Text = "Rs." + txtSkuPrice.Text;
        }

        private void txtNoOfRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void rbtnLeftName_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSkuCode.TextLength > 0)
            {
                SetBarcodeLabe();
            }
        }

        private void ChkItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkItemName.Checked)
            {
                lblItem.Visible = true;
                _NameVisible = 1;
            }
            else
            {
                lblItem.Visible = false;
                _NameVisible = 0;
            }
        }

        private void ChkItemPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkItemPrice.Checked)
            {
                lblPrice.Visible = true;
                _PriceVisible = 1;
            }
            else
            {
                lblPrice.Visible = false;
                _PriceVisible = 0;
            }
        }

        public void ConvertToImage(byte[] iBinary)
        {
            //byte[] data = iBinary;
            //MemoryStream ms = new MemoryStream(data);
            //pictureBox3.Image = Image.FromStream(ms);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtSkuCode.TextLength == 0)
            {
                MessageBox.Show(this, "Please Select Item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSKUName.Focus();
                return;
            }
            if (txtNoOfRows.TextLength == 0)
            {
                MessageBox.Show(this, "Please give No of Rows", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoOfRows.Focus();
                return;
            }

            SkuController m_ctrl = new SkuController();
            m_ctrl.InsertBarcode(SessionClass.CompanyName, txtSKUName.Text, "Rs. " + txtSkuPrice.Text, txtSkuCode.Text, imageToByteArray(pictureBox2.Image));
            SkuController sk = new SkuController();
            DataRow dr;
            DataTable dt = sk.SelectSkuBarcode();
            for (int i = 1; i < int.Parse(txtNoOfRows.Text); i++)
            {
                dr = dt.Rows[0];
                dt.ImportRow(dr);
            }


            if (ddlSheetSelection.SelectedIndex == 0)
            {
                //  0 = Invisible , 1 = Visibal , 1 = left , 2 = center , 3 = right
                CORNBusinessLayer.Reports.CrpBarcodeSingle CrpReport = new CORNBusinessLayer.Reports.CrpBarcodeSingle();
                CrpReport.SetDataSource(dt);
                CrpReport.Refresh();
                //////// Item Name Alignment
                if (rbtnLeftName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbtnCenterName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                else if (rbtnRightName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                /////////  Item Price Alignment
                if (rbtnLeftPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbtnCenterPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                else if (rbtnRightPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }

                /////////  Company Alignment
                if (rbCompanyRight.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                else if (rbCompanyLeft.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbCompanyCenter.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }

                CrpReport.SetParameterValue("NameVisibal", _NameVisible);
                CrpReport.SetParameterValue("PriceVisible", _PriceVisible);
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
            else
            {
                //  0 = Invisible , 1 = Visibal , 1 = left , 2 = center , 3 = right
                CORNBusinessLayer.Reports.CrpBarcode CrpReport = new CORNBusinessLayer.Reports.CrpBarcode();
                CrpReport.SetDataSource(dt);
                CrpReport.Refresh();
                //////// Item Name Alignment
                if (rbtnLeftName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbtnCenterName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                else if (rbtnRightName.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                /////////  Item Price Alignment
                if (rbtnLeftPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbtnCenterPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                else if (rbtnRightPrice.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }

                /////////  Company Alignment
                if (rbCompanyRight.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                else if (rbCompanyLeft.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (rbCompanyCenter.Checked)
                {
                    var field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME2"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    //
                    field = CrpReport.ReportDefinition.ReportObjects["COMPANYNAME1"];
                    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                CrpReport.SetParameterValue("NameVisibal", _NameVisible);
                CrpReport.SetParameterValue("PriceVisible", _PriceVisible);
                FormReport _formReport = new FormReport();
                _formReport.crvReportViewer.ReportSource = CrpReport;
                _formReport.ShowDialog();
            }
        }

        private void FormSKU_Barcode_Shown(object sender, EventArgs e)
        {
            LoadProducts();
            txtSKUName.Focus();
        }

        private void FormSKU_Barcode_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 425, 165);
            groupPanel2.Location = new Point(points[0], points[1]);
        }

        public void GenerateBarcode()
        {
            try
            {
                _barcode.IncludeLabel = false;
                BarcodeLib.TYPE _type = TYPE.CODE128;
                int code = txtSkuCode.TextLength;
                pictureBox2.Image = _barcode.Encode(_type, txtSkuCode.Text, code * 35, 100);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error:\n\n" + exc.Message.ToString(), "CORN: POS");
                txtSkuCode.Text = "";
                txtSKUName.Text = "";
                txtSkuPrice.Text = "";
                txtSkuCode.Focus();
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void chkByName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkByName.Checked == false)
            {
                BindProducts(0);    //  by code
            }
            else
            {
                BindProducts(1);    // by name
            }
            txtSKUName.Focus();
        }

        //public string ConcatinateCode(string _code)
        //{
        //    int _length = 13 - (_code.Length);
        //    for (int i = 0; i < _length; i++)
        //    {
        //        _code = "0" + _code;
        //    }
        //    return _code;
        //}
    }
}
