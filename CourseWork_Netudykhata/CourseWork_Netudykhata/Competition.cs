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
    public partial class Competition : Form
    {
        string login = "";
        string pass = "";
        public Competition()
        {
            InitializeComponent();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `competitions` ORDER BY `DateC`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[2].ToString();
                data[data.Count - 1][2] = read[3].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        public Competition(string login, string pass)
        {
            InitializeComponent();
            
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `competitions` ORDER BY `DateC`", db.getConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = read[1].ToString();
                data[data.Count - 1][1] = read[2].ToString();
                data[data.Count - 1][2] = read[3].ToString();
            }
            read.Close();
            db.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            button1.Visible = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Competition_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
