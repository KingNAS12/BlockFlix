namespace BlockFlix_Application
{
    partial class ProfileForm
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
            lblTitle = new Label();
            lblUserId = new Label();
            txtUserId = new TextBox();
            txtRole = new TextBox();
            lblRole = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            lblHouseNumber = new Label();
            lblStreet = new Label();
            lblCity = new Label();
            lblProvince = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtHouseNumber = new TextBox();
            txtStreet = new TextBox();
            txtCity = new TextBox();
            txtProvince = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            lblPostalCode = new Label();
            lblPaymentIdentifier = new Label();
            txtPostalCode = new TextBox();
            txtPaymentIdentifier = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            comboBoxGender = new ComboBox();
            labelDob = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(320, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(76, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Profile";
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(39, 63);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(60, 20);
            lblUserId.TabIndex = 1;
            lblUserId.Text = "User ID:";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(163, 64);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(125, 27);
            txtUserId.TabIndex = 2;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(163, 116);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(125, 27);
            txtRole.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(39, 115);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(46, 20);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role: ";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(39, 201);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 20);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(39, 249);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 20);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Last Name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(39, 293);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblHouseNumber
            // 
            lblHouseNumber.AutoSize = true;
            lblHouseNumber.Location = new Point(366, 71);
            lblHouseNumber.Name = "lblHouseNumber";
            lblHouseNumber.Size = new Size(112, 20);
            lblHouseNumber.TabIndex = 8;
            lblHouseNumber.Text = "House Number:";
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(366, 115);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(51, 20);
            lblStreet.TabIndex = 9;
            lblStreet.Text = "Street:";
            lblStreet.Click += label7_Click;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(366, 160);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(37, 20);
            lblCity.TabIndex = 10;
            lblCity.Text = "City:";
            // 
            // lblProvince
            // 
            lblProvince.AutoSize = true;
            lblProvince.Location = new Point(366, 202);
            lblProvince.Name = "lblProvince";
            lblProvince.Size = new Size(68, 20);
            lblProvince.TabIndex = 11;
            lblProvince.Text = "Province:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(163, 201);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 12;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(163, 246);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(163, 286);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 14;
            // 
            // txtHouseNumber
            // 
            txtHouseNumber.Location = new Point(490, 64);
            txtHouseNumber.Name = "txtHouseNumber";
            txtHouseNumber.Size = new Size(125, 27);
            txtHouseNumber.TabIndex = 15;
            txtHouseNumber.TextChanged += textBox6_TextChanged;
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(482, 111);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(125, 27);
            txtStreet.TabIndex = 16;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(482, 157);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 27);
            txtCity.TabIndex = 17;
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(482, 202);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(125, 27);
            txtProvince.TabIndex = 18;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(661, 361);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(127, 29);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(663, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(366, 242);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(90, 20);
            lblPostalCode.TabIndex = 21;
            lblPostalCode.Text = "Postal Code:";
            // 
            // lblPaymentIdentifier
            // 
            lblPaymentIdentifier.AutoSize = true;
            lblPaymentIdentifier.Location = new Point(366, 290);
            lblPaymentIdentifier.Name = "lblPaymentIdentifier";
            lblPaymentIdentifier.Size = new Size(87, 20);
            lblPaymentIdentifier.TabIndex = 22;
            lblPaymentIdentifier.Text = "Payment ID:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(482, 242);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(125, 27);
            txtPostalCode.TabIndex = 23;
            // 
            // txtPaymentIdentifier
            // 
            txtPaymentIdentifier.Location = new Point(482, 287);
            txtPaymentIdentifier.Name = "txtPaymentIdentifier";
            txtPaymentIdentifier.Size = new Size(125, 27);
            txtPaymentIdentifier.TabIndex = 24;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(163, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 26;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(39, 164);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 25;
            lblPassword.Text = "Password: ";
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Male", "Female", "Other", "Prefer Not To Say" });
            comboBoxGender.Location = new Point(39, 350);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(151, 28);
            comboBoxGender.TabIndex = 27;
            // 
            // labelDob
            // 
            labelDob.AutoSize = true;
            labelDob.Location = new Point(252, 348);
            labelDob.Name = "labelDob";
            labelDob.Size = new Size(43, 20);
            labelDob.TabIndex = 28;
            labelDob.Text = "DOB:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(311, 343);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 30;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelDob);
            Controls.Add(comboBoxGender);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtPaymentIdentifier);
            Controls.Add(txtPostalCode);
            Controls.Add(lblPaymentIdentifier);
            Controls.Add(lblPostalCode);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtProvince);
            Controls.Add(txtCity);
            Controls.Add(txtStreet);
            Controls.Add(txtHouseNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblProvince);
            Controls.Add(lblCity);
            Controls.Add(lblStreet);
            Controls.Add(lblHouseNumber);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblRole);
            Controls.Add(txtRole);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            Controls.Add(lblTitle);
            Name = "ProfileForm";
            Text = "ProfileForm";
            Load += ProfileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUserId;
        private TextBox txtUserId;
        private TextBox txtRole;
        private Label lblRole;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblHouseNumber;
        private Label lblStreet;
        private Label lblCity;
        private Label lblProvince;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtHouseNumber;
        private TextBox txtStreet;
        private TextBox txtCity;
        private TextBox txtProvince;
        private Button btnSave;
        private Button btnClose;
        private Label lblPostalCode;
        private Label lblPaymentIdentifier;
        private TextBox txtPostalCode;
        private TextBox txtPaymentIdentifier;
        private TextBox txtPassword;
        private Label lblPassword;
        private ComboBox comboBoxGender;
        private Label labelDob;
        private DateTimePicker dateTimePicker1;
    }
}