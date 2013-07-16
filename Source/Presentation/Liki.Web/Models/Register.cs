using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Liki.Web.Models
{
    public class Register
    {
        #region Property

        /// <summary>
        /// The User identifier
        /// </summary>
        //[Key]
        public int UserID { get; set; }

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
        /// The User first name
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
        /// The User lastName
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

        #endregion

    }
}