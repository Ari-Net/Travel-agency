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
    public partial class Administrator : Form
    {
        string login = "";
        string pass = "";
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder builder = null;
        private DataSet dataSet = null;
        public Administrator()
        {
            InitializeComponent();
        }
        public Administrator(string login, string pass)
        {
            InitializeComponent();

            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();
            adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists`", db.getConnection());
            
            MySqlDataReader read = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (read.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = read[0].ToString();
                data[data.Count - 1][1] = read[3].ToString();
                data[data.Count - 1][2] = read[4].ToString();
                data[data.Count - 1][3] = read[5].ToString();
                data[data.Count - 1][4] = read[7].ToString();
                data[data.Count - 1][5] = read[8].ToString();
            }
            read.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            button1.Visible = true;


            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `competitions` ORDER BY `DateC`", db.getConnection());
            MySqlDataReader read1 = command1.ExecuteReader();
            List<string[]> data1 = new List<string[]>();
            while (read1.Read())
            {
                data1.Add(new string[3]);
                data1[data1.Count - 1][0] = read1[1].ToString();
                data1[data1.Count - 1][1] = read1[2].ToString();
                data1[data1.Count - 1][2] = read1[3].ToString();
            }
            read1.Close();
            foreach (string[] s in data1)
                dgvComp.Rows.Add(s);

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `groupsleaders`", db.getConnection());
            MySqlDataReader read2 = command2.ExecuteReader();
            List<string[]> data2 = new List<string[]>();
            while (read2.Read())
            {
                data2.Add(new string[4]);
                data2[data2.Count - 1][0] = read2[1].ToString();
                data2[data2.Count - 1][1] = read2[2].ToString();
                data2[data2.Count - 1][2] = read2[3].ToString();
                data2[data2.Count - 1][3] = read2[4].ToString();
            }
            read2.Close();
            foreach (string[] s in data2)
                dgvGroupLeaders.Rows.Add(s);

            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `groupparticipant`", db.getConnection());
            MySqlDataReader read3 = command3.ExecuteReader();
            List<string[]> data3 = new List<string[]>();
            while (read3.Read())
            {
                data3.Add(new string[3]);
                data3[data3.Count - 1][0] = read3[0].ToString();
                data3[data3.Count - 1][1] = read3[1].ToString();
                data3[data3.Count - 1][2] = read3[2].ToString();
            }
            read3.Close();
            foreach (string[] s in data3)
                dgvGrPtcp.Rows.Add(s);

            MySqlCommand command4 = new MySqlCommand("SELECT * FROM `groupparticipant`", db.getConnection());
            MySqlDataReader read4 = command4.ExecuteReader();
            List<string[]> data4 = new List<string[]>();
            while (read4.Read())
            {
                data4.Add(new string[3]);
                data4[data4.Count - 1][0] = read4[0].ToString();
                data4[data4.Count - 1][1] = read4[1].ToString();
                data4[data4.Count - 1][2] = read4[2].ToString();
            }
            read4.Close();
            foreach (string[] s in data4)
                dgvCompPtcp.Rows.Add(s);

            db.closeConnection();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_cabinet_Click(object sender, EventArgs e)
        {
            var m = new Form1();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Administrator_Validated(object sender, EventArgs e)
        {

        }

        private void buttonAdm_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dgvComp.Visible = false;
            dgvCompPtcp.Visible = false;
            dgvGroupLeaders.Visible = false;
            dgvGrPtcp.Visible = false;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dgvGroupLeaders.Visible = true;
            dgvGrPtcp.Visible = true;
            dataGridView1.Visible = false;
            dgvComp.Visible = false;
            dgvCompPtcp.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dgvComp.Visible = true;
            dgvCompPtcp.Visible = true;
            dgvGroupLeaders.Visible = false;
            dgvGrPtcp.Visible = false;
        }
    }
}
