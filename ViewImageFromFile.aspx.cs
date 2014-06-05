using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfectCarity
{
   public partial class ViewImageFromFile : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         //Changing the page's content type to indicate the page is returning an image
         Response.ContentType = "image/jpg";
         //'Retrieving the name of the image 
         var imageName = Request.QueryString["imgName"];
         var path = imageName;
         if (!String.IsNullOrEmpty(imageName))
         {//      'Retrieving the image
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(path));
            //'Writing the image directly to the output stream
            fullSizeImg.Save(Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);
            //'Cleaning up the image
            fullSizeImg.Dispose();
         }
      }
   }
}