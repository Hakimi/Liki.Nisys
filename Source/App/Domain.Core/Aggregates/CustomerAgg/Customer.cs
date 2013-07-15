using System.ComponentModel.DataAnnotations;
using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.CustomerAgg
{
    public class Customer
        : Entity
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
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Get or set the email address 
        /// </summary>
        [Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email Address is not valid")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The customer first name
        /// </summary>
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the MiddleName
        /// </summary>
        [Required]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The customer lastName
        /// </summary>
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the Suffix
        /// </summary>
        [Required]
        [Display(Name = "Suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// Get or set the Password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        #endregion

        #region Method
        protected override void Validate()
        {
            if (FirstName == null)
                base.AddBrokenRule(CustomerBusinessRules.FirstNameRequired);

            if (LastName == null)
                base.AddBrokenRule(CustomerBusinessRules.LastNameRequired);

            if (EmailAddress == null)
                base.AddBrokenRule(CustomerBusinessRules.EmailRequired);

        }
        #endregion


    }
}
