using ImmigrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
{
    public interface IJobPostRepository
    {
        void SaveJob(Job Job);
        IEnumerable<Job> GetAllJob();
        Job GetJob(long id);
        void DeleteJob(long id);
        void UpdateJob(Job Job);
    }
}
