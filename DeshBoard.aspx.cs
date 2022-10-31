using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShopping.User;
using OnlineShopping.AppCode;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;

namespace OnlineShopping
{
    public partial class DeshBoard : System.Web.UI.Page
    {
        bal objbal=new bal();
        protected void Page_Load(object sender, EventArgs e)
        
        {
            lblWelcome.Text = "Welcome "+ Session["UserDetails"].ToString();
            if (!IsPostBack)
            {
                
                showproduct();
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["OnlineShopping"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select Cat_Name, Cat_id from tblCategoryType", con);
                    con.Open();
                    searchprodbycat.DataSource = cmd.ExecuteReader();
                    searchprodbycat.DataTextField = "Cat_Name";
                    searchprodbycat.DataValueField = "Cat_id";
                    searchprodbycat.DataBind();

                }


            }
            if (Session["UserDetails"].ToString().Contains("Guest"))
            {
                btnLogout.Visible = false;
                Page.Master.FindControl("btnorders").Visible=false;
                Page.Master.FindControl("btnResetPass").Visible = false;
                Page.Master.FindControl("btncart").Visible = false; 



            }

            //if (Session["UserDetails"].ToString().Contains("Guest"))
            //        {

            //    btn_AddProd.Visible=false;

            //}
            if (Session["UserDetails"] != Session["Admin"])
            {
                //btn_AddProd.Visible = false;
                Page.Master.FindControl("btnCategory").Visible = false;
                Page.Master.FindControl("btnProduct").Visible = false;
                Page.Master.FindControl("btnloginhistory").Visible = false;
                

            }
            //showproduct();
        }
        public void showproduct()
        {
            grdvprodshow.DataSource = objbal.displayproduct();
            grdvprodshow.DataBind();
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            bal objbal = new bal();
            objbal.Update_Logout_(0, Session["UserDetails"].ToString());
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
            
        }

        //protected void btn_AddProd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ProductAdd.aspx");
        //}

        //protected void grdvprodshow_PageIndexChanged(object sender, GridViewPageEventArgs e)
        //{
        //    grdvprodshow.PageIndex = e.NewPageIndex;
        //    this.showproduct();

         
        //}

        protected void grdvprodshow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvprodshow.PageIndex = e.NewPageIndex;
             this.showproduct();
        }

        protected void searchprod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void searchbycat_Click(object sender, EventArgs e)
        {
            grdvprodshow.DataSource = objbal.searchbyddl(int.Parse(searchprodbycat.SelectedValue.ToString()));
            grdvprodshow.DataBind();
        }

        protected void btn_searchprod_Click(object sender, EventArgs e)
        {
            grdvprodshow.DataSource = objbal.searchbyname(txt_searchprod.Text.ToString());
            grdvprodshow.DataBind();
        }

        protected void btnaddcart_Click(object sender, EventArgs e)
        {
            //ArrayList cartprod = new ArrayList();
            //ArrayList qty =  new ArrayList();

            //DataTable dt = new DataTable();
            //DataTable ndt= new DataTable();

            ///Session["cart1"] = ndt;

            //dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Prod_id"), new DataColumn("Prod_Name") , new DataColumn("Prod_descp"), new DataColumn("Price") , new DataColumn("productimage"), new DataColumn("Quantity") });
            if (Session["UserDetails"].ToString().Contains("Guest"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please regsiter to order');", true);
            }

            else
            {
                foreach (GridViewRow row in grdvprodshow.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[6].FindControl("chkselect") as CheckBox);
                        if (chkRow.Checked )
                        {
                            string useremail = Session["UserDetails"].ToString();
                            int id = int.Parse(row.Cells[0].Text);
                            string name = row.Cells[1].Text;
                            string desc = row.Cells[2].Text;
                            int price = int.Parse(row.Cells[3].Text);

                            //string image= ((Image)row.Cells[4].FindControl("Image")).ImageUrl.ToString();
                            //string url = ((Image)grdvprodshow.FindControl("grdvprodshow")).ImageUrl;
                            int qty = int.Parse(((TextBox)row.Cells[5].FindControl("txtqty")).Text);
                            if (qty > 2)
                            {
                                qty = 2;
                            }
                            //int qty =int.Parse((row.Cells[5].Text));
                            //dt.Rows.Add(id,name,desc,price,"",qty);
                            objbal.addtocart1(useremail, id, name, desc, price, qty);

                        }
                    }
                    
                }
                Response.Redirect("~/Shoppingcart.aspx");
            }
            
            /*foreach (GridViewRow row in grdvprodshow.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[6].FindControl("chkselect") as CheckBox);
                    if (chkRow.Checked)
                    {
                        cartprod.Add(int.Parse(row.Cells[0].Text));
                        //qty.Add(int.Parse(row.Cells[5].Text));


                    }
                }
            }*/
            //Session["cart"]=dt;
            /*if (Session["cart"] == null)
            {
                Session["currentDataSet"] = dt;
                Session["cart"] = dt;
                Response.Redirect("~/Shoppingcart.aspx");
            }
            else
            {
                ndt = (DataTable)Session["cart"];
                Session["currentDataSet"] = dt;
                ndt.Merge((DataTable)Session["currentDataSet"]);
                Session["cart"] = ndt;
                Response.Redirect("~/Shoppingcart.aspx");
            }*/

        }

        protected void grdvprodshow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void btn_Addcategory_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Category.apsx");
        //}
    }
}