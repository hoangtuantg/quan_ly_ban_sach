using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BTL_Web2_Nhom11.Models
{
    public class Functions
    {
        private SqlConnection Conn;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnStr;

        // Constructor để thiết lập chuỗi kết nối
        public Functions()
        {
            // Thiết lập chuỗi kết nối tới CSDL.
            ConnStr = "Data Source=Hung123;Initial Catalog=QLyBanSach;Integrated Security=True";
            
            // Tạo một đối tượng SqlConnection để quản lý kết nối đến cơ sở dữ liệu.
            Conn = new SqlConnection(ConnStr);
           
            // Tạo một đối tượng SqlCommand để thực hiện các truy vấn SQL thông qua kết nối này.
            cmd = new SqlCommand();

            // Liên kết đối tượng SqlCommand với đối tượng SqlConnection để thực hiện truy vấn.
            cmd.Connection = Conn;
        }

        public DataTable GetData(string Query)
        {
            // Tạo một đối tượng DataTable để lưu trữ kết quả truy vấn.
            dt = new DataTable();

            // Tạo một đối tượng SqlDataAdapter để thực hiện truy vấn SQL thông qua chuỗi kết nối ConnStr.
            // Đối số đầu tiên là câu truy vấn SQL, và đối số thứ hai là chuỗi kết nối.
            sda = new SqlDataAdapter(Query, ConnStr);

            // Sử dụng phương thức Fill của đối tượng SqlDataAdapter để thực hiện truy vấn và điền kết quả vào DataTable dt.
            sda.Fill(dt);

            // Trả về DataTable chứa kết quả truy vấn.
            return dt;
        }

        // Phương thức thực hiện truy vấn cơ sở dữ liệu (INSERT, UPDATE, DELETE)
        public int SetData(string Query)
        {
            // Khởi tạo biến cnt để lưu số dòng bị ảnh hưởng bởi câu truy vấn.
            int cnt = 0;

            // Kiểm tra trạng thái kết nối, nếu chưa mở kết nối thì mở nó.
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }

            // Gán câu truy vấn SQL vào thuộc tính CommandText của đối tượng SqlCommand.
            cmd.CommandText = Query;

            // Sử dụng phương thức ExecuteNonQuery của đối tượng SqlCommand để thực hiện truy vấn SQL
            // và lấy số dòng bị ảnh hưởng (số dòng đã được cập nhật trong cơ sở dữ liệu).
            cnt = cmd.ExecuteNonQuery();

            // Sau khi thực hiện xong, đóng kết nối.
            Conn.Close();

            // Trả về số dòng bị ảnh hưởng bởi câu truy vấn.
            return cnt;
        }
    }
}
