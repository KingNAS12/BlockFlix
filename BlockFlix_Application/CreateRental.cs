using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlockFlix_Application
{
    public partial class CreateRental : Form
    {

        private string connectionString;
        private string employeeID;

        public class MovieItem()
        {
            public string MovieName { get; set; }
            public string MovieID { get; set; }
            public string DisplayText
            {
                get
                {
                    if (string.IsNullOrEmpty(MovieID))
                        return "Select Movie";

                    return $"({MovieID}) {MovieName}";
                }
            }
        }
        public class CustomerItem()
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AccountNumber { get; set; }
            public string DisplayText
            {
                get
                {
                    if (string.IsNullOrEmpty(AccountNumber))
                        return "Select Customer";

                    return $"({AccountNumber}) {FirstName} {LastName}";
                }
            }
        }

        public CreateRental(string employee, string con)
        {
            InitializeComponent();
            employeeID = employee;
            connectionString = con;
            LoadMovies();
            LoadCustomers(); 
        }

        private void CreateRental_Load(object sender, EventArgs e)
        {

        }

        private void LoadMovies()
        {
            List<MovieItem> movies = new List<MovieItem>();
            // Placeholder text
            movies.Add(new MovieItem
            {
                MovieID = "",
                MovieName = ""
            });
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT movieID, movieName FROM Movie ORDER BY movieID",
                    conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new MovieItem
                    {
                        MovieID = reader["movieID"].ToString(),
                        MovieName = reader["movieName"].ToString()
                    });
                }
            }
            comboBoxMovie.DataSource = movies;
            comboBoxMovie.DisplayMember = "MovieName";
            comboBoxMovie.ValueMember = "MovieID";
            comboBoxMovie.SelectedIndex = 0; // Set to placeholder  
        }

        private void LoadCustomers()
        {
            List<CustomerItem> movies = new List<CustomerItem>();
            // Placeholder text
            movies.Add(new CustomerItem
            {
                AccountNumber = "",
                FirstName = "",
                LastName = ""
            });
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT accountNumber, firstName, lastName FROM Customer ORDER BY accountNumber",
                    conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new CustomerItem
                    {
                        AccountNumber = reader["accountNumber"].ToString(),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString()
                    });
                }
            }
            comboBoxCustomer.DataSource = movies;
            comboBoxCustomer.DisplayMember = "DisplayText";
            comboBoxCustomer.ValueMember = "AccountNumber";
            comboBoxCustomer.SelectedIndex = 0; // Set to placeholder  
        }

        private void buttonCreateRental_Click(object sender, EventArgs e)
        {
            if (comboBoxMovie.SelectedIndex == 0 || comboBoxCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Please select both a movie and a customer.");
                return;
            }
            else
            {
                string movieID = comboBoxMovie.SelectedValue.ToString();
                string accountNumber = comboBoxCustomer.SelectedValue.ToString();
                string rentalID = CreateRentalOrder(movieID, accountNumber);
                labelRentalID.Text = "Rental Created: " + rentalID;
            }
        }

        private void labelRentalID_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string CreateRentalOrder(string movieID, string accountNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand countCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM RentalOrder",
                    conn);
                int count = Convert.ToInt32(countCmd.ExecuteScalar());
                string rentalID = "R" + (count + 1).ToString("D6");
                SqlCommand insertCmd = new SqlCommand(
                    @"INSERT INTO RentalOrder (
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
                        @employeeID,
                        NULL,
                        1,
                        GETDATE(),
                        NULL
                    );", conn);
                insertCmd.Parameters.AddWithValue("@rentalID", rentalID);
                insertCmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                insertCmd.Parameters.AddWithValue("@movieID", movieID);
                insertCmd.Parameters.AddWithValue("@employeeID", employeeID);
                insertCmd.ExecuteNonQuery();
                return rentalID; 
            }
        }
    }
}
