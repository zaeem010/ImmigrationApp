using ImmigrationApp.Contract;
using ImmigrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
{
    public interface ICompanyInfoServices
    {
        Task<IResult<bool>> AddUpdateCompanyInfo(CompanyInfo CompanyInfo);
        public Task<IResult<List<CompanyInfo>>> GetCompanyInfo();
        Task<IResult<CompanyInfo>> GetSingleCompanyInfo(int id);
    }
}
