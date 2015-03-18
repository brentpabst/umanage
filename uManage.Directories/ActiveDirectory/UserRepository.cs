using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using uManage.Models;

namespace uManage.Directories.ActiveDirectory
{
    public class UserRepository:IUserRepository
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
        public IQueryable<User> GetAllUsers()
        {
            var u = new UserPrincipal(_ctx) { DisplayName = "*" };
            using (var ps = new PrincipalSearcher(u))
            {
                ps.QueryFilter = u;
                return ps.FindAll().OfType<UserPrincipal>().AsUserQueryable();
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public User GetUser(Guid userId)
        {
            return UserPrincipal.FindByIdentity(_ctx, userId.ToString()).AsUser();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userPrincipalName">Name of the user principal.</param>
        /// <returns></returns>
        public User GetUser(string userPrincipalName)
        {
            return UserPrincipal.FindByIdentity(_ctx, userPrincipalName).AsUser();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, user.UserId.ToString());
            if (p == null) return false;
            p.MergeUser(user);
            p.Save();
            return true;
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">This system will never delete user accounts, use disable instead.</exception>
        public bool DeleteUser(Guid userId)
        {
            throw new NotImplementedException("This system will never delete user accounts, use disable instead.");
        }

        /// <summary>
        /// Enables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool EnableUserAccount(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;
            p.Enabled = true;
            p.Save();
            return true;
        }

        /// <summary>
        /// Disables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool DisableUserAccount(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;
            p.Enabled = false;
            p.Save();
            return true;
        }

        /// <summary>
        /// Unlocks the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool UnlockUserAccount(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;
            p.UnlockAccount();
            p.Save();
            return true;
        }

        /// <summary>
        /// Expires the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool ExpireUserPassword(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;
            p.ExpirePasswordNow();
            p.Save();
            return true;
        }

        /// <summary>
        /// Sets the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public bool SetUserPassword(Guid userId, string pass)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;
            p.SetPassword(pass);
            p.Save();
            return true;
        }

        /// <summary>
        /// Clears the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool ClearUserPhoto(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return false;

            var e = p.GetUnderlyingObject() as DirectoryEntry;
            if (e == null) return false;

            e.SetProperty("jpegPhoto", "");
            e.SetProperty("thumbnailPhoto", "");
            p.Save();

            return true;
        }

        /// <summary>
        /// Gets the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public byte[] GetUserPhoto(Guid userId)
        {
            var p = UserPrincipal.FindByIdentity(_ctx, userId.ToString());
            if (p == null) return null;

            var e = p.GetUnderlyingObject() as DirectoryEntry;
            if (e == null) return null;

            return (byte[])e.Properties["jpegPhoto"].Value;
        }

        /// <summary>
        /// Updates the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        public bool UpdateUserPhoto(Guid userId, byte[] photo)
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
        }
    }
}
