namespace CORNPointOfSale
{
    partial class FormNewLocation2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearchDistributors = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAddNewLocation = new DevComponents.DotNetBar.ButtonX();
            this.btnActiveNewLocation = new DevComponents.DotNetBar.ButtonX();
            this.GridDistributor = new System.Windows.Forms.DataGridView();
            this.ChkAllGrid = new System.Windows.Forms.CheckBox();
            this.dataGridViewCheckBoxXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridDistributor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchDistributors
            // 
            // 
            // 
            // 
            this.txtSearchDistributors.Border.Class = "TextBoxBorder";
            this.txtSearchDistributors.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchDistributors.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchDistributors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchDistributors.Location = new System.Drawing.Point(12, 149);
            this.txtSearchDistributors.Name = "txtSearchDistributors";
            this.txtSearchDistributors.PreventEnterBeep = true;
            this.txtSearchDistributors.Size = new System.Drawing.Size(316, 23);
            this.txtSearchDistributors.TabIndex = 1;
            this.txtSearchDistributors.WatermarkText = "Search";
            this.txtSearchDistributors.TextChanged += new System.EventHandler(this.txtFilterDistributors_TextChanged);
            // 
            // btnAddNewLocation
            // 
            this.btnAddNewLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewLocation.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddNewLocation.FocusCuesEnabled = false;
            this.btnAddNewLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLocation.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnAddNewLocation.Location = new System.Drawing.Point(1088, 137);
            this.btnAddNewLocation.Name = "btnAddNewLocation";
            this.btnAddNewLocation.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAddNewLocation.Size = new System.Drawing.Size(120, 35);
            this.btnAddNewLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNewLocation.Symbol = "";
            this.btnAddNewLocation.SymbolColor = System.Drawing.Color.White;
            this.btnAddNewLocation.TabIndex = 3;
            this.btnAddNewLocation.Text = "Add";
            this.btnAddNewLocation.TextColor = System.Drawing.Color.White;
            this.btnAddNewLocation.Tooltip = "Add New";
            this.btnAddNewLocation.Click += new System.EventHandler(this.btnAddNewLocation_Click);
            // 
            // btnActiveNewLocation
            // 
            this.btnActiveNewLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActiveNewLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveNewLocation.BackColor = System.Drawing.Color.Green;
            this.btnActiveNewLocation.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnActiveNewLocation.FocusCuesEnabled = false;
            this.btnActiveNewLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveNewLocation.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnActiveNewLocation.Location = new System.Drawing.Point(1214, 137);
            this.btnActiveNewLocation.Name = "btnActiveNewLocation";
            this.btnActiveNewLocation.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnActiveNewLocation.Size = new System.Drawing.Size(120, 35);
            this.btnActiveNewLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActiveNewLocation.Symbol = "";
            this.btnActiveNewLocation.SymbolColor = System.Drawing.Color.White;
            this.btnActiveNewLocation.TabIndex = 4;
            this.btnActiveNewLocation.Text = "Active";
            this.btnActiveNewLocation.TextColor = System.Drawing.Color.White;
            this.btnActiveNewLocation.Tooltip = "Active/Inactive";
            this.btnActiveNewLocation.Click += new System.EventHandler(this.btnActiveNewLocation_Click);
            // 
            // GridDistributor
            // 
            this.GridDistributor.AllowUserToAddRows = false;
            this.GridDistributor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDistributor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDistributor.BackgroundColor = System.Drawing.Color.White;
            this.GridDistributor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDistributor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridDistributor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDistributor.Location = new System.Drawing.Point(13, 179);
            this.GridDistributor.Name = "GridDistributor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDistributor.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GridDistributor.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.GridDistributor.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridDistributor.RowTemplate.Height = 30;
            this.GridDistributor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridDistributor.Size = new System.Drawing.Size(1322, 379);
            this.GridDistributor.TabIndex = 34;
            this.GridDistributor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDistributor_CellContentClick);
            // 
            // ChkAllGrid
            // 
            this.ChkAllGrid.AutoSize = true;
            this.ChkAllGrid.Location = new System.Drawing.Point(33, 184);
            this.ChkAllGrid.Name = "ChkAllGrid";
            this.ChkAllGrid.Size = new System.Drawing.Size(15, 14);
            this.ChkAllGrid.TabIndex = 35;
            this.ChkAllGrid.UseVisualStyleBackColor = true;
            this.ChkAllGrid.CheckedChanged += new System.EventHandler(this.ChkAllGrid_CheckedChanged);
            // 
            // dataGridViewCheckBoxXColumn1
            // 
            this.dataGridViewCheckBoxXColumn1.Checked = true;
            this.dataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dataGridViewCheckBoxXColumn1.CheckValue = "N";
            this.dataGridViewCheckBoxXColumn1.HeaderText = "";
            this.dataGridViewCheckBoxXColumn1.Name = "dataGridViewCheckBoxXColumn1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 80);
            this.panel1.TabIndex = 129;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(201, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "New Location";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1264, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormNewLocation2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1346, 584);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChkAllGrid);
            this.Controls.Add(this.GridDistributor);
            this.Controls.Add(this.btnActiveNewLocation);
            this.Controls.Add(this.btnAddNewLocation);
            this.Controls.Add(this.txtSearchDistributors);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewLocation2";
            this.Load += new System.EventHandler(this.FormNewLocation2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridDistributor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchDistributors;
        private DevComponents.DotNetBar.ButtonX btnAddNewLocation;
        private DevComponents.DotNetBar.ButtonX btnActiveNewLocation;
        private System.Windows.Forms.DataGridView GridDistributor;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dataGridViewCheckBoxXColumn1;
        private System.Windows.Forms.CheckBox ChkAllGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}