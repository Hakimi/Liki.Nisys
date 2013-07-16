using System;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.UserAgg;
using System.Collections.Generic;
using System.Linq;
namespace Liki.App.Service
{
    public class UserService
        : ThrowExceptionValidation<User>, IUserService
    {

        #region Members

        private readonly IUserRepository _UserRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of User Management Service
        /// </summary>
        /// <param name="UserRepository">Associated UserRepository, intented to be resolved with DI</param>
        /// <param name="countryRepository">Associated country repository</param>
        /// 
        //public UserService()
        //    : this(DependencyResolver.Current.GetService<UserRepository>())
        //{
        //}
        public UserService(IUserRepository UserRepository)
            //the User repository                               
        {
            if (UserRepository == null)
                throw new ArgumentNullException("UserRepository");

            _UserRepository = UserRepository;
        }

        #endregion

        #region IUserService Method

        /// <summary>
        /// Add New User and Update User
        /// </summary>
        /// <param name="UserDto"></param>
        /// <returns></returns>
        public UserDTO AddNewUser(UserDTO UserDto)
        {

            var User = UserFactory.CreateUser(UserDto.UserID, UserDto.Title, UserDto.EmailAddress,
                                              UserDto.FirstName, UserDto.MiddleName,
                                              UserDto.LastName, UserDto.Suffix, UserDto.Password);

            this.ThrowExceptionIfUserIsInvalid(User);

            //save entity
            SaveUser(User);
            AutoMapper.Mapper.CreateMap<User, UserDTO>();
            //return the data with id and assigned default values
            return AutoMapper.Mapper.Map<User, UserDTO>(User);

        }


        /// <summary>
        /// Find User by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserDTO FindUser(int UserId)
        {
            ////recover existing User and map
            var User = _UserRepository.GetByKey(UserId);

            if (User != null) //adapt
            {
                AutoMapper.Mapper.CreateMap<User, UserDTO>();
                return AutoMapper.Mapper.Map<User, UserDTO>(User);
            }
            else
                return null;
            return null;
        }


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>IEnumerable of UserDTO</returns>
        public IEnumerable<UserDTO> GetAllUser()
        {
            var User = _UserRepository.GetAll();
            AutoMapper.Mapper.CreateMap<User, UserDTO>();
            IEnumerable<UserDTO> UserDtos =
                AutoMapper.Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(
                    User.Cast<User>().AsEnumerable());
            return UserDtos;
        }

        /// <summary>
        /// only update User
        /// </summary>
        /// <param name="UserDto"></param>
        public void UpdateUser(UserDTO UserDto)
        {
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
            User User = AutoMapper.Mapper.Map<UserDTO, User>(UserDto);
            _UserRepository.Update(User);
            _UserRepository.UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// SaveUser
        /// </summary>
        /// <param name="User"></param>
        private void SaveUser(User User)
        {
            if (User.UserID == 0)
            {
                _UserRepository.Add(User);
            }
            else
            {
                _UserRepository.Update(User);
            }
            _UserRepository.UnitOfWork.SaveChanges();
        }


        /// <summary>
        /// remove User from database
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        public void RemoveUser(int UserId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Method

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            // _UserRepository.Dispose();
        }

        #endregion
    }
}
