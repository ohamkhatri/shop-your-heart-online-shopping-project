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
    public partial class WebForm3 : System.Web.UI.Page
    {
        bal objbal = new bal();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("btnCategory").Visible = false;
            if (!IsPostBack)
            {
                ViewState["CategoryErrors"] = 0;
                ShowCategory();
            }
        }

        

        //protected void btn_AddProduct_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ProductAdd.aspx");
        //}

        protected void btn_CreateCategory_Click(object sender, EventArgs e)
            {
          //string v;
            
            Category Ct = new Category();
            Ct.Cat_Name=txt_Cat_name.Text.ToString();

             //v = objbal.AddProductCat(Ct).ToString();

            if (objbal.CheckProductCategory(Ct) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Category already Available');", true);
                return;
            }

            else
            {
                int val = objbal.AddProductCat(Ct);
                if (val > 0)
                {
                    ShowCategory();
                }
                //Session["CategoryDetails"] = "Category";
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registration successful');", true);
                Response.Redirect("~/Category.aspx");


            }

            //Session["UserDetails"] = "Register";
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registration successful');", true);
            //Response.Redirect("/Login.aspx");

        }

        public void ShowCategory()
        {
            bal adminbal = new bal();
            dgvCategoryMaster.DataSource=adminbal.GetCategory();
            dgvCategoryMaster.DataBind();

        }

        protected void dgvCategoryMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategoryMaster.PageIndex = e.NewPageIndex;
            this.ShowCategory();

        }

        protected void btncatsearch_Click(object sender, EventArgs e)
        {
            dgvCategoryMaster.DataSource = objbal.searchcategory(txtcatsearch.Text.ToString());
            dgvCategoryMaster.DataBind();
        }
        
    }
}