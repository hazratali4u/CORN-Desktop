namespace CORNPointOfSale
{
    partial class frmDayClose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayClose));
            this.dgvDayClose = new System.Windows.Forms.DataGridView();
            this.DISTRIBUTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACT_PERSON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACT_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLOSING_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_STAMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDayClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDayClose
            // 
            this.dgvDayClose.AllowUserToAddRows = false;
            this.dgvDayClose.AllowUserToDeleteRows = false;
            this.dgvDayClose.BackgroundColor = System.Drawing.Color.White;
            this.dgvDayClose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDayClose.ColumnHeadersVisible = false;
            this.dgvDayClose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DISTRIBUTOR_NAME,
            this.CONTACT_PERSON,
            this.CONTACT_NUMBER,
            this.CLOSING_DATE,
            this.TIME_STAMP});
            this.dgvDayClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDayClose.Location = new System.Drawing.Point(0, 80);
            this.dgvDayClose.Name = "dgvDayClose";
            this.dgvDayClose.ReadOnly = true;
            this.dgvDayClose.RowHeadersVisible = false;
            this.dgvDayClose.Size = new System.Drawing.Size(966, 220);
            this.dgvDayClose.TabIndex = 0;
            // 
            // DISTRIBUTOR_NAME
            // 
            this.DISTRIBUTOR_NAME.HeaderText = "Location Name";
            this.DISTRIBUTOR_NAME.Name = "DISTRIBUTOR_NAME";
            this.DISTRIBUTOR_NAME.ReadOnly = true;
            this.DISTRIBUTOR_NAME.Width = 200;
            // 
            // CONTACT_PERSON
            // 
            this.CONTACT_PERSON.HeaderText = "Contact Person";
            this.CONTACT_PERSON.Name = "CONTACT_PERSON";
            this.CONTACT_PERSON.ReadOnly = true;
            this.CONTACT_PERSON.Width = 200;
            // 
            // CONTACT_NUMBER
            // 
            this.CONTACT_NUMBER.HeaderText = "Contact Number";
            this.CONTACT_NUMBER.Name = "CONTACT_NUMBER";
            this.CONTACT_NUMBER.ReadOnly = true;
            this.CONTACT_NUMBER.Width = 160;
            // 
            // CLOSING_DATE
            // 
            this.CLOSING_DATE.HeaderText = "Last Close Date";
            this.CLOSING_DATE.Name = "CLOSING_DATE";
            this.CLOSING_DATE.ReadOnly = true;
            this.CLOSING_DATE.Width = 170;
            // 
            // TIME_STAMP
            // 
            this.TIME_STAMP.HeaderText = "Datetime Of Closing";
            this.TIME_STAMP.Name = "TIME_STAMP";
            this.TIME_STAMP.ReadOnly = true;
            this.TIME_STAMP.Width = 200;
            // 
            // btnDayClose
            // 
            this.btnDayClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDayClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDayClose.BackColor = System.Drawing.Color.Green;
            this.btnDayClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDayClose.FocusCuesEnabled = false;
            this.btnDayClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayClose.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnDayClose.Location = new System.Drawing.Point(839, 42);
            this.btnDayClose.Name = "btnDayClose";
            this.btnDayClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnDayClose.Size = new System.Drawing.Size(115, 32);
            this.btnDayClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDayClose.SymbolColor = System.Drawing.Color.White;
            this.btnDayClose.TabIndex = 27;
            this.btnDayClose.Text = "Day Close";
            this.btnDayClose.TextColor = System.Drawing.Color.White;
            this.btnDayClose.Tooltip = "Day Close";
            this.btnDayClose.Click += new System.EventHandler(this.btnDayClose_Click);
            // 
            // frmDayClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 300);
            this.Controls.Add(this.btnDayClose);
            this.Controls.Add(this.dgvDayClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDayClose";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDayClose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDayClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISTRIBUTOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACT_PERSON;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACT_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLOSING_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_STAMP;
        private DevComponents.DotNetBar.ButtonX btnDayClose;
    }
}