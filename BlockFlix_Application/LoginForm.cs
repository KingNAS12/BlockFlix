using Microsoft.Data.SqlClient;

namespace BlockFlix_Application
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Connection string to connect to the BLockFlix SQL Server database. 
        /// </summary>
        private string connectionString =
            @"Server=localhost;Database=CMPT291_Team7_MovieRental;Trusted_Connection=True;TrustServerCertificate=True;";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {


        }
        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAccountNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Authenticates a customer or employee throught login button
        /// Validates user input, and verifies hashed passwords against the database
        /// Opens the HomeForm with the appropriate role and user information upon successful login
        /// <summary>  
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Read user input from textboxes and trim whitespace
            string username = txtAccountNumber.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            else if (username == "E000000")
            {
                MessageBox.Show("Invalid username or password.");
                return; 
            }

            string query;
            string role;

            if (username.StartsWith("C"))
            {
                role = "Customer";
                /// Hashing and injection prevention:
                /// Using SQL Server's Hashbytes function with the SHA2_256 algorithm -
                /// - to securely compare the hashed password input with the stored hashed password in the database
                /// Improving Secuirty by avoiding plaintext password handling and leveraging strong hashing algorithms
                /// Used in both roles to ensure consistent and secure password verification for all users
                query = @"
                    SELECT accountNumber
                    FROM Customer
                    WHERE accountNumber = @Username
                    AND [password] = HASHBYTES('SHA2_256', @Password);";
            }
            else if (username.StartsWith("E"))
            {
                role = "Employee";

                query = @"
                    SELECT employeeID
                    FROM Employee
                    WHERE employeeID = @Username
                    AND [password] = HASHBYTES('SHA2_256', @Password);";
            }
            else
            {
                MessageBox.Show("Username must start with C for customer or E for employee.");
                return;
            }
            /// Connecting to the database and executing the query securely with parameterized commands to prevent SQL injection
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 20).Value = password;

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show("Login successful.");

                        HomeForm homeForm = new HomeForm(username, role, this, connectionString);
                        homeForm.FormClosed += (s, args) =>
                        {
                            txtAccountNumber.Text = "";
                            txtPassword.Text = ""; 
                        };
                        homeForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            /// Catching any exceptions that may occur during the database connection and query execution, and displaying an error message to the user
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }

    }
}