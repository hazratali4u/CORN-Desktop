namespace CORNPointOfSale
{
    partial class FormEmployeeInformation
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
            this.txtSearchEmployee = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxDistributor = new System.Windows.Forms.ComboBox();
            this.btnActiveEmployee = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNewEmployee = new DevComponents.DotNetBar.ButtonX();
            this.GridEmployeeInformation = new System.Windows.Forms.DataGridView();
            this.ChkAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridEmployeeInformation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchEmployee
            // 
            // 
            // 
            // 
            this.txtSearchEmployee.Border.Class = "TextBoxBorder";
            this.txtSearchEmployee.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchEmployee.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchEmployee.Location = new System.Drawing.Point(11, 164);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.PreventEnterBeep = true;
            this.txtSearchEmployee.Size = new System.Drawing.Size(331, 23);
            this.txtSearchEmployee.TabIndex = 53;
            this.txtSearchEmployee.TabStop = false;
            this.txtSearchEmployee.WatermarkText = "Search";
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Location";
            // 
            // cboxDistributor
            // 
            this.cboxDistributor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxDistributor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDistributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDistributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDistributor.FormattingEnabled = true;
            this.cboxDistributor.Location = new System.Drawing.Point(11, 134);
            this.cboxDistributor.Name = "cboxDistributor";
            this.cboxDistributor.Size = new System.Drawing.Size(331, 24);
            this.cboxDistributor.TabIndex = 60;
            this.cboxDistributor.TabStop = false;
            this.cboxDistributor.SelectedIndexChanged += new System.EventHandler(this.cboxDistributor_SelectedIndexChanged);
            // 
            // btnActiveEmployee
            // 
            this.btnActiveEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnActiveEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveEmployee.BackColor = System.Drawing.Color.Green;
            this.btnActiveEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnActiveEmployee.FocusCuesEnabled = false;
            this.btnActiveEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmployee.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnActiveEmployee.Location = new System.Drawing.Point(1179, 152);
            this.btnActiveEmployee.Name = "btnActiveEmployee";
            this.btnActiveEmployee.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlT);
            this.btnActiveEmployee.Size = new System.Drawing.Size(120, 35);
            this.btnActiveEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnActiveEmployee.Symbol = "";
            this.btnActiveEmployee.SymbolColor = System.Drawing.Color.White;
            this.btnActiveEmployee.TabIndex = 66;
            this.btnActiveEmployee.Text = "Active";
            this.btnActiveEmployee.TextColor = System.Drawing.Color.White;
            this.btnActiveEmployee.Tooltip = "Active/Inactive";
            this.btnActiveEmployee.Click += new System.EventHandler(this.btnActiveEmployee_Click);
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddNewEmployee.FocusCuesEnabled = false;
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewEmployee.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnAddNewEmployee.Location = new System.Drawing.Point(1053, 152);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAddNewEmployee.Size = new System.Drawing.Size(120, 35);
            this.btnAddNewEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNewEmployee.Symbol = "";
            this.btnAddNewEmployee.SymbolColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.TabIndex = 65;
            this.btnAddNewEmployee.Text = "Add";
            this.btnAddNewEmployee.TextColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.Tooltip = "Add New";
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            this.btnAddNewEmployee.MouseLeave += new System.EventHandler(this.btnAddNewEmployee_MouseLeave);
            this.btnAddNewEmployee.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAddNewEmployee_MouseMove);
            // 
            // GridEmployeeInformation
            // 
            this.GridEmployeeInformation.AllowUserToAddRows = false;
            this.GridEmployeeInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEmployeeInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridEmployeeInformation.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridEmployeeInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridEmployeeInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridEmployeeInformation.Location = new System.Drawing.Point(11, 193);
            this.GridEmployeeInformation.Name = "GridEmployeeInformation";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridEmployeeInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridEmployeeInformation.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridEmployeeInformation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridEmployeeInformation.RowTemplate.Height = 30;
            this.GridEmployeeInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridEmployeeInformation.Size = new System.Drawing.Size(1290, 351);
            this.GridEmployeeInformation.TabIndex = 67;
            this.GridEmployeeInformation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridEmployeeInformation_CellContentClick);
            // 
            // ChkAll
            // 
            this.ChkAll.AutoSize = true;
            this.ChkAll.Location = new System.Drawing.Point(31, 198);
            this.ChkAll.Name = "ChkAll";
            this.ChkAll.Size = new System.Drawing.Size(15, 14);
            this.ChkAll.TabIndex = 68;
            this.ChkAll.UseVisualStyleBackColor = true;
            this.ChkAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 80);
            this.panel1.TabIndex = 127;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(309, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Employee Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CORNPointOfSale.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1229, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormEmployeeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1311, 580);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChkAll);
            this.Controls.Add(this.GridEmployeeInformation);
            this.Controls.Add(this.cboxDistributor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchEmployee);
            this.Controls.Add(this.btnActiveEmployee);
            this.Controls.Add(this.btnAddNewEmployee);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEmployeeInformation";
            this.ShowInTaskbar = false;
            this.Text = "Personal Edition";
            this.Load += new System.EventHandler(this.FormEmployeeInformation_Load);
            this.Shown += new System.EventHandler(this.FormEmployeeInformation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GridEmployeeInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxDistributor;
        private DevComponents.DotNetBar.ButtonX btnActiveEmployee;
        private DevComponents.DotNetBar.ButtonX btnAddNewEmployee;
        private System.Windows.Forms.DataGridView GridEmployeeInformation;
        private System.Windows.Forms.CheckBox ChkAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}