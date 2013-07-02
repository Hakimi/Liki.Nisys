using System;
using System.Web.Mvc;
using Liki.Core.Interface.Service;
using Liki.Core.Model;
using Liki.Data;

namespace Liki.Service
{
    public class CustomerService : GenericRepository,ICustomerService
    {
       
        private LikiDbContext _LikiDbContext;
        public CustomerService()
         {
             _LikiDbContext = new LikiDbContext() ;
        }
        
        #region ICustomerService Members

        public void AddCustomer(Customer _customer)
        {
            this.Add(_customer);
            this.UnitOfWork.SaveChanges();
            
            
        }

        #endregion
    }
}
