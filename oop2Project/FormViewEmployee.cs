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
    public partial class FormViewEmployee : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        public FormViewEmployee()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (employe_pass.Text != "" && employe_confrm_pass.Text != "")
            {
                if (employe_confrm_pass.Text == employe_pass.Text)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "update Emp set pass = '" + employe_confrm_pass.Text + "' where Emp_Id='" + Form1.Emp_Id + "'";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Password Change Successfull");
                    this.employe_pass.Text = "";
                    this.employe_confrm_pass.Text = "";

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
    }
}
