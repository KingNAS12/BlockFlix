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
            lblTitle = new TextBox();
            lblRole = new TextBox();
            cboRole = new Label();
            btnContinue = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BackColor = SystemColors.ButtonShadow;
            lblTitle.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(221, 66);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(353, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BlockFlix Login";
            lblTitle.TextAlign = HorizontalAlignment.Center;
            lblTitle.TextChanged += textBox1_TextChanged;
            // 
            // lblRole
            // 
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(266, 242);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(138, 35);
            lblRole.TabIndex = 1;
            lblRole.Text = "Select Role:";
            lblRole.TextAlign = HorizontalAlignment.Center;
            lblRole.TextChanged += textBox1_TextChanged_1;
            // 
            // cboRole
            // 
            cboRole.AutoSize = true;
            cboRole.Location = new Point(450, 245);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(68, 30);
            cboRole.TabIndex = 2;
            cboRole.Text = "label1";
            cboRole.TextAlign = ContentAlignment.MiddleCenter;
            cboRole.Click += cboRole_Click;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(337, 306);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(131, 40);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 433);
            Controls.Add(btnContinue);
            Controls.Add(cboRole);
            Controls.Add(lblRole);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lblTitle;
        private TextBox lblRole;
        private Label cboRole;
        private Button btnContinue;
    }
}