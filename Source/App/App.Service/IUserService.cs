using System;
using System.Collections.Generic;
using Liki.App.Service.DTO;

namespace Liki.App.Service
{
    public interface IUserService
        : IDisposable
    {
        #region Method

        /// <summary>
        /// Add new User 
        /// </summary>
        /// <param name="UserDto">The User information</param>
        /// <returns>Added User representation</returns>
        UserDTO AddNewUser(UserDTO UserDto);

        /// <summary>
        /// Update existing User
        /// </summary>
        /// <param name="UserDto">The Userdto with changes</param>
        void UpdateUser(UserDTO UserDto);

        /// <summary>
        /// Remove existing User
        /// </summary>
        /// <param name="UserId">The User identifier</param>
        void RemoveUser(int UserId);


        /// <summary>
        /// Find User
        /// </summary>
        /// <param name="UserId">The User identifier</param>
        /// <returns>Selected User representation if exist or null if not exist</returns>
        UserDTO FindUser(int UserId);

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDTO> GetAllUser();

        #endregion
    }
}
