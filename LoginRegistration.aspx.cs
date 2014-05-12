using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

namespace PerfectCarity
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string[] questions = {
                                     "What city were you born?", 
                                     "What is your parental grandmother's first name?", 
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
                     where user.username == txtRegUsername.Text
                     select user).Single();

                if (cUser.password == txtPassword.Text)
                {
                    //password is valid
                   //cookies sent and move to next page
                   HttpCookie cookie = new HttpCookie("loginId", txtUsername.Text);
                   cookie.Expires = DateTime.Now.AddHours(2);
                   Response.Cookies.Add(cookie);
                }
                else
                {
                    //password is not valid
                }
            }
            catch
            {
                //login failed because username doesnt exist
            }
        }

    }
}