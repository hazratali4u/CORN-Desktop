namespace CORNPointOfSale
{
    partial class FormItemsLookUp
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
            this.txtSkuCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.GridItemsLookup = new System.Windows.Forms.DataGridView();
            this.SKU_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU_SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRADE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLOSING_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboxDistributor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsLookup)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.txtSkuCode.Location = new System.Drawing.Point(209, 135);
            this.txtSkuCode.Name = "txtSkuCode";
            this.txtSkuCode.PreventEnterBeep = true;
            this.txtSkuCode.Size = new System.Drawing.Size(271, 23);
            this.txtSkuCode.TabIndex = 114;
            this.txtSkuCode.WatermarkText = "Enter Item Code";
            this.txtSkuCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkuCode_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.FocusCuesEnabled = false;
            this.btnSearch.Location = new System.Drawing.Point(479, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF);
            this.btnSearch.Size = new System.Drawing.Size(36, 24);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.Symbol = "";
            this.btnSearch.SymbolColor = System.Drawing.Color.White;
            this.btnSearch.SymbolSize = 12F;
            this.btnSearch.TabIndex = 115;
            this.btnSearch.TabStop = false;
            this.btnSearch.Tooltip = "Find Item";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // GridItemsLookup
            // 
            this.GridItemsLookup.AllowUserToAddRows = false;
            this.GridItemsLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridItemsLookup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridItemsLookup.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridItemsLookup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridItemsLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItemsLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKU_CODE,
            this.SKU_NAME,
            this.SKU_SIZE,
            this.TRADE_PRICE,
            this.CLOSING_STOCK});
            this.GridItemsLookup.Location = new System.Drawing.Point(209, 164);
            this.GridItemsLookup.Name = "GridItemsLookup";
            this.GridItemsLookup.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridItemsLookup.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridItemsLookup.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridItemsLookup.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridItemsLookup.RowTemplate.Height = 30;
            this.GridItemsLookup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridItemsLookup.Size = new System.Drawing.Size(670, 390);
            this.GridItemsLookup.TabIndex = 119;
            // 
            // SKU_CODE
            // 
            this.SKU_CODE.HeaderText = "Item Code";
            this.SKU_CODE.Name = "SKU_CODE";
            this.SKU_CODE.ReadOnly = true;
            // 
            // SKU_NAME
            // 
            this.SKU_NAME.HeaderText = "Description";
            this.SKU_NAME.Name = "SKU_NAME";
            this.SKU_NAME.ReadOnly = true;
            // 
            // SKU_SIZE
            // 
            this.SKU_SIZE.HeaderText = "Pack Size";
            this.SKU_SIZE.Name = "SKU_SIZE";
            this.SKU_SIZE.ReadOnly = true;
            // 
            // TRADE_PRICE
            // 
            this.TRADE_PRICE.HeaderText = "Price";
            this.TRADE_PRICE.Name = "TRADE_PRICE";
            this.TRADE_PRICE.ReadOnly = true;
            // 
            // CLOSING_STOCK
            // 
            this.CLOSING_STOCK.HeaderText = "Closing Stock";
            this.CLOSING_STOCK.Name = "CLOSING_STOCK";
            this.CLOSING_STOCK.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 120;
            this.label1.Text = "Enter Item Code:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 80);
            this.panel1.TabIndex = 128;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Items Lookup";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1010, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cboxDistributor
            // 
            this.cboxDistributor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDistributor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDistributor.FormattingEnabled = true;
            this.cboxDistributor.Location = new System.Drawing.Point(521, 134);
            this.cboxDistributor.Name = "cboxDistributor";
            this.cboxDistributor.Size = new System.Drawing.Size(260, 24);
            this.cboxDistributor.Sorted = true;
            this.cboxDistributor.TabIndex = 130;
            this.cboxDistributor.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(518, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 131;
            this.label2.Text = "Location";
            // 
            // FormItemsLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1092, 584);
            this.ControlBox = false;
            this.Controls.Add(this.cboxDistributor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridItemsLookup);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSkuCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormItemsLookUp";
            this.Text = "Personal Edition";
            this.Load += new System.EventHandler(this.FormItemsLookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsLookup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSkuCode;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.DataGridView GridItemsLookup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRADE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLOSING_STOCK;
        private System.Windows.Forms.ComboBox cboxDistributor;
        private System.Windows.Forms.Label label2;
    }
}