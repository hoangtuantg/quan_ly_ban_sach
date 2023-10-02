using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BTL_Web2_Nhom11.Views.Admin
{
    public partial class BookType : System.Web.UI.Page
    {
        // Khai báo biến Conn
        private Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            
            if (!IsPostBack)
            {
                ShowTypeBooks();
            }
        }

        private void ShowTypeBooks()
        {
            string Query = "Select * from BookType";
            TypeBooksList.DataSource = Conn.GetData(Query);
            TypeBooksList.DataBind();
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeName.Value == "" ||  DesType.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string TName = TypeName.Value;
                    string TDes = DesType.Value;

                    string Query = "insert into BookType values( N'{0}', N'{1}') ";
                    Query = string.Format(Query, TName, TDes);
                    Conn.SetData(Query);
                    ShowTypeBooks();
                    ErrMsg.Text = "Đã thêm mới thể loại sách";
                    TypeName.Value = "";
                    DesType.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void TypeBooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeName.Value = HttpUtility.HtmlDecode(TypeBooksList.SelectedRow.Cells[2].Text);
            DesType.Value = HttpUtility.HtmlDecode(TypeBooksList.SelectedRow.Cells[3].Text);

            if (TypeName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TypeBooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeName.Value == "" || DesType.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string TName = TypeName.Value;
                    string TDes = DesType.Value;

                    string Query = "update BookType set theLoai = N'{0}', moTa = N'{1}' where id = {2} ";
                    Query = string.Format(Query, TName, TDes, TypeBooksList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowTypeBooks();
                    ErrMsg.Text = "Đã cập nhật thể loại sách";
                    TypeName.Value = "";
                    DesType.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeName.Value == "" || DesType.Value == "")
                {
                    ErrMsg.Text = "Bạn chưa chọn nội dung muốn xóa!!!";
                }
                else
                {
                    string TName = TypeName.Value;
                    string TDes = DesType.Value;

                    string Query = "delete from BookType where id = {0} ";
                    Query = string.Format(Query, TypeBooksList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowTypeBooks();
                    ErrMsg.Text = "Đã xóa thông tin thể loại sách";
                    TypeName.Value = "";
                    DesType.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void SearchBookTypeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBookType.Value.Trim();

                // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Tạo truy vấn SQL để tìm kiếm thể loại sách theo tên thể loại
                    string query = "SELECT * FROM BookType WHERE theLoai LIKE N'%" + searchText + "%'";

                    // Gọi hàm GetData và gán kết quả cho GridView TypeBooksList
                    TypeBooksList.DataSource = Conn.GetData(query);
                    TypeBooksList.DataBind();
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách thể loại sách
                    ShowTypeBooks();
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void TypeBooksList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TypeBooksList.PageIndex = e.NewPageIndex;
            ShowTypeBooks(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }
    }
    
}