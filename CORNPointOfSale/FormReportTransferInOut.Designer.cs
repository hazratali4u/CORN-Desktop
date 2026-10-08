namespace CORNPointOfSale
{
    partial class FormReportTransferInOut
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.DrpReportType = new System.Windows.Forms.ComboBox();
            this.rbtnTransferOut = new System.Windows.Forms.RadioButton();
            this.rbtnTransferIn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.drpDistributor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnViewPDF = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label4 = new System.Windows.Forms.Label();
            this.DrpPrincipal = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(34, 534);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(386, 42);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 123;
            this.label3.Text = "Report In";
            // 
            // DrpReportType
            // 
            this.DrpReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpReportType.FormattingEnabled = true;
            this.DrpReportType.Items.AddRange(new object[] {
            "Carton",
            "Quantity",
            "Value"});
            this.DrpReportType.Location = new System.Drawing.Point(182, 58);
            this.DrpReportType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpReportType.Name = "DrpReportType";
            this.DrpReportType.Size = new System.Drawing.Size(238, 24);
            this.DrpReportType.TabIndex = 2;
            this.DrpReportType.SelectedIndexChanged += new System.EventHandler(this.DrpReportType_SelectedIndexChanged);
            // 
            // rbtnTransferOut
            // 
            this.rbtnTransferOut.AutoSize = true;
            this.rbtnTransferOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTransferOut.Location = new System.Drawing.Point(318, 30);
            this.rbtnTransferOut.Name = "rbtnTransferOut";
            this.rbtnTransferOut.Size = new System.Drawing.Size(107, 21);
            this.rbtnTransferOut.TabIndex = 1;
            this.rbtnTransferOut.TabStop = true;
            this.rbtnTransferOut.Text = "Transfer Out";
            this.rbtnTransferOut.UseVisualStyleBackColor = true;
            // 
            // rbtnTransferIn
            // 
            this.rbtnTransferIn.AutoSize = true;
            this.rbtnTransferIn.Checked = true;
            this.rbtnTransferIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTransferIn.Location = new System.Drawing.Point(182, 30);
            this.rbtnTransferIn.Name = "rbtnTransferIn";
            this.rbtnTransferIn.Size = new System.Drawing.Size(95, 21);
            this.rbtnTransferIn.TabIndex = 0;
            this.rbtnTransferIn.TabStop = true;
            this.rbtnTransferIn.Text = "Transfer In";
            this.rbtnTransferIn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 92);
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
            this.drpDistributor.Location = new System.Drawing.Point(182, 91);
            this.drpDistributor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpDistributor.Name = "drpDistributor";
            this.drpDistributor.Size = new System.Drawing.Size(238, 24);
            this.drpDistributor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "To Date";
            // 
            // txtToDate
            // 
            // 
            // 
            // 
            this.txtToDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtToDate.ButtonDropDown.Visible = true;
            this.txtToDate.CustomFormat = "dd-MMM-yyyy";
            this.txtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtToDate.IsPopupCalendarOpen = false;
            this.txtToDate.Location = new System.Drawing.Point(182, 157);
            // 
            // 
            // 
            this.txtToDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtToDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtToDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtToDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtToDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtToDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtToDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToDate.MonthCalendar.TodayButtonVisible = true;
            this.txtToDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(238, 23);
            this.txtToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtToDate.TabIndex = 5;
            // 
            // btnViewPDF
            // 
            this.btnViewPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnViewPDF.BackColor = System.Drawing.Color.Green;
            this.btnViewPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnViewPDF.FocusCuesEnabled = false;
            this.btnViewPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPDF.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnViewPDF.Location = new System.Drawing.Point(305, 198);
            this.btnViewPDF.Name = "btnViewPDF";
            this.btnViewPDF.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnViewPDF.Size = new System.Drawing.Size(115, 32);
            this.btnViewPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnViewPDF.SymbolColor = System.Drawing.Color.White;
            this.btnViewPDF.TabIndex = 6;
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
            this.label10.Location = new System.Drawing.Point(44, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "From Date";
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
            this.txtFromDate.Location = new System.Drawing.Point(182, 124);
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
            this.txtFromDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 543);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 125;
            this.label4.Text = "Report In";
            // 
            // DrpPrincipal
            // 
            this.DrpPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpPrincipal.FormattingEnabled = true;
            this.DrpPrincipal.Location = new System.Drawing.Point(169, 542);
            this.DrpPrincipal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpPrincipal.Name = "DrpPrincipal";
            this.DrpPrincipal.Size = new System.Drawing.Size(238, 24);
            this.DrpPrincipal.Sorted = true;
            this.DrpPrincipal.TabIndex = 124;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1343, 80);
            this.panel2.TabIndex = 131;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(306, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Transfer in/out Report";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1261, 7);
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
            this.groupPanel1.Controls.Add(this.txtFromDate);
            this.groupPanel1.Controls.Add(this.txtToDate);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.btnViewPDF);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.DrpReportType);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.rbtnTransferOut);
            this.groupPanel1.Controls.Add(this.drpDistributor);
            this.groupPanel1.Controls.Add(this.rbtnTransferIn);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(452, 206);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(477, 264);
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
            // FormReportTransferInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 588);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DrpPrincipal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportTransferInOut";
            this.Load += new System.EventHandler(this.FormReportTransferInOut_Load);
            this.Resize += new System.EventHandler(this.FormReportTransferInOut_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DrpReportType;
        private System.Windows.Forms.RadioButton rbtnTransferOut;
        private System.Windows.Forms.RadioButton rbtnTransferIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpDistributor;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtToDate;
        public DevComponents.DotNetBar.ButtonX btnViewPDF;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DrpPrincipal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}