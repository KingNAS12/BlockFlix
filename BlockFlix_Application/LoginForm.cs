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
        private void textBox1_TextChanged(object sender, EventArgs e)
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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string query = @"
                SELECT accountNumber
                FROM Customer
                WHERE accountNumber = @Username
                AND [password] = @Password;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    MessageBox.Show("Login successful.");
                    CustomerScreen customerScreen = new CustomerScreen(username, connectionString);
                    customerScreen.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

    }
}
