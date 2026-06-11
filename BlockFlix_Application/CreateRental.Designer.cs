namespace BlockFlix_Application
{
    partial class CreateRental
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
            comboBoxMovie = new ComboBox();
            comboBoxCustomer = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            buttonCreateRental = new Button();
            lblTitle = new TextBox();
            label2 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBoxMovie
            // 
            comboBoxMovie.FormattingEnabled = true;
            comboBoxMovie.Location = new Point(88, 163);
            comboBoxMovie.Name = "comboBoxMovie";
            comboBoxMovie.Size = new Size(151, 28);
            comboBoxMovie.TabIndex = 0;
            comboBoxMovie.Text = "Select Movie";
            comboBoxMovie.UseWaitCursor = true;
            comboBoxMovie.SelectedIndexChanged += comboBoxMovie_SelectedIndexChanged;
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(286, 163);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(151, 28);
            comboBoxCustomer.TabIndex = 1;
            comboBoxCustomer.Text = "Select Customer";
            comboBoxCustomer.SelectedIndexChanged += comboBoxCustomer_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 231);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 317);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 4;
            // 
            // buttonCreateRental
            // 
            buttonCreateRental.Location = new Point(491, 162);
            buttonCreateRental.Name = "buttonCreateRental";
            buttonCreateRental.Size = new Size(154, 29);
            buttonCreateRental.TabIndex = 6;
            buttonCreateRental.Text = "Create Rental";
            buttonCreateRental.UseVisualStyleBackColor = true;
            buttonCreateRental.Click += buttonCreateRental_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BackColor = SystemColors.ButtonShadow;
            lblTitle.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(167, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(435, 34);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Create Rental";
            lblTitle.TextAlign = HorizontalAlignment.Center;
            lblTitle.TextChanged += lblTitle_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 130);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 8;
            label2.Text = "Select Movie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(308, 130);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 9;
            label4.Text = "Select Customer";
            // 
            // CreateRental
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Controls.Add(buttonCreateRental);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(comboBoxCustomer);
            Controls.Add(comboBoxMovie);
            Name = "CreateRental";
            Load += CreateRental_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMovie;
        private ComboBox comboBoxCustomer;
        private Label label1;
        private Label label3;
        private Button buttonCreateRental;
        private TextBox lblTitle;
        private Label label2;
        private Label label4;
    }
}