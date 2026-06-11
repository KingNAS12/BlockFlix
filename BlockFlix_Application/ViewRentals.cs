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
            var returnButton = new DataGridViewButtonColumn
            {
                Name = "ReturnMovie",
                HeaderText = "Return",
                Text = "Return",
                UseColumnTextForButtonValue = false 
            };
            dataGridView1.Columns.Add(returnButton);
            var feeCheckbox = new DataGridViewCheckBoxColumn
            {
                Name = "ChargeReplacementFee",
                HeaderText = "Replacement Fee Charged"
            };
            dataGridView1.Columns.Add(feeCheckbox);
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void LoadRentals()
        {
            if (!showActive && !showReturned && !showOverdue)
            {
                dataGridView1.DataSource = null;
                return;
            }
            DataTable table = FetchRentals();
            dataGridView1.DataSource = table;
            // Hide the raw DB column now that we have our checkbox mirror
            if (dataGridView1.Columns["replacementFeeCharged"] != null)
            {
                dataGridView1.Columns["replacementFeeCharged"].Visible = false;
            }
            RefreshCustomColumns();
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
            string query = new string(@"
                SELECT r.rentalID, 
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
                                AND GETDATE() <= DATEADD(WEEK,1,r.checkoutDate) 
                                AND r.replacementFeeCharged = 0 
                            THEN 'Active' 
                        WHEN r.returnDate IS NULL 
                                AND GETDATE() > DATEADD(WEEK,1,r.checkoutDate) 
                                AND r.replacementFeeCharged = 0 
                                AND GETDATE() <= DATEADD(WEEK, 2, r.checkoutDate) 
                            THEN 'Overdue' 
                        WHEN r.returnDate <= DATEADD(WEEK, 1, r.checkoutDate) 
                                AND r.replacementFeeCharged = 0 
                            THEN 'Returned on time' 
                        WHEN r.returnDate > DATEADD(WEEK, 1, r.checkoutDate) 
                                AND r.returnDate < DATEADD(WEEK, 2, r.checkoutDate) 
                                AND r.replacementFeeCharged = 0 
                            THEN 'Returned late but not charged replacement fee' 
                        WHEN r.returnDate IS NULL 
                                AND GETDATE() > DATEADD(WEEK,2,r.checkoutDate) 
                                AND r.replacementFeeCharged = 0 
                            THEN 'Overdue and needs replacement fee' 
                        WHEN r.returnDate IS NULL 
                                AND GETDATE() > DATEADD(WEEK,2,r.checkoutDate) 
                                AND r.replacementFeeCharged = 1 
                            THEN 'Overdue and replacement fee charged' 
                        WHEN r.returnDate >= DATEADD(WEEK, 2, r.checkoutDate) 
                                AND r.replacementFeeCharged = 1 
                            THEN 'Replacement fee charged and returned later' 
                    END AS note 
                FROM RentalOrder AS r, Customer AS c, Movie AS m, Employee AS e 
                WHERE r.accountNumber = c.accountNumber 
                    AND r.movieID = m.movieID 
                    AND r.employeeID = e.employeeID
            ");
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

        private void RefreshCustomColumns()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                // --- Checkbox: mirror the DB bit ---
                bool feeCharged = Convert.ToBoolean(row.Cells["replacementFeeCharged"].Value);
                row.Cells["ChargeReplacementFee"].Value = feeCharged;
                // --- Return button: blank it out when the rental is already returned ---
                bool alreadyReturned = (row.Cells["returnDate"].Value != null) && (row.Cells["returnDate"].Value != DBNull.Value);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name != "ReturnMovie") return;

            string cellText = dataGridView1.Rows[e.RowIndex].Cells["ReturnMovie"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(cellText)) return;  // already returned — ignore click

            int rentalID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["rentalID"].Value);
            ReturnRental(rentalID);
            LoadRentals();
        }

        private void ReturnRental(int rentalID)
        {
            const string sql = @"
                UPDATE RentalOrder
                SET    returnDate = GETDATE()
                WHERE  rentalID   = @rentalID
                  AND  returnDate IS NULL;";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}