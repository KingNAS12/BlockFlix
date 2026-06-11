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
            btnMovieLibrary = new Button();
            btnViewRequests = new Button();
            btnViewMonthlyIncome = new Button();
            btnReviews = new Button();
            btnLogout = new Button();
            btnProfile = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(329, 35);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnMovieLibrary
            // 
            btnMovieLibrary.Location = new Point(324, 169);
            btnMovieLibrary.Name = "btnMovieLibrary";
            btnMovieLibrary.Size = new Size(153, 29);
            btnMovieLibrary.TabIndex = 1;
            btnMovieLibrary.Text = "Movie Library";
            btnMovieLibrary.UseVisualStyleBackColor = true;
            // 
            // btnViewRequests
            // 
            btnViewRequests.Location = new Point(329, 80);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(143, 29);
            btnViewRequests.TabIndex = 3;
            btnViewRequests.Text = "View Rentals";
            btnViewRequests.UseVisualStyleBackColor = true;
            // 
            // btnViewMonthlyIncome
            // 
            btnViewMonthlyIncome.Location = new Point(319, 115);
            btnViewMonthlyIncome.Name = "btnViewMonthlyIncome";
            btnViewMonthlyIncome.Size = new Size(163, 29);
            btnViewMonthlyIncome.TabIndex = 4;
            btnViewMonthlyIncome.Text = "View Monthly Income ";
            btnViewMonthlyIncome.UseVisualStyleBackColor = true;
            // 
            // btnReviews
            // 
            btnReviews.Location = new Point(353, 204);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(94, 29);
            btnReviews.TabIndex = 5;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(669, 386);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(353, 239);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(94, 29);
            btnProfile.TabIndex = 7;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += button1_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProfile);
            Controls.Add(btnLogout);
            Controls.Add(btnReviews);
            Controls.Add(btnViewMonthlyIncome);
            Controls.Add(btnViewRequests);
            Controls.Add(btnMovieLibrary);
            Controls.Add(lblWelcome);
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnMovieLibrary;
        private Button btnViewRequests;
        private Button btnViewMonthlyIncome;
        private Button btnReviews;
        private Button btnLogout;
        private Button btnProfile;
    }
}