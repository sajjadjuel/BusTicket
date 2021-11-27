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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
namespace oop2Project
{
    public partial class Form2 : Form
    {

        string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SEMESTER 6\C#\CODE\oop2_1126Project\oop2Project\DATA\Customer.mdf;Integrated Security=True;Connect Timeout=30");

        private string Name;
        private string Address;
        private string Cus_Id;
        private string phn;
        private string nid;
        private string pass;
        private string cpass;
        private string email;
        private string vacc = "";
        private string OTP;
        private int otp;
        private string filePath;
        private OpenFileDialog openFileDialog;
        private string fileExtension;
        private string newPath;

        private string vac_id = "N/A";
        public Form2()
        {
            InitializeComponent();
        }

        private void Send_OTP(string email)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("busticket.booking01@gmail.com");
                msg.To.Add(email);
                msg.Subject = "C# Project Verification Code";
                Random rand = new Random();
                otp = rand.Next(1000, 9999);
                msg.Body = otp.ToString();

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "busticket.booking01@gmail.com";
                ntcd.Password = "Project001";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void Seq()
        {

        }

        private void btnsubmit1_Click(object sender, EventArgs e)
        {

            Name = textBox1.Text;
            Address = textBox2.Text;
            // Cus_Id;
            // Cus_Id = "14";
            phn = textBox3.Text;
            nid = textBox4.Text;
            pass = textBox5.Text;
            cpass = textBox6.Text;
            email = textBox7.Text;
            OTP = textBox8.Text;
            //vacc = textBox1.Text;
            vac_id = textBox9.Text ?? "N/A";
            //pictureBox1.Image = new Bitmap(filePath);
            //if (check(Name, Address, Cus_Id, phn, nid, pass, cpass, OTP, email, vacc))
            // MessageBox.Show("Please Fill");

            try
            {
                newPath = Path.Combine(Environment.CurrentDirectory, @"Images\Customer\" + Cus_Id + Path.GetExtension(filePath));
                File.Copy(filePath, newPath, true);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            if (otp.ToString() == OTP)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string query0 = " select  Cus_Id from Cus order by Cus_Id desc";

                cmd.CommandText = query0;
                SqlDataReader sdr = cmd.ExecuteReader();
                string id1 = "1000";
                if (sdr.HasRows)
                {
                    sdr.Read();
                    id1 = sdr.GetString(0);

                    Cus_Id = (Convert.ToInt32(id1) + 1).ToString();

                }
                else
                {
                    Cus_Id = id1;
                }

                sdr.Close();
                string query = " Insert into Cus Values('" + Name + "','" + Address + "'," +
                    "'" + Cus_Id + "','" + phn + "','" + nid + "','" + pass + "','" + email + "'," +
                "'" + vacc + "','" + vac_id + "','" + newPath + "')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                /*
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtb11 = new DataTable();
                sda.Fill(dtb11);*/


                MessageBox.Show("Registration Successfull");
                Form1 log = new Form1();
                this.Hide();
                log.Tag = this;
                log.Show();
            }
            else
            {
                MessageBox.Show("Wrong OTP");
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }
        public static bool check(params string[] s)
        {
            foreach (string i in s)
            {
                if (i == null || i == String.Empty)
                    return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            vacc = "Yes";
            button1.BackColor = Color.Blue;
            textBox9.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vacc = "No";
            button2.BackColor = Color.Blue;
            textBox9.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Enabled = true;
            button5.Enabled = false;
            email = textBox7.Text;
            Send_OTP(email);
        }



        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "name cannt be empty");
            }


            else
            {
                errorProvider1.Clear();
            }
            foreach (char c in textBox1.Text)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    textBox1.Focus();
                    errorProvider1.SetError(this.textBox1, "Digit  cannt be Name");
                    break;
                }
                else
                {
                    errorProvider1.Clear();

                }
            }
        }



        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "address can't be empty");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "phone can'nt be empty");
            }
            else
            {
                errorProvider3.Clear();
            }
            foreach (char c in textBox3.Text)
            {
                if (!char.IsDigit(c) || c == '.')
                {
                    textBox3.Focus();
                    errorProvider3.SetError(this.textBox3, "phone  cannt be Alphabate");
                    break;
                }
                else
                {
                    errorProvider3.Clear();

                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, " NID can'nt be empty");
            }
            else
            {

                foreach (char c in textBox4.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        textBox4.Focus();
                        errorProvider4.SetError(this.textBox4, " Only Numeric digit !!!");
                        return;
                    }


                }
                errorProvider4.Clear();
            }

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "password can'nt be empty");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Confirm password can'nt be empty");
            }
            else if (this.textBox6.Text != textBox5.Text)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Password MisMatch");
            }
            else
            {
                errorProvider6.Clear();
                //errorProvider9.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Email can'nt be empty");
            }
            else if (Regex.IsMatch(textBox7.Text, pattern) == false)
            {
                textBox7.Focus();
                errorProvider1.SetError(this.textBox7, "Invalid Format");
            }
            else
            {
                errorProvider7.Clear();
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox8.Text) == true)
            {
                textBox8.Focus();
                errorProvider8.SetError(this.textBox8, " verrification can'nt be empty");

            }
            else if (textBox8.Text != otp.ToString())
            {
                textBox8.Focus();
                errorProvider8.SetError(this.textBox8, " Wrong OTP!");
            }
            else
            {
                btnsubmit1.Enabled = true;
                errorProvider8.Clear();

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files|*.jpg;*.jpeg;*.png";
            openFileDialog.ValidateNames = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                this.fileExtension = Path.GetExtension(filePath); //Get the file extension
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
