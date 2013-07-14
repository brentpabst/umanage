using _203.UMS.Models.App;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;

namespace _203.UMS.Data.Init
{
    public class SystemDbInitializer : DropCreateDatabaseIfModelChanges<SystemDb>
    {
        private readonly SystemDb _db;
        public SystemDbInitializer()
        {
            _db = new SystemDb();
        }

        public SystemDbInitializer(SystemDb ctx)
        {
            _db = ctx;
        }

        protected override void Seed(SystemDb context)
        {
            Settings().ForEach(s => _db.Settings.Add(s));
            QuickLinks().ForEach(l => _db.QuickLinks.Add(l));
            WallPosts().ForEach(p => _db.WallPosts.Add(p));
            Offices().ForEach(o => _db.Offices.Add(o));
            Departments().ForEach(d => _db.Departments.Add(d));

            _db.SaveChanges();
        }

        #region Seed Data
        private List<Setting> Settings()
        {
            var debug = HttpContext.Current.IsDebuggingEnabled;
            return new List<Setting>
                       {
                           new Setting
                               {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "LdapPath",
                                    Value = ""
                               },
                           new Setting
                               {
                                   SettingId=Guid.NewGuid(),
                                   IsEncrypted = false,
                                   Key = "GroupsToIgnore",
                                   Value = "SQLServer2005SQLBrowserUser$LIB-IMPORT,SQLServer2005MSSQLServerADHelperUser$LIB-IMPORT,SQLServer2005MSSQLUser$LIB-IMPORT$SQLEXPRESS,SQLServer2005MSSQLUser$LIB-IMPORT$MS_ADMT,SQLServer2005SQLBrowserUser$LIB-SERVER,SQLServer2005MSSQLServerADHelperUser$LIB-SERVER,SQLServer2005MSSQLUser$LIB-SERVER$SQLEXPRESS,SQLServer2005SQLBrowserUser$MIS-TEST,SQLServer2005MSSQLServerADHelperUser$MIS-TEST,SQLServer2005MSSQLUser$MIS-TEST$MS_ADMT,SQLServerMSSQLServerADHelperUser$MIS-TEST"
                               },
                            new Setting
                                {
                                    SettingId=Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "EnableWeather",
                                    Value = "false"
                                },
                            new Setting
                                {
                                    SettingId=Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "WeatherApiKey",
                                    Value = debug ? "rm55wt3s923hffbddnjww2bk" : "" // Dev Key Only! Don't distribute or use in prod, will change!
                                },
                            new Setting
                                {
                                    SettingId=Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "OverrideWallPosts",
                                    Value = "true"
                                },
                            new Setting
                                {
                                    SettingId=Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "WallPostRssUrl",
                                    Value = "http://me.brentpabst.com/rss"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "UseOfficeLocations",
                                    Value = "false"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "UseDepartments",
                                    Value = "false"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationReminder",
                                    Value = "30"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationWarning",
                                    Value = "15"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationError",
                                    Value = "5"
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationReminderText",
                                    Value = "Your password will not expire for a while.  We will notify you when your password is closer to expiring."
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationWarningText",
                                    Value = "Your password will expire soon.  We recommend changing your password in the next few days."
                                },
                            new Setting
                                {
                                    SettingId = Guid.NewGuid(),
                                    IsEncrypted = false,
                                    Key = "PasswordNotificationErrorText",
                                    Value = "Your password expires very soon.  You should change your password as soon as possible!"
                                }
                       };
        }

        private List<QuickLink> QuickLinks()
        {
            return new List<QuickLink>
                       {
                           new QuickLink
                               {
                                   LinkId = Guid.NewGuid(),
                                   DisplayOrder = 3,
                                   NewWindow = true,
                                   Text = "Brent Pabst",
                                   Url = "http://www.brentpabst.com"
                               },
                           new QuickLink
                           {
                                   LinkId = Guid.NewGuid(),
                                   DisplayOrder = 1,
                                   NewWindow = false,
                                   Text = "uManage",
                                   Url = "http://umanage.203ent.com"
                           },
                           new QuickLink
                               {
                                   LinkId = Guid.NewGuid(),
                                   DisplayOrder = 2,
                                   NewWindow=false,
                                   Text="Fork us on GitHub",
                                   Url = "http://github.com/203ent/umanage"
                               }
                       };
        }

        private List<WallPost> WallPosts()
        {
            return new List<WallPost>
                       {
                           new WallPost
                               {
                                   PostId = Guid.NewGuid(),
                                   Title = "Welcome to uManage",
                                   PublishDate = DateTime.Today,
                                   IsDraft = false,
                                   Body = "<h2>Welcome to uManage!</h2><p>You have successfully installed uManage and are almost ready to start letting users access the system. There are a few more setup tasks to complete but they are all fairly painless and straightforward. At this point, you have setup the application, connected to the database, and connected to the directory.</p><p>The next steps all have to do with configuring uManage to work how you want it to work. These steps are typically needed for most installations:</p><ol><li>Configure Administrative Users &amp; Roles</li><li>Configure Locations</li><li>Configure Optional Settings</li></ol><h3>Feature Requests</h3><p>We obviously want to improve the system and make it easier for everyone to use. If you have, a specific feature or ideas in mind feel free to visit <a href=\"http://umanage.codeplex.com/WorkItem/Create\" target=\"_blank\">CodePlex</a> and suggest the feature. We cannot guarantee we will implement everything but we will at least look at your request.</p><p>If you want to code something out, feel free to fork/patch the repository and send it in!</p><h3>Getting Support &amp; Help</h3><p>uManage is an open source product and as such you can usually get support and additional documentation from <a href=\"http://umanage.codeplex.com/documentation\" target=\"_blank\">CodePlex</a>. If you need more assistance or want to inquire about specific customization commercial assistance is provided by <a href=\"http://www.203ent.com\" target=\"_blank\">203 Enterprises</a> along with consulting and technical assistance services.</p><p><em>You should probably remove this Wall Post before you allow users to access the system.</em></p>"
                               }
                       };
        }

        private List<Office> Offices()
        {
            return new List<Office>
                       {
                           new Office
                               {
                                   OfficeId = Guid.NewGuid(),
                                   Name = "1st Floor",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Office
                               {
                                   OfficeId = Guid.NewGuid(),
                                   Name = "2nd Floor",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Office
                               {
                                   OfficeId = Guid.NewGuid(),
                                   Name = "3rd Floor",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               }
                       };
        }

        private List<Department> Departments()
        {
            return new List<Department>
                       {
                           new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Executive",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Finance",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Technology",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Sales",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Marketing",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               },
                               new Department
                               {
                                   DepartmentId = Guid.NewGuid(),
                                   Name = "Operations",
                                   AddedOn = DateTime.Parse("7/1/2012")
                               }
                       };
        }
        #endregion
    }
}
