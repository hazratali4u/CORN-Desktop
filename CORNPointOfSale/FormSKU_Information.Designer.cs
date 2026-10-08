namespace CORNPointOfSale
{
    partial class FormSKU_Information
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnActive = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnDownload = new DevComponents.DotNetBar.ButtonX();
            this.GridSKUinfo = new System.Windows.Forms.DataGridView();
            this.ChkAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUinfo)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.txtSearch.Location = new System.Drawing.Point(60, 151);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(320, 23);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.WatermarkText = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnActive
            // 
            this.btnActive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActive.BackColor = System.Drawing.Color.Green;
            this.btnActive.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnActive.FocusCuesEnabled = false;
            this.btnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnActive.Location = new System.Drawing.Point(1181, 139);
            this.btnActive.Name = "btnActive";
            this.btnActive.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnActive.Size = new System.Drawing.Size(120, 35);
            this.btnActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActive.Symbol = "";
            this.btnActive.SymbolColor = System.Drawing.Color.White;
            this.btnActive.TabIndex = 68;
            this.btnActive.Text = "Active";
            this.btnActive.TextColor = System.Drawing.Color.White;
            this.btnActive.Tooltip = "Active/Inactive";
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddNew.FocusCuesEnabled = false;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnAddNew.Location = new System.Drawing.Point(1055, 139);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAddNew.Size = new System.Drawing.Size(120, 35);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.Symbol = "";
            this.btnAddNew.SymbolColor = System.Drawing.Color.White;
            this.btnAddNew.TabIndex = 67;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.Tooltip = "Add";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Green;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnImport.FocusCuesEnabled = false;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnImport.Location = new System.Drawing.Point(930, 139);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 35);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.Symbol = "";
            this.btnImport.SymbolColor = System.Drawing.Color.White;
            this.btnImport.TabIndex = 67;
            this.btnImport.Text = "Import";
            this.btnImport.TextColor = System.Drawing.Color.White;
            this.btnImport.Tooltip = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.BackColor = System.Drawing.Color.Salmon;
            this.btnDownload.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDownload.FocusCuesEnabled = false;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnDownload.Location = new System.Drawing.Point(805, 139);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 35);
            this.btnDownload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDownload.Symbol = "";
            this.btnDownload.SymbolColor = System.Drawing.Color.White;
            this.btnDownload.TabIndex = 67;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextColor = System.Drawing.Color.White;
            this.btnDownload.Tooltip = "Download sample excel sheet";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // GridSKUinfo
            // 
            this.GridSKUinfo.AllowUserToAddRows = false;
            this.GridSKUinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridSKUinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridSKUinfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUinfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridSKUinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSKUinfo.Location = new System.Drawing.Point(60, 180);
            this.GridSKUinfo.Name = "GridSKUinfo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUinfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridSKUinfo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridSKUinfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridSKUinfo.RowTemplate.Height = 30;
            this.GridSKUinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridSKUinfo.Size = new System.Drawing.Size(1241, 372);
            this.GridSKUinfo.TabIndex = 69;
            this.GridSKUinfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSKUinfo_CellContentClick);
            // 
            // ChkAll
            // 
            this.ChkAll.AutoSize = true;
            this.ChkAll.Location = new System.Drawing.Point(81, 186);
            this.ChkAll.Name = "ChkAll";
            this.ChkAll.Size = new System.Drawing.Size(15, 14);
            this.ChkAll.TabIndex = 70;
            this.ChkAll.UseVisualStyleBackColor = true;
            this.ChkAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 80);
            this.panel2.TabIndex = 145;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(238, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Information";
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
            // FormSKU_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 584);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ChkAll);
            this.Controls.Add(this.GridSKUinfo);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSKU_Information";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormSKU_Information_Load);
            this.Shown += new System.EventHandler(this.FormSKU_Information_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUinfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnActive;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnDownload;
        private System.Windows.Forms.DataGridView GridSKUinfo;
        private System.Windows.Forms.CheckBox ChkAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}