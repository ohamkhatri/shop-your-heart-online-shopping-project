<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="OnlineShopping.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Registration.css" rel="stylesheet" type="text/css">
    <div class="box">
        <table  class="content">
            <tr>
                <td> <asp:Label ID="Category_Id" runat="server" Text="Category Name"></asp:Label></td>
                <td> <asp:DropDownList ID="ddl_CatName" runat="server"  class="field" OnSelectedIndexChanged="ddl_Cat_id_SelectedIndexChanged">
                    <asp:ListItem text="Select Category"  class="field" Value="0" ></asp:ListItem>
                     </asp:DropDownList></td>
            </tr>
            <tr>
                <td> <asp:Label ID="lbl_ProdName" runat="server" Text="Product name"></asp:Label></td>
                <td> <asp:TextBox ID="txt_ProdName" class="field" runat="server"></asp:TextBox></td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_ProdDesc" runat="server" Text="Description"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_ProdDesc" class="field" runat="server"></asp:TextBox></td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Price" runat="server" Text="Price"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_Price" class="field" runat="server"></asp:TextBox></td>
                </tr>

            <tr>
                <td>
                    <asp:Label ID="Lbl_Availability" runat="server" Text="Availability"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_Availability" class="field" runat="server"></asp:TextBox></td>
                </tr>

            <tr>
                <td>
                    <asp:Label ID="lbl_MinQty" runat="server" Text="Minimum Quantity"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_MinQty" class="field" runat="server"></asp:TextBox></td>
                </tr>

            <tr>
                <td>
                    <asp:Label ID="lbl_MaxQty" runat="server" Text="Maximum Quantity"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_MaxQty"  class="field"   runat="server"></asp:TextBox></td>
                </tr>
            



            <tr>
                <td><asp:Label ID="lblProdimg" runat="server" Text="Product Image"></asp:Label></td>
                <td>
                        <asp:FileUpload ID="imgfile" runat="server" class="btn" />

                    
                    
                </td>
            </tr>
           
            </table>
        <asp:Button ID="btn_AddProd" runat="server" class="btn"  Text="Add"  OnClick="btn_AddProd_Click"/>
        </div>
</asp:Content>
