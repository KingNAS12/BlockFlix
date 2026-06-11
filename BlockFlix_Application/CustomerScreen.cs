using Microsoft.Data.SqlClient;
using System.Data;


namespace BlockFlix_Application
{
    public partial class CustomerScreen : Form
    {
        private string connectionString;
        public string accountNumber;

        private bool showActive;
        private bool showReturned;
        private bool showOverdue;
        public CustomerScreen(string accountNo, string conn)
        {
            InitializeComponent();
            accountNumber = accountNo;
            connectionString = conn;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            LoadMovies();
            showActive = true;
            showReturned = true;
            showOverdue = true;
            LoadRentals();
            loadQueue();
        }
        private void CustomerScreen_Load(object sender, EventArgs e)
        {
            // Leave this empty. It is included to avoid missing CustomerScreen_Load errors.
        }
        private void LoadRentals()
        {
            if (!showActive && !showReturned && !showOverdue)
            {
                dgvMyBlockFlixRentals.DataSource = null;
                return;
            }
            dgvMyBlockFlixRentals.DataSource = FetchRentals();
        }

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

        private string BuildQuery()
        {
            string query = @"
                SELECT
                    r.rentalID,
                    m.movieName,
                    r.checkoutDate,
                    DATEADD(WEEK, 1, r.checkoutDate) AS dueDate,
                    r.returnDate,
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
                FROM RentalOrder AS r, Customer AS c, Movie AS m
                WHERE r.accountNumber = c.accountNumber 
                    AND r.movieID = m.movieID
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

        private void cbxActiveRental_CheckedChanged(object sender, EventArgs e)
        {
            showActive = cbxActiveRental.Checked;
            LoadRentals();
        }

        private void cbxReturned_CheckedChanged(object sender, EventArgs e)
        {
            showReturned = cbxReturned.Checked;
            LoadRentals();
        }

        private void cbxOverdue_CheckedChanged(object sender, EventArgs e)
        {
            showOverdue = cbxOverdue.Checked;
            LoadRentals();
        }





        private void loadQueue()
        {
            string query = @"
            SELECT m.movieName AS Movie, mq.queueIndex as YourSpot
            FROM MovieQueue AS mq, Customer AS c, Movie AS m
            WHERE c.accountNumber = mq.accountNumber
                AND c.accountNumber = @accountID
                AND m.movieID = mq.movieID;";
            LoadQuery(query);

        }
        private void LoadQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue(
                    "@accountID", accountNumber);

                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvMyBlockFlixQueue.DataSource = table;
            }
        }
        private void LoadMovies()
        {
            string query = @"
                SELECT movieID, 
                        movieName, 
                        copiesAvailable
                    FROM Movie
                    ORDER BY movieName;
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
            RefreshScreen();
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
                    WHERE movieID = @movieID 
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RefreshScreen()
        {
            LoadMovies();
            LoadRentals();
            loadQueue();
        }
    }
}
