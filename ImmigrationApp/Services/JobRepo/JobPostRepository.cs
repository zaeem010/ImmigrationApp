using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
{
    public class JobPostRepository : IJobPostRepository
    {
        private ApplicationDbContext _db;
        public JobPostRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<JobType>>  GetJobType()
        {
            var Type = await _db.JobType.ToListAsync();
            return Type;
        }
        public async Task<List<JobSchedule>> GetJobSchedule()
        {
            var List = await _db.JobSchedule.ToListAsync();
            return List;
        }

        public IEnumerable<Job> GetAllJob()
        {
            throw new NotImplementedException();
        }

        public Job GetJob(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SupplementalPay>> GetSupplementalPay()
        {
            var List = await _db.SupplementalPay.ToListAsync();
            return List;
        }

        public async Task<List<BenefitOffered>> GetBenefitOffered()
        {
            var List = await _db.BenefitOffered.ToListAsync();
            return List;
        }
    }
}
