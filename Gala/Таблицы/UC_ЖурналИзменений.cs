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
    public partial class UC_ЖурналИзменений : UserControl
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=MAKSIMN;
Initial Catalog=НестеровКурсовая;Integrated Security=True");
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        public UC_ЖурналИзменений()
        {
            InitializeComponent();
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
        }
        private void UC_ЖурналИзменений_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT\r\nИдентификатор as Идентификатор,\r\nТаблица as Таблица,\r\nДействие as Действие," +
                    "\r\nСтароеЗначение as [Старое значение],\r\nНовоеЗначение as [Новое Значение]," +
                    "\r\nДата_Изменения as [Дата Изменения]\r\nFROM ЖурналИзменений";
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
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            wordExporter.WordExport(guna2DataGridView1);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(guna2DataGridView1);
        }
    }
}
