namespace THS.UMS.UI.Utilities
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Security;

    using THS.UMS.AO;

    public static class Startup
    {
        /// <summary>
        /// Gets the load file/form/page.
        /// </summary>
        /// <returns></returns>
        public static string GetLoadLocation()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["RunInstaller"]))
                return "~/setup";

            if (Convert.ToBoolean(AppSettings.GetValue("HomePageEnabled")) && Convert.ToBoolean(AppSettings.GetValue("HomePageOverride")))
                return "~/home";
            return Roles.IsUserInRole("AdminPortal") ? "~/admin/dash" : "~/my/info";
        }

        /// <summary>
        /// Loads the user info into the session memory.
        /// </summary>
        public static void LoadUserSessionInfo()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["RunInstaller"])) return;

            var emps = new Employees();
            HttpContext.Current.Session["CurrentEmp"] = emps.GetEmployeeByUsername(HttpContext.Current.User.Identity.Name);
            HttpContext.Current.Session["CurrentEmpLastLoad"] = DateTime.UtcNow;
        }

        /// <summary>
        /// Removes the user info from session memory.
        /// </summary>
        public static void RemoveUserSessionInfo()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Session["CurrentEmp"] = null;
        }

        /// <summary>
        /// Takes the app offline.
        /// </summary>
        public static void TakeAppOffline()
        {
            try
            {
                var file = HttpContext.Current.Server.MapPath("~/App_Data/Templates/Offline.txt");
                var objReader = File.OpenText(file);
                var objWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Offline.htm"), true);
                objWriter.Write(objReader.ReadToEnd());
                objReader.Close();
                objWriter.Close();
            }
            catch
            {
                throw new IOException("Failed to read template file or create new file");
            }
        }

        /// <summary>
        /// Clears the temp files.
        /// </summary>
        public static void ClearTempFiles()
        {
            var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/App_Data/Temp"));
            foreach (var f in dir.EnumerateFiles().Where(f => f.CreationTime <= DateTime.Now.AddMinutes(-30)))
            {
                f.Delete();
            }
        }
    }
}
