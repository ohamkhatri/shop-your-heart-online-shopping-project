<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="OnlineShopping.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="shopppingcart.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<br />
    <div runat="server" class="content">
        <asp:GridView runat="server" class="box" ID="grdv_orders" PagerStyle-ForeColor="#ffbf00"  AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdv_orders_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Order_No" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" HeaderText="Order No" />
                <asp:BoundField  DataField="Prod_id" HeaderText="Product id" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField  DataField="Prod_Name" HeaderText="Product Name" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
                <asp:BoundField  DataField="price" HeaderText="Price" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField  DataField="Total" HeaderText="Total" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="Order_Date" HeaderText="Date" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
