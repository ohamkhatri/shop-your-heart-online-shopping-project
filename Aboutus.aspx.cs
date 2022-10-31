using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShopping
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("btnaboutus").Visible = false;
            if (Session["UserDetails"] != Session["Admin"])
            {
                //btn_AddProd.Visible = false;
                Page.Master.FindControl("btnCategory").Visible = false;
                Page.Master.FindControl("btnProduct").Visible = false;
                Page.Master.FindControl("btnloginhistory").Visible = false;

                

            }
            if (Session["UserDetails"].ToString().Contains("Guest"))
            {
                //btnLogout.Visible = false;
                Page.Master.FindControl("btnResetPass").Visible = false;
                Page.Master.FindControl("btncart").Visible = false;
                Page.Master.FindControl("btnorders").Visible = false;

            }
        }
    }
}