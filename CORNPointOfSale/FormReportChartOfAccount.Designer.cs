namespace CORNPointOfSale
{
    partial class FormReportChartOfAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.DrpSubType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DrpDetailType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DrpAccountCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrpMainType = new System.Windows.Forms.ComboBox();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 129;
            this.label1.Text = "Account Sub Type";
            // 
            // DrpSubType
            // 
            this.DrpSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpSubType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpSubType.FormattingEnabled = true;
            this.DrpSubType.Location = new System.Drawing.Point(194, 98);
            this.DrpSubType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpSubType.Name = "DrpSubType";
            this.DrpSubType.Size = new System.Drawing.Size(238, 24);
            this.DrpSubType.TabIndex = 2;
            this.DrpSubType.SelectedIndexChanged += new System.EventHandler(this.DrpSubType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 128;
            this.label4.Text = "Account Detail Type";
            // 
            // DrpDetailType
            // 
            this.DrpDetailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpDetailType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpDetailType.FormattingEnabled = true;
            this.DrpDetailType.Location = new System.Drawing.Point(194, 132);
            this.DrpDetailType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpDetailType.Name = "DrpDetailType";
            this.DrpDetailType.Size = new System.Drawing.Size(238, 24);
            this.DrpDetailType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Account Category";
            // 
            // DrpAccountCategory
            // 
            this.DrpAccountCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpAccountCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpAccountCategory.FormattingEnabled = true;
            this.DrpAccountCategory.Location = new System.Drawing.Point(194, 30);
            this.DrpAccountCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpAccountCategory.Name = "DrpAccountCategory";
            this.DrpAccountCategory.Size = new System.Drawing.Size(238, 24);
            this.DrpAccountCategory.TabIndex = 0;
            this.DrpAccountCategory.SelectedIndexChanged += new System.EventHandler(this.DrpAccountCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 118;
            this.label2.Text = "Account Type";
            // 
            // DrpMainType
            // 
            this.DrpMainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpMainType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpMainType.FormattingEnabled = true;
            this.DrpMainType.Location = new System.Drawing.Point(194, 64);
            this.DrpMainType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpMainType.Name = "DrpMainType";
            this.DrpMainType.Size = new System.Drawing.Size(238, 24);
            this.DrpMainType.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.BackColor = System.Drawing.Color.Green;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.FocusCuesEnabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnView.Location = new System.Drawing.Point(317, 168);
            this.btnView.Name = "btnView";
            this.btnView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnView.Size = new System.Drawing.Size(115, 32);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnView.SymbolColor = System.Drawing.Color.White;
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.Tooltip = "View";
            this.btnView.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1276, 80);
            this.panel2.TabIndex = 131;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(239, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Chart of Account";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1194, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.Panel1.Controls.Add(this.label3);
            this.Panel1.Controls.Add(this.DrpAccountCategory);
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.DrpSubType);
            this.Panel1.Controls.Add(this.DrpMainType);
            this.Panel1.Controls.Add(this.label4);
            this.Panel1.Controls.Add(this.DrpDetailType);
            this.Panel1.Controls.Add(this.btnView);
            this.Panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(0, 208);
            this.Panel1.MaximumSize = new System.Drawing.Size(476, 236);
            this.Panel1.MinimumSize = new System.Drawing.Size(476, 236);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(476, 236);
            // 
            // 
            // 
            this.Panel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panel1.Style.BackColorGradientAngle = 90;
            this.Panel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderBottomWidth = 1;
            this.Panel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Panel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderLeftWidth = 1;
            this.Panel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderRightWidth = 1;
            this.Panel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Panel1.Style.BorderTopWidth = 1;
            this.Panel1.Style.CornerDiameter = 4;
            this.Panel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Panel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.Panel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Panel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.Panel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.Panel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Panel1.TabIndex = 132;
            // 
            // FormReportChartOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 590);
            this.ControlBox = false;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportChartOfAccount";
            this.Load += new System.EventHandler(this.FormReportChartOfAccount_Load);
            this.Resize += new System.EventHandler(this.FormReportChartOfAccount_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DrpAccountCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DrpMainType;
        public DevComponents.DotNetBar.ButtonX btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DrpSubType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DrpDetailType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel Panel1;
    }
}