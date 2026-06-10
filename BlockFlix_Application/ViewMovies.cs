using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BlockFlix_Application
{
    public partial class ViewMovies : Form
    {
        private string connectionString;
        private string accountNumber;

        public ViewMovies(string connString, string accountNo)
        {
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            connectionString = connString;
            accountNumber = accountNo;
            LoadMovies();
        }

        private void ViewMovies_Load(object sender, EventArgs e)
        {

        }

        private void LoadMovies()
        {
            string query = @"
                SELECT movieID, 
                        movieName, 
                        copiesAvailable
                    FROM Movie
            ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Button movieButton = new Button();

                    movieButton.Text = reader["movieName"].ToString() + " (" + reader["copiesAvailable"].ToString() + " Available)";
                    movieButton.Tag = reader["movieID"];
                    movieButton.Width = 200;
                    movieButton.Height = 50;

                    movieButton.Click += MovieButton_Click;

                    flowLayoutPanel1.Controls.Add(movieButton);
                }
            }
        }

        private void MovieButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string movieID = btn.Tag.ToString();
            RequestRental(movieID); 
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void RequestRental(string movieID)
        {
            string query = @"
                SELECT copiesAvailable 
                    FROM Movie 
                    WHERE movieID = @movieID
            ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@movieID", movieID);
                int copiesAvailable = (int)cmd.ExecuteScalar();
                if (copiesAvailable > 0)
                {
                    CreateRental(conn, movieID); 
                }
                else
                {
                    Enqueue(conn, movieID); 
                }
            }
            // Refresh screen
            flowLayoutPanel1.Controls.Clear();
            LoadMovies();
        }

        private void CreateRental(SqlConnection conn, string movieID)
        { 
            // Get the number of existing rentals
            SqlCommand countCmd = new SqlCommand(
                "SELECT COUNT(*) FROM RentalOrder",
                conn);
            int rentalCount = Convert.ToInt32(countCmd.ExecuteScalar());
            // Generate next Rental ID
            string rentalID = "R" + (rentalCount + 1).ToString("D6");
            // Insert rental
            string query = @"
                INSERT INTO RentalOrder (
                        rentalID, 
                        accountNumber, 
                        movieID, 
                        employeeID, 
                        movieRating, 
                        replacementFeeCharged, 
                        checkoutDate, 
                        returnDate
                    ) VALUES (
                        @rentalID,
                        @accountNumber,
                        @movieID,
                        'E000000',
                        NULL,
                        0,
                        GETDATE(),
                        NULL
                    ); 
                UPDATE Movie
                    SET copiesAvailable = copiesAvailable - 1
                    WHERE movieID = @movieID; 
            ";
            SqlCommand insertCmd = new SqlCommand(query, conn); 
            insertCmd.Parameters.AddWithValue("@rentalID", rentalID);
            insertCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            insertCmd.Parameters.AddWithValue("@movieID", movieID);
            insertCmd.ExecuteNonQuery();
        }

        private void Enqueue(SqlConnection conn, string movieID)
        {
            // Get next queue position
            SqlCommand countCmd = new SqlCommand(
                @"SELECT COUNT(*)
                    FROM MovieQueue
                    WHERE movieID = @movieID",
                conn);
            countCmd.Parameters.AddWithValue("@movieID", movieID);
            int nextQueueIndex = Convert.ToInt32(countCmd.ExecuteScalar()) + 1;
            if (nextQueueIndex > 3)
            {
                MessageBox.Show("Queue is full for this movie. Please try again later");
                return; 
            }
            SqlCommand existCmd = new SqlCommand(
                @"SELECT *
                    FROM MovieQueue
                    WHERE movieID = @movieID
                        AND accountNumber = @accountNumber",
                conn);
            existCmd.Parameters.AddWithValue("@movieID", movieID);
            existCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            object result = existCmd.ExecuteScalar();
            if (result != null)
            {
                MessageBox.Show("You are already in the queue for this movie.");
                return;
            }
            // Add customer to queue
            string query = @"
                INSERT INTO MovieQueue (movieID, queueIndex, accountNumber) VALUES
                    (@movieID, @queueIndex, @accountNumber)
                ";
            SqlCommand insertCmd = new SqlCommand(query, conn);
            insertCmd.Parameters.AddWithValue("@movieID", movieID);
            insertCmd.Parameters.AddWithValue("@queueIndex", nextQueueIndex);
            insertCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            insertCmd.ExecuteNonQuery();
        }
    }
}
