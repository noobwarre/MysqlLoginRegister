using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Login : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public Login()
        {
            //Login incs
            var incs = "user id=;server=;database=;password=";
            //End Login İncs
            //Connection
            con = new MySqlConnection(incs);
            //End Connection
            InitializeComponent();
        }

        private void BunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void BunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        public Point mouseLocation;



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BunifuMetroTextbox1_Click(object sender, EventArgs e)
        {

        }

        private void BunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void BunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox2.isPassword = true;
        }

        private void BunifuThinButton22_Click(object sender, EventArgs e)
        {
            string user = bunifuMetroTextbox1.Text;
            string pass = bunifuMetroTextbox2.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM users where username='" + user + "' AND password='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                System.Threading.Thread.Sleep(100);
                //Logined

                //End Logined
            }
            else
            {
                MessageBox.Show("Enter Right Password.");
            }
            con.Close();
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            Register rr = new Register();
            this.Hide();
            rr.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BunifuThinButton23_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseLocation = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;

            bool flag2 = flag;
            if (flag2)
            {
                this.Left += e.X - this.mouseLocation.X;
                this.Top += e.Y - this.mouseLocation.Y;
            }
        }
    }
}
