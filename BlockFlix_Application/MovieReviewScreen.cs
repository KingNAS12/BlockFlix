using System.Data;
using Microsoft.Data.SqlClient;

namespace BlockFlix_Application
{
    /// <summary>
    /// This form allows users to view various movie review reports based on data from the database. 
    /// Users can select different report types from a dropdown menu, and the corresponding data will be displayed in a DataGridView. 
    /// The reports include average movie ratings, actor ratings, customer ratings, and preferences by
    /// </summary>
    public partial class MovieReviewScreen : Form
    {

        private readonly string connectionString =
            @"Server=localhost;Database=CMPT291_Team7_MovieRental;Trusted_Connection=True;TrustServerCertificate=True;";

        public MovieReviewScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MovieReviewScreen form. It initializes the form's controls, including setting the title label, 
        /// populating the report type combo box with available report options, and configuring the DataGridView for displaying report results. 
        /// The combo box is set to a drop-down list style to prevent user input, and the DataGridView is configured to auto-size columns, be read-only, and allow full-row selection.
        /// </summary>
        private void MovieReviewScreen_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Movie Review Report";
            lblTitle.Font = new Font(lblTitle.Font.FontFamily, 16, FontStyle.Bold);

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Movie Ratings");
            cmbReportType.Items.Add("Actor Ratings");
            cmbReportType.Items.Add("Customer Ratings");
            cmbReportType.Items.Add("Movie Preferences by Gender");
            cmbReportType.Items.Add("Genre Preferences by Gender");
            cmbReportType.Items.Add("Actor Preferences by Gender");
            cmbReportType.Items.Add("Actor Preferences by Age Group");

            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.SelectedIndex = 0;

            btnLoadReport.Text = "Load Report";

            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.ReadOnly = true;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Handles the click event of the Load Report button. It retrieves the selected report type from the combo box, 
        /// constructs the appropriate SQL query based on the selection, and executes the query to fetch data from the database. 
        /// The results are then displayed in a DataGridView. If any errors occur during database access, an error message is shown to the user.
        /// </summary>
        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Missing Selection");
                return;
            }

