namespace Liki.App.Service.DTO
{
    /// <summary>
    /// This is the data transfer object
    /// for customer entity. The name
    /// of properties for this type
    /// is based on conventions of many mappers
    /// to simplificate the mapping process
    /// </summary>
    public class CustomerDTO
    {
        #region Property
        
        /// <summary>
        /// The customer identifier
        /// </summary>
        //[Key]
        public int CustomerID { get; set; }

        /// <summary>
        /// Get or set the Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set the email address 
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The customer first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the MiddleName
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The customer lastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the Suffix
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Get or set the Password
        /// </summary>
        public string Password { get; set; }
        #endregion
    }
}
