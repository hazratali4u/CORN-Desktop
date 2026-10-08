using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using DevComponents.DotNetBar;
using CORNCommon.Classes;

namespace CORNPointOfSale
{
    public partial class frmDayClose : Form
    {
        public frmDayClose()
        {
            InitializeComponent();
        }

        private void LastClosedDay(int UserId, int p_Distributor)
        {
            DistributorController mDayClose = new DistributorController();
            DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
            if (dt.Rows.Count > 0)
            {
                SessionClass.CurrentWorkDate = DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString());
                btnDayClose.Visible = true;
            }
            else
            {
                SessionClass.CurrentWorkDate = DateTime.Now;
            }
            GetLastClosedDay(UserId, 0);
        }

        private void GetLastClosedDay(int UserId, int p_Status)
        {
            DistributorController mController = new DistributorController();
            DataTable dtable = mController.MaxDayClose(UserId, p_Status);

            dgvDayClose.AutoGenerateColumns = false;
            dgvDayClose.Rows.Clear();
            if (dtable.Rows.Count > 0)
            {
                foreach (DataRow dr in dtable.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvDayClose);
                    row.Cells[0].Value = dr["DISTRIBUTOR_NAME"];
                    row.Cells[1].Value = dr["CONTACT_PERSON"];
                    row.Cells[2].Value = dr["CONTACT_NUMBER"];
                    row.Cells[3].Value = dr["CLOSING_DATE"];
                    row.Cells[4].Value = dr["TIME_STAMP"];
                    dgvDayClose.Rows.Add(row);
                }
            }
        }

        private void btnDayClose_Click(object sender, EventArgs e)
        {
            if (btnDayClose.Visible == true)
            {
                DistributorController mDayClose = new DistributorController();

                bool dt = mDayClose.UspDayClose(SessionClass.CurrentWorkDate, SessionClass.DISTRIBUTOR_ID, SessionClass.UserID, null);
                if (dt == false)
                {
                    MessageBox.Show("Some error in day Close Contact System Administrator", "CORN : POS");
                }
                else
                {
                    Application.Restart();
                }
            }
        }

        private void frmDayClose_Load(object sender, EventArgs e)
        {
            LastClosedDay(SessionClass.UserID, SessionClass.DISTRIBUTOR_ID);
        }
    }
}
