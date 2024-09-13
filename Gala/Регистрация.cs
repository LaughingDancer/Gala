using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Gala.Classes;
using static Gala.Classes.ValidForm;

namespace Gala
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }
        private void Регистрация_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            this.BackColor = Color.FromArgb(229, 227, 228);
            guna2TextBox5.UseSystemPasswordChar = true;
            guna2TextBox6.UseSystemPasswordChar = true;
            guna2Button1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Регистрация.ActiveForm.Hide();
            Авторизация toRegistration = new Авторизация();
            toRegistration.ShowDialog();
            Close();
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                guna2TextBox5.UseSystemPasswordChar = false;
                guna2TextBox6.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox5.UseSystemPasswordChar = true;
                guna2TextBox6.UseSystemPasswordChar = true;
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == string.Empty || guna2TextBox2.Text == string.Empty
                || guna2TextBox3.Text == string.Empty
                || guna2TextBox4.Text == string.Empty || guna2TextBox5.Text == string.Empty
                || guna2TextBox6.Text == string.Empty || guna2TextBox7.Text == string.Empty
                || guna2TextBox8.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            Validation validator = new Validation();
            string lastName = guna2TextBox1.Text;
            string firstName = guna2TextBox2.Text;
            string middleName = guna2TextBox3.Text;
            string email = guna2TextBox7.Text;
            string inn = guna2TextBox8.Text;
            if (!validator.ValidateLastName(lastName))
            {
                MessageBox.Show("Некорректная фамилия", "Ошибка");
                return;
            }
            if (!validator.ValidateFirstName(firstName))
            {
                MessageBox.Show("Некорректное имя", "Ошибка");
                return;
            }
            if (!validator.ValidateMiddleName(middleName))
            {
                MessageBox.Show("Некорректное отчество", "Ошибка");
                return;
            }
            if (!validator.ValidateEmail(email))
            {
                MessageBox.Show("Некорректный email", "Ошибка");
                return;
            }
            if (!validator.ValidateINN(inn))
            {
                MessageBox.Show("Некорректный ИНН", "Ошибка");
                return;
            }
            if (guna2TextBox5.Text != guna2TextBox6.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка");
                return;
            }
            PassValidation PassV = new PassValidation();
            if (PassV.Validation(guna2TextBox5.Text) == false)
            {
                return;
            }
            if (guna2TextBox5.Text == guna2TextBox4.Text)
            {
                MessageBox.Show("Пароль и логин не должны совпадать.", "Ошибка");
                return;
            }
            ValidationLogin LV = new ValidationLogin();
            if (LV.Validation(guna2TextBox4.Text) == false)
            {
                return;
            }
            else
            {
                RegisterClient(guna2TextBox1.Text, guna2TextBox2.Text,
                    guna2TextBox3.Text, guna2TextBox7.Text, guna2TextBox8.Text);
                int clientId = GetClientId(guna2TextBox1.Text, guna2TextBox2.Text,
                    guna2TextBox3.Text, guna2TextBox7.Text, guna2TextBox8.Text);
                RegisterUser(guna2TextBox4.Text, guna2TextBox5.Text);
                Регистрация.ActiveForm.Hide();
                Авторизация toRegistration = new Авторизация();
                toRegistration.ShowDialog();
                Close();
            }
        }
        private void RegisterClient(string lastName, string firstName, string middleName, string email, string INN)
        {
            string query = $"INSERT INTO Клиент (Фамилия, Имя, Отчество, Электронная_почта, ИНН)" +
                $" VALUES ('{lastName}', '{firstName}', '{middleName}', '{email}', '{INN}')";
            var dbquery = new DB2();
            dbquery.queryExecute(query);
        }

        private int GetClientId(string lastName, string firstName, string middleName, string email, string INN)
        {
            int clientId = -1;
            string query = $"SELECT Код_клиента FROM Клиент WHERE Фамилия = '{lastName}' AND" +
                $" Имя = '{firstName}' AND Отчество = '{middleName}' AND Электронная_почта = '{email}' AND ИНН = '{INN}'";
            var dbquery = new DB2();
            using (SqlConnection con = new SqlConnection(dbquery.StringCon()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    clientId = (int)command.ExecuteScalar();
                }
            }
            return clientId;
        }
        private void RegisterUser(string login, string password)
        {
            Hashing GH = new Hashing();
            string query = $"INSERT INTO Пользователи (Логин, Пароль) VALUES ('{login}', '{GH.Hash(password)}')";
            var dbquery = new DB();
            dbquery.queryExecute(query);
        }
        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!guna2CheckBox2.Checked)
            {
                guna2Button1.Enabled = false;
            }
            else
            {
                guna2Button1.Enabled = true;
            }
        }
    }
}
