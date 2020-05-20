using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLopHoc.DAL
{
    class DataConnection
    {
        public static SqlConnection getConnectionString()
        {
            return new SqlConnection(@"Data Source=VUHUNGA49E;Initial Catalog=QLLopHoc;Integrated Security=True");
        }

        public static DataTable fillDataTable(string query)
        {
            SqlConnection connect = getConnectionString();
            connect.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connect);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static void excuteNonQuery(string query)
        {
            SqlConnection connect = getConnectionString();
            connect.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connect);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlCommand.Clone();
        }
    }
}
