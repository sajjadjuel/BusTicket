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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Bus_Id;

        }

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            string BusName;
            string Bus_Id;
            string Route;
            string Time;
            string TFormat;

            // No Route
            if (comboRoute.Text == "")
            {
                MessageBox.Show("Please select Route!");
                return;
            }
            // No Time
            if (comboTime.Text == "" ||
                comboFormat.Text == "")
            {
                MessageBox.Show("Please select Time!");
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select Bus_Id from Bus order by Bus_Id desc";

            SqlDataReader sdr = cmd.ExecuteReader();
            string id = "1000";

            if (sdr.HasRows)
            {
                sdr.Read();
                id = sdr.GetString(0);

                Bus_Id = (Convert.ToInt32(id) + 1).ToString();
            }
            else Bus_Id = id;
            sdr.Close();

            BusName = textBusName.Text.Trim(' ').Replace("-", ",");
            Route = comboRoute.Text;
            Time = comboTime.Text;
            TFormat = comboFormat.Text;

            cmd.CommandText = " Insert into Bus Values('" + Bus_Id + "','" + BusName + "'," +
                "'" + Route + "','" + Time + "','" + TFormat + "')";

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(BusName + " has been Added!");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormCusProfile book = new FormCusProfile();
            this.Hide();
            book.Tag = this;
            book.Show();
        }

        private void FormViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void dataGridBusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridBusList.CurrentCell.Value.ToString() == "") return;

            textBusName.Text = dataGridBusList.CurrentRow.Cells[1].Value.ToString();
            textBusSerial.Text = dataGridBusList.CurrentRow.Cells[0].Value.ToString();
            comboRoute.Text = dataGridBusList.CurrentRow.Cells[2].Value.ToString().Replace(",", " - ");
            comboTime.Text = dataGridBusList.CurrentRow.Cells[3].Value.ToString();
            comboFormat.Text = dataGridBusList.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
