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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            panelLogin.Visible = true;
            linkLogin.Visible = true;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = pass.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                var m = new MyCabinet(loginUser,passUser);
                m.Show();
                this.Hide();
            }
            else { MessageBox.Show("False login or password"); }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Visible = false;
            panelSignIn.Visible = true;
            linkLogin.Visible = false;
            linkLabel1.Visible = true;
        }

        private void link2Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSignIn.Visible = false;
            panelLogin.Visible = true;
            linkLabel1.Visible = false;
            linkLogin.Visible = true;
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            String secondname = secnameField.Text;
            String surname = srnameField.Text;
            DateTime bday = bdayDate.Value;
            String loginUser = loginregField.Text;
            String passUser = passregField.Text;
            String Sex = sexField.Text;
            String category = categoryField.Text;

            int type = 0, access = 5;
            if (category == "Sportsman") { type = 2; }
            if (category == "Starter") { type = 3; }

            if (name == "") { MessageBox.Show("Input name"); access--; } 
            if (loginUser == "") { MessageBox.Show("Input login"); access--; } 
            if (passUser == "") { MessageBox.Show("Input password"); access--; }
            if (category == "") { MessageBox.Show("Choose category"); access--; }
            if (isUserExists()) access--;


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `tourists` (`Name`, `SecondName`, `Surname`, `Birthday`, `Type`, `Gender`, `login`, `password`) VALUES (@name,  @secname, @surname, @bday, @type, @sex, @login, @pass)", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@secname", MySqlDbType.VarChar).Value = secondname;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@bday", MySqlDbType.Date).Value = bday;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = Sex;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passUser;

            if (access == 5)
            {
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account created");
                    var m = new MyCabinet(loginUser, passUser);
                    m.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Error. Account doesn't created");

                db.closeConnection();
            }
        }
        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginregField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This login is already exists. Please, enter another login");
                return true;
            }
            else return false;
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
