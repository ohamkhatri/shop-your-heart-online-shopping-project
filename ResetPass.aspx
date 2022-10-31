<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="OnlineShopping.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="Login.css" rel="stylesheet" type="text/css">
    <div class="box">
        <div class="content">

            <h1>Reset Password</h1>

            <asp:TextBox ID="txtresetemail" runat="server" placeholder="Email ID" class="field"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfd_email" runat="server" ControlToValidate="txtresetemail" ErrorMessage="Email Required" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="red_email" runat="server" ErrorMessage="Invalid Email" Display="Dynamic" ControlToValidate="txtresetemail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


            <asp:TextBox ID="txtresetpass" class="field"  placeholder="Old Password" runat="server" TextMode="Password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfd_oldpass" runat="server" ControlToValidate="txtresetpass" Display="Dynamic" ErrorMessage="Old Password Required"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="red_oldpass" runat="server" ErrorMessage="should be 8-12 characters" Display="Dynamic" ControlToValidate="txtresetpass" ValidationExpression="^[\s\S]{8,12}$"></asp:RegularExpressionValidator>

            <asp:TextBox ID="txtnewpass" class="field" placeholder="New Password"  runat="server" TextMode="Password"></asp:TextBox>

            <asp:RegularExpressionValidator ID="red_newpass" runat="server" ErrorMessage="should be 8-12 characters" ControlToValidate="txtnewpass" ValidationExpression="^[\s\S]{8,12}$" Display="Dynamic"></asp:RegularExpressionValidator>

            <asp:RequiredFieldValidator ID="rfd_newpass" runat="server" ControlToValidate="txtnewpass" ErrorMessage="New Password required" Display="Dynamic"></asp:RequiredFieldValidator>


            <asp:Label ID="lbl_reset" runat="server" ></asp:Label>

            <asp:Button ID="btn_reset" class="btn" runat="server" Text="Reset" OnClick="btn_reset_Click" />





        </div>
    </div>

</asp:Content>
