using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.ViewModels
{
    public class RegisterViewModel
    {
        [Required,EmailAddress,MaxLength(256), Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required, MinLength(6), MaxLength(25), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(25), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword{ get; set; }
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }
    }
}
