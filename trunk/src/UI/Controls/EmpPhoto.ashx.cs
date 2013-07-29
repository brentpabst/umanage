namespace THS.UMS.UI.Controls
{
    using System;
    using System.Web;

    using THS.UMS.AO;

    /// <summary>
    /// Summary description for EmpPhoto
    /// </summary>
    public class EmpPhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // Get Username
            var q = context.Request.QueryString["u"];

            if (!String.IsNullOrWhiteSpace(q))
            {
                // Decode the Username
                q = Utilities.Encoder.DecodeString(q);

                // Define needed variables
                var emps = new Employees();
                byte[] i;
                
                // Determine thumbnail
                i = emps.GetEmployeePhoto(q, context.Request.QueryString["thumb"] == "yes");

                context.Response.ContentType = "image/png";
                context.Response.OutputStream.Write(i, 0, i.Length);
            }
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