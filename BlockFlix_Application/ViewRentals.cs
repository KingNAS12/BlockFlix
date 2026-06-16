using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BlockFlix_Application
{
    /// <summary>
    /// Form for Employee to view and manage rentals. Displays all rentals with filtering options for active, returned, and overdue rentals. 
    /// </summary>
    public partial class ViewRentals : Form
    {
        private string connectionString;
        private string employeeID;

        private bool showActive;
        private bool showReturned;
        private bool showOverdue;

        public ViewRentals(string employee, string conn)
        {
            InitializeComponent();
            connectionString = conn;
            employeeID = employee;
            showActive = true;
            showReturned = true;
            showOverdue = true;
            InitializeGrid();
            LoadRentals();
        }

        /// <summary>
        /// Sets up the DataGridView with custom columns for returning movies and charging replacement fees, and wires up necessary event handlers.
        /// </summary>
        private void InitializeGrid()
        {
            // "Return" button column
            var returnButton = new DataGridViewButtonColumn
            {
                Name = "ReturnMovie",
                HeaderText = "Return",
                Text = "Return",
                UseColumnTextForButtonValue = false   // must be false so per-cell values work
            };
            dataGridView1.Columns.Add(returnButton);
            // Mirror of the DB replacementFeeCharged bit as a checkbox
            var feeCheckbox = new DataGridViewCheckBoxColumn
            {
                Name = "ChargeReplacementFee",
                HeaderText = "Replacement Fee Charged"
            };
            dataGridView1.Columns.Add(feeCheckbox);
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        }
        /// <summary>
        /// Loads rentals from the database based on the current filter settings and binds them to the DataGridView. If no filters are selected, clears the grid.
        /// </summary>
        private void LoadRentals()
        {
            if (!showActive && !showReturned && !showOverdue)
            {
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = FetchRentals();
        }
        /// <summary>
        /// Fetches rental data from the database, applying filters for active, returned, and overdue rentals as specified by the current state of the form's checkboxes. 
        /// The query also computes a "note" for each rental based on its status and due date.
        /// </summary>
        private DataTable FetchRentals()
        {
            string query = BuildQuery();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(query, conn);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        /// <summary>
        /// Constructs the SQL query for fetching rentals, dynamically adding WHERE conditions based on which filters (active, returned, overdue) are currently selected. 
        /// The query also includes a CASE statement to generate a "note" for each rental that describes its status in human-readable terms.
        /// </summary>
        private string BuildQuery()
        {
            string query = @"
                SELECT
                    r.rentalID,
                    r.accountNumber,
                    c.firstName + ' ' + c.lastName AS customerName,
                    r.movieID,
                    m.movieName,
                    r.employeeID,
                    e.firstName + ' ' + e.lastName AS employeeName,
                    r.checkoutDate,
                    DATEADD(WEEK, 1, r.checkoutDate) AS dueDate,
                    r.returnDate,
                    r.replacementFeeCharged,
                    CASE
                        WHEN r.returnDate IS NULL
                                AND GETDATE() <= DATEADD(WEEK, 1, r.checkoutDate)
                                AND r.replacementFeeCharged = 0
                            THEN 'Active'
                        WHEN r.returnDate IS NULL
                                AND GETDATE() > DATEADD(WEEK, 1, r.checkoutDate)
                                AND GETDATE() <= DATEADD(WEEK, 2, r.checkoutDate)
                                AND r.replacementFeeCharged = 0
                            THEN 'Overdue'
                        WHEN r.returnDate <= DATEADD(WEEK, 1, r.checkoutDate)
                                AND r.replacementFeeCharged = 0
                            THEN 'Returned on time'
                        WHEN r.returnDate > DATEADD(WEEK, 1, r.checkoutDate)
                                AND r.replacementFeeCharged = 0
                            THEN 'Returned late; not charged'
                        WHEN r.returnDate >= DATEADD(WEEK, 1, r.checkoutDate)
                             AND r.replacementFeeCharged = 1
                            THEN 'Returned late; replacement fee charged'
                        WHEN r.returnDate IS NULL
                             AND GETDATE() > DATEADD(WEEK, 2, r.checkoutDate)
                             AND r.replacementFeeCharged = 0
                            THEN 'Overdue; charge required'
                        WHEN r.returnDate IS NULL
                             AND GETDATE() > DATEADD(WEEK, 2, r.checkoutDate)
                             AND r.replacementFeeCharged = 1
                            THEN 'Overdue; fee charged'
                    END AS note
                FROM RentalOrder AS r, Customer AS c, Movie AS m, Employee AS e 
                WHERE r.accountNumber = c.accountNumber 
                    AND r.movieID = m.movieID 
                    AND r.employeeID = e.employeeID
            ";
            List<string> filters = new List<string>();
            if (showActive)
            {
                filters.Add(@"
                    (
                        r.returnDate IS NULL
                        AND GETDATE() <= DATEADD(WEEK,1,r.checkoutDate)
                    )
                ");
            }
            if (showOverdue)
            {
                filters.Add(@"
                    (
                        r.returnDate IS NULL
                        AND GETDATE() > DATEADD(WEEK,1,r.checkoutDate)
                    )
                ");
            }
            if (showReturned)
            {
                filters.Add(@"
                    (
                        r.returnDate IS NOT NULL
                    )
                ");
            }
            if (filters.Count > 0)
            {
                query = query + " AND (";
                for (int i = 0; i < filters.Count; i++)
                {
                    query = query + filters[i];
                    if (i != filters.Count - 1)
                    {
                        query = query + " OR ";
                    }
                }
                query = query + ")";
            }

            query = query + "ORDER BY r.rentalID DESC;";
            return query;
        }

        /// <summary>
        /// Event handler for when data binding to the DataGridView is complete. 
        /// Hides the raw "replacementFeeCharged" column from the database and ensures that the custom "ReturnMovie" and "ChargeReplacementFee" columns are always displayed at the end of the grid. 
        /// Also calls RefreshCustomColumns to update the values of the custom columns based on the newly bound data.
        /// </summary>
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Hide the raw DB column now that we have our checkbox mirror
            if (dataGridView1.Columns["replacementFeeCharged"] != null)
            {
                dataGridView1.Columns["replacementFeeCharged"].Visible = false;
            }
            // Keep the two custom columns pinned at the end, after every rebind
            // (DataSource reset can shift DisplayIndex back to where the columns
            // were originally added relative to the newly bound columns).
            int lastIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["ReturnMovie"].DisplayIndex = lastIndex - 1;
            dataGridView1.Columns["ChargeReplacementFee"].DisplayIndex = lastIndex;
            RefreshCustomColumns();
        }

        /// <summary>
        /// Updates the values of the custom "ReturnMovie" and "ChargeReplacementFee" columns for each row in the DataGridView based on the underlying data.
        /// </summary>
        private void RefreshCustomColumns()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                // --- Checkbox: mirror the DB bit ---
                bool feeCharged = Convert.ToBoolean(row.Cells["replacementFeeCharged"].Value);
                row.Cells["ChargeReplacementFee"].Value = feeCharged;
                // --- Return button: blank it out when the rental is already returned ---
                bool alreadyReturned = row.Cells["returnDate"].Value != null && row.Cells["returnDate"].Value != DBNull.Value;
                row.Cells["ReturnMovie"].Value = alreadyReturned ? string.Empty : "Return";
            }
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            showActive = checkBoxActive.Checked;
            LoadRentals();
        }

        private void checkBoxReturned_CheckedChanged(object sender, EventArgs e)
        {
            showReturned = checkBoxReturned.Checked;
            LoadRentals();
        }

        private void checkBoxOverdue_CheckedChanged(object sender, EventArgs e)
        {
            showOverdue = checkBoxOverdue.Checked;
            LoadRentals();
        }

        /// <summary>
        /// Event handler for when a cell's content is clicked in the DataGridView. 
        /// Determines if the click was on the "ReturnMovie" button or the "ChargeReplacementFee" checkbox and calls the appropriate handler method for each action. 
        /// After handling the click, it reloads the rentals to reflect any changes made.
        /// </summary>
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName == "ReturnMovie")
            {
                HandleReturn(e.RowIndex);
            }
            else if (columnName == "ChargeReplacementFee")
            {
                HandleReplacementFeeToggle(e.RowIndex);
            }
            LoadRentals();
        }

        /// <summary>
        /// Handles the logic for when the "Return" button is clicked for a rental.
        /// </summary>
        private void HandleReturn(int rowIndex)
        {
            string cellText = dataGridView1.Rows[rowIndex].Cells["ReturnMovie"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(cellText)) return;  // already returned — ignore click
            string rentalID = dataGridView1.Rows[rowIndex].Cells["rentalID"].Value.ToString();
            string movieID = dataGridView1.Rows[rowIndex].Cells["movieID"].Value.ToString();
            ReturnRental(rentalID, movieID);
            UpdateQueue(movieID);
            GetRating(rentalID, movieID); 
        }

        /// <summary>
        /// Marks the specified rental as returned by setting the return date to the current date and increments the available copies for the associated movie.
        /// </summary>
        private void ReturnRental(string rentalID, string movieID)
        {
            string query = @"
                UPDATE RentalOrder
                    SET returnDate = GETDATE()
                    WHERE rentalID   = @rentalID
                        AND returnDate IS NULL;
                UPDATE Movie
                    SET copiesAvailable = copiesAvailable + 1
                    WHERE movieID = @movieID; 
            ";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                cmd.Parameters.AddWithValue("@movieID", movieID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// After a movie is returned, checks if there is a queue for that movie and automatically creates a rental for the first customer in the queue,
        /// removes them from the queue, and shifts everyone else forward.
        /// </summary>
        private void UpdateQueue(string movieID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Get the first customer in the queue
                string getFirstQuery = @"
                    SELECT accountNumber
                        FROM movieQueue
                        WHERE movieID = @movieID
                            AND queueIndex = 1
                    ";
                SqlCommand getFirstCmd = new SqlCommand(getFirstQuery, conn);
                getFirstCmd.Parameters.AddWithValue("@movieID", movieID);
                object result = getFirstCmd.ExecuteScalar();
                if (result == null)
                {
                    return; // Queue is empty
                }
                string accountNumber = result.ToString();
                // Remove them from the queue
                AutoCreateOrder(accountNumber, movieID, conn);
                string deleteQuery = @"
                    DELETE FROM movieQueue
                        WHERE movieID = @movieID
                            AND queueIndex = 1
                ";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@movieID", movieID);
                deleteCmd.ExecuteNonQuery();
                // Shift everyone else forward
                string updateQuery = @"
                    UPDATE movieQueue
                        SET queueIndex = queueIndex - 1
                        WHERE movieID = @movieID
                            AND queueIndex > 1";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@movieID", movieID);
                updateCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Automatically creates a rental order for the specified account and movie, assigning it to a default employee and setting the checkout date to the current date.
        /// </summary>
        private void AutoCreateOrder(string accountNumber, string movieID, SqlConnection conn)
        {
            // Get the number of existing rentals
            SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM RentalOrder", conn);
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

        /// <summary>
        /// Handles the logic for when the "Charge Replacement Fee" checkbox is toggled for a rental.
        /// </summary>
        private void HandleReplacementFeeToggle(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string rentalID = row.Cells["rentalID"].Value.ToString();
            DateTime checkoutDate = Convert.ToDateTime(row.Cells["checkoutDate"].Value);
            bool currentValue = Convert.ToBoolean(row.Cells["ChargeReplacementFee"].Value);
            // Toggling OFF is always allowed (refunds the customer).
            // Toggling ON requires current date >= checkoutDate + 2 weeks.
            if (!currentValue && DateTime.Now < checkoutDate.AddDays(14))
            {
                MessageBox.Show($"The replacement fee can only be charged on or after {checkoutDate.AddDays(14):MMM dd, yyyy}.");
                // Revert — the grid toggled the checkbox optimistically on click
                row.Cells["ChargeReplacementFee"].Value = false;
                return;
            }
            bool newValue = !currentValue;
            UpdateReplacementFee(rentalID, newValue);
            // Reflect the confirmed value without a full reload
            row.Cells["ChargeReplacementFee"].Value = newValue;
        }

        /// <summary>
        /// Updates the replacement fee status for a given rental in the database. Sets the "replacementFeeCharged" bit to 1 if charge is true, or 0 if charge is false.
        /// </summary>
        private void UpdateReplacementFee(string rentalID, bool charge)
        {
            const string sql = @"
                UPDATE RentalOrder
                    SET replacementFeeCharged = @charge
                    WHERE  rentalID = @rentalID;";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@charge", charge ? 1 : 0);
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateRental createRentalForm = new CreateRental(employeeID, connectionString);
            createRentalForm.FormClosed += (s, args) =>
            {
                LoadRentals();
            };
            createRentalForm.Show();
        }

        private void GetRating(string rentalID, string movieID)
        {
            GetRatingForm ratingForm = new GetRatingForm(connectionString, rentalID, movieID);
            ratingForm.ShowDialog();
        }
    }
}