            string selectedReport = cmbReportType.SelectedItem.ToString();
            string query = GetReportQuery(selectedReport);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvReports.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load report.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Gets the SQL query for the specified report type.
        /// </summary>
        private string GetReportQuery(string reportName)
        {
            switch (reportName)
            {
                case "Movie Ratings":
                    return @"
                        SELECT 
                            m.movieID AS [Movie ID],
                            m.movieName AS [Movie Name],
                            AVG(CAST(ro.movieRating AS FLOAT)) AS [Average Rating],
                            COUNT(ro.movieID) AS [Number of Ratings]
                        FROM RentalOrder AS ro
                        INNER JOIN Movie AS m
                            ON ro.movieID = m.movieID
                        WHERE ro.movieRating IS NOT NULL
                        GROUP BY m.movieID, m.movieName
                        ORDER BY [Average Rating] DESC, [Number of Ratings] DESC;";

                case "Actor Ratings":
                    return @"
                        SELECT 
                            a.actorID AS [Actor ID],
                            a.actorName AS [Actor Name],
                            AVG(CAST(ar.actorRating AS FLOAT)) AS [Average Rating],
                            COUNT(ar.actorID) AS [Number of Ratings]
                        FROM ActorRating AS ar
                        INNER JOIN Actor AS a
                            ON ar.actorID = a.actorID
                        WHERE ar.actorRating IS NOT NULL
                        GROUP BY a.actorID, a.actorName
                        ORDER BY [Average Rating] DESC, [Number of Ratings] DESC;";

                case "Customer Ratings":
                    return @"
                        SELECT 
                            accountNumber AS [Account Number],
                            firstName + ' ' + lastName AS [Customer Name],
                            customerRating AS [Customer Rating]
                        FROM Customer
                        WHERE customerRating IS NOT NULL
                        ORDER BY customerRating DESC, accountNumber ASC;";

                case "Movie Preferences by Gender":
                    return @"
                        SELECT 
                            CASE c.gender
                                WHEN 'F' THEN 'Female'
                                WHEN 'M' THEN 'Male'
                                WHEN 'O' THEN 'Other'
                                WHEN 'N' THEN 'Prefer not to say'
                                ELSE 'Unknown'
                            END AS [Gender],
                            m.movieID AS [Movie ID],
                            m.movieName AS [Movie Name],
                            COUNT(ro.rentalID) AS [Rentals]
                        FROM Customer AS c
                        INNER JOIN RentalOrder AS ro
                            ON c.accountNumber = ro.accountNumber
                        INNER JOIN Movie AS m
                            ON ro.movieID = m.movieID
                        GROUP BY c.gender, m.movieID, m.movieName
                        ORDER BY [Gender] ASC, [Rentals] DESC;";

                case "Genre Preferences by Gender":
                    return @"
                        SELECT 
                            CASE c.gender
                                WHEN 'F' THEN 'Female'
                                WHEN 'M' THEN 'Male'
                                WHEN 'O' THEN 'Other'
                                WHEN 'N' THEN 'Prefer not to say'
                                ELSE 'Unknown'
                            END AS [Gender],
                            CASE m.genre
                                WHEN 'A' THEN 'Action'
                                WHEN 'C' THEN 'Comedy'
                                WHEN 'D' THEN 'Drama'
                                WHEN 'F' THEN 'Foreign'
                                ELSE 'Unknown'
                            END AS [Genre],
                            COUNT(ro.rentalID) AS [Rentals]
                        FROM Customer AS c
                        INNER JOIN RentalOrder AS ro
                            ON c.accountNumber = ro.accountNumber
                        INNER JOIN Movie AS m
                            ON ro.movieID = m.movieID
                        GROUP BY c.gender, m.genre
                        ORDER BY [Gender] ASC, [Genre] ASC;";

                case "Actor Preferences by Gender":
                    return @"
                        SELECT 
                            CASE c.gender
                                WHEN 'F' THEN 'Female'
                                WHEN 'M' THEN 'Male'
                                WHEN 'O' THEN 'Other'
                                WHEN 'N' THEN 'Prefer not to say'
                                ELSE 'Unknown'
                            END AS [Gender],
                            a.actorID AS [Actor ID],
                            a.actorName AS [Actor Name],
                            COUNT(ro.rentalID) AS [Rentals]
                        FROM Actor AS a
                        INNER JOIN [Cast] AS ca
                            ON a.actorID = ca.actorID
                        INNER JOIN RentalOrder AS ro
                            ON ca.movieID = ro.movieID
                        INNER JOIN Customer AS c
                            ON ro.accountNumber = c.accountNumber
                        GROUP BY c.gender, a.actorID, a.actorName
                        ORDER BY [Gender] ASC, [Rentals] DESC, a.actorID ASC;";

                case "Actor Preferences by Age Group":
                    return @"
                        SELECT 
                            CASE
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) < 18 THEN '18-'
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 18 AND 29 THEN '18-29'
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 30 AND 49 THEN '30-49'
                                ELSE '50+'
                            END AS [Age Group],
                            a.actorID AS [Actor ID],
                            a.actorName AS [Actor Name],
                            COUNT(ro.rentalID) AS [Rentals]
                        FROM Actor AS a
                        INNER JOIN [Cast] AS ca
                            ON a.actorID = ca.actorID
                        INNER JOIN RentalOrder AS ro
                            ON ca.movieID = ro.movieID
                        INNER JOIN Customer AS c
                            ON ro.accountNumber = c.accountNumber
                        GROUP BY 
                            a.actorID,
                            a.actorName,
                            CASE
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) < 18 THEN '18-'
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 18 AND 29 THEN '18-29'
                                WHEN DATEDIFF(YEAR, c.dob, GETDATE()) BETWEEN 30 AND 49 THEN '30-49'
                                ELSE '50+'
                            END
                        ORDER BY [Age Group] ASC, [Rentals] DESC, a.actorID ASC;";
            }

            return "SELECT 'No report selected' AS [Message];";
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}