<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="OnlineShopping.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Category.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<img src="Productimages/08092022_fridge.png" />--%>
   
    <div runat="server" class="box">
        <div runat="server" class="lbl1">
            <asp:Label ID="Catname"   runat="server" Text="Category Name" Font-Bold="True" ForeColor="#FFBF00"></asp:Label>
        </div>
     
    
    <asp:TextBox ID="txt_Cat_name" class="field1" placeholder="enter category" runat="server"></asp:TextBox>
    <asp:Button ID="btn_CreateCategory" runat="server" class="btn" Text="Save Category" OnClick="btn_CreateCategory_Click"  />
    </div>
    

    <div runat="server" class="content">
        <div runat="server" class="content">
        <asp:TextBox runat="server" ID="txtcatsearch" class="field" placeholder="Search Category"></asp:TextBox>
        <asp:Button runat="server" Text="Search" ID="btncatsearch" class="btn" OnClick="btncatsearch_Click" />
        </div>
        <asp:GridView ID="dgvCategoryMaster" runat="server" class="content" PageSize="10" AllowPaging="True" GridLines="None" AlternatingRowStyle-ForeColor="#161616" PagerStyle-ForeColor="#ffbf00" AlternatingRowStyle-BackColor="#ffbf00" AutoGenerateColumns="false"  OnPageIndexChanging="dgvCategoryMaster_PageIndexChanging"  >
        <RowStyle Height="35px" />
         
            <Columns >
            <asp:BoundField DataField="Cat_id" HeaderText="CategoryId" HeaderStyle-ForeColor="#ffbf00" />
            <asp:BoundField DataField="Cat_Name" HeaderText="CategoryName"  HeaderStyle-ForeColor="#ffbf00" />
            <asp:BoundField DataField="AddedOn" HeaderText="AddedOn"  HeaderStyle-ForeColor="#ffbf00" />
        </Columns>   
            
        </asp:GridView>
    </div>



 </asp:Content>
