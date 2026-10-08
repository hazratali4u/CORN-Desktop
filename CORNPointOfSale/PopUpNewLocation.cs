using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CORNCommon.Classes;
using CORNBusinessLayer.Classes;
using CORNDataAccessLayer.Classes;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace CORNPointOfSale
{
    public partial class PopUpNewLocation : Form
    {
        DistributorController mController = new DistributorController();
        byte[] imageData = null;
        public PopUpNewLocation()
        {
            InitializeComponent();
            //Delete all dummy logos
            try
            {
                if (Directory.Exists(Application.StartupPath + @"\DummyLogos"))
                {
                    DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\DummyLogos");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                //Do nothing
            }
        }

        #region Form Events

        private void chkIsRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsRegister.Checked)
            {
                txtGst.Enabled = true;
                txtGst.Focus();
            }
            else
            {
                txtGst.Text = "";
                txtGst.Enabled = false;
            }
        }
        private void btnClosePopUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            ClearAll();
            this.Close();
        }
        #endregion

        #region Load Functions

        private void PopUpAddNewLocation_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
            this.GetDistributorType();
            this.LoadCompany();
        }
        private void LoadCompany()
        {
            CompanyController mCompany = new CompanyController();
            DataTable dt = mCompany.SelectCompany(Constants.IntNullValue, Constants.IntNullValue);
            //clsWebFormUtil.FillDropDownList(DrpCompanyName, dt, 0, 1, true);
            //clsWindowsFormUtil.FillComboBox(cboxCompany, dt, 0, 1, true);

            cboxCompany.DataSource = dt;
            cboxCompany.DisplayMember = "COMPANY_NAME";
            cboxCompany.ValueMember = "COMPANY_ID";
        }
        private void GetDistributorType()
        {
            DataTable dt = mController.SelectDistributorTypeInfo(Constants.IntNullValue);
            //clsWebFormUtil.FillDropDownList(cboxLocationType, dt, 0, 2);
            //clsWindowsFormUtil.FillComboBox(cboxLocationType, dt, 0, 2, true);

            cboxCompany.Items.Clear();
            cboxLocationType.DataSource = dt;
            cboxLocationType.DisplayMember = "TYPENAME";
            cboxLocationType.ValueMember = "DISTRIBUTOR_TYPE_ID";
        }

        #endregion

        #region Clear All Fields
        private void ClearAll()
        {
            txtDistributorName.Text = "";
            txtDistributorCode.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtPhoneNo.Text = "";
            txtGst.Text = "";
            btnSave.Text = "Save";
            chkIsRegister.Checked = false;
            chkShowLogo.Checked = false;
            //chkIsManualDiscount.Checked = false;
        }
        #endregion

        #region Save New Location
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cboxCompany.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Company", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (cboxLocationType.SelectedIndex < 0)
            {
                ToastNotification.Show(this, "Please Select Location Type", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (txtAddress.Text != string.Empty && txtDistributorName.Text != string.Empty)
            {
                Save_UpdateLocation();
            }
            else
            {
                ToastNotification.Show(this, "Please Enter Distributor Name and Address", CORNPointOfSale.Properties.Resources.cross, 1500, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        public void Save_UpdateLocation()
        {
            int DiscountStatus = 0;//Credit level as discount status
            int Deliveryman = 0;
            //if (chkIsManualDiscount.Checked)
            //{
            //    DiscountStatus = 1;
            //}
            if (imgLogo.Image == null)
            {
                //imageData = ReadFile(Application.StartupPath + @"\InvLogo1.png");
            }
            if (chkDeliveryman.Checked)
            {
                Deliveryman = 1;
            }
            if (imageData == null && chkShowLogo.Checked == true)
            {
                MessageBox.Show("Please Select Logo or uncheck Show Invoice Logo.", "CORN: POS");
                return;
            }
            if (btnSave.Text == "Save")
            {
                try
                {
                    if (chkIsRegister.Checked == true)
                    {
                        string result = mController.InsertDistributor(Convert.ToInt32(cboxCompany.SelectedValue), Deliveryman, !chkIsActive.Checked, System.DateTime.Now, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                                                   , Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxLocationType.SelectedValue), txtContactPerson.Text, txtPhoneNo.Text, txtGst.Text,
                                                    null, txtAddress.Text, txtEmailAddress.Text, txtDistributorCode.Text, txtDistributorName.Text, null, true, DiscountStatus, Constants.IntNullValue, imageData, chkShowLogo.Checked);
                        if (result != null)
                        {
                            SessionClass.ShowDeliveryman = Deliveryman;
                            SessionClass.ShowLogo = chkShowLogo.Checked;
                        }
                    }
                    else
                    {
                        string result = mController.InsertDistributor(Convert.ToInt32(cboxCompany.SelectedValue), Deliveryman, !chkIsActive.Checked, System.DateTime.Now, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                                                , Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxLocationType.SelectedValue), txtContactPerson.Text, txtPhoneNo.Text, "",
                                                 null, txtAddress.Text, txtEmailAddress.Text, txtDistributorCode.Text, txtDistributorName.Text, null, false, DiscountStatus, Constants.IntNullValue, imageData, chkShowLogo.Checked);
                        if (result != null)
                        {
                            SessionClass.ShowDeliveryman = Deliveryman;
                            SessionClass.ShowLogo = chkShowLogo.Checked;
                        }
                    }
                    ClearAll();
                    this.Close();
                    Form _formNewLocation = Application.OpenForms["FormNewLocation2"];
                    ToastNotification.Show(_formNewLocation, "Added Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    FormNewLocation2 _form = Application.OpenForms["FormNewLocation2"] as FormNewLocation2;
                    _form.RefreshGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    if (chkIsRegister.Checked == true)
                    {
                        string result = mController.UpdateDistributor(Convert.ToInt32(cboxCompany.SelectedValue), Deliveryman, !chkIsActive.Checked, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                             , Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxLocationType.SelectedValue), txtContactPerson.Text, txtPhoneNo.Text, txtGst.Text,
                              null, txtAddress.Text, txtEmailAddress.Text, NewLocationProperties._distributorId, txtDistributorCode.Text, txtDistributorName.Text, null, true, DiscountStatus, Constants.IntNullValue, imageData, 1, chkShowLogo.Checked);
                        if (result != null)
                        {
                            SessionClass.ShowDeliveryman = Deliveryman;
                            SessionClass.ShowLogo = chkShowLogo.Checked;
                        }
                    }
                    else
                    {
                        string result = mController.UpdateDistributor(Convert.ToInt32(cboxCompany.SelectedValue), Deliveryman, !chkIsActive.Checked, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                            , Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(cboxLocationType.SelectedValue), txtContactPerson.Text, txtPhoneNo.Text, "",
                             null, txtAddress.Text, txtEmailAddress.Text, NewLocationProperties._distributorId, txtDistributorCode.Text, txtDistributorName.Text, null, false, DiscountStatus, Constants.IntNullValue, imageData, 1, chkShowLogo.Checked);
                        if (result != null)
                        {
                            SessionClass.ShowDeliveryman = Deliveryman;
                            SessionClass.ShowLogo = chkShowLogo.Checked;
                        }
                    }
                    ClearAll();
                    this.Close();
                    Form _formNewLocation = Application.OpenForms["FormNewLocation2"];
                    ToastNotification.Show(_formNewLocation, "Updated Successfully", CORNPointOfSale.Properties.Resources.Tick, 1500, eToastGlowColor.Blue, eToastPosition.MiddleCenter);
                    FormNewLocation2 _form = Application.OpenForms["FormNewLocation2"] as FormNewLocation2;
                    _form.RefreshGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n" + ex.Message);
                }
            }
        }
        #endregion

        #region PopUpNewLocation Form Shown Event
        private void PopUpNewLocation_Shown(object sender, EventArgs e)
        {
            if (NewLocationProperties._newOrEdit == "Edit")
            {
                cboxCompany.SelectedValue = NewLocationProperties._companyName;
                cboxLocationType.SelectedIndex = cboxLocationType.FindString(NewLocationProperties._distributorType);
                txtDistributorCode.Text = NewLocationProperties._distributorCode;
                txtDistributorName.Text = NewLocationProperties._distributorName;
                txtContactPerson.Text = NewLocationProperties._contactPerson;
                txtPhoneNo.Text = NewLocationProperties._phoneNo;
                txtEmailAddress.Text = NewLocationProperties._emailAddress;
                txtAddress.Text = NewLocationProperties._address;
                chkIsRegister.Checked = NewLocationProperties._isRegistered;
                chkDeliveryman.Checked = NewLocationProperties._Deliveryman;
                chkShowLogo.Checked = NewLocationProperties._ShowLogo;
                if (NewLocationProperties._gstNo == null || NewLocationProperties._gstNo == "")
                {
                    chkIsRegister.Checked = false;
                }
                else
                {
                    chkIsRegister.Checked = true;
                    txtGst.Text = NewLocationProperties._gstNo;
                }
                if (NewLocationProperties._isActive == "Active")
                {
                    chkIsActive.Checked = true;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                try
                {
                    imgLogo.Image = (byteArrayToImage(NewLocationProperties._Logo));
                    imageData = NewLocationProperties._Logo;
                }
                catch (Exception)
                {
                }
                btnSave.Text = "Update";
            }
            else if (NewLocationProperties._newOrEdit == "New")
            {
                ClearFields();
            }
        }
        #endregion

        #region ClearFields
        public void ClearFields()
        {
            txtDistributorName.Text = "";
            txtDistributorCode.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtPhoneNo.Text = "";
            txtGst.Text = "";
            btnSave.Text = "Save";
            chkIsRegister.Checked = false;
        }
        #endregion

        private void imgLogo_Click(object sender, EventArgs e)
        {
            imgLogo.Image = null;
            string strLogoName = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            if(!Directory.Exists(Application.StartupPath + @"\DummyLogos"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\DummyLogos");
            }
            try
            {  
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Logo";
                dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    Bitmap img = new Bitmap(dlg.FileName);
                    int imageHeight = Convert.ToInt32(img.Height);
                    int imageWidth = Convert.ToInt32(img.Width);
                    if (imageHeight >= 100 && imageWidth >= 100)
                    {
                        var fileName = dlg.FileName;
                        string ext = Path.GetExtension(dlg.FileName);
                        string imgName = Path.GetFileNameWithoutExtension(fileName);

                        using (var image = Image.FromFile(fileName))
                        using (var newImage = ScaleImage(image, 60, 70))
                        {
                            newImage.Save(Application.StartupPath + @"\DummyLogos\" + strLogoName + ".png");
                        }
                        imgLogo.Image = Image.FromFile(Application.StartupPath + @"\DummyLogos\" + strLogoName + ".png");
                        //Save to db
                        imageData = ReadFile(Application.StartupPath + @"\DummyLogos\" + strLogoName + ".png");
                    }
                    else
                    {
                        MessageBox.Show(this, "Minimum Size of Image should be 100 x 100.", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPublisher.PublishException(ex);
                throw;
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            //var ratioX = (double)maxWidth / image.Width;
            //var ratioY = (double)maxHeight / image.Height;
            //var ratio = Math.Min(ratioX, ratioY);

            //var newWidth = (int)(image.Width * ratio);
            //var newHeight = (int)(image.Height * ratio);

            //var newImage = new Bitmap(newWidth, newHeight);

            //using (var graphics = Graphics.FromImage(newImage))
            //    graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            Bitmap newImage = new Bitmap(maxWidth, maxHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(image, new Rectangle(0, 0, maxWidth, maxHeight));
            }
            return newImage;
        }
        public byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
