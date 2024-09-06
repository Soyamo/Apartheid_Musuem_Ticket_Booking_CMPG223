using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Net.Mail;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class login : Form
    {
        String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd;


        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

            //pictureBox1.Image = Properties.Resources.proIcon1;
            pictureBox1.Image = Properties.Resources.mandela;
            pictureBox2.Image = Properties.Resources.proIcon1;
            pictureBox3.Image = Properties.Resources.mandela;
            pictureBox4.Image = Properties.Resources.proIcon1;

        }



        private void tabPage2_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = Properties.Resources.proIcon1;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register frm3 = new Register();
            frm3.Show();
            this.Close();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {


            string enteredEmail = txtEmail.Text;
            string enteredPassword = txtPassword.Text;

            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True");
            try
            {
                con.Open();
                // Use a parameterized query to prevent SQL injection
                string sqlQuery = $"SELECT * FROM Customers WHERE emailAddress = '{enteredEmail}' AND password = '{enteredPassword}'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
                con.Close();

                con.Open();
                string userInfoQuery = $"SELECT firstName, lastName, emailAddress FROM Customers WHERE emailAddress = '{enteredEmail}' AND password = '{enteredPassword}'";

                using (SqlCommand cmd = new SqlCommand(userInfoQuery, con))
                {
                    cmd.Parameters.AddWithValue("@emailAddress", enteredEmail);
                    cmd.Parameters.AddWithValue("@password", enteredPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Get user information
                            string firstName = reader["firstName"].ToString();
                            string lastName = reader["lastName"].ToString();
                            string emailAddress = reader["emailAddress"].ToString();
                            // Valid login, do something here (e.g., open a new form)
                            MessageBox.Show("Login successful!");

                            // Pass the user details to the Bookings form
                            Bookings bookings = new Bookings(firstName, lastName, emailAddress);


                            bookings.Show();
                            this.Close();
                        }
                        else
                        {
                            // Invalid login, show an error message
                            MessageBox.Show("Invalid login credentials. Please try again.");
                        }
                    }

                    con.Close();

                }

                  
                
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string admin = txtAdEmail.Text; // Assuming txtEmail is a TextBox control
            string password = txtAdPassword.Text; // Assuming txtPassword is a TextBox

            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True");
            try
            {
                con.Open();
                // Use a parameterized query to prevent SQL injection
                string sqlQuery = "SELECT * FROM Admin WHERE Admin_ID = @AdminID AND Password = @Password";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);

                // Add parameters for Employee_ID and Password
                sqlCommand.Parameters.AddWithValue("@AdminID", admin);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    // Valid login, do something here (e.g., open a new form)
                    MessageBox.Show("Login successful!");

                    Admin admin1 = new Admin();
                    admin1.Show();
                    this.Close();
                }
                else
                {
                    // Invalid login, show an error message
                    MessageBox.Show("Invalid login credentials. Please try again.");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtAdPassword_TextChanged(object sender, EventArgs e)
        {
            txtAdPassword.PasswordChar = '*';
        }

        private void btnExLog_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
