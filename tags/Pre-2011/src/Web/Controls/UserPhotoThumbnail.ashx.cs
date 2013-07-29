using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPI.UMS.Web.Controls
{
    /// <summary>
    /// Summary description for UserPhotoThumbnail
    /// </summary>
    public class UserPhotoThumbnail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            AD.User user = new AD.User(context.Request.QueryString["username"]);
            byte[] thumbnail = user.GetUserImageThumbnail();

            context.Response.ContentType = "image/png";
            context.Response.OutputStream.Write(thumbnail,0,thumbnail.Length);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}