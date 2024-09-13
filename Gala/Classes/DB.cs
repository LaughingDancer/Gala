using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala.Classes
{
    internal class DB
    {
        public string StringCon()
        {
            return @"Data Source=MAKSIMN;Initial Catalog=НестеровКурсовая;Integrated Security=True";
        }
        public SqlDataAdapter queryExecute(string query)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(StringCon());
                myCon.Open();
                SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Действие успешно выполнено!", "Успех");
                return SDA;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выполнении запроса. Проверьте вводимые данные", "Ошибка");
                return null;
            }
        }
    }
}
