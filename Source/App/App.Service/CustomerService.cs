using System;
using Liki.App.Service.DTO;
using Liki.Domain.Core.Aggregates.CustomerAgg;
using System.Collections.Generic;
using System.Linq;
namespace Liki.App.Service
{
    public class CustomerService
        : ThrowExceptionValidation<Customer>, ICustomerService
    {


        #region Members

        private readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of Customer Management Service
        /// </summary>
        /// <param name="customerRepository">Associated CustomerRepository, intented to be resolved with DI</param>
        /// <param name="countryRepository">Associated country repository</param>
        /// 
        //public CustomerService()
        //    : this(DependencyResolver.Current.GetService<CustomerRepository>())
        //{
        //}
        public CustomerService(ICustomerRepository customerRepository)
        //the customer repository                               
        {
            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _customerRepository = customerRepository;
        }

        #endregion

        #region ICustomerService Method
        /// <summary>
        /// Add New customer and Update customer
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        public CustomerDTO AddNewCustomer(CustomerDTO customerDto)
        {

            var customer = CustomerFactory.CreateCustomer(customerDto.CustomerID, customerDto.Title, customerDto.EmailAddress,
                                                          customerDto.FirstName, customerDto.MiddleName,
                                                          customerDto.LastName, customerDto.Suffix, customerDto.Password);

            this.ThrowExceptionIfCustomerIsInvalid(customer);

            //save entity
            SaveCustomer(customer);
            AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
            //return the data with id and assigned default values
            return AutoMapper.Mapper.Map<Customer, CustomerDTO>(customer);

        }


        /// <summary>
        /// Find customer by Customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerDTO FindCustomer(int customerId)
        {
            ////recover existing customer and map
            var customer = _customerRepository.GetByKey(customerId);

            if (customer != null) //adapt
            {
                AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
                return AutoMapper.Mapper.Map<Customer, CustomerDTO>(customer);
            }
            else
                return null;
            return null;
        }


        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns>IEnumerable of customerDTO</returns>
        public IEnumerable<CustomerDTO> GetAllCustomer()
        {
            var customer = _customerRepository.GetAll();
            AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
            IEnumerable<CustomerDTO> customerDtos =
                AutoMapper.Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(
                    customer.Cast<Customer>().AsEnumerable());
            return customerDtos;
        }
        /// <summary>
        /// only update customer
        /// </summary>
        /// <param name="customerDto"></param>
        public void UpdateCustomer(CustomerDTO customerDto)
        {
            AutoMapper.Mapper.CreateMap<CustomerDTO, Customer>();
            Customer customer = AutoMapper.Mapper.Map<CustomerDTO, Customer>(customerDto);
            _customerRepository.Update(customer);
            _customerRepository.UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// SaveCustomer
        /// </summary>
        /// <param name="customer"></param>
        private void SaveCustomer(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                _customerRepository.Add(customer);
            }
            else
            {
                _customerRepository.Update(customer);
            }
            _customerRepository.UnitOfWork.SaveChanges();
        }
         

        /// <summary>
        /// remove customer from database
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveCustomer(int customerId)
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
            // _customerRepository.Dispose();
        }

        #endregion



    }
}
