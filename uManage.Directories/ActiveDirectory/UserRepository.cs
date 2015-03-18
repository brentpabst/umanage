using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using uManage.Models;

namespace uManage.Directories.ActiveDirectory
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly PrincipalContext _ctx;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public UserRepository(PrincipalContext ctx)
        {
            if (_ctx == null)
                _ctx = ctx;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<User>> GetAllUsers()
        {
            return await Task.Run(() =>
            {
                var u = new UserPrincipal(_ctx) { DisplayName = "*" };
                using (var ps = new PrincipalSearcher(u))
                {
                    ps.QueryFilter = u;
                    return ps.FindAll().OfType<UserPrincipal>().AsUserQueryable();
                }
            });
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUser(Guid userId)
        {
            return await Task.Run(() => UserPrincipal.FindByIdentity(_ctx, userId.ToString()).AsUser());
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userPrincipalName">Name of the user principal.</param>
        /// <returns></returns>
        public async Task<User> GetUser(string userPrincipalName)
        {
            return await Task.Run(() => UserPrincipal.FindByIdentity(_ctx, userPrincipalName).AsUser());
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> AddUser(User user)
        {
            return await Task.Run(() =>
            {
                throw new NotImplementedException();
                return false;
            });
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(User user)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, user.UserId.ToString());
                if (p == null) return false;
                p.MergeUser(user);
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">This system will never delete user accounts, use disable instead.</exception>
        public async Task<bool> DeleteUser(Guid userId)
        {
            return await Task.Run(() =>
            {
                throw new NotImplementedException("This system will never delete user accounts, use disable instead.");
                return false;
            });
        }

        /// <summary>
        /// Enables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<bool> EnableUserAccount(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;
                p.Enabled = true;
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Disables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<bool> DisableUserAccount(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;
                p.Enabled = false;
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Unlocks the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<bool> UnlockUserAccount(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;
                p.UnlockAccount();
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Expires the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<bool> ExpireUserPassword(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;
                p.ExpirePasswordNow();
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Sets the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public async Task<bool> SetUserPassword(Guid userId, string pass)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;
                p.SetPassword(pass);
                p.Save();
                return true;
            });
        }

        /// <summary>
        /// Clears the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<bool> ClearUserPhoto(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;

                var e = p.GetUnderlyingObject() as DirectoryEntry;
                if (e == null) return false;

                e.SetProperty("jpegPhoto", "");
                e.SetProperty("thumbnailPhoto", "");
                p.Save();

                return true;
            });
        }

        /// <summary>
        /// Gets the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<byte[]> GetUserPhoto(Guid userId)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return null;

                var e = p.GetUnderlyingObject() as DirectoryEntry;
                if (e == null) return null;

                return (byte[])e.Properties["jpegPhoto"].Value;
            });
        }

        /// <summary>
        /// Updates the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        public async Task<bool> UpdateUserPhoto(Guid userId, byte[] photo)
        {
            return await Task.Run(() =>
            {
                var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
                if (p == null) return false;

                var e = p.GetUnderlyingObject() as DirectoryEntry;
                if (e == null) return false;

                // Not using the extension method here as it doesn't currently support byte arrays
                e.Properties["jpegPhoto"].Value = photo;
                e.Properties["thumbnailPhoto"].Value = photo;
                p.Save();

                return true;
            });
        }
    }
}
