using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BTL_Web2_Nhom11.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        // Khai báo biến Conn
        private Models.Functions Conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new Models.Functions();

            if (!IsPostBack)
            {
                ShowSellers();
            }
        }

        private void ShowSellers()
        {
            string Query = "Select * from Seller";
            SellersList.DataSource = Conn.GetData(Query);
            SellersList.DataBind();
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellName.Value == "" || SellEmail.Value == "" || SellPhone.Value == "" || SellAd.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string SName = SellName.Value;
                    string SEmail = SellEmail.Value;
                    string SPhone = SellPhone.Value;
                    string SAd = SellAd.Value;

                    string Query = "insert into Seller values( N'{0}', N'{1}', N'{2}', N'{3}') ";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAd);
                    Conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Đã thêm mới nhân viên";
                    SellName.Value = "";
                    SellEmail.Value = "";
                    SellPhone.Value = "";
                    SellAd.Value = "";

                }
            }
            catch (Exception Ex)
            {

                ErrMsg.Text = Ex.Message;
            }
        }

        int Key = 0;

        protected void SellersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SellName.Value = SellersList.SelectedRow.Cells[2].Text;
            //SellEmail.Value = SellersList.SelectedRow.Cells[3].Text;
            //SellPhone.Value = SellersList.SelectedRow.Cells[4].Text;
            //SellAd.Value = SellersList.SelectedRow.Cells[5].Text;

            SellName.Value = HttpUtility.HtmlDecode(SellersList.SelectedRow.Cells[2].Text);
            SellEmail.Value = HttpUtility.HtmlDecode(SellersList.SelectedRow.Cells[3].Text);
            SellPhone.Value = HttpUtility.HtmlDecode(SellersList.SelectedRow.Cells[4].Text);
            SellAd.Value = HttpUtility.HtmlDecode(SellersList.SelectedRow.Cells[5].Text);


            if (SellName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellersList.SelectedRow.Cells[1].Text);
            }
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellName.Value == "" || SellEmail.Value == "" || SellPhone.Value == "" || SellAd.Value == "")
                {
                    ErrMsg.Text = "Không được để trống. Hãy nhập hoặc chọn lại!!!";
                }
                else
                {
                    string SName = SellName.Value;
                    string SEmail = SellEmail.Value;
                    string SPhone = SellPhone.Value;
                    string SAd = SellAd.Value;

                    string Query = "update Seller set tenNhanVien = N'{0}', email = N'{1}', sdt = N'{2}', diaChi = N'{3}' where id = {4} ";
                    Query = string.Format(Query, SName, SEmail, SPhone, SAd, SellersList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Đã cập nhật thông tin nhân viên";
                    SellName.Value = "";
                    SellEmail.Value = "";
                    SellPhone.Value = "";
                    SellAd.Value = "";

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
                if (SellName.Value == "" || SellEmail.Value == "" || SellPhone.Value == "" || SellAd.Value == "")
                {
                    ErrMsg.Text = "Bạn chưa chọn nội dung muốn xóa!!!";
                }
                else
                {
                    string SName = SellName.Value;
                    string SEmail = SellEmail.Value;
                    string SPhone = SellPhone.Value;
                    string SAd = SellAd.Value;

                    string Query = "delete from Seller where id = {0}";
                    Query = string.Format(Query, SellersList.SelectedRow.Cells[1].Text);
                    Conn.SetData(Query);
                    ShowSellers();
                    ErrMsg.Text = "Đã xóa nhân viên";
                    SellName.Value = "";
                    SellEmail.Value = "";
                    SellPhone.Value = "";
                    SellAd.Value = "";

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
                string searchText = txtSearchSeller.Value.Trim();

                // Kiểm tra xem đã nhập từ khóa tìm kiếm hay chưa
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Tạo truy vấn SQL để tìm kiếm nhân viên theo tên nhân viên
                    string query = "SELECT * FROM Seller WHERE tenNhanVien LIKE N'%" + searchText + "%'";

                    // Gọi hàm GetData và gán kết quả cho GridView SellersList
                    SellersList.DataSource = Conn.GetData(query);
                    SellersList.DataBind();
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ danh sách nhân viên
                    ShowSellers();
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void SellersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SellersList.PageIndex = e.NewPageIndex;
            ShowSellers(); // Gọi hàm hiển thị dữ liệu của bạn lại
        }
    }
}