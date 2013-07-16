using System;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.UserAgg;

namespace Liki.App.Service
{
    public class AuthenticationService : IAuthenticationService
    {

        #region Members

        private readonly IUserRepository _UserRepository;

        #endregion

        #region Constructors

        public AuthenticationService()
        {


        }

        /// <summary>
        /// Create a new instance of Authentication Service
        /// </summary>
        /// <param name="UserRepository"></param>
        public AuthenticationService(IUserRepository UserRepository)
        {
            if (UserRepository == null)
                throw new ArgumentNullException("UserRepository");

            _UserRepository = UserRepository;
        }

        #endregion

        #region IAuthenticationService Members

        /// <summary>
        /// User Login 
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public UserDTO UserLogin(string sUserName, string sPassword)
        {
            var current = _UserRepository.FindOne(x => x.EmailAddress == sUserName && x.Password == sPassword);
            if (current != null)
            {
                AutoMapper.Mapper.CreateMap<User, UserDTO>();
                return AutoMapper.Mapper.Map<User, UserDTO>(current);
            }
            return null;
        }

        #endregion
    }
}
