using System;
using System.Collections.Generic;
using Liki.App.Service.DTO;

namespace Liki.App.Service
{
    public interface ICustomerService
        : IDisposable
    {

        #region Method

        /// <summary>
        /// Add new customer 
        /// </summary>
        /// <param name="customerDto">The customer information</param>
        /// <returns>Added customer representation</returns>
        CustomerDTO AddNewCustomer(CustomerDTO customerDto);

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customerDto">The customerdto with changes</param>
        void UpdateCustomer(CustomerDTO customerDto);

        /// <summary>
        /// Remove existing customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        void RemoveCustomer(int customerId);


        /// <summary>
        /// Find customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>Selected customer representation if exist or null if not exist</returns>
        CustomerDTO FindCustomer(int customerId);

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomerDTO> GetAllCustomer();
        #endregion

    }
}
