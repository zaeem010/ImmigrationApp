using ImmigrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
{
    public interface IJobPostRepository
    {
        IEnumerable<Job> GetAllJob();
        Job GetJob(long id);
        Task<List<JobType>> GetJobType();
        Task<List<JobSchedule>> GetJobSchedule();
        Task<List<SupplementalPay>> GetSupplementalPay();
        Task<List<BenefitOffered>> GetBenefitOffered();
        Task<string> SaveJob(Job Job);
        //void DeleteJob(long id);
        //void UpdateJob(Job Job);

    }
}
