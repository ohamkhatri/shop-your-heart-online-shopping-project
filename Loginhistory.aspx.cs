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
    public partial class WebForm8 : System.Web.UI.Page
    {   
        bal objbal =new bal();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("btnloginhistory").Visible = false;
            if (!IsPostBack)
            {
                ViewState["LoginhistoryErrors"] = 0;
                showhistory();
            }
        }
        public void showhistory()
        {
            grdvLoginhistory.DataSource = objbal.loginhistory();
            grdvLoginhistory.DataBind();
        }

        protected void grdvLoginhistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvLoginhistory.PageIndex= e.NewPageIndex;
            this.showhistory();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            grdvLoginhistory.DataSource = objbal.searchlogin(txtsearch.Text.ToString());
            grdvLoginhistory.DataBind();
        }
        
    }
}