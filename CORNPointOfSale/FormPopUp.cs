using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNCommon.Classes;
using CORNDataAccessLayer.Classes;
using CORNBusinessLayer.Classes;
using CrystalDecisions.Shared;
using System.IO;
using BarcodeLib;

namespace CORNPointOfSale
{
    public partial class FormPopUp : Form
    {
        BarcodeLib.Barcode _barcode = new BarcodeLib.Barcode();
        public string _itemName { get; set; }
        public string _itemCode { get; set; }
        public decimal _itemPrice { get; set; }
        public FormPopUp()
        {
            InitializeComponent();
        }

        private void FormPopUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PrintBarcode();
        }

        private void txtNoOfRows_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PrintBarcode();
            }
        }
        public bool GenerateBarcode()
        {
            try
            {
                _barcode.IncludeLabel = false;
                BarcodeLib.TYPE _type = TYPE.CODE128;
                int code = _itemCode.Length;
                pictureBox2.Image = _barcode.Encode(_type, _itemCode, code * 35, 100);
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error:\n\n" + exc.Message.ToString(), "CORN: POS");
                txtNoOfRows.Focus();
                return false;
            }
        }
        public void PrintBarcode()
        {
            if (!GenerateBarcode())
            {
                this.Close();
                return;
            }
            if (txtNoOfRows.TextLength == 0)
            {
                MessageBox.Show(this, "Please Enter No of Rows", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoOfRows.Focus();
                return;
            }
            SkuController m_ctrl = new SkuController();
            m_ctrl.InsertBarcode(null, _itemName, "Rs. " + _itemPrice, _itemCode, imageToByteArray(pictureBox2.Image));
            SkuController sk = new SkuController();
            DataRow dr;
            DataTable dt = sk.SelectSkuBarcode();
            for (int i = 1; i < int.Parse(txtNoOfRows.Text); i++)
            {
                dr = dt.Rows[0];
                dt.ImportRow(dr);
            }
            //  0 = Invisible , 1 = Visibal , 1 = left , 2 = center , 3 = right
            CORNBusinessLayer.Reports.CrpBarcode CrpReport = new CORNBusinessLayer.Reports.CrpBarcode();
            CrpReport.SetDataSource(dt);
            CrpReport.Refresh();
            //////// Item Name Alignment
            if (true)
            {
                var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
                field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                //
                field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
                field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;

                //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME3"];
                //field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
            }
            //else if (rbtnCenterName.Checked)
            //{
            //    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
            //    //
            //    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;

            //    //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME3"];
            //    //field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
            //}
            //else if (rbtnRightName.Checked)
            //{
            //    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME5"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            //    //
            //    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME2"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;

            //    //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTNAME3"];
            //    //field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            //}
            ///////////  Item Price Alignment
            //if (rbtnLeftPrice.Checked)
            //{
            //    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
            //    //
            //    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;

            //    //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE3"];
            //    //field.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
            //}
            //else if (rbtnCenterPrice.Checked)
            //{
            //    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
            //    //
            //    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;

            //    //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE3"];
            //    //field.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
            //}
            //else if (rbtnRightPrice.Checked)
            //{
            //    var field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE1"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            //    //
            //    field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE2"];
            //    field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            //    //
            //    //field = CrpReport.ReportDefinition.ReportObjects["PRODUCTPRICE3"];
            //    //field.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            //}

            CrpReport.SetParameterValue("NameVisibal", 1);
            CrpReport.SetParameterValue("PriceVisible", 1);
            FormReport _formReport = new FormReport();
            _formReport.crvReportViewer.ReportSource = CrpReport;
            _formReport.ShowDialog();
            this.Close();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception)
            {
                this.Close();
            }
            return null;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
