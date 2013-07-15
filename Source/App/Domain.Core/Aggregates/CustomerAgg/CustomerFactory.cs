namespace Liki.Domain.Core.Aggregates.CustomerAgg
{
    /// <summary>
    /// This is the factory for Customer creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class CustomerFactory
    {
        #region Method

        /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="sTitle"></param>
        /// <param name="sEmailAddress"></param>
        /// <param name="sFirstName"></param>
        /// <param name="sMiddleName"></param>
        /// <param name="sLastName"></param>
        /// <param name="sSuffix"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public static Customer CreateCustomer(int CustomerID, string sTitle, string sEmailAddress, string sFirstName, string sMiddleName, string sLastName, string sSuffix, string sPassword)
        {
            //create new instance and set identity
            var customer = new Customer
            {
                CustomerID = CustomerID,
                Title = sTitle,
                EmailAddress = sEmailAddress,
                FirstName = sFirstName,
                MiddleName = sMiddleName,
                LastName = sLastName,
                Suffix = sSuffix,
                Password = sPassword
            };

            // customer.GenerateNewIdentity();

            //set data

            return customer;
        }
        #endregion

    }
}
