using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PerfectCarity
{
   public partial class EditUser : System.Web.UI.Page
   {
      public string username
      {
         get
         {
            return (string)ViewState["username"];
         }
         set
         {
            ViewState["username"] = value;
         }
      }
      public string imageFileName
      {
         get
         {
            return (string)ViewState["imageFileName"];
         }
         set
         {
            ViewState["imageFileName"] = value;
         }
      }
      protected void Page_Load(object sender, EventArgs e)
      {

         if (String.IsNullOrEmpty(username))
         {
            if (Request.QueryString["username"] != null)
               username = Request.QueryString["username"].ToString();
         }

         string[] questions = {
                                     "What city were you born?", 
                                     "What is your paternal grandmother's first name?", 
                                     "What is the model of you first car?"
                                 };
         ddlSecurityQuest1.DataSource = questions;
         ddlSecurityQuest1.DataBind();
         ddlSecurityQuest2.DataSource = questions;
         ddlSecurityQuest2.DataBind();

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
         {
            imgUserImage.ImageUrl = "~/Images/imageicon.png";
         }
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

            if (!String.IsNullOrEmpty(imageFileName))
            {
               //create an Image class to save the image that was uploaded
               PerfectCarity.Image image = new Image();
               image.username = username;
               //pull the image into memory so it can be saved in the database
               FileStream fs = new FileStream(imageFileName, FileMode.Open);
               Byte[] fileData = null;
               Array.Resize(ref fileData, (int)fs.Length);
               fs.Read(fileData, 0, (int)fs.Length);
               fs.Close();
               File.Delete(imageFileName);
               //set image properties
               image.size = (int)fs.Length;
               image.image1 = fileData;
               db.Images.InsertOnSubmit(image);
            }
            db.SubmitChanges();
            if (!String.IsNullOrEmpty(imageFileName))
            {
               //need to get the image that was just inserted
               var image_id = (from img in db.Images
                               where img.username == username
                               select img.image_id).Max();
               //set profile image_id equal to the image just inserted
               myUser.image_id = image_id;
               //commit changes
               db.SubmitChanges();
               imageFileName = "";
            }
            //need to determine where to go
            Response.Redirect("ProfileDetails.aspx?username=" + username);
      }

      protected void uploadButton_Click(object sender, EventArgs e)
      {
         string status = "";
         if (fileUpload.HasFile)
         {
            try
            {
               if (fileUpload.PostedFile.ContentType == "image/jpeg")
               {
                  if (fileUpload.PostedFile.ContentLength < 2048000)
                  {
                     string filename = Path.GetFileName(fileUpload.FileName);
                     fileUpload.SaveAs(Server.MapPath("~/Uploads/") + filename);
                     imageFileName = Server.MapPath("~/Uploads/") + filename;
                  }
                  else
                     status = "The file must to be less than 2 MB";
               }
               else
                  status = "Only JPEG files are accepted.";
            }
            catch (Exception ex)
            {
               status = "The file could not be uploaded. The following error occured: " + ex.Message;
            }
         }
         if (String.IsNullOrEmpty(status))
         {
            //password is not valid
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('" + status + "')", true);
            return;
         }
      }

      protected void OnNavBarLink_Click(object sender, EventArgs e)
      {
         LinkButton lb = (LinkButton)sender;
         Response.Redirect(lb.CommandName + "?username=" + username);
         return;
      }
   }
}