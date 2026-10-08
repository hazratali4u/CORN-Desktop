namespace CORNPointOfSale
{
    partial class FormStockAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboxDocumentType = new System.Windows.Forms.ComboBox();
            this.cboxDocumentNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxDistributor = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocumentNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboxSkuCode = new System.Windows.Forms.ComboBox();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.chkByScan = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSkuCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSkuName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveDocument = new DevComponents.DotNetBar.ButtonX();
            this.GridPurchase = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPurchase)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel2.Controls.Add(this.cboxDocumentType);
            this.groupPanel2.Controls.Add(this.cboxDocumentNo);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.cboxDistributor);
            this.groupPanel2.Controls.Add(this.lblLocation);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.txtDocumentNumber);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(3, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(627, 167);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.White;
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
            this.groupPanel2.TabIndex = 113;
            // 
            // cboxDocumentType
            // 
            this.cboxDocumentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDocumentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDocumentType.FormattingEnabled = true;
            this.cboxDocumentType.Location = new System.Drawing.Point(52, 34);
            this.cboxDocumentType.Name = "cboxDocumentType";
            this.cboxDocumentType.Size = new System.Drawing.Size(227, 24);
            this.cboxDocumentType.TabIndex = 1;
            this.cboxDocumentType.SelectedIndexChanged += new System.EventHandler(this.cboxDocumentType_SelectedIndexChanged);
            // 
            // cboxDocumentNo
            // 
            this.cboxDocumentNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDocumentNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDocumentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDocumentNo.FormattingEnabled = true;
            this.cboxDocumentNo.Location = new System.Drawing.Point(349, 34);
            this.cboxDocumentNo.Name = "cboxDocumentNo";
            this.cboxDocumentNo.Size = new System.Drawing.Size(227, 24);
            this.cboxDocumentNo.TabIndex = 2;
            this.cboxDocumentNo.SelectedIndexChanged += new System.EventHandler(this.cboxDocumentNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "Document No";
            // 
            // cboxDistributor
            // 
            this.cboxDistributor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDistributor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDistributor.FormattingEnabled = true;
            this.cboxDistributor.Location = new System.Drawing.Point(52, 108);
            this.cboxDistributor.Name = "cboxDistributor";
            this.cboxDistributor.Size = new System.Drawing.Size(227, 24);
            this.cboxDistributor.TabIndex = 4;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(49, 88);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(62, 17);
            this.lblLocation.TabIndex = 92;
            this.lblLocation.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Transaction Type";
            // 
            // txtDocumentNumber
            // 
            // 
            // 
            // 
            this.txtDocumentNumber.Border.Class = "TextBoxBorder";
            this.txtDocumentNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDocumentNumber.DisabledBackColor = System.Drawing.Color.White;
            this.txtDocumentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentNumber.Location = new System.Drawing.Point(349, 109);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.PreventEnterBeep = true;
            this.txtDocumentNumber.Size = new System.Drawing.Size(227, 23);
            this.txtDocumentNumber.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 99;
            this.label6.Text = "Remarks";
            // 
            // groupPanel1
            // 
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.chkByScan);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtQuantity);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.txtSkuCode);
            this.groupPanel1.Controls.Add(this.txtSkuName);
            this.groupPanel1.Controls.Add(this.cboxSkuCode);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(3, 169);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(627, 95);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.White;
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
            this.groupPanel1.TabIndex = 114;
            this.groupPanel1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboxSkuCode
            // 
            this.cboxSkuCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxSkuCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxSkuCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSkuCode.FormattingEnabled = true;
            this.cboxSkuCode.Location = new System.Drawing.Point(42, 56);
            this.cboxSkuCode.Name = "cboxSkuCode";
            this.cboxSkuCode.Size = new System.Drawing.Size(334, 24);
            this.cboxSkuCode.TabIndex = 9;
            this.cboxSkuCode.Visible = false;
            this.cboxSkuCode.SelectedIndexChanged += new System.EventHandler(this.cboxSkuCode_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnSave.Location = new System.Drawing.Point(482, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnSave.Size = new System.Drawing.Size(99, 35);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.SymbolColor = System.Drawing.Color.White;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Add Item";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.Tooltip = "Add to GridView";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkByScan
            // 
            this.chkByScan.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkByScan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkByScan.Checked = true;
            this.chkByScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkByScan.CheckValue = "Y";
            this.chkByScan.FocusCuesEnabled = false;
            this.chkByScan.Location = new System.Drawing.Point(44, 10);
            this.chkByScan.Name = "chkByScan";
            this.chkByScan.Size = new System.Drawing.Size(115, 23);
            this.chkByScan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByScan.TabIndex = 8;
            this.chkByScan.Text = "By Scan";
            this.chkByScan.TextColor = System.Drawing.Color.Black;
            this.chkByScan.CheckedChanged += new System.EventHandler(this.chkByScan_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 102;
            this.label5.Text = "Item Description";
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.Border.Class = "TextBoxBorder";
            this.txtQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantity.DisabledBackColor = System.Drawing.Color.White;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(382, 56);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PreventEnterBeep = true;
            this.txtQuantity.Size = new System.Drawing.Size(94, 23);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(379, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 109;
            this.label11.Text = "Quantity";
            // 
            // txtSkuCode
            // 
            // 
            // 
            // 
            this.txtSkuCode.Border.Class = "TextBoxBorder";
            this.txtSkuCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSkuCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtSkuCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkuCode.Location = new System.Drawing.Point(44, 56);
            this.txtSkuCode.Name = "txtSkuCode";
            this.txtSkuCode.PreventEnterBeep = true;
            this.txtSkuCode.Size = new System.Drawing.Size(119, 23);
            this.txtSkuCode.TabIndex = 112;
            this.txtSkuCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSkuCode_KeyUp);
            // 
            // txtSkuName
            // 
            // 
            // 
            // 
            this.txtSkuName.Border.Class = "TextBoxBorder";
            this.txtSkuName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSkuName.DisabledBackColor = System.Drawing.Color.White;
            this.txtSkuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkuName.Location = new System.Drawing.Point(169, 56);
            this.txtSkuName.Name = "txtSkuName";
            this.txtSkuName.PreventEnterBeep = true;
            this.txtSkuName.Size = new System.Drawing.Size(205, 23);
            this.txtSkuName.TabIndex = 113;
            // 
            // groupPanel3
            // 
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSaveDocument);
            this.groupPanel3.Controls.Add(this.GridPurchase);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Location = new System.Drawing.Point(3, 263);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(627, 197);
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
            this.groupPanel3.TabIndex = 115;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnCancel.Location = new System.Drawing.Point(461, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.SymbolColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.Tooltip = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveDocument
            // 
            this.btnSaveDocument.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDocument.BackColor = System.Drawing.Color.Green;
            this.btnSaveDocument.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSaveDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDocument.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnSaveDocument.Location = new System.Drawing.Point(335, 152);
            this.btnSaveDocument.Name = "btnSaveDocument";
            this.btnSaveDocument.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveDocument.Size = new System.Drawing.Size(120, 35);
            this.btnSaveDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveDocument.SymbolColor = System.Drawing.Color.White;
            this.btnSaveDocument.TabIndex = 12;
            this.btnSaveDocument.Text = "Save";
            this.btnSaveDocument.TextColor = System.Drawing.Color.White;
            this.btnSaveDocument.Tooltip = "Save";
            this.btnSaveDocument.Click += new System.EventHandler(this.btnSaveDocument_Click);
            // 
            // GridPurchase
            // 
            this.GridPurchase.AllowUserToAddRows = false;
            this.GridPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPurchase.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPurchase.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridPurchase.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridPurchase.EnableHeadersVisualStyles = false;
            this.GridPurchase.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GridPurchase.Location = new System.Drawing.Point(42, 9);
            this.GridPurchase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridPurchase.Name = "GridPurchase";
            this.GridPurchase.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridPurchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridPurchase.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.GridPurchase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GridPurchase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridPurchase.Size = new System.Drawing.Size(539, 137);
            this.GridPurchase.TabIndex = 81;
            this.GridPurchase.TabStop = false;
            this.GridPurchase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPurchase_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1214, 80);
            this.panel2.TabIndex = 145;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(247, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Stock Adjustment";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1132, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel4.Controls.Add(this.groupPanel2);
            this.groupPanel4.Controls.Add(this.groupPanel1);
            this.groupPanel4.Controls.Add(this.groupPanel3);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel4.Location = new System.Drawing.Point(346, 86);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(637, 467);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 146;
            // 
            // FormStockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1214, 686);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStockAdjustment";
            this.Load += new System.EventHandler(this.FormStockAdjustment_Load);
            this.Shown += new System.EventHandler(this.FormStockAdjustment_Shown);
            this.Resize += new System.EventHandler(this.FormStockAdjustment_Resize);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPurchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ComboBox cboxDocumentType;
        private System.Windows.Forms.ComboBox cboxDocumentNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxDistributor;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDocumentNumber;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByScan;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboxSkuCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSkuCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSkuName;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridPurchase;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSaveDocument;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
    }
}