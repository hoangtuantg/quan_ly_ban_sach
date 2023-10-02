<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BTL_Web2_Nhom11.Views.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
            <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Quản lý tài khoản</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Email</label>
                    <input type="text" placeholder="Email ..." autocomplete="off" class="form-control" runat="server" id="Email"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Password</label>
                    <input type="text" placeholder="Password ..." autocomplete="off" class="form-control" runat="server" id="Pass"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">User Role</label>
                    <asp:DropDownList  runat="server" CssClass="form-control" id="Role">
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                    </asp:DropDownList>
                </div>



                <div class="row">
                   
                    <div class="col d-grid">
                        <asp:Button Text="Sửa" runat="server" id="UPDATEBtn" class="btn-primary btn-block btn" OnClick="UPDATEBtn_Click" />
                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Thêm mới" runat="server" id="ADDBtn" class="btn-success btn-block btn" OnClick="ADDBtn_Click" />

                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Xóa" runat="server" id="DELETEBtn" class="btn-danger btn-block btn" OnClick="DELETEBtn_Click" />

                    </div>

                    <asp:Label runat="server" ID="ErrMsg" class="text-danger"></asp:Label>
                </div>
            </div>

            <div class="col-md-8">
                <div class="mb-3">
                    <label for="txtSearchAuthor" class="form-label text-success">Tìm kiếm tác giả</label>
                    <input type="text" placeholder="Tìm kiếm tài khoản ..." autocomplete="off" class="form-control" runat="server" id="txtSearchUser"/>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Tìm kiếm" runat="server" ID="btnSearchUser" class="btn-info btn-block btn" Width="100" OnClick="btnSearchAuthor_Click"/>
                </div>

                <asp:GridView ID="UsersList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="UsersList_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="UsersList_PageIndexChanging">
                  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="#333333"/>

                </asp:GridView>
                
            </div>
        </div>
    </div>
</asp:Content>
