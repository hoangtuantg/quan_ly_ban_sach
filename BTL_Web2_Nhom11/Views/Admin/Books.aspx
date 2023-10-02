<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BTL_Web2_Nhom11.Views.Admin.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Quản lý bán sách</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Tên sách</label>
                    <input type="text" placeholder="Tên sách ..." autocomplete="off" class="form-control" runat="server" id="BName"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Tác giả</label>
                    <input type="text" placeholder="Tác giả ..." autocomplete="off" class="form-control" runat="server" id="BAuthor"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Thể loại</label>
                    <input type="text" placeholder="Thể loại ..." autocomplete="off" class="form-control" runat="server" id="BType"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Gía tiền</label>
                    <input type="text" placeholder="Gía tiền ..." autocomplete="off" class="form-control" runat="server" id="BPrice"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Số lượng</label>
                    <input type="text" placeholder="Số lượng ..." autocomplete="off" class="form-control" runat="server" id="BQuantity"/>
                </div>

                <div class="row">
                    <div class="col d-grid">
                        <asp:Button Text="Sửa" runat="server" id="UpdateBtn" class="btn-primary btn-block btn" OnClick="UpdateBtn_Click" />
                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Thêm mới" runat="server" id="AddBtn" class="btn-success btn-block btn" OnClick="AddBtn_Click" />

                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Xóa" runat="server" id="DeleteBtn" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" />

                    </div>

                    <asp:Label runat="server" ID="ErrMsg" class="text-danger"></asp:Label>
                </div>
            </div>

            <div class="col-md-8">
                <div class="mb-3">
                    <label for="txtSearchBook" class="form-label text-success">Tìm kiếm sách</label>
                    <input type="text" placeholder="Tìm kiếm sách ..." autocomplete="off" class="form-control" runat="server" id="txtSearchBook" />
                </div>

            <asp:Button Text="Tìm kiếm" runat="server" ID="SearchBookBtn"  class="btn-info btn-block btn" width="100" OnClick="SearchBookBtn_Click"/> </br>

                <asp:GridView ID="BooksList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BooksList_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="BooksList_PageIndexChanging">
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
