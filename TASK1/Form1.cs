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

namespace TASK1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        SqlConnection c = new SqlConnection(@" data source=(localdb)\v11.0; initial catalog=master; integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("insert into accord2 values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')",c);
            c.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("data stored");
            c.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            SqlDataAdapter sda = new SqlDataAdapter
            ("select  id,name,age, course,price,date1 from accord2", c);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand("delete from accord2 where name='" + textBox1.Text + "'", c);
            cmd.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("data deleted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand("update accord2 set age='" + textBox2.Text + "',  course='" + textBox3.Text + "',price='" + textBox4.Text + "',date1='" + textBox5.Text + "'  where name='" + textBox1.Text + "'", c);
             cmd.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("data updated");
        }
    }
}
