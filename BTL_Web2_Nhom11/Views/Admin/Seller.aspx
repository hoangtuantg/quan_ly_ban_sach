<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="BTL_Web2_Nhom11.Views.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
                <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Quản lý nhân viên bán hàng</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Tên nhân viên</label>
                    <input type="text" placeholder="Tên nhân viên ..." autocomplete="off" class="form-control" runat="server" id="SellName"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Email</label>
                    <input type="text" placeholder="Email ..." autocomplete="off" class="form-control" runat="server" id="SellEmail"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Số điện thoại</label>
                    <input type="text" placeholder="SDT ..." autocomplete="off" class="form-control" runat="server" id="SellPhone"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Địa chỉ</label>
                    <input type="text" placeholder="Địa chỉ ..." autocomplete="off" class="form-control" runat="server" id="SellAd"/>
                </div>

                <div class="row">
                   
                    <div class="col d-grid">
                        <asp:Button Text="Sửa" runat="server" id="updatebtn" class="btn-primary btn-block btn" OnClick="updatebtn_Click" />
                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Thêm mới" runat="server" id="addbtn" class="btn-success btn-block btn" OnClick="addbtn_Click" />

                    </div>

                    <div class="col d-grid">
                        <asp:Button Text="Xóa" runat="server" id="deletebtn" class="btn-danger btn-block btn" OnClick="deletebtn_Click"/>

                    </div>

                    <asp:Label runat="server" ID="ErrMsg" class="text-danger"></asp:Label>
                </div>
            </div>

            <div class="col-md-8">
                                <div class="mb-3">
                    <label for="txtSearchSeller" class="form-label text-success">Tìm kiếm nhân viên</label>
                    <input type="text" placeholder="Tìm kiếm nhân viên ..." autocomplete="off" class="form-control" runat="server" id="txtSearchSeller" />
                </div>

                <asp:Button Text="Tìm kiếm" runat="server" ID="SearchBookTypeBtn" class="btn-info btn-block btn" Width="100" OnClick="SearchBookTypeBtn_Click" />
                </br>
                <asp:GridView ID="SellersList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SellersList_SelectedIndexChanged"  AllowPaging="True" PageSize="4" OnPageIndexChanging="SellersList_PageIndexChanging">
                  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="black"/>

                </asp:GridView>
                
            </div>
        </div>
    </div>
</asp:Content>
