using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockFlix_Application
{
    public partial class HomeForm : Form
    {
        private readonly string userId = "";
        private readonly string role = "";
        private readonly Form? loginForm;
        private string connectionString; 
        private bool loggingOut = false;

        // Needed so Visual Studio Designer can open HomeForm.
        public HomeForm()
        {
            InitializeComponent();
        }

        // Used after successful login.
        public HomeForm(string userId, string role, Form loginForm, string conn)
        {
            InitializeComponent();

            this.userId = userId;
            this.role = role;
            this.loginForm = loginForm;
            this.connectionString = conn; 

            SetupHomePage();

            btnViewRentalHistory.Click += btnViewRentalHistory_Click;
            btnViewMovies.Click += btnViewMovies_Click;
            btnViewRequests.Click += btnViewRequests_Click;
            btnViewMonthlyIncome.Click += btnViewMonthlyIncome_Click;
            btnReviews.Click += btnReviews_Click;
            btnLogout.Click += btnLogout_Click;

            this.FormClosed += HomeForm_FormClosed;
        }

        private void HomeForm_Load(object? sender, EventArgs e)
        {
            // Nothing needed here for now.
        }

        private void SetupHomePage()
        {
            lblWelcome.Text = $"Welcome {userId}";

            bool isCustomer = role == "Customer";
            bool isEmployee = role == "Employee";

            // Customer-only buttons
            btnViewRentalHistory.Visible = isCustomer;
            btnViewMovies.Visible = isCustomer;

            // Employee-only buttons
            btnViewRequests.Visible = isEmployee;
            btnViewMonthlyIncome.Visible = isEmployee;

            // Buttons for both customer and employee
            btnReviews.Visible = true;
            btnLogout.Visible = true;

            // Colors from your diagram
            btnViewRentalHistory.BackColor = Color.LightGreen;
            btnViewMovies.BackColor = Color.LightGreen;

            btnViewRequests.BackColor = Color.LightSkyBlue;
            btnViewMonthlyIncome.BackColor = Color.LightSkyBlue;

            btnReviews.BackColor = Color.LightGray;
            btnLogout.BackColor = Color.LightGray;

            btnViewRentalHistory.UseVisualStyleBackColor = false;
            btnViewMovies.UseVisualStyleBackColor = false;
            btnViewRequests.UseVisualStyleBackColor = false;
            btnViewMonthlyIncome.UseVisualStyleBackColor = false;
            btnReviews.UseVisualStyleBackColor = false;
            btnLogout.UseVisualStyleBackColor = false;
        }

        private void btnViewRentalHistory_Click(object? sender, EventArgs e)
        {
            CustomerScreen screen = new CustomerScreen(userId, connectionString);
            screen.Show();
        }

        private void btnViewMovies_Click(object? sender, EventArgs e)
        {
            OpenTemporaryScreen("View Movies");
        }

        private void btnViewRequests_Click(object? sender, EventArgs e)
        {
            ViewRentals screen = new ViewRentals(userId, connectionString);
            screen.Show();
        }

        private void btnViewMonthlyIncome_Click(object? sender, EventArgs e)
        {
            OpenTemporaryScreen("View Monthly Income");
        }

        private void btnReviews_Click(object? sender, EventArgs e)
        {
            MovieReviewScreen screen = new MovieReviewScreen();
            screen.Show();
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            loggingOut = true;

            if (loginForm != null)
            {
                loginForm.Show();
            }

            this.Close();
        }

        private void HomeForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!loggingOut)
            {
                Application.Exit();
            }
        }

        private void lblWelcome_Click(object? sender, EventArgs e)
        {
            // Nothing needed here.
        }

        private void OpenTemporaryScreen(string title)
        {
            Form form = new Form();
            form.Text = title;
            form.Size = new Size(600, 350);
            form.StartPosition = FormStartPosition.CenterScreen;

            Label label = new Label();
            label.Text = title + " screen will be connected next.";
            label.AutoSize = true;
            label.Location = new Point(30, 30);

            form.Controls.Add(label);
            form.Show();
        }
    }
}