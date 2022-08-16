using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class JobSubCategory
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(555)]
        public string Name { get; set; }
        public long JobMainCategoryId { get; set; }
        public virtual JobMainCategory JobMainCategory { get; set; }
    }
    public class JobMainCategory
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(555)]
        public string Name { get; set; }
    }
    public class JobType
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Name { get; set; }
    }
    public class JobSchedule
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Name { get; set; }
    }
    public class SupplementalPay
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Name { get; set; }
    }
    public class BenefitOffered
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Name { get; set; }
    }
}
