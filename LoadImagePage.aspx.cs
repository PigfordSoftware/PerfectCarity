using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PerfectCarity
{
   public partial class LoadImagePage : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.QueryString["ImageID"] != null)
         {

             //all data is valid and accounted for check to make sure that the username does not exist
         var db = new PerfectCarityDataContext();
         var image =
               (from img in db.Images
               where img.image_id == Convert.ToInt32(Request.QueryString["ImageID"])
               select img).Single();
         //load image and send response
         Byte[] bytes = image.image1.ToArray();
         Response.Buffer = true;
         Response.Charset = "";
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         //Response.ContentType = image.content_type;
         //Response.AddHeader("content-disposition", "attachment;filename=" + image.image_name);
         Response.BinaryWrite(bytes);
         Response.Flush();
         Response.End();
         }

      }
   }
}