using ImmigrationApp.Contract;
using ImmigrationApp.Models;
using ImmigrationApp.Repositries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services
{
    public class CompanyInfoService : ICompanyInfoServices
    {
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly ICompanyInfoRepo _repository;

        public CompanyInfoService(ILogger<CompanyInfoService> logger, ICompanyInfoRepo repository)
        {
            _logger = logger;
            _repository = repository;

        }

        public async Task<IResult<bool>> AddUpdateCompanyInfo(CompanyInfo CompanyInfo)
        {

            const string message = "Unable to Add/Update Banner, please check input data and try again.";
            try
            {
                var result = await _repository.AddUpdateCompanyInfo(CompanyInfo);

                if (result)
                {
                    return await Result<bool>.SuccessAsync(result);
                }

                _logger.LogError(message);

                return await Result<bool>.FailAsync(message);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return await Result<bool>.FailAsync(message);
            }
        }

        public Task<IResult<List<CompanyInfo>>> GetCompanyInfo()
        {
            throw new NotImplementedException();
        }

        public Task<IResult<CompanyInfo>> GetCompanyInfo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<CompanyInfo>> GetSingleCompanyInfo(int id)
        {
            const string message = "Unable to get CompanyInfo.";

            try
            {
                var result = await _repository.GetSingleCompanyInfo(id);

                if (result != null)
                {
                    return await Result<CompanyInfo>.SuccessAsync(result);
                }

                _logger.LogError(message);

                return await Result<CompanyInfo>.FailAsync(message);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return await Result<CompanyInfo>.FailAsync(message);
            }
        }
    }
}
