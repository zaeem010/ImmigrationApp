using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class ChatHubVM
    {
        public List<PeopleHubDTO> peopleHub { get; set; }
        public ChatAppHub ChatAppHub { get; set; }
        public List<ChatAppHub> chatAppHublist { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string SlugName { get; set; }
        public string Type { get; set; }
    }
    public class SearchjobVM
    {
        public HomeDTO HomeDTO { get; set; }
        public List<JobDTO> JobDTOList { get; set; }
        public List<JobType> JobTypeList { get; set; }
        public string Key { get; set; }
    }
    public class CanidateVM
    {
        public CustomResume CustomResume { get; set; }
        public List<Skill> SkillList { get; set; }
        public List<CustomResume> CustomResumeList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
    public class JobDetailVM
    {
        public JobDTO JobDTO { get; set; }
        public List<JobType> JobTypeList { get; set; }
    }
    public class CompanyInfoVM
    {
        public CompanyInfo CompanyInfo { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public IEnumerable<SelectListItem> JobMainCategoryList { get; set; }
    }
    public class HomeVM
    {
        public HomeDTO HomeDTO { get; set; }
        public List<CompanyInfo> CompanyInfoList { get; set; }
        public List<JobDTO> JobList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public int UserId { get; set; }
    }
    public class JobVM
    {
        public Job Job { get; set; }
        public List<JobType> JobTypeList { get; set; }
        public List<JobSchedule> JobScheduleList { get; set; }
        public List<SupplementalPay> SupplementalPayList { get; set; }
        public List<BenefitOffered> BenefitOfferedList { get; set; }
        public int UserId { get; set; }
        public long CompanyId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}
