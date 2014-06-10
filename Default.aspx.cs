using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Net.Mail;
using System.Net;

namespace PerfectCarity
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string[] questions = {
                                     "What city were you born?", 
                                     "What is your paternal grandmother's first name?", 
                                     "What is the model of you first car?"
                                 };
            ddlSecurityQuest1.DataSource = questions;
            ddlSecurityQuest1.DataBind();
            ddlSecurityQuest2.DataSource = questions;
            ddlSecurityQuest2.DataBind();
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            // check to make sure the validator controls are valid before performing
            // any action to add a user
            if (!rfvRegEmailAddress.IsValid
               || !rfvRegUsername.IsValid
               || !rfvDDQuestion1.IsValid
               || !rfvAnswer1.IsValid
               || !rfvDDQuestion2.IsValid
               || !rfvDDQuestion2.IsValid
               || !rfvAnswer2.IsValid
               || !cvPassword.IsValid)
                return;

            //all data is valid and accounted for check to make sure that the username does not exist
            var db = new PerfectCarityDataContext();
            var users =
                from user in db.CarityUsers
                where user.username == txtRegUsername.Text
                select user;

            if(users.Count() == 0)
            {
                //username is non existing so it can be used.  we can continue with 
                var cUser = new CarityUser
                {
                    username = txtRegUsername.Text,
                    password = txtRegPassword.Text,
                    email_addr = txtRegEmailAddress.Text,
                    security_question_1 = ddlSecurityQuest1.SelectedIndex,
                    security_answer_1 = txtAnswer1.Text,
                    security_question_2 = ddlSecurityQuest2.SelectedIndex,
                    security_answer_2 = txtAnswer2.Text
                };
                db.CarityUsers.InsertOnSubmit(cUser);
                db.SubmitChanges();
                //this is where we move to the next page and create some cookies
                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();
                mm.To.Add(new System.Net.Mail.MailAddress(txtRegEmailAddress.Text, txtRegUsername.Text));
                mm.From = new System.Net.Mail.MailAddress("ryan@pigfordsoftware.com");
                mm.Sender = new System.Net.Mail.MailAddress("ryan@pigfordsoftware.com", "Ryan T Pigford");
                mm.Subject = "This is Test Email";
                mm.Body = "<h3>Thank you for signing up at PerfectCarity.com</h3>";
                mm.IsBodyHtml = true;
                mm.Priority = System.Net.Mail.MailPriority.High; // Set Priority to sending mail
                System.Net.Mail.SmtpClient smtCliend = new System.Net.Mail.SmtpClient();
                smtCliend.Host = "mail.pigfordsoftware.com";
                smtCliend.Port = 25;    // SMTP port no  
                smtCliend.EnableSsl = false;
                smtCliend.Credentials = new NetworkCredential("ryan@pigfordsoftware.com", "thomas81");
                smtCliend.DeliveryMethod = SmtpDeliveryMethod.Network;
                try
                {
                   smtCliend.Send(mm);
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                   //lblMsg.Text = ex.ToString();
                }
                catch (Exception exe)
                {
                   //lblMsg.Text = "\n\n\n" + exe.ToString();
                }
                HttpCookie cookie = new HttpCookie("loginID");
                cookie.Value = txtRegUsername.Text;
                cookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(cookie);
                Server.Transfer("EditUser.aspx");
            }
            else
            {
                //username is not distinct so must enter another username
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new PerfectCarityDataContext();
               //get the single row from the table CarityUsers with the same username that was typed in
                var cUser =
                    (from user in db.CarityUsers
                     where user.username == txtUsername.Text
                     select user).Single();

                if (cUser.password == txtPassword.Text)
                {
                    //password is valid
                   //cookies sent and move to next page
                   HttpCookie cookie = new HttpCookie("loginID", txtUsername.Text);
                   cookie.Expires = DateTime.Now.AddHours(2);
                   Response.Cookies.Add(cookie);
                   if (cUser.Profiles.Count > 0)
                      Server.TransferRequest("ProfileDetails.aspx");
                   else
                      Server.TransferRequest("AddProfile.aspx");
                }
                else
                {
                    //password is not valid
                   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('The username and or password is invalid.')", true);
                }
            }
            catch
            {
                //login failed because username doesnt exist
               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('The username and or password is invalid.')", true);
            }
        }

    }
}