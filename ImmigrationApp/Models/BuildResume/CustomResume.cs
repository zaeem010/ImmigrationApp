using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class CustomResume
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(455)]
        [Required(ErrorMessage ="Required")]
        public string FirstName { get; set; }
        [MaxLength(455)]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        [MaxLength(455)]
        public string PhoneNumber { get; set; }
        public bool ShowPhoneNumber { get; set; }
        //info
        [MaxLength(255)]
        public string Headline { get; set; }
        public string Summary { get; set; }
        //Address
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(55)]
        public string Province { get; set; }
        [MaxLength(255)]
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool ShowtoPublic { get; set; } = false;
        public bool Relocate { get; set; } = false;
        [EmailAddress]
        [MaxLength(455)]
        public string Email { get; set; }
        [MaxLength(455)]
        public string ResumeUrlPath { get; set; }
        [MaxLength(455)]
        public string SlugName { get; set; }
        public int UserId { get; set; }
        public virtual  User User { get; set; }
        //Education
        public List<ResumeEducation> ResumeEducationList { get; set; }
        public List<ResumeLanguageChild> ResumeLanguageChildList { get; set; }
        public List<ResumeLinkChild> ResumeLinkChildList { get; set; }
        //Work Experience
        public List<ResumeExperience> ResumeExperienceList { get; set; }
        public List<ResumeSkillChild> ResumeSkillChildList { get; set; }
        public CustomResume()
        {
            ResumeEducationList = new List<ResumeEducation>();
            ResumeLanguageChildList = new List<ResumeLanguageChild>();
            ResumeLinkChildList = new List<ResumeLinkChild>();
            ResumeExperienceList = new List<ResumeExperience>();
            ResumeSkillChildList = new List<ResumeSkillChild>();
        }
    }
    public class ResumeSkillChild 
    {
        [Key]
        public long Id { get; set; }
        public long CustomResumeId { get; set; }
        [MaxLength(455)]
        public string SkillName { get; set; }
        [MaxLength(455)]
        public string SkillLevel { get; set; }
        
    }
    public class ResumeLanguageChild 
    {
        [Key]
        public long Id { get; set; }
        public long CustomResumeId { get; set; }
        [MaxLength(255)]
        public string Values { get; set; }
    }
    public class ResumeLinkChild 
    {
        [Key]
        public long Id { get; set; }
        public long CustomResumeId { get; set; }
        [MaxLength(255)]
        public string Values { get; set; }
    }
    public class ResumeEducation 
    {
        [Key]
        public long Id { get; set; }
        public long CustomResumeId { get; set; }
        
        [MaxLength(255)]
        public string LevelofEducation { get; set; }
        [MaxLength(255)]
        public string FieldofStudy { get; set; }
        [MaxLength(255)]
        public string SchoolName { get; set; }
        [MaxLength(255)]
        public string StudyCountry { get; set; }
        [MaxLength(255)]
        public string StudyCity { get; set; }
        //Time Period
        public bool CurrentlyEnrolled { get; set; }
        [MaxLength(255)]
        public string FromYear { get; set; }
        [MaxLength(255)]
        public string FromMonth { get; set; }
        [MaxLength(255)]
        public string ToYear { get; set; }
        [MaxLength(255)]
        public string ToMonth { get; set; }
    }
    public class ResumeExperience
    {
        [Key]
        public long Id { get; set; }
        public long CustomResumeId { get; set; }

        [MaxLength(255)]
        public string JobTitle { get; set; }
        [MaxLength(455)]
        public string Company { get; set; }
        [MaxLength(255)]
        public string JobCountry { get; set; }
        [MaxLength(255)]
        public string JobCity { get; set; }
        //Time Period
        public bool CurrentlyEnrolled { get; set; }
        [MaxLength(255)]
        public string FromYear { get; set; }
        [MaxLength(255)]
        public string FromMonth { get; set; }
        [MaxLength(255)]
        public string ToYear { get; set; }
        [MaxLength(255)]
        public string ToMonth { get; set; }
        //Desc
        public string Description { get; set; }
    }

    public class Skill
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(455)]
        public string Name { get; set; }
        [MaxLength(455)]
        public string NormalizedName { get; set; }
    }
}
