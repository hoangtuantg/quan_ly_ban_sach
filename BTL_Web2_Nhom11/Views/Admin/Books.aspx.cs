using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BTL_Web2_Nhom11.Views.Admin
{

    public partial class Books : System.Web.UI.Page
    {
        // Khai báo biến Conn
        private Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
            }
        }

        private void ShowBooks()
        {
            string Query = "Select * from Book";
            BooksList.DataSource = Conn.GetData(Query);
            BooksList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BName.Value == "" || BAuthor.Value == "" || BType.Value == "" || BPrice.Value == "" || BQuantity.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string NameB = BName.Value;
                    string AuthorB = BAuthor.Value;
                    string TypeB = BType.Value;
                    string PriceB = BPrice.Value;
                    string QuantityB = BQuantity.Value;

                    string Query = "insert into Book values( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}') ";
                    Query = string.Format(Query, NameB, AuthorB, TypeB, PriceB, QuantityB);
                    Conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Đã thêm mới sách";
                    BName.Value = "";
                    BAuthor.Value = "";
                    BType.Value = "";
                    BPrice.Value = "";
                    BQuantity.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;
        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BooksList.SelectedIndex != -1)
            {
                GridViewRow selectedRow = BooksList.Rows[BooksList.SelectedIndex];
                BName.Value = HttpUtility.HtmlDecode(selectedRow.Cells[2].Text);
                BAuthor.Value = HttpUtility.HtmlDecode(selectedRow.Cells[3].Text);
                BType.Value = HttpUtility.HtmlDecode(selectedRow.Cells[4].Text);
                BPrice.Value = HttpUtility.HtmlDecode(selectedRow.Cells[5].Text);
                BQuantity.Value = HttpUtility.HtmlDecode(selectedRow.Cells[6].Text);

                if (BName.Value == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(selectedRow.Cells[1].Text);
                }
            }
        }


        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BName.Value == "" || BAuthor.Value == "" || BType.Value == "" || BPrice.Value == "" || BQuantity.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string NameB = BName.Value;
                    string AuthorB = BAuthor.Value;
                    string TypeB = BType.Value;
                    string PriceB = BPrice.Value;
                    string QuantityB = BQuantity.Value;

                    string Query = "update Book set tenSach = N'{0}',tacGia = N'{1}',loaiSach = N'{2}',gia = N'{3}', soLuong = N'{4}' where id = {5} ";
                    Query = string.Format(Query, NameB, AuthorB, TypeB, PriceB, QuantityB, BooksList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Đã cập nhật thông tin sách";
                    BName.Value = "";
                    BAuthor.Value = "";
                    BType.Value = "";
                    BPrice.Value = "";
                    BQuantity.Value = "";
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
                if (BName.Value == "" || BAuthor.Value == "" || BType.Value == "" || BPrice.Value == "" || BQuantity.Value == "")
                {
                    ErrMsg.Text = "Bạn chưa chọn nội dung muốn xóa!!!";
                }
                else
                {
                    string NameB = BName.Value;
                    string AuthorB = BAuthor.Value;
                    string TypeB = BType.Value;
                    string PriceB = BPrice.Value;
                    string QuantityB = BQuantity.Value;

                    string Query = "delete from Book where id = {0} ";
                    Query = string.Format(Query, BooksList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Đã xóa thông tin sách";
                    BName.Value = "";
                    BAuthor.Value = "";
                    BType.Value = "";
                    BPrice.Value = "";
                    BQuantity.Value = "";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        protected void SearchBookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBook.Value.Trim();

                // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Tạo truy vấn SQL để tìm kiếm sách theo tên sách
                    string query = "SELECT * FROM Book WHERE tenSach LIKE N'%" + searchText + "%'";

                    // Gọi hàm GetData và gán kết quả cho GridView BooksList
                    BooksList.DataSource = Conn.GetData(query);
                    BooksList.DataBind();
                    
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách sách
                    ShowBooks();
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void BooksList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BooksList.PageIndex = e.NewPageIndex;
            ShowBooks(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }

    }
}