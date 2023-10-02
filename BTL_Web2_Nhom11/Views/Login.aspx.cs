using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web2_Nhom11.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtdangnhap.Text;
            string password = txtPassword.Text;

            // Kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=Hung123;Initial Catalog=QLyBanSach;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo câu truy vấn SQL để kiểm tra tài khoản
                string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Tài khoản đăng nhập thành công
                           
                            string userEmail = reader["Email"].ToString();
                            Session["UserEmail"] = userEmail; // Lưu tên người dùng vào Session


                            string userRole = reader["UserRole"].ToString();
                            if (userRole == "Admin")
                            {
                                // Đăng nhập thành công cho admin
                                Response.Redirect("../Views/Admin/Books.aspx");
                            }
                            else if (userRole == "User")
                            {
                                // Đăng nhập thành công cho user
                                Response.Redirect("../Views/User/HoaDon.aspx");
                            }
                        }
                        else
                        {
                            // Hiển thị thông báo lỗi nếu không đăng nhập thành công

                            lblErrorMessage.Text = "Email hoặc mật khẩu không đúng.";
                        }
                    }
                }
            }

        }
    }
}