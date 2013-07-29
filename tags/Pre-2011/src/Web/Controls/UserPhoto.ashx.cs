using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPI.UMS.Web.Controls
{
    /// <summary>
    /// Summary description for UserPhoto
    /// </summary>
    public class UserPhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            AD.User user = new AD.User(context.Request.QueryString["username"]);
            byte[] thumbnail = user.GetUserImage();

            context.Response.ContentType = "image/png";
            context.Response.OutputStream.Write(thumbnail, 0, thumbnail.Length);
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