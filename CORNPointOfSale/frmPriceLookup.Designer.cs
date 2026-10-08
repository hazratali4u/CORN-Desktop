namespace CORNPointOfSale
{
    partial class frmPriceLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriceLookup));
            this.GrdPriceLookup = new System.Windows.Forms.DataGridView();
            this.SKU_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRADE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLOSING_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceLookup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrdPriceLookup
            // 
            this.GrdPriceLookup.AllowUserToAddRows = false;
            this.GrdPriceLookup.AllowUserToDeleteRows = false;
            this.GrdPriceLookup.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdPriceLookup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrdPriceLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdPriceLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SKU_ID,
            this.SKU_CODE,
            this.SKU_NAME,
            this.TRADE_PRICE,
            this.CLOSING_STOCK});
            this.GrdPriceLookup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPriceLookup.Location = new System.Drawing.Point(0, 101);
            this.GrdPriceLookup.Name = "GrdPriceLookup";
            this.GrdPriceLookup.ReadOnly = true;
            this.GrdPriceLookup.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdPriceLookup.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GrdPriceLookup.RowTemplate.Height = 27;
            this.GrdPriceLookup.Size = new System.Drawing.Size(784, 366);
            this.GrdPriceLookup.TabIndex = 0;
            this.GrdPriceLookup.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPriceLookup_CellContentDoubleClick);
            this.GrdPriceLookup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdPurchase_KeyDown);
            // 
            // SKU_ID
            // 
            this.SKU_ID.HeaderText = "SKUID";
            this.SKU_ID.Name = "SKU_ID";
            this.SKU_ID.ReadOnly = true;
            this.SKU_ID.Visible = false;
            // 
            // SKU_CODE
            // 
            this.SKU_CODE.HeaderText = "Item Code";
            this.SKU_CODE.Name = "SKU_CODE";
            this.SKU_CODE.ReadOnly = true;
            this.SKU_CODE.Width = 120;
            // 
            // SKU_NAME
            // 
            this.SKU_NAME.HeaderText = "Item Name";
            this.SKU_NAME.Name = "SKU_NAME";
            this.SKU_NAME.ReadOnly = true;
            this.SKU_NAME.Width = 420;
            // 
            // TRADE_PRICE
            // 
            this.TRADE_PRICE.HeaderText = "Unit Price";
            this.TRADE_PRICE.Name = "TRADE_PRICE";
            this.TRADE_PRICE.ReadOnly = true;
            this.TRADE_PRICE.Width = 120;
            // 
            // CLOSING_STOCK
            // 
            this.CLOSING_STOCK.HeaderText = "Closing Stock";
            this.CLOSING_STOCK.Name = "CLOSING_STOCK";
            this.CLOSING_STOCK.ReadOnly = true;
            this.CLOSING_STOCK.Width = 120;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(2, 72);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(297, 23);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.WatermarkText = "Search SKU Code or Name";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.BackColor = System.Drawing.Color.Green;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.FocusCuesEnabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSearch.Location = new System.Drawing.Point(301, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4);
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF);
            this.btnSearch.Size = new System.Drawing.Size(37, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.Symbol = "";
            this.btnSearch.SymbolColor = System.Drawing.Color.White;
            this.btnSearch.SymbolSize = 12F;
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Tooltip = "Find";
            this.btnSearch.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 66);
            this.panel1.TabIndex = 76;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(23, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(288, 50);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Price Lookup";
            // 
            // frmPriceLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnSearch;
            this.ClientSize = new System.Drawing.Size(784, 467);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GrdPriceLookup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPriceLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPriceLookup_Load);
            this.Shown += new System.EventHandler(this.frmPriceLookup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GrdPriceLookup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GrdPriceLookup;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRADE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLOSING_STOCK;
    }
}