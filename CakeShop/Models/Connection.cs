using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    class Connection
    {
        public static string cn_string = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DaTaDirectory\SQL\CakeShopmdf.mdf;Integrated Security=True";
        

        /// <summary>
        /// tạo kết nối với database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Get_Connection()
        {

            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open)
                cn_connection.Open();
            return cn_connection;
        }

        /// <summary>
        /// đóng kết nối với database
        /// </summary>
        public static void Close_Connection()
        {
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Closed)
                cn_connection.Close();
        }



        /// <summary>
        /// lấy tất cả các dữ liệu trong table
        /// </summary>
        /// <param name="sql"> câu query truy vấn database</param>
        /// <returns></returns>
        public static DataTable GetALL_Data(string sql)
        {
            SqlConnection cn_connection = Get_Connection();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cn_connection);
            adapter.Fill(dt);
            Close_Connection();
            return dt;
        }

        /// <summary>
        /// hàm xu ly tra về 1 dữ liệu
        /// </summary>
        /// <param name="sql"> câu truy vấn query</param>
        /// <returns></returns>
        public static int GetCount_Data(string sql)
        {
            SqlConnection cn_connection = Get_Connection();
            SqlCommand cmd_Command = new SqlCommand(sql, cn_connection);
            int id = (int)cmd_Command.ExecuteScalar();
            Close_Connection();
            return id;
        }

        /// <summary>
        /// update chỉnh sủa trong câu truy vấn
        /// </summary>
        /// <param name="sql"> câu query truy vấn vào database</param>
        public static void Execute_SQL(string sql)
        {
            SqlConnection cn_connection = Get_Connection();
            using (SqlCommand cmd_Command = new SqlCommand(sql, cn_connection))
            {

                cmd_Command.ExecuteNonQuery();
            }
            Close_Connection();
        }

    }
}
