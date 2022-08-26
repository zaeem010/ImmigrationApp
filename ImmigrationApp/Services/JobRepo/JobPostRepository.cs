using ImmigrationApp.Data;
using ImmigrationApp.Models;
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
        public void DeleteJob(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAllJob()
        {
            throw new NotImplementedException();
        }

        public Job GetJob(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveJob(Job Job)
        {
            throw new NotImplementedException();
        }

        public void UpdateJob(Job Job)
        {
            throw new NotImplementedException();
        }
    }
}
