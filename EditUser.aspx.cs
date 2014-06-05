using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfectCarity
{
   public partial class EditUser : System.Web.UI.Page
   {
      string username;
      protected void Page_Load(object sender, EventArgs e)
      {

         if (Request.QueryString["Method"] == "SetImageButtonURL")
         {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //SetImageButtonURL(Request.QueryString["filename"]);
            imgUserImage.ImageUrl = "ViewImageFromFile.aspx?imgName=" + Request.QueryString["filename"]+"?"+DateTime.Now.Second;
            ImageButton imageB = new ImageButton();
            imageB.ImageUrl = Request.QueryString["filename"];
            imageB.Height=150;
            imageB.Width=150;
            imageB.OnClientClick = "OpenFO();";
            imgUserImage = imageB;
            return;
         }

         string[] questions = {
                                     "What city were you born?", 
                                     "What is your parental grandmother's first name?", 
                                     "What is the model of you first car?"
                                 };
         ddlSecurityQuest1.DataSource = questions;
         ddlSecurityQuest1.DataBind();
         ddlSecurityQuest2.DataSource = questions;
         ddlSecurityQuest2.DataBind();

         //cookies get cookies
         foreach (HttpCookie cookie in Request.Cookies)
         {//pull the cookie for our loginID which is sent when loging in
            if (cookie.Name.CompareTo("loginID") == 0)
               username = cookie.Value.ToString();
         }

         if (String.IsNullOrEmpty(username))
         {
            //imgUserImage.Attributes.Add("onclick", "return OpenFO();");
            txtName.Focus();
            imgUserImage.ImageUrl="~\\Images\\imageicon.png";
            return;
         }

         lbl_username.Text = username;

          //all data is valid and accounted for check to make sure that the username does not exist
         var db = new PerfectCarityDataContext();
         var user =
               (from users in db.CarityUsers
               where users.username == username
               select users).Single();

         //load the security question things based on the user that is logged in
         ddlSecurityQuest1.SelectedIndex = user.security_question_1;
         txtAnswer1.Text = user.security_answer_1;
         ddlSecurityQuest2.SelectedIndex = user.security_question_2;
         txtAnswer2.Text = user.security_answer_2;

         if (Object.Equals(user.image_id, null))
            //lbChange.Visible = false;
           {}
         else
         {//load image from the data base
            imgUserImage.ImageUrl = "ImageLoadPage.aspx?ImageID=" + user.image_id.ToString();
         }


         txtName.Focus();
      }

      protected void registerButton_Click(object sender, EventArgs e)
      {
         //all data is valid and accounted for check to make sure that the username does not exist
         var db = new PerfectCarityDataContext();
         var myUser =
             (from user in db.CarityUsers
              where user.username == username
              select user).Single() ;

            //username is non existing so it can be used.  we can continue with 
            myUser.name = txtName.Text;
            myUser.security_question_1 = ddlSecurityQuest1.SelectedIndex;
            myUser.security_answer_1 = txtAnswer1.Text;
            myUser.security_question_2 = ddlSecurityQuest2.SelectedIndex;
            myUser.security_answer_2 = txtAnswer2.Text;

            db.CarityUsers.InsertOnSubmit(myUser);
            db.SubmitChanges();

            Server.Transfer("LoginRegistration.aspx");
      }

      protected void lbChange_Click(object sender, EventArgs e)
      {
        
      }

      private void SetImageButtonURL(string filename)
      {
         imgUserImage.ImageUrl = filename+"?"+DateTime.Now.ToString();
         return;
      }
      protected void OnLogout_Click(object sender, EventArgs e)
      {
         return;
      }
      protected void OnEditProfile_Click(object sender, EventArgs e)
      {
         return;
      }
   }
}