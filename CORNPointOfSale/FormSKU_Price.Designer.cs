namespace CORNPointOfSale
{
    partial class FormSKU_Price
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaxPrices = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSKUName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnDownload = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEffectedDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label10 = new System.Windows.Forms.Label();
            this.chkByName = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.ChkDistributorList = new System.Windows.Forms.CheckedListBox();
            this.txtTradePrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDistributorPrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Grid_pricedetails = new System.Windows.Forms.DataGridView();
            this.lblSkuId = new System.Windows.Forms.Label();
            this.txtFromdate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_pricedetails)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(24, 102);
            this.txtCode.Name = "txtCode";
            this.txtCode.PreventEnterBeep = true;
            this.txtCode.Size = new System.Drawing.Size(197, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(743, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 68;
            this.label2.Text = "G.S.T (%)";
            // 
            // txtTaxPrices
            // 
            // 
            // 
            // 
            this.txtTaxPrices.Border.Class = "TextBoxBorder";
            this.txtTaxPrices.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTaxPrices.DisabledBackColor = System.Drawing.Color.White;
            this.txtTaxPrices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxPrices.Location = new System.Drawing.Point(745, 102);
            this.txtTaxPrices.Name = "txtTaxPrices";
            this.txtTaxPrices.PreventEnterBeep = true;
            this.txtTaxPrices.Size = new System.Drawing.Size(101, 23);
            this.txtTaxPrices.TabIndex = 4;
            this.txtTaxPrices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistributorPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(634, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Retail Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(527, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Purchase Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(225, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Item Description";
            // 
            // txtSKUName
            // 
            // 
            // 
            // 
            this.txtSKUName.Border.Class = "TextBoxBorder";
            this.txtSKUName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSKUName.Cursor = System.Windows.Forms.Cursors.No;
            this.txtSKUName.DisabledBackColor = System.Drawing.Color.White;
            this.txtSKUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSKUName.Location = new System.Drawing.Point(227, 102);
            this.txtSKUName.Name = "txtSKUName";
            this.txtSKUName.PreventEnterBeep = true;
            this.txtSKUName.Size = new System.Drawing.Size(296, 23);
            this.txtSKUName.TabIndex = 1;
            this.txtSKUName.TabStop = false;
            this.txtSKUName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSKUName_MouseDown);
            // 
            // groupPanel3
            // 
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel3.Controls.Add(this.btnImport);
            this.groupPanel3.Controls.Add(this.btnDownload);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.txtEffectedDate);
            this.groupPanel3.Controls.Add(this.label10);
            this.groupPanel3.Controls.Add(this.chkByName);
            this.groupPanel3.Controls.Add(this.chkSelectAll);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.ChkDistributorList);
            this.groupPanel3.Controls.Add(this.txtTradePrice);
            this.groupPanel3.Controls.Add(this.txtDistributorPrice);
            this.groupPanel3.Controls.Add(this.Grid_pricedetails);
            this.groupPanel3.Controls.Add(this.lblSkuId);
            this.groupPanel3.Controls.Add(this.txtTaxPrices);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.txtCode);
            this.groupPanel3.Controls.Add(this.txtSKUName);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Location = new System.Drawing.Point(147, 90);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1062, 507);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel3.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 80;
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
            this.btnImport.Location = new System.Drawing.Point(910, 19);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 35);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.Symbol = "";
            this.btnImport.SymbolColor = System.Drawing.Color.White;
            this.btnImport.TabIndex = 67;
            this.btnImport.Text = "Import";
            this.btnImport.TextColor = System.Drawing.Color.White;
            this.btnImport.Tooltip = "Import bulk prices of items in excel format";
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
            this.btnDownload.Location = new System.Drawing.Point(785, 19);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 35);
            this.btnDownload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDownload.Symbol = "";
            this.btnDownload.SymbolColor = System.Drawing.Color.White;
            this.btnDownload.TabIndex = 67;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextColor = System.Drawing.Color.White;
            this.btnDownload.Tooltip = "Download excel sheet of items to update its prices";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1016, 17);
            this.label1.TabIndex = 146;
            this.label1.Text = "_________________________________________________________________________________" +
    "_____________________________________________";
            // 
            // txtEffectedDate
            // 
            // 
            // 
            // 
            this.txtEffectedDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtEffectedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEffectedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtEffectedDate.ButtonDropDown.Visible = true;
            this.txtEffectedDate.CustomFormat = "dd-MMM-yyyy";
            this.txtEffectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEffectedDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtEffectedDate.IsPopupCalendarOpen = false;
            this.txtEffectedDate.Location = new System.Drawing.Point(24, 152);
            // 
            // 
            // 
            this.txtEffectedDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEffectedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEffectedDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtEffectedDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtEffectedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEffectedDate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.txtEffectedDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtEffectedDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtEffectedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtEffectedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtEffectedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtEffectedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEffectedDate.MonthCalendar.TodayButtonVisible = true;
            this.txtEffectedDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtEffectedDate.Name = "txtEffectedDate";
            this.txtEffectedDate.Size = new System.Drawing.Size(227, 23);
            this.txtEffectedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtEffectedDate.TabIndex = 99;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "Date Effected:";
            // 
            // chkByName
            // 
            this.chkByName.AutoSize = true;
            this.chkByName.Location = new System.Drawing.Point(24, 80);
            this.chkByName.Name = "chkByName";
            this.chkByName.Size = new System.Drawing.Size(84, 21);
            this.chkByName.TabIndex = 87;
            this.chkByName.Text = "By Name";
            this.chkByName.UseVisualStyleBackColor = true;
            this.chkByName.CheckedChanged += new System.EventHandler(this.chkByName_CheckedChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSelectAll.FocusCuesEnabled = false;
            this.chkSelectAll.Location = new System.Drawing.Point(859, 80);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 19);
            this.chkSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Location";
            this.chkSelectAll.TextColor = System.Drawing.Color.Black;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnSave.Location = new System.Drawing.Point(726, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.SymbolColor = System.Drawing.Color.White;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.Tooltip = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChkDistributorList
            // 
            this.ChkDistributorList.CheckOnClick = true;
            this.ChkDistributorList.FormattingEnabled = true;
            this.ChkDistributorList.Location = new System.Drawing.Point(857, 102);
            this.ChkDistributorList.Name = "ChkDistributorList";
            this.ChkDistributorList.ScrollAlwaysVisible = true;
            this.ChkDistributorList.Size = new System.Drawing.Size(178, 382);
            this.ChkDistributorList.TabIndex = 84;
            this.ChkDistributorList.TabStop = false;
            // 
            // txtTradePrice
            // 
            // 
            // 
            // 
            this.txtTradePrice.Border.Class = "TextBoxBorder";
            this.txtTradePrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTradePrice.DisabledBackColor = System.Drawing.Color.White;
            this.txtTradePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradePrice.Location = new System.Drawing.Point(637, 102);
            this.txtTradePrice.Name = "txtTradePrice";
            this.txtTradePrice.PreventEnterBeep = true;
            this.txtTradePrice.Size = new System.Drawing.Size(102, 23);
            this.txtTradePrice.TabIndex = 3;
            this.txtTradePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistributorPrice_KeyPress);
            // 
            // txtDistributorPrice
            // 
            // 
            // 
            // 
            this.txtDistributorPrice.Border.Class = "TextBoxBorder";
            this.txtDistributorPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDistributorPrice.DisabledBackColor = System.Drawing.Color.White;
            this.txtDistributorPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistributorPrice.Location = new System.Drawing.Point(529, 102);
            this.txtDistributorPrice.Name = "txtDistributorPrice";
            this.txtDistributorPrice.PreventEnterBeep = true;
            this.txtDistributorPrice.Size = new System.Drawing.Size(102, 23);
            this.txtDistributorPrice.TabIndex = 2;
            this.txtDistributorPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistributorPrice_KeyPress);
            // 
            // Grid_pricedetails
            // 
            this.Grid_pricedetails.AllowUserToAddRows = false;
            this.Grid_pricedetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_pricedetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_pricedetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_pricedetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Grid_pricedetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_pricedetails.Location = new System.Drawing.Point(24, 181);
            this.Grid_pricedetails.Name = "Grid_pricedetails";
            this.Grid_pricedetails.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_pricedetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Grid_pricedetails.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.Grid_pricedetails.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Grid_pricedetails.RowTemplate.Height = 30;
            this.Grid_pricedetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grid_pricedetails.Size = new System.Drawing.Size(822, 303);
            this.Grid_pricedetails.TabIndex = 86;
            // 
            // lblSkuId
            // 
            this.lblSkuId.AutoSize = true;
            this.lblSkuId.BackColor = System.Drawing.Color.Transparent;
            this.lblSkuId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkuId.Location = new System.Drawing.Point(375, 82);
            this.lblSkuId.Name = "lblSkuId";
            this.lblSkuId.Size = new System.Drawing.Size(45, 17);
            this.lblSkuId.TabIndex = 84;
            this.lblSkuId.Text = "sku id";
            this.lblSkuId.Visible = false;
            // 
            // txtFromdate
            // 
            // 
            // 
            // 
            this.txtFromdate.Border.Class = "TextBoxBorder";
            this.txtFromdate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFromdate.DisabledBackColor = System.Drawing.Color.White;
            this.txtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromdate.Location = new System.Drawing.Point(480, 334);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.PreventEnterBeep = true;
            this.txtFromdate.Size = new System.Drawing.Size(193, 23);
            this.txtFromdate.TabIndex = 84;
            this.txtFromdate.Visible = false;
            this.txtFromdate.WatermarkText = "Date";
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
            this.panel2.TabIndex = 145;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Price";
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
            // FormSKU_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 627);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.txtFromdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSKU_Price";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormSKU_Price_Load);
            this.Shown += new System.EventHandler(this.FormSKU_Price_Shown);
            this.Resize += new System.EventHandler(this.FormSKU_Price_Resize);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEffectedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_pricedetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTaxPrices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSKUName;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSelectAll;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFromdate;
        private System.Windows.Forms.CheckedListBox ChkDistributorList;
        private System.Windows.Forms.Label lblSkuId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTradePrice;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDistributorPrice;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.DataGridView Grid_pricedetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkByName;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtEffectedDate;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnDownload;
        private System.Windows.Forms.Label label1;
    }
}