using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShopping.AppCode;

namespace OnlineShopping
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                //Page.Master.FindControl("tblMenu").Visible=false;
            ViewState["LoginErrors"] = 0;
            Page.Master.FindControl("menubar").Visible = false;

        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bal adminBal = new bal();
            //int logout = adminBal.Login_activity(userLogin.UserName);
            if (adminBal.Login_activity(userLogin.UserName)> 0)
            {
                
                int rs = adminBal.Update_Logout_(0, userLogin.UserName);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your last session was not logged out please login again');", true);
                
                Response.Redirect("~/Login.aspx");
            }



            string LoginDtls= adminBal.AuthUser(userLogin.UserName, userLogin.Password);
            if(!string.IsNullOrEmpty(LoginDtls))
            {
                if (LoginDtls.Contains("Oham.khatri20@gmail.com")){
                    Session["Admin"] = LoginDtls;
                }
                Session["UserDetails"] = LoginDtls;
                /**/
                Response.Redirect("/DeshBoard.aspx");
            }

        }

        protected void Register(object sender, EventArgs e)
        {
            Response.Redirect("/Registration.aspx");
        }

        protected void Guest(object sender, EventArgs e)
        {
            Session["UserDetails"] = "Guest";
            Response.Redirect("/DeshBoard.aspx");
            
        }

        protected void btn_forgot_pass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResetPass.aspx");
        }
    }
}