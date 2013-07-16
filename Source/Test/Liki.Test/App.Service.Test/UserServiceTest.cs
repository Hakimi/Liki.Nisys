using Liki.App.Service;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.UserAgg;
using NUnit.Framework;
using Rhino.Mocks;

namespace App.Service.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        IUserService _UserService;
        IUserRepository _UserRepository;    
       
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void CreateUser()
        {
            _UserRepository = MockRepository.GenerateMock<IUserRepository>();
            _UserService = new UserService(_UserRepository);
            UserDTO _User = new UserDTO();
            _User.UserID = 0;
            _User.EmailAddress = "tarun";
            _User.FirstName = "tarun";
            _User.LastName = "jadav";
            _User = _UserService.AddNewUser(_User);
        }

        #endregion
    }
}
