using System;
using System.Linq;
using uManange.Models;

namespace uManage.Directories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetAllUsers();
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        User GetUser(Guid userId);
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userPrincipalName">Name of the user principal.</param>
        /// <returns></returns>
        User GetUser(string userPrincipalName);
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool AddUser(User user);
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool UpdateUser(User user);
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool DeleteUser(Guid userId);
        /// <summary>
        /// Enables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool EnableUserAccount(Guid userId);
        /// <summary>
        /// Disables the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool DisableUserAccount(Guid userId);
        /// <summary>
        /// Unlocks the user account.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool UnlockUserAccount(Guid userId);
        /// <summary>
        /// Expires the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool ExpireUserPassword(Guid userId);
        /// <summary>
        /// Sets the user password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        bool SetUserPassword(Guid userId, string pass);
        /// <summary>
        /// Clears the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool ClearUserPhoto(Guid userId);
        /// <summary>
        /// Gets the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        byte[] GetUserPhoto(Guid userId);
        /// <summary>
        /// Updates the user photo.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        bool UpdateUserPhoto(Guid userId, byte[] photo);
    }
}
