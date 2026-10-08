using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class FormPromotionWizard : Form
    {
        DataTable dtDitributor;
        public FormPromotionWizard()
        {
            InitializeComponent();
        }

        #region Common Navigation Events

        /// <summary>
        /// Resets All Controls
        /// </summary>
        private void OfferEmpty()
        {
            this.chDiscount.Checked = false;
            this.txtDiscountAmount.Text = "";
            this.txtDiscountRate.Text = "";
            this.chSKU.Checked = false;
            this.ddPromotionCatagory.SelectedIndex = 0;
            this.txtPromotionQuantity.Text = "";
            this.txtMultipleOf.Text = "";
            this.txtFrom.Text = "";
            this.txtTo.Text = "";
            this.txtMultipleOf.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Value >= txtEndDate.Value)
            {
                MessageBox.Show(this, "Invalid Promotion Duration", "CORN: POS");
                return;
            }
            if (rBtnExisting.Checked == true && drpExisting.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select Existing Promotion", "CORN: POS");
                return;
            }
            if (rBtnNew.Checked == true && txtNew.TextLength == 0)
            {
                MessageBox.Show(this, "Enter Promotion Name", "CORN: POS");
                return;
            }
            ChbAllLocationType.Checked = false;
            chkSelectAllDistributors.Checked = false;
            ChbAllVolumeClass.Checked = false;
            this.Collection();
            Slider.SelectedPage = Step2;
            Step2Load();
        }
        private void FormPromotionWizard_Load(object sender, EventArgs e)
        {
            txtStartDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now.AddDays(1);
            Slider.SelectedPage = Step1;
            grdPromotion.BackgroundColor = Color.White;
            grdSlab.BackgroundColor = Color.White;

            //
            SchemeController mController = new SchemeController();
            DataTable dt = mController.SelectScheme(Constants.IntNullValue, Constants.IntNullValue, null, null, Constants.DateNullValue);
            clsListItems[] SchemeListItems = new clsListItems[dt.Rows.Count];
            Populate_drpSKUCompany();
            if (dt.Rows.Count != 0)
            {
                drpExisting.DataSource = dt;
                drpExisting.DisplayMember = "SCHEME_CODE";
                drpExisting.ValueMember = "SCHEME_ID";
            }

            string flow = (string)SessionClass.flow;
            if (SessionClass.IsEdit != null)
            {
                bool IsEditing = (bool)SessionClass.IsEditing;
                if (IsEditing == true)
                {

                    if (flow == "f")
                    {
                        this.FillClonePromotion();
                    }
                    else
                        if (flow == "b")
                        {
                            this.LoadPromotionCollection1();
                        }
                }
                else
                {
                    if (flow == "b")
                    {
                        this.LoadPromotionCollection1();
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnBack2_Click(object sender, EventArgs e)
        {
            SessionClass.flow = "b";
            Slider.SelectedPage = Step1;
        }
        #endregion

        /// <summary>
        /// //////////////////////////////////////////////////// Step 1 ////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region Promotion Step 1
        private void Step1_Enter(object sender, EventArgs e)
        {
            SchemeController mController = new SchemeController();
            DataTable dt = mController.SelectScheme(Constants.IntNullValue, Constants.IntNullValue, null, null, Constants.DateNullValue);
            clsListItems[] SchemeListItems = new clsListItems[dt.Rows.Count];
            Populate_drpSKUCompany();
            if (dt.Rows.Count != 0)
            {
                drpExisting.DataSource = dt;
                drpExisting.DisplayMember = "SCHEME_CODE";
                drpExisting.ValueMember = "SCHEME_ID";
            }

            string flow = (string)SessionClass.flow;
            if (SessionClass.IsEditing != null)
            {
                bool IsEditing = (bool)SessionClass.IsEditing;
                if (IsEditing == true)
                {

                    if (flow == "f")
                    {
                        this.FillClonePromotion();
                    }
                    else
                        if (flow == "b")
                        {
                            this.LoadPromotionCollection1();
                        }
                }
                else
                {
                    if (flow == "b")
                    {
                        this.LoadPromotionCollection1();
                    }
                }
            }
        }
        /// <summary>
        /// Loads Principals To Principal Combo
        /// </summary>
        private void Populate_drpSKUCompany()
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), Constants.IntNullValue, 0, DateTime.Parse(SessionClass.CurrentWorkDate.ToString()));
            cboxPrincipal.DataSource = m_dt;
            cboxPrincipal.DisplayMember = "Company_Name";
            cboxPrincipal.ValueMember = "Company_Id";
        }
        /// <summary>
        /// Loads Promotion Collection From Session Variables For Nevigating Back From Forward Steps
        /// </summary>
        private void LoadPromotionCollection1()
        {
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;

            this.txtNew.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Code;
            this.txtPromotionDescription.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Desc;
            this.txtStartDate.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Start_Date.ToString("dd/MM/yyyy");
            this.txtEndDate.Text = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).End_Date.ToString("dd/MM/yyyy");

            if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme == false)
            {
                chkSchemeDiscount.Checked = true;
            }
            else
                if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme == true)
                {
                    chkSchemeUpSell.Checked = true;
                }
            if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable == true)
            {
                this.chkClaimable.Checked = true;

            }
            else
                if (SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable == false)
                {
                    this.chkClaimable.Checked = false;

                }
            bool Promotion_For = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_For;

            if (Promotion_For == true)
            {

                rbtnSecondary.Checked = false;
            }
            else
                if (Promotion_For == false)
                {
                    rbtnPrimary.Checked = false;
                }
            if (SchCtrl.Get(0).Scheme_ID == 0)
            {
                this.rBtnExisting.Checked = false;
                this.drpExisting.Enabled = false;
                this.rBtnNew.Checked = true;
                this.txtNew.Enabled = true;
                this.txtNew.Text = SchCtrl.Get(0).Scheme_Code;
            }

            else
            {
                string sch_code = SchCtrl.Get(0).Scheme_Code;

                this.txtNew.Enabled = false;
                this.rBtnNew.Checked = false;
                this.rBtnExisting.Checked = true;
                this.drpExisting.Enabled = true;

                for (int mItem = 0; mItem < drpExisting.Items.Count; mItem++)
                {
                    if (drpExisting.Items[mItem].ToString() == sch_code)
                    {
                        drpExisting.SelectedIndex = mItem;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Loads Promotion Collection
        /// </summary>
        private void FillClonePromotion()
        {
            rBtnNew.Checked = false;
            txtNew.Enabled = false;
            drpExisting.Enabled = true;
            rBtnExisting.Checked = true;

            string PromotionId = (string)SessionClass.PromotionId;
            PromotionController mPromotionContrl = new PromotionController();
            DataTable dtPromotion = mPromotionContrl.SelectPromotionWithSchemeInfo(int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()), int.Parse(PromotionId));
            if (dtPromotion.Rows.Count > 0)
            {
                this.drpExisting.SelectedValue = dtPromotion.Rows[0]["SCHEME_ID"].ToString();
                // this.txtPromotionName.Text = dtPromotion.Rows[0]["Promotion_code"].ToString();
                this.txtNew.Text = dtPromotion.Rows[0]["Promotion_code"].ToString();
                this.txtPromotionDescription.Text = dtPromotion.Rows[0]["Promotion_Desc"].ToString();
                this.txtStartDate.Text = DateTime.Parse(dtPromotion.Rows[0]["Start_Date"].ToString()).ToString("dd-MMM-yyyy");
                this.txtEndDate.Text = DateTime.Parse(dtPromotion.Rows[0]["End_Date"].ToString()).ToString("dd-MMM-yyyy");
                for (int i = 0; i < this.cboxPrincipal.Items.Count; i++)
                {
                    if (this.cboxPrincipal.Items[i].ToString() == dtPromotion.Rows[0]["PROMOTION_TYPE"].ToString())
                    {
                        cboxPrincipal.SelectedIndex = i;
                    }
                }
                if (bool.Parse(dtPromotion.Rows[0]["is_Scheme"].ToString()) == false)
                {
                    chkSchemeDiscount.Checked = true;
                }
                else
                {
                    chkSchemeUpSell.Checked = true;
                }
                if (bool.Parse(dtPromotion.Rows[0]["CLAIMABLE"].ToString()) == true)
                {
                    this.chkClaimable.Checked = true;
                }

                if (bool.Parse(dtPromotion.Rows[0]["PROMOTION_FOR"].ToString()) == true)
                {
                    //this.rdbbtncheck.SelectedValue = "1";
                    rbtnSecondary.Checked = true;
                }
                else
                    if (bool.Parse(dtPromotion.Rows[0]["PROMOTION_FOR"].ToString()) == false)
                    {
                        //this.rdbbtncheck.SelectedValue = "0";
                        rbtnPrimary.Checked = true;
                    }

                for (int nItem = 0; nItem < drpExisting.Items.Count; nItem++)
                {
                    if (drpExisting.Items[nItem].ToString() == dtPromotion.Rows[0]["Scheme_Code"].ToString())
                    {
                        this.drpExisting.SelectedIndex = nItem;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Loads Step1 Data To Session Variables For Next Setps
        /// </summary>
        protected void Collection()
        {
            try
            {
                SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
                Scheme_Collection SchCollection = new Scheme_Collection();

                if (rBtnExisting.Checked == true)
                {
                    clsListItems[] SchemeListItems = (clsListItems[])SessionClass.SchemeListItems;
                    SchCollection.Scheme_ID = Convert.ToInt32(drpExisting.SelectedValue.ToString());
                }
                else
                {
                    SchCollection.Scheme_ID = 0;
                }
                //SchCollection.Dist_ID = Configuration.DistributorId;
                if (rBtnExisting.Checked == true)
                {
                    SchCollection.Scheme_Code = drpExisting.SelectedValue.ToString();
                    SchCollection.Scheme_Desc = drpExisting.SelectedValue.ToString();
                }
                else if (rBtnNew.Checked == true)
                {
                    SchCollection.Scheme_Code = txtNew.Text;
                    SchCollection.Scheme_Desc = txtNew.Text;
                }
                SchCtrl.Add(SchCollection);

                Promotion_Collection PC = new Promotion_Collection();
                PC.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                if (rbtnPrimary.Checked)
                {
                    PC.Promotion_For = false;
                }
                else if (rbtnSecondary.Checked)
                {
                    PC.Promotion_For = true;
                }

                // PC.Promotion_Code = txtPromotionName.Text;
                PC.Promotion_Code = txtNew.Text;
                PC.Promotion_Desc = txtPromotionDescription.Text;
                //PC.Promotion_Date On Promotion Insert
                PC.Claimable = chkClaimable.Checked;

                //PC.Start_Date = Convert.ToDateTime(this.txtStartDate.Text);
                PC.Start_Date = Convert.ToDateTime(txtStartDate.Text);
                if (txtEndDate.Text == "")
                {
                    PC.End_Date = DateTime.MaxValue;
                }
                else
                {
                    PC.End_Date = Convert.ToDateTime(txtEndDate.Text);

                }
                PC.Is_Active = true;
                PC.Promotion_Type = int.Parse(cboxPrincipal.SelectedValue.ToString());

                if (chkSchemeDiscount.Checked)
                {
                    PC.Is_Scheme = false;
                }
                else
                {
                    PC.Is_Scheme = true;
                }
                SchCollection.ObjPromotionCol_Cntrl = new PromotionCollections_Controller();
                SchCollection.ObjPromotionCol_Cntrl.Add_PCol(PC);

                SessionClass.SchCtrl = SchCtrl;
                SessionClass.flow = "f";

            }
            catch (Exception e1)
            {
                //lblErrorMessage.Text = e1.Message; 
            }
            //string PrincipalId = cboxPrincipal.SelectedValue.ToString();
            SessionClass.PRINCIPAL_ID = Constants.IntNullValue;
        }
        //
        //
        //
        private void rBtnExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnExisting.Checked == true)
            {
                txtNew.Enabled = false;
                txtNew.Text = null;
                drpExisting.Enabled = true;
                this.rBtnNew.Checked = false;
            }
            else if (rBtnExisting.Checked == false)
            {
                txtNew.Enabled = true;
                drpExisting.Enabled = false;
            }
        }
        //
        //
        //
        private void rBtnNew_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnNew.Checked == false)
            {
                txtNew.Enabled = false;
                drpExisting.Enabled = true;

            }
            else if (rBtnNew.Checked == true)
            {
                txtNew.Enabled = true;
                drpExisting.Enabled = false;
                this.rBtnExisting.Checked = false;
            }
        }

        #endregion


        /// <summary>
        /// ///////////////////////////////////////////////////// Step 2 ///////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Promotion Step 2
        private void Step2_Enter(object sender, EventArgs e)
        {

        }
        public void CreateTable()
        {
            dtDitributor = new DataTable();
            dtDitributor.Columns.Add("name", typeof(string));
            dtDitributor.Columns.Add("value", typeof(int));
        }

        #region Step 2 Load
        public void Step2Load()
        {
            this.GetDistributorType();
            this.Populate_VolumeClass();
            this.Populate_CustomerType();
            string flow = (string)SessionClass.flow;
            bool IsEditing = (bool)SessionClass.IsEditing;

            if (IsEditing == true)
            {

                if (flow == "f")
                {
                    this.FillPromotionInfo();
                }
                else if (flow == "b")
                {
                    this.LoadPromotionCollection2();
                }
            }
            else
            {
                if (flow == "b")
                {
                    this.LoadPromotionCollection2();
                }
            }
            CreateTable();
        }
        #endregion

        #region Volume Class
        private void Populate_VolumeClass()
        {
            SLASHCodesController Slash_Codes = new SLASHCodesController();
            DataTable dtSlashCodes = Slash_Codes.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, true);
            ChbVolumClass.DataSource = dtSlashCodes;
            ChbVolumClass.DisplayMember = "SLASH_DESC";
            ChbVolumClass.ValueMember = "REF_ID";
        }

        private void ChbAllVolumeClass_CheckedChanged(object sender, EventArgs e)
        {
           
            int _Items = ChbVolumClass.Items.Count;
            if (ChbAllVolumeClass.Checked)
            {
                for (int i = 0; i < _Items; i++)
                {
                    ChbVolumClass.SetItemChecked(i, true);
                } 
            }
            else
            {
                for (int i = 0; i < _Items; i++)
                {
                    ChbVolumClass.SetItemChecked(i, false);
                }
            }
        }
        #endregion

        #region Customer type
        private void Populate_CustomerType()
        {
            SLASHCodesController Slash_Codes = new SLASHCodesController();
            DataTable dtSlashCodes = Slash_Codes.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, true);
            chklCustomerType.DataSource = dtSlashCodes;
            chklCustomerType.DisplayMember = "SLASH_DESC";
            chklCustomerType.ValueMember = "REF_ID";
        }
        protected void chkSelectAllCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            bool AllChecked = (chkSelectAllCustomerType.Checked) ? true : false;
            int _Items = chklCustomerType.Items.Count;
            for (int i = 1; i < _Items; i++)
            {
                chklCustomerType.SetItemChecked(i, true);
            }
        }
        #endregion

        #region Distributor
        private void GetDistributor()
        {
            DistributorController mController = new DistributorController();
            int _items = ChbDistributorType.Items.Count;
            for (int i = 0; i < _items; i++)
            {
                DataRowView drV = (DataRowView)ChbDistributorType.Items[i];
                DataRow dr = drV.Row;
                int _value = Convert.ToInt32(dr["DISTRIBUTOR_TYPE_ID"].ToString());
                if (ChbDistributorType.GetItemChecked(i))
                {
                    DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(SessionClass.UserID.ToString()), _value, int.Parse(SessionClass.CompanyID.ToString()));
                    int _rows = dt.Rows.Count;
                    for (int j = 0; j < _rows; j++)
                    {
                        GetItem(dt.Rows[j].ItemArray[2].ToString(), Convert.ToInt32(dt.Rows[j].ItemArray[0].ToString()));
                    }
                    chklDistributors.DataSource = dtDitributor;
                    chklDistributors.DisplayMember = "name";
                    chklDistributors.ValueMember = "value";
                }
            }
        }
        public void GetItem(string text, int value)
        {
            //clsWindowsFormUtil.SetComboboxItem _item = new clsWindowsFormUtil.SetComboboxItem();
            //_item.Text = text;
            //_item.Value = value;
            //chklDistributors.Items.Add(_item);
            dtDitributor.Rows.Add(text, value);
        }
        private void chkSelectAllDistributors_CheckedChanged(object sender, EventArgs e)
        {
            int _items = chklDistributors.Items.Count;
            if (chkSelectAllDistributors.Checked)
            {
                for (int i = 0; i < _items; i++)
                {
                    chklDistributors.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < _items; i++)
                {
                    chklDistributors.SetItemChecked(i, false);
                }
            }
        }
        #endregion

        #region Distributor Type
        private void GetDistributorType()
        {
            DistributorController mController = new DistributorController();
            DataTable dt = mController.SelectDistributorTypeInfo(Constants.IntNullValue);
            ChbDistributorType.DataSource = dt;
            ChbDistributorType.DisplayMember = "TYPENAME";
            ChbDistributorType.ValueMember = "DISTRIBUTOR_TYPE_ID";
        }
        private void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbAllLocationType.Checked)
            {
                int _items = ChbDistributorType.Items.Count;
                for (int i = 0; i < _items; i++)
                {
                    ChbDistributorType.SetItemChecked(i, true);
                }
                if (_items > 0)
                {
                    try
                    {
                        ChbDistributorType.SelectedIndex = ChbDistributorType.SelectedIndex + 1;
                    }
                    catch (Exception)
                    {
                        ChbDistributorType.SelectedIndex = ChbDistributorType.SelectedIndex - 1;
                    }
                }
            }
            else
            {
                int _items = ChbDistributorType.Items.Count;
                for (int i = 0; i < _items; i++)
                {
                    ChbDistributorType.SetItemChecked(i, false);
                }
                chklDistributors.DataSource = null;
            }
        }
        #endregion

        #region Fill Promorion Info
        private void FillPromotionInfo()
        {

            #region datatable for Distributor Info

            DataTable dtDistHirerchy = new DataTable();

            dtDistHirerchy.Columns.Add("distributor_id", System.Type.GetType("System.String"));
            dtDistHirerchy.Columns.Add("subzone_id", System.Type.GetType("System.String"));

            #endregion

            #region Fill Datatable of Distributor Info

            string PromotionId = (string)SessionClass.PromotionId;

            PromotionController mPromotionCtrl = new PromotionController();
            DistributorController mDistCtl = new DistributorController();
            DataTable dtDist = mPromotionCtrl.GetPromotionDistributors(long.Parse(PromotionId));
            for (int nCount = 0; nCount < dtDist.Rows.Count; nCount++)
            {
                int AssignDistId = int.Parse(dtDist.Rows[nCount]["ASSIGNED_DISTRIBUTOR_ID"].ToString());
                DataTable dtDistHierarchy = mDistCtl.GetDistributorHierarchy(AssignDistId);
                for (int nRow = 0; nRow < dtDistHierarchy.Rows.Count; nRow++)
                {
                    DataRow dr = dtDistHirerchy.NewRow();

                    dr["subzone_id"] = dtDistHierarchy.Rows[nRow]["subzone_id"].ToString();
                    dr["distributor_id"] = dtDistHierarchy.Rows[nRow]["distributor_id"].ToString();
                    dtDistHirerchy.Rows.Add(dr);
                }
            }

            #endregion

            #region Load Customer Type

            DataTable dt = mPromotionCtrl.GetPromotionCustomerType(long.Parse(PromotionId));

            for (int nOuter = 0; nOuter < dt.Rows.Count; nOuter++)
            {
                int Customer_Type_Id = int.Parse(dt.Rows[nOuter]["CUSTOMER_TYPE_ID"].ToString());

                for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
                {
                    if (int.Parse(chklCustomerType.Items[nInner].ToString()) == Customer_Type_Id)
                    {
                        if (chklCustomerType.GetItemChecked(nInner) == false)
                        {
                            chklCustomerType.SetItemChecked(nInner, true);
                            break;
                        }
                    }
                }
            }

            #endregion

            #region Load Customer Volume Class

            DataTable dtVolume = mPromotionCtrl.GetPromotionCustomerVolumeClass(long.Parse(PromotionId));

            for (int nOuter = 0; nOuter < dtVolume.Rows.Count; nOuter++)
            {
                int Customer_Type_Id = int.Parse(dtVolume.Rows[nOuter]["CUSTOMER_VOLUMECLASS_ID"].ToString());

                for (int nInner = 0; nInner < this.ChbVolumClass.Items.Count; nInner++)
                {
                    if (int.Parse(ChbVolumClass.Items[nInner].ToString()) == Customer_Type_Id)
                    {
                        if (ChbVolumClass.GetItemChecked(nInner) == false)
                        {
                            ChbVolumClass.SetItemChecked(nInner, true);
                            break;
                        }
                    }
                }
            }

            #endregion

            #region Select Distributor Type

            for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
            {
                int distributor_type = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["subzone_id"].ToString());

                for (int Inner = 0; Inner < this.ChbDistributorType.Items.Count; Inner++)
                {
                    if (int.Parse(ChbDistributorType.Items[Inner].ToString()) == distributor_type)
                    {
                        if (ChbDistributorType.GetItemChecked(Inner) == false)
                        {
                            ChbDistributorType.SetItemChecked(Inner, true);
                            ChbDistributorType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Select Distributors

            for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
            {
                int distributor_id = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["distributor_id"].ToString());

                for (int Inner = 0; Inner < this.chklDistributors.Items.Count; Inner++)
                {
                    if (int.Parse(chklDistributors.Items[Inner].ToString()) == distributor_id)
                    {
                        if (chklDistributors.GetItemChecked(Inner) == false)
                        {
                            chklDistributors.SetItemChecked(Inner, true);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Basket or Slab Promotion

            BasketController BCtl = new BasketController();
            DataTable dtBMaster = BCtl.GetBasketMaster(long.Parse(PromotionId));
            bool IsBasket = false;

            foreach (DataRow dr in dtBMaster.Rows)
            {
                IsBasket = bool.Parse(dr["IS_BASKET"].ToString());
            }
            if (IsBasket == true)
            {
                this.rBtnSlabPromotion.Checked = false;
                this.rBtnSlabPromotion.Enabled = false;
                this.rBtnBasketPromotion.Checked = true;
            }
            else if (IsBasket == false)
            {
                this.rBtnBasketPromotion.Checked = false;
                this.rBtnBasketPromotion.Enabled = false;
                this.rBtnSlabPromotion.Checked = true;
            }
            #endregion
        }
        /// <summary>
        /// Loads Promotion Collection From Session Variables For Nevigating Back From Forward Steps
        /// </summary>
        private void LoadPromotionCollection2()
        {
            #region	Get Scheme Controller
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;
            #endregion

            #region datatable for Distributor Info

            DataTable dtDistHirerchy = new DataTable();
            dtDistHirerchy.Columns.Add("distributor_id", System.Type.GetType("System.String"));
            dtDistHirerchy.Columns.Add("subzone_id", System.Type.GetType("System.String"));

            #endregion

            #region Fill Datatable of Distributor Info

            DistributorController mDistCtl = new DistributorController();
            PromotionForCollection_Controller mPromotionForColl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl;

            for (int nCount = 0; nCount < mPromotionForColl.Count; nCount++)
            {
                PromotionFor_Collection mPromotionforColl = mPromotionForColl.Get(nCount);
                int Distributor_Id = mPromotionforColl.Assigned_Dist_ID;
                DataTable dt = mDistCtl.GetDistributorHierarchy(Distributor_Id);
                if (dt.Rows.Count > 0)
                {
                    for (int nItem = 0; nItem < dt.Rows.Count; nItem++)
                    {
                        DataRow dr = dtDistHirerchy.NewRow();
                        dr["subzone_id"] = dt.Rows[nItem]["subzone_id"].ToString();
                        dr["distributor_id"] = dt.Rows[nItem]["distributor_id"].ToString();
                        dtDistHirerchy.Rows.Add(dr);
                    }
                }
            }

            #endregion

            #region Load Customer Type

            PromotionCustTypeColl_Controller mPromotionCustTypeColl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl;
            for (int nOuter = 0; nOuter < mPromotionCustTypeColl.Count; nOuter++)
            {
                PromotionCustomerType_Collection mPromotionCustType = mPromotionCustTypeColl.Get(nOuter);
                int CustomerTypeId = mPromotionCustType.Customer_Type_ID;
                for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
                {
                    chklCustomerType.SelectedIndex = nInner;
                    if (int.Parse(chklCustomerType.SelectedValue.ToString()) == CustomerTypeId)
                    {
                        chklCustomerType.SelectedIndex = nInner;
                        break;
                    }
                }
            }
            #endregion

            #region Load Customer Volum Class

            PromotionCustVolclassColl_Controller mPromotionVolClass = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionVolClassCol_Cntrl;
            for (int nOuter = 0; nOuter < mPromotionVolClass.Count; nOuter++)
            {
                PromotionCustomerVolClass_Collection mPromotionVolClassCollection = mPromotionVolClass.Get(nOuter);
                int CustomerVolClass = mPromotionVolClassCollection.Customer_VolClass_ID;

                for (int nInner = 0; nInner < this.chklCustomerType.Items.Count; nInner++)
                {
                    ChbVolumClass.SelectedIndex = nInner;
                    if (int.Parse(ChbVolumClass.SelectedValue.ToString()) == CustomerVolClass)
                    {
                        ChbVolumClass.SetItemChecked(nInner, true);
                        break;
                    }
                }
            }
            #endregion

            #region Select Distributor Type

            for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
            {
                int distributor_type = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["subzone_id"].ToString());

                for (int Inner = 0; Inner < this.ChbDistributorType.Items.Count; Inner++)
                {
                    ChbDistributorType.SelectedIndex = Inner;
                    if (int.Parse(ChbDistributorType.SelectedValue.ToString()) == distributor_type)
                    {
                        if (ChbDistributorType.GetItemChecked(Inner) == false)
                        {
                            ChbDistributorType.SetItemChecked(Inner,true);
                            ChbDistributorType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Select Distributors

            for (int Outer = 0; Outer < dtDistHirerchy.Rows.Count; Outer++)
            {
                int distributor_id = Convert.ToInt32(dtDistHirerchy.Rows[Outer]["distributor_id"].ToString());

                for (int Inner = 0; Inner < this.chklDistributors.Items.Count; Inner++)
                {
                    chklDistributors.SelectedIndex = Inner;
                    if (int.Parse(chklDistributors.SelectedValue.ToString()) == distributor_id)
                    {
                        if (chklDistributors.GetItemChecked(Inner) == false)
                        {
                            chklDistributors.SetItemChecked(Inner,true);
                            break;
                        }
                    }
                }
            }
            #endregion
        }

        #endregion

        #region Distributor Type Event (Selected Indexed Changed)
        private void ChbDistributorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chklDistributors.DataSource = null;
            try { dtDitributor.Rows.Clear(); }
            catch (Exception) { }
            chklDistributors.Items.Clear();
            GetDistributor();
        }
        #endregion

        #region Next Button
        private void btnNext2_Click(object sender, EventArgs e)
        {
            try
            {
                SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
                SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;

                Promotion_Collection pc = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);

                // For Promotion For Distributor Collection
                pc.ObjPromotionForCol_Cntrl = new PromotionForCollection_Controller();

                for (int i = 0; i < this.chklDistributors.Items.Count; i++)
                {
                    if (this.chklDistributors.GetItemChecked(i))
                    {
                        chklDistributors.SelectedIndex = i;
                        PromotionFor_Collection PForCollection = new PromotionFor_Collection();
                        PForCollection.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                        PForCollection.Assigned_Dist_ID = Convert.ToInt32(chklDistributors.SelectedValue.ToString());
                        pc.ObjPromotionForCol_Cntrl.Add(PForCollection);
                    }
                }
                if (pc.ObjPromotionForCol_Cntrl.Count == 0)
                {
                    MessageBox.Show(this, "Please Select at least one Distributor", "CORN: POS");
                    return;
                }

                // For Promotion For CustomerType Collecion 
                pc.ObjPromotionCustTypeCol_Cntrl = new PromotionCustTypeColl_Controller();
                //      for (int i = 0; i < this.chklCustomerType.Items.Count; i++)
                //     {
                //         if (this.chklCustomerType.Items[i].Selected)
                //        {
                PromotionCustomerType_Collection PCustTypeColllection = new PromotionCustomerType_Collection();
                PCustTypeColllection.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                PCustTypeColllection.Customer_Type_ID = 90;//int.Parse(this.chklCustomerType.Items[i].Value);
                pc.ObjPromotionCustTypeCol_Cntrl.Add(PCustTypeColllection);
                //    }
                //  }
                // if (pc.ObjPromotionCustTypeCol_Cntrl.Count == 0)
                // {
                //  lblErrorMessage.Text = "Must select at one Customer Type";
                //   return; 
                // }
                pc.ObjPromotionVolClassCol_Cntrl = new PromotionCustVolclassColl_Controller();
                for (int i = 0; i < this.ChbVolumClass.Items.Count; i++)
                {
                    if (this.ChbVolumClass.GetItemChecked(i))
                    {
                        ChbVolumClass.SelectedIndex = i;
                        PromotionCustomerVolClass_Collection PVolClassColllection = new PromotionCustomerVolClass_Collection();
                        PVolClassColllection.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                        PVolClassColllection.Customer_VolClass_ID = Convert.ToInt32(ChbVolumClass.SelectedValue.ToString());
                        pc.ObjPromotionVolClassCol_Cntrl.Add(PVolClassColllection);

                    }
                }
                if (pc.ObjPromotionVolClassCol_Cntrl.Count == 0)
                {
                    MessageBox.Show(this, "Please select at least one Customer Volume Class", "CORN: POS");
                    return;
                }
                // For Promotion For Customer Collecion 
                pc.ObjPromotionForCustCol_Cntrl = new PromotionForCustColl_Controller();


                SessionClass.SchCtrl = SchCtrl;

                SessionClass.flow = "f";

                if (rBtnBasketPromotion.Checked == true)
                {
                    //Response.Redirect("frmPromotionWizardStep3Basket.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
                }
                if (rBtnSlabPromotion.Checked == true)
                {
                    Slider.SelectedPage = Step3;
                    LoadStep3();
                }
            }
            catch (Exception e1) { MessageBox.Show(e1.Message + "\r\nError: FormPromotionWizard\r\nFunction/Event: btnNext2_Click"); }
        }
        #endregion

        private void Slider_SelectedPageChanged(object sender, EventArgs e)
        {
            if (Slider.SelectedPage == Step1)
            {
                lblPromotionSteps.Text = "Customer Promotion (Step 1)";
            }
            if (Slider.SelectedPage == Step2)
            {
                lblPromotionSteps.Text = "Customer Promotion (Step 2)";
            }
            if (Slider.SelectedPage == Step3)
            {
                lblPromotionSteps.Text = "Customer Promotion (Step 3)";
            }
            if (Slider.SelectedPage == Step4)
            {
                lblPromotionSteps.Text = "Customer Promotion (Step 4)";
            }
        }


        #endregion


        /// <summary>
        /// ///////////////////////////////////////////////////// Step 3 ///////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Promotion Step 3
        public int SlabNo;
        public static int RowNo;
        public DataTable dt;
        ////////////////////

        #region Load Promotion Step 3
        public void LoadStep3()
        {
            ddSKUSelectedGroup.Enabled = false;
            txtMultipleOf.Enabled = false;
            this.LoadCategory();
            this.LoadSKUS();
            this.LoadGroups();
            this.LoadSKUCategory2();
            this.LoadSKUs2();
            LoadSlabOn();
            this.CreateSlabTable();
            string flow = (string)SessionClass.flow;
            if (SessionClass.IsEditing != null)
            {
                bool IsEditing = (bool)SessionClass.IsEditing;

                if (IsEditing == true)
                {
                    if (flow == "f")
                    {
                        this.LoadCloneSlabData();
                        btnNext.Enabled = true;
                    }
                    else
                        if (flow == "b")
                        {
                            this.LoadPromotionCollection3();
                        }
                }
                else
                {
                    if (flow == "b")
                    {
                        this.LoadPromotionCollection3();
                    }
                    else
                    {
                        this.CreatNewSlab();
                    }
                }
            }
            this.LoadGrid();
            ArrangeGrid();
        }
        public void ArrangeGrid()
        {
            try
            {
                grdSlab.Columns.Remove("Edit1");
                grdSlab.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            foreach (DataGridViewColumn clms in grdSlab.Columns)
            {
                clms.Visible = false;
            }
            grdSlab.Columns["Slab No"].Visible = true;
            grdSlab.Columns["SKU"].Visible = true;
            grdSlab.Columns["Slab On"].Visible = true;
            grdSlab.Columns["From"].Visible = true;
            grdSlab.Columns["To"].Visible = true;
            grdSlab.Columns["Discount"].Visible = true;
            grdSlab.Columns["SKU Offer"].Visible = true;
            grdSlab.Columns["SKU Quantity"].Visible = true;
            grdSlab.Columns["IS_Multiple"].Visible = true;
            grdSlab.Columns["Multiple_of"].Visible = true;

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "Edit1";
            btnEdit.Name = "Edit1";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            grdSlab.Columns.Add(btnEdit);

            // Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "Delete";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            grdSlab.Columns.Add(btnDelete);

            // Set Index 
            //grdSlab.Columns["SLAB NO"].DisplayIndex = 1;
            //grdSlab.Columns["SKU"].DisplayIndex = 2;
            //grdSlab.Columns["SLAB ON"].DisplayIndex = 3;
            //grdSlab.Columns["FROM"].DisplayIndex = 4;
            //grdSlab.Columns["TO"].DisplayIndex = 5;
            //grdSlab.Columns["DISCOUNT"].DisplayIndex = 6;
            //grdSlab.Columns["SKU OFFER"].DisplayIndex = 7;
            //grdSlab.Columns["SKU QUANTITY"].DisplayIndex = 8;
            //grdSlab.Columns["IS_MULTIPLE"].DisplayIndex = 9;
            //grdSlab.Columns["EDIT1"].DisplayIndex = 10;
            //grdSlab.Columns["DELETE"].DisplayIndex = 11;
            //grdSlab.Columns["SLAB_NO"].DisplayIndex = 12;
            //grdSlab.Columns["SKUID"].DisplayIndex = 13;
            //grdSlab.Columns["SKUGROUPID"].DisplayIndex = 14;
            //grdSlab.Columns["UOM"].DisplayIndex = 15;
            //grdSlab.Columns["UOMID"].DisplayIndex = 16;
            //grdSlab.Columns["BASKET_ON"].DisplayIndex = 17;
            //grdSlab.Columns["SKUOFFERID"].DisplayIndex = 18;
            //grdSlab.Columns["DISCOUNTPERCENTAGE"].DisplayIndex = 19;
            //grdSlab.Columns["DISCOUNTAMOUNT"].DisplayIndex = 20;
            //grdSlab.Columns["Edit"].DisplayIndex = 21;
            //grdSlab.Columns["REMOVE"].DisplayIndex = 22;
        }

        public void LoadSlabOn()
        {
            ddSlabOn.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("slabName", typeof(string));
            dt.Columns.Add("slabValue", typeof(int));
            dt.Rows.Add("Quantity", 82);
            dt.Rows.Add("Amount", 83);
            ddSlabOn.DataSource = dt;
            ddSlabOn.DisplayMember = "slabName";
            ddSlabOn.ValueMember = "slabValue";
            ddSlabOn.SelectedIndex = 0;
        }
        #endregion

        #region SKU Hierarchy

        /// <summary>
        /// Enables SKU Hierarchy Related Controls For Promotion On SKU Hierarchy
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void rbSKUHierarchy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSKUHierarchy.Checked)
            {
                ddSKUCatagory.Enabled = true;
                ddSKU.Enabled = true;
                ddSKUSelectedGroup.Enabled = false;
                ddSlabOn.Enabled = false;
            }
            else
            {
                ddSKUCatagory.Enabled = false;
                ddSKU.Enabled = false;
                ddSKUSelectedGroup.Enabled = true;
                ddSlabOn.Enabled = true;
            }
        }

        /// <summary>
        /// Loads Categories To Category Combo
        /// </summary>
        private void LoadCategory()
        {
            string PrincipalId = SessionClass.PRINCIPAL_ID.ToString();
            SkuHierarchyController mSkuHieController = new SkuHierarchyController();
            DataTable dtDist = mSkuHieController.SelectDTSkuHierarchy01(2, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            ddSKUCatagory.DataSource = dtDist;
            ddSKUCatagory.DisplayMember = "SKU_HIE_NAME";
            ddSKUCatagory.ValueMember = "SKU_HIE_ID";
            ddSKUCatagory.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads Brands To Brand Comb And SKUS To SKU Combo
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddSKUCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.LoadBrand();
               this.LoadSKUS(); 
        }

        /// <summary>
        /// Load Brands To Brand Combo
        /// </summary>
        //private void LoadBrand()
        //{
        //    if (this.ddSKUCatagory.Items.Count > 0)
        //    {
        //      //  ddSKUBrand.Items.Clear();
        //        SkuHierarchyController sel_SKU_HIE_Cat = new SkuHierarchyController();
        //        DataTable dtDist = new DataTable();
        //        dtDist = sel_SKU_HIE_Cat.SelectDTSkuHierarchy(Constants.SKUBrand, Int32.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUCatagory)));
        //        clsWebFormUtil.FillDropDownList(this.ddSKUBrand, dtDist, "SKU_HIE_ID", "SKU_HIE_NAME");
        //    }
        //}

        /// <summary>
        /// Loads SKUS To SKU Combo
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddSKUBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadSKUS();
        }

        /// <summary>
        /// Loads SKUS To SKU Combo
        /// </summary>
        private void LoadSKUS()
        {
            if (this.ddSKUCatagory.SelectedIndex > 0)
            {
                ddSKU.DataSource = null;
                this.ddSKU.Items.Clear();
                SkuController mSKUController = new SkuController();
                int comp, div, cat;
                comp = Constants.IntNullValue;
                div = Constants.IntNullValue;
                //(amanullah)cat = Int32.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUCatagory));
                //  brand = Int32.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUBrand));
                cat = Convert.ToInt32(ddSKUCatagory.SelectedValue.ToString());
                dt = mSKUController.SelectSkuInfo(comp, div, cat, Constants.IntNullValue, Constants.IntNullValue);
                ddSKU.DataSource = dt;
                ddSKU.DisplayMember = "SKUDETAIL";
                ddSKU.ValueMember = "SKU_ID";

                if (ddSKU.Items.Count > 0)
                {
                    this.ddSKU.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region SKU Group

        /// <summary>
        /// Enables SKU Group Related Controls For Promotion On SKU Group
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void rbSKUGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSKUGroup.Checked)
            {
                ddSKUSelectedGroup.Enabled = true;
                ddSKUCatagory.Enabled = false;
                ddSKU.Enabled = false;
                ddSlabOn.Enabled = true;
            }
            else
            {
                ddSKUSelectedGroup.Enabled = false;
                ddSKUCatagory.Enabled = true;
                ddSKU.Enabled = true;
                ddSlabOn.Enabled = false;
            }
        }

        /// <summary>
        /// Load Groups To Group Combo
        /// </summary>
        private void LoadGroups()
        {
            SKUGroupController grpSku = new SKUGroupController();
            DataTable m_dt = grpSku.SelectSKUGroup(Constants.IntNullValue, null, int.Parse(SessionClass.CompanyID.ToString()));
            ddSKUSelectedGroup.DataSource = m_dt;
            ddSKUSelectedGroup.DisplayMember = "GROUP_NAME";
            ddSKUSelectedGroup.ValueMember = "SKU_GROUP_ID";
        }

        #endregion

        #region Promotion Offer

        /// <summary>
        /// Enables/Disables TextBoxes For Promotion Offer in Amount Or in Rate
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void rbtnDiscountRate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDiscountRate.Checked)
            {
                txtDiscountAmount.Enabled = false;
                txtDiscountRate.Enabled = true;
            }
            else
            {
                txtDiscountAmount.Enabled = true;
                txtDiscountRate.Enabled = false;
            }
        }
        private void rbtnDiscountAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDiscountRate.Checked)
            {
                txtDiscountAmount.Enabled = false;
                txtDiscountRate.Enabled = true;
            }
            else
            {
                txtDiscountAmount.Enabled = true;
                txtDiscountRate.Enabled = false;
            }
        }
       
        /// <summary>
        /// Loads Categories To Category Combo For Promotion Offer
        /// </summary>
        private void LoadSKUCategory2()
        {
            string PrincipalId = SessionClass.PRINCIPAL_ID.ToString();
            SkuHierarchyController mSkuHieController = new SkuHierarchyController();
            DataTable m_dt_cat2 = mSkuHieController.SelectDTSkuHierarchy01(2, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            ddPromotionCatagory.DataSource = m_dt_cat2;
            ddPromotionCatagory.DisplayMember = "SKU_HIE_NAME";
            ddPromotionCatagory.ValueMember = "SKU_HIE_ID";
            try
            {
                ddPromotionCatagory.SelectedIndex = 0;
            }
            catch (Exception)
            {}
        }

        /// <summary>
        /// Loads SKUS To SKU Combo For Promotion Offer
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddPromotionCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddPromotionCatagory.SelectedIndex > 0)
            {
                this.LoadSKUs2(); 
            }
        }

        /// <summary>
        /// Loads SKUS To SKU Combo For Promotion Offer
        /// </summary>
        private void LoadSKUs2()
        {
            ddPromotionSKU.DataSource = null;
            this.ddPromotionSKU.Items.Clear();

            //clsWebFormUtil.FillDropDownList(this.ddPromotionSKU, null);

            SkuController mSkuController = new SkuController();
            DataTable m_dt_sku2 = mSkuController.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.ddPromotionCatagory.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            ddPromotionSKU.DataSource = m_dt_sku2;
            ddPromotionSKU.DisplayMember = "SKUDETAIL";
            ddPromotionSKU.ValueMember = "SKU_ID";

        }

        #endregion

        /////////////////////////////////////////////////////// Promotion Slab ////////////////////////////////////////////////////////////////
        #region Promotion Slab

        /// <summary>
        /// Creates Datatable For Slab
        /// </summary>
        private void CreateSlabTable()
        {

            dt = new DataTable();
            DataColumn dc = new DataColumn("SLAB_NO", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SLAB NO", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKUID", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKUGROUPID", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("UOM", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("UOMID", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Slab On", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("From", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("To", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Discount", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU Offer", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU Quantity", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Is_Multiple", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Multiple_of", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Basket_on", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Edit", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Remove", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKUOfferID", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DiscountPercentage", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DiscountAmount", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            SessionClass.dt = dt;
            SessionClass.SlabNo = SlabNo;
        }

        /// <summary>
        /// Loads Slab Data
        /// </summary>
        private void LoadCloneSlabData()
        {
            DataControl dc = new DataControl();
            string PromotionId = (string)SessionClass.PromotionId;
            int BasketMasterId = 0;
            BasketController BCtl = new BasketController();
            dt = (DataTable)SessionClass.dt;
            SlabNo = Convert.ToInt32(SessionClass.SlabNo);
            DataTable dtBMaster = BCtl.GetBasketMaster(long.Parse(PromotionId));
            for (int nCount = 0; nCount < dtBMaster.Rows.Count; nCount++)
            {
                SlabNo = Convert.ToInt32(SessionClass.SlabNo);
                SlabNo++;
                DataRow dr1 = dt.NewRow();
                dr1["SLAB NO"] = "SLab # " + SlabNo;
                dr1["SLAB_NO"] = SlabNo.ToString();
                if (int.Parse(dc.chkNull_0(dtBMaster.Rows[nCount]["Basket_On"].ToString())) == Constants.Basket_On_Quantity)
                {
                    dr1["Basket_on"] = Constants.Basket_On_Quantity;

                }
                else
                {
                    dr1["Basket_on"] = Constants.Basket_On_Amount;
                }

                if (bool.Parse(dtBMaster.Rows[nCount]["IS_MULTIPLE"].ToString()) == true)
                {
                    dr1["Is_Multiple"] = "true";
                }
                else
                {
                    dr1["Is_Multiple"] = "false";
                }

                dr1["SKU"] = "";
                dr1["UOM"] = "";
                dr1["Slab On"] = "";
                dr1["From"] = "";
                dr1["To"] = "";
                dr1["Discount"] = "";
                dr1["SKU Offer"] = "";
                dr1["SKU Quantity"] = "";
                dr1["Remove"] = "";
                dr1["Edit"] = "";
                dt.Rows.Add(dr1);
                SessionClass.SlabNo = SlabNo;
                DataTable dtBasketDetail = BCtl.GetBasketDetailForSlab(int.Parse(dtBMaster.Rows[nCount]["BASKET_ID"].ToString()));
                this.CloneSlabDetailData(dtBasketDetail);
            }
            grdSlab.DataSource = dt;
            SessionClass.dt = dt;
        }

        /// <summary>
        /// Loads Slab From Session Variables For Nevigating Back From Forward Steps
        /// </summary>
        private void CloneSlabDetailData(DataTable dt1)
        {
            DataControl dc = new DataControl();
            DataTable dt = (DataTable)SessionClass.dt;
            for (int nCount = 0; nCount < dt1.Rows.Count; nCount++)
            {
                SlabNo = Convert.ToInt32(SessionClass.SlabNo);
                DataRow dr1 = dt.NewRow();
                dr1["SLAB_NO"] = SlabNo.ToString();
                if (int.Parse(dc.chkNull_0(dt1.Rows[nCount]["SKU_ID"].ToString())) > 0)
                {
                    dr1["SKU"] = dt1.Rows[nCount]["sku_name"].ToString();
                    dr1["SKUID"] = Convert.ToInt64(dt1.Rows[nCount]["sku_Id"].ToString());
                    dr1["SKUGROUPID"] = Constants.IntNullValue;
                }
                else
                {
                    dr1["SKU"] = dt1.Rows[nCount]["GROUP_NAME"].ToString(); ;
                    dr1["SKUGROUPID"] = dt1.Rows[nCount]["SKU_GROUP_ID"].ToString();
                    dr1["SKUID"] = Constants.IntNullValue;
                }

                dr1["UOM"] = dt1.Rows[nCount]["UOM_DESC"].ToString();
                dr1["UOMID"] = dt1.Rows[nCount]["UOM_ID"].ToString();
                if (int.Parse(dt1.Rows[nCount]["BASKET_ON"].ToString()) == Constants.Basket_On_Quantity)
                {
                    dr1["Slab On"] = "Quantity";
                }
                else
                {
                    dr1["Slab On"] = "Amount";
                }
                dr1["From"] = Convert.ToInt64(dt1.Rows[nCount]["MIN_VAL"].ToString());
                dr1["To"] = Convert.ToInt64(dt1.Rows[nCount]["MAX_VAL"].ToString());
                if (int.Parse(dt1.Rows[nCount]["BASKET_ON"].ToString()) == Constants.Basket_On_Quantity)
                {
                    dr1["Basket_on"] = Constants.Basket_On_Quantity;
                }
                else
                {
                    dr1["Basket_on"] = Constants.Basket_On_Amount;
                }
                if (decimal.Parse(dc.chkNull_0(dt1.Rows[nCount]["DISCOUNT"].ToString())) > 0)
                {
                    dr1["Discount"] = dt1.Rows[nCount]["DISCOUNT"].ToString() + "%";
                    dr1["DiscountPercentage"] = decimal.Parse(dt1.Rows[nCount]["DISCOUNT"].ToString());
                    dr1["DiscountAmount"] = "";
                }
                else if (decimal.Parse(dc.chkNull_0(dt1.Rows[nCount]["OFFER_VALUE"].ToString())) > 0)
                {
                    dr1["Discount"] = Math.Round(decimal.Parse(dt1.Rows[nCount]["OFFER_VALUE"].ToString()), 2) + "/-";
                    dr1["DiscountAmount"] = decimal.Parse(dt1.Rows[nCount]["OFFER_VALUE"].ToString());
                    dr1["DiscountPercentage"] = "";
                }

                if (decimal.Parse(dc.chkNull_0(dt1.Rows[nCount]["OFFERSKUID"].ToString())) > 0)
                {
                    dr1["SKUOfferID"] = dc.chkNull_0(dt1.Rows[nCount]["OFFERSKUID"].ToString());
                    dr1["SKU Offer"] = dc.chkNull_0(dt1.Rows[nCount]["OFFERSKUNAME"].ToString());
                    dr1["SKU Quantity"] = dc.chkNull_0(dt1.Rows[nCount]["QUANTITY"].ToString());

                }
                dr1["MULTIPLE_OF"] = dt1.Rows[nCount]["MULTIPLE_OF"].ToString();
                dt.Rows.Add(dr1);

            }
            SessionClass.dt = dt;
        }

        /// <summary>
        /// Loads Promotion Collection From Session Variables For Nevigating Back From Forward Steps
        /// </summary>
        private void LoadPromotionCollection3()
        {

            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;
            SlabNo = Convert.ToInt32(SessionClass.SlabNo);
            BasketCollection_Controller BColCntrl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl;
            dt = (DataTable)SessionClass.dt;
            for (int n = 0; n < BColCntrl.Count; n++)
            {
                Basket_Collection BCol = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(n);
                DataRow dr1 = dt.NewRow();
                SlabNo++;
                dr1["SLAB NO"] = "SLab # " + SlabNo;
                dr1["SLAB_NO"] = SlabNo.ToString();
                dr1["Basket_on"] = BCol.Basket_On;
                dr1["Is_Multiple"] = BCol.Is_Multiple;
                dr1["SKU"] = "";
                dr1["UOM"] = "";
                dr1["Slab On"] = "";
                dr1["From"] = "";
                dr1["To"] = "";
                dr1["Discount"] = "";
                dr1["SKU Offer"] = "";
                dr1["SKU Quantity"] = "";
                dr1["Remove"] = "";
                dr1["Edit"] = "";
                dt.Rows.Add(dr1);

                for (int i = 0; i < BCol.ObjBasketDtlCol_Cntrlr.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["SLAB NO"] = "";
                    dr["SLAB_NO"] = SlabNo.ToString();
                    if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID == Constants.IntNullValue)
                    {
                        SKUGroupController mGroupController = new SKUGroupController();

                        DataTable dtSkus = mGroupController.SelectSKUGroup(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID, null, int.Parse(SessionClass.CompanyID.ToString()));

                        if (dtSkus.Rows.Count > 0)
                        {
                            dr["SKU"] = dtSkus.Rows[0]["GROUP_NAME"].ToString();
                            dr["SKUGROUPID"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID;
                            dr["SKUID"] = Constants.IntNullValue;
                        }


                    }
                    else if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID == Constants.IntNullValue)
                    {

                        SkuController mSKUController = new SkuController();

                        DataTable dtSKu = mSKUController.SelectSkuData(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                        if (dtSKu.Rows.Count > 0)
                        {
                            dr["SKU"] = dtSKu.Rows[0]["SKU_CODE"].ToString() + " - " + dtSKu.Rows[0]["SKU_NAME"].ToString();
                            dr["SKUID"] = dtSKu.Rows[0]["SKU_ID"].ToString();
                            dr["SKUGROUPID"] = Constants.IntNullValue;
                        }

                    }
                    SkuController mSkController = new SkuController();

                    DataTable dtUoms = mSkController.SelectUOMs(BCol.ObjBasketDtlCol_Cntrlr.Get(i).UOM_ID, null);

                    if (dtUoms.Rows.Count > 0)
                    {
                        dr["UOM"] = dtUoms.Rows[0]["UOM_DESC"].ToString();
                    }


                    if (BCol.Basket_On == Constants.Basket_On_Amount)
                    {
                        dr["Slab On"] = "Amount";
                    }
                    else if (BCol.Basket_On == Constants.Basket_On_Quantity)
                    {
                        dr["Slab On"] = "Quantity";
                    }

                    dr["From"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Min_Val.ToString();
                    dr["To"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Max_Val.ToString();
                    dr["Multiple_Of"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Multiple_Of.ToString();

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Discount > 0)
                    {
                        dr["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Discount.ToString() + " %";
                        dr["DiscountPercentage"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Discount.ToString();
                        dr["DiscountAmount"] = Constants.DecimalNullValue;
                    }
                    else if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Offer_Value > 0)
                    {
                        dr["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Offer_Value.ToString() + "/-";
                        dr["DiscountAmount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Offer_Value.ToString();
                        dr["DiscountPercentage"] = Constants.FloatNullValue;

                    }
                    else
                    {
                        dr["Discount"] = "";
                    }

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).SKU_ID != Constants.IntNullValue)
                    {
                        SkuController mSKuController = new SkuController();

                        DataTable dtSku = mSKuController.SelectSkuData(BCol.ObjPromotionOfferCol_Cntrl.Get(i).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                        if (dtSku.Rows.Count > 0)
                        {
                            dr["SKUOfferID"] = dtSku.Rows[0]["SKU_ID"].ToString();
                            dr["SKU Offer"] = dtSku.Rows[0]["SKU_CODE"].ToString() + " - " + dtSku.Rows[0]["SKU_NAME"].ToString();
                        }

                    }
                    else
                    {
                        dr["SKUOfferID"] = Constants.IntNullValue;
                        dr["SKU Offer"] = "";
                    }

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Quantity != Constants.IntNullValue)
                    {
                        dr["SKU Quantity"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Quantity.ToString();
                    }
                    else
                    {
                        dr["SKU Quantity"] = "";
                    }
                    dt.Rows.Add(dr);

                }
                SessionClass.dt = dt;
                SessionClass.SlabNo = SlabNo;
            }
        }

        /// <summary>
        /// Creates New Slab
        /// </summary>
        private void CreatNewSlab()
        {
            chIsMultiple.Enabled = true;
            ddSlabOn.Enabled = false;
            rbSKUHierarchy.Enabled = true;
           // rbSKUGroup.Enabled = true;
            txtMultipleOf.Enabled = false;
            txtMultipleOf.Text = "";
            chIsMultiple.Checked = false;

            if (rbSKUGroup.Checked == true)
            {
                ddSKUSelectedGroup.Enabled = true;
            }
            if (rbSKUHierarchy.Checked == true)
            {
                ddSKUCatagory.Enabled = true;
                //ddSKUBrand.Enabled = true;
                ddSKU.Enabled = true;
            }

            SlabNo = Convert.ToInt32(SessionClass.SlabNo);
            dt = (DataTable)SessionClass.dt;
            SlabNo++;
            DataRow dr1 = dt.NewRow();
            dr1["SLAB NO"] = "SLab # " + SlabNo;
            dr1["SLAB_NO"] = SlabNo.ToString();
            if (ddSlabOn.SelectedValue == "Quantity")
            {
                dr1["Basket_on"] = Constants.Basket_On_Quantity;

            }
            else
            {
                dr1["Basket_on"] = Constants.Basket_On_Amount;
            }

            if (chIsMultiple.Checked == true)
            {
                dr1["Is_Multiple"] = "true";
            }
            else
            {
                dr1["Is_Multiple"] = "false";
            }

            dr1["SKU"] = "";
            dr1["UOM"] = "";
            dr1["Slab On"] = "";
            dr1["From"] = "";
            dr1["To"] = "";
            dr1["Discount"] = "";
            dr1["SKU Offer"] = "";
            dr1["SKU Quantity"] = "";
            dr1["Remove"] = "";
            dr1["Edit"] = "";
            dt.Rows.Add(dr1);
            grdSlab.DataSource = dt;
            SessionClass.dt = dt;
            SessionClass.SlabNo = SlabNo;
        }

        /// <summary>
        /// Loads Slabs To Slab Grid
        /// </summary>
        private void LoadGrid()
        {
            dt = (DataTable)SessionClass.dt;
            grdSlab.DataSource = dt.DefaultView;
        }

       
        /// <summary>
        /// Enables/Disable IsMultiple TextBox For Slab
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void chIsMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsMultiple.Checked == true)
            {
                txtMultipleOf.Enabled = true;
                txtMultipleOf.Focus();
            }
            else
            {
                txtMultipleOf.Enabled = false;
                txtMultipleOf.Text = "";
            }
        }

        /// <summary>
        /// Sets Text For Quanity Labels Either Quantity Or Amount
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void ddSlabOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFrom.Text = "From " + ddSlabOn.Text;
            lblTo.Text = "To " + ddSlabOn.Text;
        }

        /// <summary>
        /// Adds Or Updates Slab
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnAddtoSlab_Click(object sender, EventArgs e)
        {
            if (chDiscount.Checked == false && chSKU.Checked == false)
            {
                MessageBox.Show(this, "Please Make Some Promotion Offer as Discount or Item");
                return;
            }
            if (txtFrom.TextLength == 0 )
            {
                MessageBox.Show(this, "Please Enter From Range");
                return;
            }
            if (txtTo.TextLength == 0)
            {
                MessageBox.Show(this, "Please Enter To Range");
                return;
            }
            DataRow dr1;
            dt = (DataTable)SessionClass.dt;
            if (btnAddtoSlab.Text == "Add To Slab")
            {
                if (rbSKUHierarchy.Checked == true && ddSKU.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Please Select Item");
                    return;
                }
                #region Add New Slab Detail on Last Index
                SlabNo = Convert.ToInt32(SessionClass.SlabNo);
                dr1 = dt.NewRow();
                dr1["SLAB_NO"] = SlabNo.ToString();
                if (rbSKUHierarchy.Checked == true)
                {
                    dr1["SKU"] = ddSKU.Text;
                    dr1["SKUID"] = ddSKU.SelectedValue.ToString();
                    dr1["SKUGROUPID"] = Constants.IntNullValue;
                }
                else if (rbSKUGroup.Checked == true)
                {
                    dr1["SKU"] = ddSKUSelectedGroup.Text;
                    dr1["SKUGROUPID"] = ddSKUSelectedGroup.SelectedValue.ToString();
                    dr1["SKUID"] = Constants.IntNullValue;
                }

                dr1["UOM"] = "Piece";
                dr1["Slab On"] = ddSlabOn.Text;
                dr1["From"] = txtFrom.Text;
                dr1["To"] = txtTo.Text;
                dr1["UOMID"] = "10";
                if (ddSlabOn.SelectedItem.ToString() == "Quantity")
                {
                    dr1["Basket_on"] = Constants.Basket_On_Quantity;
                }
                else
                {
                    dr1["Basket_on"] = Constants.Basket_On_Amount;
                }
                if (chDiscount.Checked == true)
                {
                    if (rbtnDiscountRate.Checked)
                    {
                        dr1["Discount"] = txtDiscountRate.Text + " %";
                        dr1["DiscountPercentage"] = txtDiscountRate.Text;
                        dr1["DiscountAmount"] = Constants.DecimalNullValue;
                    }
                    else
                    {
                        dr1["Discount"] = txtDiscountAmount.Text + "/-";
                        dr1["DiscountAmount"] = txtDiscountAmount.Text;
                        dr1["DiscountPercentage"] = Constants.FloatNullValue;
                    }
                }
                if (chSKU.Checked == true)
                {
                    dr1["SKUOfferID"] = ddPromotionSKU.SelectedValue.ToString();
                    dr1["SKU Offer"] = ddPromotionSKU.Text;
                    dr1["SKU Quantity"] = txtPromotionQuantity.Text;

                }
                if (chIsMultiple.Checked == true)
                {
                    dr1["Multiple_of"] = int.Parse(txtMultipleOf.Text).ToString();
                }
                else
                {
                    dr1["Multiple_of"] = "0";
                }
                dt.Rows.Add(dr1);
                grdSlab.DataSource = dt;
                SessionClass.dt = dt;
                this.OfferEmpty();
                #endregion

                #region Update Priviouse Slab Detail aginst New Record
                bool flag = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == dr1[0].ToString())
                    {
                        DataRow dr2 = dt.Rows[i];
                        if (flag != true)
                        {
                            dr2["Is_Multiple"] = chIsMultiple.Checked.ToString();
                            flag = true;
                        }
                        else
                        {
                            dr2["Is_Multiple"] = "";
                            if (rbSKUHierarchy.Checked == true)
                            { dr2["SKU"] = ddSKU.Text; }
                            else
                            { dr2["SKU"] = ddSKUSelectedGroup.Text; }
                            dr2["Slab On"] = dr1["Slab On"];
                            dr2["UOM"] = dr1["UOM"].ToString();
                        }
                        if (rbSKUHierarchy.Checked == true)
                        {

                            dr2["SKUID"] = ddSKU.SelectedValue.ToString();
                            dr2["SKUGROUPID"] = Constants.IntNullValue;
                        }
                        else if (rbSKUGroup.Checked == true)
                        {


                            dr2["SKUGROUPID"] = ddSKUSelectedGroup.SelectedValue.ToString();
                            dr2["SKUID"] = Constants.IntNullValue;
                        }
                        dr2["Basket_On"] = dr1["Basket_on"];
                        dr2["UOMID"] = dr1["UOMID"];

                    }
                }
                dt.DefaultView.Sort = "Slab_NO";
                grdSlab.DataSource = dt.DefaultView;
                SessionClass.dt = dt;
                this.OfferEmpty();
                btnAddtoSlab.Text = "Add To Slab";
                btnCreateNewSlab.Enabled = true;
                btnNext.Enabled = true;
                #endregion
            }
            else if (btnAddtoSlab.Text == "Update Slab")
            {
                #region Update Slab Detail
                string Id = dt.Rows[RowNo][0].ToString();
                dr1 = dt.Rows[RowNo];
                dr1["UOM"] = "Piece";
                dr1["Slab On"] = ddSlabOn.Text;
                dr1["From"] = txtFrom.Text;
                dr1["To"] = txtTo.Text;
                dr1["UOMID"] = "10";
                if (ddSlabOn.SelectedValue == "Quantity")
                {
                    dr1["Basket_on"] = Constants.Basket_On_Quantity;
                }
                else
                {
                    dr1["Basket_on"] = Constants.Basket_On_Amount;
                }
                if (chDiscount.Checked == true)
                {
                    if (rbtnDiscountRate.Checked == true)
                    {
                        dr1["Discount"] = txtDiscountRate.Text + " %";
                        dr1["DiscountPercentage"] = txtDiscountRate.Text;
                        dr1["DiscountAmount"] = Constants.DecimalNullValue;
                    }
                    else
                    {
                        dr1["DiscountAmount"] = txtDiscountAmount.Text;
                        dr1["Discount"] = txtDiscountAmount.Text + "/-";
                        dr1["DiscountPercentage"] = Constants.FloatNullValue;
                    }
                }
                else
                {
                    dr1["Discount"] = DBNull.Value;
                    dr1["DiscountPercentage"] = DBNull.Value;
                    dr1["DiscountAmount"] = DBNull.Value;
                }
                if (chSKU.Checked == true)
                {
                    dr1["SKUOfferID"] = ddPromotionSKU.SelectedValue.ToString();
                    dr1["SKU Offer"] = ddPromotionSKU.Text;
                    dr1["SKU Quantity"] = txtPromotionQuantity.Text;

                }
                else
                {
                    dr1["SKUOfferID"] = DBNull.Value;
                    dr1["SKU Offer"] = DBNull.Value;
                    dr1["SKU Quantity"] = DBNull.Value;
                }
                if (chIsMultiple.Checked == true)
                {
                    dr1["Multiple_of"] = int.Parse(txtMultipleOf.Text).ToString();
                }
                else
                {
                    dr1["Multiple_of"] = "0";
                }

                //dt.DefaultView.Sort = "Slab_NO";  
                grdSlab.DataSource = dt;
                SessionClass.dt = dt;
                this.OfferEmpty();
                btnAddtoSlab.Text = "Add To Slab";
                btnCreateNewSlab.Enabled = true;
                btnNext.Enabled = true;
                #endregion
            }
            else
            {
                #region Add New Existing Slab at Meddle

                dr1 = dt.NewRow();
                dr1["SLAB_NO"] = int.Parse(btnAddtoSlab.Text.Substring(12));
                if (rbSKUHierarchy.Checked == true)
                {
                    dr1["SKU"] = ddSKU.Text;
                    dr1["SKUID"] = ddSKU.SelectedValue.ToString();
                    dr1["SKUGROUPID"] = Constants.IntNullValue;
                }
                else if (rbSKUGroup.Checked == true)
                {
                    dr1["SKU"] = ddSKUSelectedGroup.Text;
                    dr1["SKUGROUPID"] = ddSKUSelectedGroup.SelectedValue.ToString();
                    dr1["SKUID"] = Constants.IntNullValue;
                }

                dr1["UOM"] = "Piece";
                dr1["Slab On"] = ddSlabOn.SelectedValue;
                dr1["From"] = txtFrom.Text;
                dr1["To"] = txtTo.Text;
                dr1["UOMID"] = "10";
                if (ddSlabOn.SelectedValue == "Quantity")
                {
                    dr1["Basket_on"] = Constants.Basket_On_Quantity;
                }
                else
                {
                    dr1["Basket_on"] = Constants.Basket_On_Amount;
                }
                if (chDiscount.Checked == true)
                {
                    if (rbtnDiscountRate.Checked == true)
                    {
                        dr1["Discount"] = txtDiscountRate.Text + " %";
                        dr1["DiscountPercentage"] = txtDiscountRate.Text;
                        dr1["DiscountAmount"] = Constants.DecimalNullValue;
                    }
                    else
                    {
                        dr1["Discount"] = txtDiscountAmount.Text + "/-";
                        dr1["DiscountAmount"] = txtDiscountAmount.Text;
                        dr1["DiscountPercentage"] = Constants.FloatNullValue;
                    }
                }
                if (chSKU.Checked == true)
                {
                    dr1["SKUOfferID"] = ddPromotionSKU.SelectedValue.ToString();
                    dr1["SKU Offer"] = ddPromotionSKU.Text;
                    dr1["SKU Quantity"] = txtPromotionQuantity.Text;

                }
                if (chIsMultiple.Checked == true)
                {
                    dr1["Multiple_of"] = int.Parse(txtMultipleOf.Text).ToString();
                }
                else
                {
                    dr1["Multiple_of"] = "0";
                }
                dt.Rows.Add(dr1);
                grdSlab.DataSource = dt;
                SessionClass.dt = dt;
                this.OfferEmpty();


                #endregion

                #region Update Priviouse Slab Detail aginst New Record
                bool flag = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == dr1[0].ToString())
                    {
                        DataRow dr2 = dt.Rows[i];
                        if (flag != true)
                        {
                            dr2["Is_Multiple"] = chIsMultiple.Checked.ToString();
                            flag = true;
                        }
                        else
                        {
                            dr2["Is_Multiple"] = "";
                            if (rbSKUHierarchy.Checked == true)
                            { dr2["SKU"] = ddSKU.Text; }
                            else
                            { dr2["SKU"] = ddSKUSelectedGroup.Text; }
                            dr2["Slab On"] = dr1["Slab On"];
                            dr2["UOM"] = dr1["UOM"].ToString();
                        }
                        if (rbSKUHierarchy.Checked == true)
                        {

                            dr2["SKUID"] = ddSKU.SelectedValue.ToString();
                            dr2["SKUGROUPID"] = Constants.IntNullValue;
                        }
                        else if (rbSKUGroup.Checked == true)
                        {


                            dr2["SKUGROUPID"] = ddSKUSelectedGroup.SelectedValue.ToString();
                            dr2["SKUID"] = Constants.IntNullValue;
                        }
                        dr2["Basket_On"] = dr1["Basket_on"];
                        dr2["UOMID"] = dr1["UOMID"];

                    }
                }
                dt.DefaultView.Sort = "Slab_NO";
                grdSlab.DataSource = dt.DefaultView;
                SessionClass.dt = dt;
                this.OfferEmpty();
                btnAddtoSlab.Text = "Add To Slab";
                btnCreateNewSlab.Enabled = true;
                btnNext.Enabled = true;
                #endregion
            }
            rbSKUHierarchy.Enabled = false;
            rbSKUGroup.Enabled = false;
            ddSKUCatagory.Enabled = false;
            // ddSKUBrand.Enabled = false;
            ddSKU.Enabled = false;
            ddSKUSelectedGroup.Enabled = false;
            ArrangeGrid();
        }

        /// <summary>
        /// Creates New Datatable For Slab And Enables All Related Controls For New Slab
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnCreateNewSlab_Click(object sender, EventArgs e)
        {
            this.CreatNewSlab();
            rbSKUHierarchy.Enabled = true;
            rbSKUGroup.Enabled = true;
            ddSKUCatagory.Enabled = true;
            //  ddSKUBrand.Enabled = true;
            ddSKU.Enabled = true;
            ddSKUSelectedGroup.Enabled = true;
            ArrangeGrid();
        }

        /// <summary>
        /// Redirects To Step2
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnBack3_Click(object sender, EventArgs e)
        {
            SessionClass.flow = "b";
            Slider.SelectedPage = Step2;
        }

        /// <summary>
        /// Loads Promotion Collection And Slabs To Session Variable And Redirects To Step4
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnNext3_Click(object sender, EventArgs e)
        {
            DataControl dc = new DataControl();
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;
            Promotion_Collection pc = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);
            pc.ObjBasketCol_Cntrl = new BasketCollection_Controller();
            Basket_Collection BCol = null;

            dt = (DataTable)SessionClass.dt;

            foreach (DataRowView drv in dt.DefaultView)
            {
                if (!drv[1].ToString().Trim().Equals(""))
                {

                    BCol = new Basket_Collection();
                    BCol.ObjPromotionOfferCol_Cntrl = new PromotionOfferColl_Controller();
                    BCol.ObjBasketDtlCol_Cntrlr = new BasketDetailCollection_Controller();
                    BCol.Is_Basket = false;
                    BCol.Is_And = false;
                    BCol.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                    BCol.Basket_On = int.Parse(drv["Basket_on"].ToString());
                    BCol.Basket_ID = Constants.LongNullValue;
                    BCol.Basket_Selection = Constants.IntNullValue;

                    if (!drv["Is_Multiple"].ToString().Equals(""))
                    {
                        BCol.Is_Multiple = bool.Parse(drv["Is_Multiple"].ToString());
                    }
                    pc.ObjBasketCol_Cntrl.Add(BCol);
                }
                else
                {
                    Basket_Detail_Collection BDCol = new Basket_Detail_Collection();

                    BDCol.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                    BDCol.Min_Val = int.Parse(drv["From"].ToString());
                    BDCol.Max_Val = int.Parse(drv["To"].ToString());
                    BDCol.Multiple_Of = int.Parse(dc.chkNull(drv["Multiple_of"].ToString()));
                    BDCol.SKU_ID = int.Parse(dc.chkNull(drv["SKUID"].ToString()));
                    BDCol.SKUGroup_ID = int.Parse(dc.chkNull(drv["SKUGROUPID"].ToString()));
                    BDCol.UOM_ID = int.Parse(dc.chkNull(drv["UOMID"].ToString()));
                    BDCol.SKUCompany_ID = Constants.IntNullValue;
                    BDCol.SKUDiv_ID = Constants.IntNullValue;
                    BDCol.SKUCatg_ID = Constants.IntNullValue;
                    BDCol.SKUBrand_ID = Constants.IntNullValue;
                    BDCol.SKUProductLine_ID = Constants.IntNullValue;
                    if (BDCol == null)
                    {
                        BCol.ObjBasketDtlCol_Cntrlr.Add(null);
                    }
                    else
                    {
                        BCol.ObjBasketDtlCol_Cntrlr.Add(BDCol); 
                    }

                    PromotionOffer_Collection POfferCol = new PromotionOffer_Collection();

                    POfferCol.Dist_ID = Convert.ToInt32(SessionClass.DISTRIBUTOR_ID);
                    POfferCol.Is_And = false;
                    if (int.Parse(dc.chkNull(drv["SKUOfferID"].ToString())) > 0)
                    {
                        POfferCol.SKU_ID = int.Parse(drv["SKUOfferID"].ToString());
                    }
                    else
                    {
                        POfferCol.SKU_ID = Constants.IntNullValue;
                    }
                    POfferCol.UOM_ID = int.Parse(dc.chkNull(drv["UOMID"].ToString()));

                    if (int.Parse(dc.chkNull(drv["SKU Quantity"].ToString())) > 0)
                    {
                        POfferCol.Quantity = int.Parse(dc.chkNull(drv["SKU Quantity"].ToString()));
                    }
                    else
                    {
                        POfferCol.Quantity = Constants.IntNullValue;
                    }
                    if (float.Parse(dc.chkNull_0(drv["DiscountPercentage"].ToString())) > 0)
                    {
                        POfferCol.Discount = float.Parse(dc.chkNull(drv["DiscountPercentage"].ToString()));
                        POfferCol.Offer_Value = Constants.DecimalNullValue;
                    }
                    else
                    {
                        POfferCol.Offer_Value = decimal.Parse(dc.chkNull(drv["DiscountAmount"].ToString()));
                        POfferCol.Discount = Constants.FloatNullValue;
                    }

                    BCol.ObjPromotionOfferCol_Cntrl.Add(POfferCol);
                }
            }

            Slider.SelectedPage = Step4;
            SessionClass.flow = "f";
            LoadStep4();
        }
        #endregion 

        #region Edit or Delete Grid Of Slab
        private void grdSlab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = grdSlab.CurrentCell.RowIndex;
            if (e.ColumnIndex == grdSlab.Columns["Edit1"].Index)
            {
                EditSlab(_rowIndex);
            }
            if (e.ColumnIndex == grdSlab.Columns["Delete"].Index)
            {
                DeleteSlab(_rowIndex);
            }
        }

        #region Edit Slab
        public void EditSlab(int _rowIndex)
        {
            DataControl dc = new DataControl();
            dt = (DataTable)SessionClass.dt;
            DataRowView drv = dt.DefaultView[_rowIndex];
            RowNo = _rowIndex;
            if (drv["Slab No"].ToString().Trim().Equals(""))
            {
                if (int.Parse(dc.chkNull_0(drv["SKUID"].ToString())) > 0)
                {
                    for (int i = 0; i < ddSKU.Items.Count; i++)
                    {
                        ddSKU.SelectedIndex = i;
                        if (int.Parse(ddSKU.SelectedValue.ToString()) == int.Parse(dc.chkNull_0(drv["SKUID"].ToString())))
                        {
                            ddSKU.SelectedIndex = i;
                            break;
                        }
                    }
                    rbSKUHierarchy.Checked = true;
                    rbSKUGroup.Checked = false;
                    ddSKU.Enabled = true;
                    rbSKUGroup.Checked = false;
                    ddSKUSelectedGroup.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < ddSKUSelectedGroup.Items.Count; i++)
                    {
                        ddSKUSelectedGroup.SelectedIndex = i;
                        if (int.Parse(ddSKUSelectedGroup.SelectedValue.ToString()) == int.Parse(dc.chkNull_0(drv["SKUGROUPID"].ToString())))
                        {
                            ddSKUSelectedGroup.SelectedIndex = i;
                            break;
                        }
                    }
                    rbSKUGroup.Checked = true;
                    rbSKUHierarchy.Checked = false;
                    ddSKUSelectedGroup.Enabled = true;
                    rbSKUHierarchy.Enabled = false;
                    ddSKU.Enabled = false;
                }
                this.txtMultipleOf.Text = drv["Multiple_of"].ToString();
                if (int.Parse(dc.chkNull_0(this.txtMultipleOf.Text)) > 0)
                {
                    chIsMultiple.Checked = true;
                    txtMultipleOf.Enabled = true;
                }
                else
                {
                    chIsMultiple.Checked = false;
                    txtMultipleOf.Enabled = false;
                }
                this.txtFrom.Text = drv["From"].ToString();
                this.txtTo.Text = drv["To"].ToString();
                this.ddSlabOn.SelectedValue = drv["Basket_on"].ToString();

                if (decimal.Parse(dc.chkNull_0(drv["DiscountAmount"].ToString())) <= 0)
                {
                    rbtnDiscountRate.Checked = true;
                    this.txtDiscountRate.Text = dc.chkNull_0(drv["DiscountPercentage"].ToString());
                    this.txtDiscountRate.Enabled = true;
                    this.txtDiscountAmount.Text = "";
                }
                else
                {
                    rbtnDiscountAmount.Checked = true;
                    this.txtDiscountAmount.Text = dc.chkNull_0(drv["DiscountAmount"].ToString());
                    this.txtDiscountAmount.Enabled = true;
                    this.txtDiscountRate.Text = "";
                }
                if (!drv["Discount"].ToString().Trim().Equals(""))
                {
                    chDiscount.Checked = true;
                }
                if (int.Parse(dc.chkNull_0(drv["SKU Quantity"].ToString())) > 0)
                {
                    chSKU.Checked = true;
                }
                for (int i = 0; i < ddPromotionSKU.Items.Count; i++)
                {
                    ddPromotionSKU.SelectedIndex = i;
                    if (int.Parse(ddPromotionSKU.SelectedValue.ToString()) == int.Parse(dc.chkNull_0(drv["SKUOfferID"].ToString())))
                    {
                        ddPromotionSKU.SelectedIndex = i;
                        break;
                    }
                }
                this.txtPromotionQuantity.Text = dc.chkNull_0(drv["SKU Quantity"].ToString());

                btnAddtoSlab.Text = "Update Slab";
                btnCreateNewSlab.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnAddtoSlab.Text = "Add To Slab#" + drv["Slab_No"].ToString();
                btnCreateNewSlab.Enabled = false;
                btnNext.Enabled = false;
            }
        }
        #endregion

        #region Delete Slab
        public void DeleteSlab(int _rowIndex)
        {
            try
            {
                int RowPosition = _rowIndex;
                dt = (DataTable)SessionClass.dt;
                DataRowView drv = dt.DefaultView[RowPosition];
                string SlabValue = drv[0].ToString();
                string Column2 = drv[1].ToString();
                int RowCount = dt.Rows.Count - 1;

                if (Column2.Trim() != "")
                {
                    for (int i = RowCount; i > 0; i--)
                    {
                        if (dt.Rows[i][0].ToString().Trim() == SlabValue)
                        {
                            dt.Rows[i].Delete();
                        }
                    }
                }
                else
                {
                    drv.Delete();
                }
                dt.AcceptChanges();
                SessionClass.dt = dt;
                this.LoadGrid();
            }
            catch (Exception )
            {
                // lblErrorMessage.Text = Ex.Message;
            }
            finally
            {
            }
        }
        #endregion 
        #endregion

        #endregion

        //////////////////////////////////////////////////////// Step 4 ///////////////////////////////////////////////////

        #region Promotion Step 4
        public void LoadStep4()
        {
            SkuController mSkuController = new SkuController();
            DataTable m_dt_Sku = mSkuController.SelectSkuData(Constants.IntNullValue, int.Parse(SessionClass.CompanyID.ToString()));
            clsListItems[] clsSKUItems = new clsListItems[m_dt_Sku.Rows.Count + 1];
            clsListItems[] clsSKUGroupItems = (clsListItems[])SessionClass.clsSKUGroupItems;
            clsListItems[] clsUOMItems = (clsListItems[])SessionClass.clsUOMItems;
            clsDetailListItems[] DistributorListItems = (clsDetailListItems[])SessionClass.DistributorListItems;
            clsDetailListItems[] CustTypeListItems = (clsDetailListItems[])SessionClass.CustTypeListItems;
            clsDetailListItems[] CustListItems = (clsDetailListItems[])SessionClass.CustListItems;

            clsSKUItems[0] = new clsListItems("ALL", "0");

            for (int i = 0; i < m_dt_Sku.Rows.Count; i++)
            {
                DataRow dRow = m_dt_Sku.Rows[i];
                clsSKUItems[i + 1] = new clsListItems(dRow[2].ToString(), dRow[0].ToString());
            }
            SessionClass.clsSKUItems = clsSKUItems;
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("BASKET NO", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("UOM", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Basket On", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("From", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("To", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Discount", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU Offer", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SKU Quantity", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Is_Multiple", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Is_Bundled", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);


            // Scheme Loading
            SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
            SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;

            string summary = "Scheme Code : " + SchCtrl.Get(0).Scheme_Code + "\r\nPromotion Name : " + SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Code + "\r\nPromotion For : \r\n";
            for (int i = 0; i < SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl.Count; i++)
            {
                long id = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl.Get(i).Assigned_Dist_ID;

                DistributorController mDistController = new DistributorController();

                DataTable m_dt_Dist = mDistController.SelectDistributor(int.Parse(id.ToString()));

                if (m_dt_Dist.Rows.Count > 0)
                {
                    summary = summary + m_dt_Dist.Rows[0]["DISTRIBUTOR_NAME"].ToString() + "\r\n";
                }
            }
            summary = summary + "\r\nPromotions for Customer type : \r\n";
            for (int i = 0; i < SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl.Count; i++)
            {
                long id = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl.Get(i).Customer_Type_ID;

                SLASHCodesController Slash_Codes = new SLASHCodesController();

                DataTable dtSlashCodes = Slash_Codes.SelectSlashCodes(int.Parse(id.ToString()), null, Constants.CustomerChannelType, null, Constants.IntNullValue, true);

                if (dtSlashCodes.Rows.Count > 0)
                {
                    summary = summary + dtSlashCodes.Rows[0]["SLASH_DESC"].ToString() + "\r\n";
                }
            }

            BasketCollection_Controller BColCntrl = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl;
            txtSummary.Text = summary;
            if (BColCntrl.Get(0).Is_Basket == true)
            {
                for (int n = 0; n < BColCntrl.Count; n++)
                {
                    Basket_Collection BCol = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(n);

                    int numBasket = n + 1;
                    DataRow dr1 = dt.NewRow();
                    dr1["BASKET NO"] = "Basket # " + numBasket;
                    dr1["SKU"] = "";
                    dr1["UOM"] = "";
                    dr1["Basket On"] = "";
                    dr1["From"] = "";
                    dr1["To"] = "";

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(0).Discount != Constants.FloatNullValue)
                    {
                        dr1["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(0).Discount.ToString() + " %";
                    }
                    else if (BCol.ObjPromotionOfferCol_Cntrl.Get(0).Offer_Value > 0)
                    {
                        dr1["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(0).Offer_Value.ToString() + " /-";
                    }
                    else
                    {
                        dr1["Discount"] = "";
                    }

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(0).SKU_ID != Constants.IntNullValue)
                    {
                        //dr1["SKU Offer"] = returnSKU(BCol.ObjPromotionOfferCol_Cntrl.Get(0).SKU_ID);
                        SkuController mSKUController = new SkuController();

                        DataTable dtSKUs = mSKUController.SelectSkuData(BCol.ObjPromotionOfferCol_Cntrl.Get(0).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                        if (dtSKUs.Rows.Count > 0)
                        {
                            dr1["SKU Offer"] = dtSKUs.Rows[0]["SKU_Code"].ToString() + " - " + dtSKUs.Rows[0]["SKU_NAME"].ToString();

                        }
                    }
                    else
                    {
                        dr1["SKU Offer"] = "";
                    }

                    if (BCol.ObjPromotionOfferCol_Cntrl.Get(0).Quantity != Constants.IntNullValue)
                    {
                        dr1["SKU Quantity"] = BCol.ObjPromotionOfferCol_Cntrl.Get(0).Quantity.ToString();
                    }
                    else
                    {
                        dr1["SKU Quantity"] = "";
                    }
                    dr1["Is_Multiple"] = BCol.Is_Multiple;
                    dr1["Is_Bundled"] = BCol.Is_Bundled;

                    dt.Rows.Add(dr1);

                    for (int i = 0; i < BCol.ObjBasketDtlCol_Cntrlr.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BASKET NO"] = "";
                        if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID == Constants.IntNullValue)
                        {
                            SKUGroupController mGroupController = new SKUGroupController();

                            DataTable dtSkus = mGroupController.SelectSKUGroup(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID, null, int.Parse(SessionClass.CompanyID.ToString()));

                            if (dtSkus.Rows.Count > 0)
                            {
                                dr["SKU"] = dtSkus.Rows[0]["GROUP_NAME"].ToString();
                            }

                        }
                        else if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID == Constants.IntNullValue)
                        {

                            SkuController mSkUController = new SkuController();

                            DataTable dtSKu = mSkUController.SelectSkuData(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                            if (dtSKu.Rows.Count > 0)
                            {
                                dr["SKU"] = dtSKu.Rows[0]["SKU_Code"].ToString() + " - " + dtSKu.Rows[0]["SKU_NAME"].ToString();
                            }
                        }
                        //dr["UOM"] = "Pcs"; // Has to be changed later

                        SkuController mSkController = new SkuController();

                        DataTable dtUOMs = mSkController.SelectUOMs(BCol.ObjBasketDtlCol_Cntrlr.Get(i).UOM_ID, null);

                        if (dtUOMs.Rows.Count > 0)
                        {
                            dr["UOM"] = dtUOMs.Rows[0]["UOM_DESC"].ToString();

                        }

                        if (BCol.Basket_On == Constants.Basket_On_Amount)
                        {
                            dr["Basket On"] = "Amount";
                        }
                        else if (BCol.Basket_On == Constants.Basket_On_Quantity)
                        {
                            dr["Basket On"] = "Quantity";
                        }

                        dr["From"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Min_Val.ToString();
                        dr["To"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Max_Val.ToString();
                        dr["Discount"] = "";
                        dr["SKU Offer"] = "";
                        dr["SKU Quantity"] = "";

                        dt.Rows.Add(dr);

                    }
                    //Inner Loop
                }
                //Outer Loop
                grdPromotion.DataSource = dt;
            }
            else
            {
                for (int n = 0; n < BColCntrl.Count; n++)
                {
                    Basket_Collection BCol = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(n);

                    int numSlab = n + 1;
                    DataRow dr1 = dt.NewRow();
                    dr1["BASKET NO"] = "Slab # " + numSlab;
                    dr1["SKU"] = "";
                    dr1["UOM"] = "";
                    dr1["Basket On"] = "";
                    dr1["From"] = "";
                    dr1["To"] = "";
                    dr1["Discount"] = "";
                    dr1["SKU Offer"] = "";
                    dr1["SKU Quantity"] = "";
                    dr1["Is_Multiple"] = BCol.Is_Multiple;
                    dr1["Is_Bundled"] = BCol.Is_And;
                    dt.Rows.Add(dr1);

                    for (int i = 0; i < BCol.ObjBasketDtlCol_Cntrlr.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BASKET NO"] = "";
                        if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID == Constants.IntNullValue)
                        {
                            SKUGroupController mGroupController = new SKUGroupController();

                            DataTable dtSkus = mGroupController.SelectSKUGroup(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID, null, int.Parse(SessionClass.CompanyID.ToString()));

                            if (dtSkus.Rows.Count > 0)
                            {
                                dr["SKU"] = dtSkus.Rows[0]["GROUP_NAME"].ToString();
                            }


                        }
                        else if (BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKUGroup_ID == Constants.IntNullValue)
                        {

                            SkuController mSKUController = new SkuController();

                            DataTable dtSKu = mSKUController.SelectSkuData(BCol.ObjBasketDtlCol_Cntrlr.Get(i).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                            if (dtSKu.Rows.Count > 0)
                            {
                                dr["SKU"] = dtSKu.Rows[0]["SKU_Code"].ToString() + " - " + dtSKu.Rows[0]["SKU_NAME"].ToString();

                            }

                        }
                        SkuController mSkController = new SkuController();

                        DataTable dtUoms = mSkController.SelectUOMs(BCol.ObjBasketDtlCol_Cntrlr.Get(i).UOM_ID, null);

                        if (dtUoms.Rows.Count > 0)
                        {
                            dr["UOM"] = dtUoms.Rows[0]["UOM_DESC"].ToString();
                        }


                        if (BCol.Basket_On == Constants.Basket_On_Amount)
                        {
                            dr["Basket On"] = "Amount";
                        }
                        else if (BCol.Basket_On == Constants.Basket_On_Quantity)
                        {
                            dr["Basket On"] = "Quantity";
                        }

                        dr["From"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Min_Val.ToString();
                        dr["To"] = BCol.ObjBasketDtlCol_Cntrlr.Get(i).Max_Val.ToString();

                        if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Discount > 0)
                        {
                            dr["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Discount.ToString() + " %";
                        }
                        else if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Offer_Value > 0)
                        {
                            dr["Discount"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Offer_Value.ToString() + "/-";
                        }
                        else
                        {
                            dr["Discount"] = "";
                        }

                        if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).SKU_ID != Constants.IntNullValue)
                        {
                            SkuController mSKuController = new SkuController();

                            DataTable dtSku = mSKuController.SelectSkuData(BCol.ObjPromotionOfferCol_Cntrl.Get(i).SKU_ID, int.Parse(SessionClass.CompanyID.ToString()));

                            if (dtSku.Rows.Count > 0)
                            {
                                dr["SKU Offer"] = dtSku.Rows[0]["SKU_Code"].ToString() + " - " + dtSku.Rows[0]["SKU_NAME"].ToString();
                            }

                        }
                        else
                        {
                            dr["SKU Offer"] = "";
                        }

                        if (BCol.ObjPromotionOfferCol_Cntrl.Get(i).Quantity != Constants.IntNullValue)
                        {
                            dr["SKU Quantity"] = BCol.ObjPromotionOfferCol_Cntrl.Get(i).Quantity.ToString();
                        }
                        else
                        {
                            dr["SKU Quantity"] = "";
                        }

                        dt.Rows.Add(dr);
                    }
                    //Inner Loop
                }
                //Outer Loop
                grdPromotion.DataSource = dt;
                grdPromotion.Columns[0].HeaderText = "Slab No";
                grdPromotion.Columns[5].HeaderText = "Slab On";
                grdPromotion.Columns[2].Visible = false;
            }
        }

        /// <summary>
        /// Inserts All Promotion Related Data To Database
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            string url;
            try
            {
                #region Loading Scheme

                SchemeCollection_Controller SchCtrl = new SchemeCollection_Controller();
                SchCtrl = (SchemeCollection_Controller)SessionClass.SchCtrl;

                #endregion

                #region Inserting Scheme

                int SchemeID = 0;
                if (SchCtrl.Get(0).Scheme_ID == 0)
                {
                    //Scheme Insertion
                    SchemeController mSchemeController = new SchemeController();
                    SchemeID = int.Parse(mSchemeController.InsertScheme(SchCtrl.Get(0).Dist_ID, SchCtrl.Get(0).Scheme_Code, SchCtrl.Get(0).Scheme_Desc, System.DateTime.Now));
                }
                else
                {
                    SchemeID = SchCtrl.Get(0).Scheme_ID;
                }

                #endregion

                #region Insert Promotion

                Promotion_Collection Pro = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);

                PromotionController mPromotionController = new PromotionController();
                Pro.Promotion_Date = System.DateTime.Now;
                long PromotionID = long.Parse(mPromotionController.InsertPromotion(SchemeID, Pro.Dist_ID, Pro.Promotion_Code, Pro.Promotion_Desc, Pro.Promotion_Date, Pro.Claimable, Pro.Start_Date, Pro.End_Date, Pro.Is_Active, Pro.Promotion_Type, Pro.Promotion_Selection, Pro.Is_Scheme, Pro.Promotion_For, int.Parse(SessionClass.UserID.ToString())));

                #endregion

                #region Promotion for Distributor

                PromotionController PCtl = new PromotionController();
                for (int i = 0; i < Pro.ObjPromotionForCol_Cntrl.Count; i++)
                {
                    PromotionFor_Collection ProDist = Pro.ObjPromotionForCol_Cntrl.Get(i);
                    PCtl.InsertPromotionDist(PromotionID, SchemeID, ProDist.Dist_ID, ProDist.Assigned_Dist_ID);
                }
                #endregion

                #region Promotion for Customer Type

                for (int i = 0; i < Pro.ObjPromotionCustTypeCol_Cntrl.Count; i++)
                {
                    PromotionCustomerType_Collection ProCustType = Pro.ObjPromotionCustTypeCol_Cntrl.Get(i);
                    PCtl.InsertPromotionCustType(PromotionID, ProCustType.Dist_ID, SchemeID, ProCustType.Customer_Type_ID);
                }
                #endregion

                #region Promotion for Customer Volume Class

                for (int i = 0; i < Pro.ObjPromotionVolClassCol_Cntrl.Count; i++)
                {
                    PromotionCustomerVolClass_Collection ProVolClass = Pro.ObjPromotionVolClassCol_Cntrl.Get(i);
                    PCtl.InsertPromotionVolClass(PromotionID, SchemeID, ProVolClass.Dist_ID, ProVolClass.Customer_VolClass_ID);
                }
                #endregion

                #region Promotion Basket Master & Detail

                for (int i = 0; i < Pro.ObjBasketCol_Cntrl.Count; i++)
                {
                    Basket_Collection Bask = SchCtrl.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(i);
                    BasketController mBasketController = new BasketController();
                    long BasketID = long.Parse(mBasketController.InsertBasket(PromotionID, SchemeID, Bask.Dist_ID, Bask.Is_Basket, Bask.Is_Bundled, Bask.Is_Multiple, Bask.Basket_On, Bask.Basket_Selection));

                    if (Bask.Is_Basket == true)
                    {
                        PromotionOffer_Collection ProOffer = Bask.ObjPromotionOfferCol_Cntrl.Get(0);
                        if ((ProOffer.Discount != 0) && (ProOffer.Discount != Constants.FloatNullValue))
                        {
                            ProOffer.Offer_Value = decimal.Parse(ProOffer.Discount.ToString());
                        }
                        PCtl.InsertPromotionOffer(BasketID, PromotionID, SchemeID, ProOffer.Dist_ID, ProOffer.BasketDetail_ID, ProOffer.Quantity, ProOffer.Offer_Value, ProOffer.Discount,
                            ProOffer.Is_And, ProOffer.SKU_ID, ProOffer.UOM_ID);
                    }
                    for (int j = 0; j < Bask.ObjBasketDtlCol_Cntrlr.Count; j++)
                    {
                        Basket_Detail_Collection BaskDetail = Bask.ObjBasketDtlCol_Cntrlr.Get(j);
                        long BasketDetailID = long.Parse(mBasketController.InsertBasketDetail(BasketID, PromotionID, SchemeID, BaskDetail.Dist_ID, BaskDetail.Min_Val, BaskDetail.Max_Val, BaskDetail.Multiple_Of, BaskDetail.SKU_ID,
                            BaskDetail.SKUBrand_ID, BaskDetail.SKUDiv_ID, BaskDetail.SKUCatg_ID, BaskDetail.SKUProductLine_ID, BaskDetail.SKUGroup_ID, BaskDetail.UOM_ID, BaskDetail.SKUCompany_ID));

                        if (Bask.Is_Basket == false)
                        {
                            PromotionOffer_Collection ProOffer = Bask.ObjPromotionOfferCol_Cntrl.Get(j);
                            PCtl.InsertPromotionOffer(BasketID, PromotionID, SchemeID, ProOffer.Dist_ID, BasketDetailID, ProOffer.Quantity, ProOffer.Offer_Value, ProOffer.Discount,
                                ProOffer.Is_And, ProOffer.SKU_ID, ProOffer.UOM_ID);
                        }
                    }

                }
                #endregion

                MessageBox.Show(this, "Promotion has been created Successfully", "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnFinish.Enabled = false;
                SessionClass.flow = string.Empty;
                SessionClass.SchCtrl = null;
                txtSummary.Text = "";
                btnFinish.Enabled = false;
                btnBack4.Enabled = false;
                if (SessionClass.IsEdit != null)
                {
                    //SessionClass.IsEditing = false;
                    SessionClass.PromotionId = null;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: \n" + ex.Message, "CORN: POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void btnBack4_Click(object sender, EventArgs e)
        {
            SessionClass.flow = "b";
            Slider.SelectedPage = Step3;
        }
        /// <summary>
        /// Cancels Promotion Wizard And Redirects To Promotion Wizard Form
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void btnCancel4_Click(object sender, EventArgs e)
        {
            SessionClass.flow = string.Empty;
            if (SessionClass.IsEdit != null)
            {
                //SessionClass.IsEditing =false;
                SessionClass.PromotionId = string.Empty;
            }
            this.Close();
        } 
        #endregion

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsWindowsFormUtil.InputNum(e);
        }
    }
}
