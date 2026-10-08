namespace CORNPointOfSale
{
    partial class FormReportItemPriceStructure
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
            this.label2 = new System.Windows.Forms.Label();
            this.drpDistributor = new System.Windows.Forms.ComboBox();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.ChkAllCategories = new System.Windows.Forms.CheckBox();
            this.ChkAllSections = new System.Windows.Forms.CheckBox();
            this.ChkListCatagory = new System.Windows.Forms.CheckedListBox();
            this.ChkListSection = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 118;
            this.label2.Text = "Location";
            // 
            // drpDistributor
            // 
            this.drpDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpDistributor.FormattingEnabled = true;
            this.drpDistributor.Location = new System.Drawing.Point(93, 21);
            this.drpDistributor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpDistributor.Name = "drpDistributor";
            this.drpDistributor.Size = new System.Drawing.Size(213, 24);
            this.drpDistributor.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.BackColor = System.Drawing.Color.Green;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.FocusCuesEnabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnView.Location = new System.Drawing.Point(483, 406);
            this.btnView.Name = "btnView";
            this.btnView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnView.Size = new System.Drawing.Size(115, 32);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnView.SymbolColor = System.Drawing.Color.White;
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.Tooltip = "View";
            this.btnView.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // ChkAllCategories
            // 
            this.ChkAllCategories.AutoSize = true;
            this.ChkAllCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllCategories.Location = new System.Drawing.Point(325, 58);
            this.ChkAllCategories.Name = "ChkAllCategories";
            this.ChkAllCategories.Size = new System.Drawing.Size(84, 21);
            this.ChkAllCategories.TabIndex = 147;
            this.ChkAllCategories.Text = "Category";
            this.ChkAllCategories.UseVisualStyleBackColor = true;
            this.ChkAllCategories.CheckedChanged += new System.EventHandler(this.ChkAllCategories_CheckedChanged);
            // 
            // ChkAllSections
            // 
            this.ChkAllSections.AutoSize = true;
            this.ChkAllSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllSections.Location = new System.Drawing.Point(33, 59);
            this.ChkAllSections.Name = "ChkAllSections";
            this.ChkAllSections.Size = new System.Drawing.Size(74, 21);
            this.ChkAllSections.TabIndex = 146;
            this.ChkAllSections.Text = "Section";
            this.ChkAllSections.UseVisualStyleBackColor = true;
            this.ChkAllSections.CheckedChanged += new System.EventHandler(this.ChkAllSections_CheckedChanged);
            // 
            // ChkListCatagory
            // 
            this.ChkListCatagory.CheckOnClick = true;
            this.ChkListCatagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkListCatagory.FormattingEnabled = true;
            this.ChkListCatagory.Location = new System.Drawing.Point(322, 81);
            this.ChkListCatagory.Name = "ChkListCatagory";
            this.ChkListCatagory.Size = new System.Drawing.Size(276, 310);
            this.ChkListCatagory.TabIndex = 145;
            this.ChkListCatagory.TabStop = false;
            // 
            // ChkListSection
            // 
            this.ChkListSection.CheckOnClick = true;
            this.ChkListSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkListSection.FormattingEnabled = true;
            this.ChkListSection.Location = new System.Drawing.Point(30, 81);
            this.ChkListSection.Name = "ChkListSection";
            this.ChkListSection.Size = new System.Drawing.Size(276, 310);
            this.ChkListSection.TabIndex = 144;
            this.ChkListSection.TabStop = false;
            this.ChkListSection.SelectedIndexChanged += new System.EventHandler(this.ChkListSection_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 80);
            this.panel2.TabIndex = 148;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Price Structure";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1115, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.btnView);
            this.groupPanel1.Controls.Add(this.ChkAllCategories);
            this.groupPanel1.Controls.Add(this.drpDistributor);
            this.groupPanel1.Controls.Add(this.ChkAllSections);
            this.groupPanel1.Controls.Add(this.ChkListSection);
            this.groupPanel1.Controls.Add(this.ChkListCatagory);
            this.groupPanel1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(116, 101);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(638, 462);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 149;
            // 
            // FormReportItemPriceStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 658);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportItemPriceStructure";
            this.Load += new System.EventHandler(this.FormReportItemPriceStructure_Load);
            this.Resize += new System.EventHandler(this.FormReportItemPriceStructure_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpDistributor;
        public DevComponents.DotNetBar.ButtonX btnView;
        private System.Windows.Forms.CheckBox ChkAllCategories;
        private System.Windows.Forms.CheckBox ChkAllSections;
        private System.Windows.Forms.CheckedListBox ChkListCatagory;
        private System.Windows.Forms.CheckedListBox ChkListSection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}