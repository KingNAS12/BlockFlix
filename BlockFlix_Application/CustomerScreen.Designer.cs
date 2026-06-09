namespace BlockFlix_Application
{
    partial class CustomerScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCustomer = new Label();
            dgvMyBlockFlix = new DataGridView();
            btnMyQueue = new Button();
            cbxActiveRental = new CheckBox();
            cbxReturned = new CheckBox();
            cbxOverdue = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlix).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(351, 53);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(157, 20);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "My BlockFlix Rentals";
            // 
            // dgvMyBlockFlix
            // 
            dgvMyBlockFlix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBlockFlix.Location = new Point(12, 76);
            dgvMyBlockFlix.Name = "dgvMyBlockFlix";
            dgvMyBlockFlix.RowHeadersWidth = 51;
            dgvMyBlockFlix.Size = new Size(776, 295);
            dgvMyBlockFlix.TabIndex = 1;
            // 
            // btnMyQueue
            // 
            btnMyQueue.Location = new Point(665, 379);
            btnMyQueue.Name = "btnMyQueue";
            btnMyQueue.Size = new Size(123, 29);
            btnMyQueue.TabIndex = 3;
            btnMyQueue.Text = "View My Queue";
            btnMyQueue.UseVisualStyleBackColor = true;
            btnMyQueue.Click += btnMyQueue_Click;
            // 
            // cbxActiveRental
            // 
            cbxActiveRental.AutoSize = true;
            cbxActiveRental.Location = new Point(12, 382);
            cbxActiveRental.Name = "cbxActiveRental";
            cbxActiveRental.Size = new Size(164, 24);
            cbxActiveRental.TabIndex = 4;
            cbxActiveRental.Text = "Show Active Rentals";
            cbxActiveRental.UseVisualStyleBackColor = true;
            cbxActiveRental.CheckedChanged += cbxActiveRental_CheckedChanged;
            // 
            // cbxReturned
            // 
            cbxReturned.AutoSize = true;
            cbxReturned.Location = new Point(182, 382);
            cbxReturned.Name = "cbxReturned";
            cbxReturned.Size = new Size(91, 24);
            cbxReturned.TabIndex = 6;
            cbxReturned.Text = "Returned";
            cbxReturned.UseVisualStyleBackColor = true;
            cbxReturned.CheckedChanged += cbxReturned_CheckedChanged;
            // 
            // cbxOverdue
            // 
            cbxOverdue.AutoSize = true;
            cbxOverdue.Location = new Point(279, 382);
            cbxOverdue.Name = "cbxOverdue";
            cbxOverdue.Size = new Size(87, 24);
            cbxOverdue.TabIndex = 7;
            cbxOverdue.Text = "Overdue";
            cbxOverdue.UseVisualStyleBackColor = true;
            cbxOverdue.CheckedChanged += cbxOverdue_CheckedChanged;
            // 
            // CustomerScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbxOverdue);
            Controls.Add(cbxReturned);
            Controls.Add(cbxActiveRental);
            Controls.Add(btnMyQueue);
            Controls.Add(dgvMyBlockFlix);
            Controls.Add(lblCustomer);
            Name = "CustomerScreen";
            Text = "CustomerScreen";
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private DataGridView dgvMyBlockFlix;
        private Button btnMyQueue;
        private CheckBox cbxActiveRental;
        private CheckBox cbxReturned;
        private CheckBox cbxOverdue;
    }
}
