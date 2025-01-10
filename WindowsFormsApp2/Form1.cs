using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex]; ;
                textID.Text = row.Cells["id"].Value.ToString();
                textBox1.Text = row.Cells["Column2"].Value.ToString();
                textBox2.Text = row.Cells["Column3"].Value.ToString();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewData();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addData();
        }





        private void viewData (){
            dataGridView1.Rows.Clear();
            string connectionString = "server=localhost\\SQLEXPRESS;database=stores;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connectionString);
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            SqlCommand cmd = new SqlCommand("SELECT * From names", conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 1;
                while (reader.Read())
                {
                        dataGridView1.Rows.Add(reader["name_id"], i, reader["name_fname"], reader["name_lname"], " เลือก ");
                    i++;
                }
            }
            conn.Close();
        }

        private void addData()
        {
            string connectionString = "server=localhost\\SQLEXPRESS;database=stores;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connectionString);
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO names (name_fname,name_lname) VALUES (@fName,@lName)", conn);
            cmd.Parameters.Add("@fName", textBox1.Text);
            cmd.Parameters.Add("@lName", textBox2.Text);
            cmd.ExecuteNonQuery();               
            conn.Close();
            viewData();
        }
        private void editData()
        {
            string connectionString = "server=localhost\\SQLEXPRESS;database=stores;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connectionString);
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            SqlCommand cmd = new SqlCommand("UPDATE names SET name_fname=@fName,name_lname=@lName WHERE name_id= @id", conn);
            cmd.Parameters.Add("@id", textID.Text);
            cmd.Parameters.Add("@fName", textBox1.Text);
            cmd.Parameters.Add("@lName", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            viewData();
        }

        private void delData()
        {
            string connectionString = "server=localhost\\SQLEXPRESS;database=stores;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connectionString);
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            SqlCommand cmd = new SqlCommand("DELETE names WHERE name_id= @id", conn);
            cmd.Parameters.Add("@id", textID.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            viewData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }
    }
}
