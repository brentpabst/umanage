using System;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Net.Configuration;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using PPI.UMS.BLL.Common;

namespace PPI.UMS.BLL
{
    public class Installer
    {
        #region Properties

        Configuration config;

        #endregion

        #region Constructor

        /// <summary>
        /// Primary Constructor
        /// </summary>
        public Installer()
        {
            //Get the web configuration object
            config = WebConfigurationManager.OpenWebConfiguration("~");
        }

        #endregion

        #region Public

        /// <summary>
        /// Reset's the application to factory defaults and takes the application offline.
        /// </summary>
        /// <returns><see cref="bool"/>Returns false when the application cannot be reset.</returns>
        public bool Teardown()
        {
            try
            {
                //Get the Connection Strings Section
                ConnectionStringsSection cs = (ConnectionStringsSection)config.GetSection("connectionStrings");

                //Reset the LDAP connection
                cs.ConnectionStrings["ADService"].ConnectionString = "";

                //Reset the Entity Framework connection
                cs.ConnectionStrings["uManageEntities"].ConnectionString = "";

                //Reset the SMTP Service
                MailSettingsSectionGroup mailer = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
                mailer.Smtp.Network.Host = "";
                mailer.Smtp.Network.Port = 25;
                mailer.Smtp.From = "";
                mailer.Smtp.Network.EnableSsl = false;
                mailer.Smtp.Network.UserName = "";
                mailer.Smtp.Network.Password = "";
                mailer.Smtp.Network.DefaultCredentials = false;

                //Remove the role provider
                RoleManagerSection rm = (RoleManagerSection)config.GetSection("system.web/roleManager");
                rm.Enabled = false;
                rm.DefaultProvider = null;

                //Configure the membership provider
                MembershipSection ms = (MembershipSection)config.GetSection("system.web/membership");
                ProviderSettings ps = ms.Providers["AspNetActiveDirectoryMembershipProvider"];
                ps.Parameters.Set("connectionUsername", "");
                ps.Parameters.Set("connectionPassword", "");

                //Configure the Custom Errors section
                CustomErrorsSection ce = (CustomErrorsSection)config.GetSection("system.web/customErrors");
                ce.Mode = CustomErrorsMode.Off;

                //Configure the App settings
                config.AppSettings.Settings["LaunchSetupWizard"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserPasswordChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserAttibChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserNameChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserEmailChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserLocationChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserPhoneChanges"].Value = true.ToString();
                config.AppSettings.Settings["AllowUserPhotoChanges"].Value = true.ToString();
                config.AppSettings.Settings["DisplayUserAccountNotes"].Value = true.ToString();
                config.AppSettings.Settings["DisplayUserLocationSection"].Value = true.ToString();
                config.AppSettings.Settings["DisplayUserPhoneSection"].Value = true.ToString();
                config.AppSettings.Settings["DisplayUserOrganizationSection"].Value = true.ToString();
                config.AppSettings.Settings["DisplayUserPhotoSection"].Value = true.ToString();
                config.AppSettings.Settings["EnableOfficeLocationList"].Value = false.ToString();
                config.AppSettings.Settings["EnableMsftTag"].Value = false.ToString();
                config.AppSettings.Settings["MsftTagApiKey"].Value = String.Empty;
                config.AppSettings.Settings["AdGroupName"].Value = "uManage-Users";
                config.AppSettings.Settings["EnableNewUserCreation"].Value = false.ToString();
                config.AppSettings.Settings["NewUsernameFormat"].Value = "$fi$$lname$";
                config.AppSettings.Settings["NewUserContainer"].Value = String.Empty;
                config.AppSettings.Settings["CompanyName"].Value = String.Empty;
                config.AppSettings.Settings["CompanyAddress"].Value = String.Empty;
                config.AppSettings.Settings["CompanyCity"].Value = String.Empty;
                config.AppSettings.Settings["CompanyState"].Value = String.Empty;
                config.AppSettings.Settings["CompanyPostal"].Value = String.Empty;
                config.AppSettings.Settings["CompanyCountry"].Value = String.Empty;
                config.AppSettings.Settings["CompanyPhone"].Value = String.Empty;

                //Save config changes
                config.Save();

                //De-crypt the membership section
                UiHelper.UnProtectSection(ms.SectionInformation.SectionName);

                //De-crypt the smtp section
                UiHelper.UnProtectSection(mailer.SectionGroupName + "/smtp");

                //Configure the Setup Wizard security
                Configuration setupConfig = WebConfigurationManager.OpenWebConfiguration("~/Forms/Setup/");
                AuthorizationSection auths = (AuthorizationSection)setupConfig.GetSection("system.web/authorization");
                auths.Rules.Clear();

                //Save Config
                setupConfig.Save();

                //Take it down!
                UiHelper.TakeAppOffline();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Runs the installation scripts for the uManage database.
        /// </summary>
        /// <param name="server">The database server to connect to</param>
        /// <param name="password">The SA password to execute sommands with</param>
        /// <param name="domain">The domain name for the new database</param>
        /// <param name="userToAdd">The domain user to grant admin access to</param>
        /// <returns><see cref="bool"/>True if the database was installed, false if any errors were encountered.</returns>
        public bool InstallDatabase(string server, string password, string domain, string userToAdd)
        {
            try
            {
                //Define variables
                string dbName;
                string dbUser;
                string dbPassword;

                //Generate Required Strings
                GenerateDatabaseInfo(domain, out dbName, out dbUser, out dbPassword);

                SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();

                //Build a new connection with the sa creds, we use sa creds to install the db
                connBuilder.DataSource = server;
                connBuilder.InitialCatalog = "";
                connBuilder.UserID = "sa";
                connBuilder.Password = password;
                connBuilder.MultipleActiveResultSets = true;

                //Database Build statement
                string sql = "IF NOT EXISTS (SELECT [name] FROM Master..sysdatabases WHERE [name] = N'" + dbName + "') CREATE DATABASE [" + dbName + "]";

                //Build the initial connection
                SqlConnection conn = new SqlConnection(connBuilder.ConnectionString);

                //Create a command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Open the connection
                conn.Open();

                //Execute the database creation script
                cmd.ExecuteNonQuery();

                //Add a SQL Server User
                sql = "CREATE LOGIN [" + dbUser + "] WITH PASSWORD=N'" + dbPassword + "', DEFAULT_DATABASE=[" + dbName + "], CHECK_EXPIRATION=OFF";

                //Create a new command to create the user
                cmd = new SqlCommand(sql, conn);

                //Execute
                cmd.ExecuteNonQuery();

                //Add the new user to the database
                sql = "USE [" + dbName + "]; CREATE USER [" + dbUser + "] FOR LOGIN [" + dbUser + "] WITH DEFAULT_SCHEMA=[dbo]; EXEC sp_addrolemember N'db_owner', N'" + dbUser + "';";

                //Create a new command to add the user
                cmd = new SqlCommand(sql, conn);

                //Execute
                cmd.ExecuteNonQuery();

                //Once the DB is created we install the database objects from a file in the web app
                //  Load the File
                string file = HttpContext.Current.Server.MapPath("~/App_Data/SQL/uManage-Import.sql");

                //Read it to a stream
                StreamReader objReader = File.OpenText(file);

                //Define a string builder
                StringBuilder sb = new StringBuilder();

                //Loop through the stream
                while (!objReader.EndOfStream)
                {
                    //Get the current line
                    string s = objReader.ReadLine();

                    //GO Statements cannot be passed in, so we remove them from the generated file
                    if (!String.IsNullOrWhiteSpace(s) && !s.ToUpper().Trim().Equals("GO"))
                    {
                        //Add the current line
                        sb.AppendLine(s);
                    }
                }

                //Create a new command to execute the db script
                cmd = new SqlCommand(sb.ToString(), conn);

                //Execute
                cmd.ExecuteNonQuery();

                //We only add the current user from the HTTP session to the ASP.NET roles required, they can setup others on their own!
                //Use the built-in SPROC to Grant the current user system rights
                cmd = new SqlCommand("Setup_AddUserToRoles", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ApplicationName", System.Data.SqlDbType.NVarChar).Value = "uManage";
                cmd.Parameters.Add("@UserNames", System.Data.SqlDbType.NVarChar).Value = userToAdd;
                cmd.Parameters.Add("@RoleNames", System.Data.SqlDbType.NVarChar).Value = "System, Admin";
                cmd.Parameters.Add("@CurrentTimeUtc", System.Data.SqlDbType.DateTime).Value = DateTime.UtcNow;

                //Execute
                cmd.ExecuteNonQuery();

                //Get the Connection Strings Section
                ConnectionStringsSection cs = (ConnectionStringsSection)config.GetSection("connectionStrings");

                //Create Future Connection String                
                connBuilder.ConnectionString = "";
                connBuilder.DataSource = server;
                connBuilder.InitialCatalog = dbName;
                connBuilder.UserID = dbUser;
                connBuilder.Password = dbPassword;
                connBuilder.MultipleActiveResultSets = true;

                EntityConnectionStringBuilder eBuilder = new EntityConnectionStringBuilder();
                eBuilder.Provider = "System.Data.SqlClient";
                eBuilder.ProviderConnectionString = connBuilder.ConnectionString;
                eBuilder.Metadata = @"res://*/uManage.csdl|res://*/uManage.ssdl|res://*/uManage.msl";

                //Reset the Entity Framework connection
                cs.ConnectionStrings["uManageEntities"].ConnectionString = eBuilder.ConnectionString;

                //Save the configuration
                config.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Prepares the application for first use.
        /// </summary>
        /// <param name="domain">The domain the application should use</param>
        /// <param name="username">The username used to update the domain</param>
        /// <param name="password">The password used to update the domain</param>
        /// <param name="options">A list of application options to enable</param>
        /// <returns><see cref="bool"/>True if the application is configured, false if any errors are encountered.</returns>
        public bool InstallApplication(string domain, string username, string password, ListItemCollection options)
        {
            try
            {
                //Configure the LDAP connection
                ConnectionStringsSection cs = (ConnectionStringsSection)config.GetSection("connectionStrings");
                cs.ConnectionStrings["ADService"].ConnectionString = "LDAP://" + domain;

                //Configure the role manager
                RoleManagerSection rm = (RoleManagerSection)config.GetSection("system.web/roleManager");
                rm.Enabled = true;
                rm.DefaultProvider = "RoleProvider";

                //Configure the membership provider
                MembershipSection ms = (MembershipSection)config.GetSection("system.web/membership");
                ProviderSettings ps = ms.Providers["AspNetActiveDirectoryMembershipProvider"];
                ps.Parameters.Set("connectionUsername", username);
                ps.Parameters.Set("connectionPassword", password);

                //Configure the Custom Errors section
                CustomErrorsSection ce = (CustomErrorsSection)config.GetSection("system.web/customErrors");
                ce.Mode = CustomErrorsMode.RemoteOnly;

                //Update Settings and Options
                config.AppSettings.Settings["LaunchSetupWizard"].Value = "False";
                config.AppSettings.Settings["EnableOfficeLocationList"].Value = "False";
                config.AppSettings.Settings["AdGroupName"].Value = "uManage-Users";
                config.AppSettings.Settings["EnableNewUserCreation"].Value = "False";
                config.AppSettings.Settings["NewUsernameFormat"].Value = "$fi$$lname$";
                foreach (ListItem li in options)
                {
                    config.AppSettings.Settings[li.Value].Value = li.Selected.ToString();
                }

                //Save config changes
                config.Save();

                //Encrypt the membership section
                UiHelper.ProtectSection(ms.SectionInformation.SectionName, "DataProtectionConfigurationProvider");

                //Configure the Setup Wizard security
                Configuration setupConfig = WebConfigurationManager.OpenWebConfiguration("~/Forms/Setup/");
                AuthorizationSection auths = (AuthorizationSection)setupConfig.GetSection("system.web/authorization");
                AuthorizationRule authr = new AuthorizationRule(AuthorizationRuleAction.Deny);
                authr.Users.Add("*");
                auths.Rules.Add(authr);

                //Save Config
                setupConfig.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies a set of credentials against a domain controller
        /// </summary>
        /// <param name="domain">The domain to validate against</param>
        /// <param name="username">The username to validate with</param>
        /// <param name="password">The password to validate with</param>
        /// <param name="server">The sever that performed the validation</param>
        /// <returns><see cref="bool"/>True if validation succeeds.</returns>
        public bool VerifyDomainCredentials(string domain, string username, string password, out string server)
        {
            try
            {
                AD.Directory dir = new AD.Directory();

                if (dir.VerifyConnectionDetails(domain, username, password, out server))
                {
                    return true;
                }
                else
                {
                    server = "";
                    return false;
                }
            }
            catch
            {
                server = "";
                return false;
            }
        }

        /// <summary>
        /// Verifies a given user exists in the domain
        /// </summary>
        /// <param name="domain">The domain to verify against</param>
        /// <param name="username">The username to bind with</param>
        /// <param name="password">The password to bind with</param>
        /// <param name="userToVerify">The user to verify</param>
        /// <returns></returns>
        public bool VerifyUserExists(string domain, string username, string password, string userToVerify)
        {
            AD.Directory dir = new AD.Directory();
            if (dir.VerifyUserExists(domain, username, password, userToVerify))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifies connectivity to the specified database server.
        /// </summary>
        /// <remarks>
        /// Attempts to connect to a database server using the parameters specified.
        /// </remarks>
        /// <param name="dbServer">The database server to connect to</param>
        /// <param name="saPassword">The SA Password to access the database server with</param>
        /// <returns><see cref="bool"/> true if successful</returns>
        public bool VerifyDatabaseServer(string dbServer, string saPassword)
        {
            //Define variables
            bool retVal;
            string user = "sa";

            //Create a connection string to connect with
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.DataSource = dbServer;
            connBuilder.InitialCatalog = "";
            connBuilder.UserID = user;
            connBuilder.Password = saPassword;

            //Attempt to connect to the server
            SqlConnection conn = new SqlConnection(connBuilder.ConnectionString);

            try
            {
                //Try to open the connection
                conn.Open();

                //Ensure we are connected by checking the server version
                if (!String.IsNullOrWhiteSpace(conn.ServerVersion))
                { retVal = true; }
                else
                { retVal = false; }
            }
            catch (SqlException)
            {
                //Return false if any problems come up
                retVal = false;
            }
            finally
            {
                //Make sure we close the connection if it is still open
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                //We're good programmers, get rid of the connection object
                conn.Dispose();
            }

            //Send back the result
            return retVal;
        }

        /// <summary>
        /// Generates potential database connection information for uManage
        /// </summary>
        /// <param name="domain">The domain to connect to</param>
        /// <param name="dbName">The name the new database will use</param>
        /// <param name="dbUser">The database user that will be created</param>
        /// <param name="dbPassword">The random password generated for the new database user</param>
        public void GenerateDatabaseInfo(string domain, out string dbName, out string dbUser, out string dbPassword)
        {
            //This is pretty simple, just some string manipulations
            dbName = "uManage-" + domain.ToUpper();
            dbUser = "ums-conn-" + domain.ToLower();
            dbPassword = Membership.GeneratePassword(64, 20);
        }

        #endregion
    }
}
