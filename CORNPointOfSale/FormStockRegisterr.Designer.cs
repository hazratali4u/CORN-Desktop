namespace CORNPointOfSale
{
    partial class FormStockRegisterr
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
            this.label4 = new System.Windows.Forms.Label();
            this.cboxDocumentType = new System.Windows.Forms.ComboBox();
            this.lblToLocation = new System.Windows.Forms.Label();
            this.cboxPrincipal = new System.Windows.Forms.ComboBox();
            this.lblFromLocation = new System.Windows.Forms.Label();
            this.cboxDistributor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxDocumentNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuiltyno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumentNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxSkuCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTradePrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQuantity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboxTransferFor = new System.Windows.Forms.ComboBox();
            this.lblTransferFor = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.chkByScan = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtSkuCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSkuName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveDocument = new DevComponents.DotNetBar.ButtonX();
            this.GridPurchase = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtDiscountTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAmountTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuantityTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTital = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Transaction Type";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cboxDocumentType
            // 
            this.cboxDocumentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDocumentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDocumentType.FormattingEnabled = true;
            this.cboxDocumentType.Location = new System.Drawing.Point(30, 175);
            this.cboxDocumentType.Name = "cboxDocumentType";
            this.cboxDocumentType.Size = new System.Drawing.Size(227, 24);
            this.cboxDocumentType.TabIndex = 1;
            this.cboxDocumentType.SelectedIndexChanged += new System.EventHandler(this.cboxDocumentType_SelectedIndexChanged);
            // 
            // lblToLocation
            // 
            this.lblToLocation.AutoSize = true;
            this.lblToLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblToLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToLocation.Location = new System.Drawing.Point(312, 72);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(60, 17);
            this.lblToLocation.TabIndex = 93;
            this.lblToLocation.Text = "Supplier";
            // 
            // cboxPrincipal
            // 
            this.cboxPrincipal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxPrincipal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPrincipal.FormattingEnabled = true;
            this.cboxPrincipal.Location = new System.Drawing.Point(315, 92);
            this.cboxPrincipal.Name = "cboxPrincipal";
            this.cboxPrincipal.Size = new System.Drawing.Size(227, 24);
            this.cboxPrincipal.TabIndex = 3;
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.AutoSize = true;
            this.lblFromLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblFromLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromLocation.Location = new System.Drawing.Point(312, 16);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(93, 17);
            this.lblFromLocation.TabIndex = 92;
            this.lblFromLocation.Text = "Purchase For";
            // 
            // cboxDistributor
            // 
            this.cboxDistributor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDistributor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDistributor.FormattingEnabled = true;
            this.cboxDistributor.Location = new System.Drawing.Point(315, 36);
            this.cboxDistributor.Name = "cboxDistributor";
            this.cboxDistributor.Size = new System.Drawing.Size(227, 24);
            this.cboxDistributor.TabIndex = 4;
            this.cboxDistributor.SelectedIndexChanged += new System.EventHandler(this.cboxDistributor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 91;
            this.label1.Text = "Document No";
            // 
            // cboxDocumentNo
            // 
            this.cboxDocumentNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDocumentNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDocumentNo.FormattingEnabled = true;
            this.cboxDocumentNo.Location = new System.Drawing.Point(16, 36);
            this.cboxDocumentNo.Name = "cboxDocumentNo";
            this.cboxDocumentNo.Size = new System.Drawing.Size(227, 24);
            this.cboxDocumentNo.TabIndex = 2;
            this.cboxDocumentNo.SelectedIndexChanged += new System.EventHandler(this.cboxDocumentNo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 100;
            this.label9.Text = "Builty No";
            // 
            // txtBuiltyno
            // 
            // 
            // 
            // 
            this.txtBuiltyno.Border.Class = "TextBoxBorder";
            this.txtBuiltyno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuiltyno.DisabledBackColor = System.Drawing.Color.White;
            this.txtBuiltyno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuiltyno.Location = new System.Drawing.Point(16, 92);
            this.txtBuiltyno.Name = "txtBuiltyno";
            this.txtBuiltyno.PreventEnterBeep = true;
            this.txtBuiltyno.Size = new System.Drawing.Size(227, 23);
            this.txtBuiltyno.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(611, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 99;
            this.label6.Text = "INV/DC No";
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
            this.txtDocumentNumber.Location = new System.Drawing.Point(614, 36);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.PreventEnterBeep = true;
            this.txtDocumentNumber.Size = new System.Drawing.Size(227, 23);
            this.txtDocumentNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 102;
            this.label5.Text = "Item Description";
            // 
            // cboxSkuCode
            // 
            this.cboxSkuCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxSkuCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxSkuCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSkuCode.FormattingEnabled = true;
            this.cboxSkuCode.Location = new System.Drawing.Point(16, 56);
            this.cboxSkuCode.Name = "cboxSkuCode";
            this.cboxSkuCode.Size = new System.Drawing.Size(340, 24);
            this.cboxSkuCode.TabIndex = 9;
            this.cboxSkuCode.Visible = false;
            this.cboxSkuCode.SelectedIndexChanged += new System.EventHandler(this.cboxSkuCode_SelectedIndexChanged);
            this.cboxSkuCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboxSkuCode_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(659, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 106;
            this.label7.Text = "Amount";
            // 
            // txtAmount
            // 
            // 
            // 
            // 
            this.txtAmount.Border.Class = "TextBoxBorder";
            this.txtAmount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmount.DisabledBackColor = System.Drawing.Color.White;
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(662, 56);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PreventEnterBeep = true;
            this.txtAmount.Size = new System.Drawing.Size(94, 23);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(559, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 105;
            this.label8.Text = "Sale Price";
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
            this.txtTradePrice.Location = new System.Drawing.Point(562, 56);
            this.txtTradePrice.Name = "txtTradePrice";
            this.txtTradePrice.PreventEnterBeep = true;
            this.txtTradePrice.Size = new System.Drawing.Size(94, 23);
            this.txtTradePrice.TabIndex = 12;
            this.txtTradePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(460, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 110;
            this.label10.Text = "Cost Price";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.Border.Class = "TextBoxBorder";
            this.txtPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrice.DisabledBackColor = System.Drawing.Color.White;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(462, 56);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PreventEnterBeep = true;
            this.txtPrice.Size = new System.Drawing.Size(94, 23);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(359, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 109;
            this.label11.Text = "Quantity";
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
            this.txtQuantity.Location = new System.Drawing.Point(362, 56);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PreventEnterBeep = true;
            this.txtQuantity.Size = new System.Drawing.Size(94, 23);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // groupPanel2
            // 
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel2.Controls.Add(this.cboxTransferFor);
            this.groupPanel2.Controls.Add(this.lblTransferFor);
            this.groupPanel2.Controls.Add(this.cboxDocumentNo);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.cboxDistributor);
            this.groupPanel2.Controls.Add(this.lblToLocation);
            this.groupPanel2.Controls.Add(this.cboxPrincipal);
            this.groupPanel2.Controls.Add(this.lblFromLocation);
            this.groupPanel2.Controls.Add(this.txtDocumentNumber);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.Controls.Add(this.txtBuiltyno);
            this.groupPanel2.Controls.Add(this.label9);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(3, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(869, 144);
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
            this.groupPanel2.TabIndex = 112;
            // 
            // cboxTransferFor
            // 
            this.cboxTransferFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxTransferFor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxTransferFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTransferFor.FormattingEnabled = true;
            this.cboxTransferFor.Location = new System.Drawing.Point(315, 92);
            this.cboxTransferFor.Name = "cboxTransferFor";
            this.cboxTransferFor.Size = new System.Drawing.Size(227, 24);
            this.cboxTransferFor.TabIndex = 7;
            // 
            // lblTransferFor
            // 
            this.lblTransferFor.AutoSize = true;
            this.lblTransferFor.BackColor = System.Drawing.Color.Transparent;
            this.lblTransferFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferFor.Location = new System.Drawing.Point(312, 72);
            this.lblTransferFor.Name = "lblTransferFor";
            this.lblTransferFor.Size = new System.Drawing.Size(83, 17);
            this.lblTransferFor.TabIndex = 102;
            this.lblTransferFor.Text = "Transfer To";
            // 
            // groupPanel1
            // 
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel1.Controls.Add(this.cboxSkuCode);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.chkByScan);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtQuantity);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.txtAmount);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.txtPrice);
            this.groupPanel1.Controls.Add(this.txtTradePrice);
            this.groupPanel1.Controls.Add(this.txtSkuCode);
            this.groupPanel1.Controls.Add(this.txtSkuName);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(3, 145);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(869, 95);
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
            this.groupPanel1.TabIndex = 113;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.FocusCuesEnabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnSave.Location = new System.Drawing.Point(762, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnSave.Size = new System.Drawing.Size(98, 35);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.SymbolColor = System.Drawing.Color.White;
            this.btnSave.TabIndex = 114;
            this.btnSave.Text = "Add Item";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.Tooltip = "Add";
            this.btnSave.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.chkByScan.Location = new System.Drawing.Point(16, 3);
            this.chkByScan.Name = "chkByScan";
            this.chkByScan.Size = new System.Drawing.Size(70, 23);
            this.chkByScan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByScan.TabIndex = 8;
            this.chkByScan.Text = "By Scan";
            this.chkByScan.TextColor = System.Drawing.Color.Black;
            this.chkByScan.CheckedChanged += new System.EventHandler(this.chkByScan_CheckedChanged);
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
            this.txtSkuCode.Location = new System.Drawing.Point(16, 56);
            this.txtSkuCode.Name = "txtSkuCode";
            this.txtSkuCode.PreventEnterBeep = true;
            this.txtSkuCode.Size = new System.Drawing.Size(135, 23);
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
            this.txtSkuName.Location = new System.Drawing.Point(157, 56);
            this.txtSkuName.Name = "txtSkuName";
            this.txtSkuName.PreventEnterBeep = true;
            this.txtSkuName.Size = new System.Drawing.Size(199, 23);
            this.txtSkuName.TabIndex = 113;
            // 
            // groupPanel3
            // 
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSaveDocument);
            this.groupPanel3.Controls.Add(this.GridPurchase);
            this.groupPanel3.Controls.Add(this.txtDiscountTotal);
            this.groupPanel3.Controls.Add(this.label13);
            this.groupPanel3.Controls.Add(this.txtAmountTotal);
            this.groupPanel3.Controls.Add(this.label14);
            this.groupPanel3.Controls.Add(this.txtQuantityTotal);
            this.groupPanel3.Controls.Add(this.label16);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Location = new System.Drawing.Point(3, 239);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(869, 211);
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
            this.groupPanel3.TabIndex = 114;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnCancel.Location = new System.Drawing.Point(729, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.SymbolColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 19;
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
            this.btnSaveDocument.Location = new System.Drawing.Point(603, 161);
            this.btnSaveDocument.Name = "btnSaveDocument";
            this.btnSaveDocument.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveDocument.Size = new System.Drawing.Size(120, 35);
            this.btnSaveDocument.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveDocument.SymbolColor = System.Drawing.Color.White;
            this.btnSaveDocument.TabIndex = 18;
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
            this.GridPurchase.Location = new System.Drawing.Point(13, 9);
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
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.GridPurchase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GridPurchase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridPurchase.Size = new System.Drawing.Size(836, 137);
            this.GridPurchase.TabIndex = 81;
            this.GridPurchase.TabStop = false;
            this.GridPurchase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPurchase_CellContentClick);
            // 
            // txtDiscountTotal
            // 
            // 
            // 
            // 
            this.txtDiscountTotal.Border.Class = "TextBoxBorder";
            this.txtDiscountTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountTotal.DisabledBackColor = System.Drawing.Color.White;
            this.txtDiscountTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountTotal.Location = new System.Drawing.Point(213, 173);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.PreventEnterBeep = true;
            this.txtDiscountTotal.Size = new System.Drawing.Size(94, 23);
            this.txtDiscountTotal.TabIndex = 17;
            this.txtDiscountTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(211, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 106;
            this.label13.Text = "Discount";
            // 
            // txtAmountTotal
            // 
            // 
            // 
            // 
            this.txtAmountTotal.Border.Class = "TextBoxBorder";
            this.txtAmountTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmountTotal.DisabledBackColor = System.Drawing.Color.White;
            this.txtAmountTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountTotal.Location = new System.Drawing.Point(113, 173);
            this.txtAmountTotal.Name = "txtAmountTotal";
            this.txtAmountTotal.PreventEnterBeep = true;
            this.txtAmountTotal.Size = new System.Drawing.Size(94, 23);
            this.txtAmountTotal.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 17);
            this.label14.TabIndex = 110;
            this.label14.Text = "Quantity";
            // 
            // txtQuantityTotal
            // 
            // 
            // 
            // 
            this.txtQuantityTotal.Border.Class = "TextBoxBorder";
            this.txtQuantityTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantityTotal.DisabledBackColor = System.Drawing.Color.White;
            this.txtQuantityTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityTotal.Location = new System.Drawing.Point(13, 173);
            this.txtQuantityTotal.Name = "txtQuantityTotal";
            this.txtQuantityTotal.PreventEnterBeep = true;
            this.txtQuantityTotal.Size = new System.Drawing.Size(94, 23);
            this.txtQuantityTotal.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(112, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 17);
            this.label16.TabIndex = 105;
            this.label16.Text = "Amount";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.lblTital);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1214, 80);
            this.panel2.TabIndex = 145;
            // 
            // lblTital
            // 
            this.lblTital.AutoSize = true;
            this.lblTital.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTital.Location = new System.Drawing.Point(12, 20);
            this.lblTital.Name = "lblTital";
            this.lblTital.Size = new System.Drawing.Size(206, 37);
            this.lblTital.TabIndex = 1;
            this.lblTital.Text = "Stock Register";
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(23, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 100);
            this.panel1.TabIndex = 146;
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
            this.groupPanel4.Location = new System.Drawing.Point(141, 104);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(879, 458);
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
            this.groupPanel4.TabIndex = 147;
            // 
            // FormStockRegisterr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1214, 686);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboxDocumentType);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStockRegisterr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormStockRegister_Load);
            this.Shown += new System.EventHandler(this.FormStockRegisterr_Shown);
            this.Resize += new System.EventHandler(this.FormStockRegisterr_Resize);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPurchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxDocumentType;
        private System.Windows.Forms.Label lblToLocation;
        private System.Windows.Forms.ComboBox cboxPrincipal;
        private System.Windows.Forms.Label lblFromLocation;
        private System.Windows.Forms.ComboBox cboxDistributor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxDocumentNo;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuiltyno;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDocumentNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxSkuCode;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAmount;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTradePrice;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrice;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQuantity;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridPurchase;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDiscountTotal;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQuantityTotal;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAmountTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByScan;
        private System.Windows.Forms.ComboBox cboxTransferFor;
        private System.Windows.Forms.Label lblTransferFor;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSkuCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSkuName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSaveDocument;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTital;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
    }
}