namespace BlockFlix_Application
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnLogin = new Button();
            lblAccountNumber = new Label();
            lblPassword = new Label();
            txtAccountNumber = new TextBox();
            txtPassword = new TextBox();
            lblTitle = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.AutoSize = true;
            btnLogin.BackColor = Color.Maroon;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(855, 532);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 49);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Sign in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.BackColor = Color.Transparent;
            lblAccountNumber.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            lblAccountNumber.ForeColor = Color.WhiteSmoke;
            lblAccountNumber.Location = new Point(693, 357);
            lblAccountNumber.Margin = new Padding(4, 0, 4, 0);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(171, 25);
            lblAccountNumber.TabIndex = 4;
            lblAccountNumber.Text = "Account Number:";
            lblAccountNumber.Click += lblAccountNumber_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            lblPassword.ForeColor = Color.WhiteSmoke;
            lblPassword.Location = new Point(700, 433);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(102, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(933, 357);
            txtAccountNumber.Margin = new Padding(4);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(232, 32);
            txtAccountNumber.TabIndex = 6;
            txtAccountNumber.TextChanged += txtAccountNumber_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(933, 433);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(232, 32);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Maroon;
            lblTitle.Location = new Point(660, 72);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(533, 90);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "BLOCKFLIX";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1351, 168);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 453);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(168, 168);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(324, 453);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1855, 877);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(lblTitle);
            Controls.Add(txtPassword);
            Controls.Add(txtAccountNumber);
            Controls.Add(lblPassword);
            Controls.Add(lblAccountNumber);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private Label lblAccountNumber;
        private Label lblPassword;
        private TextBox txtAccountNumber;
        private TextBox txtPassword;
        private Label lblTitle;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}