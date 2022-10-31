<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Shoppingcart.aspx.cs" Inherits="OnlineShopping.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="shopppingcart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div runat="server" class="content">
        <asp:GridView runat="server" PagerStyle-ForeColor="#ffbf00" AlternatingRowStyle-BackColor="#ffbf00"  AlternatingRowStyle-ForeColor="#161616" class="box" AllowPaging="true" AutoGenerateColumns="false" PageSize="5" ID="grdvcart" OnPageIndexChanging="grdvcart_PageIndexChanging">
            <Columns >
                <asp:BoundField DataField="Prod_id" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" HeaderText="Product Id" runat="server" />
                <asp:BoundField DataField="Prod_Name" HeaderText="Product Name" runat="server" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
                <asp:BoundField DataField="Prod_descp" HeaderText="Description" runat="server" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00"/>
                <asp:BoundField DataField="Price"  HeaderText="Price"  runat="server" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
                
                <asp:ImageField runat="server" DataImageUrlField="productimage" HeaderText="Image" ControlStyle-Height="150px" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" ></asp:ImageField>
               <asp:BoundField runat="server" DataField="Quantity" HeaderText="Quantity" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
                
                <%--<asp:TemplateField runat="server">
                    <ItemTemplate>
                        <asp:TextBox runat="server"  ID="txtqtybuy"  Text="<%#Eval("Quantity") %>"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
                <%--<asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqtybuy" runat="server" Text='<%# Eval("Quantity") %>' Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                </asp:TemplateField>--%>
                
                
                <asp:TemplateField runat="server"  HeaderText="Select" HeaderStyle-ForeColor="#ffbf00">
                    <ItemTemplate runat="server">
                        <asp:CheckBox runat="server" ID="chkcart" ControlStyle-Width="150px" HeaderStyle-ForeColor="#ffbf00" />
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>

        </asp:GridView>
        <asp:Label runat="server" class="content" ID="lbl_total"></asp:Label>
    </div>
    <div runat="server" class="content">
        <asp:Button ID="btn_order" class="btn" Text="Order" runat="server" OnClick="btn_order_Click" />
        <asp:Button ID="removeprod" Text="Remove" class="btn" runat="server" OnClick="removeprod_Click" />
    </div>



</asp:Content>
