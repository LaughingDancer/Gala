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
    public partial class UC_КлиентА : UserControl
    {
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;Initial" +
            " Catalog=НестеровКурсовая;Integrated Security=True");
        int selectedRow;
        private DB db;
        private bool firstDropDown = true;
        public UC_КлиентА()
        {
            db = new DB();
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
        }
        private void UC_Клиент_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connectionString.Open();
                string query = "SELECT Код_клиента as Код, Фамилия, Имя, Отчество," +
                    " Электронная_почта as Email, ИНН FROM Клиент";
                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                клиентBindingSource1.DataSource = dataTable;
                guna2DataGridView1.DataSource = клиентBindingSource1;
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
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var queryUp = $"update Клиент set Фамилия = '{guna2TextBox2.Text}'," +
                $" Имя = '{guna2TextBox3.Text}'," +
                $" Отчество = '{guna2TextBox4.Text}', Электронная_почта = '{guna2TextBox5.Text}'," +
                $" ИНН = '{guna2TextBox6.Text}' where Код_клиента = {guna2TextBox7.Text}";
            db.queryExecute(queryUp);
            LoadDataIntoDataGridView();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var queryDel = $"delete Клиент where Код_клиента = {guna2TextBox1.Text} ";
            db.queryExecute(queryDel);
            LoadDataIntoDataGridView();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var queryAdd = $"insert into Клиент (Фамилия, Имя, Отчество, Электронная_почта," +
                $" ИНН) values ('{guna2TextBox2.Text}', '{guna2TextBox3.Text}'," +
                $" '{guna2TextBox4.Text}', '{guna2TextBox5.Text}', '{guna2TextBox6.Text}')";
            db.queryExecute(queryAdd);
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
                guna2TextBox7.Text = row.Cells[0].Value.ToString();
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
                    клиентBindingSource1.Filter = string.Empty;
                }
                else
                {
                    клиентBindingSource1.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
    }
}
