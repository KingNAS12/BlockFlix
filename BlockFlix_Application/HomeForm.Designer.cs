namespace BlockFlix_Application
{
    partial class HomeForm
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
            lblWelcome = new Label();
            btnViewRentalHistory = new Button();
            btnViewMovies = new Button();
            btnViewRequests = new Button();
            btnViewMonthlyIncome = new Button();
            btnReviews = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(351, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnViewRentalHistory
            // 
            btnViewRentalHistory.Location = new Point(66, 70);
            btnViewRentalHistory.Name = "btnViewRentalHistory";
            btnViewRentalHistory.Size = new Size(153, 29);
            btnViewRentalHistory.TabIndex = 1;
            btnViewRentalHistory.Text = "View Rental History";
            btnViewRentalHistory.UseVisualStyleBackColor = true;
            // 
            // btnViewMovies
            // 
            btnViewMovies.Location = new Point(487, 70);
            btnViewMovies.Name = "btnViewMovies";
            btnViewMovies.Size = new Size(143, 29);
            btnViewMovies.TabIndex = 2;
            btnViewMovies.Text = "View Movies";
            btnViewMovies.UseVisualStyleBackColor = true;
            // 
            // btnViewRequests
            // 
            btnViewRequests.Location = new Point(66, 163);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(143, 29);
            btnViewRequests.TabIndex = 3;
            btnViewRequests.Text = "View Rentals";
            btnViewRequests.UseVisualStyleBackColor = true;
            // 
            // btnViewMonthlyIncome
            // 
            btnViewMonthlyIncome.Location = new Point(487, 163);
            btnViewMonthlyIncome.Name = "btnViewMonthlyIncome";
            btnViewMonthlyIncome.Size = new Size(163, 29);
            btnViewMonthlyIncome.TabIndex = 4;
            btnViewMonthlyIncome.Text = "View Monthly Income ";
            btnViewMonthlyIncome.UseVisualStyleBackColor = true;
            // 
            // btnReviews
            // 
            btnReviews.Location = new Point(66, 245);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(94, 29);
            btnReviews.TabIndex = 5;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(487, 245);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnReviews);
            Controls.Add(btnViewMonthlyIncome);
            Controls.Add(btnViewRequests);
            Controls.Add(btnViewMovies);
            Controls.Add(btnViewRentalHistory);
            Controls.Add(lblWelcome);
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnViewRentalHistory;
        private Button btnViewMovies;
        private Button btnViewRequests;
        private Button btnViewMonthlyIncome;
        private Button btnReviews;
        private Button btnLogout;
    }
}