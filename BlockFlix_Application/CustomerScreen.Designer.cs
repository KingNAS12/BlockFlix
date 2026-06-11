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
            dgvMyBlockFlixRentals = new DataGridView();
            cbxActiveRental = new CheckBox();
            cbxReturned = new CheckBox();
            cbxOverdue = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            dgvMyBlockFlixQueue = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlixRentals).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlixQueue).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(520, 23);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(157, 20);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "My BlockFlix Rentals";
            // 
            // dgvMyBlockFlixRentals
            // 
            dgvMyBlockFlixRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBlockFlixRentals.Location = new Point(261, 59);
            dgvMyBlockFlixRentals.Name = "dgvMyBlockFlixRentals";
            dgvMyBlockFlixRentals.RowHeadersWidth = 51;
            dgvMyBlockFlixRentals.Size = new Size(825, 291);
            dgvMyBlockFlixRentals.TabIndex = 1;
            // 
            // cbxActiveRental
            // 
            cbxActiveRental.AutoSize = true;
            cbxActiveRental.Checked = true;
            cbxActiveRental.CheckState = CheckState.Checked;
            cbxActiveRental.Location = new Point(261, 356);
            cbxActiveRental.Name = "cbxActiveRental";
            cbxActiveRental.Size = new Size(124, 24);
            cbxActiveRental.TabIndex = 4;
            cbxActiveRental.Text = "Active Rentals";
            cbxActiveRental.UseVisualStyleBackColor = true;
            cbxActiveRental.CheckedChanged += cbxActiveRental_CheckedChanged;
            // 
            // cbxReturned
            // 
            cbxReturned.AutoSize = true;
            cbxReturned.Checked = true;
            cbxReturned.CheckState = CheckState.Checked;
            cbxReturned.Location = new Point(484, 356);
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
            cbxOverdue.Checked = true;
            cbxOverdue.CheckState = CheckState.Checked;
            cbxOverdue.Location = new Point(391, 356);
            cbxOverdue.Name = "cbxOverdue";
            cbxOverdue.Size = new Size(87, 24);
            cbxOverdue.TabIndex = 7;
            cbxOverdue.Text = "Overdue";
            cbxOverdue.UseVisualStyleBackColor = true;
            cbxOverdue.CheckedChanged += cbxOverdue_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 59);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(233, 653);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // dgvMyBlockFlixQueue
            // 
            dgvMyBlockFlixQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBlockFlixQueue.Location = new Point(261, 407);
            dgvMyBlockFlixQueue.Name = "dgvMyBlockFlixQueue";
            dgvMyBlockFlixQueue.RowHeadersWidth = 51;
            dgvMyBlockFlixQueue.Size = new Size(923, 270);
            dgvMyBlockFlixQueue.TabIndex = 9;
            dgvMyBlockFlixQueue.CellContentClick += dataGridView1_CellContentClick;
            // 
            // CustomerScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 745);
            Controls.Add(dgvMyBlockFlixQueue);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(cbxOverdue);
            Controls.Add(cbxReturned);
            Controls.Add(cbxActiveRental);
            Controls.Add(dgvMyBlockFlixRentals);
            Controls.Add(lblCustomer);
            Name = "CustomerScreen";
            Text = "CustomerScreen";
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlixRentals).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlixQueue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private DataGridView dgvMyBlockFlixRentals;
        private CheckBox cbxActiveRental;
        private CheckBox cbxReturned;
        private CheckBox cbxOverdue;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView dgvMyBlockFlixQueue;
    }
}
