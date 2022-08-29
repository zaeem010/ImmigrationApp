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

        public async Task<string> SaveJob(Job Job)
        {
            string message;
            if (Job.Id == 0)
            {
                await _db.Job.AddAsync(Job);
                message = "Registerd Successfully";
            }
            else 
            {
                var t = await _db.JobTypeChild.Where(z=>z.JobId.Equals(Job.Id)).ToListAsync();
                var S = await _db.JobScheduleChild.Where(z=>z.JobId.Equals(Job.Id)).ToListAsync();
                var Sup = await _db.SupplementalPayChild.Where(z=>z.JobId.Equals(Job.Id)).ToListAsync();
                var Ben = await _db.BenefitOfferedChild.Where(z=>z.JobId.Equals(Job.Id)).ToListAsync();
                _db.JobTypeChild.RemoveRange(t);
                _db.JobScheduleChild.RemoveRange(S);
                _db.SupplementalPayChild.RemoveRange(Sup);
                _db.BenefitOfferedChild.RemoveRange(Ben);
                _db.Job.Update(Job);
                message = "Updated Successfully";
            }
            await _db.SaveChangesAsync();
            return message;
        }
    }
}
