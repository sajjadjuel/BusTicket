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
    public partial class FormCusProfile : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        private string vid;
        public FormCusProfile()
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
        {   if (textConfirmPass.Text != "" && textPass.Text!= "")
            {
                if (textConfirmPass.Text == textPass.Text)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "update Cus set pass = '" + textConfirmPass.Text + "' where email = '" + Form1.user + "'";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Password Change Successfull");
                    this.textPass.Text = "";
                    this.textConfirmPass.Text = "";

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

        else
            {
                MessageBox.Show(" please enter Password  ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBooking cus = new FormBooking();
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
            textName.Text = sdr.GetString(0);
            textAddress.Text = sdr.GetString(1);
            textPhone.Text = sdr.GetString(3);
            textEmail.Text = sdr.GetString(6);
            vid = textVac.Text = sdr.GetString(8);
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
                btnUpdate.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vid == "N/A" || vid == "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Cus set vac_id = '" + textVac.Text + "' where email = '" + Form1.user + "'";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Vaccine Information update Successfull");
                btnUpdate.Enabled = false;

            }
            /*else
            {
                MessageBox.Show(" Already Updated ");

            }*/

        }
    }
}
