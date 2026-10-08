namespace CORNPointOfSale
{
    partial class FormPromotion
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
            this.txttoDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtFromdate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.txtSeach = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboxSchem = new System.Windows.Forms.ComboBox();
            this.lblScheem = new System.Windows.Forms.Label();
            this.cboxPrincipal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChbActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnNew = new DevComponents.DotNetBar.ButtonX();
            this.btnPromotion = new DevComponents.DotNetBar.ButtonX();
            this.btnFilter = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.CboxSearchType = new System.Windows.Forms.ComboBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnActive = new DevComponents.DotNetBar.ButtonX();
            this.GridPromotions = new System.Windows.Forms.DataGridView();
            this.ChkAllGrid = new System.Windows.Forms.CheckBox();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txttoDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPromotions)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txttoDate
            // 
            // 
            // 
            // 
            this.txttoDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txttoDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txttoDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txttoDate.ButtonDropDown.Visible = true;
            this.txttoDate.CustomFormat = "dd-MMM-yyyy";
            this.txttoDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttoDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txttoDate.IsPopupCalendarOpen = false;
            this.txttoDate.Location = new System.Drawing.Point(270, 79);
            // 
            // 
            // 
            this.txttoDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txttoDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txttoDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txttoDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txttoDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txttoDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txttoDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txttoDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txttoDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txttoDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txttoDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txttoDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txttoDate.MonthCalendar.TodayButtonVisible = true;
            this.txttoDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txttoDate.Name = "txttoDate";
            this.txttoDate.Size = new System.Drawing.Size(227, 23);
            this.txttoDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txttoDate.TabIndex = 8;
            // 
            // txtFromdate
            // 
            // 
            // 
            // 
            this.txtFromdate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFromdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromdate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFromdate.ButtonDropDown.Visible = true;
            this.txtFromdate.ButtonFreeText.Checked = true;
            this.txtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.txtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromdate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtFromdate.FreeTextEntryMode = true;
            this.txtFromdate.IsPopupCalendarOpen = false;
            this.txtFromdate.Location = new System.Drawing.Point(37, 79);
            // 
            // 
            // 
            this.txtFromdate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromdate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromdate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFromdate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFromdate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromdate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtFromdate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtFromdate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtFromdate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFromdate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFromdate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFromdate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromdate.MonthCalendar.TodayButtonVisible = true;
            this.txtFromdate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Size = new System.Drawing.Size(227, 23);
            this.txtFromdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFromdate.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(267, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 98;
            this.label10.Text = "To Date";
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.BackColor = System.Drawing.Color.Transparent;
            this.lblChequeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeDate.Location = new System.Drawing.Point(34, 59);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(74, 17);
            this.lblChequeDate.TabIndex = 94;
            this.lblChequeDate.Text = "From Date";
            // 
            // txtSeach
            // 
            // 
            // 
            // 
            this.txtSeach.Border.Class = "TextBoxBorder";
            this.txtSeach.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSeach.DisabledBackColor = System.Drawing.Color.White;
            this.txtSeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeach.Location = new System.Drawing.Point(562, 258);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.PreventEnterBeep = true;
            this.txtSeach.Size = new System.Drawing.Size(193, 23);
            this.txtSeach.TabIndex = 123;
            this.txtSeach.TabStop = false;
            this.txtSeach.Visible = false;
            this.txtSeach.WatermarkText = "Search";
            // 
            // cboxSchem
            // 
            this.cboxSchem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSchem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSchem.FormattingEnabled = true;
            this.cboxSchem.Location = new System.Drawing.Point(50, 353);
            this.cboxSchem.Name = "cboxSchem";
            this.cboxSchem.Size = new System.Drawing.Size(227, 24);
            this.cboxSchem.TabIndex = 129;
            this.cboxSchem.TabStop = false;
            this.cboxSchem.Visible = false;
            // 
            // lblScheem
            // 
            this.lblScheem.AutoSize = true;
            this.lblScheem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheem.Location = new System.Drawing.Point(47, 333);
            this.lblScheem.Name = "lblScheem";
            this.lblScheem.Size = new System.Drawing.Size(59, 17);
            this.lblScheem.TabIndex = 130;
            this.lblScheem.Text = "Scheem";
            this.lblScheem.Visible = false;
            // 
            // cboxPrincipal
            // 
            this.cboxPrincipal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxPrincipal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPrincipal.FormattingEnabled = true;
            this.cboxPrincipal.Location = new System.Drawing.Point(37, 30);
            this.cboxPrincipal.Name = "cboxPrincipal";
            this.cboxPrincipal.Size = new System.Drawing.Size(460, 24);
            this.cboxPrincipal.TabIndex = 131;
            this.cboxPrincipal.TabStop = false;
            this.cboxPrincipal.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 132;
            this.label1.Text = "Principal";
            this.label1.Visible = false;
            // 
            // ChbActive
            // 
            this.ChbActive.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ChbActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbActive.Location = new System.Drawing.Point(37, 105);
            this.ChbActive.Name = "ChbActive";
            this.ChbActive.Size = new System.Drawing.Size(100, 23);
            this.ChbActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChbActive.TabIndex = 120;
            this.ChbActive.Text = "Is Active";
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(459, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(38, 17);
            this.chkAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAll.TabIndex = 133;
            this.chkAll.Text = "All";
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.Green;
            this.btnNew.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnNew.FocusCuesEnabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnNew.Location = new System.Drawing.Point(997, 247);
            this.btnNew.Name = "btnNew";
            this.btnNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
            this.btnNew.Size = new System.Drawing.Size(130, 35);
            this.btnNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNew.SymbolColor = System.Drawing.Color.White;
            this.btnNew.TabIndex = 136;
            this.btnNew.Text = "New Promotion";
            this.btnNew.TextColor = System.Drawing.Color.White;
            this.btnNew.Tooltip = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPromotion
            // 
            this.btnPromotion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPromotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPromotion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPromotion.FocusCuesEnabled = false;
            this.btnPromotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromotion.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnPromotion.Location = new System.Drawing.Point(861, 247);
            this.btnPromotion.Name = "btnPromotion";
            this.btnPromotion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlG);
            this.btnPromotion.Size = new System.Drawing.Size(130, 35);
            this.btnPromotion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPromotion.SymbolColor = System.Drawing.Color.White;
            this.btnPromotion.TabIndex = 135;
            this.btnPromotion.Text = "Get Promotion";
            this.btnPromotion.TextColor = System.Drawing.Color.White;
            this.btnPromotion.Tooltip = "Get Promotions";
            this.btnPromotion.Click += new System.EventHandler(this.btnPromotion_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFilter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFilter.FocusCuesEnabled = false;
            this.btnFilter.Location = new System.Drawing.Point(753, 257);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(36, 24);
            this.btnFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFilter.Symbol = "";
            this.btnFilter.SymbolColor = System.Drawing.Color.White;
            this.btnFilter.SymbolSize = 12F;
            this.btnFilter.TabIndex = 124;
            this.btnFilter.TabStop = false;
            this.btnFilter.Visible = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(559, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 127;
            this.label2.Text = "Search By";
            this.label2.Visible = false;
            // 
            // CboxSearchType
            // 
            this.CboxSearchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboxSearchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboxSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxSearchType.FormattingEnabled = true;
            this.CboxSearchType.Location = new System.Drawing.Point(562, 224);
            this.CboxSearchType.Name = "CboxSearchType";
            this.CboxSearchType.Size = new System.Drawing.Size(227, 24);
            this.CboxSearchType.TabIndex = 126;
            this.CboxSearchType.TabStop = false;
            this.CboxSearchType.Visible = false;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel2.Controls.Add(this.lblChequeDate);
            this.groupPanel2.Controls.Add(this.txtFromdate);
            this.groupPanel2.Controls.Add(this.label10);
            this.groupPanel2.Controls.Add(this.txttoDate);
            this.groupPanel2.Controls.Add(this.chkAll);
            this.groupPanel2.Controls.Add(this.ChbActive);
            this.groupPanel2.Controls.Add(this.cboxPrincipal);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(12, 143);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(544, 139);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
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
            this.groupPanel2.TabIndex = 137;
            // 
            // btnActive
            // 
            this.btnActive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnActive.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnActive.FocusCuesEnabled = false;
            this.btnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnActive.Location = new System.Drawing.Point(1133, 247);
            this.btnActive.Name = "btnActive";
            this.btnActive.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnActive.Size = new System.Drawing.Size(130, 35);
            this.btnActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActive.Symbol = "";
            this.btnActive.SymbolColor = System.Drawing.Color.White;
            this.btnActive.TabIndex = 138;
            this.btnActive.Text = "Active";
            this.btnActive.TextColor = System.Drawing.Color.White;
            this.btnActive.Tooltip = "Active/Inactive";
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // GridPromotions
            // 
            this.GridPromotions.AllowUserToAddRows = false;
            this.GridPromotions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPromotions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridPromotions.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPromotions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridPromotions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPromotions.Location = new System.Drawing.Point(12, 288);
            this.GridPromotions.Name = "GridPromotions";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPromotions.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridPromotions.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridPromotions.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridPromotions.RowTemplate.Height = 30;
            this.GridPromotions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridPromotions.Size = new System.Drawing.Size(1251, 273);
            this.GridPromotions.TabIndex = 139;
            this.GridPromotions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPromotions_CellContentClick);
            // 
            // ChkAllGrid
            // 
            this.ChkAllGrid.AutoSize = true;
            this.ChkAllGrid.Location = new System.Drawing.Point(32, 305);
            this.ChkAllGrid.Name = "ChkAllGrid";
            this.ChkAllGrid.Size = new System.Drawing.Size(15, 14);
            this.ChkAllGrid.TabIndex = 140;
            this.ChkAllGrid.UseVisualStyleBackColor = true;
            this.ChkAllGrid.Visible = false;
            this.ChkAllGrid.CheckedChanged += new System.EventHandler(this.ChkAllGrid_CheckedChanged);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 50;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 80);
            this.panel1.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(277, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Promotion Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1193, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 623);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChkAllGrid);
            this.Controls.Add(this.GridPromotions);
            this.Controls.Add(this.btnPromotion);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.CboxSearchType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtSeach);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cboxSchem);
            this.Controls.Add(this.lblScheem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPromotion";
            this.Load += new System.EventHandler(this.FormPromotion_Load);
            this.Shown += new System.EventHandler(this.FormPromotion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txttoDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPromotions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput txttoDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFromdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblChequeDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSeach;
        private System.Windows.Forms.ComboBox cboxSchem;
        private System.Windows.Forms.Label lblScheem;
        private System.Windows.Forms.ComboBox cboxPrincipal;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.CheckBoxX ChbActive;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private DevComponents.DotNetBar.ButtonX btnNew;
        private DevComponents.DotNetBar.ButtonX btnPromotion;
        private DevComponents.DotNetBar.ButtonX btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboxSearchType;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridView GridPromotions;
        private System.Windows.Forms.CheckBox ChkAllGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}