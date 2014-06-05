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
      TextBox[] emailAddresses = null;
      DropDownList[] accessLevels = null;

      protected void Page_Load(object sender, EventArgs e)
      {

         if(Object.Equals(emailAddresses,null))
            Array.Resize(ref emailAddresses, 0);
         if (Object.Equals(emailAddresses, null))
            Array.Resize(ref accessLevels, 0);
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
         var size = emailAddresses.Length+1;
         Array.Resize(ref emailAddresses, size);
         Array.Resize(ref accessLevels, size);
         emailAddresses[size - 1] = new TextBox();
         accessLevels[size - 1] = new DropDownList();
         emailAddresses[size - 1].CssClass = "textBox";
         accessLevels[size - 1].CssClass = "textBox";
         emailAddresses[size - 1].Height = txtEmailAddress.Height;
         emailAddresses[size - 1].Width = txtEmailAddress.Width;
         accessLevels[size - 1].Height = userAccess.Height;
         accessLevels[size - 1].Width = userAccess.Width;
         if(size != 1)
         {
            profileEmails.Controls.Add(new LiteralControl("<br />"));
            profileUserAccess.Controls.Add(new LiteralControl("<br />"));
         }
         this.profileEmails.Controls.Add(emailAddresses[size - 1]);
         this.profileUserAccess.Controls.Add(accessLevels[size - 1]);
      }
   }
}