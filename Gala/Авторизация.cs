using Gala.Classes;
using Guna.UI2.WinForms;
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

namespace Gala
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            this.BackColor = Color.FromArgb(229, 227, 228);

            guna2TextBox2.UseSystemPasswordChar = true;
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
            Авторизация.ActiveForm.Hide();
            Регистрация toRegistration = new Регистрация();
            toRegistration.ShowDialog();
            Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var login = guna2TextBox1.Text;
            var password = guna2TextBox2.Text;
            int roleId = GetRoleId(login, password);
            if (login == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            if (AuthorizeUser(login, password))
            {
                if (roleId == 1)
                {
                    Авторизация.ActiveForm.Hide();
                    ГлавнаяАдмин toRegistration = new ГлавнаяАдмин();
                    toRegistration.ShowDialog();
                    Close();
                }
                if (roleId == 2)
                {
                    Авторизация.ActiveForm.Hide();
                    ГлавнаяМенеджер toRegistration = new ГлавнаяМенеджер();
                    toRegistration.ShowDialog();
                    Close();
                }
                if (roleId == 3)
                {
                    Авторизация.ActiveForm.Hide();
                    ГлавнаяПоставщик toRegistration = new ГлавнаяПоставщик();
                    toRegistration.ShowDialog();
                    Close();
                }
                if (roleId == 4)
                {
                    Авторизация.ActiveForm.Hide();
                    ГлавнаяКлиент toRegistration = new ГлавнаяКлиент();
                    toRegistration.ShowDialog();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка");
            }
        }
        private bool AuthorizeUser(string login, string password)
        {
            bool isAuthorized = false;
            var dbQeury = new DB();
            var getHash = new Hashing();
            using (SqlConnection con = new SqlConnection(dbQeury.StringCon()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM Пользователи" +
                    $" WHERE Логин ='{login}' and Пароль = '{getHash.Hash(password)}'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["Пароль"].ToString() == getHash.Hash(password) &&
                                reader["Логин"].ToString() == login)
                            {
                                isAuthorized = true;
                                MessageBox.Show("Вход успешно выполнен!", "Успех");
                            }
                        }
                    }
                }
            }
            return isAuthorized;
        }
        private int GetRoleId(string login, string password)
        {
            int roleId = -1;
            var dbQeury = new DB();
            var getHash = new Hashing();
            using (SqlConnection con = new SqlConnection(dbQeury.StringCon()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand($"SELECT Код_роли FROM Пользователи" +
                    $" WHERE Логин ='{login}' and Пароль = '{getHash.Hash(password)}'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            roleId = Convert.ToInt32(reader["Код_роли"]);
                        }
                    }
                }
            }
            return roleId;
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Авторизация.ActiveForm.Hide();
            ГлавнаяМенеджер toRegistration = new ГлавнаяМенеджер();
            toRegistration.ShowDialog();
            Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Авторизация.ActiveForm.Hide();
            ГлавнаяПоставщик toRegistration = new ГлавнаяПоставщик();
            toRegistration.ShowDialog();
            Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Авторизация.ActiveForm.Hide();
            ГлавнаяАдмин toRegistration = new ГлавнаяАдмин();
            toRegistration.ShowDialog();
            Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Авторизация.ActiveForm.Hide();
            ГлавнаяКлиент toRegistration = new ГлавнаяКлиент();
            toRegistration.ShowDialog();
            Close();
        }
    }
}