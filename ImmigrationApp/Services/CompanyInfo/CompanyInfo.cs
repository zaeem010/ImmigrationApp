using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
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
            var companyInfo = await _db.CompanyInfo.SingleOrDefaultAsync(c => c.UserId.Equals(UserId));
            return companyInfo;
        }

        public async Task<CompanyInfo> GetCompanyInfoByslugName(string SlugName)
        {
            var companyInfo = await _db.CompanyInfo.SingleOrDefaultAsync(c => c.SlugName.Equals(SlugName));
            return companyInfo;
        }
    }
}
