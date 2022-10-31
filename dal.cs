using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.User;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using OnlineShopping.AppCode;

//using System.Data.SqlClient;

namespace OnlineShopping.AppCode
{
    public class dal
    {
        SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["OnlineShopping"].ToString());
        
        public string Userauth( string user_email,string password)
        {
            string values = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_UserAuth",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email",user_email);
                cmd.Parameters.AddWithValue("@User_password", password);
                values = (cmd.ExecuteScalar()).ToString();
                
            }
            catch(Exception ex)
            {}
            finally
            {
                con.Close();
            }
            if (!string.IsNullOrEmpty(values))
            { 
             
                con.Open();
                SqlCommand login = new SqlCommand("LoginActivity", con);
                login.CommandType = CommandType.StoredProcedure;
                login.Parameters.AddWithValue("@User_Email",values);
                login.Parameters.AddWithValue("@flag", 1);
                login.ExecuteReader();
                con.Close();
            }
            return values;
        }

        // password recovery
        public string password_recovery(string user_email)
        {
            string password = string.Empty;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_password_recover", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email", user_email);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        password = sdr["User_Password"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return password;
        }


        // password recovery end

        //reset password start
        public int reset_password(string Useremail, string Password , string newPassword)
        {
            int s=0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_forgot_password", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email", Useremail);
                cmd.Parameters.AddWithValue("@User_Password", Password);
                cmd.Parameters.AddWithValue("@New_Password", newPassword);
                s = (int)(cmd.ExecuteScalar());
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return s;
        }

        // reset pasword end

        public int Update_Logout(int flag, string user_email)
        {
            int result = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("LoginActivity", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Email", user_email);
            cmd.Parameters.AddWithValue("@flag", flag);
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }



       public int check_logout( string user_email)
        {

            int result=0;
            con.Open();
            SqlCommand check = new SqlCommand("usp_checkLogout", con);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.AddWithValue("@User_Email", user_email);
            result=(int)(check.ExecuteScalar());
            con.Close();

            return result;

           
        }

        public DataTable CheckRegister(registerUser ru)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            con.Open();

            SqlCommand cmd = new SqlCommand("usp_Checkregister", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Email", ru.email);
            cmd.Parameters.AddWithValue("@Mob_No", ru.Mob_no);
            //cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(ds);
            dt = ds.Tables[0];
            con.Close();
            return dt;
        }


        public string Registration(registerUser r)
        {
            string rg = "";
            
            try
            {
                con.Open();
               
                    SqlCommand cmd = new SqlCommand("usp_InsertUserDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", r.User_Name);
                    cmd.Parameters.AddWithValue("@Mobno", r.Mob_no);
                    cmd.Parameters.AddWithValue("@UserEmail", r.email);
                    cmd.Parameters.AddWithValue("@Password", r.password);
                    cmd.Parameters.AddWithValue("@Address", r.Address);
                    cmd.Parameters.AddWithValue("@Createdby", r.CreatedBy);
                    rg = (cmd.ExecuteScalar()).ToString();
                
                

            }
            catch(Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return rg;
        }

        #region Product

        public int ProductRegister(ProductDetails pd)
        {
            int prod=0;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertProductDetails", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prod_Name", pd.Prod_Name);
                cmd.Parameters.AddWithValue("@Prod_Descp", pd.Prod_Descp);
                cmd.Parameters.AddWithValue("@Price", pd.Price);
                cmd.Parameters.AddWithValue("@AvailableQty", pd.Availabe);
                cmd.Parameters.AddWithValue("@Cat_id", pd.Catid);
                cmd.Parameters.AddWithValue("MaxQty" ,pd.MaxQty);
                cmd.Parameters.AddWithValue("MinQty", pd.MinQty);
                cmd.Parameters.AddWithValue("productimage", pd.imgpath);

                //cmd.Parameters.AddWithValue("Cat_id", pd.cate);
                cmd.Parameters.Add("@Prod_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                prod= Convert.ToInt16(cmd.Parameters["@Prod_id"].Value.ToString());




            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return prod;
        }


        public int ProductCategory(Category cp)
        {
            int id=0;


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertCategoryTypes", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cat_Name", SqlDbType.NVarChar).Value = cp.Cat_Name;
                cmd.Parameters.Add("@Cat_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                 id = Convert.ToInt16(cmd.Parameters["@Cat_id"].Value.ToString());
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();

            }
            return id;

        }
        public int CheckCategory(Category ct)
        {
            int cntCatagory =0;
            try
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("usp_CheckCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cat_Name", ct.Cat_Name);
                cntCatagory = (int)(cmd.ExecuteScalar());
            }
            catch(Exception EX)
            {

            }
            finally { con.Close(); }
            return  cntCatagory;
            
        }
        public DataTable getCategory()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_GETCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA= new SqlDataAdapter(cmd);
                DA.Fill(dt);
                
            }
            catch( Exception EX) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getloginhistory()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_loginhistory", con);
                cmd.CommandType= CommandType.StoredProcedure;
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception EX) { }
            finally
            {
                con.Close();
            }
            return dt;
        }
        // search grid
        public DataTable getsearchgrid( string useremail)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_searchgrid", con);
                cmd.Parameters.AddWithValue("User_Email", useremail);
                cmd.CommandType=CommandType.StoredProcedure;
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex) { }
            finally { con.Close(); }    
            return dt ;
        }
        // search grid end

        //search category
        public DataTable searchcategory(string Catname)
        {
            DataTable dt= new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_searchcategory",con);
                cmd.Parameters.AddWithValue("Cat_Name", Catname);
                cmd.CommandType=CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally { con.Close(); }
            return dt;
        }


        //search category end 

        // display product
        public DataTable displayproduct()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_cart", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally { con.Close(); }
            return dt;
        }
        // display user cart
        public DataTable displayusercart(string useremail)
        {
            DataTable dt=new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("displaycart", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email",useremail);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch(Exception ex) { }
            finally { con.Close(); }
            return dt;
        }
        // remove from cart
        public void removecart(string useremail, int prodid)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_removecart",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email", useremail);
                cmd.Parameters.AddWithValue("@Prod_id", prodid);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }

        }
        // display orders
        public DataTable Displayorders(string useremail)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_previousorders", con);
                cmd.Parameters.AddWithValue("User_Email", useremail);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                d.Fill(dt);
            }
            catch { Exception ex; }
            finally { con.Close(); }
            return dt;

        }
        // search by drop down
        public DataTable searchbyddl(int Catid)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_searchbydropdown", con);
                cmd.Parameters.AddWithValue("Cat_id", Catid);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex) { }
            finally { con.Close(); }
            return dt;
        }
        // search by dropdown end


        // search by product name
        public DataTable searchbyname(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_searchproduct",con);
                cmd.Parameters.AddWithValue("Prod_Name", name);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch(Exception ex) { }
            finally { con.Close(); }
            return dt;
        }

        //search by product name ends
        public int check_product(ProductDetails cp)
        {
            int ckp=0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_CheckProduct", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prod_Name", cp.Prod_Name);
                cmd.Parameters.AddWithValue("@Price", cp.Price);
                ckp = (int)(cmd.ExecuteScalar());
            }
            catch (Exception EX) { }
            finally
            {
                con.Close();

            }
            return ckp;
        }
        // add to cart
        public void addtocart(string useremail,int pid,string pname,string pdescp,int price,int qty)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_usercart", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email", useremail);
                cmd.Parameters.AddWithValue("@Prod_id", pid);
                cmd.Parameters.AddWithValue("@Prod_Name", pname);
                cmd.Parameters.AddWithValue("@Prod_Descp", pdescp);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", qty);
                cmd.ExecuteNonQuery();

            }
            catch(Exception EX) { }
            finally { con.Close(); }
        }
        // order commplete
        public void ordercomplete(string Useremail,int prodid, string Prodname, int qty, int price)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ordercomplete", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Email",Useremail);
                cmd.Parameters.AddWithValue("@Prod_id", prodid);
                cmd.Parameters.AddWithValue("@Prod_Name", Prodname);
                cmd.Parameters.AddWithValue("@Quantity", qty);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
            }
            catch(Exception EX) { }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}