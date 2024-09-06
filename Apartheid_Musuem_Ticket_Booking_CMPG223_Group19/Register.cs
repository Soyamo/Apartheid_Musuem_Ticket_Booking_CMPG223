using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class Register : Form
    {
        String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection cnn;
        DataSet ds;
        SqlCommand cmd;

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.reg;
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string fname = txtName.Text;
                    string lname = txtLast.Text;
                    string email = txtEnail.Text;
                    string pword = txtPassword.Text;   


                    string commandQuery = $"INSERT INTO Customers (firstName, lastName, emailAddress, password, BankAccountNum)  VALUES ('{fname}', '{lname}', '{email}', '{pword}', NULL)";
                    cnn = new SqlConnection(conString);
                    cnn.Open();

                    string query = @"Select CustomerID FROM Customers";
                    cmd = new SqlCommand(query, cnn);
                    adapter = new SqlDataAdapter(cmd);
                    ds = new DataSet();

                    adapter.Fill(ds, "Customers");
                    




                    using (SqlCommand sqlCommand = new SqlCommand(commandQuery, con))
                    {
                        

                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record inserted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No records were inserted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    // Handle the exception as needed (log it, show a user-friendly message, etc.)
                }
           
            }
            this.Close();
            // Create an instance of the form you want to open
            
            login form2 = new login();
            // Show the form
            form2.Show();
            
            
        }
    }
}
