namespace CORNPointOfSale
{
    partial class FormSKU_Group
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblGroupID = new System.Windows.Forms.Label();
            this.reflectionLabel2 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.reflectionLabel3 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.btnAddNewGroup = new DevComponents.DotNetBar.ButtonX();
            this.GridSKUgroup = new System.Windows.Forms.DataGridView();
            this.GridSKUgroupDetail = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchGroupDetail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSearchGroup = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUgroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUgroupDetail)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGroupID
            // 
            this.lblGroupID.AutoSize = true;
            this.lblGroupID.Location = new System.Drawing.Point(16, 525);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(13, 13);
            this.lblGroupID.TabIndex = 3;
            this.lblGroupID.Text = "1";
            this.lblGroupID.Visible = false;
            // 
            // reflectionLabel2
            // 
            // 
            // 
            // 
            this.reflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel2.Location = new System.Drawing.Point(35, 186);
            this.reflectionLabel2.Name = "reflectionLabel2";
            this.reflectionLabel2.ReflectionEnabled = false;
            this.reflectionLabel2.Size = new System.Drawing.Size(98, 28);
            this.reflectionLabel2.TabIndex = 58;
            this.reflectionLabel2.Text = "Group";
            // 
            // reflectionLabel3
            // 
            // 
            // 
            // 
            this.reflectionLabel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel3.Location = new System.Drawing.Point(416, 187);
            this.reflectionLabel3.Name = "reflectionLabel3";
            this.reflectionLabel3.ReflectionEnabled = false;
            this.reflectionLabel3.Size = new System.Drawing.Size(164, 27);
            this.reflectionLabel3.TabIndex = 59;
            this.reflectionLabel3.Text = "Group Detail";
            // 
            // btnAddNewGroup
            // 
            this.btnAddNewGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddNewGroup.FocusCuesEnabled = false;
            this.btnAddNewGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewGroup.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnAddNewGroup.Location = new System.Drawing.Point(1222, 171);
            this.btnAddNewGroup.Name = "btnAddNewGroup";
            this.btnAddNewGroup.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.btnAddNewGroup.Size = new System.Drawing.Size(120, 35);
            this.btnAddNewGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNewGroup.Symbol = "";
            this.btnAddNewGroup.SymbolColor = System.Drawing.Color.White;
            this.btnAddNewGroup.TabIndex = 66;
            this.btnAddNewGroup.Text = "Add";
            this.btnAddNewGroup.TextColor = System.Drawing.Color.White;
            this.btnAddNewGroup.Tooltip = "Add";
            this.btnAddNewGroup.Click += new System.EventHandler(this.btnAddNewGroup_Click);
            // 
            // GridSKUgroup
            // 
            this.GridSKUgroup.AllowUserToAddRows = false;
            this.GridSKUgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridSKUgroup.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUgroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridSKUgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSKUgroup.Location = new System.Drawing.Point(35, 220);
            this.GridSKUgroup.Name = "GridSKUgroup";
            this.GridSKUgroup.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUgroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridSKUgroup.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridSKUgroup.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridSKUgroup.RowTemplate.Height = 30;
            this.GridSKUgroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridSKUgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridSKUgroup.Size = new System.Drawing.Size(375, 421);
            this.GridSKUgroup.TabIndex = 68;
            this.GridSKUgroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSKUgroup_CellContentClick);
            this.GridSKUgroup.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridSKUgroup_RowHeaderMouseClick);
            this.GridSKUgroup.MouseHover += new System.EventHandler(this.GridSKUgroup_MouseHover);
            // 
            // GridSKUgroupDetail
            // 
            this.GridSKUgroupDetail.AllowUserToAddRows = false;
            this.GridSKUgroupDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridSKUgroupDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridSKUgroupDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUgroupDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridSKUgroupDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridSKUgroupDetail.Location = new System.Drawing.Point(416, 221);
            this.GridSKUgroupDetail.Name = "GridSKUgroupDetail";
            this.GridSKUgroupDetail.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridSKUgroupDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GridSKUgroupDetail.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.GridSKUgroupDetail.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridSKUgroupDetail.RowTemplate.Height = 30;
            this.GridSKUgroupDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridSKUgroupDetail.Size = new System.Drawing.Size(926, 420);
            this.GridSKUgroupDetail.TabIndex = 69;
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
            this.panel2.TabIndex = 131;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 37);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Group";
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
            // txtSearchGroupDetail
            // 
            // 
            // 
            // 
            this.txtSearchGroupDetail.Border.Class = "TextBoxBorder";
            this.txtSearchGroupDetail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchGroupDetail.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchGroupDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchGroupDetail.Location = new System.Drawing.Point(551, 186);
            this.txtSearchGroupDetail.Name = "txtSearchGroupDetail";
            this.txtSearchGroupDetail.PreventEnterBeep = true;
            this.txtSearchGroupDetail.Size = new System.Drawing.Size(316, 23);
            this.txtSearchGroupDetail.TabIndex = 132;
            this.txtSearchGroupDetail.WatermarkText = "Search";
            this.txtSearchGroupDetail.TextChanged += new System.EventHandler(this.txtSearchGroupDetail_TextChanged);
            // 
            // txtSearchGroup
            // 
            // 
            // 
            // 
            this.txtSearchGroup.Border.Class = "TextBoxBorder";
            this.txtSearchGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchGroup.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchGroup.Location = new System.Drawing.Point(105, 186);
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.PreventEnterBeep = true;
            this.txtSearchGroup.Size = new System.Drawing.Size(305, 23);
            this.txtSearchGroup.TabIndex = 133;
            this.txtSearchGroup.WatermarkText = "Search";
            this.txtSearchGroup.TextChanged += new System.EventHandler(this.txtSearchGroup_TextChanged);
            // 
            // FormSKU_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 695);
            this.ControlBox = false;
            this.Controls.Add(this.txtSearchGroup);
            this.Controls.Add(this.txtSearchGroupDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GridSKUgroupDetail);
            this.Controls.Add(this.GridSKUgroup);
            this.Controls.Add(this.btnAddNewGroup);
            this.Controls.Add(this.reflectionLabel3);
            this.Controls.Add(this.reflectionLabel2);
            this.Controls.Add(this.lblGroupID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSKU_Group";
            this.Load += new System.EventHandler(this.FormSKU_Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUgroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSKUgroupDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGroupID;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel2;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel3;
        private DevComponents.DotNetBar.ButtonX btnAddNewGroup;
        private System.Windows.Forms.DataGridView GridSKUgroup;
        private System.Windows.Forms.DataGridView GridSKUgroupDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchGroupDetail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchGroup;
    }
}