using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web2_Nhom11.Views.Admin
{
    public partial class Author : System.Web.UI.Page
    {
        // Khai báo biến Conn để sử dụng cho cả trang quản lý tác giả
        private Models.Functions Conn; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng Conn từ lớp Functions để sử dụng các phương thức của nó
            Conn = new Models.Functions();

            // Hiển thị danh sách tác giả khi trang được tải
            //Khi thực hiện tìm kiếm sau khi thực hiện sẽ không đổ lại toàn bộ db 
            if (!IsPostBack)
            {
                ShowAuthors();
            }
        }

        private void ShowAuthors()
        {
            //Lấy dữ liệu từ bảng Author
            string Query = "Select * from Author";

            //Gán dữ liệu lấy được từ bảng vào danh sách
            AuthorsList.DataSource = Conn.GetData(Query);

            //Gán dữ liệu từ danh sách lên giao diện GridView
            AuthorsList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra input có rỗng ko
                if (AName.Value == "" || AGender.SelectedIndex == -1 || ACountry.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    //Lấy thông tin đc nhập vào input
                    string Name = AName.Value ;
                    string Gender = AGender.SelectedItem.ToString();
                    string Country = ACountry.Value ;

                    //Query thêm tác giả vào CSDL
                    //{0},... là các tham số đại diện lần lượt cho các giá trị ở query =... bên  dưới
                    string Query = "insert into Author values( N'{0}', N'{1}', N'{2}') ";
                    Query = string.Format(Query, Name, Gender, Country);
  
                    Conn.SetData(Query);//Thực thi câu lệnh truy vấn
                    ShowAuthors() ;//Hiển thị danh sách sau khi thêm mới

                    //Xóa dữ liệu trường input
                    ErrMsg.Text = "Đã thêm mới tác giả";
                    AName.Value = "";
                    AGender.SelectedIndex = -1;
                    ACountry.Value = "";
                }
            }
            catch (Exception Ex)
            {
                //Thông báo lỗi 
                ErrMsg.Text = Ex.Message;
            }
        }
        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hiện thị thông tin của hàng được chọn
            AName.Value = HttpUtility.HtmlDecode(AuthorsList.SelectedRow.Cells[2].Text);
            AGender.SelectedItem.Value = HttpUtility.HtmlDecode(AuthorsList.SelectedRow.Cells[3].Text);
            ACountry.Value = HttpUtility.HtmlDecode(AuthorsList.SelectedRow.Cells[4].Text);

            if (AName.Value == "")//Kiểm tra xem trường nhập tên tác giả có trống không
            {
                Key = 0;
            }
            else //Nếu không thì lấy dữ liệu từ hàng đầu tiên
            {
                Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
                

            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AName.Value == "" || AGender.SelectedIndex == -1 || ACountry.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string Name = AName.Value;
                    string Gender = AGender.SelectedItem.ToString();
                    string Country = ACountry.Value;

                    string Query = "update Author set tenTacGia = N'{0}',gioiTinh = N'{1}',quocTich = N'{2}' where id = {3} ";
                    Query = string.Format(Query, Name, Gender, Country, AuthorsList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Đã cập nhật thông tin tác giả";
                    AName.Value = "";
                    AGender.SelectedIndex = -1;
                    ACountry.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AName.Value == "" || AGender.SelectedIndex == -1 || ACountry.Value == "")
                {
                    ErrMsg.Text = "Bạn chưa chọn nội dung muốn xóa!!!";
                }
                else
                {
                    string Name = AName.Value;
                    string Gender = AGender.SelectedItem.ToString();
                    string Country = ACountry.Value;

                    string Query = "delete from Author where id = {0} ";
                    Query = string.Format(Query, AuthorsList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Đã xóa thông tin tác giả";
                    AName.Value = "";
                    AGender.SelectedIndex = -1;
                    ACountry.Value = "";
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
                string searchText = txtSearchAuthor.Value.Trim();

                // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Tạo truy vấn SQL để tìm kiếm tác giả theo tên
                    string query = "SELECT * FROM Author WHERE tenTacGia LIKE N'%" + searchText + "%'";

                    // Gọi hàm GetData và gán kết quả cho GridView AuthorsList
                    AuthorsList.DataSource = Conn.GetData(query);
                    AuthorsList.DataBind();
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách tác giả
                    ShowAuthors();
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void AuthorsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AuthorsList.PageIndex = e.NewPageIndex;
            ShowAuthors(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }
    }
}