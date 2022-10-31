using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineShopping.User;
using OnlineShopping.AppCode;
using System.Net.Mail;
using System.Net;

namespace OnlineShopping
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        bal objbal = new bal();   
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Password_recovery"] = 0;
        }

       

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
           /*string password = objbal.Pass_recovery(PasswordRecovery1.UserName.ToString());


            if (!string.IsNullOrEmpty(password))
            {
                MailMessage mm = new MailMessage("2001640100181.2b@gmail.com", PasswordRecovery1.UserName.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", PasswordRecovery1.UserName.ToString(), password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
               
                //smtp.EnableSsl = true;
                //smtp.Send(Msg);


                /*NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "2001640100181.2b@gmail.com";
                NetworkCred.Password = "<Oham2709>";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 25;
                smtp.Send(mm);
                smtp.Credentials = new System.Net.NetworkCredential("2001640100181.2b@gmail.com", "oham2709");
                smtp.UseDefaultCredentials = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Password has been sent to your email address.";
            }

            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "This email address does not match our records.";
            }
           */



        }
    }
}