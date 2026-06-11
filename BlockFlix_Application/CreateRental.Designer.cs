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
            label2 = new Label();
            label4 = new Label();
            lblCreateRental = new Label();
            SuspendLayout();
            // 
            // comboBoxMovie
            // 
            comboBoxMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMovie.FormattingEnabled = true;
            comboBoxMovie.Location = new Point(325, 148);
            comboBoxMovie.Name = "comboBoxMovie";
            comboBoxMovie.Size = new Size(151, 28);
            comboBoxMovie.TabIndex = 0;
            comboBoxMovie.UseWaitCursor = true;
            comboBoxMovie.SelectedIndexChanged += comboBoxMovie_SelectedIndexChanged;
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(325, 223);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(151, 28);
            comboBoxCustomer.TabIndex = 1;
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
            label3.Location = new Point(405, 160);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 4;
            // 
            // buttonCreateRental
            // 
            buttonCreateRental.Location = new Point(323, 361);
            buttonCreateRental.Name = "buttonCreateRental";
            buttonCreateRental.Size = new Size(154, 29);
            buttonCreateRental.TabIndex = 6;
            buttonCreateRental.Text = "Create Rental";
            buttonCreateRental.UseVisualStyleBackColor = true;
            buttonCreateRental.Click += buttonCreateRental_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(357, 115);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 8;
            label2.Text = "Select Movie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(347, 190);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 9;
            label4.Text = "Select Customer";
            // 
            // lblCreateRental
            // 
            lblCreateRental.AutoSize = true;
            lblCreateRental.BackColor = SystemColors.ButtonShadow;
            lblCreateRental.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCreateRental.Location = new Point(319, 46);
            lblCreateRental.Name = "lblCreateRental";
            lblCreateRental.Size = new Size(162, 31);
            lblCreateRental.TabIndex = 10;
            lblCreateRental.Text = "Create Rental";
            // 
            // CreateRental
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCreateRental);
            Controls.Add(label4);
            Controls.Add(label2);
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
        private Label label2;
        private Label label4;
        private Label lblCreateRental;
    }
}