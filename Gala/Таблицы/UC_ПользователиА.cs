using Gala.Classes;
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

namespace Gala.Таблицы
{
    public partial class UC_ПользователиА : UserControl
    {
        private DB db;
        int selectedRow;
        private bool firstDropDown = true;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;Initial " +
            "Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_ПользователиА()
        {
            db = new DB();
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
        }
        private void UC_ПользовательА_Load(object sender, EventArgs e)
        {
            this.пользователиTableAdapter.Fill(this.нестеровКурсоваяDataSet.Пользователи);
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT * FROM Пользователи";
                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[selectedRow];
                guna2TextBox2.Text = row.Cells[1].Value.ToString();
                guna2TextBox3.Text = row.Cells[2].Value.ToString();
                guna2TextBox4.Text = row.Cells[3].Value.ToString();
                guna2TextBox5.Text = row.Cells[0].Value.ToString();
            }
        }
        private void guna2ComboBox1_DropDown(object sender, EventArgs e)
        {
            if (firstDropDown && guna2ComboBox1.Items.Count > 0)
            {
                guna2ComboBox1.Items.RemoveAt(0);
                firstDropDown = false;
            }
        }
        private void guna2TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(guna2TextBoxSearch.Text))
                {
                    пользователиBindingSource.Filter = string.Empty;
                }
                else
                {
                    пользователиBindingSource.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == string.Empty || guna2TextBox2.Text == string.Empty || guna2TextBox3.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            PassValidation PassV = new PassValidation();
            if (PassV.Validation(guna2TextBox4.Text) == false)
            {
                return;
            }
            if (guna2TextBox3.Text == guna2TextBox4.Text)
            {
                MessageBox.Show("Пароль и логин не должны совпадать.", "Ошибка");
                return;
            }
            ValidationLogin LV = new ValidationLogin();
            if (LV.Validation(guna2TextBox3.Text) == false)
            {
                return;
            }
            else
            {
                RegisterUser(guna2TextBox3.Text, guna2TextBox4.Text);
                LoadDataIntoDataGridView();
            }
        }
        private void RegisterUser(string login, string password)
        {
            Hashing GH = new Hashing();
            string query = $"INSERT INTO Пользователи (Код_роли, Логин, Пароль)" +
                $" VALUES ('{guna2TextBox2.Text}', '{login}', '{GH.Hash(password)}')";
            var dbquery = new DB();
            dbquery.queryExecute(query);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Пользователи set Код_роли = '{guna2TextBox2.Text}'," +
                $" Логин = '{guna2TextBox3.Text}'," +
               $" Пароль = '{guna2TextBox4.Text}' where Код_пользователя = {guna2TextBox5.Text}";
            db.queryExecute(queryUp);
            LoadDataIntoDataGridView();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Пользователи where Код_пользователя = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
            LoadDataIntoDataGridView();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
        }
    }
}
