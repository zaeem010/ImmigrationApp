using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationApp.Models
{
    public class User : IdentityUser<int>
    {
        [MaxLength(455)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsResetPasswordRequired { get; set; }
        [MaxLength(255)]
        public string Type { get; set; }
        #region Not Mapped Properties
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public IList<string> Roles { get; set; }
        [NotMapped]
        public bool IsAddedFromPortal { get; set; } = false;
        #endregion
    }
}
