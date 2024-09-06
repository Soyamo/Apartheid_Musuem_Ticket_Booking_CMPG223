using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class Admin : Form
    {
        String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Schema.mdf;Integrated Security=True";
        SqlDataAdapter adapter;
        SqlConnection cnn;
        DataSet ds;
        SqlCommand cmd;


        public Admin()
        {
            InitializeComponent();
        }

        public void loadCustomer()
        {
            cnn.Open();

            string query = @"SELECT * FROM Customers";
            adapter = new SqlDataAdapter();
            cmd = new SqlCommand(query, cnn);
            adapter.SelectCommand = cmd;
            ds = new DataSet();
            adapter.Fill(ds, "Customers");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Customers";

            cnn.Close();
        }

        public void loadEvents()
        {
            cnn.Open();

            string query = @"SELECT * FROM exhibition";
            adapter = new SqlDataAdapter();
            cmd = new SqlCommand(query, cnn);
            adapter.SelectCommand = cmd;
            ds = new DataSet();
            adapter.Fill(ds, "exhibition");

            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "exhibition";

            cnn.Close();
        }

        public void loadEmployee()
        {
            cnn.Open();

            string query = @"SELECT * FROM Employee";
            adapter = new SqlDataAdapter();
            cmd = new SqlCommand(query, cnn);
            adapter.SelectCommand = cmd;
            ds = new DataSet();
            adapter.Fill(ds, "Employee");

            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Employee";

            cnn.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schemaDataSet14.Customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter4.Fill(this.schemaDataSet14.Customers);
            // TODO: This line of code loads data into the 'schemaDataSet13.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter3.Fill(this.schemaDataSet13.Customers);
            // TODO: This line of code loads data into the 'schemaDataSet12.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter2.Fill(this.schemaDataSet12.Employee);
            // TODO: This line of code loads data into the 'schemaDataSet11.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter2.Fill(this.schemaDataSet11.Customers);
            // TODO: This line of code loads data into the 'schemaDataSet10.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter5.Fill(this.schemaDataSet10.exhibition);
            // TODO: This line of code loads data into the 'schemaDataSet8.Customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter1.Fill(this.schemaDataSet8.Customers);
            // TODO: This line of code loads data into the 'schemaDataSet7.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.schemaDataSet7.Customers);
            // TODO: This line of code loads data into the 'schemaDataSet6.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter4.Fill(this.schemaDataSet6.exhibition);
            // TODO: This line of code loads data into the 'schemaDataSet5.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter3.Fill(this.schemaDataSet5.exhibition);
            // TODO: This line of code loads data into the 'schemaDataSet4.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter2.Fill(this.schemaDataSet4.exhibition);
            // TODO: This line of code loads data into the 'schemaDataSet3.exhibition' table. You can move, or remove it, as needed.
            this.exhibitionTableAdapter1.Fill(this.schemaDataSet3.exhibition);
            // TODO: This line of code loads data into the 'schemaDataSet2.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter1.Fill(this.schemaDataSet2.Employee);
            // TODO: This line of code loads data into the 'schemaDataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.schemaDataSet1.Employee);
            // TODO: This line of code loads data into the 'schemaDataSet.exhibition' table. You can move, or remove it, as needed.
            
            pictureBox1.Image = Properties.Resources.veIcon;
            pictureBox2.Image = Properties.Resources.log;
            pictureBox3.Image = Properties.Resources.p1;
            pictureBox4.Image = Properties.Resources.events;
            pictureBox5.Image = Properties.Resources.staff;
            pictureBox6.Image = Properties.Resources.heritage;
            pictureBox7.Image = Properties.Resources.obama;
            pictureBox8.Image = Properties.Resources.cust;
            pictureBox9.Image = Properties.Resources.mm;


            lbl3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            textBox8.Visible = false;
            textBox7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            label16.Visible = false;
            label15.Visible = false;
            label8.Visible = false;
            label14.Visible = false;
            textBox11.Visible = false;
            textBox10.Visible = false;
            monthCalendar1.Visible = false;
            numericUpDown1.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            comboBox4.Hide();
            label19.Hide();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbl3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    if (cnn.State != ConnectionState.Open)
                        cnn.Open();

                    // Assuming you have a unique identifier for the customer, such as a customer ID.
                    // Replace "CustomerID" with the actual name of your unique identifier column.
          

                    string query = "UPDATE Customers " +
                                   "SET firstName = @firstName, " +
                                   "    lastName = @lastName, " +
                                   "    emailAddress = @emailAddress, " +
                                   "    password = @password " +
                                   "WHERE CustomerID = @CustomerId"; // Use your unique identifier column here.

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                        cmd.Parameters.AddWithValue("@emailAddress", textBox3.Text);
                        cmd.Parameters.AddWithValue("@password", textBox4.Text);
                        cmd.Parameters.AddWithValue("@CustomerId", comboBox4.Text); // Bind the unique identifier parameter.

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // You can add code here to handle success
                            MessageBox.Show("The UPDATE was successful");
                            loadCustomer();
                            
                        }
                        else
                        {
                            // You can add code here to handle failure
                            MessageBox.Show("The UPDATE was NOT successful!!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the database update.
                MessageBox.Show("Error: " + ex.Message);
            }

        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            lbl3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();
                // Prepare the SQL statement
                string query = $"INSERT INTO Customers (firstName, lastName, emailAddress, password )VALUES ('{textBox1.Text}' , '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}' )";
                cmd = new SqlCommand(query, cnn);
                {
                    // Set parameter values
                    cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@emailAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@password", textBox4.Text);

                    // Execute the SQL statement
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();

                loadCustomer();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            label10.Visible = false;
            textBox8.Visible = false;
            textBox7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    if (cnn.State != ConnectionState.Open)
                        cnn.Open();

                    string query = "UPDATE Employee " +
                                   "SET firstName = @firstName, " +
                                   "    lastName = @lastName " +
                                   "WHERE Employee_ID = @employeeId"; // Use your unique identifier column here.

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", textBox8.Text);
                        cmd.Parameters.AddWithValue("@lastName", textBox7.Text);
                        cmd.Parameters.AddWithValue("@employeeId", comboBox5.Text); // Bind the unique identifier parameter.

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // The UPDATE was successful
                            // You can add code here to handle success
                            MessageBox.Show("The UPDATE was successful");
                            loadEmployee();
                        }
                        else
                        {
                            // The UPDATE failed
                            MessageBox.Show("The UPDATE was NOT successful!!!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle any exceptions that may occur during the database update.
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            label10.Visible = false;
            textBox8.Visible = false;
            textBox7.Visible = false;
            button8.Visible = false;
            label20.Visible = false;
            comboBox5.Visible = false;

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();
                // Prepare the SQL statement
                string query = $"INSERT INTO Employee (firstName, lastName )VALUES ('{textBox8.Text}' , '{textBox8.Text}' )";
                cmd = new SqlCommand(query, cnn);
                {
                    // Set parameter values
                    cmd.Parameters.AddWithValue("@firstName", textBox8.Text);
                    cmd.Parameters.AddWithValue("@lastName", textBox7.Text);

                    // Execute the SQL statement
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
                
                loadEmployee();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label16.Visible = false;
            label15.Visible = false;
            label8.Visible = false;
            label14.Visible = false;
            textBox11.Visible = false;
            textBox10.Visible = false;
            monthCalendar1.Visible = false;
            numericUpDown1.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            comboBox6.Show();
            label21.Show();

            decimal numeric = numericUpDown1.Value;

            try
            {
                using (SqlConnection cnn = new SqlConnection(conString))
                {
                    cnn.Open();

                    string query = "UPDATE exhibition " +
                                   "SET eventName = @eventName, " +
                                   "    eventPrice = @eventPrice, " +
                                   "    eventDate = @eventDate, " +
                                   "    Space_left = @numericColumn " +
                                   "WHERE exhibitionID = @eventID"; // Use your unique identifier column here.

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@eventName", textBox11.Text);
                        cmd.Parameters.AddWithValue("@eventPrice", textBox10.Text);
                        cmd.Parameters.AddWithValue("@eventDate", monthCalendar1.SelectionStart);
                        cmd.Parameters.AddWithValue("@numericColumn", numeric);
                        cmd.Parameters.AddWithValue("@eventID", comboBox6.Text); // Bind the unique identifier parameter.

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // The UPDATE was successful
                            // You can add code here to handle success
                            MessageBox.Show("The event has been updated");
                            loadEvents();
                        }
                        else
                        {
                            // The UPDATE failed
                            // You can add code here to handle failure
                            MessageBox.Show("No records were updated. Event not found.");
                        }
                    }
                }
            }
            catch (SqlException error)
            {
                // Handle any exceptions that may occur during the database update.
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label16.Visible = false;
            label15.Visible = false;
            label8.Visible = false;
            label14.Visible = false;
            textBox11.Visible = false;
            textBox10.Visible = false;
            monthCalendar1.Visible = false;
            numericUpDown1.Visible = false;
            button14.Visible = false;
            button15.Visible = false;

            decimal numeric = numericUpDown1.Value;

            try
            {
                cnn = new SqlConnection(conString);
                cnn.Open();
                SqlCommand sqlcommand = new SqlCommand($"INSERT INTO exhibition VALUES('{textBox11.Text}', '{textBox10.Text}', '{monthCalendar1.SelectionStart}', {numeric})", cnn);
                adapter = new SqlDataAdapter();

                adapter.InsertCommand = sqlcommand;
                adapter.InsertCommand.ExecuteNonQuery();

                cnn.Close();
                MessageBox.Show("The Events has been added");
                loadEvents();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();
                string sql = "DELETE FROM Customers WHERE emailAddress = '" + comboBox1.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                adapter = new SqlDataAdapter();
                adapter.DeleteCommand = cmd;

                cmd.ExecuteNonQuery();
               

                cnn.Close();
                MessageBox.Show("Item Removed");
                loadCustomer();
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                cnn.Close();
            }

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select CustomerID FROM Customers";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "Customers");
                comboBox1.DisplayMember = "CustomerID";
                comboBox1.DataSource = ds.Tables["Customers"];
                cnn.Close();


            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            lbl3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible = false;
            button5.Visible = true;
            label19.Show();
            comboBox4.Show();
            try
            {
                
                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select CustomerID FROM Customers";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "Customers");
                comboBox4.DisplayMember = "CustomerID";
                comboBox4.DataSource = ds.Tables["Customers"];
                cnn.Close();


            }catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            comboBox4.Hide();
            label19.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label10.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;
            button8.Visible = false;
            button9.Visible = true;
            comboBox5.Hide();
            label20.Hide();

           
        }


        private void button10_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label10.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;
            button8.Visible = true;
            button9.Visible = false;
            comboBox5.Show();
            label20.Show();

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select Employee_ID FROM Employee";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "Employee");
                comboBox5.DisplayMember = "Employee_ID";
                comboBox5.DataSource = ds.Tables["Employee"];
                cnn.Close();

            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label16.Visible = true;
            label15.Visible = true;
            label8.Visible = true;
            textBox11.Visible = true;
            textBox10.Visible = true;
            monthCalendar1.Visible = true;
            numericUpDown1.Visible = true;
            button14.Visible = false;
            button15.Visible = true;
            comboBox6.Hide();
            label21.Hide();




        }

        private void button16_Click(object sender, EventArgs e)
        {
            label16.Visible = true;
            label15.Visible = true;
            label8.Visible = true;
            textBox11.Visible = true;
            textBox10.Visible = true;
            monthCalendar1.Visible = true;
            numericUpDown1.Visible = true;
            button14.Visible = true;
            button15.Visible = false;
            comboBox6.Show();
            label21.Show();


            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select exhibitionID FROM exhibition";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "exhibition");
                comboBox6.DisplayMember = "exhibitionID";
                comboBox6.DataSource = ds.Tables["exhibition"];
                cnn.Close();


            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();
                string sql = @"DELETE FROM Employee WHERE Employee_ID = '" + comboBox2.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                adapter = new SqlDataAdapter();
                adapter.DeleteCommand = cmd;

                cmd.ExecuteNonQuery();


                cnn.Close();
                MessageBox.Show("Item Removed");
                loadEmployee();
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                cnn.Close();
            }

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select Employee_ID FROM Employee";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "Employee");
                comboBox2.DisplayMember = "Employee_ID";
                comboBox2.DataSource = ds.Tables["Employee"];
                cnn.Close();


            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();
                string sql = @"DELETE FROM exhibition WHERE eventName = '" + comboBox3.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                adapter = new SqlDataAdapter();
                adapter.DeleteCommand = cmd;

                cmd.ExecuteNonQuery();


                cnn.Close();
                MessageBox.Show("Item Removed");
                loadEvents();
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                cnn.Close();
            }

            try
            {

                cnn = new SqlConnection(conString);
                cnn.Open();

                string query = @"Select eventName FROM exhibition";
                cmd = new SqlCommand(query, cnn);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();

                adapter.Fill(ds, "exhibition");
                comboBox3.DisplayMember = "eventName";
                comboBox3.DataSource = ds.Tables["exhibition"];
                cnn.Close();


            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
           

        }
        
        private void SortExhibitionData(string sortBy, string sortOrder)
        {
            try
            {
                cnn = new SqlConnection(conString);
                cnn.Open();

                // Define the SQL query to retrieve and sort the data
                string query = $"SELECT * FROM exhibition ORDER BY {sortBy} {sortOrder}";

                // Create a SqlDataAdapter to fetch the data
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cnn);

                // Create a DataSet to store the data
                DataSet dataSet = new DataSet();

                // Fill the DataSet with the sorted data
                dataAdapter.Fill(dataSet, "exhibition");

                // Bind the DataGridView to the sorted data
                dataGridView4.DataSource = dataSet.Tables["exhibition"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        private string GetSortOrder()
        {
            if (radioButton4.Checked)
            {
                return "ASC";
            }
            else if (radioButton5.Checked)
            {
                return "DESC";
            }
            else
            {
                // Default to ascending if neither radio button is checked.
                return "ASC";
            }
        }
        private string GetSortColumn()
        {
            if (radioButton1.Checked)
            {
                return "eventPrice";
            }
            else if (radioButton2.Checked)
            {
                return "Space_left";
            }
            else
            {
                // Default to "price" if neither radio button is checked.
                return "eventPrice";
            }
        }
        

        public void loadEvent()
        {
            cnn = new SqlConnection(conString);
            cnn.Open();

            string query = @"SELECT * FROM exhibition";
            adapter = new SqlDataAdapter();
            cmd = new SqlCommand(query, cnn);
            adapter.SelectCommand = cmd;
            ds = new DataSet();
            adapter.Fill(ds, "exhibition");

            dataGridView4.DataSource = ds;
            dataGridView4.DataMember = "exhibition";

            cnn.Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            loadEvent();
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SortExhibitionData("eventPrice", GetSortOrder());
            loadEvent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SortExhibitionData("Space_left", GetSortOrder());

        }
        
        

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SortExhibitionData(GetSortColumn(), "ASC");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
           SortExhibitionData(GetSortColumn(), "DESC");
            loadEvent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SortExhibitionData("eventDate", GetSortOrder());
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
