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
    public partial class WebForm7 : System.Web.UI.Page
    {
        bal objbal= new bal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                ViewState["ResetErros"] = 0;
            Page.Master.FindControl("menubar").Visible = false;
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            int result;

            Reset_pass rs = new Reset_pass();
            rs.Useremail = txtresetemail.Text.ToString();
            rs.Password = txtresetpass.Text.ToString();
            rs.newPassword=txtnewpass.Text.ToString();
            result = objbal.reset_pass(rs.Useremail,rs.Password,rs.newPassword);
            if (result == -1)
            {
                lbl_reset.ForeColor = System.Drawing.Color.Yellow;
                lbl_reset.Text = "Invalid Email or Password";

            }
            else
            {
                lbl_reset.ForeColor = System.Drawing.Color.Yellow;

                lbl_reset.Text = "Reset Successful";
            }
        }
    }
}