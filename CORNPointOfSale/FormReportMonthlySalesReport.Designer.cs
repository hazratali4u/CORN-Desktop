namespace CORNPointOfSale
{
    partial class FormReportMonthlySalesReport
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
            this.panelYear = new System.Windows.Forms.Panel();
            this.txtEndYear = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtStartYear = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DrpUnitType = new System.Windows.Forms.ComboBox();
            this.panelDate = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label9 = new System.Windows.Forms.Label();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromMonth = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToMonth = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.DrpReportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drpDistributor = new System.Windows.Forms.ComboBox();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.rbtnTradePrice = new System.Windows.Forms.RadioButton();
            this.rbtnPurchasePrice = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.ddDistributorType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panelYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartYear)).BeginInit();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).BeginInit();
            this.panelMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToMonth)).BeginInit();
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
            this.groupPanel2.Location = new System.Drawing.Point(45, 580);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(464, 62);
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
            this.groupPanel2.TabIndex = 119;
            // 
            // panelYear
            // 
            this.panelYear.Controls.Add(this.txtEndYear);
            this.panelYear.Controls.Add(this.txtStartYear);
            this.panelYear.Controls.Add(this.label10);
            this.panelYear.Controls.Add(this.label1);
            this.panelYear.Location = new System.Drawing.Point(31, 129);
            this.panelYear.Name = "panelYear";
            this.panelYear.Size = new System.Drawing.Size(403, 76);
            this.panelYear.TabIndex = 132;
            this.panelYear.Paint += new System.Windows.Forms.PaintEventHandler(this.panelYear_Paint);
            // 
            // txtEndYear
            // 
            // 
            // 
            // 
            this.txtEndYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndYear.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtEndYear.ButtonDropDown.Visible = true;
            this.txtEndYear.CustomFormat = "yyyy";
            this.txtEndYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndYear.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtEndYear.IsPopupCalendarOpen = false;
            this.txtEndYear.Location = new System.Drawing.Point(127, 39);
            // 
            // 
            // 
            this.txtEndYear.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEndYear.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.txtEndYear.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndYear.MonthCalendar.DisplayMonth = new System.DateTime(2015, 9, 1, 0, 0, 0, 0);
            this.txtEndYear.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtEndYear.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEndYear.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndYear.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.Size = new System.Drawing.Size(238, 23);
            this.txtEndYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtEndYear.TabIndex = 4;
            // 
            // txtStartYear
            // 
            // 
            // 
            // 
            this.txtStartYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartYear.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtStartYear.ButtonDropDown.Visible = true;
            this.txtStartYear.CustomFormat = "yyyy";
            this.txtStartYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartYear.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtStartYear.IsPopupCalendarOpen = false;
            this.txtStartYear.Location = new System.Drawing.Point(127, 5);
            // 
            // 
            // 
            this.txtStartYear.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtStartYear.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.txtStartYear.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartYear.MonthCalendar.DisplayMonth = new System.DateTime(2015, 9, 1, 0, 0, 0, 0);
            this.txtStartYear.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtStartYear.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtStartYear.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartYear.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.Size = new System.Drawing.Size(238, 23);
            this.txtStartYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtStartYear.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "From Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "To Year";
            // 
            // DrpUnitType
            // 
            this.DrpUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpUnitType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpUnitType.FormattingEnabled = true;
            this.DrpUnitType.Location = new System.Drawing.Point(158, 66);
            this.DrpUnitType.Name = "DrpUnitType";
            this.DrpUnitType.Size = new System.Drawing.Size(239, 24);
            this.DrpUnitType.TabIndex = 1;
            this.DrpUnitType.SelectedIndexChanged += new System.EventHandler(this.DrpUnitType_SelectedIndexChanged);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.label8);
            this.panelDate.Controls.Add(this.txtStartDate);
            this.panelDate.Controls.Add(this.txtEndDate);
            this.panelDate.Controls.Add(this.label9);
            this.panelDate.Location = new System.Drawing.Point(31, 129);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(403, 76);
            this.panelDate.TabIndex = 130;
            this.panelDate.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 129;
            this.label8.Text = "To Date";
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
            this.txtStartDate.Location = new System.Drawing.Point(127, 5);
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
            this.txtStartDate.TabIndex = 126;
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
            this.txtEndDate.Location = new System.Drawing.Point(127, 39);
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
            this.txtEndDate.TabIndex = 128;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 127;
            this.label9.Text = "From Date";
            // 
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.label4);
            this.panelMonth.Controls.Add(this.txtFromMonth);
            this.panelMonth.Controls.Add(this.label6);
            this.panelMonth.Controls.Add(this.txtToMonth);
            this.panelMonth.Location = new System.Drawing.Point(31, 129);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Size = new System.Drawing.Size(403, 70);
            this.panelMonth.TabIndex = 131;
            this.panelMonth.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 123;
            this.label4.Text = "To Month";
            // 
            // txtFromMonth
            // 
            // 
            // 
            // 
            this.txtFromMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFromMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromMonth.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFromMonth.ButtonDropDown.Visible = true;
            this.txtFromMonth.CustomFormat = "MMM-yyyy";
            this.txtFromMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMonth.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtFromMonth.IsPopupCalendarOpen = false;
            this.txtFromMonth.Location = new System.Drawing.Point(127, 5);
            // 
            // 
            // 
            this.txtFromMonth.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromMonth.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromMonth.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFromMonth.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFromMonth.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromMonth.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtFromMonth.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtFromMonth.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromMonth.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFromMonth.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromMonth.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFromMonth.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromMonth.MonthCalendar.TodayButtonVisible = true;
            this.txtFromMonth.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtFromMonth.Name = "txtFromMonth";
            this.txtFromMonth.Size = new System.Drawing.Size(238, 23);
            this.txtFromMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFromMonth.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 121;
            this.label6.Text = "From Month";
            // 
            // txtToMonth
            // 
            // 
            // 
            // 
            this.txtToMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtToMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToMonth.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtToMonth.ButtonDropDown.Visible = true;
            this.txtToMonth.CustomFormat = "MMM-yyyy";
            this.txtToMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMonth.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtToMonth.IsPopupCalendarOpen = false;
            this.txtToMonth.Location = new System.Drawing.Point(127, 39);
            // 
            // 
            // 
            this.txtToMonth.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtToMonth.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToMonth.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtToMonth.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtToMonth.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToMonth.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtToMonth.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtToMonth.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtToMonth.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtToMonth.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtToMonth.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtToMonth.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtToMonth.MonthCalendar.TodayButtonVisible = true;
            this.txtToMonth.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtToMonth.Name = "txtToMonth";
            this.txtToMonth.Size = new System.Drawing.Size(238, 23);
            this.txtToMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtToMonth.TabIndex = 122;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 122;
            this.label5.Text = "Report Type";
            // 
            // DrpReportType
            // 
            this.DrpReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpReportType.FormattingEnabled = true;
            this.DrpReportType.Items.AddRange(new object[] {
            "Discount",
            "Gross Sale ",
            "Purchase",
            "Purchase Return",
            "Sales Return ",
            "Transfer In",
            "Transfer Out"});
            this.DrpReportType.Location = new System.Drawing.Point(158, 33);
            this.DrpReportType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpReportType.Name = "DrpReportType";
            this.DrpReportType.Size = new System.Drawing.Size(238, 24);
            this.DrpReportType.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Value Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 102);
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
            this.drpDistributor.Location = new System.Drawing.Point(158, 99);
            this.drpDistributor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpDistributor.Name = "drpDistributor";
            this.drpDistributor.Size = new System.Drawing.Size(238, 24);
            this.drpDistributor.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.BackColor = System.Drawing.Color.Green;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.FocusCuesEnabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnView.Location = new System.Drawing.Point(281, 211);
            this.btnView.Name = "btnView";
            this.btnView.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnView.Size = new System.Drawing.Size(115, 32);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnView.SymbolColor = System.Drawing.Color.White;
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.Tooltip = "View";
            this.btnView.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // rbtnTradePrice
            // 
            this.rbtnTradePrice.AutoSize = true;
            this.rbtnTradePrice.Location = new System.Drawing.Point(74, 625);
            this.rbtnTradePrice.Name = "rbtnTradePrice";
            this.rbtnTradePrice.Size = new System.Drawing.Size(80, 17);
            this.rbtnTradePrice.TabIndex = 134;
            this.rbtnTradePrice.TabStop = true;
            this.rbtnTradePrice.Text = "Trade Price";
            this.rbtnTradePrice.UseVisualStyleBackColor = true;
            // 
            // rbtnPurchasePrice
            // 
            this.rbtnPurchasePrice.AutoSize = true;
            this.rbtnPurchasePrice.Location = new System.Drawing.Point(160, 625);
            this.rbtnPurchasePrice.Name = "rbtnPurchasePrice";
            this.rbtnPurchasePrice.Size = new System.Drawing.Size(97, 17);
            this.rbtnPurchasePrice.TabIndex = 135;
            this.rbtnPurchasePrice.TabStop = true;
            this.rbtnPurchasePrice.Text = "Purchase Price";
            this.rbtnPurchasePrice.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(56, 581);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 137;
            this.label11.Text = "Location Type";
            // 
            // ddDistributorType
            // 
            this.ddDistributorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDistributorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddDistributorType.FormattingEnabled = true;
            this.ddDistributorType.Location = new System.Drawing.Point(174, 580);
            this.ddDistributorType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddDistributorType.Name = "ddDistributorType";
            this.ddDistributorType.Size = new System.Drawing.Size(238, 24);
            this.ddDistributorType.Sorted = true;
            this.ddDistributorType.TabIndex = 136;
            this.ddDistributorType.SelectedIndexChanged += new System.EventHandler(this.ddDistributorType_SelectedIndexChanged);
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
            this.panel2.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(288, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Monthly Sale Report";
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
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.btnView);
            this.groupPanel1.Controls.Add(this.panelYear);
            this.groupPanel1.Controls.Add(this.drpDistributor);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.DrpUnitType);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.panelDate);
            this.groupPanel1.Controls.Add(this.DrpReportType);
            this.groupPanel1.Controls.Add(this.panelMonth);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(452, 177);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(448, 289);
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
            this.groupPanel1.TabIndex = 139;
            // 
            // FormReportMonthlySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 666);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.rbtnPurchasePrice);
            this.Controls.Add(this.rbtnTradePrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ddDistributorType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportMonthlySalesReport";
            this.Load += new System.EventHandler(this.FormReportMonthlySalesReport_Load);
            this.Resize += new System.EventHandler(this.FormReportMonthlySalesReport_Resize);
            this.panelYear.ResumeLayout(false);
            this.panelYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartYear)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).EndInit();
            this.panelMonth.ResumeLayout(false);
            this.panelMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToMonth)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DrpReportType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpDistributor;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtEndYear;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtStartYear;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtToMonth;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFromMonth;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtEndDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Panel panelMonth;
        private System.Windows.Forms.Panel panelYear;
        private System.Windows.Forms.RadioButton rbtnTradePrice;
        private System.Windows.Forms.RadioButton rbtnPurchasePrice;
        private System.Windows.Forms.ComboBox DrpUnitType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddDistributorType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnView;
    }
}