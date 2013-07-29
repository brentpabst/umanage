using System;
using System.Text;
using UMS.Core.Data.Models.App;
using UMS.Core.Data.Repository;
using UMS.Core.Security;

namespace UMS.Core.Logic.Config
{
    public static class Settings
    {
        private static readonly SettingRepository Repo = new SettingRepository();

        public static T Get<T>(string key)
        {
            try
            {
                var s = Repo.Find(key);

                var v = s.IsEncrypted ? Crypto.Decrypt(s.Value) : s.Value;

                return (T)Convert.ChangeType(v, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static void Put(string key, object value)
        {
            Put(key, value, false);
        }

        public static void Put(string key, object value, bool encrypt)
        {
            if (encrypt)
            {
                value = Crypto.Ecrypt(value.ToString());
            }

            Repo.InsertOrUpdate(new Setting { Key = key, Value = value.ToString(), IsEncrypted = encrypt });
            Repo.Save();
        }

        public static void Delete(string key)
        {
            Repo.Delete(key);
            Repo.Save();
        }
    }
}
