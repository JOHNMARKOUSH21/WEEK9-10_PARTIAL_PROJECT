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


        /// /////////////////////////insert
        private void button1_Click(object sender, EventArgs e)
        {
        
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM PATIENT WHERE Id = @Id", con);
            checkCmd.Parameters.AddWithValue("@Id", int.Parse(textBox111.Text));
            con.Open();
            int existingCount = (int)checkCmd.ExecuteScalar();
            con.Close();
            if (existingCount > 0)
            {
                MessageBox.Show("Please enter a different ID number.");
                return;
            }

            SqlCommand insertCmd = new SqlCommand("insert into PATIENT values(@Id,@First_Name,@Middle_Initial,@Last_name,@Age,@Sex,@Height_cm,@Weight_kg,@Phone_num,@Email,@Nationality,@Race,@Birthday,@Place_of_birth,@Blood_type)", con);
            insertCmd.Parameters.AddWithValue("@Id", int.Parse(textBox111.Text));
            insertCmd.Parameters.AddWithValue("@First_Name", textBox2.Text);
            insertCmd.Parameters.AddWithValue("@Middle_Initial", textBox3.Text);
            insertCmd.Parameters.AddWithValue("@Last_name", textBox4.Text);
            insertCmd.Parameters.AddWithValue("@Age", int.Parse(textBox5.Text));
            insertCmd.Parameters.AddWithValue("@Sex", textBox6.Text);
            insertCmd.Parameters.AddWithValue("@Height_cm", float.Parse(textBox7.Text));
            insertCmd.Parameters.AddWithValue("@Weight_kg", float.Parse(textBox8.Text));
            insertCmd.Parameters.AddWithValue("@Phone_num", textBox9.Text);
            insertCmd.Parameters.AddWithValue("@Email", textBox10.Text);
            insertCmd.Parameters.AddWithValue("@Nationality", textBox11.Text);
            insertCmd.Parameters.AddWithValue("@Race", textBox12.Text);
            insertCmd.Parameters.AddWithValue("@Birthday", textBox13.Text);
            insertCmd.Parameters.AddWithValue("@Place_of_birth", textBox14.Text);
            insertCmd.Parameters.AddWithValue("@Blood_type", textBox15.Text);

            con.Open();
            insertCmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Complete");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PATIENT", con);
            DataTable database = new DataTable();
            adapter.Fill(database);
            dataGridView1.DataSource = database;
            

        }
    /// /////////////////////////update
    private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Update PATIENT set First_Name = @First_Name, Middle_Initial = @Middle_Initial, Last_name= @Last_name, Age = @Age, Sex = @Sex, Height_cm = @Height_cm, Weight_kg = @Weight_kg, Phone_num = @Phone_num, Email = @Email, Nationality = @Nationality, Race = @Race, Birthday = @Birthday, Place_of_birth = @Place_of_birth, Blood_type = @Blood_type where Id = @Id", con);


            //@Id,@First_Name,@Middle_Initial,@Last_name,@Age,
            //@Sex,@Height_cm,@Weight_kg,@Phone_num,@Email
            //,@Nationality,@Race,@Birthday,@Place_of_birth,@Blood_type)"
            cmd1.Parameters.AddWithValue("@Id", int.Parse(textBox111.Text));
            cmd1.Parameters.AddWithValue("@First_Name", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Middle_Initial", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Last_name", textBox4.Text);
            cmd1.Parameters.AddWithValue("@Age", int.Parse(textBox5.Text));
            cmd1.Parameters.AddWithValue("@Sex", textBox6.Text);
            cmd1.Parameters.AddWithValue("@Height_cm", float.Parse(textBox7.Text));
            cmd1.Parameters.AddWithValue("@Weight_kg", float.Parse(textBox8.Text));
            cmd1.Parameters.AddWithValue("@Phone_num", textBox9.Text);
            //@Phone_num,@Email,@Nationality,@Race,@Birthday,@Place_of_birth,Blood_type
            cmd1.Parameters.AddWithValue("@Email", textBox10.Text);
            cmd1.Parameters.AddWithValue("@Nationality", textBox11.Text);
            cmd1.Parameters.AddWithValue("@Race", textBox12.Text);
            cmd1.Parameters.AddWithValue("@Birthday", textBox13.Text);
            cmd1.Parameters.AddWithValue("@Place_of_birth", textBox14.Text);
            cmd1.Parameters.AddWithValue("@Blood_type", textBox15.Text);
            cmd1.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Inventory has been updated");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PATIENT", con);
            DataTable database = new DataTable();
            adapter.Fill(database);
            dataGridView1.DataSource = database;


        }
        /// /////////////////////////Delete
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Delete PATIENT where Id = @Id", con);
            cmd2.Parameters.AddWithValue("@Id",int.Parse(textBox111.Text));
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Id has been deleted");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PATIENT", con);
            DataTable database = new DataTable();
            adapter.Fill(database);
            dataGridView1.DataSource = database;

        }
        /// /////////////////////////SEARCH
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();
              int id;
              if (int.TryParse(textBox111.Text, out id))
              {
                  SqlCommand cmd3 = new SqlCommand("Select * from PATIENT where Id=@Id", con);
                  //SqlCommand cmd3 = new SqlCommand("Select * from PATIENT", con);
                  cmd3.Parameters.AddWithValue("Id", id);
                  SqlDataAdapter adapter = new SqlDataAdapter(cmd3);
                  DataTable database = new DataTable();
                  adapter.Fill(database);
                  dataGridView1.DataSource = database;
              }
              else
              {
                  MessageBox.Show("Invalid input for Id.");
              }
            
        }
        /// CLEAR/
        private void button5_Click(object sender, EventArgs e)
        {
            textBox111.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
          
        }
        //TEXTBOX1/////////////////////////////
        
       private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PATIENT_TABLE;Integrated Security=True");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PATIENT", con);
            DataTable database = new DataTable();
            adapter.Fill(database);

            dataGridView1.DataSource = database;

            con.Close();
        }
    }
}