<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Loginhistory.aspx.cs" Inherits="OnlineShopping.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoginHistory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div runat="server" class="content">
        <asp:TextBox runat="server" ID="txtsearch" placeholder="Search record" class="field"> </asp:TextBox>
        <asp:Button runat="server" ID="btnsearch" class="btn" OnClick="btnsearch_Click" Text="search" />
        <asp:GridView runat="server" AllowPaging="true" class="content"  ID="grdvLoginhistory" PageSize="20" PagerStyle-ForeColor="#ffbf00" AlternatingRowStyle-BackColor="#ffbf00" GridLines="None" AlternatingRowStyle-ForeColor="#161616" AutoGenerateColumns="false" OnPageIndexChanging="grdvLoginhistory_PageIndexChanging" >
            <RowStyle Height="35px" />
            <Columns >
                <asp:BoundField  DataField="UserLoginId" HeaderText="UserLoginId" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="UserDetailId" HeaderText="UserDetailId" HeaderStyle-ForeColor="#ffbf00" />
                <asp:BoundField DataField="LoginDate" HeaderText="LoginDate" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="LogoutDate" HeaderText="LogoutDate" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="User_Email" HeaderText="User_Email" HeaderStyle-ForeColor="#ffbf00"/>

            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
