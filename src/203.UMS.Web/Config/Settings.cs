using _203.UMS.Data.Contracts;
using _203.UMS.Models.App;
using _203.UMS.Security;
using System;
using System.Linq;

namespace _203.UMS.Web.Config
{
    public class Settings
    {
        #region Properties
        private readonly IRepoUow _repo;
        #endregion

        #region Ctor
        public Settings(IRepoUow uow)
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
            if (encrypt)
            {
                var byteArray = Crypto.Ecrypt(value.ToString());
                _repo.Settings.Add(new Setting { Key = key, ByteValue = byteArray, IsEncrypted = true });
            }
            else
            {
                _repo.Settings.Add(new Setting { Key = key, Value = value.ToString(), IsEncrypted = false });
            }
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
