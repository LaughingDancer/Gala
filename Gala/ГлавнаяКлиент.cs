using Gala.Клиент;
using Gala.Таблицы;
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
    public partial class ГлавнаяКлиент : Form
    {
        public ГлавнаяКлиент()
        {
            InitializeComponent();
            UC_Главная uc = new UC_Главная();
            addUserControl(uc);
        }
        public void Alert(string msg)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg);
        }
        private void addUserControl(UserControl userControl)
        {
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        string connectionString = "Data Source=MAKSIMN;" +
            "Initial Catalog=НестеровКурсовая;Integrated Security=True";
        private void CheckOrderStatus()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Заказ.Статус_заказа FROM Заказ JOIN Договор ON" +
                        " Заказ.Код_заказа = Договор.Код_заказа WHERE Договор.Код_клиента = 6 AND" +
                        " Заказ.Статус_заказа = 'выполнен'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                this.Alert("Ваш заказ выполнен!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
        private void ГлавнаяКлиент_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            panelContainer.BackColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(229, 227, 228);
            CheckOrderStatus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Главная uc = new UC_Главная();
            addUserControl(uc);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_ЛичныеДанные uc = new UC_ЛичныеДанные();
            addUserControl(uc);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ГлавнаяКлиент.ActiveForm.Hide();
            Авторизация toRegistration = new Авторизация();
            toRegistration.ShowDialog();
            Close();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_ЗаказыКлиента uc = new UC_ЗаказыКлиента();
            addUserControl(uc);
        }
    }
}
