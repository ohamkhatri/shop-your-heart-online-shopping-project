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
    public partial class WebForm11 : System.Web.UI.Page
    {
        bal objbal = new bal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] != Session["Admin"])
            {
                //btn_AddProd.Visible = false;
                Page.Master.FindControl("btnCategory").Visible = false;
                Page.Master.FindControl("btnProduct").Visible = false;
                Page.Master.FindControl("btnloginhistory").Visible = false;
                

            }
            Page.Master.FindControl("btnorders").Visible = false;
            showorders();
        }


        public void showorders()
        {
            grdv_orders.DataSource = objbal.displayords(Session["UserDetails"].ToString());
            grdv_orders.DataBind();
        }

        protected void grdv_orders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdv_orders.PageIndex = e.NewPageIndex;
            this.showorders();
        }
    }
}