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
using System.Globalization;
using System.Net.Mail;
using System.Net;
using Guna.UI2.WinForms;
using static Gala.Classes.ValidForm;

namespace Gala.Клиент
{
    public partial class UC_Главная : UserControl
    {
        SqlConnection connectionString = new SqlConnection("Data Source=MAKSIMN;" +
            "Initial Catalog=НестеровКурсовая;Integrated Security=True");
        public UC_Главная()
        {
            InitializeComponent();
        }

        private void UC_Главная_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT Наименование_товара FROM Товар";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxProducts.Items.Add(reader["Наименование_товара"].ToString());
                }
                reader.Close();
            }
            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT Наименование_компании FROM Поставщик";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxSuppliers.Items.Add(reader["Наименование_компании"].ToString());
                }
                reader.Close();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxProducts.Text))
            {
                MessageBox.Show("Выберите товар", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxSuppliers.Text))
            {
                MessageBox.Show("Выберите поставщика", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {
                MessageBox.Show("Введите количество товара", "Ошибка");
                return;
            }
            Validation validator = new Validation();
            string number = textBoxQuantity.Text;
            if (!validator.ValidateNumber(number))
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
                return;
            }
            string productName = comboBoxProducts.SelectedItem.ToString();
            string supplierName = comboBoxSuppliers.SelectedItem.ToString();
            int quantity = Convert.ToInt32(textBoxQuantity.Text);
            int productCode = GetProductCode(productName);
            int currentStockQuantity = GetCurrentStockQuantity(productCode);
            if (quantity > currentStockQuantity)
            {
                MessageBox.Show("Такого количества товаров нет на складе.");
                return;
            }
            UpdateStock(productCode, currentStockQuantity - quantity);
            AddOrder(productName, supplierName, quantity);
        }
        private void AddOrder(string productName, string supplierName, int quantity)
        {
            int productId = FindProductIdByName(productName);
            int supplierId = FindSupplierIdByName(supplierName);
            if (productId == -1)
            {
                MessageBox.Show("Товар с указанным наименованием не найден.");
                return;
            }
            if (supplierId == -1)
            {
                MessageBox.Show("Поставщик с указанным наименованием не найден.");
                return;
            }
            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "INSERT INTO Заказ (Код_поставщика, Код_товара, Количество_товаров, Статус_заказа)" +
                    " VALUES (@supplierId, @productId, @quantity, 'в процессе')";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@supplierId", supplierId);
                command.Parameters.AddWithValue("@productId", productId);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Заказ успешно добавлен.");
        }
        private int FindProductIdByName(string productName)
        {
            int productId = -1;
            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT Код_товара FROM Товар WHERE Наименование_товара = @productName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@productName", productName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    productId = Convert.ToInt32(result);
                }
            }
            return productId;
        }
        private int FindSupplierIdByName(string supplierName)
        {
            int supplierId = -1;

            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT Код_поставщика FROM Поставщик WHERE Наименование_компании = @supplierName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@supplierName", supplierName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    supplierId = Convert.ToInt32(result);
                }
            }
            return supplierId;
        }
        private int GetCurrentStockQuantity(int productCode)
        {
            int currentStockQuantity = 0;
            try
            {
                connectionString.Open();
                string query = $"SELECT Остаток_товара FROM Склад WHERE Код_товара = {productCode}";
                SqlCommand command = new SqlCommand(query, connectionString);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    currentStockQuantity = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении остатка товара на складе: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
            return currentStockQuantity;
        }
        private int GetProductCode(string productName)
        {
            int productCode = 0;
            try
            {
                connectionString.Open();
                string query = $"SELECT Код_товара FROM Товар WHERE Наименование_товара = '{productName}'";
                SqlCommand command = new SqlCommand(query, connectionString);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    productCode = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении кода товара: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
            return productCode;
        }
        private void UpdateStock(int productCode, int newStockQuantity)
        {
            try
            {
                connectionString.Open();
                string query = $"UPDATE Склад SET Остаток_товара = {newStockQuantity}" +
                    $" WHERE Код_товара = {productCode}";
                SqlCommand command = new SqlCommand(query, connectionString);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении остатка товара на складе: " + ex.Message);
            }
            finally
            {
                connectionString.Close();
            }
        }
        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductName = comboBoxProducts.SelectedItem.ToString();
            string description;
            decimal price;
            int stockQuantity;
            using (SqlConnection connection = new SqlConnection("Data Source=MAKSIMN;" +
                "Initial Catalog=НестеровКурсовая;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT t.Описание_товара, t.Цена_товара, s.Остаток_товара " +
                               "FROM Товар t " +
                               "INNER JOIN Склад s ON t.Код_товара = s.Код_товара " +
                               "WHERE t.Наименование_товара = @productName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@productName", selectedProductName);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    description = reader["Описание_товара"].ToString();
                    price = Convert.ToDecimal(reader["Цена_товара"]);
                    stockQuantity = Convert.ToInt32(reader["Остаток_товара"]);
                }
                else
                {
                    description = string.Empty;
                    price = 0;
                    stockQuantity = 0;
                }
                reader.Close();
            }
            string formattedPrice = price.ToString("C", CultureInfo.GetCultureInfo("ru-RU"));
            textBoxDescription.Text = description;
            textBoxPrice.Text = formattedPrice;
            textBoxStockQuantity.Text = stockQuantity.ToString();
        }
    }
}
