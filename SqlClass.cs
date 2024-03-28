using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTraffic
{
    internal class SqlClass
    {

        private static SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-KBH6SHR\\SQLEXPRESS;Initial Catalog=Diplom;Integrated Security=True;Encrypt=False");

        public static SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public DataTable Commands(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");

            SqlConnection.Open();
            SqlCommand sqlCommand = SqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            SqlConnection.Close();
            return dataTable;
        }
    }
}
