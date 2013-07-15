using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Liki.App.Service;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.CustomerAgg;
using Liki.Domain.Seedwork;
using NUnit.Framework;
using Rhino.Mocks;

namespace App.Service.Test
{
    [TestFixture]
    public class CustomerServiceTest
    {
        ICustomerService _CustomerService;
        ICustomerRepository _CustomerRepository;    
       
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
        public void CreateCustomer()
        {
            _CustomerRepository = MockRepository.GenerateMock<ICustomerRepository>();
            _CustomerService = new CustomerService(_CustomerRepository);
            CustomerDTO _customer = new CustomerDTO();
            _customer.CustomerID = 0;
            _customer.EmailAddress = "tarun";
            _customer.FirstName = "tarun";
            _customer.LastName = "jadav";
            _customer = _CustomerService.AddNewCustomer(_customer);
        }

        #endregion
    }
}
