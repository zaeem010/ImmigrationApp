using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
{
    public class CompanyInfoRepo : ICompanyInfoRepo
    {
        public ApplicationDbContext _db { get; set; }
        public CompanyInfoRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<CompanyInfo>  GetSingleCompanyInfo(int UserId)
        {
            var companyInfo = await _db.CompanyInfo
                .Include(x=>x.JobList)
                .SingleOrDefaultAsync(c => c.UserId.Equals(UserId));
            return companyInfo;
        }

        public async Task<CompanyInfo> GetCompanyInfoByslugName(string SlugName)
        {
            var companyInfo = await _db.CompanyInfo
                .Include(c=>c.JobList)
                .SingleOrDefaultAsync(c => c.SlugName.Equals(SlugName));
            return companyInfo;
        }

        public Task<bool> AddUpdateCompanyInfo(CompanyInfo CompanyInfo)
        {
            throw new NotImplementedException();
        }
    }
}
