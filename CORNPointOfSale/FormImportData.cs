using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using System.IO;

namespace CORNPointOfSale
{
    public partial class FormImportData : Form
    {
        public FormImportData()
        {
            InitializeComponent();
        }

      

        private void FormImportData_Load(object sender, EventArgs e)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
        }

        /// <summary>
        /// Loads Locations To Location Combo
        /// </summary>
        private void LoadDistributor()
        {
            DistributorController mController = new DistributorController();
            DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.CompanyID.ToString()));
            DrpDistributor.DataSource = dt;
            DrpDistributor.DisplayMember = "DISTRIBUTOR_NAME";
            DrpDistributor.ValueMember = "DISTRIBUTOR_ID";
        }

        /// <summary>
        /// Loads Towns To Town Combo
        /// </summary>
        //private void LoadTown()
        //{
        //    GeoHierarchyController GControler = new GeoHierarchyController();
        //    DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        //    clsWebFormUtil.FillDropDownList(DrpTown, dt, 0, 4, true);
        //}    

        /// <summary>
        /// Loads Principals To Principal Comb
        /// </summary>
        private void LoadPrincipal()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            DrpPrincipal.DataSource = m_dt;
            DrpPrincipal.DisplayMember = "Company_Name";
            DrpPrincipal.ValueMember = "Company_Id";
        }

        /// <summary>
        /// Imports File Data To Database
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region FileValidation
            if (txtFile.TextLength == 0)
            {
                ToastNotification.Show(this, "Choose a file please", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            #endregion

            //try
            //{
            //if (!Directory.Exists(Constants.fldOtherDataFolder))
            //{
            //    Directory.CreateDirectory(Constants.fldOtherDataFolder);
            //}

            //string path = System.IO.Path.GetFullPath(txtFile.PostedFile.FileName);
            //string filename = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
            //if (File.Exists(Constants.fldOtherDataFolder + filename))
            //{
            //    ToastNotification.Show(this, "File already Exist in folder. Save file with other name", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            //    cboFileTypes.SelectedIndex = 0;
            //    return;
            //}
            //else
            //{
            //    txtFile.PostedFile.SaveAs(Constants.fldOtherDataFolder + filename);
            //    path = Constants.fldOtherDataFolder + filename;
            //    int index = cboFileTypes.SelectedIndex;

            //    if (cboFileTypes.SelectedValue == "3")
            //    {
            //        SkuController SKUCtl = new SkuController();
            //        SKUCtl.ImportSKUS(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(SessionClass.CompanyID.ToString()), Convert.ToInt32(SessionClass.UserID));
            //    }
            //    else if (cboFileTypes.SelectedValue == "4")
            //    {
            //        SKUPriceDetailController SKUPriceCtl = new SKUPriceDetailController();
            //        SKUPriceCtl.ImportSKUPrices(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()));

            //    }
            //    else if (cboFileTypes.SelectedValue == "7")
            //    {
            //        PurchaseController PurCtl = new PurchaseController();
            //        DistributorController DistrCtl = new DistributorController();
            //        DataTable dtDayClose = DistrCtl.MaxDayClose(Convert.ToInt32(DrpDistributor.SelectedValue), 3);
            //        PurCtl.ImportOpeningStock(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()), Convert.ToDateTime(dtDayClose.Rows[0]["DayClose"]), Convert.ToInt32(SessionClass.UserID));
            //    }
            //    else if (cboFileTypes.SelectedValue == "5") //For Purchase
            //    {
            //        PurchaseController PurCtl = new PurchaseController();
            //        DistributorController DistrCtl = new DistributorController();
            //        DataTable dtDayClose = DistrCtl.MaxDayClose(Convert.ToInt32(DrpDistributor.SelectedValue), 3);
            //        PurCtl.ImportPurchaseStock(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()), Convert.ToDateTime(dtDayClose.Rows[0]["DayClose"]), Convert.ToInt32(SessionClass.UserID));
            //    }

            //    ToastNotification.Show(this, "Record insert successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);

            //    this.LoadDistributor();
            //    this.LoadPrincipal();
            //}

            //}
            //catch (Exception excp)
            //{
            //    MessageBox.Show(excp.ToString());
            //    cboFileTypes.SelectedIndex = 0;
            //    return;
            //}
        }

        private void btnChoosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog _dlg = new OpenFileDialog();
            _dlg.Filter = "Text File (.txt)|*.txt";
            _dlg.RestoreDirectory = true;
            if (_dlg.ShowDialog() == DialogResult.OK)
            {
               // txtFile.Text = _dlg.FileName;
            }
            _dlg.ShowDialog();
        }

        private void FormImportData_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 230, 90);
            groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
