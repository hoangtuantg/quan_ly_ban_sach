<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User/SellerMaster.Master" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="BTL_Web2_Nhom11.Views.User.HoaDon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var PGrid = document.getElementById('<%=Billist.ClientID %>');
            PGrid.bordr = 0;
            var dateInput = document.getElementById('<%=DateTb.ClientID %>');
            var dateValue = dateInput.value;
        var PWin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height-768,toolbar=0,scrolbarrs=0,status=0,resizeable=1');
        PWin.document.write('<html><head><title>Bill</title></head><body>');
        PWin.document.write(PGrid.outerHTML);
        PWin.document.write('<p><%=GrdTotalTb.Text %></p>');
            PWin.document.write('</body></html>');
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
    <div class="container-fluid">
        <div class="row">

        </div>

        <div class="row">
            <div class="col-md5">
                <h3 class="text-center">Thông tin sách</h3>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Tên Sách</label>
                            <input type="text" placeholder="Tên Sách" autocomplete="off" runat="server" class="form-control" id="BNameTb"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Giá sách</label> 
                            <input type="text" placeholder="Giá Sách" autocomplete="off" runat="server" class="form-control" id="BPriceTb"/>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Số lượng</label>
                            <input type="text" placeholder="Số lượng" autocomplete="off" runat="server" class="form-control" id="BQyTb"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label ">Ngày thanh toán</label>
                            <input type="date" runat="server" class="form-control" id="DateTb" />
                        </div>
                    </div>
                </div>
                <div class="row-mt-3">
                            <div class="col d-grid">
                                <asp:Label runat="server" ID="ErroTb" class="text-danger text-center"></asp:Label><br />
                                <asp:Button Text="Thêm vào hoá đơn" runat="server" id="AddToBill" class="btn-primary btn-block btn" OnClick="AddToBill_Click1"  />
                            </div>
                        </div> 
                    <div class="row-mt-5">
                         <label for="txtSearchAuthor" class="form-label text-success">Tìm kiếm tên sách</label><br />
                         <input type="text" placeholder="Tìm kiếm tên sách..." autocomplete="off" class="form-control" runat="server" id="txtSearchBook"/>
                        
                        <div class="d-grid">
                           <asp:Button Text="Tìm kiếm" runat="server" ID="btnSearchBook" class="btn-info btn-block btn" Width="100" OnClick="btnSearchBook_Click"/>
                        </div>
                        <h6 class="text-center">Danh sách</h6>
                        <div class="col">
                            <asp:GridView ID="BooksList" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged" AutoPostBack="true" AllowPaging="True" PageSize="3" OnPageIndexChanging="BooksList_PageIndexChanging">
                                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="#333333"/>
                             </asp:GridView>
                        </div>
                    </div>
            </div>
            <div class="col-md7">
                <h3 class="text-center">Danh sách thanh toán</h3>
                    <div class="col">
                        <asp:GridView ID="Billist" runat="server" class="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged">
                             <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="true" ForeColor="#333333"/>
                         </asp:GridView>

                        <div class="d-grid">
                            <asp:Label runat="server" ID="GrdTotalTb" class="text-danger text-center"></asp:Label><br />
                            <asp:Button Text="In hoá đơn" runat="server" id="Printbtn" class="btn-primary btn-block btn" OnClientClick="PrintBill()"  />
                        </div>
                    </div>
            </div>
        </div>
</div>
</asp:Content>
