using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BlockFlix_Application
{
    public partial class ProfileForm : Form
    {
        private readonly string userId;
        private readonly string role;
        private readonly string connectionString;

        // Needed so Visual Studio Designer can open ProfileForm.
        public ProfileForm()
        {
            InitializeComponent();

            userId = "";
            role = "";
            connectionString = "";

            WireUpButtons();
        }

        // Used when HomeForm opens ProfileForm after login.
        public ProfileForm(string userId, string role, string connectionString)
        {
            InitializeComponent();

            this.userId = userId;
            this.role = role;
            this.connectionString = connectionString;

            WireUpButtons();
        }

        private void WireUpButtons()
        {
            btnClose.Click += btnClose_Click;
            btnSave.Click += btnSave_Click;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            txtUserId.Text = userId;
            txtRole.Text = role;

            if (role == "Customer")
            {
                LoadCustomerProfile();
            }
            else if (role == "Employee")
            {
                LoadEmployeeProfile();

                lblEmail.Visible = false;
                txtEmail.Visible = false;

                lblPaymentIdentifier.Visible = false;
                txtPaymentIdentifier.Visible = false;
            }
            else
            {
                MessageBox.Show("Unknown role. Cannot load profile.");
                Close();
            }
        }

        private void LoadCustomerProfile()
        {
            string sql = @"
                SELECT accountNumber, email, firstName, lastName,
                       houseNumber, street, city, province, postalCode,
                       paymentIdentifier
                FROM Customer
                WHERE accountNumber = @UserId;";

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtUserId.Text = reader["accountNumber"].ToString();
                    txtRole.Text = "Customer";
                    txtFirstName.Text = reader["firstName"].ToString();
                    txtLastName.Text = reader["lastName"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtHouseNumber.Text = reader["houseNumber"].ToString();
                    txtStreet.Text = reader["street"].ToString();
                    txtCity.Text = reader["city"].ToString();
                    txtProvince.Text = reader["province"].ToString();
                    txtPostalCode.Text = reader["postalCode"].ToString();
                    txtPaymentIdentifier.Text = reader["paymentIdentifier"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer profile not found.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load customer profile: " + ex.Message);
            }
        }

        private void LoadEmployeeProfile()
        {
            string sql = @"
                SELECT employeeID, firstName, lastName,
                       houseNumber, street, city, province, postalCode
                FROM Employee
                WHERE employeeID = @UserId;";

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtUserId.Text = reader["employeeID"].ToString();
                    txtRole.Text = "Employee";
                    txtFirstName.Text = reader["firstName"].ToString();
                    txtLastName.Text = reader["lastName"].ToString();
                    txtHouseNumber.Text = reader["houseNumber"].ToString();
                    txtStreet.Text = reader["street"].ToString();
                    txtCity.Text = reader["city"].ToString();
                    txtProvince.Text = reader["province"].ToString();
                    txtPostalCode.Text = reader["postalCode"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee profile not found.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load employee profile: " + ex.Message);
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateProfileInput())
            {
                return;
            }

            if (role == "Customer")
            {
                SaveCustomerProfile();
            }
            else if (role == "Employee")
            {
                SaveEmployeeProfile();
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            // User can close only if the visible profile fields are not blank/invalid.
            if (!ValidateProfileInput())
            {
                MessageBox.Show("Please fill all required fields before closing.");
                return;
            }

            Close();
        }

        private bool ValidateProfileInput()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string houseNumberText = txtHouseNumber.Text.Trim();
            string street = txtStreet.Text.Trim();
            string city = txtCity.Text.Trim().ToUpper();
            string province = txtProvince.Text.Trim().ToUpper();
            string postalCode = txtPostalCode.Text.Trim().Replace(" ", "").ToUpper();

            if (firstName == "" || lastName == "")
            {
                MessageBox.Show("First name and last name cannot be blank.");
                return false;
            }

            if (firstName.Length > 20 || lastName.Length > 20)
            {
                MessageBox.Show("First name and last name must be 20 characters or less.");
                return false;
            }

            if (!int.TryParse(houseNumberText, out int houseNumber))
            {
                MessageBox.Show("House number must be a whole number.");
                return false;
            }

            if (houseNumber < 0 || houseNumber > 99999)
            {
                MessageBox.Show("House number must be between 0 and 99999.");
                return false;
            }

            if (street == "")
            {
                MessageBox.Show("Street cannot be blank.");
                return false;
            }

            if (street.Length > 10)
            {
                MessageBox.Show("Street must be 10 characters or less.");
                return false;
            }

            if (city == "")
            {
                MessageBox.Show("City cannot be blank.");
                return false;
            }

            if (city.Length != 3)
            {
                MessageBox.Show("City must be exactly 3 characters, like YEG.");
                return false;
            }

            if (province == "")
            {
                MessageBox.Show("Province cannot be blank.");
                return false;
            }

            if (province.Length != 2)
            {
                MessageBox.Show("Province must be exactly 2 characters, like AB.");
                return false;
            }

            if (postalCode == "")
            {
                MessageBox.Show("Postal code cannot be blank.");
                return false;
            }

            if (postalCode.Length != 6)
            {
                MessageBox.Show("Postal code must be exactly 6 characters, like T5J1A1.");
                return false;
            }

            if (role == "Customer")
            {
                string email = txtEmail.Text.Trim();
                string paymentIdentifier = txtPaymentIdentifier.Text.Trim();

                if (email == "")
                {
                    MessageBox.Show("Email cannot be blank.");
                    return false;
                }

                if (!email.Contains("@"))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    return false;
                }

                if (paymentIdentifier == "")
                {
                    MessageBox.Show("Payment ID cannot be blank.");
                    return false;
                }

                if (paymentIdentifier.Length > 20)
                {
                    MessageBox.Show("Payment ID must be 20 characters or less.");
                    return false;
                }
            }

            txtCity.Text = city;
            txtProvince.Text = province;
            txtPostalCode.Text = postalCode;

            return true;
        }

        private void SaveCustomerProfile()
        {
            string sql = @"
                UPDATE Customer
                SET email = @Email,
                    firstName = @FirstName,
                    lastName = @LastName,
                    houseNumber = @HouseNumber,
                    street = @Street,
                    city = @City,
                    province = @Province,
                    postalCode = @PostalCode,
                    paymentIdentifier = @PaymentIdentifier
                WHERE accountNumber = @UserId;";

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@HouseNumber", int.Parse(txtHouseNumber.Text.Trim()));
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim());
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text.Trim().Replace(" ", "").ToUpper());
                cmd.Parameters.AddWithValue("@PaymentIdentifier", txtPaymentIdentifier.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Customer profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("No customer profile was updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update customer profile: " + ex.Message);
            }
        }

        private void SaveEmployeeProfile()
        {
            string sql = @"
                UPDATE Employee
                SET firstName = @FirstName,
                    lastName = @LastName,
                    houseNumber = @HouseNumber,
                    street = @Street,
                    city = @City,
                    province = @Province,
                    postalCode = @PostalCode
                WHERE employeeID = @UserId;";

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@HouseNumber", int.Parse(txtHouseNumber.Text.Trim()));
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim());
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text.Trim().Replace(" ", "").ToUpper());
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Employee profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("No employee profile was updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update employee profile: " + ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Nothing needed here.
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Nothing needed here.
        }
    }
}