using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartheid_Musuem_Ticket_Booking_CMPG223_Group19
{
    public partial class Form1 : Form
    {
        /*Group 19
            Vakala, Lloyd – 37421115
            Maphela, K – 43674976
            Sibiya, LM – 41566599
            Temane, EN – 42003318
            Moleya, MP - 331470788*/

        public Form1()
        {
            InitializeComponent();
        }

        private void linklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login form2 = new login();
            form2.Show();
            CloseForm();

        }

        private void CloseForm()
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ticket;
        }
    }
}
