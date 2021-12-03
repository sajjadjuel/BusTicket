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
    public partial class FormBooking : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        List<string> RouteFrom = new List<string>();
        List<string> RouteTo = new List<string>();

        public FormBooking()
        {
            InitializeComponent();
        }

        private void butbookticket_Click(object sender, EventArgs e)
        {
            // Same Route
            if (comboTo.Text == comboFrom.Text)
            {
                MessageBox.Show("From and To cannot be same.", "Please change route!");
                return;
            }
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            //DPicker.Value = DateTime.Today;
            displayBusData();
            GetRoutes();
            // ComboBox From Items
            int _i = 0;
            while (_i < RouteFrom.Count)
            {
                comboFrom.Items.Add(RouteFrom[_i]);
                _i++;
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProfile CusProfile = new FormProfile();
            this.Hide();
            CusProfile.Tag = this;
            CusProfile.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Tag = this;
            log.Show();
        }

        private void displayBusData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId as [Serial No], BusName as [Bus Name], BusFrom as [From], BusTo as [To], Time, TFormat as [Format] from Bus";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridBusList.DataSource = dt;
            con.Close();
        }

        private void dataGridBusList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string From = comboFrom.Text;
            comboTo.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Distinct BusTo from Bus Where BusFrom = '" + From + "'";
            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                    comboTo.Items.Add(sdr.GetString(0));
            }

            con.Close();

            // Enable To and Time
            comboTo.Enabled = true;
        }

        private void GetRoutes()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Bus";
            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (!RouteFrom.Contains(sdr.GetString(2)))
                        RouteFrom.Add(sdr.GetString(2));
                    else if (!RouteFrom.Contains(sdr.GetString(3)))
                        RouteFrom.Add(sdr.GetString(3));

                    if (!RouteFrom.Contains(sdr.GetString(3)))
                        RouteFrom.Add(sdr.GetString(3));
                }
            }
            con.Close();
        }

        private void comboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string From = comboFrom.Text;
            string To = comboTo.Text;
            comboTime.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Time, TFormat from Bus Where BusFrom='" + From + "' And BusTo ='" + To + "' Order By TFormat";
            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string BusTime = sdr.GetString(0) + " " + sdr.GetString(1);
                    if (!comboTime.Items.Contains(BusTime))
                        comboTime.Items.Add(BusTime);
                }
            }

            con.Close();

            // Enable Time
            comboTime.Enabled = true;
        }

        private void comboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string From = comboFrom.Text;
            string To = comboTo.Text;
            string BusTime = comboTime.Text.Split(' ')[0];
            string TimeFormat = comboTime.Text.Split(' ')[1];

            comboBus.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId, BusName from Bus Where BusFrom='" + From + "' And BusTo='" + To +
                  "' And Time='" + BusTime + "' And TFormat='" + TimeFormat + "'";
            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string BusName = sdr.GetString(1) + "-" + sdr.GetString(0);
                    comboBus.Items.Add(BusName);
                }
            }

            con.Close();

            // Enable Bus
            comboBus.Enabled = true;
        }
    }
}
