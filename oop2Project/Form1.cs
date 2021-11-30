using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace oop2Project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        public static string user;
        public static string Cus_Id;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormForgotPass frgt = new FormForgotPass();
            this.Hide();
            frgt.Tag = this;
            frgt.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtusername.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cus where email='" + email + "'";
            /* pass = "select pass from Cus where email='" + txtusername.Text + "'";
             user = "select email from Cus where email='" + txtusername.Text + "'";*/

            /*DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);*/

            //dataGridView1.DataSource = dt;

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows == true)
            {
                cmd.CommandText = ("select * from Cus where email='" + email + "'and pass='" + txtpassword.Text + "' ");
                sdr.Close();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    user = email;
                    Cus_Id = sdr.GetString(2);
                    FormBooking Cus = new FormBooking();
                    this.Hide();
                    Cus.Tag = this;
                    Cus.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Pass");
                }
            }

            else if (email == "admin" && txtpassword.Text == "123")
            {
                FormViewAdmin admin = new FormViewAdmin();
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
            else MessageBox.Show("Invalid Username/Password");
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
            FormReg Reg = new FormReg();
            this.Hide();
            Reg.Tag = this;
            Reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
