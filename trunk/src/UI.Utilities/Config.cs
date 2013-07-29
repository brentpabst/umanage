namespace THS.UMS.UI.Utilities
{
    using System;
    using System.Configuration;
    using System.Data.EntityClient;
    using System.IO;
    using System.Net;
    using System.Net.Configuration;
    using System.Net.Mail;
    using System.Web;
    using System.Web.Configuration;

    public class Config
    {
        private readonly Configuration _conf;

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        public Config()
        {
            _conf = WebConfigurationManager.OpenWebConfiguration("~");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="path">The path to the configuration file.</param>
        public Config(string path)
        {
            if (File.Exists(path))
                _conf = ConfigurationManager.OpenExeConfiguration(path);
            else
                _conf = WebConfigurationManager.OpenWebConfiguration(path);
        }

        /// <summary>
        /// Gets the authorization settings.
        /// </summary>
        /// <returns></returns>
        public AuthorizationSection GetAuthorizationSettings()
        {
            return (AuthorizationSection)_conf.GetSection("system.web/authorization");
        }

        /// <summary>
        /// Gets the mail settings.
        /// </summary>
        /// <returns></returns>
        public MailSettingsSectionGroup GetMailSettings()
        {
            return (MailSettingsSectionGroup)_conf.GetSectionGroup("system.net/mailSettings");
        }

        /// <summary>
        /// Saves the mail settings.
        /// </summary>
        /// <param name="m">The mailsettingssectiongroup to use.</param>
        /// <param name="t">The test address to use.</param>
        /// <returns></returns>
        public bool SaveMailSettings(MailSettingsSectionGroup m, string t)
        {
            try
            {
                // Test new Configuration
                string body;

                try
                {
                    var file = HttpContext.Current.Server.MapPath("~/App_Data/Templates/EmailTest.txt");
                    var objReader = File.OpenText(file);
                    body = objReader.ReadToEnd();
                    objReader.Close();
                }
                catch
                {
                    throw new IOException("Failed to read template file or create new file");
                }

                // Define the message
                var msg = new MailMessage(m.Smtp.From, t)
                              {
                                  Subject = "uManage Test Email",
                                  Body = body,
                                  IsBodyHtml = true
                              };

                // Send the message
                var smtp = new SmtpClient(m.Smtp.Network.Host, m.Smtp.Network.Port) { EnableSsl = m.Smtp.Network.EnableSsl };

                if (m.Smtp.Network.DefaultCredentials)
                {
                    smtp.UseDefaultCredentials = true;
                }
                else if (String.IsNullOrWhiteSpace(m.Smtp.Network.UserName))
                {
                    smtp.UseDefaultCredentials = false;
                }
                else
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(m.Smtp.Network.UserName, m.Smtp.Network.Password);
                }

                smtp.Send(msg);

                // Encrypt mail section
                ProtectSection(m.SectionGroupName + "/smtp");

                // Save settings
                SaveConfiguration();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the database settings.
        /// </summary>
        /// <returns></returns>
        public EntityConnectionStringBuilder GetDatabaseSettings()
        {
            return new EntityConnectionStringBuilder
                        {
                            ConnectionString = _conf.ConnectionStrings.ConnectionStrings["AppEntities"].ConnectionString
                        };
        }

        /// <summary>
        /// Sets the database settings.
        /// </summary>
        /// <param name="sqlConn">The SQL conn.</param>
        /// <returns></returns>
        public bool SetDatabaseSettings(string sqlConn)
        {
            var efConn = new EntityConnectionStringBuilder()
                             {
                                 ProviderConnectionString = sqlConn,
                                 Provider = "System.Data.SqlClient",
                                 Metadata = @"res://*/App.csdl|res://*/App.ssdl|res://*/App.msl"
                             };
            _conf.ConnectionStrings.ConnectionStrings["AppEntities"].ConnectionString = efConn.ConnectionString;

            try
            {
                SaveConfiguration();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the value of the application setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetApplicationSetting(string key, string value)
        {
            _conf.AppSettings.Settings[key].Value = value;
        }

        /// <summary>
        /// Encrypts the section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        private void ProtectSection(string sectionName)
        {
            var s = _conf.GetSection(sectionName);

            if (s == null || s.SectionInformation.IsProtected) return;

            s.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            SaveConfiguration();
        }

        /// <summary>
        /// Decrypts the protected section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        public void UnProtectSection(string sectionName)
        {
            var s = _conf.GetSection(sectionName);

            if (s == null || !s.SectionInformation.IsProtected) return;

            s.SectionInformation.UnprotectSection();

            SaveConfiguration();
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            _conf.Save();
        }
    }
}
