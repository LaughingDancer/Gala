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

namespace Gala.Поставщик
{
    public partial class UC_ЗаказыПоставщик : UserControl
    {
        private DB db;
        int selectedRow;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;" +
            "Initial Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_ЗаказыПоставщик()
        {
            InitializeComponent();
            db = new DB();
            guna2DataGridView1.Font = new Font("Segoe UI", 12);

        }
        private void UC_ЗаказыПоставщик_Load(object sender, EventArgs e)
        {
           LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT Заказ.Код_заказа AS [Код заказа], Товар.Наименование_товара AS Товар," +
                    " Заказ.Количество_товаров AS [Кол-во товара], Заказ.Статус_заказа AS Статус FROM Заказ" +
                    " JOIN Товар ON Товар.Код_товара = Заказ.Код_товара WHERE Заказ.Код_поставщика = 1";
                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.DefaultView.RowFilter = "Статус <> 'выполнен'";
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[selectedRow];
                var кодЗаказа = row.Cells[0].Value.ToString();
                var queryUp = $"update Заказ set Статус_заказа = 'выполнен' where Код_заказа = {кодЗаказа}";
                db.queryExecute(queryUp);
                LoadDataIntoDataGridView();
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
        }
    }
}