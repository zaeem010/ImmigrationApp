using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class CompanyInfo
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Company { get; set; }
        [Required(ErrorMessage = "Required")]
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
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(455)]
        public string SlugName { get; set; }
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
        public List<Job> JobList { get; set; }
        public CompanyInfo()
        {
            JobList = new List<Job>();
        }
        [NotMapped]
        public int JobAgainst => JobList.Where(x => x.CompanyInfoId == Id).Count();

    }

}
