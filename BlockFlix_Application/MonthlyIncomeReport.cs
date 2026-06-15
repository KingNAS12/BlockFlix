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
    /// This form displays a monthly income report for the BlockFlix application. 
    /// It retrieves data from the database to show the rental income, replacement income, and total income for each month and year. 
    /// The report is displayed in a DataGridView control on the form.
    /// </summary>
    public partial class MonthlyIncomeReport : Form
    {
        private string connectionString; 

        public MonthlyIncomeReport(string conn)
        {
            InitializeComponent();
            connectionString = conn;
            LoadReport(); 
        }
        /// <summary>
        /// Loads the monthly income report by executing a SQL query that retrieves rental and replacement income data from the database.
        /// </summary>
        private void LoadReport()
        {
            string query = @"
                SELECT YEAR(ro.checkoutDate) AS rentalYear,
                    DATEPART(MONTH, ro.checkoutDate) AS numMonth,
                    DATENAME(MONTH, ro.checkoutDate) AS rentalMonth,
                    SUM(m.rentalFee) AS rentalIncome,
                    SUM(CASE 
                        WHEN ro.replacementFeeCharged = 1 THEN m.replacementFee 
                        ELSE 0 
                        END) AS replacementIncome,
                    SUM(m.rentalFee) + SUM(CASE 
                        WHEN ro.replacementFeeCharged = 1 THEN m.replacementFee 
                        ELSE 0 
                        END) AS totalIncome
                FROM RentalOrder AS ro, Movie AS m
                WHERE ro.movieID = m.movieID
                GROUP BY YEAR(ro.checkoutDate), DATEPART(MONTH, ro.checkoutDate), DATENAME(MONTH, ro.checkoutDate)
                ORDER BY rentalYear ASC, numMonth ASC;
            ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
