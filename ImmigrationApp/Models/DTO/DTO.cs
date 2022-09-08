using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class SearchDTO
    {
        public string Title { get; set; }
        public string category { get; set; }
        public string datepost { get; set; }
        public double minval { get; set; }
        public double maxval { get; set; }
        public List<long> types { get; set; }
    }
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
    public class UserCandidateDto
    {
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
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
    public class LoginDTO
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class JobDTO
    {
        public long Id { get; set; }
        public string logoPath { get; set; }
        public string Title { get; set; }
        
        public bool SpecificAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string AddressToAdvertise { get; set; }
        public string Industry { get; set; }
        public string Vacant { get; set; }
        public string Description { get; set; }
        public string SlugName { get; set; }
        public DateTime? StartDate { get; set; }

        public string ShowBy { get; set; }
        public string Rate { get; set; }
        public double MinPay { get; set; }
        public double MaxPay { get; set; }
        public double Amount { get; set; }
        public List<JobTypeChild> jobTypes { get; set; }
        public DateTime PostDateTime { get; set; }

        public int DayPassed => (DateTime.Now - PostDateTime).Days;
        public int HourPassed => (DateTime.Now - PostDateTime).Hours;
        public int MinPassed => (DateTime.Now - PostDateTime).Minutes;
    }
}
