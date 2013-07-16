using System.Web.Http;
using Liki.App.Service;
using Liki.App.Service.DTO;

namespace Liki.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        #region Members
        IUserService _UserService;
        #endregion

        #region Constructors
        
        public UserController(IUserService _Userservice)
            : base()
        {
            _UserService = _Userservice;
        }
        #endregion
    
        #region Method

        // GET api/User
        public UserDTO Get()
        {
             
            UserDTO _User = new UserDTO();
            _User.UserID = 31;
            _User.EmailAddress = "tarun11111111";
            _User.FirstName = "tarun";
            _User.LastName = "jadav";
            _User.Title = "TEST";
            _User.MiddleName = "test22222";
            _User.Password = "testss";
            _User.Suffix = "sdfsdf";
           
            
            return _UserService.AddNewUser(_User);

        }

        // GET api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/User/5
        public void Delete(int id)
        {
        }
        #endregion

    }
}
