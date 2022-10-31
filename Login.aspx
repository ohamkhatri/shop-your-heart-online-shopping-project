<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopping.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineShopping.WebForm1" Theme="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

             
<link href="Login.css" rel="stylesheet" type="text/css">
    
  
        <asp:Login ID="userLogin"  runat="server" OnAuthenticate="Login1_Authenticate"  Width="100%" >
            <LayoutTemplate>
               <div class="box">
                   <div class="content">

                       <h1>Login Required</h1>
                       <!-- <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>-->
                                 
                         <asp:TextBox ID="UserName" runat="server" class="field"  placeholder="User Email"></asp:TextBox>
                         
                       <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="userLogin">*</asp:RequiredFieldValidator>
                                   
                       <!-- <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>-->
                                  
                         <asp:TextBox ID="Password" class="field" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                       
                       <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="userLogin">*</asp:RequiredFieldValidator>
                                   
                      <!-- <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />-->
                                    
                       <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>

                       
                                   
                      <asp:Button ID="LoginButton" CssClass="btn" runat="server" CommandName="Login"  Text="Log In" ValidationGroup="userLogin" />
                                    



                    <asp:Button runat="server" Text="Register" class="btn" OnClick="Register"  />
       
                       <asp:Button ID="Button1" runat="server"  class="btn"     Text="Guest" OnClick="Guest" />
     
                       <asp:Button ID="btn_forgot_pass" runat="server" Text="Reset Password" class="btn"  OnClick="btn_forgot_pass_Click"/>

                   </div>
               </div>
                                       
            </LayoutTemplate>

        </asp:Login >
      
         
        
        
       <!--  <asp:Button runat="server" Text="Register" OnClick="Register" Width="99px" Font-Bold="true" Font-Size="1.0em" />
        <asp:Button ID="Button1" runat="server" Text="Guest" OnClick="Guest" Width="100px"  Font-Bold="true" Font-Size="1.0em"/>-->
     
    










   <!-- <br />
    <br />
        <div>
            <asp:Button ID="btn_forgot_pass" runat="server" Text="Forgot Password"  OnClick="btn_forgot_pass_Click"/>
            </div>

    -->


   




</asp:Content>
