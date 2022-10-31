
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShopping.AppCode;
using OnlineShopping.User;

namespace OnlineShopping
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        bal objbal=new bal();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                ViewState["RegisterErrors"] = 0;
            Page.Master.FindControl("menubar").Visible = false;
        }

        protected void btm_register_Click(object sender, EventArgs e)
        {

            /* logic for existing user*/
            /*
             start
            
            check if  user exists in database table user or not 
            if(yes)
            show error message
            else 
            register user
             
             */
            


            registerUser registerUser = new registerUser();
            registerUser.User_Name = txt_Username.Text.ToString();
            registerUser.Mob_no = Convert.ToDecimal(txt_Mobile.Text);
            registerUser.email = txt_UserEmail.Text.ToString();
            registerUser.password = txt_pass.Text.ToString();
            registerUser.Address = txt_Addr.Text.ToString();
            registerUser.CreatedBy = 0;
            if (objbal.CheckUser(registerUser).Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('User already Register');", true);
                //Response.Redirect("/Registration.aspx");
                return;
               
            }
            else
            {
                

                string values = objbal.RegisterUser(registerUser);
                Session["UserDetails"] = "Register";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registration successful');", true);
                Response.Redirect("/Login.aspx");
            }

        }

        

        protected void btn_Cancel_Click1(object sender, EventArgs e)
        {
            
           
            Response.Redirect("~/Login.aspx");
        }
    }
}