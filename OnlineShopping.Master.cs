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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                //if (Session["UserDetails"].ToString().Contains("Guest") || Session["UserDetails"].ToString().Contains("")) {
                //btn_logout.Visible = false;
            
            
        }

        protected void btnaboutus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Aboutus.aspx");
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Deshboard.aspx");
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Category.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductAdd.aspx");
        }

        protected void btnloginhistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Loginhistory.aspx");
        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ResetPass.aspx");
        }

        protected void btnorders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders.aspx");
        }

        protected void btncart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shoppingcart.aspx");
        }

        //protected void btn_logout_Click(object sender, EventArgs e)
        //{
        //    bal objbal = new bal();

        //    objbal.Update_Logout_(0, Session["UserDetails"].ToString());
        //    Session.Abandon();
        //    Response.Redirect("~/Login.aspx");
        //}
    }
}