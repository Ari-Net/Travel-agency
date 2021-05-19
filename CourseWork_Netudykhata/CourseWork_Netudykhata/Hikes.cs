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
    public partial class Hikes : Form
    {
        string login = "";
        string pass = "";
        public Hikes()
        {
            InitializeComponent();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `journeys` ORDER BY `StartDate`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[2].ToString();
                data[data.Count - 1][2] = read[3].ToString();
                data[data.Count - 1][3] = read[4].ToString();
                data[data.Count - 1][4] = read[5].ToString();
                data[data.Count - 1][5] = read[6].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        public Hikes(string login, string pass)
        {
            InitializeComponent();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `journeys` ORDER BY `StartDate`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[2].ToString();
                data[data.Count - 1][2] = read[3].ToString();
                data[data.Count - 1][3] = read[4].ToString();
                data[data.Count - 1][4] = read[5].ToString();
                data[data.Count - 1][5] = read[6].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
            dataGridView1.Rows.Add(s);
            button1.Visible = true;
        }
        private void Hikes_Load(object sender, EventArgs e)
        {

        }

        private void bt_cabinet_Click(object sender, EventArgs e)
        {
            var m = new Form1();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
