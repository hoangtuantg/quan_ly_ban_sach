using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web2_Nhom11.Views.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        // Khai báo biến Conn để sử dụng cho cả trang quản lý tài khoản
        private Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng Conn từ lớp Functions để sử dụng các phương thức của nó
            Conn = new Models.Functions();

            // Hiển thị danh sách tài khoản khi trang được tải

            if (!IsPostBack)
            {
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            //Lấy dữ liệu từ bảng User
            string Query = "Select * from Users";

            //Gán dữ liệu lấy được từ bảng vào danh sách
            UsersList.DataSource = Conn.GetData(Query);

            //Gán dữ liệu từ danh sách lên giao diện GridView
            UsersList.DataBind();
        }

        protected void ADDBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra input có rỗng ko
                if (Email.Value == "" || Pass.Value == "" || Role.SelectedIndex == -1 )
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    //Lấy thông tin đc nhập vào input
                    string email = Email.Value;
                    string pass = Pass.Value;
                    string role = Role.SelectedItem.ToString();

                    //Query thêm tai khoan vào CSDL
                    string Query = "insert into Users values( N'{0}', N'{1}', N'{2}') ";
                    Query = string.Format(Query, email, pass, role);

                    Conn.SetData(Query);//Thực thi câu lệnh truy vấn
                    ShowUsers();//Hiển thị danh sách sau khi thêm mới

                    //Xóa dữ liệu trường input
                    ErrMsg.Text = "Đã thêm mới tài khoản";
                    Email.Value = "";
                    Pass.Value = "";
                    Role.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                //Thông báo lỗi 
                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void UsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hiện thị thông tin của hàng được chọn
            Email.Value = HttpUtility.HtmlDecode(UsersList.SelectedRow.Cells[2].Text);
            Pass.Value = HttpUtility.HtmlDecode(UsersList.SelectedRow.Cells[3].Text);
            Role.SelectedItem.Value = HttpUtility.HtmlDecode(UsersList.SelectedRow.Cells[4].Text);
            

            if (Email.Value == "")//Kiểm tra xem trường nhập email có trống không
            {
                Key = 0;
            }
            else //Nếu không thì lấy dữ liệu từ cột đầu tiên
            {
                Key = Convert.ToInt32(UsersList.SelectedRow.Cells[1].Text);


            }
        }

        protected void UPDATEBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Email.Value == "" || Pass.Value == "" || Role.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string email = Email.Value;
                    string pass = Pass.Value;
                    string role = Role.SelectedItem.ToString();

                    string Query = "update Users set Email = '{0}',Password = '{1}',UserRole = '{2}' where UserId = {3} ";
                    Query = string.Format(Query, email, pass, role, UsersList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowUsers();
                    ErrMsg.Text = "Đã cập nhật thông tin tai khoan";
                    Email.Value = "";
                    Pass.Value = "";
                    Role.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DELETEBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Email.Value == "" || Pass.Value == "" || Role.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Bạn chưa chọn nội dung muốn xóa!!!";
                }
                else
                {
                    string email = Email.Value;
                    string pass = Pass.Value;
                    string role = Role.SelectedItem.ToString();

                    string Query = "delete from Users where UserId = {0} ";
                    Query = string.Format(Query, UsersList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowUsers();
                    ErrMsg.Text = "Đã xóa tài khoản";
                    Email.Value = "";
                    Pass.Value = "";
                    Role.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchUser.Value.Trim();

                // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Tạo truy vấn SQL để tìm kiếm tác giả theo tên
                    string query = "SELECT * FROM Users WHERE email LIKE N'%" + searchText + "%'";

                    // Gọi hàm GetData và gán kết quả cho GridView AuthorsList
                    UsersList.DataSource = Conn.GetData(query);
                    UsersList.DataBind();
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách tác giả
                    ShowUsers();
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void UsersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersList.PageIndex = e.NewPageIndex;
            ShowUsers(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }
    }
}