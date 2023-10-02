<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="BTL_Web2_Nhom11.Views.Admin.Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Quản lý tác giả</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Tên tác giả</label>
                    <input type="text" placeholder="Tên tác giả ..." autocomplete="off" class="form-control" runat="server" id="AName"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Giới tính</label>
                    <asp:DropDownList  runat="server" CssClass="form-control" id="AGender">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Quốc tịch</label>
                    <input type="text" placeholder="Quốc tịch ..." autocomplete="off" class="form-control" runat="server" id="ACountry"/>
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
                    <label for="txtSearchAuthor" class="form-label text-success">Tìm kiếm tác giả</label>
                    <input type="text" placeholder="Tìm kiếm tác giả ..." autocomplete="off" class="form-control" runat="server" id="txtSearchAuthor"/>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Tìm kiếm" runat="server" ID="btnSearchAuthor" class="btn-info btn-block btn" Width="100" OnClick="btnSearchAuthor_Click"/>
                </div>

                <asp:GridView ID="AuthorsList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="AuthorsList_PageIndexChanging">
                  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="#333333"/>

                </asp:GridView>
                
            </div>
        </div>
    </div>
</asp:Content>
