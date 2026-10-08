namespace CORNPointOfSale
{
    partial class FormUserLogin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnActiveLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnAddLogin = new DevComponents.DotNetBar.ButtonX();
            this.GridCreateUserLogin = new System.Windows.Forms.DataGridView();
            this.ChkAllGrid = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridCreateUserLogin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(211, 148);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(245, 23);
            this.txtSearch.TabIndex = 35;
            this.txtSearch.WatermarkText = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnActiveLogin
            // 
            this.btnActiveLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActiveLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveLogin.BackColor = System.Drawing.Color.Green;
            this.btnActiveLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnActiveLogin.FocusCuesEnabled = false;
            this.btnActiveLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveLogin.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnActiveLogin.Location = new System.Drawing.Point(1011, 136);
            this.btnActiveLogin.Name = "btnActiveLogin";
            this.btnActiveLogin.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnActiveLogin.Size = new System.Drawing.Size(120, 35);
            this.btnActiveLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActiveLogin.Symbol = "";
            this.btnActiveLogin.SymbolColor = System.Drawing.Color.White;
            this.btnActiveLogin.TabIndex = 68;
            this.btnActiveLogin.Text = "Active";
            this.btnActiveLogin.TextColor = System.Drawing.Color.White;
            this.btnActiveLogin.Tooltip = "Active/Inactive";
            this.btnActiveLogin.Click += new System.EventHandler(this.btnActiveLogin_Click);
            // 
            // btnAddLogin
            // 
            this.btnAddLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddLogin.FocusCuesEnabled = false;
            this.btnAddLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLogin.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnAddLogin.Location = new System.Drawing.Point(885, 136);
            this.btnAddLogin.Name = "btnAddLogin";
            this.btnAddLogin.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAddLogin.Size = new System.Drawing.Size(120, 35);
            this.btnAddLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddLogin.Symbol = "";
            this.btnAddLogin.SymbolColor = System.Drawing.Color.White;
            this.btnAddLogin.TabIndex = 67;
            this.btnAddLogin.Text = "Add";
            this.btnAddLogin.TextColor = System.Drawing.Color.White;
            this.btnAddLogin.Tooltip = "Add New";
            this.btnAddLogin.Click += new System.EventHandler(this.btnAddLogin_Click);
            // 
            // GridCreateUserLogin
            // 
            this.GridCreateUserLogin.AllowUserToAddRows = false;
            this.GridCreateUserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCreateUserLogin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridCreateUserLogin.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCreateUserLogin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.GridCreateUserLogin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCreateUserLogin.EnableHeadersVisualStyles = false;
            this.GridCreateUserLogin.Location = new System.Drawing.Point(211, 177);
            this.GridCreateUserLogin.Name = "GridCreateUserLogin";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCreateUserLogin.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.GridCreateUserLogin.RowHeadersVisible = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.GridCreateUserLogin.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.GridCreateUserLogin.RowTemplate.Height = 30;
            this.GridCreateUserLogin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridCreateUserLogin.Size = new System.Drawing.Size(920, 378);
            this.GridCreateUserLogin.TabIndex = 69;
            this.GridCreateUserLogin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCreateUserLogin_CellContentClick);
            // 
            // ChkAllGrid
            // 
            this.ChkAllGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkAllGrid.AutoSize = true;
            this.ChkAllGrid.Location = new System.Drawing.Point(231, 183);
            this.ChkAllGrid.Name = "ChkAllGrid";
            this.ChkAllGrid.Size = new System.Drawing.Size(15, 14);
            this.ChkAllGrid.TabIndex = 70;
            this.ChkAllGrid.UseVisualStyleBackColor = true;
            this.ChkAllGrid.CheckedChanged += new System.EventHandler(this.ChkAllGrid_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 80);
            this.panel1.TabIndex = 126;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "User Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1280, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormUserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 584);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChkAllGrid);
            this.Controls.Add(this.GridCreateUserLogin);
            this.Controls.Add(this.btnActiveLogin);
            this.Controls.Add(this.btnAddLogin);
            this.Controls.Add(this.txtSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserLogin";
            this.ShowInTaskbar = false;
            this.Text = "Personal Edition";
            this.Load += new System.EventHandler(this.FormUserLogin_Load);
            this.Shown += new System.EventHandler(this.FormCreateUserLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GridCreateUserLogin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnActiveLogin;
        private DevComponents.DotNetBar.ButtonX btnAddLogin;
        private System.Windows.Forms.DataGridView GridCreateUserLogin;
        private System.Windows.Forms.CheckBox ChkAllGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}