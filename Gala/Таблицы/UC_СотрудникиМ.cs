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
    public partial class UC_СотрудникиМ : UserControl
    {
        private DB db;
        int selectedRow;
        private bool firstDropDown = true;
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;Initial " +
            "Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_СотрудникиМ()
        {
            db = new DB();
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
        }
        private void UC_СотрудникиМ_Load(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.нестеровКурсоваяDataSet.Сотрудники);
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
                guna2TextBox5.Text = row.Cells[4].Value.ToString();
                guna2TextBox6.Text = row.Cells[5].Value.ToString();
                guna2TextBox7.Text = row.Cells[6].Value.ToString();
                guna2TextBox8.Text = row.Cells[7].Value.ToString();
                guna2TextBox9.Text = row.Cells[0].Value.ToString();
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
                    сотрудникиBindingSource.Filter = string.Empty;
                }
                else
                {
                    сотрудникиBindingSource.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            wordExporter.WordExport(guna2DataGridView1);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(guna2DataGridView1);
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT * FROM Сотрудники";
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == string.Empty
    || guna2TextBox3.Text == string.Empty
    || guna2TextBox4.Text == string.Empty || guna2TextBox5.Text == string.Empty
    || guna2TextBox6.Text == string.Empty || guna2TextBox7.Text == string.Empty
    || guna2TextBox8.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            Validation validator = new Validation();
            string lastName = guna2TextBox2.Text;
            string firstName = guna2TextBox3.Text;
            string middleName = guna2TextBox4.Text;
            string salary = guna2TextBox5.Text;
            string date = guna2TextBox6.Text;
            string phone = guna2TextBox7.Text;
            string post = guna2TextBox8.Text;

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
            if (!validator.ValidateFirstName(post))
            {
                MessageBox.Show("Некорректная должность", "Ошибка");
                return;
            }
            if (!validator.ValidateMiddleName(middleName))
            {
                MessageBox.Show("Некорректное отчество", "Ошибка");
                return;
            }
            if (!validator.ValidatePhone(phone))
            {
                MessageBox.Show("Некорректный номер телефона", "Ошибка");
                return;
            }
            if (!validator.ValidateNumber(salary))
            {
                MessageBox.Show("Некорректный сумма", "Ошибка");
                return;
            }
            DateTime parsedDate;
            if (!DateTime.TryParse(date, out parsedDate))
            {
                MessageBox.Show("Некорректная дата", "Ошибка");
                return;
            }
            var queryAdd = $"insert into Сотрудники (Фамилия, Имя, Отчество, Зарплата," +
    $" Дата_трудоустройства, Контактный_номер, Должность) values ('{guna2TextBox2.Text}'," +
    $" '{guna2TextBox3.Text}'," +
    $" '{guna2TextBox4.Text}', '{guna2TextBox5.Text}', '{guna2TextBox6.Text}'," +
    $" '{guna2TextBox7.Text}', '{guna2TextBox8.Text}')";
            db.queryExecute(queryAdd);
            LoadDataIntoDataGridView();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Сотрудники set Фамилия = '{guna2TextBox2.Text}'," +
    $" Имя = '{guna2TextBox3.Text}'," +
    $" Отчество = '{guna2TextBox4.Text}', Зарплата = '{guna2TextBox5.Text}'," +
    $" Дата_трудоустройства = '{guna2TextBox6.Text}'" +
    $", Контактный_номер = '{guna2TextBox7.Text}', Должность = '{guna2TextBox8.Text}'" +
    $" where Код_сотрудника = {guna2TextBox9.Text}";
            db.queryExecute(queryUp);
            LoadDataIntoDataGridView();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
            guna2TextBox6.Text = "";
            guna2TextBox7.Text = "";
            guna2TextBox8.Text = "";
            guna2TextBox9.Text = "";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Сотрудники where Код_сотрудника = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
            LoadDataIntoDataGridView();
        }
    }
}
