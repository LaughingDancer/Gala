using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala.Classes
{
    internal class DB2
    {
        public string StringCon()
        {
            return @"Data Source=MAKSIMN;Initial Catalog=НестеровКурсовая;Integrated Security=True";
        }
        public SqlDataReader queryExecute(string query)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(StringCon());
                myCon.Open();
                SqlCommand command = new SqlCommand(query, myCon);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка при выполнении запроса: {ex.Message}", "Ошибка");
                return null;
            }
        }
    }
}
