﻿using Gala.Classes;
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
    public partial class UC_СкладПоставщик : UserControl
    {
        private DB db;
        int selectedRow;
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;" +
            "Initial Catalog=НестеровКурсовая;Integrated Security=True");
        private bool firstDropDown = true;
        public UC_СкладПоставщик()
        {
            InitializeComponent();
            db = new DB();
            guna2DataGridView1.Font = new Font("Segoe UI", 10);
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;

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
                    складBindingSource.Filter = string.Empty;
                }
                else
                {
                    складBindingSource.Filter = string.Format("{0}='{1}'", guna2ComboBox1.Text,
                        guna2TextBoxSearch.Text);
                }
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var queryAdd = $"insert into Склад (Код_товара, Остаток_товара, Расположение_товара)" +
                $" values ('{guna2TextBox2.Text}', '{guna2TextBox3.Text}'," +
                $" '{guna2TextBox4.Text}')";
            db.queryExecute(queryAdd);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Склад set Код_товара = '{guna2TextBox2.Text}', Остаток_товара = '{guna2TextBox3.Text}'," +
                $" Расположение_товара = '{guna2TextBox4.Text}' where Код_склада = {guna2TextBox5.Text}";
            db.queryExecute(queryUp);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Склад where Код_склада = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
        }
        private void UC_СкладПоставщик_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT Склад.Код_склада AS Cклад, Товар.Наименование_товара AS Товар, Склад.Остаток_товара as Остаток," +
                    " Склад.Расположение_товара as Расположение FROM Склад JOIN Товар ON Товар.Код_товара = Склад.Код_товара";
                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                складBindingSource.DataSource = dataTable;
                guna2DataGridView1.DataSource = складBindingSource;
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
