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
    public partial class FormChartOfAccount : Form
    {
        public FormChartOfAccount()
        {
            InitializeComponent();
        }

        #region Variables

        AccountHeadController MController = new AccountHeadController();
        private static long AccountTypeId;
        private static long AccountSubTypeId;
        private static long AccountDetailTypeId;
        private static long AccountHeadId;
        private static string strCode;

        #endregion
        /// <summary>
        /// Account Type TAB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region Main Type Tab

        private void FormChartOfAccount_Load(object sender, EventArgs e)
        {
            cboxAccountCatagory.SelectedIndex = 0;
            CORNCommon.Classes.Configuration.DistributorId = 1;
            this.GetAccountType();
            ArrngeGridView(GridMainType);
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
        }

        private void cboxAccountCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetSubTypeForDetail();
            this.GetSubTypeForHead();
            this.GetDetailAccountType();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
            ArrngeGridView(GridMainType);
        }

        private void GetAccountType()
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_MainTypeId, Constants.LongNullValue, cboxAccountCatagory.SelectedIndex);
            GridMainType.DataSource = dt;

            cboxAccountType1.DataSource = dt;
            cboxAccountType1.DisplayMember = "Account_Detail";
            cboxAccountType1.ValueMember = "Account_Head_ID";

            cboxAccountType2.DataSource = dt;
            cboxAccountType2.DisplayMember = "Account_Detail";
            cboxAccountType2.ValueMember = "Account_Head_ID";

            cboxAccountType3.DataSource = dt;
            cboxAccountType3.DisplayMember = "Account_Detail";
            cboxAccountType3.ValueMember = "Account_Head_ID";
        }

        private void cboxAccountType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSubAccountType();
        }

        public void ArrngeGridView(DataGridView dGrid)
        {
            try
            {
                dGrid.Columns.Remove("Edit");
                dGrid.Columns.Remove("Delete");
            }
            catch (Exception)
            { }
            dGrid.Columns["DISTRIBUTOR_ID"].Visible = false;
            dGrid.Columns["COMPANY_ID"].Visible = false;
            dGrid.Columns["ACCOUNT_CODE"].Visible = false;
            dGrid.Columns["ACCOUNT_NAME"].Visible = false;
            dGrid.Columns["ACCOUNT_PARENT_ID"].Visible = false;
            dGrid.Columns["ACCOUNT_TYPE_ID"].Visible = false;
            dGrid.Columns["TIME_STAMP"].Visible = false;
            dGrid.Columns["LASTUPDATE_DATE"].Visible = false;
            dGrid.Columns["IS_ACTIVE"].Visible = false;
            dGrid.Columns["ACCOUNT_HEAD"].Visible = false;
            dGrid.Columns["ACCOUNT_CATEGORY"].Visible = false;
            dGrid.Columns["Account_Head_ID"].HeaderText = "Code";
            dGrid.Columns["Account_Detail"].HeaderText = "Account Name";

            // Add Edit Button
            DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "Edit";
            btnEdit.DataPropertyName = "lnkColumn";
            btnEdit.Image = CORNPointOfSale.Properties.Resources.edit1;
            dGrid.Columns.Add(btnEdit);

            //// Add Delete Button
            DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "Delete";
            btnDelete.DataPropertyName = "lnkColumn";
            btnDelete.Image = CORNPointOfSale.Properties.Resources.delete_icon;
            dGrid.Columns.Add(btnDelete);

            // Set Columns width
            dGrid.Columns["Account_Head_ID"].Width = 70;
            dGrid.Columns["Edit"].Width = 60;
            dGrid.Columns["Delete"].Width = 70;
            dGrid.Columns["Account_Detail"].Width = 499;
        }

        private void cboxAccountType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSubTypeForDetail();
            this.GetDetailAccountType();
        }

        private void cboxAccountType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSubTypeForHead();
            this.GetDetailAccountTypeForHead();
            this.GetAccountHead();
        }

        private void GridMainType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridMainType.Columns["Edit"].Index)
            {
                int _rowIndex = GridMainType.CurrentCell.RowIndex;
                AccountTypeId = long.Parse(GridMainType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString());
                txtAtypeCode.Text = GridMainType.Rows[_rowIndex].Cells["ACCOUNT_CODE"].Value.ToString();
                txtAtypeName.Text = GridMainType.Rows[_rowIndex].Cells["ACCOUNT_NAME"].Value.ToString().Replace("amp;", "");
                cboxAccountCatagory.SelectedIndex = int.Parse(GridMainType.Rows[_rowIndex].Cells["ACCOUNT_CATEGORY"].Value.ToString());
                btnAccountType.Text = "Update";
                txtAtypeName.Focus();
            }
            else if (e.ColumnIndex == GridMainType.Columns["Delete"].Index)
            {
                int _rowIndex = GridMainType.CurrentCell.RowIndex;
                DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, long.Parse(GridMainType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()));
                if (dt.Rows.Count == 0)
                {
                    if (clsWindowsFormUtil.DeleteConfirmation("Are you sure to delete?"))
                    {
                        MController.UpdateAccountHead(long.Parse(GridMainType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()), SessionClass.CompanyID, false, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, Constants.LongNullValue, null, null, 0);
                        this.GetAccountType(); 
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error: \n" + "Transaction exists unable to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAccountType_Click(object sender, EventArgs e)
        {
            if (btnAccountType.Text == "New Account Type")
            {
                btnAccountType.Text = "Save Account Type";
                txtAtypeCode.Text = this.GetAutoCode(Constants.AC_MainTypeId, Constants.LongNullValue);
            }
            else if (btnAccountType.Text == "Save Account Type")
            {
                MController.InsertAccountHead(1, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text, txtAtypeCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetAccountType();
                this.GetSubAccountType();
                this.GetSubTypeForDetail();
                this.GetSubTypeForHead();
                this.GetDetailAccountType();
                this.GetDetailAccountTypeForHead();
                this.GetAccountHead();
                ClearAll(btnAccountType, "New Account Type", txtAtypeCode, txtAtypeName);
            }
            else if (btnAccountType.Text == "Update")
            {
                MController.UpdateAccountHead(AccountTypeId, 1, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text, txtAtypeCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetAccountType();
                this.GetSubAccountType();
                txtAtypeName.Focus();
                this.GetSubTypeForDetail();
                //this.GetSubTypeForHead();
                //this.GetDetailAccountType();
                //this.GetDetailAccountTypeForHead();
                //this.GetAccountHead();
                ClearAll(btnAccountType, "New Account Type", txtAtypeCode, txtAtypeName);
            }
        }

        public void ClearAll(DevComponents.DotNetBar.ButtonX Creatnew,string btnText, TextBox txtcode, TextBox txtname)
        {
            Creatnew.Text = btnText;
            txtcode.Text = "";
            txtname.Text = "";
        }

        #endregion
        
        /// <summary>
        /// Sub Type TAB
        /// </summary>
        
        #region Sub Type Tab

        private void GetSubAccountType()
        {
            try
            {
                if (cboxAccountType1.Items.Count > 0)
                {
                    DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(cboxAccountType1.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                    GridSubType.DataSource = dt;
                    this.ArrngeGridView(GridSubType);
                }
            }
            catch (Exception)
            {}
        }

        private void GridSubType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridSubType.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridSubType.Columns["Edit"].Index)
            {
                AccountSubTypeId = long.Parse(GridSubType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString());
                txtASubTypeCode.Text = GridSubType.Rows[_rowIndex].Cells["ACCOUNT_CODE"].Value.ToString();
                txtASubTypeName.Text = GridSubType.Rows[_rowIndex].Cells["ACCOUNT_NAME"].Value.ToString().Replace("amp;", "");
                btnAccountSubType.Text = "Update";
            }
            else if (e.ColumnIndex == GridSubType.Columns["Delete"].Index)
            {
                DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, long.Parse(GridSubType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()));

                if (dt.Rows.Count == 0)
                {
                    if (clsWindowsFormUtil.DeleteConfirmation("Are You Sure to Delete?"))
                    {
                        MController.UpdateAccountHead(long.Parse(GridSubType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()), SessionClass.CompanyID, false, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, Constants.LongNullValue, null, null, 0);
                        this.GetSubAccountType();
                        this.GetSubTypeForDetail(); 
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error: \n" + "Transaction exists unable to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAccountSubType_Click(object sender, EventArgs e)
        {
            if (btnAccountSubType.Text == "New Sub Type")
            {
                btnAccountSubType.Text = "Save Sub Type";
                txtASubTypeCode.Text = this.GetAutoCode(Constants.AC_SubTypeId, long.Parse(cboxAccountType1.SelectedValue.ToString()));
                txtASubTypeName.Focus();
            }
            else if (btnAccountSubType.Text == "Save Sub Type")
            {
                if (cboxAccountType1.Items.Count > 0)
                {
                    MController.InsertAccountHead(1, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, long.Parse(cboxAccountType1.SelectedValue.ToString()), txtASubTypeName.Text, txtASubTypeCode.Text, cboxAccountCatagory.SelectedIndex);
                }
                this.GetSubAccountType();
                this.GetSubTypeForDetail();
                this.GetSubTypeForHead();
                this.GetDetailAccountType();
                this.GetDetailAccountTypeForHead();
                this.GetAccountHead();
                this.ClearAll(btnAccountSubType,"New Sub Type",txtASubTypeCode,txtASubTypeName);
            }
            else if (btnAccountSubType.Text == "Update")
            {
                MController.UpdateAccountHead(AccountSubTypeId, 1, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, long.Parse(cboxAccountType1.SelectedValue.ToString()), txtASubTypeName.Text, txtASubTypeCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetSubAccountType();
                this.GetSubTypeForDetail();
                this.GetSubTypeForHead();
                this.GetDetailAccountType();
                this.GetDetailAccountTypeForHead();
                this.GetAccountHead();
                this.ClearAll(btnAccountSubType, "New Sub Type", txtASubTypeCode, txtASubTypeName);
            }
        }

        #endregion

        // Sub Type Detail Tab

        #region SubType Detail Tab
        private void GetSubTypeForDetail()
        {
            if (cboxAccountType2.Items.Count > 0)
            {
                try
                {
                    DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(cboxAccountType2.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                    cboxAccountSubType1.DataSource = dt;
                    cboxAccountSubType1.DisplayMember = "Account_Detail";
                    cboxAccountSubType1.ValueMember = "Account_Head_ID";
                }
                catch (Exception)
                { }
            }
        }

        private void GetDetailAccountType()
        {
            try
            {
                if (cboxAccountSubType1.Items.Count > 0)
                {
                    DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, int.Parse(cboxAccountSubType1.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                    GridDetailType.DataSource = dt;
                    this.ArrngeGridView(GridDetailType);
                }
            }
            catch (Exception)
            { }
        }

        private void GridDetailType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridDetailType.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridDetailType.Columns["Edit"].Index)
            {
                AccountDetailTypeId = long.Parse(GridDetailType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString());
                txtDetailCode.Text = GridDetailType.Rows[_rowIndex].Cells["ACCOUNT_CODE"].Value.ToString();
                txtDetailName.Text = GridDetailType.Rows[_rowIndex].Cells["ACCOUNT_NAME"].Value.ToString().Replace("amp;", "");
                btnAccountDetailType.Text = "Update";
            }
            else if (e.ColumnIndex == GridDetailType.Columns["Delete"].Index)
            {
                DataTable dt = MController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(GridDetailType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()));

                if (dt.Rows.Count == 0)
                {
                    if (clsWindowsFormUtil.DeleteConfirmation("Are you sure to Delete?"))
                    {
                        MController.UpdateAccountHead(long.Parse(GridDetailType.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()), SessionClass.CompanyID, false, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, Constants.LongNullValue, null, null, 0);
                        this.GetDetailAccountType();
                        this.GetDetailAccountTypeForHead(); 
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error: \n" + "Transaction exists unable to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAccountDetailType_Click(object sender, EventArgs e)
        {
            if (btnAccountDetailType.Text == "New Detail Type")
            {
                btnAccountDetailType.Text = "Save Detail Type";
                txtDetailCode.Text = this.GetAutoCode(Constants.AC_DetailTypeId, long.Parse(cboxAccountSubType1.SelectedValue.ToString()));
                txtDetailName.Focus();
            }
            else if (btnAccountDetailType.Text == "Save Detail Type")
            {
                if (txtDetailName.Text != "")
                {
                    if (cboxAccountType2.Items.Count > 0 && cboxAccountType1.Items.Count > 0)
                    {
                        MController.InsertAccountHead(SessionClass.CompanyID, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, long.Parse(cboxAccountSubType1.SelectedValue.ToString()), txtDetailName.Text, txtDetailCode.Text, cboxAccountCatagory.SelectedIndex);
                        this.GetDetailAccountType();
                        this.GetDetailAccountTypeForHead();
                        this.GetAccountHead();
                        this.ClearAll(btnAccountDetailType, "New Detail Type", txtDetailCode, txtDetailName);
                    }
                }
            }
            else if (btnAccountDetailType.Text == "Update")
            {
                MController.UpdateAccountHead(AccountDetailTypeId, SessionClass.CompanyID, true, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, long.Parse(cboxAccountSubType1.SelectedValue.ToString()), txtDetailName.Text, txtDetailCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetDetailAccountType();
                this.GetDetailAccountTypeForHead();
                this.GetAccountHead();
                this.ClearAll(btnAccountDetailType, "New Detail Type", txtDetailCode, txtDetailName);
            }
        }

        private void cboxAccountSubType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetDetailAccountType();
        } 
        #endregion

        // Account Head Tab

        #region Account Head Tab

        private void GetSubTypeForHead()
        {
            try
            {
                if (cboxAccountType3.Items.Count > 0)
                {
                    DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(cboxAccountType3.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                    cboxAccountSubType2.DataSource = dt;
                    cboxAccountSubType2.DisplayMember = "Account_Detail";
                    cboxAccountSubType2.ValueMember = "Account_Head_ID";
                }
            }
            catch (Exception)
            {}
        }

        private void cboxAccountSubType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.GetDetailAccountTypeForHead();
            //this.GetAccountHead();
        }

        private void GetDetailAccountTypeForHead()
        {
            if (cboxAccountSubType2.Items.Count > 0)
            {
                DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, int.Parse(cboxAccountSubType2.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                cboxAccountTypeDetail.DataSource = dt;
                cboxAccountTypeDetail.DisplayMember = "Account_Detail";
                cboxAccountTypeDetail.ValueMember = "Account_Head_ID";
            }
        }

        private void cboxAccountTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAccountHead();
        }

        private void GetAccountHead()
        {
            try
            {
                if (cboxAccountTypeDetail.Items.Count > 0)
                {
                    DataTable dt = MController.SelectAccountHead(Constants.AC_AccountHeadId, int.Parse(cboxAccountTypeDetail.SelectedValue.ToString()), cboxAccountCatagory.SelectedIndex);
                    GridAccountHead.DataSource = dt;
                    this.ArrngeGridView(GridAccountHead);
                }
                else
                {
                    GridAccountHead.DataSource = null;
                }
            }
            catch (Exception)
            {}
        }

        private void GridAccountHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _rowIndex = GridAccountHead.CurrentCell.RowIndex;
            if (e.ColumnIndex == GridAccountHead.Columns["Edit"].Index)
            {
                AccountHeadId = long.Parse(GridAccountHead.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString());
                txtAccountCode.Text = GridAccountHead.Rows[_rowIndex].Cells["ACCOUNT_CODE"].Value.ToString();
                txtAccountHead.Text = GridAccountHead.Rows[_rowIndex].Cells["ACCOUNT_NAME"].Value.ToString().Replace("amp;", "");
                btnNew.Text = "Update";
            }
            else if (e.ColumnIndex == GridAccountHead.Columns["Delete"].Index)
            {
                DataTable dt = MController.SelectGlTranscton(long.Parse(GridAccountHead.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()));

                if (dt.Rows.Count == 0)
                {
                    if (clsWindowsFormUtil.DeleteConfirmation("Are you sure to Delete?"))
                    {
                        MController.UpdateAccountHead(long.Parse(GridAccountHead.Rows[_rowIndex].Cells["ACCOUNT_HEAD_ID"].Value.ToString()), SessionClass.CompanyID, false, DateTime.Now, CORNCommon.Classes.Configuration.DistributorId, Constants.AC_AccountHeadId, Constants.LongNullValue, null, null, 0);
                        this.GetAccountHead(); 
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error: \n" + "Transaction exists unable to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                btnNew.Text = "Save";
                txtAccountCode.Text = this.GetAutoCode(Constants.AC_AccountHeadId, int.Parse(cboxAccountTypeDetail.SelectedValue.ToString()));
                txtAccountCode.Focus();
            }
            else if (btnNew.Text == "Save")
            {
                MController.InsertAccountHead(SessionClass.CompanyID, true, DateTime.Now, SessionClass.DISTRIBUTOR_ID, Constants.AC_AccountHeadId, long.Parse(cboxAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, cboxAccountType3.SelectedItem.ToString().Substring(0, 2) + cboxAccountSubType2.SelectedItem.ToString().Substring(0, 2) + cboxAccountTypeDetail.SelectedItem.ToString().Substring(0, 2) + txtAccountCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetAccountHead();
                this.ClearAll(btnNew, "New", txtAccountCode, txtAccountHead);
            }
            else
            {
                MController.UpdateAccountHead(AccountHeadId, SessionClass.CompanyID, true, System.DateTime.Now, SessionClass.DISTRIBUTOR_ID, Constants.AC_AccountHeadId, int.Parse(cboxAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, cboxAccountType3.SelectedItem.ToString().Substring(0, 2) + cboxAccountSubType2.SelectedItem.ToString().Substring(0, 2) + cboxAccountTypeDetail.SelectedItem.ToString().Substring(0, 2) + txtAccountCode.Text, cboxAccountCatagory.SelectedIndex);
                this.GetAccountHead();
                this.ClearAll(btnNew, "New", txtAccountCode, txtAccountHead);
            }
        } 
        #endregion

        // Auto Code

        #region Get Auto Code
        private string GetAutoCode(int CodeType, long CValue)
        {
            DataTable dt = MController.SelectAccountHead(CodeType, CValue, cboxAccountCatagory.SelectedIndex);
            DataView dv = new DataView(dt);
            dv.Sort = "ACCOUNT_CODE";
            dt = dv.ToTable();
            if (CodeType != Constants.AC_AccountHeadId)
            {
                if (dt.Rows.Count > 0)
                {
                    int AccountCode = Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString()) + 1;
                    if (AccountCode.ToString().Length == 1)
                    {
                        return "0" + AccountCode.ToString();

                    }
                    else
                    {
                        return AccountCode.ToString();
                    }
                }
                else
                {
                    return "01";
                }
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    int AccountCode = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString().Substring(6, 4)) + 1;
                    if (AccountCode.ToString().Length == 1)
                    {
                        return "000" + AccountCode.ToString();
                    }
                    else if (AccountCode.ToString().Length == 2)
                    {
                        return "00" + AccountCode.ToString();
                    }
                    else if (AccountCode.ToString().Length == 3)
                    {
                        return "0" + AccountCode.ToString();
                    }
                    else
                    {
                        return AccountCode.ToString();
                    }
                }
                else
                {
                    return "0001";
                }
            }
        } 
        #endregion

        private void FormChartOfAccount_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 380, 180);
            tabControl1.Location = new Point(points[0], points[1]);
        }
    }
}
