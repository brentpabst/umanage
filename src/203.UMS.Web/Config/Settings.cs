using _203.UMS.Data.Interfaces;
using _203.UMS.Models.App;
using _203.UMS.Security;
using System;
using System.Linq;

namespace _203.UMS.Web.Config
{
    public class Settings
    {
        #region Properties
        private readonly IDbUow _repo;
        #endregion

        #region Ctor
        public Settings(IDbUow uow)
        {
            _repo = uow;
        }
        #endregion

        public T Get<T>(string key)
        {
            try
            {
                var s = _repo.Settings.GetAll().FirstOrDefault(set => set.Key == key);

                var v = s != null && s.IsEncrypted ? Crypto.Decrypt(s.ByteValue) : s.Value;

                return (T)Convert.ChangeType(v, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public void Put(string key, object value)
        {
            Put(key, value, false);
        }

        public void Put(string key, object value, bool encrypt)
        {
            var isNew = false;
            var s = _repo.Settings.GetAll().FirstOrDefault(k => k.Key == key);
            if (s == null)
            {
                isNew = true;
                s = new Setting { SettingId = Guid.NewGuid(), Key = key };
            }

            if (encrypt)
            {
                s.ByteValue = Crypto.Ecrypt(value.ToString());
                s.IsEncrypted = true;
                s.Value = null;
            }
            else
            {
                s.ByteValue = null;
                s.IsEncrypted = false;
                s.Value = value.ToString();
            }

            if (isNew)
                _repo.Settings.Add(s);
            else
                _repo.Settings.Update(s);

            _repo.Commit();
        }

        public void Delete(string key)
        {
            var s = _repo.Settings.GetAll().FirstOrDefault(set => set.Key == key);
            _repo.Settings.Delete(s);
            _repo.Commit();
        }
    }
}
