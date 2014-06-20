using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfectCarity
{
   public partial class ProfileDetails : System.Web.UI.Page
   {
      public int ProfileID
      {
         get
         {
            return (int)ViewState["profile_id"];
         }
         set
         {
            ViewState["profile_id"] = value;
         }
      }
      
      protected void Page_Init(object sender, EventArgs e)
      {
         try
         {//make sure we initialize the profile id to zero so we know if we have been on this page before
            if(Object.Equals(ProfileID,null))
               ProfileID = 0;
         }
         catch
         {
            ProfileID = 0;
         }
         return;
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

         if (String.IsNullOrEmpty(username))
            Server.Transfer("Default.aspx");

         lbl_username.Text = username;

         var db = new PerfectCarityDataContext();

         if (ProfileID == 0)
         {
            if (Request.QueryString["ProfileID"] != null)
            {
               ProfileID = Convert.ToInt32(Request.QueryString["ProfileID"].ToString());
            }
            else
            {
               try
               {

                  var profile_id = (from prof in db.Profiles
                                    where prof.username == username
                                    select prof.profile_id).Single();

                  ProfileID = profile_id;
               }
               catch
               {
                  Server.Transfer("AddProfile.aspx");
                  return;
               }
            }
         }

         var profile = (from prof in db.Profiles
                        where prof.profile_id == ProfileID
                        select prof).Single();

         lblProfileName.Text = profile.name;
         profileLabel.Text = profile.name;
         profileImage.ImageUrl = "LoadImagePage.aspx?ImageID=" + profile.image_id.ToString();
      }

      protected void OnEditProfile_Click(Object sender, EventArgs e)
      {
         return;
      }

      protected void OnLogout_Click(object sender, EventArgs e)
      {
         return;
      }
   }
}