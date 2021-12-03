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
    public partial class FormEmployeeView : Form
    {
        SqlConnection con = new SqlConnection(ConString.con);
        private string BusId = "";
        List<string> Route = new List<string>() { "Dhaka", "Coxs Bazar", "Sylhet", "Barisal", "Rajshashi" };

        public FormEmployeeView()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Tag = this;
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProfile EmpProfile = new FormProfile();
            this.Hide();
            EmpProfile.Tag = this;
            EmpProfile.Show();
        }

        private void FormViewEmployee_Load(object sender, EventArgs e)
        {
            displayBusData();
            // ComboBox From-To Items
            int _i = 0;
            while (_i < Route.Count)
            {
                comboTo.Items.Add(Route[_i]);
                comboFrom.Items.Add(Route[_i]);
                _i++;
            }
        }

        private void dataGridBusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridBusList.CurrentCell.Value.ToString() == "") return;

            textBusName.Text = dataGridBusList.CurrentRow.Cells[1].Value.ToString();
            BusId = textBusSerial.Text = dataGridBusList.CurrentRow.Cells[0].Value.ToString();
            comboFrom.Text = dataGridBusList.CurrentRow.Cells[2].Value.ToString().Replace(",", " - ");
            comboTo.Text = dataGridBusList.CurrentRow.Cells[3].Value.ToString().Replace(",", " - ");
            comboTime.Text = dataGridBusList.CurrentRow.Cells[4].Value.ToString();
            comboFormat.Text = dataGridBusList.CurrentRow.Cells[5].Value.ToString();
            ShowSerial();
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

        private void btnAddBus_Click_1(object sender, EventArgs e)
        {
            string id = "1000";
            string BusName;
            string From;
            string To;
            string Time;
            string TFormat;

            // No Route
            if (comboFrom.Text == "" || comboTo.Text == "")
            {
                MessageBox.Show("Please select Startin!");
                return;
            }
            // Same Route
            if (comboTo.Text == comboFrom.Text)
            {
                MessageBox.Show("From and To cannot be same.", "Please change route!");
                return;
            }
            // No Time
            if (comboTime.Text == "" || comboFormat.Text == "")
            {
                MessageBox.Show("Please select Time!");
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select BusId from Bus order by BusId desc";

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                id = sdr.GetString(0);

                BusId = (Convert.ToInt32(id) + 1).ToString();
            }
            else BusId = id;
            sdr.Close();

            BusName = textBusName.Text;
            From = comboFrom.Text;
            To = comboTo.Text;
            Time = comboTime.Text;
            TFormat = comboFormat.Text;

            cmd.CommandText = " Insert into Bus Values('" + BusId + "','" + BusName + "','" +
                From + "','" + To + "','" + Time + "','" + TFormat + "')";

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(BusName + " has been Added!");
            displayBusData();
            textBusName.Text = textBusSerial.Text = comboFrom.Text = comboTo.Text = comboTime.Text = comboFormat.Text = BusId = null;
            HideSerial();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // No Bus_Id
            if (BusId == "")
            {
                MessageBox.Show("Please Click on the bus from below table.", "Bus Serial is not selected!");
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Bus where BusId = '" + BusId + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Bus-" + BusId + " has been Deleted!");
            displayBusData();
            textBusName.Text = textBusSerial.Text = comboFrom.Text = comboTo.Text = comboTime.Text = comboFormat.Text = BusId = null;
            HideSerial();
        }

        private void HideSerial()
        {
            textBusSerial.Visible = false;
            labelSerial.Visible = false;
        }
        private void ShowSerial()
        {
            textBusSerial.Visible = true;
            labelSerial.Visible = true;
        }
    }
}
