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
    public partial class FormReportDataUpdateStatus : Form
    {

        DistributorController mController = new DistributorController();
        public FormReportDataUpdateStatus()
        {
            InitializeComponent();
        }

        private void FormReportDataUpdateStatus_Load(object sender, EventArgs e)
        {
            btnDayClose.Visible = true;
            //if (SessionClass.RoleID == 1)
            //{
            //    btnDayClose.Visible = false;
            //}
            //else
            //{
            //    btnDayClose.Visible = true;
            //}
            LastClosedDay(int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()));
        }

        /// <summary>
        /// Gets Location(s) Last Day Close(s)
        /// </summary>
        /// <param name="UserId">User</param>
        /// <param name="p_Distributor">Location</param>
        private void LastClosedDay(int UserId, int p_Distributor)
        {
            DistributorController mDayClose = new DistributorController();
            DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
            if (dt.Rows.Count > 0)
            {
                SessionClass.CurrentWorkDate = DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString());
                // btnDayClose.Visible = true;
            }
            else
            {
                SessionClass.CurrentWorkDate = DateTime.Now;
                rbtnAll.Visible = true;
            }
            GetLastClosedDay(UserId, p_Distributor, 0);
        }

        /// <summary>
        /// Loads Location(s) Last Day Close(s) To Grid
        /// </summary>
        /// <param name="UserId">User</param>
        /// <param name="p_Distributor">Location</param>
        /// <param name="p_Status">Status</param>
        private void GetLastClosedDay(int UserId, int p_Distributor, int p_Status)
        {
            DataTable dtable = mController.MaxDayClose(int.Parse(SessionClass.UserID.ToString()), p_Status);
            Grid_Hierarchy.DataSource = dtable;
            ArrangeGrid();
        }

        /// <summary>
        /// Loads Locations(Active/InActive/All) Last Day Close(s) To Grid
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void rblDistributorTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rbtnValues = 0;
            if (rbtnAll.Checked)
            {
                rbtnValues = 0;
            }
            else if (rbtnActive.Checked)
            {
                rbtnValues = 1;
            }
            else if (rbtnInActive.Checked)
            {
                rbtnValues = 2;
            }
            GetLastClosedDay(int.Parse(SessionClass.UserID.ToString()), int.Parse(SessionClass.DISTRIBUTOR_ID.ToString()), rbtnValues);
        }

        public void ArrangeGrid()
        {
            Grid_Hierarchy.Columns["DISTRIBUTOR_CODE"].HeaderText = "Location Code";
            Grid_Hierarchy.Columns["DISTRIBUTOR_NAME"].HeaderText = "Location Name";
            Grid_Hierarchy.Columns["CONTACT_PERSON"].HeaderText = "Contact Person";
            Grid_Hierarchy.Columns["CONTACT_NUMBER"].HeaderText = "Contact Number";
            Grid_Hierarchy.Columns["CLOSING_DATE"].HeaderText = "Last Day Close";
            Grid_Hierarchy.Columns["TIME_STAMP"].HeaderText = "Closing Date/Time";

            Grid_Hierarchy.Columns["DISTRIBUTOR_CODE"].Width = 160;
            Grid_Hierarchy.Columns["DISTRIBUTOR_NAME"].Width = 450;
            Grid_Hierarchy.Columns["CONTACT_PERSON"].Width = 160;
            Grid_Hierarchy.Columns["CONTACT_NUMBER"].Width = 160;
            Grid_Hierarchy.Columns["CLOSING_DATE"].Width = 160;
            Grid_Hierarchy.Columns["TIME_STAMP"].Width = 160;
        }

        private void btnDayClose_Click(object sender, EventArgs e)
        {
            if (btnDayClose.Visible == true)
            {
                int days = 0;
                string daysUpdated;
                DataTable dtLicenseData = SessionClass.dtLicenseData;
                try
                {
                    days = Convert.ToInt32(Cryptography.Decrypt(dtLicenseData.Rows[0]["DIAS"].ToString(), Constants.CryptographyKey));
                    DistributorController mDayClose = new DistributorController();
                    daysUpdated = Cryptography.Encrypt((days + 1).ToString(), Constants.CryptographyKey);
                    bool dt = mDayClose.UspDayClose(Convert.ToDateTime(SessionClass.CurrentWorkDate.ToShortDateString()), SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, daysUpdated);
                    if (dt == false)
                    {
                        MessageBox.Show("Some error in day Close Contact System Administrator", "CORN : POS");
                    }
                    else
                    {
                        Application.Restart();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unauthorized Activity Performed, Contact to Administrator", "CORN POS");
                }
            }
        }
    }
}
