using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Liki.Domain.Core.Aggregates.CustomerAgg;
using NUnit.Framework;

namespace Domain.Core.Test.Aggreemates.CustomerAgg
{
    [TestFixture]
    public class CustomerAggTests
    {
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateACustomerWithSSN()
        {
            var customer = new Customer();
        }

        #endregion
    }
}
