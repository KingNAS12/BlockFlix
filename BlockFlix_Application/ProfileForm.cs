using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BlockFlix_Application
{
    /// <summary>
    /// ProfileForm is used for both customers and employees to view and edit their profile information. 
    /// It is opened from HomeForm after login. It uses the userId and role passed from HomeForm to determine which profile to load and which fields to show. 
    /// Customers can edit all their information including password, while employees can only edit their name and address. When the user clicks Save, 
    /// the form validates the input and updates the database with the new information. If there are any errors during loading or saving, it shows an error message to the user.
    /// </summary>
    public partial class ProfileForm : Form
    {
        private readonly string userId;
        private readonly string role;
        private readonly string connectionString;
        private readonly bool newProfile; 

        // Needed so Visual Studio Designer can open ProfileForm.
        public ProfileForm()
        {
            InitializeComponent();

            userId = "";
            role = "";
            connectionString = "";
            newProfile = false;

            WireUpButtons();
        }

        // Used when HomeForm opens ProfileForm after login.
        public ProfileForm(string userId, string role, string connectionString, bool newProfile = false)
        {
            InitializeComponent();

            this.userId = userId;
            this.role = role;
            this.connectionString = connectionString;
            this.newProfile = newProfile;

            WireUpButtons();
        }

        private void WireUpButtons()
        {
            btnClose.Click += btnClose_Click;
            btnSave.Click += btnSave_Click;
        }
        /// <summary>
        /// When the form loads, it checks the role of the user. If the user is a customer, it loads the customer's profile information from the database and populates the form fields.
        /// </summary>

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            txtUserId.Text = userId;
            txtRole.Text = role;

            if (role == "Customer")
            {
                if (newProfile)
                {
                    txtUserId.Text = userId; 
                    txtRole.Text = role;
                }
                else
                {
                    LoadCustomerProfile();
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                }
            }
            else if (role == "Employee")
            {
                LoadEmployeeProfile();

                lblEmail.Visible = false;
                txtEmail.Visible = false;

                lblPaymentIdentifier.Visible = false;
                txtPaymentIdentifier.Visible = false;

                comboBoxGender.Visible = false;
                dateTimePicker1.Visible = false;
                labelDob.Visible = false;

                lblPassword.Visible = false;
                txtPassword.Visible = false;
            }
            else
            {
                MessageBox.Show("Unknown role. Cannot load profile.");
                Close();
            }
        }
        /// <summary>
        /// The LoadCustomerProfile method retrieves the customer's profile information 
        /// from the database using their account number (userId) and populates the form fields with the retrieved data.
        /// </summary>
        private void LoadCustomerProfile()
        {
            string sql = @"
                SELECT accountNumber, email, firstName, lastName,
                       houseNumber, street, city, province, postalCode,
                       paymentIdentifier, password, gender, dob
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
                    dateTimePicker1.Value = reader["dob"] != DBNull.Value ? Convert.ToDateTime(reader["dob"]) : DateTime.Now;
                    comboBoxGender.SelectedItem = reader["gender"].ToString() switch
                    {
                        "M" => "Male",
                        "F" => "Female",
                        "O" => "Other",
                        "N" => "Prefer Not To Say",
                        _ => null
                    };
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
        /// <summary>
        /// The LoadEmployeeProfile method retrieves the employee's profile information from the database 
        /// using their employee ID (userId) and populates the form fields with the retrieved data.
        /// </summary>
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
            Close();
        }
        /// <summary>
        /// The ValidateProfileInput method checks the user input in the form fields to ensure they meet certain criteria before allowing the profile to be saved.
        /// </summary>
        private bool ValidateProfileInput()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string houseNumberText = txtHouseNumber.Text.Trim();
            string street = txtStreet.Text.Trim();
            string city = txtCity.Text.Trim().ToUpper();
            string province = txtProvince.Text.Trim().ToUpper();
            string postalCode = txtPostalCode.Text.Trim().Replace(" ", "").ToUpper();
            string password = txtPassword.Text.Trim();
            DateTime dob = dateTimePicker1.Value;

            if (firstName == "" || lastName == "")
            {
                MessageBox.Show("First name and last name cannot be blank.");
                return false;
            }

            if (password == "" && newProfile)
            {
                MessageBox.Show("Password cannot be blank.");
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
        /// <summary>
        /// The SaveCustomerProfile method takes the input from the form fields and updates the customer's profile information in the database. 
        /// If it's a new profile, it inserts a new record; otherwise, it updates the existing record. 
        /// It also handles hashing the password for new profiles and shows a success or error message based on the outcome of the database operation.
        /// </summary>
        private void SaveCustomerProfile()
        {
            string sql = "";
            if (newProfile)
            {
                sql = @"
                    INSERT INTO Customer (
                        accountNumber,
                        [password], 
                        accountCreationDate, 
                        email, 
                        firstName, 
                        lastName, 
                        gender, 
                        dob, 
                        houseNumber, 
                        street, 
                        city, 
                        province, 
                        postalCode, 
                        paymentIdentifier, 
                        customerRating
                    ) VALUES (
                        @UserId, 
                        HASHBYTES('SHA2_256', @Password), 
                        GETDATE(),
                        @Email, 
                        @FirstName, 
                        @LastName,
                        @gender,
                        @dob,    
                        @HouseNumber, 
                        @Street, 
                        @City, 
                        @Province, 
                        @PostalCode,
                        @PaymentIdentifier, 
                        NULL
                    );";
            }
            else
            {
                sql = @"
                    UPDATE Customer
                    SET email = @Email,
                        firstName = @FirstName,
                        lastName = @LastName,
                        gender = @gender,
                        dob = @dob,
                        houseNumber = @HouseNumber,
                        street = @Street,
                        city = @City,
                        province = @Province,
                        postalCode = @PostalCode,
                        paymentIdentifier = @PaymentIdentifier
                    WHERE accountNumber = @UserId;";
            }

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
                if (newProfile)
                {
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 20).Value = txtPassword.Text.Trim();
                }
                cmd.Parameters.AddWithValue("@gender",
                    comboBoxGender.SelectedItem?.ToString() == "Male" ? "M" :
                    comboBoxGender.SelectedItem?.ToString() == "Female" ? "F" :
                    comboBoxGender.SelectedItem?.ToString() == "Other" ? "O" :
                    comboBoxGender.SelectedItem?.ToString() == "Prefer Not To Say" ? "N" :
                    DBNull.Value);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);

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
        /// <summary>
        /// The SaveEmployeeProfile method takes the input from the form fields and updates the employee's profile information in the database.
        /// </summary>
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