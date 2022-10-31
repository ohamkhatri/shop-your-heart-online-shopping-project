<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="DeshBoard.aspx.cs" Inherits="OnlineShopping.DeshBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Deshboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- 
   <link href="Login.css" rel="stylesheet" type="text/css">--%> 

    <div runat="server" class="content">
    <asp:Button ID="btnLogout" class="btn" runat="server" Text="Logout"  OnClick="btnLogout_Click"/>
        <br />
        <br />
   
    <asp:Label runat="server" class="field" id="lblWelcome"></asp:Label>

</div>

    <div runat="server" class="content">
        
        <asp:DropDownList runat="server" ID="searchprodbycat" class="field"  OnSelectedIndexChanged="searchprod_SelectedIndexChanged" >
            <asp:ListItem Text="Select Category" style="text-align:center; " Value="0"></asp:ListItem>
        </asp:DropDownList>
        
        
        <asp:Button runat="server" class="btn" ID="searchbycat" Text="search by category" OnClick="searchbycat_Click" />
    </div>

   
    <div runat="server" class="content">
        <asp:TextBox ID="txt_searchprod" class="field" placeholder="Search Product" runat="server"></asp:TextBox>
        
        <asp:Button ID="btn_searchprod" runat="server"  class="btn" Text="Search" OnClick="btn_searchprod_Click"/>
    </div>
    <div runat="server" class="content">
    <asp:GridView runat="server" ID="grdvprodshow" PagerStyle-ForeColor="#ffbf00" AlternatingRowStyle-BackColor="#ffbf00"  AlternatingRowStyle-ForeColor="#161616" class="box" AllowPaging="true"  OnPageIndexChanging="grdvprodshow_PageIndexChanging" AutoGenerateColumns="false" PageSize="5" OnSelectedIndexChanged="grdvprodshow_SelectedIndexChanged"  >
        <RowStyle width="150px" Wrap="true" />
        <Columns >
           
            <asp:BoundField DataField="Prod_id" HeaderText="Product id"  runat="server" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
            <asp:BoundField DataField="Prod_Name" HeaderText="Product Name" HeaderStyle-ForeColor="#ffbf00" runat="server" />
            <asp:BoundField DataField="Prod_descp" HeaderText="Decsription" ControlStyle-Width="150px" ItemStyle-Wrap="true" runat="server" HeaderStyle-ForeColor="#ffbf00" />
            <asp:BoundField DataField="Price" HeaderStyle-ForeColor="#ffbf00" HeaderText="Price" runat="server" />
            <asp:ImageField runat="server" DataImageUrlField="productimage"  HeaderStyle-ForeColor="#ffbf00" HeaderText="Image"  ControlStyle-Height="150px" ControlStyle-Width="150px"></asp:ImageField>
            <asp:TemplateField runat="server" HeaderText="Quantity" HeaderStyle-ForeColor="#ffbf00">
                <ItemTemplate>
                    <asp:TextBox ID="txtqty" class="field1" placeholder="Quantity" runat="server" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                <asp:Label runat="server" ID="validqty"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField runat="server" HeaderStyle-ForeColor="#ffbf00" HeaderText="Select">
                <ItemTemplate runat="server">
                    <asp:CheckBox ID="chkselect" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
     
    </asp:GridView>
    </div>
    <asp:Button runat="server" Text="Add to Cart" ID="btnaddcart" class="btn" OnClick="btnaddcart_Click" />
   

    
    <%--<asp:Button ID="btn_Addcategory" runat="server" Text="Add Category" onclick="btn_Addcategory_Click" />--%>    
    
    <%--<asp:Button ID="btn_AddProd" runat="server" Text="Add Product " OnClick="btn_AddProd_Click" />--%>
</asp:Content>
