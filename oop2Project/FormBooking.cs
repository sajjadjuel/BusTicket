using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace oop2Project
{
    public partial class FormBooking : Form
    {
        public FormBooking()
        {
            InitializeComponent();
        }

        private void butonprofile_Click(object sender, EventArgs e)
        {

        }

        private void butbookticket_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCusProfile book = new FormCusProfile();
            this.Hide();
            book.Tag = this;
            book.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            DPicker.Value = DateTime.Today;
        }
    }
}
