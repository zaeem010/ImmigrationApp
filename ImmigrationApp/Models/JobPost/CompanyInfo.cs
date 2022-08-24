using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class CompanyInfo
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(455)]
        public string Company { get; set; }
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        
        [MaxLength(255)]
        public string NumberOfEmployee { get; set; }
        [MaxLength(255)]
        public string Industry { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
