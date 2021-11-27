﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.IO;

namespace oop2Project
{
   
    public partial class FormViewAdmin : Form
    {
        private string email;
        private int otp;
        private string OTP;
        private string pass;
        private string filePath;
        private OpenFileDialog openFileDialog;
        private string fileExtension;
        private string newPath;

        SqlConnection con = new SqlConnection(ConString.con);

        string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        

        public FormViewAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReg Reg = new FormReg();
            this.Hide();
            Reg.Tag = this;
            Reg.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }


        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFilter.SelectedIndex == 0)
            {

            }
            else if (comboFilter.SelectedIndex == 1)
            {

            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textemail.Text) == true)
            {
                textemail.Focus();
                errorProvider1.SetError(this.textemail, "Email can'nt be empty");
            }
            else if (Regex.IsMatch(textBox7.Text, pattern) == false)
            {
                textemail.Focus();
                errorProvider1.SetError(this.textemail, "Invalid Format");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textpass.Text) == true)
            {
                textpass.Focus();
                errorProvider2.SetError(this.textpass, "Password can'nt be empty");
            }
            
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textotp.Text) == true)
            {
                textotp.Focus();
                errorProvider3.SetError(this.textotp, " OTP can'nt be empty");

            }
            else if (textotp.Text != otp.ToString())
            {
                textotp.Focus();
                errorProvider3.SetError(this.textotp, " Wrong OTP!");
            }
            else
            {
                //btnsubmit1.Enabled = true;
                errorProvider3.Clear();

            }
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
        private void button2_Click(object sender, EventArgs e)
        {
            email = textemail.Text;
            Send_OTP(email);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string role;
          //  RadioButton rb = panelSignup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (radioButton2.Checked)
            {
                role = "Customer";
            }
            else if(radioButton1.Checked)
            {
                role = "Employee";
            }
            else
            {
                MessageBox.Show("select user ");
                return;
            }

            pass = textpass.Text;
            
            email = textemail.Text;
            OTP = textotp.Text;

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

                try
                {
                    newPath = Path.Combine(Environment.CurrentDirectory, @"Images\Customer\" + Cus_Id + Path.GetExtension(filePath));
                    File.Copy(filePath, newPath, true);
                }
                catch (Exception exc)
                {
                    con.Close();
                    Console.WriteLine(exc);
                    MessageBox.Show("Please upload an image!");
                    return;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
}
