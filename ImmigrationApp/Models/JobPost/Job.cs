using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = "Required")]
        public bool SpecificAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string City { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(55)]
        public string Province { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string PostalCode { get; set; }
        //
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string AddressToAdvertise { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool PlanedstartDate { get; set; }
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string Numberofvaccant { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255)]
        public string HireSpeed { get; set; }

        [MaxLength(255)]
        public string ShowPayby { get; set; }
        [Required(ErrorMessage = "Required")]
        public double MinPay { get; set; }
        [Required(ErrorMessage = "Required")]
        public double MaxPay { get; set; }
        [Required(ErrorMessage = "Required")]
        public double Amount { get; set; }
        [MaxLength(155)]
        public string Rate { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinLength(30),MaxLength(10000)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(55)]
        public string ResumeSubmit { get; set; }
        public bool Deadline { get; set; }
        public DateTime? DeadlineDate { get; set; }
        //
        public long JobSubCategoryId { get; set; }
        public long CompanyInfoId { get; set; }
        public int UserId { get; set; }
        public DateTime PostDateTime { get; set; }
        public bool Verify { get; set; } = false;
        [MaxLength(455)]
        public string SlugName { get; set; }
        [MaxLength(455)]
        public string CallBy { get; set; }
        //
        public virtual JobSubCategory JobSubCategory { get; set; }
        public virtual User User { get; set; }
        public virtual List<JobTypeChild> JobTypeChildList { get; set; }
        public virtual List<JobScheduleChild> JobScheduleChildList { get; set; }
        public virtual List<SupplementalPayChild> SupplementalPayChildList { get; set; }
        public virtual List<BenefitOfferedChild> BenefitOfferedChildList { get; set; }
        public virtual List<JobEmailChild> JobEmailChildList { get; set; }
       
        [NotMapped]
        public int DayPassed => (DateTime.Now - PostDateTime).Days ;
        [NotMapped]
        public int HourPassed => (DateTime.Now - PostDateTime).Hours;
        [NotMapped]
        public int MinPassed => (DateTime.Now - PostDateTime).Minutes;
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
    public class ApplyforJob
    {
        [Key]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long EmployerId { get; set; }
        public long CanidateId { get; set; }
        [MaxLength(455)]
        public string CoverLetter { get; set; }
        [MaxLength(55)]
        public string AppliedUsing { get; set; }
        public DateTime AppliedDate { get; set; }
        [MaxLength(100)]
        public string Status { get; set; }
        [NotMapped]
        public User myuser { get; set; }
        [NotMapped]
        public CustomResume mycustomresume { get; set; }
        [NotMapped]
        public Job myJob { get; set; }
    }
}
