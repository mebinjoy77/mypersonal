using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace Mypersonal
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection cnn = new SqlConnection(@"Data Source=(local);Initial Catalog=codex1.0;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connetionString;
            connetionString = "Data Source=.;Initial Catalog=codex1.0;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Table007", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connetionString;
            string sql;

            connetionString = "Data Source=.;Initial Catalog=codex1.0;Integrated Security=True";


            sql = "insert into Table007 ([Id],[Name],[Address],[Phone Number],[Unit],[Payment],[Amount])VALUES(@id,@name,@address,@phonenumber,@unit,@payment,@amount)";


            using (SqlConnection cnn = new SqlConnection(connetionString))
            {



                cnn.Open();


                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox6.Text;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@phonenumber", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@payment", SqlDbType.NVarChar).Value = comboBox3.Text;
                    cmd.Parameters.Add("@amount", SqlDbType.Int).Value = textBox4.Text;
            

                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Sucessfull !!!");
                    else

                        MessageBox.Show("Insertion Failed !!!");

                }


                SqlDataAdapter sda = new SqlDataAdapter("select * from Table007", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            textBox6.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Clear();
            comboBox3.ResetText();
            comboBox1.ResetText();
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox6.Text = selectedRow.Cells[0].Value.ToString();
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            comboBox1.Text = selectedRow.Cells[3].Value.ToString();
            textBox3.Text = selectedRow.Cells[4].Value.ToString();
            comboBox3.Text = selectedRow.Cells[5].Value.ToString();
            textBox4.Text = selectedRow.Cells[6].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString;
            connetionString = "Data Source=.;Initial Catalog=codex1.0;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Table007", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int A, B = 0;
            for (A = 0; A < dataGridView1.Rows.Count; ++A)
            {
                B += Convert.ToInt32(dataGridView1.Rows[A].Cells[6].Value);
            }
            label5.Text = B.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string connetionString;
            string sql;

            connetionString = "Data Source=.;Initial Catalog=codex1.0;Integrated Security=True";


            sql = "delete from Table007 where Id = '" + this.textBox6.Text + "'";


            using (SqlConnection cnn = new SqlConnection(connetionString))
            {



                cnn.Open();


                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox6.Text;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@phonenumber", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@payment", SqlDbType.NVarChar).Value = comboBox3.Text;
                    cmd.Parameters.Add("@amount", SqlDbType.Int).Value = textBox4.Text;
                    int rowsdelete = cmd.ExecuteNonQuery();
                    if (rowsdelete > -1)

                        MessageBox.Show(" Deleted Sucessfull !!!");
                    else

                        MessageBox.Show("Deletion Failed !!!");

                }


                SqlDataAdapter sda = new SqlDataAdapter("select * from Table007", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            textBox6.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Clear();
            comboBox3.ResetText();
            comboBox1.ResetText();
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString;
            string sql;

            connetionString = "Data Source=.;Initial Catalog=codex1.0;Integrated Security=True";


            sql = "Update Table007 set Amount = Amount + '"+textBox7.Text+"'  where Id = '" + textBox6.Text + "'";


            using (SqlConnection cnn = new SqlConnection(connetionString))
            {



                cnn.Open();


                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox6.Text;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@phonenumber", SqlDbType.NVarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@payment", SqlDbType.NVarChar).Value = comboBox3.Text;
                    cmd.Parameters.Add("@amount", SqlDbType.Int).Value = textBox4.Text;
                    cmd.Parameters.Add("@amountpaid", SqlDbType.Int).Value = textBox7.Text;

                    int rowupdated = cmd.ExecuteNonQuery();
                    if (rowupdated > -1)
                        MessageBox.Show(" Update Sucessfull !!!");
                    else
                        MessageBox.Show(" Update Failed !!!");
                }


                SqlDataAdapter sda = new SqlDataAdapter("select * from Table007", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            textBox6.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Clear();
            comboBox3.ResetText();
            comboBox1.ResetText();
            textBox7.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table007 where Name = '"+textBox5.Text+ "' OR Address = '" + textBox5.Text + "'OR Payment  = '" + textBox5.Text + "'OR Unit  = '" + textBox5.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox5.Clear();
            cnn.Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
     
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
    }
}
