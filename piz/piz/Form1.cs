using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace piz
{
    public partial class Form1 : Form
    {

        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void log_in_load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*'; 
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox3.Text != label3.Text)
            {
                MessageBox.Show("Непрвильная капча");
            }
            else
            {

                var loginUser = textBox1.Text;
                var passUser = textBox2.Text;

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                string querystring = $"select id_user, login_user, password_user from register1 where login_user = '{loginUser}' and password_user = '{passUser}'";

                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Успешный вход", "Долби долби!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 frm1 = new Form1();
                    this.Hide();
                    frm1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Нема такого акка!", "повтори", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num = rand.Next(6,8);
            string capcha = "";
            int totl =0;
            do
            {
                int chr = rand.Next(48,123);
                if ((chr>=48 && chr<=57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122));
                {
                    capcha += (char)chr;
                    totl++;
                    if (totl == num)
                        break;
                }
            } while (true);
            label3.Text = capcha;
        }
    }
}
