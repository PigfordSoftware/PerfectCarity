using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
         string username = "";
         //cookies get cookies
         foreach (String key in Request.Cookies)
         {//pull the cookie for our loginID which is sent when loging in
            if (key.CompareTo("loginID") == 0)
               username = Request.Cookies[key].Value.ToString();
         }


         lbl_username.Text = username;

      }

      protected void Page_LoadComplete(object sender, EventArgs e)
      {
         if(System.IO.File.Exists("~\\Uploads\\" + txtName.Text))
         {
            SetImageButtonURL("~\\Uploads\\" + txtName.Text);
         }
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

      private void SetImageButtonURL(string filename)
      {
         imgProfileImage.ImageUrl = filename + "?" + DateTime.Now.ToString();
         return;
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

         PerfectCarity.Profile profile = new Profile();
         profile.name = txtName.Text;
         profile.username = username;

         db.Profiles.InsertOnSubmit(profile);
         db.SubmitChanges();

         var profile_id = (from prof in db.Profiles
                           where prof.username == username
                           select prof.profile_id).Single();

         Server.TransferRequest("ProfileDetails.aspx?ProfileID=" + profile_id);

      }
   }
}