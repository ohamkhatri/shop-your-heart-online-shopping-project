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
    public partial class WebForm10 : System.Web.UI.Page
    {
         bal objbal=new bal();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["UserDetails"] != Session["Admin"])
                {
                    //btn_AddProd.Visible = false;
                    Page.Master.FindControl("btnCategory").Visible = false;
                    Page.Master.FindControl("btnProduct").Visible = false;
                    Page.Master.FindControl("btnloginhistory").Visible = false;
                    


                }
                //int total = 0;
                //showcart();
                Page.Master.FindControl("btncart").Visible = false;
                showcart1();
                
            }
            
        }
        
        public void showcart1()
        {
            grdvcart.DataSource = objbal.displayusercart1(Session["UserDetails"].ToString());
            grdvcart.DataBind();
            int total = 0;
            foreach (GridViewRow row in grdvcart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    int qty = int.Parse(row.Cells[5].Text) * int.Parse(row.Cells[3].Text);
                    total += qty;



                }
            }
            lbl_total.Text = "Grand Total: " + total.ToString();

        }
        /*public void showcart()
        {
            grdvcart.DataSource = Session["cart"];
            grdvcart.DataBind();
            int total = 0;
            foreach (GridViewRow row in grdvcart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    
                        int qty = int.Parse(row.Cells[5].Text) * int.Parse(row.Cells[3].Text);
                        total += qty;


                  
                }
            }
            lbl_total.Text = "Grand Total: "+ total.ToString();
        }*/

        protected void grdvcart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvcart.PageIndex= e.NewPageIndex;
            this.showcart1();
        }

        

        protected void btn_order_Click(object sender, EventArgs e)
        {
           
               foreach (GridViewRow row in grdvcart.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string email = Session["UserDetails"].ToString();
                        int id= int.Parse(row.Cells[0].Text);
                        string name= row.Cells[1].Text;
                        int price = int.Parse(row.Cells[3].Text);
                        int Qty = int.Parse(row.Cells[5].Text);

                        objbal.ordercomplete(email,id,name,Qty,price);


                    }
                }

            
        }

        protected void removeprod_Click(object sender, EventArgs e)
        {
           
            foreach(GridViewRow row in grdvcart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[6].FindControl("chkcart") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int id= int.Parse(row.Cells[0].Text);
                        objbal.removecart1(Session["UserDetails"].ToString(), id);
                        showcart1();
                    }
                }
            }
            int total = 0;
            foreach (GridViewRow row in grdvcart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (row.Visible == true)
                    {
                        int qty = int.Parse(row.Cells[5].Text) * int.Parse(row.Cells[3].Text);
                        total += qty;

                    }



                }
            }
            lbl_total.Text = "Grand Total: " + total.ToString();
        }

 
    }
}