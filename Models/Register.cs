using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSCB766_RentACar.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter your first name!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email!")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
