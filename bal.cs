using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using OnlineShopping.User;

namespace OnlineShopping.AppCode
{
    public class bal
    {
        dal objDAL = new dal();

        public string AuthUser(string username,string password)
        {

          return  objDAL.Userauth(username, password);
            
        }
        
        //password recovery
        public string Pass_recovery(string user_email)
        {
            return objDAL.password_recovery(user_email);
        }


        // reste password
        public int reset_pass(string Useremail, string Password, string newPassword)
        {
            return objDAL.reset_password(Useremail, Password, newPassword);
        }
        // login history
        public DataTable loginhistory()
        {
            using (DataTable dt = objDAL.getloginhistory())
            {
                return dt;
            }
        }
        // search login grid
        public DataTable searchlogin(string useremail )
        {
            using (DataTable dt = objDAL.getsearchgrid(useremail))
            {
                return dt;
            }
        }
        // search category grid
        public DataTable searchcategory(string Catname)
        {
            using(DataTable dt = objDAL.searchcategory(Catname))
            {
                return dt;
            }
        }
        // display product
        public DataTable displayproduct()
        {
            using (DataTable dt = objDAL.displayproduct())
            {
                return dt;
            }
        }
        // search by drop down 
        public DataTable searchbyddl(int Catid)
        {
            using(DataTable dt = objDAL.searchbyddl(Catid))
            {
                return dt;
            }
        }
        // search by product name
        public DataTable searchbyname(string name)
        {
            using( DataTable dt = objDAL.searchbyname(name))
            {
                return dt;
            }
        }
        // order complete
        public void ordercomplete(string Useremail,int prodid,string prodname, int qty, int price)
        {
            objDAL.ordercomplete(Useremail,prodid,prodname,qty,price);
        }
        // previous orders
        public DataTable displayords(string useremail)
        {
            using (DataTable dt = objDAL.Displayorders(useremail))
            {
                return dt;
            }
        }
        // display user cart
        public DataTable displayusercart1(string useremail)
        {
            using (DataTable dt = objDAL.displayusercart(useremail))
            {
                return dt;
            }
        }
        // add to cart
        public void addtocart1(string useremail, int pid, string pname, string pdescp, int price, int qty)
        {
            objDAL.addtocart(useremail,pid,pname,pdescp,price,qty);
        }
        // remove cart 
        public void removecart1(string useremail,int prodid)
        {
            objDAL.removecart(useremail,prodid);    
        }
        public int Login_activity (string user_email)
        {
            return  objDAL.check_logout(user_email);
        }

        public int Update_Logout_(int flag, string user_email)
        {
            return objDAL.Update_Logout(flag, user_email);
        }


        public  DataTable CheckUser(registerUser ru)
        {
            return objDAL.CheckRegister(ru);
        }
        public string RegisterUser(registerUser r)
        {
            return objDAL.Registration(r);
        }

        public int AddProductCat(Category ct)
        {
            return objDAL.ProductCategory(ct);
        }

        public int CheckProductCategory(Category ct)
        {
            return objDAL.CheckCategory(ct);
        }
        public DataTable GetCategory()
        {
           using (DataTable dt=objDAL.getCategory())
            {
                return dt;
            }
        }

        public int ProductRegistration(ProductDetails pd)
        {
            return objDAL.ProductRegister(pd);
        }

        public int CheckProduct(ProductDetails pd)
        {
            return objDAL.check_product(pd);
        }
    }
}