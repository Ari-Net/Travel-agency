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
    public partial class MyCabinet : Form
    {
        string login = "";
        string pass = "";
        public MyCabinet()
        {
            InitializeComponent();
        }
        public MyCabinet(string login, string pass)
        {
            InitializeComponent();
            this.login = login;
            this.pass = pass;
            if (CheckAdmin()) { buttonAdm.Visible = true; }

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists` WHERE `login`=@login", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConnection();
            if (table.Rows.Count > 0)
            {
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    labelHello.Text = (read["Name"].ToString());
                    nameField.Text = (read["Name"].ToString());
                    secnameField.Text = (read["SecondName"].ToString());
                    srnameField.Text = (read["Surname"].ToString());
                    bdayDate.Text = (read["Birthday"].ToString());
                    loginregField.Text = login;
                    passregField.Text = pass;
                    if (read["Gender"].ToString() == "M")
                    {
                        sexField.SelectedIndex = 0;
                    }
                    else sexField.SelectedIndex = 1;
                    if (read["Type"].ToString() == "3")
                    {
                        categoryField.SelectedIndex = 0;
                    }
                    if (read["Type"].ToString() == "2")
                    {
                        categoryField.SelectedIndex = 1;
                    }
                    if (read["Type"].ToString() == "1")
                    {
                        categoryField.Visible = false;
                        adminbox.Visible = true;
                        adminbox.SelectedIndex = 2;
                    }
                    string photo = read["photopath"].ToString();
                    if (photo != "")
                    {
                        pictureBox1.Image = Image.FromFile(photo);
                    }
                    else pictureBox1.Image = Image.FromFile("avatar.jpg");
                }
                read.Close();
            }
            else MessageBox.Show("Oops.. Something went wrong");
            db.closeConnection();




        }
        string id = "";
        private string GetID()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists` WHERE `login`=@login", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConnection();
            if (table.Rows.Count > 0)
            {
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    id = (read["ID"].ToString());
                }
                read.Close();
                return id;
            }
            db.closeConnection();
            return MessageBox.Show("Oops.. Something went wrong").ToString();
        }
        private void bt_cabinet_Click(object sender, EventArgs e)
        {
            var m = new Form1();
            m.Show();
            this.Hide();
        }
        string admType = "";
        private Boolean CheckAdmin()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tourists` WHERE `login`=@login", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                admType = (read["Type"].ToString());
            }
            read.Close();
            db.closeConnection();
            if (admType == "3")
            { return true; }
            else return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MyCabinet_Load(object sender, EventArgs e)
        {

        }

        private void labelHello_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //edit info button
        {
            paneleEdit.Visible = true;
            linkLabelUpload.Visible = true;
            buttonCompt.Visible = false;
            buttonSched.Visible = false;
            buttonHike.Visible = false;
            buttonAdm.Visible = false;
        }
        
        public void FillInfo()
        {
           
        }

        private void button6_Click(object sender, EventArgs e) //save button
        {
            String name = nameField.Text;
            String secondname = secnameField.Text;
            String surname = srnameField.Text;
            DateTime bday = bdayDate.Value;
            String loginUser = loginregField.Text;
            String passUser = passregField.Text;
            String Sex = sexField.Text;
            String category = categoryField.Text;
            int type = 3;
            if (category == "Sportsman") { type = 2; }
            if (category == "Starter") { type = 3; }


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE `tourists` SET `Name`=@name, `SecondName`=@secname, `Surname`=@surname, `Birthday`=@bday, `Type`=@type, `Gender`=@sex, `login`=@login, `password`=@pass WHERE ID=@id", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@secname", MySqlDbType.VarChar).Value = secondname;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@bday", MySqlDbType.Date).Value = bday;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = Sex;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passUser;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = GetID();
            
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data successfully changed");
            }
            else MessageBox.Show("Oops, something went wrong. Please, try again");
            
            db.closeConnection();
            paneleEdit.Visible = false;
            linkLabelUpload.Visible = false;
            buttonCompt.Visible = true;
            buttonSched.Visible = true;
            buttonHike.Visible = true;
            if (CheckAdmin()) { buttonAdm.Visible = true; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //upload image click
        {
            panelImage.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //Ok button (for image upload)
        {
            label2.Visible = true;
            imageName.Visible = true;
            string imageUpload = imageName.Text;
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE `tourists` SET `photopath`=@photo WHERE `tourists`.`login`=@login", db.getConnection());
            command.Parameters.Add("@photo", MySqlDbType.VarChar).Value = imageUpload;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Image successfully changed");
            }
            else MessageBox.Show("Oops, something went wrong. Please, try again");

            db.closeConnection();
            if (imageUpload != "")
            {
                pictureBox1.Image = Image.FromFile(imageUpload);
            }
            else pictureBox1.Image = Image.FromFile("avatar.jpg");
            panelImage.Visible = false;
        }

        private void buttonCompt_Click(object sender, EventArgs e)
        {
            var m = new Competition(login,pass);
            m.Show();
        }

        private void buttonSched_Click(object sender, EventArgs e)
        {
            var m = new Schedule(login, pass);
            m.Show();
        }

        private void buttonHike_Click(object sender, EventArgs e)
        {
            var m = new Hikes(login, pass);
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m = new Administrator(login, pass);
            m.Show();
        }
    }
}
