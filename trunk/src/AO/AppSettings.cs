namespace THS.UMS.AO
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using THS.UMS.EF;

    public static class AppSettings
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            using (var ctx = new AppEntities())
            {
                var s = ctx.AppSettings.Where(c => c.Key == key).FirstOrDefault();

                if (s == null) throw new ConfigurationErrorsException("The key provided could not be located");

                return s.IsEncrypted ? DecryptValue(s.Value) : s.Value;
            }
        }

        /// <summary>
        /// Sets the value or creates a new AppSetting if the key is new.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool SetValue(string key, string value)
        {
            using (var ctx = new AppEntities())
            {
                var s = ctx.AppSettings.Where(c => c.Key == key).FirstOrDefault();

                try
                {

                    if (s == null)
                    {
                        // Key does not exist, add it as a new object
                        var newKey = new AppSetting
                                         {
                                             Key = key,
                                             Value = value,
                                             SettingId = Guid.NewGuid(),
                                             IsEncrypted = false
                                         };
                        ctx.AppSettings.AddObject(newKey);
                        ctx.SaveChanges();
                        return true;
                    }

                    s.Value = value;
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the settings collection.
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetSettingsCollection()
        {
            using (var ctx = new AppEntities())
            {
                var r = new List<KeyValuePair<string, string>>();
                foreach (var s in ctx.AppSettings)
                {
                    if (s == null) continue;
                    r.Add(new KeyValuePair<string, string>(s.Key, s.IsEncrypted ? DecryptValue(s.Value) : s.Value));
                }
                return r;
            }
        }

        /// <summary>
        /// Decrypts the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static string DecryptValue(string value)
        {
            throw new NotImplementedException("Encrypted settings are not yet supported.  Please store values in clear text.");
        }
    }
}
