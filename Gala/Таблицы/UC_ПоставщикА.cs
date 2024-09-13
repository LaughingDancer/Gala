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
using static Gala.Classes.ValidForm;

namespace Gala.Таблицы
{
    public partial class UC_ПоставщикА : UserControl
    {
        private DB db;
        int selectedRow;
        private bool firstDropDown = true;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;Initial " +
            "Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_ПоставщикА()
        {
            db = new DB();
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
        }
        private void UC_Поставщик_Load(object sender, EventArgs e)
        {
            this.поставщикTableAdapter.Fill(this.нестеровКурсоваяDataSet.Поставщик);
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
                    поставщикBindingSource.Filter = string.Empty;
                }
                else
                {
                    поставщикBindingSource.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Validation validator = new Validation();
            string companyName = guna2TextBox2.Text;
            string email = guna2TextBox3.Text;
            string inn = guna2TextBox4.Text;
            if (!validator.ValidateCompanyName(companyName))
            {
                MessageBox.Show("Некорректное название компании", "Ошибка");
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
            var queryAdd = $"insert into Поставщик (Наименование_компании, Электронная_почта, ИНН)" +
                $" values ('{guna2TextBox2.Text}', '{guna2TextBox3.Text}'," +
                $" '{guna2TextBox4.Text}')";
            db.queryExecute(queryAdd);
            LoadDataIntoDataGridView();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Поставщик where Код_поставщика = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
            LoadDataIntoDataGridView();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Поставщик set Наименование_компании = '{guna2TextBox2.Text}'," +
                $" Электронная_почта = '{guna2TextBox3.Text}'," +
                $" ИНН = '{guna2TextBox4.Text}' where Код_поставщика = {guna2TextBox5.Text}";
            db.queryExecute(queryUp);
            LoadDataIntoDataGridView();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT * FROM Поставщик";
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
    }
}
