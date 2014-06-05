using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PerfectCarity
{
   /// <summary>
   /// Summary description for UploadHandler
   /// </summary>
   public class UploadHandler : IHttpHandler
   {

      public void ProcessRequest(HttpContext context)
      {
         string path = context.Request["path"];
         string username = context.Request["username"];
         FileInfo file = new FileInfo(path);
         string filename = context.Server.MapPath("~//Uploads//") + username + "_" + file.Name;
         file.CopyTo(filename);
         string name = "~/Uploads/"+username+"_"+file.Name;
         FileStream fs = new FileStream(path, FileMode.Open);
         Byte[] fileData = null;
         Array.Resize(ref fileData, (int)fs.Length);
         fs.Read(fileData, 0,(int) fs.Length);
         int size = fileData.Length;
         string singleImage = "22";
         /*var db = new PerfectCarityDataContext();
         System.Data.Linq.Binary b = new System.Data.Linq.Binary(fileData);
         var image = new PerfectCarity.Image() { username = username, size = size, image1 = b};
         db.Images.InsertOnSubmit(image);
         db.SubmitChanges();

         var singleImage = (from images in db.Images
                            where images.username == username
                            && images.profile_id.HasValue
                            && images.entry_id == null
                            select images.image_id).Single();*/
         context.Response.Write(singleImage+"@"+name);
      }
  
      public bool IsReusable
      {
         get
         {
            return false;
         }
      }
   }
}