using Microsoft.Data.SqlClient;
using System.Data;


namespace BlockFlix_Application
{
    public partial class CustomerScreen : Form
    {
        private string connectionString = @"Server=localhost;Database=CMPT291_Team7_MovieRental;Trusted_Connection=True;TrustServerCertificate=True;";
        public string accountNumber = "C000019";
        public CustomerScreen()
        {
            InitializeComponent();
            loadRentalHistoryActive();
            loadRentalHistoryReturned();
            loadRentalHistoryOverdue();
        }
        private void CustomerScreen_Load(object sender, EventArgs e)
        {
            // Leave this empty. It is included to avoid missing CustomerScreen_Load errors.
        }
        private void loadRentalHistoryActive()
        {
            string query = @"
            SELECT rentalID, ro.movieID, movieName, checkoutDate, returnDate, 
                CASE WHEN returnDate <= DATEADD(WEEK, 1, checkoutDate) THEN 'Returned on time'
                     WHEN returnDate > DATEADD(WEEK, 1, checkoutDate) AND returnDate<DATEADD(WEEK, 2, checkoutDate) THEN 'Returned late but not charged'
                     WHEN returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 0 THEN 'Overdue and needs to be charged'
                     WHEN returnDate IS NULL AND replacementFeeCharged = 1 THEN 'Overdue and replacement fee charged'
                     WHEN returnDate >= DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 1 THEN 'Replacement fee already charged but returned later'
                END AS rentalStatus
            FROM RentalOrder AS ro, Customer AS c, Movie AS m
            WHERE ro.accountNumber = c.accountNumber
                AND ro.movieID = m.movieID
                AND c.accountNumber = @accountID;";
            LoadQuery(query);
        }
        private void loadRentalHistoryReturned()
        {
            string query = @"
            SELECT rentalID, ro.movieID, movieName, checkoutDate, returnDate, 
                CASE WHEN returnDate <= DATEADD(WEEK, 1, checkoutDate) THEN 'Returned on time'
                     WHEN returnDate > DATEADD(WEEK, 1, checkoutDate) AND returnDate<DATEADD(WEEK, 2, checkoutDate) THEN 'Returned late but not charged'
                     WHEN returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 0 THEN 'Overdue and needs to be charged'
                     WHEN returnDate IS NULL AND replacementFeeCharged = 1 THEN 'Overdue and replacement fee charged'
                     WHEN returnDate >= DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 1 THEN 'Replacement fee already charged but returned later'
                END AS rentalStatus
            FROM RentalOrder AS ro, Customer AS c, Movie AS m
            WHERE ro.accountNumber = c.accountNumber
                AND ro.movieID = m.movieID
                AND c.accountNumber = @accountID;";
            LoadQuery(query);
        }
        private void loadRentalHistoryOverdue()
        {
            string query = @"
            SELECT rentalID, ro.movieID, movieName, checkoutDate, returnDate, 
                CASE WHEN returnDate <= DATEADD(WEEK, 1, checkoutDate) THEN 'Returned on time'
                     WHEN returnDate > DATEADD(WEEK, 1, checkoutDate) AND returnDate<DATEADD(WEEK, 2, checkoutDate) THEN 'Returned late but not charged'
                     WHEN returnDate IS NULL AND GETDATE() > DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 0 THEN 'Overdue and needs to be charged'
                     WHEN returnDate IS NULL AND replacementFeeCharged = 1 THEN 'Overdue and replacement fee charged'
                     WHEN returnDate >= DATEADD(WEEK, 2, checkoutDate) AND replacementFeeCharged = 1 THEN 'Replacement fee already charged but returned later'
                END AS rentalStatus
            FROM RentalOrder AS ro, Customer AS c, Movie AS m
            WHERE ro.accountNumber = c.accountNumber
                AND ro.movieID = m.movieID
                AND c.accountNumber = @accountID;";
            LoadQuery(query);
        }

        private void btnMyQueue_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT mq.queueIndex, mq.movieID, m.movieName
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
                dgvMyBlockFlix.DataSource = table;
            }
        }

        private void cbxActiveRental_CheckedChanged(object sender, EventArgs e)
        {
            loadRentalHistoryActive();
        }

        private void cbxReturned_CheckedChanged(object sender, EventArgs e)
        {
            loadRentalHistoryReturned();
        }

        private void cbxOverdue_CheckedChanged(object sender, EventArgs e)
        {
            loadRentalHistoryOverdue();
        }
    }
}
