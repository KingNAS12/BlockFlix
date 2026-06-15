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
    /// <summary>
    /// This form is used to get a rating from the customer after they have returned a movie. It is opened by the ReturnMovieForm after the customer has returned a movie. 
    /// The form displays the name of the movie that was returned and allows the customer to select a rating from a combo box. 
    /// The rating is then saved to the database when the customer clicks the save button.
    /// </summary>
    public partial class GetRatingForm : Form
    {
        private string connectionString;
        private string rentalID; 

        public GetRatingForm(string connect, string rental, string movieID)
        {
            InitializeComponent();
            connectionString = connect;
            rentalID = rental; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Get the first customer in the queue
                string query = @"
                    SELECT movieName
                        FROM Movie
                        WHERE movieID = @movieID
                ";
                SqlCommand getFirstCmd = new SqlCommand(query, conn);
                getFirstCmd.Parameters.AddWithValue("@movieID", movieID);
                object result = getFirstCmd.ExecuteScalar();
                string movieName = result.ToString();
                label.Text = "Please enter a rating for " + movieName;
            }
        }
        /// <summary>
        /// This method is called when the customer clicks the save button. 
        /// It checks if a rating has been selected from the combo box and if so, it updates the rental order in the database with the selected rating.
        /// If no rating has been selected, it shows a message box asking the customer to select a rating before saving.
        /// </summary>

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxRating.SelectedItem == null)
            {
                MessageBox.Show("Please select a rating before saving.");
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Get the first customer in the queue
                    string updateQuery = @"
                        UPDATE RentalOrder
                            SET movieRating = @rating
                            WHERE rentalID = @rentalID
                    ";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@rating", comboBoxRating.SelectedItem);
                    updateCmd.Parameters.AddWithValue("@rentalID", rentalID);
                    updateCmd.ExecuteNonQuery();
                }
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
