namespace CORNPointOfSale
{
    partial class FormReportTrialBalance
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
            this.txtFromAccount = new System.Windows.Forms.ComboBox();
            this.txttoAccount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkAllAccounts = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.DrpLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnPostedLedger = new System.Windows.Forms.RadioButton();
            this.DrpMainAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnUnpostedLedger = new System.Windows.Forms.RadioButton();
            this.drpDistributor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnViewPDF = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
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
            // txtFromAccount
            // 
            this.txtFromAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFromAccount.DropDownWidth = 5;
            this.txtFromAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromAccount.FormattingEnabled = true;
            this.txtFromAccount.Location = new System.Drawing.Point(169, 179);
            this.txtFromAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFromAccount.Name = "txtFromAccount";
            this.txtFromAccount.Size = new System.Drawing.Size(266, 24);
            this.txtFromAccount.TabIndex = 133;
            // 
            // txttoAccount
            // 
            this.txttoAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttoAccount.DropDownWidth = 6;
            this.txttoAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttoAccount.FormattingEnabled = true;
            this.txttoAccount.Location = new System.Drawing.Point(169, 208);
            this.txttoAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txttoAccount.Name = "txttoAccount";
            this.txttoAccount.Size = new System.Drawing.Size(266, 24);
            this.txttoAccount.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 131;
            this.label6.Text = "To Account Head";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 129;
            this.label4.Text = "From Account Head";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 125;
            this.label3.Text = "Level";
            // 
            // ChkAllAccounts
            // 
            this.ChkAllAccounts.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChkAllAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkAllAccounts.FocusCuesEnabled = false;
            this.ChkAllAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAllAccounts.Location = new System.Drawing.Point(169, 147);
            this.ChkAllAccounts.Name = "ChkAllAccounts";
            this.ChkAllAccounts.Size = new System.Drawing.Size(111, 23);
            this.ChkAllAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkAllAccounts.TabIndex = 126;
            this.ChkAllAccounts.TabStop = false;
            this.ChkAllAccounts.Text = "All Accounts";
            this.ChkAllAccounts.TextColor = System.Drawing.Color.Black;
            this.ChkAllAccounts.CheckedChanged += new System.EventHandler(this.ChbSelectAll_CheckedChanged);
            // 
            // DrpLevel
            // 
            this.DrpLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpLevel.DropDownWidth = 3;
            this.DrpLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpLevel.FormattingEnabled = true;
            this.DrpLevel.Location = new System.Drawing.Point(169, 84);
            this.DrpLevel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpLevel.Name = "DrpLevel";
            this.DrpLevel.Size = new System.Drawing.Size(266, 24);
            this.DrpLevel.TabIndex = 124;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 125;
            this.label5.Text = "Main Account";
            // 
            // rbtnPostedLedger
            // 
            this.rbtnPostedLedger.AutoSize = true;
            this.rbtnPostedLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPostedLedger.Location = new System.Drawing.Point(321, 27);
            this.rbtnPostedLedger.Name = "rbtnPostedLedger";
            this.rbtnPostedLedger.Size = new System.Drawing.Size(119, 21);
            this.rbtnPostedLedger.TabIndex = 1;
            this.rbtnPostedLedger.TabStop = true;
            this.rbtnPostedLedger.Text = "Posted Ledger";
            this.rbtnPostedLedger.UseVisualStyleBackColor = true;
            // 
            // DrpMainAccount
            // 
            this.DrpMainAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrpMainAccount.DropDownWidth = 4;
            this.DrpMainAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrpMainAccount.FormattingEnabled = true;
            this.DrpMainAccount.Location = new System.Drawing.Point(169, 114);
            this.DrpMainAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DrpMainAccount.Name = "DrpMainAccount";
            this.DrpMainAccount.Size = new System.Drawing.Size(266, 24);
            this.DrpMainAccount.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 118;
            this.label2.Text = "Location";
            // 
            // rbtnUnpostedLedger
            // 
            this.rbtnUnpostedLedger.AutoSize = true;
            this.rbtnUnpostedLedger.Checked = true;
            this.rbtnUnpostedLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnUnpostedLedger.Location = new System.Drawing.Point(169, 27);
            this.rbtnUnpostedLedger.Name = "rbtnUnpostedLedger";
            this.rbtnUnpostedLedger.Size = new System.Drawing.Size(141, 21);
            this.rbtnUnpostedLedger.TabIndex = 0;
            this.rbtnUnpostedLedger.TabStop = true;
            this.rbtnUnpostedLedger.Text = "Un Posted Ledger";
            this.rbtnUnpostedLedger.UseVisualStyleBackColor = true;
            // 
            // drpDistributor
            // 
            this.drpDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDistributor.DropDownWidth = 2;
            this.drpDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpDistributor.FormattingEnabled = true;
            this.drpDistributor.Location = new System.Drawing.Point(169, 54);
            this.drpDistributor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.drpDistributor.Name = "drpDistributor";
            this.drpDistributor.Size = new System.Drawing.Size(266, 24);
            this.drpDistributor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 269);
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
            this.txtEndDate.Location = new System.Drawing.Point(169, 268);
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
            this.txtEndDate.Size = new System.Drawing.Size(266, 23);
            this.txtEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtEndDate.TabIndex = 8;
            // 
            // btnViewPDF
            // 
            this.btnViewPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnViewPDF.BackColor = System.Drawing.Color.Green;
            this.btnViewPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnViewPDF.FocusCuesEnabled = false;
            this.btnViewPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPDF.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnViewPDF.Location = new System.Drawing.Point(320, 307);
            this.btnViewPDF.Name = "btnViewPDF";
            this.btnViewPDF.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.btnViewPDF.Size = new System.Drawing.Size(115, 32);
            this.btnViewPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnViewPDF.SymbolColor = System.Drawing.Color.White;
            this.btnViewPDF.TabIndex = 9;
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
            this.label10.Location = new System.Drawing.Point(39, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "From Date";
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
            this.txtStartDate.Location = new System.Drawing.Point(169, 238);
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
            this.txtStartDate.Size = new System.Drawing.Size(266, 23);
            this.txtStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtStartDate.TabIndex = 7;
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
            this.panel2.TabIndex = 134;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Trial Balance";
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
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.rbtnUnpostedLedger);
            this.groupPanel1.Controls.Add(this.txtFromAccount);
            this.groupPanel1.Controls.Add(this.DrpMainAccount);
            this.groupPanel1.Controls.Add(this.txttoAccount);
            this.groupPanel1.Controls.Add(this.drpDistributor);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.rbtnPostedLedger);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.btnViewPDF);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtEndDate);
            this.groupPanel1.Controls.Add(this.txtStartDate);
            this.groupPanel1.Controls.Add(this.DrpLevel);
            this.groupPanel1.Controls.Add(this.ChkAllAccounts);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(450, 145);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(489, 373);
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
            this.groupPanel1.TabIndex = 135;
            // 
            // FormReportTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 584);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportTrialBalance";
            this.Load += new System.EventHandler(this.FormReportTrialBalance_Load);
            this.Resize += new System.EventHandler(this.FormReportTrialBalance_Resize);
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

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnPostedLedger;
        private System.Windows.Forms.ComboBox DrpMainAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnUnpostedLedger;
        private System.Windows.Forms.ComboBox drpDistributor;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtEndDate;
        public DevComponents.DotNetBar.ButtonX btnViewPDF;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtStartDate;
        private DevComponents.DotNetBar.Controls.CheckBoxX ChkAllAccounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DrpLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtFromAccount;
        private System.Windows.Forms.ComboBox txttoAccount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}