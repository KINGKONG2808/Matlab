using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace HECHUYENGIA
{
    class KetNoi
    {
         SqlConnection conn;
        public KetNoi()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=VUHUNGA49E;Initial Catalog=TuVanLapTop_HCG;Integrated Security=True";
            conn.Open();
        }
        public DataTable TaoBang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable XemDL(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public void ThucHien(string sql)
        {
            SqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public DataTable TaoMaTuDong(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
    }
}
