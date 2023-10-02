using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web2_Nhom11.Views.User
{
    public partial class HoaDon : System.Web.UI.Page
    {
        Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Price", typeof(decimal)),
                new DataColumn("Quantity", typeof(int)),
                new DataColumn("Total", typeof(decimal))
            });

                ViewState["Bill"] = dt;
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Billist.DataSource = ViewState["Bill"];
            Billist.DataBind();
        }

        private void ShowBooks()
        {
            string Query = "Select id as Code, tenSach as Name,gia as Price,soLuong as Stock from Book";
            BooksList.DataSource = Conn.GetData(Query);
            BooksList.DataBind();
        }

        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BooksList.SelectedIndex != -1)
            {
                BNameTb.Value = HttpUtility.HtmlDecode(BooksList.Rows[BooksList.SelectedIndex].Cells[2].Text);
                Stock = Convert.ToInt32(BooksList.Rows[BooksList.SelectedIndex].Cells[4].Text);
                BPriceTb.Value = HttpUtility.HtmlDecode(BooksList.Rows[BooksList.SelectedIndex].Cells[3].Text);

                if (BNameTb.Value == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(BooksList.Rows[BooksList.SelectedIndex].Cells[1].Text);
                }
            }
        }

        protected void btnSearchBook_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBook.Value.Trim();

            // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
            if (!string.IsNullOrEmpty(searchText))
            {
                // Tạo truy vấn SQL để tìm kiếm sách theo tên sách
                string query = "SELECT id as Code, tenSach as Name, gia as Price, soLuong as Stock FROM Book WHERE tenSach LIKE '%" + searchText + "%'";

                // Gọi hàm GetData và gán kết quả cho GridView BooksList
                BooksList.DataSource = Conn.GetData(query);
                BooksList.DataBind();

                // Xóa dữ liệu trên các trường input khi thực hiện tìm kiếm
                BNameTb.Value = "";
                BPriceTb.Value = "";
                BQyTb.Value = "";
                Key = 0;
                Stock = 0;
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách sách
                ShowBooks();
            }
        }

        private void UpdateStock()
        {
            int NewQTy;
            NewQTy = Convert.ToInt32(BooksList.Rows[BooksList.SelectedIndex].Cells[4].Text) - Convert.ToInt32(BQyTb.Value);
            string Query = "UPDATE Book SET soLuong = {0} WHERE id = {1}";
            Query = string.Format(Query, NewQTy, BooksList.Rows[BooksList.SelectedIndex].Cells[1].Text);
            Conn.SetData(Query);
            ShowBooks();
        }

        int Stock = 0;
        int Key = 0;

        protected void AddToBill_Click1(object sender, EventArgs e)
        {
            if (BooksList.SelectedIndex == -1)
            {
                return; // Không có cuốn sách nào được chọn
            }

            int NewQTy;
            if (!int.TryParse(BQyTb.Value, out NewQTy) || NewQTy <= 0)
            {
                ErroTb.Text = "Số lượng phải là số nguyên và lớn hơn 0.";
                return;
            }

            int availableStock = Convert.ToInt32(BooksList.Rows[BooksList.SelectedIndex].Cells[4].Text);

            if (NewQTy > availableStock)
            {
                ErroTb.Text = "Số lượng không được lớn hơn tồn kho hiện có.";
                return;
            }

            decimal total = Convert.ToDecimal(BQyTb.Value) * Convert.ToDecimal(BPriceTb.Value);

            if (NewQTy <= availableStock)
            {
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(Billist.Rows.Count + 1,
                    BNameTb.Value.Trim(),
                    BPriceTb.Value.Trim(),
                    BQyTb.Value.Trim(),
                    total);

                ViewState["Bill"] = dt;
                BindGrid();
                UpdateStock();

                GrdTotal = 0;
                for (int i = 0; i < Billist.Rows.Count; i++)
                {
                    GrdTotal = GrdTotal + Convert.ToInt32(Billist.Rows[i].Cells[5].Text);
                }
                Amount = GrdTotal;
                GrdTotalTb.Text = "Tổng tiền:" + GrdTotal + "VND";
                BNameTb.Value = "";
                BPriceTb.Value = "";
                BQyTb.Value = "";
            }
        }

        int GrdTotal = 0;
        int Amount;

        protected void BooksList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BooksList.PageIndex = e.NewPageIndex;
            ShowBooks(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }
    }
}