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

namespace oop2Project
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEMESTER 6\C#\CODE\oop2_1126Project\oop2Project\DATA\Customer.mdf;Integrated Security=True;Connect Timeout=30");
        private string vid;
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void butconfirm_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == textBox6.Text)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Cus set pass = '" + textBox7.Text + "' where email = '" + Form1.user + "'";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password Change Successfull");
                this.textBox6.Text = "";
                this.textBox7.Text = "";

                /*Form1 f1 = new Form1();
                this.Hide();
                f1.Tag = this;
                f1.Show();*/

            }
            else
            {
                MessageBox.Show(" Password MissMatch ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 cus = new Form6();
            this.Hide();
            cus.Tag = this;
            cus.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string query0 = " select  * from Cus where email='" + Form1.user + "'";
            cmd.CommandText = query0;
            SqlDataReader sdr = cmd.ExecuteReader();
            //string id1 = "1000";
            sdr.Read();
            textBox4.Text = sdr.GetString(0);
            textBox3.Text = sdr.GetString(1);
            textBox2.Text = sdr.GetString(3);
            textBox1.Text = sdr.GetString(6);
            vid = textBox5.Text = sdr.GetString(8);
            /* if (sdr.HasRows)
             {
                 sdr.Read();
                 id1 = sdr.GetString(0);

                 Cus_Id = (Convert.ToInt32(id1) + 1).ToString();

             }
             else
             {
                 Cus_Id = id1;
             }*/

            pictureBox1.Image = new Bitmap(sdr.GetString(9));
            sdr.Close();
            /*string query = " Insert into Cus Values('" + Name + "','" + Address + "'," +
                "'" + Cus_Id + "','" + phn + "','" + nid + "','" + pass + "','" + email + "'," +
            "'" + vacc + "','" + vac_id + "','" + newPath + "')";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();*/
            con.Close();
            if (vid == "N/A" || vid == "")
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vid == "N/A" || vid == "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Cus set vac_id = '" + textBox5.Text + "' where email = '" + Form1.user + "'";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Vaccine Information update Successfull");
                button1.Enabled = false;

            }
            /*else
            {
                MessageBox.Show(" Already Updated ");

            }*/

        }
    }
}
