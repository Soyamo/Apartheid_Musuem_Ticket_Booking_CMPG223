using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class Payments : Form
    {
        String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection cnn;
        DataSet ds;
        SqlCommand cmd;

        public Payments()
        {
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.bill;
            pictureBox2.Image = Properties.Resources.log;
            pictureBox3.Image = Properties.Resources.Visa;
            pictureBox4.Image = Properties.Resources.pay;
            pictureBox5.Image = Properties.Resources.express;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bookings book = new Bookings();
            book.Show();
        }
        public void sendTicket()
        {
            cnn = new SqlConnection(conString);
            cnn.Open();

            string query = "SELECT * FROM ticket";
            cmd = new SqlCommand(query, cnn);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show("TicketID: " + reader.GetValue(0) + "\n Customer Name: " + reader.GetValue(1) + " " + reader.GetValue(2) + "\n Event Name: " + reader.GetValue(3) + "\n Price: R" + reader.GetValue(4));
                }

                else
                {
                    // Invalid login, show an error message
                    MessageBox.Show("Invalid login credentials. Please try again.");
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            string userInput = textBox1.Text;
            string cvv = textBox3.Text;

            if (userInput.Length == 16 && long.TryParse(userInput, out long _))
            {
                if(cvv.Length == 3 && short.TryParse(cvv, out short _))
                {
                    MessageBox.Show("Payment Successful! :) .", "Validation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login form2 = new login();
                    form2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Input must be a 3-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                sendTicket();
            }
            else
            {
                MessageBox.Show("Input must be a 16-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            /*
            cnn = new SqlConnection(conString);
            cnn.Open();

            string query = "SELECT * FROM ticket";
            cmd = new SqlCommand(query, cnn);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show("TicketID: " + reader.GetValue(0) + "\n Customer Name: " + reader.GetValue(1) + " " + reader.GetValue(2) + "\n Event Name: " + reader.GetValue(3) + "\n Price: R" + reader.GetValue(4));
                }

                else
                {
                    // Invalid login, show an error message
                    MessageBox.Show("Invalid login credentials. Please try again.");
                }

            }
            */



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Absa")
            {
                txtBranch.Text = "632005";
            }
            else if(comboBox1.Text == "Capitec Bank")
            {
                txtBranch.Text = "470010";
             
            }
            else if(comboBox1.Text == "First National Bank")
            {
                txtBranch.Text = "250655";
            }
            else if (comboBox1.Text == "Nedbank")
            {
                txtBranch.Text = "198665";
            }
            else if (comboBox1.Text == "Standard Bank")
            {
                txtBranch.Text = "730020";
            }
            else
            {
                txtBranch.Text = string.Empty;
            }
        }
    }
}
