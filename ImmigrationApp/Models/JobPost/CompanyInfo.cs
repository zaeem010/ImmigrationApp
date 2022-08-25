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
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(255)]
        public string PostCode { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        //
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string TwitterUrl { get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string LinkedinUrl { get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string WebsiteUrl{ get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string FacebookUrl { get; set; }
        public virtual User User { get; set; }
    }
    public class CompanyInfoDTO
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Required")]
        public string NumberOfEmployee { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Industry { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        //
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string TwitterUrl { get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string LinkedinUrl { get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string WebsiteUrl{ get; set; }
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string FacebookUrl { get; set; }
        public virtual User User { get; set; }
    }
}
