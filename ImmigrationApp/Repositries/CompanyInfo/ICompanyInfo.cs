using ImmigrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
{
    public interface ICompanyInfoRepo
    {
        Task<CompanyInfo> GetSingleCompanyInfo(int UserId);
        Task<CompanyInfo> GetCompanyInfoByslugName(string SlugName);
        Task<bool> AddUpdateCompanyInfo(CompanyInfo CompanyInfo);
    }
}
