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
            btnRentalHistory = new Button();
            btnMyQueue = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMyBlockFlix).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(355, 52);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(99, 20);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "My BlockFlix";
            // 
            // dgvMyBlockFlix
            // 
            dgvMyBlockFlix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBlockFlix.Location = new Point(250, 131);
            dgvMyBlockFlix.Name = "dgvMyBlockFlix";
            dgvMyBlockFlix.RowHeadersWidth = 51;
            dgvMyBlockFlix.Size = new Size(300, 188);
            dgvMyBlockFlix.TabIndex = 1;
            // 
            // btnRentalHistory
            // 
            btnRentalHistory.Location = new Point(200, 325);
            btnRentalHistory.Name = "btnRentalHistory";
            btnRentalHistory.Size = new Size(151, 29);
            btnRentalHistory.TabIndex = 2;
            btnRentalHistory.Text = "View Rental History";
            btnRentalHistory.UseVisualStyleBackColor = true;
            btnRentalHistory.Click += btnRentalHistory_Click;
            // 
            // btnMyQueue
            // 
            btnMyQueue.Location = new Point(477, 325);
            btnMyQueue.Name = "btnMyQueue";
            btnMyQueue.Size = new Size(123, 29);
            btnMyQueue.TabIndex = 3;
            btnMyQueue.Text = "View My Queue";
            btnMyQueue.UseVisualStyleBackColor = true;
            btnMyQueue.Click += btnMyQueue_Click;
            // 
            // CustomerScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMyQueue);
            Controls.Add(btnRentalHistory);
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
        private Button btnRentalHistory;
        private Button btnMyQueue;
    }
}
