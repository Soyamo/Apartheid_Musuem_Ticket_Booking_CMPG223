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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class Bookings : Form
    {

        String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection cnn;
        DataSet ds;
        SqlCommand cmd;

        public Bookings()
        {
            InitializeComponent();
        }

        public Bookings(string firstName, string lastName, string emailAddress)
        {

            InitializeComponent();
            txtCustomerName.Text = firstName;
            txtCustSurname.Text = lastName;
            txtCustEmail.Text = emailAddress;
        }

        public void loadEvents()
        {
            try
            {
                cnn.Open();

                string query = @"SELECT * FROM exhibition";
                adapter = new SqlDataAdapter();
                cmd = new SqlCommand(query, cnn);
                adapter.SelectCommand = cmd;
                ds = new DataSet();
                adapter.Fill(ds, "exhibition");

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "exhibition";

                cnn.Close();
            }
            catch(SqlException ex) 
            {
                MessageBox.Show(ex.Message);

            }
            finally 
            { 
                cnn.Close();
            }    

        }

        private void Bookings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schemaDataSet9.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter.Fill(this.schemaDataSet9.exhibition);
            pictureBox1.Image = Properties.Resources.veIcon;
            pictureBox2.Image = Properties.Resources.log;
            pictureBox3.Image = Properties.Resources.parking_lot;
            lblTotal.Hide();

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select eventName FROM exhibition";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "exhibition");
                comboBox1.DisplayMember = "eventName";
                comboBox1.DataSource = ds.Tables["exhibition"];
                cnn.Close();


            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string venue = comboBox1.Text.ToString();  
            

            try
            {
                cnn = new SqlConnection(conString);
                cnn.Open();
                SqlCommand sqlcommand = new SqlCommand($"INSERT INTO ticket VALUES('{txtCustomerName.Text}', '{txtCustSurname.Text}', '{venue}', {totalAmount})", cnn);
                adapter = new SqlDataAdapter();

                adapter.InsertCommand = sqlcommand;
                adapter.InsertCommand.ExecuteNonQuery();

                cnn.Close();
                MessageBox.Show("The ticket has been added to the cart");
                
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }


            Payments pay = new Payments();
            pay.Show();
            this.Close();
        }

        private decimal GetEventPriceFromDatabase(string eventName)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Define a SQL query to retrieve the event price based on the event name
                string query = $"SELECT eventPrice FROM exhibition WHERE eventName = '{comboBox1.Text}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eventName", comboBox1.Text);

                    // Execute the query and retrieve the price
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Parse the result to a double (assuming the price is stored as a numeric type in the database)
                        if (decimal.TryParse(result.ToString(), out selectedEventPrice))
                        {
                            return selectedEventPrice;
                        }
                        else
                        {
                            // Handle the case where the price in the database is not a valid double
                            // You can return a default value or throw an exception as needed
                            return 0.0m;
                        }
                    }
                    else
                    {
                        // Handle the case where the event name was not found in the database
                        // You can return a default price or throw an exception as per your requirement
                        return 0.0m;
                    }
                }
            }
        }

        public decimal selectedEventPrice = 0.0m;
        decimal totalAmount;

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string selectedEventName = comboBox1.SelectedItem.ToString();

            // Retrieve the event's price from the database based on the selected event name
            selectedEventPrice = GetEventPriceFromDatabase(selectedEventName);

            // Get the quantity from the NumericUpDown control
            int quantity = (int)numericUpDown1.Value;

            // Calculate the total amount by multiplying the price by the quantity
            totalAmount = selectedEventPrice * quantity;

            lblTotal.Show();

            lblTotal.Text = "Total amount: " + totalAmount.ToString("C");

            try
            {

                cnn.Open();

                // Define your SQL query to decrement the column
                string sqlQuery = $"UPDATE exhibition SET Space_left = Space_left - {quantity} WHERE eventName = '{comboBox1.Text}'";

                // Create a SqlCommand with parameters
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn);

                // Execute the SQL command to decrement the column
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                cnn.Close();    
                loadEvents();
                

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}
