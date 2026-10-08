using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class frmVideoTutorial : Form
    {
        int _tilID;
        public frmVideoTutorial()
        {
            InitializeComponent();
        }

        
        private void frmVideoTutorial_Load(object sender, EventArgs e)
        {
            
        }
       

        private void frmVideoTutorial_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 280, 160);
            //groupPanel2.Location = new Point(points[0],points[1]);
        }
    }
}
