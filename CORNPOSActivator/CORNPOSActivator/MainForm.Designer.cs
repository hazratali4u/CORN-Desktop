namespace CORNPOSActivator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSalutation = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNtn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRenewalDate = new System.Windows.Forms.TextBox();
            this.txtSubscDate = new System.Windows.Forms.TextBox();
            this.lblRenewalDate = new System.Windows.Forms.Label();
            this.lblSubscDate = new System.Windows.Forms.Label();
            this.btnRebind = new System.Windows.Forms.Button();
            this.txtRenewalKey = new System.Windows.Forms.TextBox();
            this.btnRenewalKey = new System.Windows.Forms.Button();
            this.txtActivationKey = new System.Windows.Forms.TextBox();
            this.btnActivationKey = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.bwCustCombo = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbSalutation);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDecrypt);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(64, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 420);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Last Name";
            // 
            // cmbSalutation
            // 
            this.cmbSalutation.FormattingEnabled = true;
            this.cmbSalutation.Items.AddRange(new object[] {
            "Mr.",
            "Ms."});
            this.cmbSalutation.Location = new System.Drawing.Point(96, 353);
            this.cmbSalutation.Name = "cmbSalutation";
            this.cmbSalutation.Size = new System.Drawing.Size(48, 21);
            this.cmbSalutation.TabIndex = 8;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(269, 353);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(118, 20);
            this.txtLastName.TabIndex = 9;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(147, 353);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(118, 20);
            this.txtFirstName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Contact Person First Name";
            // 
            // txtNtn
            // 
            this.txtNtn.Location = new System.Drawing.Point(96, 191);
            this.txtNtn.Name = "txtNtn";
            this.txtNtn.ReadOnly = true;
            this.txtNtn.Size = new System.Drawing.Size(291, 20);
            this.txtNtn.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "NTN";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(96, 158);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(291, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Phone No";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(96, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(291, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save Customer to TeamSuite";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(96, 260);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(291, 73);
            this.txtAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 224);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(291, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(96, 125);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(291, 20);
            this.txtCustomerName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(96, 81);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(291, 23);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(96, 44);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(291, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Key";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtRenewalDate);
            this.groupBox2.Controls.Add(this.txtSubscDate);
            this.groupBox2.Controls.Add(this.lblRenewalDate);
            this.groupBox2.Controls.Add(this.lblSubscDate);
            this.groupBox2.Controls.Add(this.btnRebind);
            this.groupBox2.Controls.Add(this.txtRenewalKey);
            this.groupBox2.Controls.Add(this.btnRenewalKey);
            this.groupBox2.Controls.Add(this.txtActivationKey);
            this.groupBox2.Controls.Add(this.btnActivationKey);
            this.groupBox2.Controls.Add(this.cmbCustomer);
            this.groupBox2.Location = new System.Drawing.Point(626, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 420);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved Customers";
            // 
            // txtRenewalDate
            // 
            this.txtRenewalDate.Location = new System.Drawing.Point(128, 107);
            this.txtRenewalDate.Name = "txtRenewalDate";
            this.txtRenewalDate.ReadOnly = true;
            this.txtRenewalDate.Size = new System.Drawing.Size(241, 20);
            this.txtRenewalDate.TabIndex = 19;
            this.txtRenewalDate.TabStop = false;
            // 
            // txtSubscDate
            // 
            this.txtSubscDate.Location = new System.Drawing.Point(128, 78);
            this.txtSubscDate.Name = "txtSubscDate";
            this.txtSubscDate.ReadOnly = true;
            this.txtSubscDate.Size = new System.Drawing.Size(241, 20);
            this.txtSubscDate.TabIndex = 18;
            this.txtSubscDate.TabStop = false;
            // 
            // lblRenewalDate
            // 
            this.lblRenewalDate.AutoSize = true;
            this.lblRenewalDate.Location = new System.Drawing.Point(31, 110);
            this.lblRenewalDate.Name = "lblRenewalDate";
            this.lblRenewalDate.Size = new System.Drawing.Size(75, 13);
            this.lblRenewalDate.TabIndex = 17;
            this.lblRenewalDate.Text = "Renewal Date";
            // 
            // lblSubscDate
            // 
            this.lblSubscDate.AutoSize = true;
            this.lblSubscDate.Location = new System.Drawing.Point(31, 81);
            this.lblSubscDate.Name = "lblSubscDate";
            this.lblSubscDate.Size = new System.Drawing.Size(91, 13);
            this.lblSubscDate.TabIndex = 16;
            this.lblSubscDate.Text = "Subscription Date";
            // 
            // btnRebind
            // 
            this.btnRebind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRebind.BackgroundImage")));
            this.btnRebind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRebind.Location = new System.Drawing.Point(372, 42);
            this.btnRebind.Name = "btnRebind";
            this.btnRebind.Size = new System.Drawing.Size(30, 25);
            this.btnRebind.TabIndex = 11;
            this.btnRebind.UseVisualStyleBackColor = true;
            this.btnRebind.Click += new System.EventHandler(this.btnRebind_Click);
            // 
            // txtRenewalKey
            // 
            this.txtRenewalKey.Location = new System.Drawing.Point(31, 326);
            this.txtRenewalKey.Multiline = true;
            this.txtRenewalKey.Name = "txtRenewalKey";
            this.txtRenewalKey.ReadOnly = true;
            this.txtRenewalKey.Size = new System.Drawing.Size(366, 73);
            this.txtRenewalKey.TabIndex = 15;
            // 
            // btnRenewalKey
            // 
            this.btnRenewalKey.Location = new System.Drawing.Point(31, 297);
            this.btnRenewalKey.Name = "btnRenewalKey";
            this.btnRenewalKey.Size = new System.Drawing.Size(366, 23);
            this.btnRenewalKey.TabIndex = 14;
            this.btnRenewalKey.Text = "Generate Renewal Key";
            this.btnRenewalKey.UseVisualStyleBackColor = true;
            this.btnRenewalKey.Click += new System.EventHandler(this.btnRenewalKey_Click);
            // 
            // txtActivationKey
            // 
            this.txtActivationKey.Location = new System.Drawing.Point(31, 203);
            this.txtActivationKey.Multiline = true;
            this.txtActivationKey.Name = "txtActivationKey";
            this.txtActivationKey.ReadOnly = true;
            this.txtActivationKey.Size = new System.Drawing.Size(366, 73);
            this.txtActivationKey.TabIndex = 13;
            // 
            // btnActivationKey
            // 
            this.btnActivationKey.Location = new System.Drawing.Point(31, 174);
            this.btnActivationKey.Name = "btnActivationKey";
            this.btnActivationKey.Size = new System.Drawing.Size(366, 23);
            this.btnActivationKey.TabIndex = 12;
            this.btnActivationKey.Text = "Generate Activation Key";
            this.btnActivationKey.UseVisualStyleBackColor = true;
            this.btnActivationKey.Click += new System.EventHandler(this.btnActivationKey_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(31, 44);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(338, 21);
            this.cmbCustomer.TabIndex = 10;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // bwCustCombo
            // 
            this.bwCustCombo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCustCombo_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CORNPOSActivator.Properties.Resources.LoginPageBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1127, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CORN POS Activation Key Gen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.TextBox txtRenewalKey;
        private System.Windows.Forms.Button btnRenewalKey;
        private System.Windows.Forms.TextBox txtActivationKey;
        private System.Windows.Forms.Button btnActivationKey;
        private System.Windows.Forms.TextBox txtNtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRebind;
        private System.Windows.Forms.ComboBox cmbSalutation;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker bwCustCombo;
        private System.Windows.Forms.Label lblRenewalDate;
        private System.Windows.Forms.Label lblSubscDate;
        private System.Windows.Forms.TextBox txtRenewalDate;
        private System.Windows.Forms.TextBox txtSubscDate;
    }
}