namespace CORNPointOfSale
{
    partial class FormReportPhysicalStockReport
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
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnValueWise = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnItemWise = new System.Windows.Forms.RadioButton();
            this.DrpLocation = new System.Windows.Forms.ComboBox();
            this.btnViewPDF = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 126;
            this.label3.Text = "Report Type";
            // 
            // rbtnValueWise
            // 
            this.rbtnValueWise.AutoSize = true;
            this.rbtnValueWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnValueWise.Location = new System.Drawing.Point(259, 32);
            this.rbtnValueWise.Name = "rbtnValueWise";
            this.rbtnValueWise.Size = new System.Drawing.Size(97, 21);
            this.rbtnValueWise.TabIndex = 1;
            this.rbtnValueWise.TabStop = true;
            this.rbtnValueWise.Text = "Value Wise";
            this.rbtnValueWise.UseVisualStyleBackColor = true;
            this.rbtnValueWise.CheckedChanged += new System.EventHandler(this.rbtnValueWise_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 118;
            this.label2.Text = "Location";
            // 
            // rbtnItemWise
            // 
            this.rbtnItemWise.AutoSize = true;
            this.rbtnItemWise.Checked = true;
            this.rbtnItemWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnItemWise.Location = new System.Drawing.Point(165, 32);
            this.rbtnItemWise.Name = "rbtnItemWise";
            this.rbtnItemWise.Size = new System.Drawing.Size(87, 21);
            this.rbtnItemWise.TabIndex = 0;
            this.rbtnItemWise.TabStop = true;
            this.rbtnItemWise.Text = "Item Wise";
            this.rbtnItemWise.UseVisualStyleBackColor = true;
            this.rbtnItemWise.CheckedChanged += new System.EventHandler(this.rbtnItemWise_CheckedChanged);
            // 
            // DrpLocation
            // 
            this.DrpLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpLocation.FormattingEnabled = true;
            this.DrpLocation.Location = new System.Drawing.Point(165, 60);
            this.DrpLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpLocation.Name = "DrpLocation";
            this.DrpLocation.Size = new System.Drawing.Size(238, 24);
            this.DrpLocation.TabIndex = 2;
            // 
            // btnViewPDF
            // 
            this.btnViewPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnViewPDF.BackColor = System.Drawing.Color.Green;
            this.btnViewPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnViewPDF.FocusCuesEnabled = false;
            this.btnViewPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPDF.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnViewPDF.Location = new System.Drawing.Point(288, 135);
            this.btnViewPDF.Name = "btnViewPDF";
            this.btnViewPDF.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnViewPDF.Size = new System.Drawing.Size(115, 32);
            this.btnViewPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnViewPDF.SymbolColor = System.Drawing.Color.White;
            this.btnViewPDF.TabIndex = 4;
            this.btnViewPDF.Text = "View";
            this.btnViewPDF.TextColor = System.Drawing.Color.White;
            this.btnViewPDF.Tooltip = "View";
            this.btnViewPDF.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "Date";
            // 
            // txtFromDate
            // 
            // 
            // 
            // 
            this.txtFromDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFromDate.ButtonDropDown.Visible = true;
            this.txtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtFromDate.IsPopupCalendarOpen = false;
            this.txtFromDate.Location = new System.Drawing.Point(165, 95);
            // 
            // 
            // 
            this.txtFromDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFromDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFromDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtFromDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtFromDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFromDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromDate.MonthCalendar.TodayButtonVisible = true;
            this.txtFromDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(238, 23);
            this.txtFromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFromDate.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1126, 80);
            this.panel2.TabIndex = 131;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(307, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Physical Stock Taking";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1044, 7);
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
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.txtFromDate);
            this.groupPanel1.Controls.Add(this.rbtnValueWise);
            this.groupPanel1.Controls.Add(this.DrpLocation);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.btnViewPDF);
            this.groupPanel1.Controls.Add(this.rbtnItemWise);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(461, 221);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(462, 207);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
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
            this.groupPanel1.TabIndex = 132;
            // 
            // FormReportPhysicalStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1126, 577);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportPhysicalStockReport";
            this.Load += new System.EventHandler(this.FormReportPhysicalStockReport_Load);
            this.Resize += new System.EventHandler(this.FormReportPhysicalStockReport_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnValueWise;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnItemWise;
        private System.Windows.Forms.ComboBox DrpLocation;
        public DevComponents.DotNetBar.ButtonX btnViewPDF;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}