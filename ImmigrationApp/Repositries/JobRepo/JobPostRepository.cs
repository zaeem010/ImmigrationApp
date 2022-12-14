using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
{
    public class JobPostRepository : IJobPostRepository
    {
        public ApplicationDbContext _db;
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

        public async Task<List<Job>> GetAllJob(int id)
        {
            try
            {
                var List = await _db.Job
                    .Where(x=>x.UserId.Equals(id))
                    .ToListAsync();
                return List;
            }
            catch (Exception e)
            {
                var error= e.Message;
                throw;
            }
        }

        public async Task<Job> GetJob(long id)
        {
            var result = await _db.Job
                .Include(x => x.SupplementalPayChildList)
                .Include(x => x.BenefitOfferedChildList)
                .Include(x => x.JobTypeChildList)
                .Include(x => x.JobScheduleChildList)
                .Include(x => x.JobSubCategory)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
                return result;
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
            if (Job.SpecificAddress == true)
            {
                Job.AddressToAdvertise = " ";
                Job.MutualAddress = Job.Street;
            }
            if (Job.SpecificAddress == false)
            {
                Job.Street = " ";
                Job.City = " ";
                Job.PostalCode = " ";
                Job.Province = " ";
                Job.MutualAddress = Job.AddressToAdvertise;
            }
            string Slugname = Job.Title;
            Job.JobSubCategoryId = Convert.ToInt64(30024);
            Job.SlugName = Slugname.Replace(" ", "-");
            var check = await _db.JobSubCategory.Where(x => x.Name.Contains(Job.Title)).CountAsync();
            if (check == 0)
            {
                var subcat = new JobSubCategory();
                subcat.Id = 0;
                subcat.JobMainCategoryId = Convert.ToInt64(519);
                subcat.Name = Job.Title;
                await _db.JobSubCategory.AddAsync(subcat);
            }
            if (Job.Id == 0)
            {
                Random rnd = new Random();
                Job.PostDateTime = DateTime.Now;
                Job.CallBy = rnd.Next(0, 1000000).ToString("D6");
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
            try
            {
                await _db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
            return message;
        }

        public async Task<long> GetCompanyId(int id)
        {
            var result = await _db.CompanyInfo.SingleOrDefaultAsync(c => c.UserId == id);
            if (result != null)
            {
                return result.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
