<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineShopping.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head"   runat="server"  >
    <link href="Login.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"   runat="server">
    <div class="box"  >
       <div class="content">
           <h1>Registration</h1>
    

    <asp:TextBox ID="txt_Username" runat="server" class="field" placeholder="Username"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Username" Display="Dynamic" ErrorMessage="Enter Username"></asp:RequiredFieldValidator>
    
    <asp:TextBox ID="txt_Mobile" runat="server" class="field" placeholder="Mobile Number" ></asp:TextBox>

   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Mobile" Display="Dynamic" ToolTip="Number is required" ErrorMessage="Enter Mobile number"></asp:RequiredFieldValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_Mobile" Display="Dynamic" ValidationExpression="^[\s\S]{10,10}$" runat="server" ErrorMessage="Invalid Number "></asp:RegularExpressionValidator>
   
    <asp:TextBox ID="txt_UserEmail" class="field" placeholder="Email" runat="server"></asp:TextBox>

   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_UserEmail" Display="Dynamic" tooltip="Email is required" ErrorMessage="Enter Email "></asp:RequiredFieldValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_UserEmail" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email Format "></asp:RegularExpressionValidator>
   
    <asp:TextBox ID="txt_pass" class="field" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_pass" Display="Dynamic" ErrorMessage="Password is required "></asp:RequiredFieldValidator>
    
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_pass" Display="Dynamic" ValidationExpression="^[\s\S]{8,12}$" ErrorMessage="should be 8-12 characters " ></asp:RegularExpressionValidator>

   
     <asp:TextBox ID="txt_Addr" class="field" placeholder="Address" runat="server"></asp:TextBox>
    
      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ToolTip="Enter Address" Display="Dynamic" ControlToValidate="txt_Addr" ErrorMessage  ="Enter Address"></asp:RequiredFieldValidator>

      <asp:Button ID="btm_register" class="btn" runat="server" Text="Register" OnClick="btm_register_Click" />
    
    <asp:Button ID="btn_Cancel" runat="server" class="btn" Text="Cancel" CausesValidation="false"  OnClick="btn_Cancel_Click1" />
       
    
    
    </div>
    </div>
       
    
    
    <!-- <asp:Button ID="Button1" runat="server" Text="Register" OnClick="btm_register_Click" />
    
    <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false"  OnClick="btn_Cancel_Click1" />-->
   
    

</asp:Content>
