using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PerfectCarity
{
   public partial class AddProfile : System.Web.UI.Page
   {
      public string[] emailAddresses
      {
         get
         {
            return (string[])ViewState["emailAddresses"];
         }
         set
         {
            ViewState["emailAddresses"] = value;
         }
      }

      public int[] accessLevels
      {
         get
         {
            return (int[])ViewState["accessLevels"];
         }
         set
         {
            ViewState["accessLevels"] = value;
         }
      }

      public int numberOfUsers
      {
         get
         {
            return (int)ViewState["numberOfUsers"];
         }
         set
         {
            ViewState["numberOfUsers"] = value;
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

      protected void Page_Init(object sender, EventArgs e)
      {
         numberOfUsers = 0;
         string[] emails = null;
         Array.Resize(ref emails, 0);
         int[] access = null;
         Array.Resize(ref access, 0);
         emailAddresses = emails;
         accessLevels = access;
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(username))
         {
            if (Request.QueryString["username"] != null)
               username = Request.QueryString["username"].ToString();
         }
            
         lbl_username.Text = username;

      }

      protected void Page_LoadComplete(object sender, EventArgs e)
      {
         return;
      }

      protected void OnNavBarLink_Click(object sender, EventArgs e)
      {
         LinkButton lb = (LinkButton)sender;
         Response.Redirect(lb.CommandName + "?username=" + username);
         return;
      }
      protected void addUser_Click(object sender, ImageClickEventArgs e)
      {
         numberOfUsers =  numberOfUsers + 1;
         AddControls();
      }

      protected override void CreateChildControls()
      {
         base.CreateChildControls();
         AddControls();
      }

      private void AddControls()
      {
         var index = numberOfUsers - 1;
         TextBox[] emails = null;
         DropDownList[] access = null;
         Array.Resize(ref emails, numberOfUsers);
         Array.Resize(ref access, numberOfUsers);
         profileEmails.Controls.Clear();
         for (int i = 0; i < numberOfUsers; i++)
         {
            emails[i] = new TextBox();
            emails[i].CssClass = "textBox";
            emails[i].Height = txtEmailAddress.Height;
            emails[i].Width = txtEmailAddress.Width;
            emails[i].ID = "emailAddress_" + index.ToString();

            access[i] = new DropDownList();
            access[i].CssClass = "textBox";
            access[i].Height = userAccess.Height;
            access[i].Width = userAccess.Width;
            access[i].Items.Add("Read Only");
            access[i].Items.Add("Read and Create Entries");
            access[i].Items.Add("Read, Create, Edit, Delete Entries");
            access[i].ID = "dropDown_" + index.ToString();

            if (i != 0)
            {
               profileEmails.Controls.Add(new LiteralControl("<br />"));
            }
            profileEmails.Controls.Add(emails[i]);
            profileEmails.Controls.Add(access[i]);
         }
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
                  if (fileUpload.PostedFile.ContentLength < 102400)
                  {
                     string filename = Path.GetFileName(fileUpload.FileName);
                     fileUpload.SaveAs(Server.MapPath("~/Images/") + filename);
                     imageFileName = Server.MapPath("~/Images/") + filename;
                  }
                  else
                     status = "The file must to be less than 100 KB";
               }
               else
                  status = "Only JPEG files are accepted.";
            }
            catch (Exception ex)
            {
               status = "The file could not be uploaded. The following error occured: " + ex.Message;
            }
         }       
         if(String.IsNullOrEmpty(status))
         {
            //password is not valid
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "alert('"+status+"')", true);
            return;
         }
      }
      protected void createButton_Click(object sender, EventArgs e)
      {
         string username = lbl_username.Text;
         //all data is valid and accounted for check to make sure that the username does not exist
         var db = new PerfectCarityDataContext();
         var user =
               (from users in db.CarityUsers
                where users.username == username
                select users).Single();
         //create a new class profile to store the creates profile
         PerfectCarity.Profile profile = new Profile();
         //store values in fields as profile
         profile.name = txtName.Text;
         profile.username = username;
         //create an Image class to save the image that was uploaded
         PerfectCarity.Image image = new Image();
         image.username = username;
         //pull the image into memory so it can be saved in the database
         FileStream fs = new FileStream(imageFileName, FileMode.Open);
         Byte[] fileData = null;
         Array.Resize(ref fileData, (int)fs.Length);
         fs.Read(fileData, 0, (int)fs.Length);
         //set image properties
         image.size = (int)fs.Length;
         image.image1 = fileData;
         //add both the image row and the profile row
         db.Profiles.InsertOnSubmit(profile);
         db.Images.InsertOnSubmit(image);
         //commit changes to the database
         db.SubmitChanges();
         //we now need to update the profile class that was created with the image_id that was created
         //we also need to get the profile_id that was inserted
         var pro = (from prof in db.Profiles
                    where prof.username == username
                    select prof).Single();
         //need to get the image that was just inserted
         var image_id = (from img in db.Images
                         where img.username == username
                         select img.image_id).Max();
         //set profile image_id equal to the image just inserted
         pro.image_id = image_id;
         //commit changes
         db.SubmitChanges();
         //go to the profile details page
         Response.Redirect("ProfileDetails.aspx?ProfileID=" + pro.profile_id);

      }
   }
}