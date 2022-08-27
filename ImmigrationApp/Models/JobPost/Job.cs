using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class Job
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(555)]
        public string Title { get; set; }

        public bool SpecificAddress { get; set; }
        
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(55)]
        public string Province { get; set; }
        [MaxLength(255)]
        public string PostalCode { get; set; }
        //
        [MaxLength(255)]
        public string AddressToAdvertise { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool PlanedstartDate { get; set; }
        public DateTime? StartDate { get; set; }
        [MaxLength(255)]
        public string Numberofvaccant { get; set; }
        [MaxLength(255)]
        public string HireSpeed { get; set; }

        [MaxLength(255)]
        public string ShowPayby { get; set; }
        public double MinPay { get; set; }
        public double MaxPay { get; set; }
        public double Amount { get; set; }
        [MaxLength(155)]
        public string Rate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(55)]
        public string ResumeSubmit { get; set; }
        public bool Deadline { get; set; }
        public DateTime? DeadlineDate { get; set; }
        //
        public long JobSubCategoryId { get; set; }
        public int UserId { get; set; }
        //
        public virtual JobSubCategory JobSubCategory { get; set; }
        public virtual User User { get; set; }
        public virtual List<JobTypeChild> JobTypeChildList { get; set; }
        public virtual List<JobScheduleChild> JobScheduleChildList { get; set; }
        public virtual List<SupplementalPayChild> SupplementalPayChildList { get; set; }
        public virtual List<BenefitOfferedChild> BenefitOfferedChildList { get; set; }
        public virtual List<JobEmailChild> JobEmailChildList { get; set; }
    }
    public class JobTypeChild 
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        public double? Hours { get; set; }
        public double? ContractLength { get; set; }
        [MaxLength(155)]
        public string ContractPeriod { get; set; }
        public long JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }
    }
    public class JobScheduleChild 
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long JobScheduleId { get; set; }
        public virtual JobSchedule JobSchedule { get; set; }
    }
    public class SupplementalPayChild
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long SupplementalPayId { get; set; }
        public virtual SupplementalPay SupplementalPay { get; set; }
    }
    public class BenefitOfferedChild
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long BenefitOfferedId { get; set; }
        public virtual BenefitOffered BenefitOffered { get; set; }
    }
    public class JobEmailChild
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        [EmailAddress]
        [MaxLength(455)]
        public string Emails { get; set; }
    }
}
