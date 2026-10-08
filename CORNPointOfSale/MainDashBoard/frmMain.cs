using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CORNPointOfSale
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        public void BuildFormTree()
        {
            DataSet dsUserForms = null;
            try
            {
                //dsUserForms = new DataSet();
                //dsUserForms = Global.Common.DAL.GetUserForms(Global.Common.GlobalInfo.intRoleCode, GlobalInfo.UserCode);
                //dsUserForms.Relations.Add("Table", dsUserForms.Tables["Table"].Columns["Child"], dsUserForms.Tables["Table"].Columns["Parent"], false);
                //treForm.SetDataBinding(dsUserForms, "Table");
                //treForm.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
