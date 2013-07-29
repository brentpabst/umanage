namespace THS.UMS.UI
{
    using System;
    using System.Web.Routing;

    using THS.UMS.UI.Utilities;

    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            // Map System Pages/Files
            routes.MapPageRoute("error", "error", "~/Forms/Error.aspx");
            routes.MapPageRoute("setup", "setup", "~/Forms/Setup/Setup.aspx");

            // Map Home Page
            routes.MapPageRoute("home", "home", "~/Forms/Users/Home.aspx");

            // Map User Pages
            routes.MapPageRoute("user-info", "my/info", "~/Forms/Users/Info.aspx");
            routes.MapPageRoute("user-password", "my/password", "~/Forms/Users/Password.aspx");
            routes.MapPageRoute("user-account", "my/account", "~/Forms/Users/Account.aspx");
            routes.MapPageRoute("user-dir", "user/search", "~/Forms/Users/Search.aspx");
            routes.MapPageRoute("user-dirinfo", "user/info/{upn}", "~/Forms/Users/UserView.aspx");

            // Map Admin Pages
            routes.MapPageRoute("admin-dash", "admin/dash", "~/Forms/Admin/Dashboard.aspx");
            routes.MapPageRoute("admin-conf-offline", "admin/conf/offline", "~/Forms/Admin/Config/SysOffline.aspx");
            routes.MapPageRoute("admin-conf-summary", "admin/conf/summary", "~/Forms/Admin/Config/SysSummary.aspx");
            routes.MapPageRoute("admin-conf-reset", "admin/conf/reset", "~/Forms/Admin/Config/SysReset.aspx");
            routes.MapPageRoute("admin-conf-smtp", "admin/conf/smtp", "~/Forms/Admin/Config/SysSmtp.aspx");
            routes.MapPageRoute("admin-conf-groups", "admin/conf/groups", "~/Forms/Admin/Config/SysGroups.aspx");
            routes.MapPageRoute("admin-conf-auto", "admin/conf/auto", "~/Forms/Admin/Config/SysAuto.aspx");
            routes.MapPageRoute("admin-conf-directory", "admin/conf/directory", "~/Forms/Admin/Config/SysDirectory.aspx");
            routes.MapPageRoute("admin-conf-database", "admin/conf/database", "~/Forms/Admin/Config/SysDatabase.aspx");
            routes.MapPageRoute("admin-conf-settings", "admin/conf/settings", "~/Forms/Admin/Config/AppSettings.aspx");
            routes.MapPageRoute("admin-conf-office", "admin/conf/office", "~/Forms/Admin/Config/AppOffice.aspx");
            routes.MapPageRoute("admin-conf-department", "admin/conf/department", "~/Forms/Admin/Config/AppDepartment.aspx");
            routes.MapPageRoute("admin-conf-location", "admin/conf/location", "~/Forms/Admin/Config/AppLocation.aspx");
            routes.MapPageRoute("admin-conf-users", "admin/conf/users", "~/Forms/Admin/Config/AppUsers.aspx");
            routes.MapPageRoute("admin-conf-templ", "admin/conf/templates", "~/Forms/Admin/Config/AppTemplates.aspx");
            routes.MapPageRoute("admin-user-list", "admin/user/list", "~/Forms/Admin/User/UsrList.aspx");
            routes.MapPageRoute("admin-user-add", "admin/user/add", "~/Forms/Admin/User/UsrAdd.aspx");
            routes.MapPageRoute("admin-user-show", "admin/user/show/{upn}", "~/Forms/Admin/User/UsrDetail.aspx");
            routes.MapPageRoute("admin-user-audit", "admin/user/audit", "~/Forms/Admin/User/UsrAudit.aspx");
            routes.MapPageRoute("admin-user-audit-detail", "admin/user/audit/show/{id}", "~/Forms/Admin/User/UsrAuditDetail.aspx");
            routes.MapPageRoute("admin-group-list", "admin/group/list", "~/Forms/Admin/Groups/GroupList.aspx");
            routes.MapPageRoute("admin-group-show", "admin/group/show/{upn}", "~/Forms/Admin/Groups/GroupDetail.aspx");
            routes.MapPageRoute("admin-home-links", "admin/home/links", "~/Forms/Admin/Config/HomeLinks.aspx");
            routes.MapPageRoute("admin-home-posts", "admin/home/posts", "~/Forms/Admin/Config/HomePosts.aspx");
            routes.MapPageRoute("admin-home-config", "admin/home/conf", "~/Forms/Admin/Config/HomeConfig.aspx");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

            // Load the current user employee to memory
            Startup.LoadUserSessionInfo();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

            // Remove Employee Session memory
            Startup.RemoveUserSessionInfo();
        }

    }
}
