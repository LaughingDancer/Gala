using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gala.Classes.ValidForm;

namespace Gala.Клиент
{
    public partial class UC_ЛичныеДанные : UserControl
    {
        string connectionString = @"Data Source=MAKSIMN;
Initial Catalog=НестеровКурсовая;Integrated Security=True";
        private byte[] selectedPhotoBytes;
        public UC_ЛичныеДанные()
        {
            InitializeComponent();
            int clientId = 6;
            LoadClientData(clientId);
            LoadClientPhoto(clientId);
        }
        private void LoadClientData(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Клиент WHERE Код_клиента = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", clientId);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            guna2TextBox1.Text = reader["Фамилия"].ToString();
                            guna2TextBox2.Text = reader["Имя"].ToString();
                            guna2TextBox3.Text = reader["Отчество"].ToString();
                            guna2TextBox4.Text = reader["Электронная_почта"].ToString();
                            guna2TextBox5.Text = reader["ИНН"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке данных о клиенте: " + ex.Message);
                    }
                }
            }
        }
        private void LoadClientPhoto(int clientId)
        {
            byte[] photoBytes = GetClientPhoto(clientId);
            if (photoBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(photoBytes))
                {
                    pictureSet.Image = Image.FromStream(ms);
                }
            }
        }
        private byte[] GetClientPhoto(int clientId)
        {
            byte[] photoBytes = null;
            string query = $"SELECT Фото FROM Клиент WHERE Код_клиента = {clientId}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                photoBytes = (byte[])reader["Фото"];
                            }
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении фотографии: " + ex.Message);
                    }
                }
            }
            return photoBytes;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Validation validator = new Validation();
            string lastName = guna2TextBox1.Text;
            string firstName = guna2TextBox2.Text;
            string middleName = guna2TextBox3.Text;
            string Email = guna2TextBox4.Text;
            string INN = guna2TextBox5.Text;
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
            if (!validator.ValidateMiddleName(middleName))
            {
                MessageBox.Show("Некорректное отчество", "Ошибка");
                return;
            }
            if (!validator.ValidateEmail(Email))
            {
                MessageBox.Show("Некорректный email", "Ошибка");
                return;
            }
            if (!validator.ValidateINN(INN))
            {
                MessageBox.Show("Некорректный ИНН", "Ошибка");
                return;
            }
            DialogResult result = MessageBox.Show("Изменить личные данные?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateClientData(6, firstName, lastName, middleName, Email, INN);
            }
            else
            {
                MessageBox.Show("Действие было отменено!", "Уведомление", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void UpdateClientData(int clientId, string firstName, string lastName, string middleName, string Email, string INN)
        {
            string queryUp = $"UPDATE Клиент SET Фамилия = @LastName, Имя = @FirstName, " +
                            $"Отчество = @MiddleName, Электронная_почта = @Email, " +
                            $"ИНН = @INN WHERE Код_клиента = {clientId}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryUp, connection))
                {
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@MiddleName", middleName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@INN", INN);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно обновлены");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
                    }
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                pictureSet.Image = Image.FromFile(selectedFile);
                selectedPhotoBytes = File.ReadAllBytes(selectedFile);
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (selectedPhotoBytes != null)
            {
                int clientId = 6;
                string query = "UPDATE Клиент SET Фото = @Photo WHERE Код_клиента = @ClientId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Photo", selectedPhotoBytes);
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Фотография успешно сохранена в базе данных");
                            }
                            else
                            {
                                MessageBox.Show("Не удалось сохранить фотографию в базе данных");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при сохранении фотографии в базе данных: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите фотографию для сохранения", "Предупреждение", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
