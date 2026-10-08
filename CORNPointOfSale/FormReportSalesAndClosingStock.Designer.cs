namespace CORNPointOfSale
{
    partial class FormReportSalesAndClosingStock
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
            this.label4 = new System.Windows.Forms.Label();
            this.DrpReportType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DrpUnitType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddDistributorType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.drpDistributor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.DrpPrincipal = new System.Windows.Forms.ComboBox();
            this.ChkListCatagory = new System.Windows.Forms.CheckedListBox();
            this.ChkListSection = new System.Windows.Forms.CheckedListBox();
            this.ChkAllSections = new System.Windows.Forms.CheckBox();
            this.ChkAllCategories = new System.Windows.Forms.CheckBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 124;
            this.label4.Text = "Report Type";
            // 
            // DrpReportType
            // 
            this.DrpReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpReportType.FormattingEnabled = true;
            this.DrpReportType.Items.AddRange(new object[] {
            "Closing Stock",
            "Damage",
            "Purchase",
            "Sales",
            "Sales Return"});
            this.DrpReportType.Location = new System.Drawing.Point(140, 15);
            this.DrpReportType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpReportType.Name = "DrpReportType";
            this.DrpReportType.Size = new System.Drawing.Size(238, 24);
            this.DrpReportType.TabIndex = 0;
            this.DrpReportType.SelectedIndexChanged += new System.EventHandler(this.DrpReportType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 122;
            this.label5.Text = "Value Type";
            // 
            // DrpUnitType
            // 
            this.DrpUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpUnitType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpUnitType.FormattingEnabled = true;
            this.DrpUnitType.Items.AddRange(new object[] {
            "Carton",
            "Pieces"});
            this.DrpUnitType.Location = new System.Drawing.Point(473, 15);
            this.DrpUnitType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpUnitType.Name = "DrpUnitType";
            this.DrpUnitType.Size = new System.Drawing.Size(238, 24);
            this.DrpUnitType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Location Type";
            // 
            // ddDistributorType
            // 
            this.ddDistributorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDistributorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddDistributorType.FormattingEnabled = true;
            this.ddDistributorType.Location = new System.Drawing.Point(140, 45);
            this.ddDistributorType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddDistributorType.Name = "ddDistributorType";
            this.ddDistributorType.Size = new System.Drawing.Size(238, 24);
            this.ddDistributorType.TabIndex = 2;
            this.ddDistributorType.SelectedIndexChanged += new System.EventHandler(this.ddDistributorType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(389, 47);
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
            this.drpDistributor.Location = new System.Drawing.Point(473, 45);
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
            this.label1.Location = new System.Drawing.Point(389, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "To Date";
            // 
            // txtEndDate
            // 
            // 
            // 
            // 
            this.txtEndDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtEndDate.ButtonDropDown.Visible = true;
            this.txtEndDate.CustomFormat = "dd-MMM-yyyy";
            this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtEndDate.IsPopupCalendarOpen = false;
            this.txtEndDate.Location = new System.Drawing.Point(473, 75);
            // 
            // 
            // 
            this.txtEndDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtEndDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtEndDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtEndDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndDate.MonthCalendar.TodayButtonVisible = true;
            this.txtEndDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(238, 23);
            this.txtEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtEndDate.TabIndex = 5;
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.BackColor = System.Drawing.Color.Green;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.FocusCuesEnabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnView.Location = new System.Drawing.Point(670, 432);
            this.btnView.Name = "btnView";
            this.btnView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnView.Size = new System.Drawing.Size(115, 32);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnView.SymbolColor = System.Drawing.Color.White;
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.Tooltip = "View";
            this.btnView.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(20, 76);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 17);
            this.lblDate.TabIndex = 100;
            this.lblDate.Text = "From Date";
            // 
            // txtStartDate
            // 
            // 
            // 
            // 
            this.txtStartDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtStartDate.ButtonDropDown.Visible = true;
            this.txtStartDate.CustomFormat = "dd-MMM-yyyy";
            this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtStartDate.IsPopupCalendarOpen = false;
            this.txtStartDate.Location = new System.Drawing.Point(140, 75);
            // 
            // 
            // 
            this.txtStartDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtStartDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtStartDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtStartDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartDate.MonthCalendar.TodayButtonVisible = true;
            this.txtStartDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(238, 23);
            this.txtStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtStartDate.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(400, 188);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 127;
            this.label6.Text = "principal";
            this.label6.Visible = false;
            // 
            // DrpPrincipal
            // 
            this.DrpPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpPrincipal.FormattingEnabled = true;
            this.DrpPrincipal.Items.AddRange(new object[] {
            "Closing Stock",
            "Damage",
            "Opeing Stock",
            "Purchase",
            "Sales",
            "Sales Return"});
            this.DrpPrincipal.Location = new System.Drawing.Point(520, 185);
            this.DrpPrincipal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpPrincipal.Name = "DrpPrincipal";
            this.DrpPrincipal.Size = new System.Drawing.Size(93, 24);
            this.DrpPrincipal.Sorted = true;
            this.DrpPrincipal.TabIndex = 126;
            this.DrpPrincipal.Visible = false;
            // 
            // ChkListCatagory
            // 
            this.ChkListCatagory.CheckOnClick = true;
            this.ChkListCatagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkListCatagory.FormattingEnabled = true;
            this.ChkListCatagory.Location = new System.Drawing.Point(388, 154);
            this.ChkListCatagory.Name = "ChkListCatagory";
            this.ChkListCatagory.Size = new System.Drawing.Size(276, 310);
            this.ChkListCatagory.TabIndex = 137;
            this.ChkListCatagory.TabStop = false;
            // 
            // ChkListSection
            // 
            this.ChkListSection.CheckOnClick = true;
            this.ChkListSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkListSection.FormattingEnabled = true;
            this.ChkListSection.Location = new System.Drawing.Point(55, 154);
            this.ChkListSection.Name = "ChkListSection";
            this.ChkListSection.Size = new System.Drawing.Size(276, 310);
            this.ChkListSection.TabIndex = 136;
            this.ChkListSection.TabStop = false;
            this.ChkListSection.Click += new System.EventHandler(this.ChkListSection_Click);
            this.ChkListSection.SelectedIndexChanged += new System.EventHandler(this.ChkListSection_SelectedIndexChanged);
            // 
            // ChkAllSections
            // 
            this.ChkAllSections.AutoSize = true;
            this.ChkAllSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllSections.Location = new System.Drawing.Point(58, 132);
            this.ChkAllSections.Name = "ChkAllSections";
            this.ChkAllSections.Size = new System.Drawing.Size(74, 21);
            this.ChkAllSections.TabIndex = 138;
            this.ChkAllSections.Text = "Section";
            this.ChkAllSections.UseVisualStyleBackColor = true;
            this.ChkAllSections.CheckedChanged += new System.EventHandler(this.ChkAllSections_CheckedChanged);
            // 
            // ChkAllCategories
            // 
            this.ChkAllCategories.AutoSize = true;
            this.ChkAllCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllCategories.Location = new System.Drawing.Point(391, 131);
            this.ChkAllCategories.Name = "ChkAllCategories";
            this.ChkAllCategories.Size = new System.Drawing.Size(84, 21);
            this.ChkAllCategories.TabIndex = 139;
            this.ChkAllCategories.Text = "Category";
            this.ChkAllCategories.UseVisualStyleBackColor = true;
            this.ChkAllCategories.CheckedChanged += new System.EventHandler(this.ChkAllCategories_CheckedChanged);
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.Color.Silver;
            this.line1.Location = new System.Drawing.Point(5, 106);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(733, 23);
            this.line1.TabIndex = 140;
            this.line1.Text = "line1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1354, 80);
            this.panel2.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(330, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Sales and Closing Stock";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1272, 7);
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
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.drpDistributor);
            this.groupPanel1.Controls.Add(this.line1);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.ChkAllCategories);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.ChkAllSections);
            this.groupPanel1.Controls.Add(this.ddDistributorType);
            this.groupPanel1.Controls.Add(this.ChkListCatagory);
            this.groupPanel1.Controls.Add(this.txtEndDate);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.ChkListSection);
            this.groupPanel1.Controls.Add(this.btnView);
            this.groupPanel1.Controls.Add(this.DrpPrincipal);
            this.groupPanel1.Controls.Add(this.DrpUnitType);
            this.groupPanel1.Controls.Add(this.lblDate);
            this.groupPanel1.Controls.Add(this.DrpReportType);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtStartDate);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(12, 86);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(798, 480);
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
            this.groupPanel1.TabIndex = 142;
            // 
            // FormReportSalesAndClosingStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 700);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportSalesAndClosingStock";
            this.Load += new System.EventHandler(this.FormReportSalesAndClosingStock_Load);
            this.Resize += new System.EventHandler(this.FormReportSalesAndClosingStock_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX btnView;
        private System.Windows.Forms.Label lblDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtStartDate;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DrpReportType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DrpUnitType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddDistributorType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpDistributor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DrpPrincipal;
        private System.Windows.Forms.CheckedListBox ChkListCatagory;
        private System.Windows.Forms.CheckedListBox ChkListSection;
        private System.Windows.Forms.CheckBox ChkAllCategories;
        private System.Windows.Forms.CheckBox ChkAllSections;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}