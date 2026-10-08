using System;
using System.Data;
using System.Windows.Forms;
using CORNBusinessLayer.Classes;
using CORNCommon.Classes;
using DevComponents.DotNetBar;
using System.Drawing;

namespace CORNPointOfSale
{
    public partial class frmRequestAFeature : Form
    {
        int _tilID;
        public frmRequestAFeature()
        {
            InitializeComponent();
        }

        
        private void frmRequestAFeature_Load(object sender, EventArgs e)
        {
            //openFileDialog1 = new OpenFileDialog
            //{
            //    InitialDirectory = @"c:\",
            //    Title = "Browse Image Files",

            //    CheckFileExists = true,
            //    CheckPathExists = true,

            //    DefaultExt = "jpg",
            //    Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| *.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true,

            //    ReadOnlyChecked = true,
            //    ShowReadOnly = true
            //};
        }


        private void frmRequestAFeature_Resize(object sender, EventArgs e)
        {
            int[] points = clsWindowsFormUtil.GetLocation(this.Width, this.Height, 280, 160);
            //groupPanel2.Location = new Point(points[0],points[1]);
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int i = 1;
                foreach (String file in openFileDialog1.FileNames)
                {
                    if(i == 1)
                    {
                        txtFilePath1.Text = file;
                    }
                    else if (i == 2)
                    {
                        txtFilePath2.Text = file;
                    }
                    else if (i == 3)
                    {
                        txtFilePath3.Text = file;
                    }
                    else if (i == 4)
                    {
                        txtFilePath4.Text = file;
                    }
                    else if (i == 5)
                    {
                        txtFilePath5.Text = file;
                    }
                    i++;
                }
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath2.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath3.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowse4_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath4.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowse5_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath5.Text = openFileDialog1.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSubject.Clear();
            txtDesc.Clear();
            txtFilePath1.Clear();
            txtFilePath2.Clear();
            txtFilePath3.Clear();
            txtFilePath4.Clear();
            txtFilePath5.Clear();
        }

        private void txtFilePath1_MouseEnter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds
            if(TB.Text.Trim().Length > 0)
            {
                //System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                toolTip1.Show(TB.Text, TB, 0, 0, VisibleTime);
            }
        }

        private void txtFilePath2_MouseEnter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            if (TB.Text.Trim().Length > 0)
            {
                //System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                toolTip1.Show(TB.Text, TB, 0, 0, VisibleTime);
            }
        }

        private void txtFilePath3_MouseEnter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            if (TB.Text.Trim().Length > 0)
            {
                //System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                toolTip1.Show(TB.Text, TB, 0, 0, VisibleTime);
            }
        }

        private void txtFilePath4_MouseEnter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            if (TB.Text.Trim().Length > 0)
            {
                //System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                toolTip1.Show(TB.Text, TB, 0, 0, VisibleTime);
            }
        }

        private void txtFilePath5_MouseEnter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            if (TB.Text.Trim().Length > 0)
            {
                //System.Windows.Forms.ToolTip tt = new System.Windows.Forms.ToolTip();
                toolTip1.Show(TB.Text, TB, 0, 0, VisibleTime);
            }
        }
    }
}
