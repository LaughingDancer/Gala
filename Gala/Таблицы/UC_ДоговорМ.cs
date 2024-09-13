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
    public partial class UC_ДоговорМ : UserControl
    {
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        private DB db;
        int selectedRow;
        private bool firstDropDown = true;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;Initial " +
            "Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_ДоговорМ()
        {
            db = new DB();
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
        }
        private void UC_ДоговорМ_Load(object sender, EventArgs e)
        {
            this.договорTableAdapter.Fill(this.нестеровКурсоваяDataSet.Договор);
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            wordExporter.WordExport(guna2DataGridView1);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(guna2DataGridView1);
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
                    договорBindingSource.Filter = string.Empty;
                }
                else
                {
                    договорBindingSource.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var queryAdd = $"insert into Договор (Код_товара, Код_поставщика, Код_клиента, Код_сотрудника," +
    $" Код_заказа, Количество_товаров, Статус_договора, Стоимость_договора, Дата_оформления," +
    $" Дата_завершения ) values ('{guna2TextBox2.Text}', '{guna2TextBox3.Text}'," +
    $" '{guna2TextBox4.Text}', '{guna2TextBox5.Text}', '{guna2TextBox6.Text}'," +
    $" '{guna2TextBox7.Text}', '{guna2TextBox8.Text}', '{guna2TextBox9.Text}', '{guna2TextBox10.Text}'," +
    $" '{guna2TextBox11.Text}')";
            db.queryExecute(queryAdd);
            LoadDataIntoDataGridView();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Договор set Код_товара = '{guna2TextBox2.Text}', " +
    $"Код_поставщика = '{guna2TextBox3.Text}', Код_клиента = '{guna2TextBox4.Text}'," +
    $" Код_сотрудника = '{guna2TextBox5.Text}', Код_заказа = '{guna2TextBox6.Text}'," +
    $" Количество_товаров = '{guna2TextBox7.Text}', Статус_договора = '{guna2TextBox8.Text}'," +
    $" Стоимость_договора = '{guna2TextBox9.Text}', Дата_оформления = '{guna2TextBox10.Text}'," +
    $" Дата_завершения = '{guna2TextBox11.Text}' where Код_договора = {guna2TextBox12.Text}";
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
            guna2TextBox10.Text = "";
            guna2TextBox11.Text = "";
            guna2TextBox12.Text = "";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Договор where Код_договора = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
            LoadDataIntoDataGridView();
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
                guna2TextBox9.Text = row.Cells[8].Value.ToString();
                guna2TextBox10.Text = row.Cells[9].Value.ToString();
                guna2TextBox11.Text = row.Cells[10].Value.ToString();
                guna2TextBox12.Text = row.Cells[0].Value.ToString();
            }
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT * FROM Договор";
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
