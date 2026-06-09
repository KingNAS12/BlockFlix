namespace BlockFlix_Application
{
    partial class MovieReviewScreen
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
            cmbReportType = new ComboBox();
            btnLoadReport = new Button();
            dgvReports = new DataGridView();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(48, 47);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(221, 28);
            cmbReportType.TabIndex = 3;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            // 
            // btnLoadReport
            // 
            btnLoadReport.Location = new Point(48, 100);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Size = new Size(132, 29);
            btnLoadReport.TabIndex = 4;
            btnLoadReport.Text = "Load Report ";
            btnLoadReport.UseVisualStyleBackColor = true;
            btnLoadReport.Click += btnLoadReport_Click;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(111, 150);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(624, 288);
            dgvReports.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(307, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(154, 20);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Movie Review Report ";
            lblTitle.Click += lblTitle_Click;
            // 
            // MovieReviewScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(dgvReports);
            Controls.Add(btnLoadReport);
            Controls.Add(cmbReportType);
            Name = "MovieReviewScreen";
            Text = "MovieReviewScreen";
            Load += MovieReviewScreen_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button btnLoadReport;
        private DataGridView dataGridView1;
        private Label lblTitle;
        private ComboBox cmbReportType;
        private DataGridView dgvReports;
    }
}