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
            lblRentalHistory = new Label();
            dgvRentalHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRentalHistory).BeginInit();
            SuspendLayout();
            // 
            // lblRentalHistory
            // 
            lblRentalHistory.AutoSize = true;
            lblRentalHistory.Location = new Point(641, 31);
            lblRentalHistory.Name = "lblRentalHistory";
            lblRentalHistory.Size = new Size(102, 20);
            lblRentalHistory.TabIndex = 0;
            lblRentalHistory.Text = "Rental History";
            // 
            // dgvRentalHistory
            // 
            dgvRentalHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRentalHistory.Location = new Point(443, 86);
            dgvRentalHistory.Name = "dgvRentalHistory";
            dgvRentalHistory.RowHeadersWidth = 51;
            dgvRentalHistory.Size = new Size(300, 188);
            dgvRentalHistory.TabIndex = 1;
            // 
            // CustomerScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvRentalHistory);
            Controls.Add(lblRentalHistory);
            Name = "CustomerScreen";
            Text = "CustomerScreen";
            ((System.ComponentModel.ISupportInitialize)dgvRentalHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRentalHistory;
        private DataGridView dgvRentalHistory;
    }
}
