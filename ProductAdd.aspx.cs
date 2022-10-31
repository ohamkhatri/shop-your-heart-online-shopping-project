using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShopping.AppCode;
using OnlineShopping.User;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace OnlineShopping
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        bal objbal = new bal();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Master.FindControl("btnaboutus").Visible = false;
            Page.Master.FindControl("btnProduct").Visible = false;
            if (!IsPostBack)

            {
                if (Session["UserDetails"].ToString().Contains("Guest"))
                {
                    Page.Master.FindControl("btnProduct").Visible = false;
                    Page.Master.FindControl("btnloginhistory").Visible = false;
                    Page.Master.FindControl("btnCategory").Visible = false;
                }
                string cs = ConfigurationManager.ConnectionStrings["OnlineShopping"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select Cat_Name, Cat_id from tblCategoryType", con);
                    con.Open();
                    ddl_CatName.DataSource = cmd.ExecuteReader();
                    ddl_CatName.DataTextField = "Cat_Name";
                    ddl_CatName.DataValueField = "Cat_id";
                    ddl_CatName.DataBind();

                }
            }
        }

        protected void ddl_Cat_id_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_AddProd_Click(object sender, EventArgs e)
        {
            ProductDetails productDetails = new ProductDetails();
            productDetails.Prod_Name = txt_ProdName.Text;
            productDetails.Prod_Descp = txt_ProdDesc.Text;
            productDetails.Price = int.Parse(txt_Price.Text);
            productDetails.Availabe = int.Parse(txt_Availability.Text);
            productDetails.Catid = int.Parse(ddl_CatName.SelectedValue.ToString());
            if (productDetails.Catid == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('please select category');", true);
                return;
            }
            productDetails.MaxQty = int.Parse(txt_MaxQty.Text);
            productDetails.MinQty = int.Parse(txt_MinQty.Text);
            productDetails.imgpath= "~/Productimages/"+DateTime.Now.ToString("ddMMyyyy")+"_"+imgfile.FileName.ToString();


            if (imgfile.HasFile)
            {
                //imgfile.SaveAs(@"../Productimages/" +DateTime.Now.ToString("ddMMyyyy")+ imgfile.FileName);
                string filename = Path.Combine(Server.MapPath("~/Productimages"), DateTime.Now.ToString("ddMMyyyy") + "_" + imgfile.FileName);
                imgfile.SaveAs(filename);

            }

            if (objbal.CheckProduct(productDetails) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Product already Available');", true);
                return;
            }
            else
            {
                int vl = objbal.ProductRegistration(productDetails);
                Response.Redirect("~/ProductAdd.aspx");
            }
            

           
        }

        
    }
}