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

namespace Gala.Клиент
{
    public partial class UC_ЗаказыКлиента : UserControl
    {
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;" +
            "Initial Catalog=НестеровКурсовая;Integrated Security=True");
        private DB db;
        public UC_ЗаказыКлиента()
        {
            db = new DB();
            InitializeComponent();
            guna2DataGridView1.Font = new Font("Segoe UI", 9);
        }
        private void UC_ЗаказыКлиента_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            guna2DataGridView1.Columns[2].Width = 170;
            guna2DataGridView1.Columns[1].Width = 60;
            guna2DataGridView1.Columns[0].Width = 70;
            guna2DataGridView1.Columns[4].Width = 80;
            guna2DataGridView1.Columns[5].Width = 80;
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT Договор.Код_договора AS [Договор],Товар.Наименование_товара AS Товар," +
                    "Поставщик.Наименование_компании AS Поставщик,Договор.Количество_товаров AS [Кол-во товара]," +
                    "Договор.Статус_договора AS Статус,Договор.Стоимость_договора AS Стоимость," +
                    "Договор.Дата_оформления AS [Дата оформления]," +
                    " Договор.Дата_завершения AS [Дата завершения] FROM Договор JOIN Товар ON" +
                    " Товар.Код_товара = Договор.Код_товара JOIN Поставщик ON Поставщик.Код_поставщика = Договор.Код_поставщика" +
                    " WHERE Договор.Код_клиента = 6";
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
        int selectedRow;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[selectedRow];
                var кодДоговора = row.Cells["Договор"].Value.ToString();
                var queryDel = $"delete Договор where Код_договора = {кодДоговора} ";
                db.queryExecute(queryDel);
                LoadDataIntoDataGridView();
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
        }
    }
}
