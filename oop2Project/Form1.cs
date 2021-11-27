//Hello from safin
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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        private string pass;
        public static string user;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            Form7 frgt = new Form7();
            this.Hide();
            frgt.Tag = this;
            frgt.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cus where email='" + txtusername.Text + "'";
            /* pass = "select pass from Cus where email='" + txtusername.Text + "'";
             user = "select email from Cus where email='" + txtusername.Text + "'";*/

            /*DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);*/

            //dataGridView1.DataSource = dt;

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows == true)
            {
                cmd.CommandText = ("select * from Cus where email='" + txtusername.Text + "'and pass='" + txtpassword.Text + "' ");
                sdr.Close();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    user = txtusername.Text;
                    Form6 Cus = new Form6();
                    this.Hide();
                    Cus.Tag = this;
                    Cus.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Pass");
                }
            }

            else if (txtusername.Text == "admin" && txtpassword.Text == "123")
            {
                Form3 admin = new Form3();
                this.Hide();
                admin.Tag = this;
                admin.Show();
            }
            /* else if (txtusername.Text == "emp" && txtpassword.Text == "456")
             {
                 Form4 Emp = new Form4();
                 this.Hide();
                 Emp.Tag = this;
                 Emp.Show();
             }/
            else if (txtusername.Text == user && txtpassword.Text == pass)
            {
                Form6 Cus = new Form6();
                this.Hide();
                Cus.Tag = this;
                Cus.Show();
            }*/
            else
                MessageBox.Show("Invalid Username/Password");
            con.Close();
        }

        private void btnlogin_MouseEnter(object sender, EventArgs e)
        {
            btnlogin.BackColor = Color.GreenYellow;
        }

        private void btnlogin_MouseLeave(object sender, EventArgs e)
        {
            btnlogin.BackColor = SystemColors.ActiveCaption;
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            Form2 Reg = new Form2();
            this.Hide();
            Reg.Tag = this;
            Reg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
