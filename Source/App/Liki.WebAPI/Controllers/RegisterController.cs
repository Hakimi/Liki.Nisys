using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Liki.App.Service;
using Liki.App.Service.DTO;

namespace Liki.WebAPI.Controllers
{
    public class RegisterController : ApiController
    {
        #region Members

        private readonly IUserService _iUserService;

        #endregion

        #region Constructors

        public RegisterController(IUserService Userservice)
        {
            _iUserService = Userservice;
        }

        #endregion

        #region Method

        // GET api/register
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> Get()
        {
            return _iUserService.GetAllUser();
        }

        // GET api/values/5
        public UserDTO Get(int id)
        {
            return _iUserService.FindUser(id);
        }

        // POST api/register
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="dto">Userdto object</param>
        /// <returns></returns>
        public bool Post(UserDTO dto)
        {
            //dto.UserFID = Guid.NewGuid().ToString().Substring(0, 10);
            if (ModelState.IsValid)
            {
                _iUserService.AddNewUser(dto);

                return true;
            }
            return false;
        }

        // PUT api/register/5
        /// <summary>
        /// Edit User Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserDto"></param>
        /// <returns></returns>
        public HttpResponseMessage PutRegister(int id, UserDTO UserDto)
        {
            _iUserService.UpdateUser(UserDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion
    }

}
