using Microsoft.Data.SqlClient;

namespace BlockFlix_Application
{
    public partial class LoginForm : Form
    {
        private string connectionString =
            @"Server=localhost;Database=CMPT291_Team7_MovieRental;Trusted_Connection=True;TrustServerCertificate=True;";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {


        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string query;
            string role;

            if (username.StartsWith("C"))
            {
                role = "Customer";

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
                        homeForm.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }

    }
}