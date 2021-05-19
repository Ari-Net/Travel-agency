using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_Netudykhata
{
    public partial class Schedule : Form
    {
        string login = "";
        string pass = "";
        public Schedule()
        {
            InitializeComponent();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `groupswork` ORDER BY `GroupID`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[3].ToString();
                data[data.Count - 1][2] = read[4].ToString();
                data[data.Count - 1][3] = read[5].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        public Schedule(string login, string pass)
        {
            InitializeComponent();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `groupswork` ORDER BY `GroupID`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[3].ToString();
                data[data.Count - 1][2] = read[4].ToString();
                data[data.Count - 1][3] = read[5].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            button1.Visible = true;
        }
        private void bt_back_Click(object sender, EventArgs e)
        {

        }

        private void bt_cabinet_Click(object sender, EventArgs e)
        {
            var m = new Form1();
            m.Show();
            this.Hide();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
