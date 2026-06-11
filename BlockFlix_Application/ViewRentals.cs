using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BlockFlix_Application
{
    public partial class ViewRentals : Form
    {
        private readonly string connectionString;
        private readonly string employeeID;

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

        private void LoadRentals()
        {
            if (!showActive && !showReturned && !showOverdue)
            {
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = FetchRentals();
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
                                AND r.returnDate < DATEADD(WEEK, 2, r.checkoutDate)
                                AND r.replacementFeeCharged = 0
                            THEN 'Returned late; not charged'
                        WHEN r.returnDate IS NULL
                             AND GETDATE() > DATEADD(WEEK, 2, r.checkoutDate)
                             AND r.replacementFeeCharged = 0
                            THEN 'Overdue; charge required'
                        WHEN r.returnDate IS NULL
                             AND GETDATE() > DATEADD(WEEK, 2, r.checkoutDate)
                             AND r.replacementFeeCharged = 1
                            THEN 'Overdue; fee charged'
                        WHEN r.returnDate >= DATEADD(WEEK, 2, r.checkoutDate)
                             AND r.replacementFeeCharged = 1
                            THEN 'Returned late; replacement fee charged'
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

        private void HandleReturn(int rowIndex)
        {
            string cellText = dataGridView1.Rows[rowIndex].Cells["ReturnMovie"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(cellText)) return;  // already returned — ignore click
            string rentalID = dataGridView1.Rows[rowIndex].Cells["rentalID"].Value.ToString();
            ReturnRental(rentalID);
        }

        private void ReturnRental(string rentalID)
        {
            string query = @"
                UPDATE RentalOrder
                    SET returnDate = GETDATE()
                    WHERE rentalID   = @rentalID
                        AND returnDate IS NULL;
            ";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void HandleReplacementFeeToggle(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string rentalID = row.Cells["rentalID"].Value.ToString();
            DateTime checkoutDate = Convert.ToDateTime(row.Cells["checkoutDate"].Value);
            bool currentValue = Convert.ToBoolean(row.Cells["ChargeReplacementFee"].Value);

            // Toggling OFF is always allowed.
            // Toggling ON requires current date >= checkoutDate + 2 weeks.
            if (!currentValue && DateTime.Now < checkoutDate.AddDays(14))
            {
                MessageBox.Show("The replacement fee can only be charged on or after {checkoutDate.AddDays(14):MMM dd, yyyy}.");
                // Revert — the grid toggled the checkbox optimistically on click
                row.Cells["ChargeReplacementFee"].Value = false;
                return;
            }
            bool newValue = !currentValue;
            UpdateReplacementFee(rentalID, newValue);

            // Reflect the confirmed value without a full reload
            row.Cells["ChargeReplacementFee"].Value = newValue;
        }

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
    }
}