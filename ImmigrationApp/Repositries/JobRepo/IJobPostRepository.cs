using ImmigrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
{
    public interface IJobPostRepository
    {
        Task<List<Job>> GetAllJob();
        Task<Job> GetJob(long id);
        Task<long> GetCompanyId(int id);
        Task<List<JobType>> GetJobType();
        Task<List<JobSchedule>> GetJobSchedule();
        Task<List<SupplementalPay>> GetSupplementalPay();
        Task<List<BenefitOffered>> GetBenefitOffered();
        Task<string> SaveJob(Job Job);
        //void DeleteJob(long id);
        //void UpdateJob(Job Job);

    }
}
