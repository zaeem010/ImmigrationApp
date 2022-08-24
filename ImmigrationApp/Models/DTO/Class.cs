using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberOfEmployee { get; set; }
        public string Contact { get; set; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        
        public string ConfirmPassword { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
