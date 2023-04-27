using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEEK9_10_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into PATIENT values(@Id,@First_Name,@Middle_Initial,@Last_name)", con);

            con.Open();
            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@First_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Middle_Initial", textBox3.Text);
            cmd.Parameters.AddWithValue("@Last_name", textBox4.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Complete");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Update PATIENT set First_Name = @First_Name, Middle_Initial = @Middle_Initial, Last_name= @Last_name where Id = @Id", con);

         
            cmd1.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd1.Parameters.AddWithValue("@First_Name", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Middle_Initial", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Last_name", textBox4.Text);
            cmd1.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Inventory has been updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Delete PATIENT where Id = @Id", con);
            cmd2.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Id has been deleted");

        }
    }
}
