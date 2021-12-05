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
        List<string> SeatNames = new List<string>();
        string From { set; get; }
        string To { set; get; }
        string Time { set; get; }
        int fare = 0;

        public FormBooking()
        {
            InitializeComponent();
            panelSeat.BackColor = Color.FromArgb(90, Color.AntiqueWhite);
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            DateTimePicker.Value = DateTime.Today;
            displayBusData();
            GetRoutes();
            // ComboBoxFrom Items
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
            From = comboFrom.Text;
            comboTo.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Distinct BusTo from Bus Where BusFrom = '" + From + "'";

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

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (!RouteFrom.Contains(sdr.GetString(2)))
                        RouteFrom.Add(sdr.GetString(2));
                }
            }
            con.Close();
        }

        private void comboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            From = comboFrom.Text;
            To = comboTo.Text;
            comboTime.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Time, TFormat from Bus Where BusFrom='" + From + "' And BusTo ='" + To + "' Order By TFormat";

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
            DateTimePicker.Enabled = true;
        }

        private void comboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            From = comboFrom.Text;
            To = comboTo.Text;
            Time = comboTime.Text.Split(' ')[0];
            string TimeFormat = comboTime.Text.Split(' ')[1];

            comboBus.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select BusId, BusName from Bus Where BusFrom='" + From + "' And BusTo='" + To +
                  "' And Time='" + Time + "' And TFormat='" + TimeFormat + "'";

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
            comboBus.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String SeatNo = btn.Text;

            if (btn.BackColor != Color.Green)
            {
                btn.BackColor = Color.Green;
                SeatNames.Add(SeatNo);
            }
            else
            {
                btn.BackColor = Color.Transparent;
                if (SeatNames.Contains(SeatNo))
                    SeatNames.Remove(SeatNo);
            }

            UpdateCost();
        }

        private void comboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BusId = comboBus.Text.Split('-')[1];
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Fare From Bus Where BusId= '" + BusId + "'";

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            fare = Convert.ToInt32(sdr.GetString(0));


            textCost.Text = "0";
            if (labelSelectBus.Visible)
                labelSelectBus.Visible = false;

            foreach (Button b in panelSeat.Controls.OfType<Button>())
            {
                if (b.Text != "Driver" && b.Text != "Door" && !b.Enabled)
                    b.Enabled = true;
                if (!b.Visible)
                    b.Visible = true;
            }
        }

        private void UpdateCost()
        {
            textCost.Text = (fare * SeatNames.Count).ToString();
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            // Same Route
            if (comboTo.Text == comboFrom.Text)
            {
                MessageBox.Show("Please change route!");
                return;
            }
            DateTime Date = DateTimePicker.Value;


        }
    }
}
