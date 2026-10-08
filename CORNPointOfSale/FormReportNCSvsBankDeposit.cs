using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormReportNCSvsBankDeposit : Form
    {
        public static string _reportHeader { get; set; }
        public FormReportNCSvsBankDeposit()
        {
            InitializeComponent();
        }

        private void FormReportInputs_Load(object sender, EventArgs e)
        {
            txtToDate.Value = SessionClass.CurrentWorkDate;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormReport _frmreports = new FormReport();
            _frmreports.NCSVsBankDeposit(txtToDate.Value);
            _frmreports.ShowDialog();
        }

        private void FormReportNCSvsBankDeposit_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 215, 80);
            groupPanel1.Location = new Point(points[0],points[1]);
        }
    }
}
